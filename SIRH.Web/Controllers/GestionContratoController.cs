using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIRH.Web.FuncionarioLocal;
using SIRH.Web.ViewModels;
using SIRH.Web.Models;
using SIRH.DTO;


namespace SIRH.Web.Controllers
{
    public class GestionContratoController : Controller
    {
        CFuncionarioServiceClient funcionarioReference = new CFuncionarioServiceClient();
        // GET: GestionContrato


        public ActionResult Index()
        {
            try
            {
                PerfilFuncionarioVM model = new PerfilFuncionarioVM();
                var solicitudes = funcionarioReference.ListarSolicitudes(Session["CedulaUsuario"].ToString());
                model.solicitudes = solicitudes.ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}