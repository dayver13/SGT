using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIRH.Web.Controllers
{
    public class NotificacionController : Controller
    {
        // GET: Notificacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaNotificaciones()
        {
            //var modelo = new CNotificacionUsuarioDTO();
            return View();//modelo); NotificacionUsuarioDTO (instancia new)
        }
    }
}