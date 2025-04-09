using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIRH.DTO;
using Microsoft.Data.SqlClient;
using SIRH.Web.ViewModels;

namespace SIRH.Web.Controllers
{
    public class ModuloJefaturaController : Controller
    {
        // GET: ModuloJefatura
        public ActionResult Index(int? idSolicitud)
        {
            string cedula = "3214567370";

            // Crear el modelo de vista
            PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();
            modelo.Funcionario = ObtenerFuncionario(cedula);
          
            // Cargar todas las solicitudes pendientes para la jefatura
            modelo.ListaSolicitudesPendientes = ObtenerSolicitudesPendientes(cedula);

            // Si se envió un id de solicitud, se carga esa solicitud; de lo contrario, se carga la primera de la lista (si existe)
            if (idSolicitud.HasValue)
            {
                modelo.SolicitudTeletrabajo = ObtenerSolicitudPorId(idSolicitud.Value);
                modelo.IdSolicitudSeleccionada = idSolicitud.Value;
            }
            else if (modelo.ListaSolicitudesPendientes != null && modelo.ListaSolicitudesPendientes.Count > 0)
            {
                // Por defecto se carga la primera solicitud pendiente
                modelo.SolicitudTeletrabajo = modelo.ListaSolicitudesPendientes[0];
                modelo.IdSolicitudSeleccionada = modelo.ListaSolicitudesPendientes[0].IdEntidad;
            }

            return View(modelo);
        }

        public ActionResult TiempoFuera()
        {
            Session["errorF"] = null;
            try
            {
                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();
                modelo.personal = funcionarios();
                modelo.TiposSalida = new SelectList(ObtenerTiposSalida(), "Value", "Text");
                return View(modelo);
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";

                if (error.Message != "modelo")
                {
                    ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de ver el perfil del funcionario, ponerse en contacto con el personal autorizado. \n" + error.Message);
                }
                else
                {
                    ModelState.AddModelError("modelo", "No existen datos del lugar de contrato ni el lugar de trabajo.\n\n Pongase en contacto con el personal autorizado.");
                }
                return View();
            }
        }

        // Método para obtener los tipos de salida (por ahora quemado)
        private List<SelectListItem> ObtenerTiposSalida()
        {
            // Temporalmente quemado, cambiar a BD cuando esté lista
            List<SelectListItem> tiposSalida = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Vacaciones" },
                new SelectListItem { Value = "2", Text = "Incapacidad" }
            };

            /* Cargar desde la base de datos
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Clasificacion FROM TipoSalida";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tiposSalida.Add(new SelectListItem
                            {
                                Value = reader["Id"].ToString(),
                                Text = reader["Clasificacion"].ToString()
                            });
                        }
                    }
                }
            }
            */

