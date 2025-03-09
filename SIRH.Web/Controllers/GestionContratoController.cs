using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIRH.Web.FuncionarioLocal;
using SIRH.Web.ViewModels;
using SIRH.Web.Models;
using SIRH.DTO;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Drawing.Printing;


namespace SIRH.Web.Controllers
{
    public class GestionContratoController : Controller
    {
        CFuncionarioServiceClient funcionarioReference = new CFuncionarioServiceClient();
        // GET: GestionContrato


        public ActionResult Index()
        {
            
                return View();
            
        }

        [HttpGet]
        public ActionResult DescargarSolicitudes()
        {
            // Simulando una lista de actividades


            // Convertir la lista a CSV
            var csv = new StringBuilder();
            csv.AppendLine("Numero");
            csv.AppendLine("Estado");// Encabezados

            List<SolicitudTeletrabajoDTO> solicitudes = dessolicitudes(Session["CedulaUsuario"].ToString());

            for (var i = 0; i < solicitudes.Count; i++)
            {

                csv.AppendLine($"{solicitudes[i].IdEntidad}");
                if (!solicitudes[i].AprobadoJefaturaInmediata && !solicitudes[i].AprobadoJefaturaSuperior)
                {
                    csv.AppendLine($"{"V"}");
                }
                if (solicitudes[i].AprobadoJefaturaInmediata && !solicitudes[i].AprobadoJefaturaSuperior)
                {
                    csv.AppendLine($"{"F1"}");
                }
                if (solicitudes[i].AprobadoJefaturaInmediata && solicitudes[i].AprobadoJefaturaSuperior)
                {
                    csv.AppendLine($"{"F2"}");
                }
            }


            // Devolver el CSV como archivo descargable
            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "solicitudes.csv");
        }

        List<SolicitudTeletrabajoDTO> dessolicitudes(string cedula)
        {
            List<SolicitudTeletrabajoDTO> solicitudes = new List<SolicitudTeletrabajoDTO>();
            SolicitudTeletrabajoDTO solicitud;
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
                    FROM SolicitudTeletrabajo
                    WHERE FK_Funcionario IN(SELECT PK_Funcionario FROM Funcionario WHERE IdCedulaFuncionario = @cedula)
                    ORDER BY PK_SolicitudTeletrabajo DESC"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    command.Parameters.AddWithValue("@cedula", cedula);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {   
                            solicitud = new SolicitudTeletrabajoDTO();
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
                            solicitud.AprobadoJefaturaSuperior = reader.GetBoolean(18);
                            solicitud.TiempoLaborarDependencia = reader.GetString(19);
                            solicitudes.Add(solicitud);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                }
            }
            Session["Solicitudes"] = solicitudes;
            return solicitudes;
        }
    }
}