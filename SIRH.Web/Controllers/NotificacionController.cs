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
                            Id = Convert.ToInt32(reader["id"]),
                            Asunto = "Notificación",
                            Contenido = reader["notificacion"].ToString(),
                            FechaEnvio = DateTime.Now, // No fecha exacta en tabla
                            CedulaReferencia = reader["fk_funcionario"].ToString(),
                            Destinatario = reader["fk_funcionario"].ToString(),
                            Usuario = new CUsuarioDTO { NombreUsuario = "Sistema" }, // Placeholder
                            Leido = Convert.ToBoolean(reader["leido"])
                        };
                        notificaciones.Add(notificacion);
                    }
                }

                ViewBag.UnreadCount = notificaciones.Count(n => !n.Leido);
                ViewBag.Success = TempData["Success"];
                ViewBag.Error = TempData["Error"];
                return View("ListaNotificaciones", notificaciones);
            }
            catch (Exception error)
            {
                ViewBag.Error = error.Message;
                ViewBag.UnreadCount = 0;
                return View("ListaNotificaciones", notificaciones);
            }
        }

        [HttpPost]
        public ActionResult AccionesNotificaciones(List<int> selectedIds, string actionType)
        {
            try
            {
                if (selectedIds == null || !selectedIds.Any())
                {
                    TempData["Error"] = "Debe seleccionar al menos una notificación.";
                    return RedirectToAction("ListaNotificaciones");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (int id in selectedIds)
                    {
                        string query = actionType == "delete"
                            ? "DELETE FROM NotificacionTeletrabajo WHERE id = @id"
                            : "UPDATE NotificacionTeletrabajo SET leido = 1 WHERE id = @id";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                TempData["Success"] = actionType == "delete" ? "Notificaciones eliminadas correctamente." : "Notificaciones marcadas como leídas.";
                return RedirectToAction("ListaNotificaciones");
            }
            catch (Exception error)
            {
                TempData["Error"] = error.Message;
                return RedirectToAction("ListaNotificaciones");
            }
        }
    }
}
