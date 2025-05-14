using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIRH.DTO;
using Microsoft.Data.SqlClient;
using SIRH.Web.ViewModels;
using System.Drawing.Printing;
using SIRH.Web.AntecedentesPenalesService;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace SIRH.Web.Controllers
{
    public class ModuloJefaturaController : Controller
    {
        // GET: ModuloJefatura
        public ActionResult Index(int? idSolicitud)
        {
            Session["errorF"] = null;
            try
            {
                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();
                modelo.personal = funcionariospendientes();
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
        public ActionResult NuevoRegistro(PerfilFuncionarioVM model, string StartDate, string EndDate, double cantidadDias, string SubmitButton)
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
                            
                            var respuesta1 = new { mensaje = "Conflicto de fechas detectado o registro ya existente. Verifique las fechas antes de guardar.", estado = false };

                            return Json(respuesta1);
                        }
                    }

                    string query = @"
                        INSERT INTO TiempoFuera (
                            FK_Funcionario,
                            Tipo,
                            Inicio,
                            Final,
                            cantidad
                        )
                        OUTPUT INSERTED.TiempoFuera_PK
                        VALUES (
                            @Funcionario,
                            @Tipo,
                            @Inicio,
                            @Final,
                            @cantidad
                        );";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Funcionario", Int32.Parse(model.personalseleccionado));
                        command.Parameters.AddWithValue("@Tipo", salida);
                        command.Parameters.AddWithValue("@Inicio", StartDate);
                        command.Parameters.AddWithValue("@Final", EndDate);
                        command.Parameters.AddWithValue("@cantidad", cantidadDias);
                        command.ExecuteNonQuery();
                    }
                }
                var respuesta = new { mensaje = "Guardado correctamente", estado = true };

                return Json(respuesta);
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";
                System.Diagnostics.Debug.WriteLine($"20-Error al conectar a la base de datos: {error.Message}");
                var respuesta2 = new { mensaje = "Ha ocurrido un error al conectar con la base de datos", estado = false };
                return Json(respuesta2);
            }
        }

        [HttpPost]
        public ActionResult RegistroDesempeno(PerfilFuncionarioVM model, int mes, int metricas, int horario, int tardias, int abandonos, string observaciones, string SubmitButton)
        {
            Session["errorF"] = null;
            try
            {
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";

                System.Diagnostics.Debug.Print(model.personalseleccionado);
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
                           
                            var respuesta1 = new { mensaje = "Ya existe un registro para este colaborador en el mismo mes y año.", estado = false };

                            return Json(respuesta1);
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
                            Ano,
                            Observaciones
                        )
                        OUTPUT INSERTED.RegistroRendimiento_PK
                        VALUES (
                            @Funcionario,
                            @Metricas,
                            @Tardias,
                            @Abandono,
                            @CHorario,
                            @Periodo,
                            @Ano,
                            @Observaciones
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
                        command.Parameters.AddWithValue("@Observaciones", observaciones);
                        command.ExecuteNonQuery();
                    }
                }
                var respuesta = new { mensaje = "Guardado correctamente", estado = true };

                return Json(respuesta);
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";
                System.Diagnostics.Debug.WriteLine($"20-Error al conectar a la base de datos: {error.Message}");
                var respuesta2 = new { mensaje = "Ha ocurrido un error al conectar con la base de datos", estado = false };

                return Json(respuesta2);
            }
        }

        [HttpPost]
        public ActionResult ActualizarAval( string aval, string comentarios)
        {
            bool avals = false;
            string notificacion = "";
            try
            {
                if (aval == "1") { avals = true; }
                // Actualiza campos de la solicitud
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
                string query = @"
                    UPDATE SolicitudTeletrabajo 
                    SET 
                        IndAprobadoJefatura = @AvalJefatura,
                        IndAprobadoSuperior = @AprobadoJefaturaSuperior,
                        FechaAprobacion = @fecha,
                        ComentarioAval = @ComentarioAval
                    WHERE PK_SolicitudTeletrabajo = @SolicitudId;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if ((int)Session["FamiliaPuesto"] == 2)
                        {
                            command.Parameters.AddWithValue("@AvalJefatura", avals);
                            command.Parameters.AddWithValue("@AprobadoJefaturaSuperior", avals);
                            if (aval == "1")
                            {
                                command.Parameters.AddWithValue("@fecha", DateTime.Now);
                            }
                            }
                        if ((int)Session["FamiliaPuesto"] == 1)
                        {
                            command.Parameters.AddWithValue("@AvalJefatura", avals);
                            command.Parameters.AddWithValue("@AprobadoJefaturaSuperior", false);
                        }
                        command.Parameters.AddWithValue("@fecha", DBNull.Value);
                        command.Parameters.AddWithValue("@ComentarioAval", comentarios ?? "");
                        command.Parameters.AddWithValue("@SolicitudId", Int32.Parse(Session["SolicitudID"].ToString()));
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                
                if (aval == "1") {
                    if ((int)Session["FamiliaPuesto"] == 1) {
                        notificacion = "Su jefatura ha aprobado su solicitud. Comentarios: " + comentarios;
                    }
                    if ((int)Session["FamiliaPuesto"] == 2)
                    {
                        notificacion = "Su superior ha aprobado su solicitud. Comentarios: " + comentarios;
                    }
                    RegistroMovimiento(comentarios, Int32.Parse(Session["FuncionarioID"].ToString()), "Aprobado", Int32.Parse(Session["SolicitudID"].ToString()));
                }
                else
                {
                    if ((int)Session["FamiliaPuesto"] == 1)
                    {
                        notificacion = "Su jefatura ha rechazado su solicitud. Comentarios: " + comentarios;
                    }
                    if ((int)Session["FamiliaPuesto"] == 2)
                    {
                        notificacion = "Su superior ha rechazado su solicitud. Comentarios: " + comentarios;
                    }
                    RegistroMovimiento(comentarios, Int32.Parse(Session["FuncionarioID"].ToString()), "Rechazado", Int32.Parse(Session["SolicitudID"].ToString()));
                }

                GenerarNotificacion(notificacion, Int32.Parse(Session["FuncionarioID"].ToString()));
                enviarCorreo(notificacion, "dayverfx@gmail.com");

                var respuesta = "El aval de la solicitud ha sido actualizado exitosamente.";

                return Json(new
                {
                    success = true,
                    respuesta = respuesta
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                var respuesta = "Ha ocurrido un error al actualizar el aval: " + ex.Message ;

                return Json(new
                {
                    success = false,
                    respuesta = respuesta
                }, JsonRequestBehavior.AllowGet);
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
            return View();
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

        private CFuncionarioDTO ObtenerFuncionario(string id)
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
                    command.Parameters.AddWithValue("@cedula", id);
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

        private CFuncionarioDTO ObtenerFuncionarioid(int id)
        {
            CFuncionarioDTO funcionario = new CFuncionarioDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Funcionario WHERE PK_Funcionario = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
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

        private SolicitudTeletrabajoDTO ObtenerSolicitudPorId(int idfuncionario)
        {
            SolicitudTeletrabajoDTO solicitud = new SolicitudTeletrabajoDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            string query;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    if ((int)Session["FamiliaPuesto"] == 1)
                    {
                        query = "SELECT TOP 1 * FROM SolicitudTeletrabajo WHERE (FK_Funcionario = @idfuncionario AND IndAprobadoJefatura = 0) ORDER BY PK_SolicitudTeletrabajo DESC";
                    }
                    else
                    {
                        query = "SELECT TOP 1 * FROM SolicitudTeletrabajo WHERE (FK_Funcionario = @idfuncionario AND IndAprobadoJefatura = 1) ORDER BY PK_SolicitudTeletrabajo DESC";
                    }
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@idfuncionario", idfuncionario);
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
                            solicitud.TiempoLaborarDependencia = reader.GetString(19);
                            solicitud.AprobadoJefaturaInmediata = reader.GetBoolean(17);

                            if (!reader.IsDBNull(20))
                                solicitud.ComentarioAval = reader.GetString(20);

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

        [HttpPost]
        public ActionResult GetSolicitud(int idfuncionario)
        {
            
            try
            {
                SolicitudTeletrabajoDTO solicitud = ObtenerSolicitudPorId(idfuncionario);
                CFuncionarioDTO funcionario = ObtenerFuncionarioid(idfuncionario);
                Session["FuncionarioID"] = idfuncionario;
                Session["SolicitudID"] = solicitud.IdEntidad;
                CDistritoDTO distrito = getDistrito(solicitud.DistritoSecundario);
                CDireccionDTO dir = getDireccion(idfuncionario);
                System.Diagnostics.Debug.Print(funcionario.Cedula);
                return Json(new
                {
                    success = true,
                    cedula = funcionario.Cedula + " - " + funcionario.Nombre + " " + funcionario.PrimerApellido + " " + funcionario.SegundoApellido,
                    distritop = dir.Distrito.NomDistrito + ", " + dir.Distrito.Canton.NomCanton + ", " + dir.Distrito.Canton.Provincia.NomProvincia,
                    direccionp = dir.DirExacta,
                    distrito = distrito.NomDistrito + ", " + distrito.Canton.NomCanton + ", " +distrito.Canton.Provincia.NomProvincia,
                    direccion = solicitud.DireccionExactaSecundaria,
                    dias = solicitud.CantidadDiasTeletrabajo,
                    perpri = solicitud.CantidadPersonasDireccionPrimaria,
                    persecu = solicitud.CantidadPersonasDireccionSecundaria,
                    tiempom = solicitud.TiempoLaborarMOPT + " año(s)",
                    tiempod = solicitud.TiempoLaborarDependencia + " año(s)",
                    hora = solicitud.Horario,
                    funciones = solicitud.Funciones,
                    sistemas = solicitud.Sistemas,
                    razones = solicitud.Razones,
                    detalle = Regex.Replace(solicitud.DetalleDiasTeletrabajo, "([A-Z])", ", $1").TrimStart(' ', ','),
                    aprjefe = solicitud.AprobadoJefaturaInmediata,
                    aprsup = solicitud.AprobadoJefaturaSuperior,
                    id = solicitud.IdEntidad,
                    comentarios = solicitud.ComentarioAval
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.Print(error.Message);
                return Json(new { success = false, mensaje = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        SelectList funcionarios()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            SelectList listado;
            CFuncionarioDTO aux;
            string querynom;

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    if ((int)Session["FamiliaPuesto"] == 1)
                    {
                        querynom = "SELECT * FROM SolicitudTeletrabajo WHERE IndAprobadoSuperior = 1 AND FK_Funcionario IN (" +
                            "SELECT PK_Funcionario FROM Funcionario WHERE FK_Puesto IN ( SELECT PK_Puesto FROM Puesto WHERE FK_UbicacionAdministrativa = @ubicacion AND FK_FamiliaPuesto = 3)  AND IdCedulaFuncionario != @cedula )";
                    }
                    else {
                        querynom = "SELECT * FROM SolicitudTeletrabajo WHERE IndAprobadoSuperior = 1 AND FK_Funcionario IN (" +
                            "SELECT PK_Funcionario FROM Funcionario WHERE FK_Puesto IN ( SELECT PK_Puesto FROM Puesto WHERE FK_UbicacionAdministrativa = @ubicacion) AND IdCedulaFuncionario != @cedula )";
                    }
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    command.Parameters.AddWithValue("@ubicacion", Int32.Parse(Session["Ubicacion"].ToString()));
                    command.Parameters.AddWithValue("@cedula", Session["CedulaUsuario"].ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = getfuncionario(reader.GetInt32(16));
                            if (!lista.Any(p => p.Value == aux.IdEntidad.ToString()))
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

        SelectList funcionariospendientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            SelectList listado;
            CFuncionarioDTO aux;
            string querynom;

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    if ((int)Session["FamiliaPuesto"] == 1)
                    {
                        querynom = "SELECT * FROM SolicitudTeletrabajo WHERE FK_Funcionario IN (" +
                            "SELECT PK_Funcionario FROM Funcionario WHERE FK_Puesto IN ( SELECT PK_Puesto FROM Puesto WHERE FK_UbicacionAdministrativa = @ubicacion AND FK_FamiliaPuesto = 3)  AND IdCedulaFuncionario != @cedula )";
                    }
                    else
                    {
                        querynom = "SELECT * FROM SolicitudTeletrabajo WHERE IndAprobadoJefatura = 1 AND FK_Funcionario IN (" +
                            "SELECT PK_Funcionario FROM Funcionario WHERE FK_Puesto IN ( SELECT PK_Puesto FROM Puesto WHERE FK_UbicacionAdministrativa = @ubicacion) AND IdCedulaFuncionario != @cedula )";
                    }
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    command.Parameters.AddWithValue("@ubicacion", Int32.Parse(Session["Ubicacion"].ToString()));
                    command.Parameters.AddWithValue("@cedula", Session["CedulaUsuario"].ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = getfuncionario(reader.GetInt32(16));
                            if (!lista.Any(p => p.Value == aux.IdEntidad.ToString()) && !topaprobado(aux.IdEntidad))
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

        Boolean topaprobado(int idfuncionario) {
            bool aprobado = false;

            string querynom;

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");


                    querynom = "SELECT TOP 1 * FROM SolicitudTeletrabajo WHERE FK_Funcionario = " + idfuncionario + " ORDER BY PK_SolicitudTeletrabajo DESC";
                            
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            if (reader.GetBoolean(17) && (int)Session["FamiliaPuesto"] == 1)
                            {
                                aprobado = true;
                            }
                            if (reader.GetBoolean(18) && (int)Session["FamiliaPuesto"] == 2)
                            {
                                aprobado = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"4-Error al conectar a la base de datos: {ex.Message}");
            }

            
            return aprobado;

        }

        CDistritoDTO getDistrito(int idDistrito)
        {
            CDistritoDTO Distrito = new CDistritoDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Distrito WHERE PK_Distrito=" + idDistrito; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Distrito.IdEntidad = reader.GetInt32(0);
                            Distrito.NomDistrito = reader.GetString(2);
                            Distrito.CodPostalDistrito = reader.GetString(3);
                            Distrito.Canton = getCanton(reader.GetInt32(1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"8-Error al conectar a la base de datos: {ex.Message}");
            }
            return Distrito;
        }

        CProvinciaDTO getProvincia(int idProvincia)
        {
            CProvinciaDTO provincia = new CProvinciaDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Provincia WHERE PK_Provincia=" + idProvincia; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            provincia.NomProvincia = reader.GetString(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"6-Error al conectar a la base de datos: {ex.Message}");
            }
            return provincia;
        }

        CCantonDTO getCanton(int idCanton)
        {
            CCantonDTO canton = new CCantonDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Canton WHERE PK_Canton=" + idCanton; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            canton.NomCanton = reader.GetString(2);
                            canton.CodPostalCanton = reader.GetString(3);
                            canton.Provincia = getProvincia(reader.GetInt32(1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"7-Error al conectar a la base de datos: {ex.Message}");
            }
            return canton;
        }

        CDireccionDTO getDireccion(int id)
        {
            CDireccionDTO direccion = new CDireccionDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Direccion WHERE FK_Funcionario=" + id; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            direccion.IdEntidad = reader.GetInt32(0);
                            direccion.Distrito = getDistrito(reader.GetInt32(1));
                            direccion.DirExacta = reader.GetString(3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"8-Error al conectar a la base de datos: {ex.Message}");
            }
            return direccion;
        }

        [HttpPost]
        public ActionResult DescargarActividades(int id)
        {
            try {
                List<CActividadSolicitudTeletrabajoDTO> activList = actividades(id);
                

                return Json(new
                {
                    success = true,
                    listado = activList
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { success = false, mensaje = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        List<CActividadSolicitudTeletrabajoDTO> actividades(int ind)
        {
            List<CActividadSolicitudTeletrabajoDTO> actividad = new List<CActividadSolicitudTeletrabajoDTO>();
            CActividadSolicitudTeletrabajoDTO actv;
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";


            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = @"SELECT *
                    FROM ActividadSolicitudTeletrabajo
                    WHERE FK_SolicitudTeletrabajo = @ind"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    command.Parameters.AddWithValue("@ind", ind);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            actv = new CActividadSolicitudTeletrabajoDTO();
                            actv.DescripcionActividad = reader.GetString(1);
                            actv.Medios = reader.GetBoolean(2);
                            actv.Medible = reader.GetBoolean(3);
                            actv.Supervision = reader.GetBoolean(4);
                            actividad.Add(actv);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"14-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            Session["Actividades"] = actividad;
            return actividad;
        }

        public void GenerarNotificacion(string mensaje, int idFuncionario)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
           {
               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                   string query = @"INSERT INTO NotificacionTeletrabajo (notificacion, leido, fk_funcionario, Fecha)
                                             VALUES (@notificacion, @leido, @fk_funcionario, @fecha)";

                    SqlCommand command = new SqlCommand(query, connection);
                   command.Parameters.AddWithValue("@notificacion", mensaje);
                    command.Parameters.AddWithValue("@leido", false); //se debe iniciar en falso para que la notificación no se marque como leída
                    command.Parameters.AddWithValue("@fk_funcionario", idFuncionario);
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);

                    connection.Open();
                   command.ExecuteNonQuery();
               }
           }
           catch (Exception ex)
           {

                System.Diagnostics.Debug.WriteLine("Error al generar notificación: " + ex.Message);
           }
        }

        public void RegistroMovimiento(string comantario, int idFuncionario, string estado, int solicitud)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO TransaccionesTeletrabajo (FK_Solicitud, FK_Funcionario, Comentario, Estado, Fecha)
                                             VALUES (@solicitud, @funcionario, @comentario, @estado, @fecha)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@comentario", comantario);
                    command.Parameters.AddWithValue("@solicitud", solicitud); //se debe iniciar en falso para que la notificación no se marque como leída
                    command.Parameters.AddWithValue("@funcionario", idFuncionario);
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine("Error al generar registro: " + ex.Message);
            }
        }

         void enviarCorreo(string mensaje, string destino)
        {
            try
            {
                var fromAddress = new MailAddress("dayverfx@gmail.com");
                var toAddress = new MailAddress(destino);
                const string fromPassword = "sfnz tepf lhxr hdeu";
                const string subject = "Notificacion";
                

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // Cambia esto según tu proveedor
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = mensaje
                })
                {
                    smtp.Send(message);
                    Console.WriteLine("Correo enviado correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
            }
        }

    }
}








