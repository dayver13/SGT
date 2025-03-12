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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TiempoFuera()
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
        public ActionResult NuevoRegistro(PerfilFuncionarioVM model, string StartDate, string EndDate, int salida, string SubmitButton)
        {
            Session["errorF"] = null;
            try
            {
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";

                // Validando si existe un conflicto para el nuevo registro en la fechas dada

                string checkQuery = @"
                            SELECT * FROM TiempoFuera
                            WHERE FK_Funcionario = @Funcionario
                            AND ((@Inicio BETWEEN Inicio AND Final)
                            OR (@Final BETWEEN Inicio AND Final)
                            OR (Inicio BETWEEN @Inicio AND @Final) 
                            OR (Final BETWEEN @Inicio AND @Final))";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Funcionario",Int32.Parse(model.personalseleccionado));
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
                        command.Parameters.AddWithValue("@Funcionario",Int32.Parse(model.personalseleccionado));
                        command.Parameters.AddWithValue("@Tipo", salida);
                        command.Parameters.AddWithValue("@Inicio", StartDate);
                        command.Parameters.AddWithValue("@Final", EndDate);
                        connection.Open();
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

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consult
                    string querynom = "SELECT * FROM SolicitudTeletrabajo WHERE IndAprobadoSuperior = 0"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aux = getfuncionario(reader.GetInt32(16));
                            if (!lista.Any(p => p.Value == aux.Cedula))
                            {
                                lista.Add(new SelectListItem { Text = aux.Nombre + " " + aux.PrimerApellido + " " + aux.SegundoApellido, Value = aux.IdEntidad.ToString() });
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

        [HttpPost]
        public ActionResult RegistroDesempeno(PerfilFuncionarioVM model, int mes, int metricas, int horario, int tardias, int abandonos, string SubmitButton)
        {
            Session["errorF"] = null;
            try
            {
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";

                // Validando si ya existe un registro para el periodo

                string checkQuery = @"
                            SELECT * FROM RegistroRendimiento
                            WHERE FK_Funcionario = @Funcionario
                            AND Periodo = @Periodo
                            AND Ano = 2025";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Funcionario",Int32.Parse(model.personalseleccionado));
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
                        command.Parameters.AddWithValue("@Funcionario",Int32.Parse(model.personalseleccionado));
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



        private CFuncionarioDTO getfuncionario(int v)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CFuncionarioDTO func = new CFuncionarioDTO();

            // Crear una conexión
            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string query = "SELECT * FROM Funcionario WHERE PK_Funcionario = " + v; // Cambia 'tu_tabla' por el nombre de tu tabla
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
                            System.Diagnostics.Debug.WriteLine(func.Cedula + func.FechaNacimiento.ToString());
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

    }
}