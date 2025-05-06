using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using SIRH.DTO;

namespace SIRH.Web.Controllers
{
    public class NotificacionController : Controller
    {
        string connectionString = "Server=tcp:35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;";

        // GET: Notificacion
        public ActionResult Index()
        {
            return RedirectToAction("ListaNotificaciones");
        }

        public ActionResult ListaNotificaciones()
        {
            List<CNotificacionUsuarioDTO> notificaciones = new List<CNotificacionUsuarioDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT id, notificacion, leido, fk_funcionario
                                     FROM NotificacionTeletrabajo
                                     ORDER BY id DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var notificacion = new CNotificacionUsuarioDTO
                        {
                            Asunto = "Notificación",
                            Contenido = reader["notificacion"].ToString(),
                            FechaEnvio = DateTime.Now, // No fecha exacta en tabla
                            CedulaReferencia = reader["fk_funcionario"].ToString(),
                            Destinatario = reader["fk_funcionario"].ToString(),
                            Usuario = new CUsuarioDTO { NombreUsuario = "Sistema" } // Placeholder
                        };
                        notificaciones.Add(notificacion);
                    }
                }

                return View("ListaNotificaciones", notificaciones);
            }
            catch (Exception error)
            {
                ViewBag.Error = error.Message;
                return View("ListaNotificaciones", notificaciones);
            }
        }
    }
}