            return tiposSalida;
        }
        public ActionResult Desempeno()
        {
            Session["errorF"] = null;
            try
            {
                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();
                modelo.personal = funcionarios();
                return View(modelo);
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";

                if (error.Message != "modelo")
                {
                    ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de ver el perfil del funcionario, ponerse en contacto con el personal autorizado. \n" + error.Message);
                }
                else
                {
                    ModelState.AddModelError("modelo", "No existen datos del lugar de contrato ni el lugar de trabajo.\n\n Pongase en contacto con el personal autorizado.");
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult NuevoRegistro(PerfilFuncionarioVM model, string StartDate, string EndDate, string SubmitButton)
        {
            int salida = int.Parse(model.TipoSalidaSeleccionada);
            Session["errorF"] = null;
            try
            {
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";

                // Validar conflicto de fechas
                string checkQuery = @"
                    SELECT COUNT(*) FROM TiempoFuera
                    WHERE FK_Funcionario = @Funcionario
                    AND (
                         (@Inicio BETWEEN Inicio AND Final)
                         OR (@Final BETWEEN Inicio AND Final)
                         OR (Inicio BETWEEN @Inicio AND @Final) 
                         OR (Final BETWEEN @Inicio AND @Final)
                    )";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Funcionario", Int32.Parse(model.personalseleccionado));
                        checkCommand.Parameters.AddWithValue("@Inicio", StartDate);
                        checkCommand.Parameters.AddWithValue("@Final", EndDate);

                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            ModelState.AddModelError("ConflictoFechas", "Conflicto de fechas detectado o registro ya existente. Verifique las fechas antes de guardar.");
                            return View();
                        }
                    }

                    string query = @"
                        INSERT INTO TiempoFuera (
                            FK_Funcionario,
                            Tipo,
                            Inicio,
                            Final
                        )
                        OUTPUT INSERTED.TiempoFuera_PK
                        VALUES (
                            @Funcionario,
                            @Tipo,
                            @Inicio,
                            @Final
                        );";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Funcionario", Int32.Parse(model.personalseleccionado));
                        command.Parameters.AddWithValue("@Tipo", salida);
                        command.Parameters.AddWithValue("@Inicio", StartDate);
                        command.Parameters.AddWithValue("@Final", EndDate);
                        command.ExecuteNonQuery();
                    }
                }
                return View();
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";
                System.Diagnostics.Debug.WriteLine($"20-Error al conectar a la base de datos: {error.Message}");
                ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de ver el perfil del funcionario, ponerse en contacto con el personal autorizado. \n" + error.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult RegistroDesempeno(PerfilFuncionarioVM model, int mes, int metricas, int horario, int tardias, int abandonos, string SubmitButton)
        {
            Session["errorF"] = null;
            try
            {
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";

                // Validar si ya existe un registro para el periodo
                string checkQuery = @"
                    SELECT COUNT(*) FROM RegistroRendimiento
                    WHERE FK_Funcionario = @Funcionario
                      AND Periodo = @Periodo
                      AND Ano = @Ano";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Funcionario", Int32.Parse(model.personalseleccionado));
                        checkCommand.Parameters.AddWithValue("@Periodo", mes);
                        checkCommand.Parameters.AddWithValue("@Ano", 2025);

                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            ModelState.AddModelError("RegistroDuplicado", "Ya existe un registro para este colaborador en el mismo mes y año.");
                            return View();
                        }
                    }

                    string query = @"
                        INSERT INTO RegistroRendimiento (
                            FK_Funcionario,
                            Metricas,
                            Tardias,
                            Abandono,
                            CHorario,
                            Periodo,
                            Ano
                        )
                        OUTPUT INSERTED.RegistroRendimiento_PK
                        VALUES (
                            @Funcionario,
                            @Metricas,
                            @Tardias,
                            @Abandono,
                            @CHorario,
                            @Periodo,
                            @Ano
                        );";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Funcionario", Int32.Parse(model.personalseleccionado));
                        command.Parameters.AddWithValue("@Metricas", metricas);
                        command.Parameters.AddWithValue("@Tardias", tardias);
                        command.Parameters.AddWithValue("@Abandono", abandonos);
                        command.Parameters.AddWithValue("@CHorario", horario);
                        command.Parameters.AddWithValue("@Periodo", mes);
                        command.Parameters.AddWithValue("@Ano", 2025);

                        command.ExecuteNonQuery();
                    }
                }
                return View();
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";
                System.Diagnostics.Debug.WriteLine($"20-Error al conectar a la base de datos: {error.Message}");
                ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de ver el perfil del funcionario, ponerse en contacto con el personal autorizado. \n" + error.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult ActualizarAval(PerfilFuncionarioVM modelo, string SubmitButton)
        {
            try
            {
                // Actualiza campos de la solicitud
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
                string query = @"
                    UPDATE SolicitudTeletrabajo 
                    SET 
                        AprobadoJefaturaInmediata = @AvalJefatura,
                        AprobadoJefaturaSuperior = @AprobadoJefaturaSuperior,
                        ComentarioAval = @ComentarioAval
                    WHERE PK_SolicitudTeletrabajo = @SolicitudId;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AvalJefatura", modelo.SolicitudTeletrabajo.AprobadoJefaturaInmediata);
                        command.Parameters.AddWithValue("@AprobadoJefaturaSuperior", modelo.SolicitudTeletrabajo.AprobadoJefaturaSuperior);
                        command.Parameters.AddWithValue("@ComentarioAval", modelo.SolicitudTeletrabajo.ComentarioAval ?? "");
                        command.Parameters.AddWithValue("@SolicitudId", modelo.SolicitudTeletrabajo.IdEntidad);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                ViewBag.Message = "El aval de la solicitud ha sido actualizado exitosamente.";
                return RedirectToAction("Index", new { idSolicitud = modelo.SolicitudTeletrabajo.IdEntidad });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Ha ocurrido un error al actualizar el aval: " + ex.Message);
                return View("Index", modelo);
            }
        }

        [HttpPost]
        public ActionResult BuscarPorCedula(string cedula)
        {
            CFuncionarioDTO funcionario = ObtenerFuncionario(cedula);
            bool tieneSolicitudTeletrabajo = false;

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string queryTeletrabajo = "SELECT COUNT(*) FROM SolicitudTeletrabajo WHERE FK_Funcionario = @idFuncionario";
                    SqlCommand cmdTeletrabajo = new SqlCommand(queryTeletrabajo, connection);
                    cmdTeletrabajo.Parameters.AddWithValue("@idFuncionario", funcionario.IdEntidad);

                    tieneSolicitudTeletrabajo = (int)cmdTeletrabajo.ExecuteScalar() > 0;
                }
                catch (Exception)
                {
                    return PartialView("_ErrorContrato", "Ocurrió un error en la búsqueda.");
                }
            }

            if (!tieneSolicitudTeletrabajo)
            {
                return PartialView("_ErrorContrato", "Este funcionario no tiene una solicitud de teletrabajo registrada.");
            }

            return PartialView("_DetalleFuncionario", funcionario);
        }

        /// <summary>
        /// Acción para mostrar el histórico de solicitudes (aceptadas, rechazadas, etc.)

        public ActionResult MovimientoTeletrabajo(string periodo = null)
        {

            string cedula = "0876543210";


            var vm = new PerfilFuncionarioVM();


            var historicoSolicitudes = ObtenerHistoricoTeletrabajo(cedula, periodo);


            vm.solicitudes = historicoSolicitudes;


            return View(vm);
        }

        /// <summary>
        /// Método auxiliar para obtener el histórico de teletrabajo (todas las solicitudes) de un funcionario
        /// </summary>
        private List<SolicitudTeletrabajoDTO> ObtenerHistoricoTeletrabajo(string cedula, string periodo)
        {
            List<SolicitudTeletrabajoDTO> lista = new List<SolicitudTeletrabajoDTO>();

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Trae todas las solicitudes del funcionario
                    string query = @"
                        SELECT *
                        FROM SolicitudTeletrabajo
                        WHERE FK_Funcionario IN (
                            SELECT PK_Funcionario FROM Funcionario 
                            WHERE IdCedulaFuncionario = @cedula
                        )
                        ORDER BY PK_SolicitudTeletrabajo DESC
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cedula", cedula);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var solicitud = new SolicitudTeletrabajoDTO();
                                solicitud.IdEntidad = reader.GetInt32(0);
                                solicitud.Escolaridad = reader.GetInt32(1);
                                solicitud.DistritoSecundario = reader.GetInt32(2);
                                solicitud.DireccionExactaSecundaria = reader.GetString(3);
                                solicitud.CantidadPersonasDireccionSecundaria = reader.GetInt32(4);
                                solicitud.CantidadPersonasDireccionPrimaria = reader.GetInt32(5);
                                solicitud.TiempoLaborarMOPT = reader.GetString(6);
                                solicitud.Teletrabajable = reader.GetBoolean(7);
                                solicitud.CantidadDiasTeletrabajo = reader.GetInt32(8);
                                solicitud.DetalleDiasTeletrabajo = reader.GetString(9);
                                solicitud.Horario = reader.GetString(10);
                                solicitud.Funciones = reader.GetString(11);
                                solicitud.TiempoFunciones = reader.GetInt32(12);
                                solicitud.Razones = reader.GetString(13);
                                solicitud.DeclaracionJurada = reader.GetBoolean(14);
                                solicitud.Sistemas = reader.GetString(15);
                                solicitud.AprobadoJefaturaInmediata = reader.GetBoolean(16);

                                if (!reader.IsDBNull(17))
                                    solicitud.ComentarioAval = reader.GetString(17);

                                // Si la tabla tiene la columna AprobadoJefaturaSuperior en índice 18
                                if (reader.FieldCount > 18 && !reader.IsDBNull(18))
                                    solicitud.AprobadoJefaturaSuperior = reader.GetBoolean(18);

                                // Suponiendo que en la posición 19 está FechaSolicitud (DateTime)
                                // Ajusta si tu columna está en otra posición o usa reader["FechaSolicitud"]
                               // if (reader.FieldCount > 19 && !reader.IsDBNull(19))
                                   // solicitud.FechaSolicitud = reader.GetDateTime(19);

                                lista.Add(solicitud);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al obtener histórico de teletrabajo: " + ex.Message);
                }
            }



            return lista;
        }

        // -----------------------------
        // Métodos auxiliares existentes
        // -----------------------------

        private CFuncionarioDTO getfuncionario(int v)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CFuncionarioDTO func = new CFuncionarioDTO();

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    string query = "SELECT * FROM Funcionario WHERE PK_Funcionario = " + v;
                    SqlCommand command = new SqlCommand(query, connectionfake);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            func.IdEntidad = reader.GetInt32(0);
                            func.Cedula = reader.GetString(8);
                            func.Nombre = reader.GetString(3);
                            func.PrimerApellido = reader.GetString(4);
                            func.SegundoApellido = reader.GetString(5);
                            func.FechaNacimiento = reader.GetDateTime(6);
                            func.Sexo = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader.GetString(7));
                            Session["Identidad"] = reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Hi-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return func;
        }

        private CFuncionarioDTO ObtenerFuncionario(string cedula)
        {
            CFuncionarioDTO funcionario = new CFuncionarioDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Funcionario WHERE IdCedulaFuncionario = @cedula";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cedula", cedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            funcionario.IdEntidad = reader.GetInt32(0);
                            funcionario.Cedula = reader.GetString(8);
                            funcionario.Nombre = reader.GetString(3);
                            funcionario.PrimerApellido = reader.GetString(4);
                            funcionario.SegundoApellido = reader.GetString(5);
                            funcionario.FechaNacimiento = reader.GetDateTime(6);
                            funcionario.Sexo = (GeneroEnum)Enum.Parse(typeof(GeneroEnum), reader.GetString(7));
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al obtener funcionario: " + ex.Message);
                }
            }
            return funcionario;
        }

        private List<SolicitudTeletrabajoDTO> ObtenerSolicitudesPendientes(string cedula)
        {
            List<SolicitudTeletrabajoDTO> lista = new List<SolicitudTeletrabajoDTO>();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT * 
                        FROM SolicitudTeletrabajo 
                        WHERE FK_Funcionario IN (
                            SELECT PK_Funcionario FROM Funcionario WHERE IdCedulaFuncionario = @cedula
                        )
                        AND IndAprobadoJefatura = 0 
                        ORDER BY PK_SolicitudTeletrabajo DESC";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@cedula", cedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var solicitud = new SolicitudTeletrabajoDTO();
                            solicitud.IdEntidad = reader.GetInt32(0);
                            solicitud.Escolaridad = reader.GetInt32(1);
                            solicitud.DistritoSecundario = reader.GetInt32(2);
                            solicitud.DireccionExactaSecundaria = reader.GetString(3);
                            solicitud.CantidadPersonasDireccionSecundaria = reader.GetInt32(4);
                            solicitud.CantidadPersonasDireccionPrimaria = reader.GetInt32(5);
                            solicitud.TiempoLaborarMOPT = reader.GetString(6);
                            solicitud.Teletrabajable = reader.GetBoolean(7);
                            solicitud.CantidadDiasTeletrabajo = reader.GetInt32(8);
                            solicitud.DetalleDiasTeletrabajo = reader.GetString(9);
                            solicitud.Horario = reader.GetString(10);
                            solicitud.Funciones = reader.GetString(11);
                            solicitud.TiempoFunciones = reader.GetInt32(12);
                            solicitud.Razones = reader.GetString(13);
                            solicitud.DeclaracionJurada = reader.GetBoolean(14);
                            solicitud.Sistemas = reader.GetString(15);
                            solicitud.AprobadoJefaturaInmediata = reader.GetBoolean(17);

                            if (!reader.IsDBNull(20))
                                solicitud.ComentarioAval = reader.GetString(20);

                            if (reader.FieldCount > 18 && !reader.IsDBNull(18))
                                solicitud.AprobadoJefaturaSuperior = reader.GetBoolean(18);

                            lista.Add(solicitud);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al obtener solicitudes pendientes: " + ex.Message);
                }
            }
            return lista;
        }

        private SolicitudTeletrabajoDTO ObtenerSolicitudPorId(int idSolicitud)
        {
            SolicitudTeletrabajoDTO solicitud = new SolicitudTeletrabajoDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM SolicitudTeletrabajo WHERE PK_SolicitudTeletrabajo = @idSolicitud";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            solicitud.IdEntidad = reader.GetInt32(0);
                            solicitud.Escolaridad = reader.GetInt32(1);
                            solicitud.DistritoSecundario = reader.GetInt32(2);
                            solicitud.DireccionExactaSecundaria = reader.GetString(3);
                            solicitud.CantidadPersonasDireccionSecundaria = reader.GetInt32(4);
                            solicitud.CantidadPersonasDireccionPrimaria = reader.GetInt32(5);
                            solicitud.TiempoLaborarMOPT = reader.GetString(6);
                            solicitud.Teletrabajable = reader.GetBoolean(7);
                            solicitud.CantidadDiasTeletrabajo = reader.GetInt32(8);
                            solicitud.DetalleDiasTeletrabajo = reader.GetString(9);
                            solicitud.Horario = reader.GetString(10);
                            solicitud.Funciones = reader.GetString(11);
                            solicitud.TiempoFunciones = reader.GetInt32(12);
                            solicitud.Razones = reader.GetString(13);
                            solicitud.DeclaracionJurada = reader.GetBoolean(14);
                            solicitud.Sistemas = reader.GetString(15);
                            solicitud.AprobadoJefaturaInmediata = reader.GetBoolean(16);

                            if (!reader.IsDBNull(17))
                                solicitud.ComentarioAval = reader.GetString(17);

                            if (reader.FieldCount > 18 && !reader.IsDBNull(18))
                                solicitud.AprobadoJefaturaSuperior = reader.GetBoolean(18);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al obtener solicitud por id: " + ex.Message);
                }
            }
            return solicitud;
        }

        SelectList funcionarios()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            SelectList listado;
            CFuncionarioDTO aux;

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Ejemplo: Tomar funcionarios con IndAprobadoSuperior = 0
                    string querynom = "SELECT * FROM SolicitudTeletrabajo WHERE IndAprobadoSuperior = 0";
                    SqlCommand command = new SqlCommand(querynom, connectionfake);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = getfuncionario(reader.GetInt32(16));
                            if (!lista.Any(p => p.Value == aux.Cedula))
                            {
                                lista.Add(new SelectListItem
                                {
                                    Text = aux.Nombre + " " + aux.PrimerApellido + " " + aux.SegundoApellido,
                                    Value = aux.IdEntidad.ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"4-Error al conectar a la base de datos: {ex.Message}");
            }

            listado = new SelectList(lista, "Value", "Text");
            return listado;
        }
    }
}