using SIRH.DTO;

using SIRH.Web.Helpers;


using SIRH.Web.Reports.PDF;
using SIRH.Web.Reports.Vacaciones;
using SIRH.Web.UserValidation;
//using SIRH.Web.FuncionarioService;
using SIRH.Web.NombramientoService;
//using SIRH.Web.VacacionesService;
using SIRH.Web.CalificacionService;
using SIRH.Web.PerfilUsuarioService;

using SIRH.Web.FuncionarioLocal;
//using SIRH.Web.NombramientoLocal;
//using SIRH.Web.PerfilUsuarioLocal;
//using SIRH.Web.CalificacionLocal;
using SIRH.Web.VacacionesLocal;

//using SIRH.Web.VacacionesPrueba;

using SIRH.Web.Models;
using SIRH.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;


namespace SIRH.Web.Controllers
{
    public class VacacionesController : Controller
    {
        CAccesoWeb context = new CAccesoWeb();
        CVacacionesServiceClient ServicioVacaciones = new CVacacionesServiceClient();
        CFuncionarioServiceClient ServicioFuncionario = new CFuncionarioServiceClient();
        CPerfilUsuarioServiceClient perfilUsuario = new CPerfilUsuarioServiceClient();
        CCalificacionServiceClient servicioCalificacion = new CCalificacionServiceClient();
       
        private static double uploadProgresses = 0;



        WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        // GET: Vacaciones

        public ActionResult Inicio()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), Convert.ToInt32(EAccionesBitacora.Login), 0,
                        CAccesoWeb.ListarEntidades(typeof(CPerfilDTO).Name));
                    if (Convert.ToBoolean(Session["Administrador_Global"]) == true || Session["Permiso_17_88"] != null || Session["Permiso_17_89"] != null)
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("InicioFuncionario");
                    }
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }

        public ActionResult InicioFuncionario()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), Convert.ToInt32(EAccionesBitacora.Login), 0,
                        CAccesoWeb.ListarEntidades(typeof(CPerfilDTO).Name));
                    return View();
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }

        public ActionResult Index()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), Convert.ToInt32(EAccionesBitacora.Login), 0,
                        CAccesoWeb.ListarEntidades(typeof(CPerfilDTO).Name));
                    return View();
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }
        public ActionResult ReintegroVacaciones()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    return View();
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult ReintegroVacaciones(ReintegroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.PeriodoVacaciones.Nombramiento.Funcionario.Cedula);

                        var datosRegistro = ServicioVacaciones.ObtenerRegistro(model.PeriodoVacaciones.Nombramiento.Funcionario.Cedula, model.RegistroVacaciones.NumeroTransaccion);



                        if (datosRegistro[0].GetType() != typeof(CErrorDTO) && datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            model.PeriodoVacaciones = (CPeriodoVacacionesDTO)datosRegistro[1];
                            model.RegistroVacaciones = (CRegistroVacacionesDTO)datosRegistro[0];
                            model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                            model.Puesto = (CPuestoDTO)datosFuncionario[1];
                            model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                            return PartialView("_FormularioReintegro", model);
                        }
                        else
                        {
                            if (datosRegistro[0].GetType() == typeof(CErrorDTO) && datosFuncionario[0].GetType() != typeof(CErrorDTO))
                            {
                                ModelState.AddModelError("BusquedaPeriodo",
                                   ((CErrorDTO)datosRegistro[0]).MensajeError);
                                throw new Exception("BusquedaPeriodo");
                            }
                            else
                                if (datosRegistro[0].GetType() != typeof(CErrorDTO) && datosFuncionario[0].GetType() == typeof(CErrorDTO))
                            {
                                ModelState.AddModelError("BusquedaPeriodo",
                                  ((CErrorDTO)datosFuncionario[0]).MensajeError);
                                throw new Exception("BusquedaFuncionario");
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaPeriodo",
                                   ((CErrorDTO)datosRegistro[0]).MensajeError);
                                ModelState.AddModelError("BusquedaPeriodo",
                                  ((CErrorDTO)datosFuncionario[0]).MensajeError);
                                throw new Exception("BusquedaFuncionario");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("BusquedaPeriodo");
                    }

                }
                else
                {
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                    if (ModelState.IsValid)
                    {
                        model.ReintegroVacaciones.Mensaje = model.PeriodoVacaciones.Periodo;
                        var reintegra = ServicioVacaciones.RegistraReintegroVacaciones(model.RegistroVacaciones.NumeroTransaccion, model.ReintegroVacaciones, model.Funcionario.Cedula);
                        if (((CRespuestaDTO)reintegra).Codigo > 0)
                        {
                            return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                                                                              model.Funcionario.Cedula + "&CodPeriodo=" +
                                                                               model.PeriodoVacaciones.Periodo + "&Codigo=" + ((CRespuestaDTO)reintegra).Codigo + "&detalle=3'");
                        }
                        else
                        {
                            ModelState.AddModelError("Error",
                              ((CRespuestaDTO)reintegra).Mensaje);
                            throw new Exception("Guardar");
                        }

                    }
                    else
                    {
                        return PartialView("_ErrorVacaciones");
                    }
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult RegistrarVacaciones()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    return View();
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult RegistrarVacaciones(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.PeriodoVacaciones.Nombramiento.Funcionario.Cedula);

                        //var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.PeriodoVacaciones.Nombramiento.Funcionario.Cedula).OrderBy(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();
                        var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.PeriodoVacaciones.Nombramiento.Funcionario.Cedula);

                        /*//////////////////////// NUEVO //////////////////////////////////////////////*/

                        var datosJefatura = ServicioVacaciones.ListarJefatura(model.PeriodoVacaciones.Nombramiento.Funcionario.Cedula);
                        if (datosJefatura.GetType() != typeof(CErrorDTO))
                            model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }

                        var periodosActuales = new List<string>();

                        List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();
                        CPeriodoVacacionesDTO periodoCero = new CPeriodoVacacionesDTO { IdEntidad = -1 };
                        CPeriodoVacacionesDTO periodoNegativo = new CPeriodoVacacionesDTO { IdEntidad = -1 };

                        if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                            {
                                if (item.Saldo > 0)
                                    datosDescarga.Add(item);
                                else if (item.Saldo == 0)
                                    periodoCero = item;
                                else
                                    periodoNegativo = item;
                            }
                        }
                        if (datosDescarga.Count < 1)
                        {
                            // datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
                            if (periodoNegativo.IdEntidad > -1)
                                datosDescarga.Add(periodoNegativo);
                            else if (periodoCero.IdEntidad > -1)
                                datosDescarga.Add(periodoCero);
                            else
                                datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = 0, Periodo = "20232024XXX" });
                        }
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            ViewBag.DiasTotales = 0;
                            if (datosDescarga[0].IdEntidad > -1)
                            {
                                model.PeriodoVacaciones = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault());
                                model.UltimoPeriodo = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault()).Periodo;
                                model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                //var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                                //if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                                //{
                                //    foreach (var item in periodosActivos)
                                //    {
                                //        periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                                //    }
                                //}
                                //if (periodosActivos[0].GetType() != typeof(CErrorDTO))
                                //{
                                //    //model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).Where(F => F.Saldo > 0).ToList();
                                //    model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).Where(F => F.Saldo != 0).ToList();
                                //    ViewBag.DiasTotales = model.PeriodosActivos.Sum(Q=>Q.Saldo);
                                //}
                                model.PeriodosActivos = datosDescarga;
                                ViewBag.DiasTotales = model.PeriodosActivos.Sum(Q => Q.Saldo);
                                model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];

                                List<string> estadosTipoVacaciones = new List<string>();
                                estadosTipoVacaciones.Add("Vacaciones");
                                estadosTipoVacaciones.Add("Permiso con goce de salario");
                                model.tipoDocumento = new SelectList(estadosTipoVacaciones);
                                return PartialView("_FormularioVacaciones", model);
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                                throw new Exception("Error al cargar el modelo");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }
                else if (SubmitButton == "Guardar")
                {
                    String tipoUsuario;
                    PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                    if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Administrador))] != null)
                    {
                        tipoUsuario = "RH";
                    }
                    else
                    {
                        tipoUsuario = "Funcionario";
                    }
                    tipoUsuario = "RH";
                    var solicitadoPor = int.Parse(modelUsuario.Funcionario.Cedula);
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                    if (ModelState.IsValid && model.PeriodosActivos != null && model.tipoDocumentoSeleccion != null)
                    {
                        var vacaciones = 0;
                        if (model.tipoDocumentoSeleccion == "Vacaciones")
                        {
                            vacaciones = 1;
                        }
                        else if (model.tipoDocumentoSeleccion == "Permiso sin goce de salario")
                        {
                            vacaciones = 6;
                        }
                        var medioDia = 0;
                        if (model.MedioDia == "Mañana")
                        {
                            medioDia = 1;
                        }
                        else if (model.MedioDia == "Tarde")
                        {
                            medioDia = 2;

                        }
                        model.RegistroVacaciones.SolicitadoPor = solicitadoPor;

                        model.RegistroVacaciones.Bitacora = new CBitacoraDTO { Usuario = Session["CedulaUsuario"].ToString() };

                        var guardarDatos = ServicioVacaciones.GuardarRegistroVacacionesNuevo(model.RegistroVacaciones, model.Funcionario.Cedula, model.PeriodosActivos.First().Periodo, vacaciones, medioDia, tipoUsuario);

                        if (((CRespuestaDTO)guardarDatos).Codigo > 0)
                        {
                            return Content("<div class='alert alert-success'>Cambios guardados correctamente</div>");

                            //return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                            //                                                  model.Funcionario.Cedula + "&CodPeriodo=" +
                            //                                                   model.PeriodosActivos.First().Periodo + "&Codigo=" + ((CRespuestaDTO)guardarDatos).Codigo + "&detalle=4'");
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo", ((CRespuestaDTO)guardarDatos).Mensaje);
                            throw new Exception("Guardar");
                        }
                    }
                    else
                    {
                        if (model.PeriodosActivos == null)
                        {
                            ModelState.AddModelError("Busqueda", "El periodo de vacaciones es obligatorio.");
                            throw new Exception("Error al cargar el modelo");
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", "El tipo de transacción es obligatorio.");
                            throw new Exception("Error al cargar el modelo");
                        }
                    }
                }
                else
                {
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }

            /*//////////////////////// FIN *////////////////////////////////////////////////

            /*List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();

            if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
            {
                foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                {
                    if (item.Saldo > 0)
                    {
                        datosDescarga.Add(item);
                    }
                }

            }

            if (datosDescarga.Count < 1)
            {
                datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
            }

            if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
            {
                if (datosDescarga[0].IdEntidad > -1)
                {
                    //model.PeriodosActivos = new SelectList(datosPeriodo.Select(U => ((CPeriodoVacacionesDTO)U).Periodo));
                    model.PeriodoVacaciones = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault());
                    model.UltimoPeriodo = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault()).Periodo;
                    model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                    model.Puesto = (CPuestoDTO)datosFuncionario[1];
                    model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                    List<string> estadosTipoVacaciones = new List<string>();
                    estadosTipoVacaciones.Add("Vacaciones");
                    estadosTipoVacaciones.Add("Permiso con goce de salario");
                    estadosTipoVacaciones.Add("Proporcionales");
                    model.tipoDocumento = new SelectList(estadosTipoVacaciones);
                    return PartialView("_FormularioVacaciones", model);
                }
                else
                {
                    ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                    throw new Exception("Error al cargar el modelo");
                }
            }
            else
            {
                ModelState.AddModelError("BusquedaPeriodo",
                  ((CErrorDTO)datosFuncionario[0]).MensajeError);
                throw new Exception("BusquedaFuncionario");
            }
        }
        else
        {
            throw new Exception("Busqueda");
        }

    }
    else
    {
        var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
        if (ModelState.IsValid && model.UltimoPeriodo != null && model.tipoDocumentoSeleccion != null)
        {
            var vacaciones = 0;
            if (model.tipoDocumentoSeleccion == "Vacaciones")
            {
                vacaciones = 1;
            }
            else
                if (model.tipoDocumentoSeleccion == "Permiso sin goce de salario")
            {
                vacaciones = 6;
            }
            else
            {
                vacaciones = 5;
            }
            var guardarDatos = ServicioVacaciones.GuardarRegistroVacaciones(model.RegistroVacaciones, model.Funcionario.Cedula, model.UltimoPeriodo, vacaciones
                );
            if (((CRespuestaDTO)guardarDatos).Codigo > 0)
            {
                return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                                                                  model.Funcionario.Cedula + "&CodPeriodo=" +
                                                                   model.UltimoPeriodo + "&Codigo=" + ((CRespuestaDTO)guardarDatos).Codigo + "&detalle=4'");
            }
            else
            {
                ModelState.AddModelError("BusquedaPeriodo",
                  ((CRespuestaDTO)guardarDatos).Mensaje);
                throw new Exception("Guardar");
            }
        }
        else
        {
            if (model.UltimoPeriodo != null)
            {
                ModelState.AddModelError("Busqueda", "El periodo de vacaciones es obligatorio.");
                throw new Exception("Error al cargar el modelo");
            }
            else
            {
                ModelState.AddModelError("Busqueda", "El tipo de transacción es obligatorio.");
                throw new Exception("Error al cargar el modelo");
            }
        }
    }

}
catch (Exception e)
{
    return PartialView("_ErrorVacaciones");
}*/
        }

        public ActionResult VacacionesPersonal()
        {

            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                        Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                        Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                    {
                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();
                        model.Funcionario = modelUsuario.Funcionario;
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula).OrderBy(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();
                        double diasTotales = 0;

                        var periodosActuales = new List<string>();
                        var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                        if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                        {
                            foreach (var item in periodosActivos)
                            {
                                periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                            }
                        }
                        if (periodosActivos[0].GetType() != typeof(CErrorDTO))
                        {
                            model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).Where(F => F.Saldo > 0).ToList();
                            diasTotales += periodosActivos.Sum(P => ((CPeriodoVacacionesDTO)P).Saldo);
                            ViewBag.DiasTotales = diasTotales;
                        }

                        List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();

                        if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                            {
                                if (item.Saldo > 0)
                                {
                                    datosDescarga.Add(item);
                                }
                            }

                        }

                        if (datosDescarga.Count < 1)
                        {
                            datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
                        }

                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            if (datosDescarga[0].IdEntidad > -1)
                            {
                                var datosJefatura = ServicioVacaciones.ListarJefatura(model.Funcionario.Cedula);

                                if (datosJefatura.GetType() != typeof(CErrorDTO))
                                    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                                else
                                {
                                    ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                                    throw new Exception("BusquedaFuncionario");
                                }

                                //model.PeriodosActivos = new SelectList(datosPeriodo.Select(U => ((CPeriodoVacacionesDTO)U).Periodo));
                                model.PeriodoVacaciones = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault());
                                model.UltimoPeriodo = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault()).Periodo;
                                model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                                List<string> estadosTipoVacaciones = new List<string>();
                                estadosTipoVacaciones.Add("Vacaciones");
                                estadosTipoVacaciones.Add("Permiso con goce de salario");
                                model.tipoDocumento = new SelectList(estadosTipoVacaciones);
                                return PartialView("VacacionesPersonal", model);
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                                throw new Exception("Error al cargar el modelo");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }

                        //return View();

                    }
                    else
                    {
                        CAccesoWeb.CargarErrorAcceso(Session);
                        return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                    }
                }

            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });

            }
        }

        [HttpPost]
        public ActionResult VacacionesPersonal(FormularioRegistroVacacionesVM model)
        {
            try
            {
                var tipoUsuario = "Funcionario";
                var solicitadoPor = Convert.ToInt32(Session["CedulaUsuario"]);
                var mensaje = "";

                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                if (ModelState.IsValid && model.PeriodosActivos != null && model.tipoDocumentoSeleccion != null)
                {
                    var vacaciones = 0;

                    if (model.tipoDocumentoSeleccion == "Vacaciones")
                    {
                        vacaciones = 1;
                    }
                    else
                        if (model.tipoDocumentoSeleccion == "Permiso sin goce de salario")
                    {
                        vacaciones = 6;
                    }

                    var medioDia = 0;

                    if (model.MedioDia == "Mañana")
                    {
                        medioDia = 1;
                    }
                    else
                    {
                        if (model.MedioDia == "Tarde")
                        {
                            medioDia = 2;
                        }
                    }

                    model.RegistroVacaciones.SolicitadoPor = solicitadoPor;
                    model.RegistroVacaciones.Bitacora = new CBitacoraDTO { Usuario = Session["CedulaUsuario"].ToString() };

                    var guardarDatos = ServicioVacaciones.GuardarRegistroVacacionesNuevo(model.RegistroVacaciones, model.Funcionario.Cedula, model.PeriodosActivos.First().Periodo, vacaciones, medioDia, tipoUsuario);
                    mensaje = "guardarDatos";
                    if (((CRespuestaDTO)guardarDatos).Codigo > 0)
                    {
                        mensaje = "Guardó";
                        model.Funcionario.Sexo = GeneroEnum.Indefinido;
                        mensaje = "Genero";
                        var encargado = servicioCalificacion.BuscarEncargado(model.Funcionario, model.Puesto.UbicacionAdministrativa);
                        mensaje = "Encargado";
                        if (encargado.ElementAt(0).GetType() != typeof(CErrorDTO))
                        {
                            /*EmailWebHelper correo = new EmailWebHelper();
                            correo.Destinos = encargado.ElementAt(0).Mensaje;
                            correo.Asunto = "Registro de vacaciones " + model.RegistroVacaciones.NumeroTransaccion;
                            var funcionarioNombre = model.Funcionario.Nombre + " " + model.Funcionario.PrimerApellido + " " + model.Funcionario.SegundoApellido;
                            correo.EmailBody = CorreoVacaciones(funcionarioNombre);
                            correo.EnviarCorreo();*/
                        }
                        mensaje = "Tab2";
                        Session["VacacionesActivo"] = "tab2";

                        //return Content(mensaje);
                        return JavaScript("window.location = '/Vacaciones/MisSolicitudes'");
                        /*return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                                                                                           model.Funcionario.Cedula + "&CodPeriodo=" +
                                                                                           model.PeriodosActivos.First().Periodo + "&Codigo=" + ((CRespuestaDTO)guardarDatos).Codigo + "&detalle=4'");*/
                    }
                    else
                    {
                        ModelState.AddModelError("BusquedaPeriodo", ((CRespuestaDTO)guardarDatos).Mensaje);
                        throw new Exception("Guardar");
                    }

                }
                else
                {
                    if (model.PeriodosActivos == null)
                    {
                        ModelState.AddModelError("Busqueda", "El periodo de vacaciones es obligatorio.");
                        throw new Exception("Error al cargar el modelo");
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", "El tipo de transacción es obligatorio.");
                        throw new Exception("Error al cargar el modelo");
                    }
                }
            }
            catch (Exception e)
            {
                //return Content(e.Message);
                return PartialView("_ErrorVacaciones");
            }
        }

        private string CorreoVacaciones(string funcionario)
        {
            string respuesta = "";

            respuesta += "<h1>Solicitud de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha generado una nueva solicitud de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Administración de Solicitudes</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoAprobacionVacaciones(string funcionario)
        {
            string respuesta = "";

            respuesta += "<h1>Solicitud de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha aprobado su solicitud de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Mis Solicitudes</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoAprobacionReintegros(string funcionario)
        {
            string respuesta = "";

            respuesta += "<h1>Reintegro de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha aprobado su solicitud de reintegro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Mis Reintegros</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoReintegro(string funcionario)
        {
            string respuesta = "";

            respuesta += "<h1>Solicitud de reintegro de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha generado una nueva solicitud de reintegro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Administración de Reintegros</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoRechazo(string funcionario, string motivo)
        {
            string respuesta = "";

            respuesta += "<h1>Rechazo de solicitud de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha rechazado una solicitud a su nombre de registro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Las observaciones del rechazo son las siguientes: " + motivo + ".</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Mis Solicitudes</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoRechazoReintegro(string funcionario, string motivo)
        {
            string respuesta = "";

            respuesta += "<h1>Rechazo de solicitud de reintegro de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha rechazado una solicitud a su nombre de reintegro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Las observaciones del rechazo son las siguientes: " + motivo + ".</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Mis Reintegros</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoDiscusion(string funcionario, string motivo)
        {
            string respuesta = "";

            respuesta += "<h1>Discusion sobre solicitud de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha hecho observaciones a una solicitud a su nombre de registro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Las observaciones son las siguientes: " + motivo + ".</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Mis Solicitudes (La misma se encuentra como pendiente de aprobación)</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoRespuestaDiscusion(string funcionario, string motivo)
        {
            string respuesta = "";

            respuesta += "<h1>Discusion sobre solicitud de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha hecho observaciones a una solicitud de registro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Las observaciones son las siguientes: " + motivo + ".</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Administración de Solicitudes</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoDiscusionReintegro(string funcionario, string motivo)
        {
            string respuesta = "";

            respuesta += "<h1>Discusion sobre solicitud de reintegro de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha hecho observaciones a una solicitud a su nombre de reintegro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Las observaciones son las siguientes: " + motivo + ".</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Mis Reintegros (La misma se encuentra como pendiente de aprobación)</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }

        private string CorreoRespuestaDiscusionReintegro(string funcionario, string motivo)
        {
            string respuesta = "";

            respuesta += "<h1>Discusion sobre solicitud de reintegro de vacaciones - SIRH</h1>";
            respuesta += "<p>El funcionario <strong>" + funcionario + "</strong>, ha hecho observaciones a una solicitud de reintegro de vacaciones en el Sistema Integrado de Recursos Humanos.</p>";
            respuesta += "<p>Las observaciones son las siguientes: " + motivo + ".</p>";
            respuesta += "<p>Puede revisar esta solicitud en el módulo de Vacaciones, en la opción de <strong>Administración de Reintegros (La misma se encuentra como pendiente de aprobación)</strong>.</p>";
            respuesta += "<p>Favor no responder a este correo, ya que se generó automáticamente.</p>";
            respuesta += "<p>Saludos cordiales.</p>";

            return respuesta;
        }


        public ActionResult Search()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Consulta))] != null ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    return View();
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult Search(DetalleVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var detallePeriodos = ServicioVacaciones.ObtenerDetalleVacaciones(model.Funcionario.Cedula);
                        var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                        var periodosInactivos = ServicioVacaciones.ListarPeriodosNoActivos(model.Funcionario.Cedula);
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuestoVacaciones(model.Funcionario.Cedula);

                        var periodosActuales = new List<string>();


                        if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                        {
                            foreach (var item in periodosActivos)
                            {
                                periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                            }
                        }

                        if (periodosInactivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                        {
                            foreach (var item in periodosInactivos)
                            {
                                periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                            }
                        }

                        var periodosEmulacion = ServicioVacaciones.BuscarHistorialPeriodoVacacionesSinActuales(model.Funcionario.Cedula, periodosActuales.ToArray());

                        if ((detallePeriodos[0][0].GetType() != typeof(CErrorDTO) 
                            || detallePeriodos[1][0].GetType() != typeof(CErrorDTO))
                            && datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            model.DetalleContratacion = (CDetalleContratacionDTO)ServicioVacaciones.DetalleContratacion(model.Funcionario.Cedula);
                            model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                            model.Puesto = (CPuestoDTO)datosFuncionario[1];
                            model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];

                            var datosJefatura = ServicioVacaciones.ListarJefatura(model.Funcionario.Cedula);

                            if (datosJefatura.GetType() != typeof(CErrorDTO))
                                model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                            else
                            {
                                ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                                throw new Exception("BusquedaFuncionario");
                            }

                            //model.PeriodosActivos = detallePeriodos.ElementAt(0).Select(F => (CPeriodoVacacionesDTO)F).ToList();
                            if (periodosActivos[0].GetType() != typeof(CErrorDTO))
                            {
                                double diasTotales = 0;
                                model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).ToList();
                                foreach (var item in model.PeriodosActivos)
                                {
                                    var fechaCumplimiento = new DateTime(DateTime.Now.Year,
                                                                         model.DetalleContratacion.FechaIngreso.Month,
                                                                         model.DetalleContratacion.FechaIngreso.Day);
                                    if (item.DiasDerecho == 26)
                                    {
                                        item.ProporcionMes = Math.Round(Convert.ToDouble(item.DiasDerecho / 12), 2) - 0.01;
                                    }
                                    else
                                    {
                                        item.ProporcionMes = Math.Round(Convert.ToDouble(item.DiasDerecho / 12), 2);
                                    }
                                    item.Proporcion = Math.Round((DateTime.Now.Subtract(fechaCumplimiento).Days / 30) * item.ProporcionMes, 2);
                                    diasTotales += item.Saldo;
                                }
                                ViewBag.DiasTotales = diasTotales;
                            }
                            if (periodosInactivos[0].GetType() != typeof(CErrorDTO))
                            {
                                model.PeriodosNoActivos = periodosInactivos.Select(F => (CPeriodoVacacionesDTO)F).ToList();
                            }
                            if (periodosEmulacion[0].GetType() != typeof(CErrorDTO))
                            {
                                model.PeriodosEmulacion = periodosEmulacion.Select(F => (CPeriodoVacacionesDTO)F).ToList();
                            }

                            return PartialView("_SearchDetails", model);
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda",
                                  ((CErrorDTO)detallePeriodos[0][0]).MensajeError
                              );
                            throw new Exception("Busqueda");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }
                else
                {
                    throw new Exception("Busqueda");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }

        }

        [HttpPost]
        public ActionResult ReintegrarRegistro(FormCollection form)
        {
            try
            {
                var fechainicioOriginal = Convert.ToDateTime(form["fechaInicioOriginal"]);
                var fechafinOriginal = Convert.ToDateTime(form["fechaFinOriginal"]);

                if ((Convert.ToDateTime(form["fecInicio"]) < fechainicioOriginal || Convert.ToDateTime(form["fecInicio"]) > fechafinOriginal)
                    || (Convert.ToDateTime(form["fecFin"]) > fechafinOriginal || Convert.ToDateTime(form["fecFin"]) < fechainicioOriginal))
                {
                    ModelState.AddModelError("errorActualizar", "El rango de fechas seleccionado no coincide con el registro de vacaciones a reintegrar");
                    return PartialView("_ErrorVacaciones");
                }

                CReintegroVacacionesDTO reintegro = new CReintegroVacacionesDTO
                {
                    CantidadDias = Convert.ToDecimal(form["diasReintegro"]),
                    FechaActualizacion = DateTime.Now,
                    FechaRige = Convert.ToDateTime(form["fecInicio"]),
                    FechaVence = Convert.ToDateTime(form["fecFin"]),
                    Fuente = form["fuente"],
                    Motivo = 99,
                    Observaciones = form["obsReintegro"],
                    SolReintegro = form["docReintegro"],
                    RegistroVacaciones = new CRegistroVacacionesDTO { IdEntidad = Convert.ToInt32(form["identRegistro"]) }
                };

                var resultado = ServicioVacaciones.RegistrarReintegroRegistro(reintegro);

                if (resultado.GetType() != typeof(CErrorDTO))
                {
                    return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                            form["Funcionario.Cedula"] + "&codPeriodo=" +
                            form["Periodo.Periodo"] + "&codigo=" + resultado.IdEntidad + "&detalle=6'");
                }
                else
                {
                    ModelState.AddModelError("errorActualizar", ((CErrorDTO)resultado).MensajeError);
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("errorActualizar", error.Message);
                return PartialView("_ErrorVacaciones");
            }

        }

        [HttpPost]
        public ActionResult ReintegrarVacaciones(FormularioRegistroVacacionesVM model)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                if (ModelState.IsValid)
                {
                    model.ReintegroVacaciones.Mensaje = model.PeriodoVacaciones.Periodo;

                    var reintegra = ServicioVacaciones.RegistraReintegroVacaciones(model.RegistroVacaciones.NumeroTransaccion, model.ReintegroVacaciones, model.Funcionario.Cedula);
                    if (((CRespuestaDTO)reintegra).Codigo > 0)
                    {
                        /*return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                                                                          model.Funcionario.Cedula + "&CodPeriodo=" +
                                                                           model.PeriodoVacaciones.Periodo + "&Codigo=" + ((CRespuestaDTO)reintegra).Codigo + "&detalle=3'");*/
                        model.Funcionario.Sexo = GeneroEnum.Indefinido;
                        var encargado = servicioCalificacion.BuscarEncargado(model.Funcionario, model.Puesto.UbicacionAdministrativa);
                        if (encargado.ElementAt(0).GetType() != typeof(CErrorDTO))
                        {
                            /*EmailWebHelper correo = new EmailWebHelper();
                            correo.Destinos = encargado.ElementAt(0).Mensaje;
                            correo.Asunto = "Reintegro de vacaciones";
                            var funcionarioNombre = model.Funcionario.Nombre + " " + model.Funcionario.PrimerApellido + " " + model.Funcionario.SegundoApellido;
                            correo.EmailBody = CorreoReintegro(funcionarioNombre);
                            correo.EnviarCorreo();*/
                        }
                        Session["ReintegroActivo"] = "tab2";
                        //return JavaScript("window.location = '/Vacaciones/MisSolicitudes'");
                        return JavaScript("window.location = '/Vacaciones/MisReintegros'");
                    }
                    else
                    {
                        ModelState.AddModelError("Error",
                          ((CRespuestaDTO)reintegra).Mensaje);
                        throw new Exception("Guardar");
                    }
                }
                else
                {
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult ReportesHistoricos()
        {
            if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Consulta))] != null ||
                Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
            {
                BusquedaVacacionesReportesVM model = new BusquedaVacacionesReportesVM();
                List<string> estados = new List<string>();
                estados.Add("Registros");
                estados.Add("Reintegros");
                List<string> estadosTipoVacaciones = new List<string>();
                estadosTipoVacaciones.Add("Vacaciones");
                estadosTipoVacaciones.Add("Permiso sin goce de salario");
                model.Divisiones = new SelectList(ServicioVacaciones.ListarDivisiones().Select(U => ((CDivisionDTO)U).NomDivision));
                model.Secciones = new SelectList(ServicioVacaciones.ListarSecciones().Select(U => ((CSeccionDTO)U).NomSeccion));
                model.Estados = new SelectList(estados);
                model.tipoRegistroVacaciones = new SelectList(estadosTipoVacaciones);
                return View(model);
            }
            else
            {
                CAccesoWeb.CargarErrorAcceso(Session);
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }
        [HttpPost]
        public ActionResult ReportesHistoricos(BusquedaVacacionesReportesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "BuscarFuncionario")
                {
                    if (ModelState.IsValid == true)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula).OrderBy(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();
                        List<string> estados = new List<string>();
                        estados.Add("Registros");
                        estados.Add("Reintegros");
                        List<string> estadosTipoVacaciones = new List<string>();
                        estadosTipoVacaciones.Add("Vacaciones");
                        estadosTipoVacaciones.Add("Permiso sin goce de salario");
                        model.Estados = new SelectList(estados);
                        model.tipoRegistroVacaciones = new SelectList(estadosTipoVacaciones);
                        var periodosActuales = new List<string>();
                        List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();
                        if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                            {
                                if (item.Saldo > 0)
                                {
                                    datosDescarga.Add(item);
                                }
                            }
                        }
                        if (datosDescarga.Count < 1)
                        {
                            datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
                        }
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            if (datosDescarga[0].IdEntidad > -1)
                            {
                                var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                                if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                                {
                                    foreach (var item in periodosActivos)
                                    {
                                        periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                                    }
                                }
                                model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                model.Periodos = new SelectList(periodosActuales);

                            }
                        }
                    }
                    return PartialView("_ReportesHistoricos", model);
                }
                else if (SubmitButton == "Buscar")
                {
                    try
                    {
                        if (model.EstadoSeleccion != null || model.Funcionario.Cedula != null || model.SeleccionTipoVacaciones != null || model.PeriodoSeleccion != null || model.Periodo.Periodo != null
                        || model.DivisionSeleccion != null || (model.FechaFinalVacaciones.Year > 1 && model.FechaInicioVacaciones.Year > 1))
                        {
                            var filtro = new List<string>();
                            List<DateTime> fechas = new List<DateTime>();
                            if (model.FechaInicioVacaciones.Year > 1 && model.FechaFinalVacaciones.Year > 1)
                            {
                                fechas.Add(model.FechaFinalVacaciones);
                                fechas.Add(model.FechaInicioVacaciones);
                                filtro.Add(" Fechas");
                                if (model.EstadoSeleccion == null)
                                {
                                    model.EstadoSeleccion = "null";
                                }
                                if (model.SeleccionTipoVacaciones == null)
                                {
                                    model.SeleccionTipoVacaciones = "null";
                                }
                                if (model.DivisionSeleccion == null)
                                {
                                    model.DivisionSeleccion = "null";
                                }
                                if (model.PeriodoSeleccion == null)
                                {
                                    model.PeriodoSeleccion = "null";
                                }
                                if (model.Funcionario != null)
                                {
                                    model.Funcionario.Sexo = GeneroEnum.Indefinido;
                                }
                                if (model.EstadoSeleccion == "Registros" || model.EstadoSeleccion == "Rebajo colectivo")
                                {
                                    if (model.EstadoSeleccion == "Rebajo colectivo" && model.SeleccionTipoVacaciones != "null")
                                    {
                                        ModelState.Clear();
                                        ModelState.AddModelError("Busqueda", "Para buscar por tipo de vacaciones debe seleccionar tipo de registro vacaciones.");
                                        throw new Exception("Busqueda");
                                    }
                                    var datos = new CBaseDTO[0][];
                                    if (model.Funcionario != null)
                                    {
                                        datos = ServicioVacaciones.BuscarVacacionesFuncionario(model.Funcionario, model.PeriodoSeleccion, fechas.ToArray(), model.EstadoSeleccion, model.SeleccionTipoVacaciones);
                                    }
                                    else
                                    {
                                        datos = ServicioVacaciones.BuscarVacacionesDivision(model.DivisionSeleccion, model.Periodo, fechas.ToArray(), model.EstadoSeleccion, model.SeleccionTipoVacaciones);
                                    }

                                    if (datos[0][0].GetType() != typeof(CErrorDTO))
                                    {
                                        if (model.EstadoSeleccion == "Rebajo colectivo")
                                        {
                                            model.RegistroRebajoColectivo = true;
                                        }
                                        model.RegistroVacaciones = datos.ElementAt(0).Select(F => (CRegistroVacacionesDTO)F).ToList();
                                        model.RegistroFuncionarios = datos.ElementAt(1).Select(F => (CFuncionarioDTO)F).ToList();
                                        model.PeriodosVacaciones = datos.ElementAt(2).Select(F => (CPeriodoVacacionesDTO)F).ToList();
                                        return PartialView("_ReportesHistoricos", model);
                                    }
                                    else
                                    {
                                        ModelState.Clear();
                                        ModelState.AddModelError("Busqueda",
                                              ((CErrorDTO)datos[0][0]).MensajeError);
                                        throw new Exception("Busqueda");
                                    }
                                }
                                else
                                {
                                    if (model.EstadoSeleccion == "Reintegros" && model.SeleccionTipoVacaciones != "null")
                                    {
                                        ModelState.Clear();
                                        ModelState.AddModelError("Busqueda", "Para buscar por tipo de vacaciones debe seleccionar tipo de registro vacaciones.");
                                        throw new Exception("Busqueda");
                                    }
                                    var datosReintegros = new CBaseDTO[0][];
                                    if (model.Funcionario != null)
                                    {
                                        datosReintegros = ServicioVacaciones.BuscarReintegrosFuncionario(model.Funcionario, model.PeriodoSeleccion, fechas.ToArray());
                                    }
                                    else
                                    {
                                        datosReintegros = ServicioVacaciones.BuscarReintegrosDivision(model.DivisionSeleccion, model.Periodo, fechas.ToArray());
                                    }
                                    if (datosReintegros[0][0].GetType() != typeof(CErrorDTO))
                                    {
                                        model.ReintegrosVacaciones = datosReintegros.ElementAt(0).Select(F => (CReintegroVacacionesDTO)F).ToList();
                                        model.RegistroFuncionarios = datosReintegros.ElementAt(1).Select(F => (CFuncionarioDTO)F).ToList();
                                        model.PeriodosVacaciones = datosReintegros.ElementAt(2).Select(F => (CPeriodoVacacionesDTO)F).ToList();
                                        return PartialView("_ReportesHistoricos", model);
                                    }
                                    else
                                    {
                                        ModelState.Clear();
                                        ModelState.AddModelError("Busqueda",
                                              ((CErrorDTO)datosReintegros[0][0]).MensajeError);
                                        throw new Exception("Busqueda");
                                    }
                                }
                            }
                            else
                            {
                                ModelState.Clear();
                                if (model.FechaFinalVacaciones.Year < 2 && model.FechaInicioVacaciones.Year > 2 || model.FechaFinalVacaciones.Year > 2 && model.FechaInicioVacaciones.Year > 2)
                                {
                                    ModelState.AddModelError("Busqueda", "Para realizar una búsqueda con rango de fechas de Vencimiento, debe ingresar la fecha -desde- y la fecha -hasta-.");
                                }
                                if (model.EstadoSeleccion == null)
                                {
                                    ModelState.AddModelError("Busqueda", "Debe ingresar un tipo de registo.");
                                }
                                else
                                {
                                    ModelState.AddModelError("Busqueda", "Los parámetros ingresados son insuficientes para realizar la búsqueda.");
                                }
                                throw new Exception("Busqueda");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return PartialView("_ErrorVacaciones");
                    }
                    return null;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }

        public ActionResult Reportes()
        {
            if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Consulta))] != null ||
                Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
            {
                BusquedaVacacionesReportesVM model = new BusquedaVacacionesReportesVM();
                List<string> estados = new List<string>();
                estados.Add("Registros");
                estados.Add("Reintegros");
                estados.Add("Rebajo colectivo");
                List<string> estadosTipoVacaciones = new List<string>();
                estadosTipoVacaciones.Add("Vacaciones");
                estadosTipoVacaciones.Add("Permiso sin goce de salario");
                estadosTipoVacaciones.Add("Proporcionales");
                model.Direcciones = new SelectList(ServicioVacaciones.ListarDireccionGeneral().Select(U => ((CDireccionGeneralDTO)U).NomDireccion));
                model.Divisiones = new SelectList(ServicioVacaciones.ListarDivisiones().Select(U => ((CDivisionDTO)U).NomDivision));
                model.Departamentos = new SelectList(ServicioVacaciones.ListarDepartamentos().Select(U => ((CDepartamentoDTO)U).NomDepartamento));
                model.Secciones = new SelectList(ServicioVacaciones.ListarSecciones().Select(U => ((CSeccionDTO)U).NomSeccion));
                model.Estados = new SelectList(estados);
                model.tipoRegistroVacaciones = new SelectList(estadosTipoVacaciones);
                return View(model);
            }
            else
            {
                CAccesoWeb.CargarErrorAcceso(Session);
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }
        [HttpPost]
        public ActionResult Reportes(BusquedaVacacionesReportesVM model)
        {
            try
            {
                if (model.EstadoSeleccion != null && (model.Funcionario.Cedula != null || model.SeleccionTipoVacaciones != null || model.Periodo.Periodo != null || model.Registro.NumeroTransaccion != null
                    || model.DepartamentoSeleccion != null || model.DireccionSeleccion != null
                    || model.DivisionSeleccion != null || model.SeccionSeleccion != null || model.DepartamentoSeleccion != null || (model.FechaFinalVacaciones.Year > 1 &&
                    model.FechaInicioVacaciones.Year > 1)))
                {
                    var filtro = new List<string>();
                    List<DateTime> fechas = new List<DateTime>();
                    if (model.FechaInicioVacaciones.Year > 1 && model.FechaFinalVacaciones.Year > 1)
                    {
                        fechas.Add(model.FechaFinalVacaciones);
                        fechas.Add(model.FechaInicioVacaciones);
                        filtro.Add(" Fechas");
                    }
                    if (model.EstadoSeleccion == null)
                    {
                        model.EstadoSeleccion = "null";
                    }
                    if (model.SeleccionTipoVacaciones == null)
                    {
                        model.SeleccionTipoVacaciones = "null";
                    }
                    if (model.DepartamentoSeleccion == null)
                    {
                        model.DepartamentoSeleccion = "null";
                    }
                    if (model.DireccionSeleccion == null)
                    {
                        model.DireccionSeleccion = "null";
                    }
                    if (model.DivisionSeleccion == null)
                    {
                        model.DivisionSeleccion = "null";
                    }
                    if (model.SeccionSeleccion == null)
                    {
                        model.SeccionSeleccion = "null";
                    }
                    model.Funcionario.Sexo = GeneroEnum.Indefinido;
                    if (model.EstadoSeleccion == "Registros" || model.EstadoSeleccion == "Rebajo colectivo")
                    {
                        if (model.EstadoSeleccion == "Rebajo colectivo" && model.SeleccionTipoVacaciones != "null")
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Busqueda", "Para buscar por tipo de vacaciones debe seleccionar tipo de registro vacaciones.");
                            throw new Exception("Busqueda");
                        }
                        var datos = ServicioVacaciones.BuscarVacaciones(model.Funcionario, model.Periodo, model.Registro, fechas.ToArray(),
                            model.DireccionSeleccion, model.SeccionSeleccion, model.DivisionSeleccion, model.DepartamentoSeleccion, model.EstadoSeleccion, model.SeleccionTipoVacaciones);
                        if (datos[0][0].GetType() != typeof(CErrorDTO))
                        {
                            if (model.EstadoSeleccion == "Rebajo colectivo")
                            {
                                model.RegistroRebajoColectivo = true;
                            }

                            model.RegistroVacaciones = datos.ElementAt(0).Select(F => (CRegistroVacacionesDTO)F).ToList();

                            model.RegistroFuncionarios = datos.ElementAt(1).Select(F => (CFuncionarioDTO)F).ToList();
                            model.PeriodosVacaciones = datos.ElementAt(2).Select(F => (CPeriodoVacacionesDTO)F).ToList();
                            return PartialView("_Reportes", model);
                        }
                        else
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Busqueda",
                                  ((CErrorDTO)datos[0][0]).MensajeError);
                            throw new Exception("Busqueda");
                        }
                    }
                    else
                    {
                        if (model.EstadoSeleccion == "Reintegros" && model.SeleccionTipoVacaciones != "null")
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Busqueda", "Para buscar por tipo de vacaciones debe seleccionar tipo de registro vacaciones.");
                            throw new Exception("Busqueda");
                        }

                        var datosReintegros = ServicioVacaciones.BuscarReintegros(model.Funcionario, model.Periodo, model.Registro, fechas.ToArray(), model.DireccionSeleccion, model.SeccionSeleccion, model.DivisionSeleccion, model.DepartamentoSeleccion);

                        if (datosReintegros[0][0].GetType() != typeof(CErrorDTO))
                        {
                            model.ReintegrosVacaciones = datosReintegros.ElementAt(0).Select(F => (CReintegroVacacionesDTO)F).ToList();
                            model.RegistroFuncionarios = datosReintegros.ElementAt(1).Select(F => (CFuncionarioDTO)F).ToList();
                            model.PeriodosVacaciones = datosReintegros.ElementAt(2).Select(F => (CPeriodoVacacionesDTO)F).ToList();
                            return PartialView("_Reportes", model);
                        }
                        else
                        {
                            ModelState.Clear();
                            ModelState.AddModelError("Busqueda",
                                  ((CErrorDTO)datosReintegros[0][0]).MensajeError);
                            throw new Exception("Busqueda");
                        }

                    }

                }
                else
                {
                    ModelState.Clear();
                    if (model.FechaFinalVacaciones.Year < 2 && model.FechaInicioVacaciones.Year > 2 || model.FechaFinalVacaciones.Year > 2 && model.FechaInicioVacaciones.Year > 2)
                    {
                        ModelState.AddModelError("Busqueda", "Para realizar una búsqueda con rango de fechas de Vencimiento, debe ingresar la fecha -desde- y la fecha -hasta-.");
                    }
                    if (model.EstadoSeleccion == null)
                    {
                        ModelState.AddModelError("Busqueda", "Debe ingresar un tipo de registo.");

                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", "Los parámetros ingresados son insuficientes para realizar la búsqueda.");
                    }
                    throw new Exception("Busqueda");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }

        }
        public ActionResult CreatePeriodo()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    return View();
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult CreatePeriodo(FormularioPeriodoVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuestoVacaciones(model.Funcionario.Cedula);
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                            model.Puesto = (CPuestoDTO)datosFuncionario[1];
                            model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];

                            var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                            if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                                model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).OrderBy(P => P.Periodo).ToList();

                            var datosJefatura = ServicioVacaciones.ListarJefatura(model.Funcionario.Cedula);

                            if (datosJefatura.GetType() != typeof(CErrorDTO))
                                model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                            else
                            {
                                ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                                throw new Exception("BusquedaFuncionario");
                            }

                            return PartialView("_FormularioPeriodo", model);
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                                  ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaPeriodo");
                        }

                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }
                else
                {
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                    if (ModelState.IsValid && model.PeriodoVacaciones.Periodo != null)
                    {
                        model.PeriodoVacaciones.Bitacora = new CBitacoraDTO { Usuario = Session["CedulaUsuario"].ToString() };

                        var guardarDatos = ServicioVacaciones.GuardaRegistroPeriodo(model.PeriodoVacaciones, model.Funcionario.Cedula);
                        if (((CBaseDTO)guardarDatos).IdEntidad < 0)
                        {
                            ModelState.AddModelError("Error al ingresar", ((CRespuestaDTO)guardarDatos).Mensaje);
                            throw new Exception("Guardar");
                        }
                        else
                        {
                            return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                                                  model.Funcionario.Cedula + "&CodPeriodo=" +
                                                   model.PeriodoVacaciones.Periodo + "&Codigo=" + ((CBaseDTO)guardarDatos).IdEntidad + "&detalle=2'");
                        }
                    }

                    else
                    {
                        if (model.PeriodoVacaciones.Periodo == null)
                        {
                            ModelState.AddModelError("Periodo", "El periodo es obligatorio.");

                        }
                        throw new Exception("Error al cargar el modelo");

                    }

                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult Details(string cedula, string codPeriodo, int codigo, int detalle = 0)
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    DetalleVacacionesVM model = new DetalleVacacionesVM();
                    model.detalle = detalle;
                    var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuestoVacaciones(cedula);
                    var datosPeriodo = ServicioVacaciones.ObtenerPeriodo(cedula, codPeriodo, codigo);
                    var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(cedula);
                    if (periodosActivos[0].GetType() != typeof(CErrorDTO))
                    {
                        var datosperiodos = periodosActivos.Where(P => P.IdEntidad != datosPeriodo.IdEntidad).ToList();
                        model.PeriodosActivos = datosperiodos.Select(F => (CPeriodoVacacionesDTO)F).ToList();
                    }
                    else
                    {
                        model.PeriodosActivos = null;
                    }
                    model.Periodo = (CPeriodoVacacionesDTO)datosPeriodo;
                    model.codigoDetalle = codigo;
                    if (codigo > 0)
                    {
                        var datosRegistroVacaciones = ServicioVacaciones.ListarRegistroVacaciones(cedula, codPeriodo, codigo);
                        var datosReintegro = ServicioVacaciones.ListarReintegrosPeriodos(cedula, codPeriodo, codigo);
                        if (datosRegistroVacaciones.ElementAt(0).GetType() != typeof(CErrorDTO))
                        {
                            model.RegistroVacaciones = datosRegistroVacaciones.Select(F => (CRegistroVacacionesDTO)F).ToList();
                            model.TotalRegistros = datosRegistroVacaciones.Sum(F => ((CRegistroVacacionesDTO)F).Dias);
                            if (model.TotalRegistros > model.Periodo.DiasDerecho)
                            {
                                model.Alerta = "¡ATENCIÓN! La sumatoria de días disfrutados de este periodo es mayor a los días a derecho, por favor revise la información para solventar esta inconsistencia.";
                            }
                        }
                        else
                        {
                            model.RegistroVacaciones = new List<CRegistroVacacionesDTO>();
                        }
                        if (datosReintegro.Count() > 0 && datosReintegro.ElementAt(0).GetType() != typeof(CErrorDTO))
                        {
                            model.ReintegroVacaciones = datosReintegro.Select(F => (CReintegroVacacionesDTO)F).ToList();
                            model.TotalReintegros = datosReintegro.Sum(F => ((CReintegroVacacionesDTO)F).CantidadDias);
                        }
                        else
                        {
                            model.ReintegroVacaciones = new List<CReintegroVacacionesDTO>();
                        }
                        model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                        model.DetalleContratacion = (CDetalleContratacionDTO)datosFuncionario[3];
                        model.Puesto = (CPuestoDTO)datosFuncionario[1];
                        model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                        model.codigoDetalle = codigo;
                        model.estadoPeriodo = DefinirEstadoPeriodo(model.Periodo.Estado);

                        var datosJefatura = ServicioVacaciones.ListarJefatura(model.Funcionario.Cedula);

                        if (datosJefatura.GetType() != typeof(CErrorDTO))
                            model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                    }
                    return View(model);
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }

        private string DefinirEstadoPeriodo(int estado)
        {
            switch (estado)
            {
                case 1:
                    return "Activo";
                case 2:
                    return "Vencido";
                case 3:
                    return "Anulado";
                default:
                    return "Indefinido";
            }
        }

        [HttpPost]
        public ActionResult ActualizarDatos(int idRegistro, string mensaje, FormCollection form)
        {
            try
            {
                if (form.Count > 4)
                    if (mensaje == "saldo" && Convert.ToDecimal(form[4]) > Convert.ToDecimal(form[1]))
                        throw new Exception("El nuevo saldo es mayor a la cantidad de días a derecho. Revise por favor");

                var resultado = ServicioVacaciones.ActualizarDatosVacaciones(idRegistro, mensaje, form.Count > 4 ? Convert.ToDecimal(form[4]) : 0);
                //return RedirectToAction("Details", "Vacaciones", new { cedula = form[3], codPeriodo = form[2], codigo = idRegistro });
                if (resultado.GetType() != typeof(CErrorDTO))
                {
                    if (mensaje != "anular")
                    {
                    //    //Registrar Bitácora
                    //    CBitacoraDTO bitacora = new CBitacoraDTO
                    //    {
                    //        TipoMovimiento = "Registrar Periodo Vacaciones";
                    //    NumMovimiento = cedulaFuncionario + "|" + ((PeriodoVacaciones)resultado.Contenido).PK_PeriodoVacaciones.ToString();
                    //    NombreCampo = "IndDiasDerecho";
                    //    ValorInicial = registroPeriodo.DiasDerecho.ToString();
                    //    ValorFinal = registroPeriodo.DiasDerecho.ToString();
                    //    TipoTransaccion = "I";
                    //    Estructura = "PeriodoVacaciones";
                    //};

                        return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                          form[3] + "&CodPeriodo=" +
                           form[2] + "&Codigo=" + idRegistro + "&detalle=5'");
                    }
                    else
                    {
                        return JavaScript("window.location = '/Vacaciones/Search'");
                    }
                }
                else
                {
                    ModelState.AddModelError("errorActualizar",((CErrorDTO)resultado).MensajeError);
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("errorActualizar", error.Message);
                return PartialView("_ErrorVacaciones");
            }
        }

        public ActionResult DetalleHistorial(string cedula, string periodo, string ex = "no")
        {
            DetalleVacacionesVM model = new DetalleVacacionesVM();
            try
            {
                var respuesta = ServicioVacaciones.BuscarHistorialMovimientoVacaciones(cedula, periodo);

                if (respuesta.ElementAt(0).GetType() != typeof(CErrorDTO))
                {
                    if (ex == "si")
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarExfuncionarioFiltros(cedula, "", "", "", "");
                        model.DetalleContratacion = new CDetalleContratacionDTO
                        {
                            Mensaje = datosFuncionario[0].NumeroExpediente,
                            FechaIngreso = Convert.ToDateTime(datosFuncionario[0].FechaIngreso),
                            FechaCese = Convert.ToDateTime(datosFuncionario[0].FechaCese)
                        };
                        model.Funcionario = new CFuncionarioDTO
                        {
                            Cedula = datosFuncionario[0].Cedula,
                            Nombre = datosFuncionario[0].Nombre,
                            PrimerApellido = datosFuncionario[0].PrimerApellido,
                            SegundoApellido = datosFuncionario[0].SegundoApellido,
                            EstadoFuncionario = new CEstadoFuncionarioDTO { DesEstadoFuncionario = datosFuncionario[0].DescEstado }
                        };
                        model.Puesto = new CPuestoDTO
                        {
                            CodPuesto = datosFuncionario[0].PuestoPropiedad,
                            UbicacionAdministrativa = new CUbicacionAdministrativaDTO
                            {
                                Division = new CDivisionDTO { NomDivision = datosFuncionario[0].Division },
                                DireccionGeneral = new CDireccionGeneralDTO { NomDireccion = datosFuncionario[0].Direccion },
                                Departamento = new CDepartamentoDTO { NomDepartamento = datosFuncionario[0].Departamento },
                                Seccion = new CSeccionDTO { NomSeccion = datosFuncionario[0].Seccion }
                            }
                        };
                        model.DetallePuesto = new CDetallePuestoDTO
                        {
                            Clase = new CClaseDTO { DesClase = datosFuncionario[0].ClasePuesto }
                        };
                    }
                    else
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuestoVacaciones(cedula);
                        model.RegistroVacaciones = new List<CRegistroVacacionesDTO>();
                        model.Periodo = new CPeriodoVacacionesDTO { Periodo = periodo };
                        model.DetalleContratacion = (CDetalleContratacionDTO)ServicioVacaciones.DetalleContratacion(cedula);
                        model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                        model.Puesto = (CPuestoDTO)datosFuncionario[1];
                        model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                    }

                    model.RegistroVacaciones = new List<CRegistroVacacionesDTO>();
                    model.ReintegroVacaciones = new List<CReintegroVacacionesDTO>();
                    model.Periodo = new CPeriodoVacacionesDTO { Periodo = periodo };

                    foreach (var item in respuesta)
                    {
                        if (((CRegistroVacacionesDTO)item).TipoTransaccion != 99)
                        {
                            model.RegistroVacaciones.Add((CRegistroVacacionesDTO)item);
                            model.TotalRegistros += ((CRegistroVacacionesDTO)item).Dias;
                        }
                        else
                        {
                            model.ReintegroVacaciones.Add(new CReintegroVacacionesDTO
                            {
                                FechaRige = ((CRegistroVacacionesDTO)item).FechaRige,
                                SolReintegro = ((CRegistroVacacionesDTO)item).NumeroTransaccion,
                                CantidadDias = ((CRegistroVacacionesDTO)item).Dias
                            });

                            model.TotalReintegros += ((CRegistroVacacionesDTO)item).Dias;
                        }
                    }

                    return View(model);
                }
                else
                {
                    throw new Exception(((CErrorDTO)respuesta.ElementAt(0)).MensajeError);
                }
            }
            catch (Exception error)
            {
                model.Error = new CErrorDTO { MensajeError = error.Message };
                return View("_ErrorVacaciones");
            }
        }


        [HttpPost]
        public ActionResult TrasladarRegistro(FormCollection form)
        {
            var cantidadPeriodos = Convert.ToInt32(form["PeriodosActivos.Count"]);
            int idRegistro = 0;
            decimal dias = 0;
            int periodoDestino = 0;

            for (int i = 0; i < cantidadPeriodos; i++)
            {
                var texto = form["textdiasTraslado" + i];
                if (texto != "")
                {
                    dias = Convert.ToDecimal(texto);
                    idRegistro = Convert.ToInt32(form["identRegistro"]);
                    periodoDestino = Convert.ToInt32(form["PeriodosActivos["+i+"].IdEntidad"]);
                    var respuesta = ServicioVacaciones.TrasladarRegistroVacaciones(idRegistro, dias, periodoDestino);
                    if (respuesta.GetType() != typeof(CErrorDTO))
                    {
                        return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                                form["Funcionario.Cedula"] + "&CodPeriodo=" +
                                form["Periodo.Periodo"] + "&Codigo=" + form["Periodo.IdEntidad"] + "&detalle=5'");
                    }
                    else
                    {
                        ModelState.AddModelError("errorActualizar", ((CErrorDTO)respuesta).MensajeError);
                        return PartialView("_ErrorVacaciones");
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult AnularRegistro(FormCollection form)
        {

            int idCedula = 0;
            int identRegistro = 0;
            idCedula = Convert.ToInt32(form["Funcionario.Cedula"]);
            identRegistro = Convert.ToInt32(form["identRegistro"]);
            var respuesta = ServicioVacaciones.AnularSolicitudVacaciones(identRegistro);
            if (identRegistro != 0)
            {
                return JavaScript("window.location = '/Vacaciones/MisSolicitudes'");
            }
            return View();
        }
        [HttpPost]
        public ActionResult MostrarDetalles(FormCollection form)
        {
            var respuesta = ServicioVacaciones.ObtenerDetalleVacaciones(form["Funcionario.Cedula"]);
            return JavaScript("window.location = '/Vacaciones/MisSolicitudes'");
        }
        [HttpPost]
        public ActionResult AnularReintegro(FormCollection form)
        {
            int idCedula = 0;
            int identRegistro = 0;
            idCedula = Convert.ToInt32(form["Funcionario.Cedula"]);
            identRegistro = Convert.ToInt32(form["identRegistro"]);
            var respuesta = ServicioVacaciones.AnularSolicitudReintegro(identRegistro);
            if (identRegistro != 0)
            {

                Session["ReintegroActivo"] = "tab2";
                //return JavaScript("window.location = '/Vacaciones/MisSolicitudes'");
                return JavaScript("window.location = '/Vacaciones/MisReintegros'");
            }
            return View();
        }

        [HttpPost]
        public CrystalReportPdfResult ReporteDetalle(BusquedaVacacionesReportesVM model)
        {

            if (model.RegistroVacaciones != null)
            {
                List<ReporteRegistrosRpt> modelo = new List<ReporteRegistrosRpt>();
                for (int i = 0; i < model.RegistroVacaciones.Count(); i++)
                {
                    modelo.Add(ReporteRegistrosRpt.GenerarDatosReporte(model.RegistroVacaciones[i], model.RegistroFuncionarios[i], model.PeriodosVacaciones[i]));
                }
                string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "ReporteRegistroRPT.rpt");
                return new CrystalReportPdfResult(reportPath, modelo, "PDF");
            }
            else
            {
                List<ReporteReintegroRpt> modelo2 = new List<ReporteReintegroRpt>();
                for (int i = 0; i < model.ReintegrosVacaciones.Count(); i++)
                {
                    modelo2.Add(ReporteReintegroRpt.GenerarDatosReporte(model.ReintegrosVacaciones[i], model.RegistroFuncionarios[i], model.PeriodosVacaciones[i]));
                }
                string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "ReporteReintegroRPT.rpt");
                return new CrystalReportPdfResult(reportPath, modelo2, "PDF");
            }
        }
        public ActionResult RebajoColectivo()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    return View();
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }

        [HttpPost]
        public CrystalReportPdfResult ReporteDetalleHistorico(BusquedaVacacionesReportesVM model, string SubmitButton)
        {
            if (model.RegistroVacaciones != null)
            {
                if (SubmitButton == "PdfRegistros")
                {
                    List<ReporteRegistrosRpt> modelo = new List<ReporteRegistrosRpt>();
                    for (int i = 0; i < model.RegistroVacaciones.Count(); i++)
                    {
                        modelo.Add(ReporteRegistrosRpt.GenerarDatosReporte(model.RegistroVacaciones[i], model.RegistroFuncionarios[i], model.PeriodosVacaciones[i]));
                    }
                    string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "ReporteRegistroVacacionesHistorico.rpt");
                    return new CrystalReportPdfResult(reportPath, modelo, "PDF");
                }
                else
                {
                    List<ReporteRegistrosRpt> modelo = new List<ReporteRegistrosRpt>();
                    for (int i = 0; i < model.RegistroVacaciones.Count(); i++)
                    {
                        modelo.Add(ReporteRegistrosRpt.GenerarDatosReporte(model.RegistroVacaciones[i], model.RegistroFuncionarios[i], model.PeriodosVacaciones[i]));
                    }
                    string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "ReporteRegistroVacacionesHistorico.rpt");
                    return new CrystalReportPdfResult(reportPath, modelo, "EXCEL");
                }
            }
            else
            {
                if (SubmitButton == "PdfReintegros")
                {
                    List<ReporteReintegroRpt> modelo = new List<ReporteReintegroRpt>();
                    for (int i = 0; i < model.ReintegrosVacaciones.Count(); i++)
                    {
                        modelo.Add(ReporteReintegroRpt.GenerarDatosReporte(model.ReintegrosVacaciones[i], model.RegistroFuncionarios[i], model.PeriodosVacaciones[i]));
                    }
                    string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "ReporteRegistroReintegroHistorico.rpt");
                    return new CrystalReportPdfResult(reportPath, modelo, "PDF");
                }
                else
                {
                    List<ReporteReintegroRpt> modelo = new List<ReporteReintegroRpt>();
                    for (int i = 0; i < model.ReintegrosVacaciones.Count(); i++)
                    {
                        modelo.Add(ReporteReintegroRpt.GenerarDatosReporte(model.ReintegrosVacaciones[i], model.RegistroFuncionarios[i], model.PeriodosVacaciones[i]));
                    }
                    string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "ReporteRegistroReintegroHistorico.rpt");
                    return new CrystalReportPdfResult(reportPath, modelo, "EXCEL");
                }

            }
        }

        [HttpPost]
        public ActionResult RebajoColectivo(RebajoColectivoVM model, string SubmitButton)
        {
            try
            {
                CBaseDTO rebajo = new CBaseDTO();
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        uploadProgresses = 0;
                        var documento = ServicioVacaciones.ValidarNumeroDocumento(model.Registro.NumeroTransaccion);
                        if (((CRespuestaDTO)documento).Codigo > 0)
                        {
                            model.funcionariosInconsistencias = new List<CFuncionarioDTO>();
                            var funcionariosActivos = ServicioVacaciones.ListarFuncionariosActivos(model.seleccionSeguridad, model.seleccionPolicial);
                            if (funcionariosActivos[0].GetType() != typeof(CErrorDTO))
                            {
                                var porcentaje = 0;
                                foreach (var item in funcionariosActivos)
                                {
                                    porcentaje++;
                                    rebajo = ServicioVacaciones.GuardarRebajoColectivo((CFuncionarioDTO)item, model.Registro);
                                    //var inconsistencia = ServicioVacaciones.ObtenerInconsistencias(model.Registro
                                    //    .FechaRige, model.Registro.FechaVence, ((CFuncionarioDTO)item).Cedula);
                                    //if (inconsistencia[0][0].GetType() != typeof(CErrorDTO))
                                    //{
                                    //    model.registrosInconsistentes = inconsistencia.ElementAt(0).Select(F => (CRegistroVacacionesDTO)F).ToList();
                                    //    model.funcionariosInconsistencias = inconsistencia.ElementAt(1).Select(F => (CFuncionarioDTO)F).ToList();
                                    //}
                                    if (((CRespuestaDTO)rebajo).Codigo < 0)
                                    {
                                        uploadProgresses = -1;
                                        ModelState.AddModelError("Busqueda", "Ocurrio un error al realizar el rebajo colectivo");
                                        throw new Exception("Rebajo Colectivo");

                                    }
                                    else
                                    if (porcentaje == Convert.ToInt32((funcionariosActivos.Count() / 100)))
                                    {
                                        uploadProgresses++;
                                        porcentaje = 0;
                                        if (uploadProgresses > 100)
                                        {
                                            uploadProgresses = 100;
                                        }
                                    }
                                }
                                uploadProgresses = 100;
                                return PartialView("_RebajoColectivoInfo", model);
                            }
                            else
                            {
                                uploadProgresses = -1;
                                ModelState.AddModelError("Busqueda", "Ocurrio un error al intentar cargar los funcionarios");
                                throw new Exception("BusquedaPeriodo");
                            }
                        }
                        else
                        {
                            uploadProgresses = -1;
                            ModelState.AddModelError("DocumentoRepetido",
                          ((CRespuestaDTO)documento).Mensaje);
                            throw new Exception("BusquedaPeriodo");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }

                }
                else
                {
                    throw new Exception("Busqueda");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        [HttpPost]
        public ActionResult RebajoColectivoInfo(RebajoColectivoVM model, string SubmitButton)
        {
            try
            {
                CBaseDTO rebajo = new CBaseDTO();
                if (SubmitButton == "Anular")
                {
                    if (ModelState.IsValid == true)
                    {
                        var funcionariosActivos = ServicioVacaciones.ListarFuncionariosActivos(model.seleccionSeguridad, model.seleccionPolicial);
                        foreach (var item in funcionariosActivos)
                        {
                            ServicioVacaciones.AnularRebajoColectivo((CFuncionarioDTO)item, model.Registro.NumeroTransaccion);
                        }
                        return JavaScript("window.location = '/Vacaciones/AnularRebajo?numeroTransaccion=" +
                                                  model.Registro.NumeroTransaccion + "'");
                    }
                    else
                    {
                        throw new Exception("Anular");
                    }

                }
                else
                {
                    throw new Exception("Anular");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Busqueda", "Ocurrio un al intentar anular el rebajo colectivo.");
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult AnularRebajo(string numeroTransaccion)
        {
            RebajoColectivoVM model = new RebajoColectivoVM();
            model.numTransaccion = numeroTransaccion;
            return View(model);
        }
        public CrystalReportPdfResult ReporteFuncionario(string cedula)
        {
            List<PeriodoVacacionesRpt> modelo1 = new List<PeriodoVacacionesRpt>();
            List<DatosFuncionarioRpt> modelo2 = new List<DatosFuncionarioRpt>();
            BusquedaVacacionesReportesVM model = new BusquedaVacacionesReportesVM();

            var fechaCumplimiento = DateTime.Now;

            var periodos = ServicioVacaciones.ListaPeriodos(cedula);
            if (periodos[0].GetType() != typeof(CErrorDTO))
            {
                model.PeriodosVacaciones = periodos.Select(F => (CPeriodoVacacionesDTO)F).ToList();
            }
            var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedula);
            if(datosFuncionario[0].GetType() != typeof(CErrorDTO))
            {
                model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                model.Funcionario.Mensaje = ((CDetalleContratacionDTO)datosFuncionario[3]).FechaVacaciones.ToShortDateString();

                fechaCumplimiento = new DateTime(DateTime.Now.Year,
                                     ((CDetalleContratacionDTO)datosFuncionario[3]).FechaVacaciones.Month,
                                     ((CDetalleContratacionDTO)datosFuncionario[3]).FechaVacaciones.Day);

            }
            else
            {
                //Buscar Exfuncionario

                var datosFuncionarioEx = ServicioFuncionario.BuscarExfuncionarioFiltros(cedula, "", "", "", "");
                
                model.Funcionario = new CFuncionarioDTO
                {
                    Cedula = datosFuncionarioEx[0].Cedula,
                    Nombre = datosFuncionarioEx[0].Nombre.TrimEnd(),
                    PrimerApellido = datosFuncionarioEx[0].PrimerApellido.TrimEnd(),
                    SegundoApellido = datosFuncionarioEx[0].SegundoApellido.TrimEnd(),
                    EstadoFuncionario = new CEstadoFuncionarioDTO { DesEstadoFuncionario = datosFuncionarioEx[0].DescEstado.TrimEnd() },
                    Mensaje = datosFuncionarioEx[0].FechaIngreso.Value.ToString()
                };

                fechaCumplimiento = new DateTime(DateTime.Now.Year,
                                     (DateTime.Parse(model.Funcionario.Mensaje)).Month,
                                     (DateTime.Parse(model.Funcionario.Mensaje)).Day);


                var respuesta = ServicioVacaciones.BuscarHistorialPeriodoVacacionesSinActuales(model.Funcionario.Cedula, (new List<string>()).ToArray());

                model.PeriodosVacaciones = respuesta.Select(F => (CPeriodoVacacionesDTO)F).ToList();
            }
           
            modelo2.Add(DatosFuncionarioRpt.GenerarDatosReporte(model.Funcionario));
            if (model.PeriodosVacaciones != null)
            {
                //var fechaCumplimiento = new DateTime(DateTime.Now.Year,
                //                     ((CDetalleContratacionDTO)datosFuncionario[3]).FechaVacaciones.Month,
                //                     ((CDetalleContratacionDTO)datosFuncionario[3]).FechaVacaciones.Day);

                for (int i = 0; i < model.PeriodosVacaciones.Count(); i++)
                {
                    
                    model.PeriodosVacaciones[i].ProporcionMes = Math.Round(Convert.ToDouble(model.PeriodosVacaciones[i].DiasDerecho / 12), 2);
                    model.PeriodosVacaciones[i].Proporcion = Math.Round((DateTime.Now.Subtract(fechaCumplimiento).Days / 30) * model.PeriodosVacaciones[i].ProporcionMes, 2);
                    modelo1.Add(PeriodoVacacionesRpt.GenerarDatosReporte(model.PeriodosVacaciones[i]));
                }
            }
            string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "DatosFuncionarioRPT.rpt");
            return new CrystalReportPdfResult(reportPath, modelo2, modelo1);
        }

        public CrystalReportPdfResult ReporteInconsistencias(DateTime fechaInic, DateTime FechaVence, bool seguridad, bool transito)
        {
            List<InconsistenciaRebColRpt> modelo1 = new List<InconsistenciaRebColRpt>();
            var funcionarios = ServicioVacaciones.ListarFuncionariosActivos(seguridad, transito);
            foreach (var item in funcionarios)
            {
                var registros = ServicioVacaciones.ObtenerInconsistencias(fechaInic, FechaVence, ((CFuncionarioDTO)item).Cedula).ElementAt(0).Select(F => (CRegistroVacacionesDTO)F).ToList();
                foreach (var registro in registros)
                {
                    modelo1.Add(InconsistenciaRebColRpt.GenerarDatosReporte((CRegistroVacacionesDTO)registro, (CFuncionarioDTO)item));
                }
            }
            string reportPath = Path.Combine(Server.MapPath("~/Reports/Vacaciones"), "InconsistenciaRPT.rpt");
            return new CrystalReportPdfResult(reportPath, modelo1);
        }

        public ActionResult BuscarHistorial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarHistorial(DetalleVacacionesVM model)
        {
            try
            {
                var respuesta = ServicioVacaciones.BuscarHistorialPeriodoVacacionesSinActuales(model.Funcionario.Cedula, (new List<string>()).ToArray());
                var datosFuncionario = ServicioFuncionario.BuscarExfuncionarioFiltros(model.Funcionario.Cedula, "", "", "", "");

                if (respuesta.ElementAt(0).GetType() != typeof(CErrorDTO))
                {
                    model.DetalleContratacion = new CDetalleContratacionDTO
                    {
                        Mensaje = datosFuncionario[0].NumeroExpediente,
                        FechaIngreso = Convert.ToDateTime(datosFuncionario[0].FechaIngreso),
                        FechaCese = Convert.ToDateTime(datosFuncionario[0].FechaCese)
                    };
                    model.Funcionario = new CFuncionarioDTO
                    {
                        Cedula = datosFuncionario[0].Cedula,
                        Nombre = datosFuncionario[0].Nombre,
                        PrimerApellido = datosFuncionario[0].PrimerApellido,
                        SegundoApellido = datosFuncionario[0].SegundoApellido,
                        EstadoFuncionario = new CEstadoFuncionarioDTO { DesEstadoFuncionario = datosFuncionario[0].DescEstado }
                    };
                    model.Puesto = new CPuestoDTO
                    {
                        CodPuesto = datosFuncionario[0].PuestoPropiedad,
                        UbicacionAdministrativa = new CUbicacionAdministrativaDTO
                        {
                            Division = new CDivisionDTO { NomDivision = datosFuncionario[0].Division },
                            DireccionGeneral = new CDireccionGeneralDTO { NomDireccion = datosFuncionario[0].Direccion },
                            Departamento = new CDepartamentoDTO { NomDepartamento = datosFuncionario[0].Departamento },
                            Seccion = new CSeccionDTO { NomSeccion = datosFuncionario[0].Seccion } 
                        }
                    };
                    model.DetallePuesto = new CDetallePuestoDTO
                    {
                        Clase = new CClaseDTO { DesClase = datosFuncionario[0].ClasePuesto }
                    };

                    model.PeriodosEmulacion = respuesta.Select(F => (CPeriodoVacacionesDTO)F).ToList();

                    return PartialView("_BuscarHistorialResult",model);
                }
                else
                {
                    throw new Exception(((CErrorDTO)respuesta.ElementAt(0)).MensajeError);
                }
            }
            catch (Exception error)
            {
                model.Error = new CErrorDTO { MensajeError = error.Message };
                return PartialView("_BuscarHistorialResult", model);
            }
        }
        public ActionResult MisSolicitudes()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);
                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                        Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                        Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                    {

                        //Aqui comienza el proceso para mostrar las solicitudes despues de validar los permisos de la sesion

                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        //perfilUsuario fue declarado desde el constructor como CPerfilUsuarioServiceClient perfilUsuario = new CPerfilUsuarioServiceClient();
                        //el metodo RetornarPerfilUsuario en servicio llama al metodo ObtenerUsuarioPorNombre(nombreUsuario) en la Logica
                        //Identity.Name pasa el nombre de usuario como parametro, la variable usuario es temporal
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        // usuario se vuelve un arreglo con 3 listas
                        //[0] - Usuario
                        //[1] - Funcionario
                        //[2] - Perfil
                        // Le pasa el Funcionario completo con atributos al ViewModel modelUsuario haciendo un cast
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        // Crea un ViewModel de Registro de vacaciones  y le pasa Funcionario, se ocupa ese modelUsuario intermedio porque el ViewModel de  Registro de vacaciones  
                        // no tiene de atributo usuario solo funcionario
                        FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();
                        model.Funcionario = modelUsuario.Funcionario;
                        // datos funcionario  devuelve un arreglo con 4 listas
                        //[0] - Funcionario
                        //[1] - Puesto
                        //[2] - DetallePuesto
                        //[3] - DetalleContratacion
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        //Estos son los servicios hacia la tabla intermedia para almacenar FUNCIONARIO - FUNCIONARIO o FUNCIONARIO - ID DIVISION
                        //var datosPrueba = ServicioVacaciones.ObtenerPermisosAprobacion("0061720305");
                        //var datosPrueba  =  ServicioVacaciones.AgregarPermisosAprobacion(1000,102);
                        // datos periodo devuelve una lista con periodos activos y sus atributos
                        var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula).OrderByDescending(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();
                        var periodosActuales = new List<string>();
                        //var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                        //var datosReintegros = ServicioVacaciones.ObtenerReintegros(model.Funcionario.Cedula);

                        if (datosPeriodo.FirstOrDefault().GetType() != typeof(CErrorDTO))
                        {
                            foreach (var item in datosPeriodo)
                            {
                                periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                            }
                        }
                        model.ListaPeriodos = periodosActuales;
                        // datos vacaciones devuelve una lista con las solicitudes de vacaciones
                        var datosVacaciones = ServicioVacaciones.ObtenerVacaciones(model.Funcionario.Cedula).OrderBy(P => ((CRegistroVacacionesDTO)P).Periodo.IdEntidad).ToList();
                        // Metodo de prueba para anular una solicitud y restaurar saldo
                        //ServicioVacaciones.AnularSolicitudVacaciones(63796);
                        List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();
                        List<CRegistroVacacionesDTO> datosVacacionesDescarga = new List<CRegistroVacacionesDTO>();
                        // List<string> periodoPorRegistro = new List<string>();

                        // Este If revisa todos los periodos y filtra solo los que tienen dias en saldo
                        //agregandolos a la lista de datosDescarga
                        if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                            {
                                if (item.Saldo > 0)
                                {
                                    datosDescarga.Add(item);
                                }
                            }
                        }
                        if (datosVacaciones[0].GetType() != typeof(CErrorDTO))
                        {
                            model.Puesto = (CPuestoDTO)datosFuncionario[1];
                            model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                            foreach (CRegistroVacacionesDTO item in datosVacaciones)
                            {
                                if (item.Dias > 0)
                                {
                                    datosVacacionesDescarga.Add(item);
                                }
                            }
                            model.ListaRegistroVacacionesAprobadas = datosVacaciones.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 1).OrderBy(F => F.FechaRige).Reverse().ToList();
                            model.ListaRegistroVacacionesPendientes = datosVacaciones.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 2 || F.Estado == 3 || F.Estado == 6).OrderBy(F => F.FechaRige).Reverse().ToList();
                            model.ListaRegistroVacacionesRechazadas = datosVacaciones.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 4 || F.Estado == 5 ).OrderBy(F => F.FechaRige).Reverse().ToList();
                            model.ListaRegistroVacacionesAnuladas = datosVacaciones.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 7).OrderBy(F => F.FechaRige).Reverse().ToList();
                            model.PeriodosActivos = datosDescarga.Select(P => (CPeriodoVacacionesDTO)P).OrderBy(P => P.Periodo).Reverse().ToList();
                        }
                        if (datosDescarga.Count < 1)
                        {
                            datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
                        }
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            if (datosDescarga[0].IdEntidad > -1)
                            {
                                var datosJefatura = ServicioVacaciones.ListarJefatura(model.Funcionario.Cedula);

                                if (datosJefatura.GetType() != typeof(CErrorDTO))
                                    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                                else
                                {
                                    ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                                    throw new Exception("BusquedaFuncionario");
                                }

                                model.PeriodoVacaciones = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault());
                                model.RegistroVacaciones = ((CRegistroVacacionesDTO)datosVacacionesDescarga.FirstOrDefault());
                                return PartialView("MisSolicitudes", model);

                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                                throw new Exception("Error al cargar el modelo");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                        //return View();
                    }
                    else
                    {
                        CAccesoWeb.CargarErrorAcceso(Session);
                        return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                    }
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }
        public ActionResult AdministracionSolicitudes(string accion)
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);
            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                    modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                    FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();
                    model.Funcionario = modelUsuario.Funcionario;
                    var datosFuncionarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                    
                    var datosFuncionarios = ServicioVacaciones.ListarFuncionarios("", Session["CedulaUsuario"].ToString(),"",0,0,0);

                    List<SelectListItem> listaFuncionariosAsociados = datosFuncionarios.Select(item => new SelectListItem { Text = (((CFuncionarioDTO)item).Nombre + " " + ((CFuncionarioDTO)item).PrimerApellido + " " + ((CFuncionarioDTO)item).SegundoApellido), Value = ((CFuncionarioDTO)item).Cedula }).ToList();
                    model.FuncionariosAsociados = new SelectList(listaFuncionariosAsociados, "Value", "Text");

                    if (usuario != null)
                    {
                        if (usuario.Count() >= 3)
                        {
                            List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                            for (int j = 2; j < usuario.Count(); j++)
                            {
                                for (int i = 0; i < usuario.ElementAt(j).Count(); i++)
                                {
                                    if (usuario.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                    {
                                        //Permisos que posee el funcionario logueado
                                        permisos.Add((CCatPermisoDTO)usuario.ElementAt(j).ElementAt(i));
                                    }
                                }
                            }
                            for (int k = 0; k < permisos.Count; k++)
                            {

                                if (datosFuncionarioLogueado[0].GetType() != typeof(CErrorDTO))
                                {
                                    model.Puesto = (CPuestoDTO)datosFuncionarioLogueado[1];
                                }
                                else
                                {
                                    ModelState.AddModelError("BusquedaPeriodo",
                                      ((CErrorDTO)datosFuncionarioLogueado[0]).MensajeError);
                                    throw new Exception("BusquedaFuncionario");
                                }
                                //Si el funcionario tiene permiso de jefatura se obtienen
                                //todos los registros con estado activo(2).
                                if (permisos[k].NomPermiso == "Jefatura")
                                {
                                    model.permiso = "Jefatura";
                                }
                                //Si el funcionario tiene permiso de RH se obtienen todos
                                //los registros con estado Aprobado por Jefatura(3).
                                else if (permisos[k].NomPermiso == "RH")
                                {
                                    model.permiso = "RH";
                                }
                            }
                            //tipo de permiso
                            var datosUsuarioLoggeado = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                            //var datosUsuarioAprobar = perfilUsuario.RetornarPerfilUsuario("MOPT\\" + Session["NombreUsuario"].ToString());
                            var datosCedula = (CFuncionarioDTO)datosUsuarioLoggeado[1][0];

                            //obtener datos seccion y division
                            /*var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(datosCedula.Cedula);
                            var datosSeccion = (CPuestoDTO)datosFuncionario[1];
                            var seccion = datosSeccion.UbicacionAdministrativa.Seccion.NomSeccion;
                            var division = datosSeccion.UbicacionAdministrativa.Division.NomDivision;
                            if (model.permiso != "")
                            {
                                if (model.permiso == "RH")
                                {
                                    model.Secciones = new SelectList(ServicioVacaciones.ListarSecciones()
                                        .Select(U => ((CSeccionDTO)U).NomSeccion));
                                    model.Divisiones = new SelectList(ServicioVacaciones.ListarDivisiones()
                                        .Select(U => ((CDivisionDTO)U).NomDivision));
                                }
                                else if (model.permiso == "Jefatura")
                                {
                                    model.Secciones = new SelectList(
                                        new List<SelectListItem>
                                        {
                                            new SelectListItem {Text = seccion, Value = seccion}
                                        }, "Value", "Text");
                                    model.Divisiones = new SelectList(
                                        new List<SelectListItem>
                                        {
                                            new SelectListItem {Text = division, Value = division}
                                        }, "Value", "Text");
                                }
                            }*/
                            if(accion == "guardar")
                            {
                                model.division = "guardar";
                            }
                            return PartialView("AdministracionSolicitudes", model);
                        }
                        else
                        {
                            if (usuario.Count() == 2)
                            {
                                ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                throw new Exception("Busqueda");
                            }
                            throw new Exception("Busqueda");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                        throw new Exception("Busqueda");
                    }
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        //Según la cedula a buscar se despliegan todos los registros del funcionario con estado pendiente
        [HttpPost]
        public ActionResult AdministracionSolicitudes(FormularioRegistroVacacionesVM model)
        {
            try
            {
                string SubmitButton = "Buscar";
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        var usuarioLogueado = perfilUsuario.CargarPerfilUsuarioCompleto(Session["NombreUsuario"].ToString(), 88, Convert.ToInt32(EModulosHelper.Vacaciones));
                        if (usuarioLogueado[0][0].GetType() == typeof(CErrorDTO))
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                                ((CErrorDTO)usuarioLogueado[0][0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }

                        var cedUsuarioLogueado = (CFuncionarioDTO)usuarioLogueado[0][0];
                        var datosUsuarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedUsuarioLogueado.Cedula);

                        if (cedUsuarioLogueado.Cedula != model.funcionarioSeleccionado)
                        {
                            var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.funcionarioSeleccionado);
                            var datosVacaciones = ServicioVacaciones.ObtenerVacaciones(model.funcionarioSeleccionado).ToList();
                            List<CRegistroVacacionesDTO> datosVacacionesDescarga = new List<CRegistroVacacionesDTO>();
                            CPuestoDTO puesto = new CPuestoDTO();
                            if (datosVacaciones[0].GetType() != typeof(CErrorDTO))
                            {
                                foreach (CRegistroVacacionesDTO item in datosVacaciones)
                                {
                                    if (item.Dias > 0)
                                    {
                                        datosVacacionesDescarga.Add(item);
                                    }
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaRegistrosPendientes",
                                    ((CErrorDTO)datosVacaciones[0]).MensajeError);
                                throw new Exception("BusquedaRegistrosPendientes");
                            }
                            puesto = (CPuestoDTO)datosUsuarioLogueado[1];

                            if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                            {
                                var permisosAprobacionVacacionesTemporal = ServicioVacaciones.ObtenerPermisosAprobacion(cedUsuarioLogueado.Cedula, model.funcionarioSeleccionado);
                                model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                if (puesto.UbicacionAdministrativa.Departamento.IdEntidad == model.Puesto.UbicacionAdministrativa.Departamento.IdEntidad || puesto.UbicacionAdministrativa.Seccion.IdEntidad == model.Puesto.UbicacionAdministrativa.Seccion.IdEntidad ||
                                    puesto.UbicacionAdministrativa.Division.IdEntidad == model.Puesto.UbicacionAdministrativa.Division.IdEntidad || puesto.UbicacionAdministrativa.DireccionGeneral.IdEntidad == model.Puesto.UbicacionAdministrativa.DireccionGeneral.IdEntidad ||
                                    permisosAprobacionVacacionesTemporal.Length > 1)
                                {
                                    model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                                    model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                }
                                else
                                {
                                    ModelState.AddModelError("Busqueda", "No tiene permisos para acceder a los registros de vacaciones del funcionario.");
                                    throw new Exception("Error al cargar el modelo");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaPeriodo",
                                    ((CErrorDTO)datosFuncionario[0]).MensajeError);
                                throw new Exception("BusquedaFuncionario");
                            }
                            if (usuario != null)
                            {
                                var listPermisos = perfilUsuario.ListarPermisosFuncionario(cedUsuarioLogueado.Cedula);
                                if (listPermisos != null)
                                {
                                    if (listPermisos.Count() > 0)
                                    {
                                        List<string> permisos = new List<string>();
                                        foreach (var item in listPermisos)
                                        {
                                            if (!permisos.Contains(((CPerfilAccesoDTO)item).CatPermiso.NomPermiso))
                                            {
                                                permisos.Add(((CPerfilAccesoDTO)item).CatPermiso.NomPermiso);
                                            }
                                        }
                                        foreach (var permiso in permisos)
                                        {
                                            if (permiso == "Jefatura" || permiso == "Global")
                                            {
                                                model.ListaRegistroVacacionesPendientes = datosVacaciones.Select(F => (CRegistroVacacionesDTO)F)
                                                     .Where(F => F.Estado == 2)
                                                     .ToList();
                                            }
                                            //Si el funcionario tiene permiso de RH se obtienen todos
                                            //los registros con estado Aprobado por Jefatura(3).
                                            else if (permiso == "RH")
                                            {
                                                model.ListaRegistroVacacionesPendientes = datosVacaciones.Select(F => (CRegistroVacacionesDTO)F)
                                                    .Where(F => F.Estado == 3)
                                                    .ToList();
                                            }
                                        }
                                    }
                                    return PartialView("_AdministracionSolicitudes", model);

                                }
                                else
                                {
                                    if (usuario.Count() == 2)
                                    {
                                        ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                        throw new Exception("Busqueda");
                                    }
                                    throw new Exception("Busqueda");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                                throw new Exception("Busqueda");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", "No tiene permiso para acceder a sus registros de vacaciones.");
                            throw new Exception("Error al cargar el modelo");
                        }
                    }
                    else
                    {
                        CAccesoWeb.CargarErrorAcceso(Session);
                        return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        [HttpPost]
        public ActionResult ActualizarSolicitud(FormularioRegistroVacacionesVM model, string SubmitButton,
            string Solicitud, string Cedula)
        {
            try
            {
                string funcAprobar = "";
                string Comentario = "";

                var datosUsuarioAprobar = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                //var datosUsuarioAprobar = perfilUsuario.RetornarPerfilUsuario("MOPT\\" + Session["NombreUsuario"].ToString());
                if (SubmitButton != "Aprobar")
                {
                    Comentario = model.RegistroVacaciones.Comentario;
                }
                if (datosUsuarioAprobar != null)
                {
                    if (datosUsuarioAprobar.Count() >= 3)
                    {
                        List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                        for (int j = 2; j < datosUsuarioAprobar.Count(); j++)
                        {
                            for (int i = 0; i < datosUsuarioAprobar.ElementAt(j).Count(); i++)
                            {
                                if (datosUsuarioAprobar.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                    permisos.Add((CCatPermisoDTO)datosUsuarioAprobar.ElementAt(j).ElementAt(i));
                            }
                        }
                        foreach (CCatPermisoDTO p in permisos)
                        {
                            if (p.NomPermiso == "Jefatura" || p.NomPermiso == "Global")
                            {
                                funcAprobar = "Jefatura";
                                break;
                            }
                            else if (p.NomPermiso == "RH")
                            {
                                funcAprobar = "RH";
                            }
                        }
                    }
                }
                if(SubmitButton == "Responder")
                {
                    funcAprobar = "RespuestaFuncionario";
                }
                var resultado = ServicioVacaciones.ActualizarSolicitudVacaciones(Solicitud, SubmitButton, Comentario,
                    Cedula, funcAprobar);
                if (resultado.GetType() != typeof(CErrorDTO))
                {
                    var usuario = perfilUsuario.NombreUsuarioPorCedula(Cedula);
                    if (usuario.GetType() != typeof(CErrorDTO))
                    {
                        /*EmailWebHelper correo = new EmailWebHelper();
                        correo.Destinos = ((CBaseDTO)usuario).Mensaje.Split('\\').Last() + "@mopt.go.cr, deivert.guiltrichs@mopt.go.cr";
                        correo.Asunto = "Registro de vacaciones ";
                        var funcionarioNombre = model.Funcionario.Nombre + " " + model.Funcionario.PrimerApellido + " " + model.Funcionario.SegundoApellido;
                        if(SubmitButton == "Aprobar")
                        { 
                            correo.EmailBody = CorreoAprobacionVacaciones(funcionarioNombre);
                        }
                        if(SubmitButton == "Discusion")
                        {
                            correo.EmailBody = CorreoDiscusion(funcionarioNombre, Comentario);
                        }
                        if (SubmitButton == "Rechazar")
                        {
                            correo.EmailBody = CorreoRechazo(funcionarioNombre, Comentario);
                        }
                        if(SubmitButton == "Responder")
                        {
                            model.Funcionario.Sexo = GeneroEnum.Indefinido;
                            var encargado = servicioCalificacion.BuscarEncargado(model.Funcionario, model.Puesto.UbicacionAdministrativa);
                            if (encargado.ElementAt(0).GetType() != typeof(CErrorDTO))
                            {
                                correo.Destinos = encargado.ElementAt(0).Mensaje;
                                correo.EmailBody = CorreoRespuestaDiscusion(funcionarioNombre, Comentario);
                            }
                        }
                        correo.EnviarCorreo();*/
                    }
                    if(funcAprobar != "RespuestaFuncionario")
                    {
                        return JavaScript("window.location = '/Vacaciones/AdministracionSolicitudes?accion=exito'");
                    }
                    else
                    {
                        return JavaScript("window.location.reload()");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("errorActualizar",
                              ((CErrorDTO)resultado).MensajeError);
                    throw new Exception("BusquedaFuncionario");
                }
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("errorActualizar", e.Message);
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult BuscarPorSeccion(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        model.Funcionario = modelUsuario.Funcionario;
                        var datosFuncionarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        var usuarioLogueado = perfilUsuario.CargarPerfilUsuarioCompleto(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 88);
                        var cedUsuarioLogueado = (CFuncionarioDTO)usuarioLogueado[0][0];
                        var datosUsuarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedUsuarioLogueado.Cedula);


                        CPuestoDTO puesto = new CPuestoDTO();
                        if (datosFuncionarioLogueado[0].GetType() != typeof(CErrorDTO))
                        {
                            model.Puesto = (CPuestoDTO)datosFuncionarioLogueado[1];
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionarioLogueado[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                        //lista de vacaciones por seccion
                        var datosVacaciones = ServicioVacaciones.ObtenerVacacionesPorSeccion(model.seccion)
                            .OrderBy(P => ((CRegistroVacacionesDTO)P).Periodo.Nombramiento.Funcionario.Cedula)
                            .ToList();
                        List<CRegistroVacacionesDTO> datosVacacionesDescarga = new List<CRegistroVacacionesDTO>();
                        if (datosVacaciones.Count == 0)
                        {
                            if (datosVacaciones[0].GetType() != typeof(CErrorDTO))
                            {
                                foreach (CRegistroVacacionesDTO item in datosVacaciones)
                                {
                                    if (item.Dias > 0)
                                    {
                                        //Verifica que el funcionario logueado y el funcionario a buscar sean distintos
                                        if (model.Funcionario.Cedula != item.Periodo.Nombramiento.Funcionario.Cedula)
                                        {
                                            //Verifica si el funcionario tiene nombramiento activo.
                                            var datosFuncionarios = ServicioFuncionario.BuscarFuncionarioDetallePuesto(item.Periodo.Nombramiento.Funcionario.Cedula);
                                            if (datosFuncionarios[0].GetType() != typeof(CErrorDTO))
                                            {
                                                datosVacacionesDescarga.Add(item);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaRegistrosPendientes",
                                    ((CErrorDTO)datosVacaciones[0]).MensajeError);
                                throw new Exception("BusquedaRegistrosPendientes");
                            }
                            if (usuario != null)
                            {
                                if (usuario.Count() >= 3)
                                {
                                    List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                                    for (int j = 2; j < usuario.Count(); j++)
                                    {
                                        for (int i = 0; i < usuario.ElementAt(j).Count(); i++)
                                        {
                                            if (usuario.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                            {
                                                //Permisos que posee el funcionario logueado
                                                permisos.Add((CCatPermisoDTO)usuario.ElementAt(j).ElementAt(i));
                                            }
                                        }
                                    }
                                    for (int k = 0; k < permisos.Count; k++)
                                    {
                                        if (permisos[k].NomPermiso == "Jefatura")
                                        {
                                            model.ListaRegistroVacacionesPendientes = datosVacacionesDescarga.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 2).ToList();
                                        }
                                        //Si el funcionario tiene permiso de RH se obtienen todos
                                        //los registros con estado Aprobado por Jefatura(3).
                                        else if (permisos[k].NomPermiso == "RH")
                                        {
                                            model.ListaRegistroVacacionesPendientes = datosVacacionesDescarga.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 3).ToList();
                                        }
                                    }
                                    return PartialView("_AdministracionSolicitudes", model);
                                }
                                else
                                {
                                    if (usuario.Count() == 2)
                                    {
                                        ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                        throw new Exception("Busqueda");
                                    }
                                    throw new Exception("Busqueda");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                                throw new Exception("Busqueda");
                            }
                        }
                        model.ListaRegistroVacacionesPendientes = datosVacacionesDescarga;
                        return PartialView("_AdministracionSolicitudes", model);
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", "No tiene permiso para acceder a sus registros de vacaciones.");
                        throw new Exception("Error al cargar el modelo");
                    }
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult BuscarPorDivision(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        model.Funcionario = modelUsuario.Funcionario;
                        var datosFuncionarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        var usuarioLogueado = perfilUsuario.CargarPerfilUsuarioCompleto(Session["NombreUsuario"].ToString(),
                            Convert.ToInt32(EModulosHelper.Vacaciones), 88);
                        var cedUsuarioLogueado = (CFuncionarioDTO)usuarioLogueado[0][0];
                        var datosUsuarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedUsuarioLogueado.Cedula);
                        CPuestoDTO puesto = new CPuestoDTO();
                        if (datosFuncionarioLogueado[0].GetType() != typeof(CErrorDTO))
                        {
                            model.Puesto = (CPuestoDTO)datosFuncionarioLogueado[1];
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionarioLogueado[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                        //lista de vacaciones por division
                        var datosVacaciones = ServicioVacaciones.ObtenerVacacionesPorDivision(model.division)
                            .OrderBy(P => ((CRegistroVacacionesDTO)P).Periodo.Nombramiento.Funcionario.Cedula)
                            .ToList();
                        List<CRegistroVacacionesDTO> datosVacacionesDescarga = new List<CRegistroVacacionesDTO>();
                        if (datosVacaciones.Count != 0)
                        {
                            if (datosVacaciones[0].GetType() != typeof(CErrorDTO))
                            {
                                foreach (CRegistroVacacionesDTO item in datosVacaciones)
                                {
                                    if (item.Dias > 0)
                                    {
                                        //Verifica que el funcionario logueado y el funcionario a buscar sean distintos
                                        if (model.Funcionario.Cedula != item.Periodo.Nombramiento.Funcionario.Cedula)
                                        {
                                            //Verifica si el funcionario tiene nombramiento activo.
                                            var datosFuncionarios = ServicioFuncionario.BuscarFuncionarioDetallePuesto(item.Periodo.Nombramiento.Funcionario.Cedula);
                                            if (datosFuncionarios[0].GetType() != typeof(CErrorDTO))
                                            {
                                                datosVacacionesDescarga.Add(item);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaRegistrosPendientes",
                                    ((CErrorDTO)datosVacaciones[0]).MensajeError);
                                throw new Exception("BusquedaRegistrosPendientes");
                            }
                            if (usuario != null)
                            {
                                if (usuario.Count() >= 3)
                                {
                                    List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                                    for (int j = 2; j < usuario.Count(); j++)
                                    {
                                        for (int i = 0; i < usuario.ElementAt(j).Count(); i++)
                                        {
                                            if (usuario.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                            {
                                                //Permisos que posee el funcionario logueado
                                                permisos.Add((CCatPermisoDTO)usuario.ElementAt(j).ElementAt(i));
                                            }
                                        }
                                    }
                                    for (int k = 0; k < permisos.Count; k++)
                                    {
                                        if (permisos[k].NomPermiso == "Jefatura")
                                        {
                                            model.ListaRegistroVacacionesPendientes = datosVacacionesDescarga.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 2).ToList();
                                        }
                                        //Si el funcionario tiene permiso de RH se obtienen todos
                                        //los registros con estado Aprobado por Jefatura(3).
                                        else if (permisos[k].NomPermiso == "RH")
                                        {
                                            model.ListaRegistroVacacionesPendientes = datosVacacionesDescarga.Select(F => (CRegistroVacacionesDTO)F).Where(F => F.Estado == 3).ToList();
                                        }
                                    }
                                    return PartialView("_AdministracionSolicitudes", model);
                                }
                                else
                                {
                                    if (usuario.Count() == 2)
                                    {
                                        ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                        throw new Exception("Busqueda");
                                    }
                                    throw new Exception("Busqueda");
                                }
                            }
                            model.ListaRegistroVacacionesPendientes = datosVacacionesDescarga;
                            return PartialView("_AdministracionSolicitudes", model);
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                            throw new Exception("Busqueda");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", "No tiene permiso para acceder a sus registros de vacaciones.");
                        throw new Exception("Error al cargar el modelo");
                    }
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult AdministracionReintegros()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);
            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                {
                    PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                    modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                    FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();
                    model.Funcionario = modelUsuario.Funcionario;
                    var datosFuncionarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                    if (usuario != null)
                    {
                        if (usuario.Count() >= 3)
                        {
                            List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                            for (int j = 2; j < usuario.Count(); j++)
                            {
                                for (int i = 0; i < usuario.ElementAt(j).Count(); i++)
                                {
                                    if (usuario.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                    {
                                        //Permisos que posee el funcionario logueado
                                        permisos.Add((CCatPermisoDTO)usuario.ElementAt(j).ElementAt(i));
                                    }
                                }
                            }
                            for (int k = 0; k < permisos.Count; k++)
                            {

                                if (datosFuncionarioLogueado[0].GetType() != typeof(CErrorDTO))
                                {
                                    model.Puesto = (CPuestoDTO)datosFuncionarioLogueado[1];
                                }
                                else
                                {
                                    ModelState.AddModelError("BusquedaPeriodo",
                                      ((CErrorDTO)datosFuncionarioLogueado[0]).MensajeError);
                                    throw new Exception("BusquedaFuncionario");
                                }
                                //Si el funcionario tiene permiso de jefatura se obtienen
                                //todos los registros con estado activo(2).
                                if (permisos[k].NomPermiso == "Jefatura")
                                {
                                    model.permiso = "Jefatura";
                                }
                                //Si el funcionario tiene permiso de RH se obtienen todos
                                //los registros con estado Aprobado por Jefatura(3).
                                else if (permisos[k].NomPermiso == "RH")
                                {
                                    model.permiso = "RH";
                                }
                            }
                            //tipo de permiso
                            var datosUsuarioLoggeado = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                            //var datosUsuarioAprobar = perfilUsuario.RetornarPerfilUsuario("MOPT\\" + Session["NombreUsuario"].ToString());
                            var datosCedula = (CFuncionarioDTO)datosUsuarioLoggeado[1][0];
                            //obtener datos seccion y division
                            var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(datosCedula.Cedula);
                            var datosSeccion = (CPuestoDTO)datosFuncionario[1];
                            var seccion = datosSeccion.UbicacionAdministrativa.Seccion.NomSeccion;
                            var division = datosSeccion.UbicacionAdministrativa.Division.NomDivision;
                            //if (model.permiso != "")
                            //{
                            //    if (model.permiso == "RH")
                            //    {
                            //        model.Secciones = new SelectList(ServicioVacaciones.ListarSecciones()
                            //            .Select(U => ((CSeccionDTO)U).NomSeccion));
                            //        model.Divisiones = new SelectList(ServicioVacaciones.ListarDivisiones()
                            //            .Select(U => ((CDivisionDTO)U).NomDivision));
                            //    }
                            //    else if (model.permiso == "Jefatura")
                            //    {
                            //        model.Secciones = new SelectList(
                            //            new List<SelectListItem>
                            //            {
                            //                new SelectListItem {Text = seccion, Value = seccion}
                            //            }, "Value", "Text");
                            //        model.Divisiones = new SelectList(
                            //            new List<SelectListItem>
                            //            {
                            //                new SelectListItem {Text = division, Value = division}
                            //            }, "Value", "Text");
                            //    }
                            //}
                            var anio = DateTime.Now.Year;
                            var datosFuncionarios = servicioCalificacion.ListarFuncionariosJefatura(anio, Session["CedulaUsuario"].ToString());

                            List<SelectListItem> listaFuncionariosAsociados = datosFuncionarios.Select(item => new SelectListItem { Text = (((CFuncionarioDTO)item).Nombre + " " + ((CFuncionarioDTO)item).PrimerApellido + " " + ((CFuncionarioDTO)item).SegundoApellido), Value = ((CFuncionarioDTO)item).Cedula }).ToList();
                            model.FuncionariosAsociados = new SelectList(listaFuncionariosAsociados, "Value", "Text");

                            return PartialView("AdministracionReintegros", model);
                        }
                        else
                        {
                            if (usuario.Count() == 2)
                            {
                                ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                throw new Exception("Busqueda");
                            }
                            throw new Exception("Busqueda");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                        throw new Exception("Busqueda");
                    }
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult AdministracionReintegros(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        var usuarioLogueado = perfilUsuario.CargarPerfilUsuarioCompleto(Session["NombreUsuario"].ToString(), 88, Convert.ToInt32(EModulosHelper.Vacaciones));
                        if (usuarioLogueado[0][0].GetType() == typeof(CErrorDTO))
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                                ((CErrorDTO)usuarioLogueado[0][0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                        var cedUsuarioLogueado = (CFuncionarioDTO)usuarioLogueado[0][0];
                        var datosUsuarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedUsuarioLogueado.Cedula);
                        if (cedUsuarioLogueado.Cedula != model.funcionarioSeleccionado)
                        {
                            var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.funcionarioSeleccionado);
                            var datosReintegros = ServicioVacaciones.ObtenerReintegros(model.funcionarioSeleccionado).ToList();
                            CPuestoDTO puesto = new CPuestoDTO();
                            puesto = (CPuestoDTO)datosUsuarioLogueado[1];
                            if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                            {
                                model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                if (puesto.UbicacionAdministrativa.Departamento.IdEntidad == model.Puesto.UbicacionAdministrativa.Departamento.IdEntidad ||
                                    puesto.UbicacionAdministrativa.Seccion.IdEntidad == model.Puesto.UbicacionAdministrativa.Seccion.IdEntidad ||
                                    puesto.UbicacionAdministrativa.Division.IdEntidad == model.Puesto.UbicacionAdministrativa.Division.IdEntidad ||
                                    puesto.UbicacionAdministrativa.DireccionGeneral.IdEntidad == model.Puesto.UbicacionAdministrativa.DireccionGeneral.IdEntidad)
                                {
                                    model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                                    model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                }
                                else
                                {
                                    ModelState.AddModelError("Busqueda", "No tiene permisos para acceder a los reintegros de vacaciones del funcionario.");
                                    throw new Exception("Error al cargar el modelo");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaPeriodo",
                                    ((CErrorDTO)datosFuncionario[0]).MensajeError);
                                throw new Exception("BusquedaFuncionario");
                            }
                            if (usuario != null)
                            {
                                var listPermisos = perfilUsuario.ListarPermisosFuncionario(cedUsuarioLogueado.Cedula);
                                if (listPermisos != null)
                                {
                                    if (listPermisos.Count() > 0)
                                    {
                                        List<string> permisos = new List<string>();
                                        foreach (var item in listPermisos)
                                        {
                                            if (!permisos.Contains(((CPerfilAccesoDTO)item).CatPermiso.NomPermiso))
                                            {
                                                permisos.Add(((CPerfilAccesoDTO)item).CatPermiso.NomPermiso);
                                            }
                                        }
                                        foreach (var permiso in permisos)
                                        {
                                            if (permiso == "Jefatura" || permiso == "Global")
                                            {
                                                if (datosReintegros[0].GetType() != typeof(CErrorDTO))
                                                {
                                                    model.ListaReintegroVacacionesPendientes = datosReintegros.Select(F => (CReintegroVacacionesDTO)F)
                                                        .Where(F => F.Estado == 2)
                                                        .ToList();
                                                }
                                            }
                                            //Si el funcionario tiene permiso de RH se obtienen todos
                                            //los registros con estado Aprobado por Jefatura(3).
                                            else if (permiso == "RH")
                                            {
                                                if (datosReintegros[0].GetType() != typeof(CErrorDTO))
                                                {
                                                    model.ListaReintegroVacacionesPendientes = datosReintegros.Select(F => (CReintegroVacacionesDTO)F)
                                                        .Where(F => F.Estado == 3)
                                                        .ToList();
                                                }
                                            }
                                        }
                                    }
                                    return PartialView("_AdministracionReintegros", model);
                                }
                                else
                                {
                                    if (usuario.Count() == 2)
                                    {
                                        ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                        throw new Exception("Busqueda");
                                    }
                                    throw new Exception("Busqueda");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                                throw new Exception("Busqueda");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", "No tiene permiso para acceder a sus reintegros de vacaciones.");
                            throw new Exception("Error al cargar el modelo");
                        }
                    }
                    else
                    {
                        CAccesoWeb.CargarErrorAcceso(Session);
                        return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
        public ActionResult BuscarReintegrosPorSeccion(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        model.Funcionario = modelUsuario.Funcionario;
                        var datosFuncionarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        var usuarioLogueado = perfilUsuario.CargarPerfilUsuarioCompleto(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 88);
                        var cedUsuarioLogueado = (CFuncionarioDTO)usuarioLogueado[0][0];
                        var datosUsuarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedUsuarioLogueado.Cedula);
                        CPuestoDTO puesto = new CPuestoDTO();
                        if (datosFuncionarioLogueado[0].GetType() != typeof(CErrorDTO))
                        {
                            model.Puesto = (CPuestoDTO)datosFuncionarioLogueado[1];
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionarioLogueado[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                        //lista de Reintegros por Seccion
                        var datosReintegros = ServicioVacaciones.ObtenerReintegrosPorSeccion(model.seccion)
                            .OrderBy(P => ((CReintegroVacacionesDTO)P).RegistroVacaciones.Periodo.Nombramiento.Funcionario.Cedula)
                            .ToList();
                        List<CReintegroVacacionesDTO> datosReintegrosDescarga = new List<CReintegroVacacionesDTO>();
                        if (datosReintegros.Count != 0)
                        {
                            if (datosReintegros[0].GetType() != typeof(CErrorDTO))
                            {
                                foreach (CReintegroVacacionesDTO item in datosReintegros)
                                {
                                    if (item.CantidadDias > 0)
                                    {
                                        //Verifica que el funcionario logueado y el funcionario a buscar sean distintos
                                        if (model.Funcionario.Cedula != item.RegistroVacaciones.Periodo.Nombramiento.Funcionario.Cedula)
                                        {
                                            //Verifica si el funcionario tiene nombramiento activo.
                                            var datosFuncionarios = ServicioFuncionario.BuscarFuncionarioDetallePuesto(item.RegistroVacaciones.Periodo.Nombramiento.Funcionario.Cedula);
                                            if (datosFuncionarios[0].GetType() != typeof(CErrorDTO))
                                            {
                                                datosReintegrosDescarga.Add(item);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaRegistrosPendientes",
                                    ((CErrorDTO)datosReintegros[0]).MensajeError);
                                throw new Exception("BusquedaRegistrosPendientes");
                            }
                            if (usuario != null)
                            {
                                if (usuario.Count() >= 3)
                                {
                                    List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                                    for (int j = 2; j < usuario.Count(); j++)
                                    {
                                        for (int i = 0; i < usuario.ElementAt(j).Count(); i++)
                                        {
                                            if (usuario.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                            {
                                                //Permisos que posee el funcionario logueado
                                                permisos.Add((CCatPermisoDTO)usuario.ElementAt(j).ElementAt(i));
                                            }
                                        }
                                    }
                                    for (int k = 0; k < permisos.Count; k++)
                                    {
                                        if (permisos[k].NomPermiso == "Jefatura")
                                        {
                                            model.ListaReintegroVacacionesPendientes = datosReintegrosDescarga.Select(F => (CReintegroVacacionesDTO)F)
                                                .Where(F => F.Estado == 2)
                                                .ToList();
                                        }
                                        //Si el funcionario tiene permiso de RH se obtienen todos
                                        //los registros con estado Aprobado por Jefatura(3).
                                        else if (permisos[k].NomPermiso == "RH")
                                        {
                                            model.ListaReintegroVacacionesPendientes = datosReintegrosDescarga.Select(F => (CReintegroVacacionesDTO)F)
                                                .Where(F => F.Estado == 3)
                                                .ToList();
                                        }
                                    }
                                    return PartialView("_AdministracionSolicitudes", model);
                                }
                                else
                                {
                                    if (usuario.Count() == 2)
                                    {
                                        ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                        throw new Exception("Busqueda");
                                    }
                                    throw new Exception("Busqueda");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                                throw new Exception("Busqueda");
                            }
                        }
                        model.ListaReintegroVacacionesPendientes = datosReintegrosDescarga;
                        return PartialView("_AdministracionSolicitudes", model);
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", "No tiene permiso para acceder a sus registros de Reintegros.");
                        throw new Exception("Error al cargar el modelo");
                    }
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorReintegros");
            }
        }
        public ActionResult BuscarReintegrosPorDivision(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        modelUsuario.Usuario = (CUsuarioDTO)usuario.ElementAt(0).ElementAt(0);
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        model.Funcionario = modelUsuario.Funcionario;
                        var datosFuncionarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        var usuarioLogueado = perfilUsuario.CargarPerfilUsuarioCompleto(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 88);
                        var cedUsuarioLogueado = (CFuncionarioDTO)usuarioLogueado[0][0];
                        var datosUsuarioLogueado = ServicioFuncionario.BuscarFuncionarioDetallePuesto(cedUsuarioLogueado.Cedula);
                        CPuestoDTO puesto = new CPuestoDTO();
                        if (datosFuncionarioLogueado[0].GetType() != typeof(CErrorDTO))
                        {
                            model.Puesto = (CPuestoDTO)datosFuncionarioLogueado[1];
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionarioLogueado[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                        //lista de Reintegros por division
                        var datosReintegros = ServicioVacaciones.ObtenerReintegrosPorDivision(model.division)
                            .OrderBy(P => ((CReintegroVacacionesDTO)P).RegistroVacaciones.Periodo.Nombramiento.Funcionario.Cedula)
                            .ToList();
                        List<CReintegroVacacionesDTO> datosReintegrosDescarga = new List<CReintegroVacacionesDTO>();
                        if (datosReintegros.Count != 0)
                        {
                            if (datosReintegros[0].GetType() != typeof(CErrorDTO))
                            {
                                foreach (CReintegroVacacionesDTO item in datosReintegros)
                                {
                                    if (item.CantidadDias > 0)
                                    {
                                        //Verifica que el funcionario logueado y el funcionario a buscar sean distintos
                                        if (model.Funcionario.Cedula != item.RegistroVacaciones.Periodo.Nombramiento.Funcionario.Cedula)
                                        {
                                            //Verifica si el funcionario tiene nombramiento activo.
                                            var datosFuncionarios = ServicioFuncionario.BuscarFuncionarioDetallePuesto(item.RegistroVacaciones.Periodo.Nombramiento.Funcionario.Cedula);
                                            if (datosFuncionarios[0].GetType() != typeof(CErrorDTO))
                                            {
                                                datosReintegrosDescarga.Add(item);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("BusquedaRegistrosPendientes",
                                    ((CErrorDTO)datosReintegros[0]).MensajeError);
                                throw new Exception("BusquedaRegistrosPendientes");
                            }
                            if (usuario != null)
                            {
                                if (usuario.Count() >= 3)
                                {
                                    List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                                    for (int j = 2; j < usuario.Count(); j++)
                                    {
                                        for (int i = 0; i < usuario.ElementAt(j).Count(); i++)
                                        {
                                            if (usuario.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                            {
                                                //Permisos que posee el funcionario logueado
                                                permisos.Add((CCatPermisoDTO)usuario.ElementAt(j).ElementAt(i));
                                            }
                                        }
                                    }
                                    for (int k = 0; k < permisos.Count; k++)
                                    {
                                        if (permisos[k].NomPermiso == "Jefatura")
                                        {
                                            model.ListaReintegroVacacionesPendientes = datosReintegrosDescarga.Select(F => (CReintegroVacacionesDTO)F)
                                                .Where(F => F.Estado == 2)
                                                .ToList();
                                        }
                                        //Si el funcionario tiene permiso de RH se obtienen todos
                                        //los registros con estado Aprobado por Jefatura(3).
                                        else if (permisos[k].NomPermiso == "RH")
                                        {
                                            model.ListaReintegroVacacionesPendientes = datosReintegrosDescarga.Select(F => (CReintegroVacacionesDTO)F)
                                                .Where(F => F.Estado == 3)
                                                .ToList();
                                        }
                                    }
                                    return PartialView("_AdministracionSolicitudes", model);
                                }
                                else
                                {
                                    if (usuario.Count() == 2)
                                    {
                                        ModelState.AddModelError("Busqueda", "El usuario está registrado en el sistema, pero no se le ha asignado ningún perfil para el uso del mismo");
                                        throw new Exception("Busqueda");
                                    }
                                    throw new Exception("Busqueda");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", ((CErrorDTO)usuario.ElementAt(0).ElementAt(0)).MensajeError);
                                throw new Exception("Busqueda");
                            }
                        }
                        model.ListaReintegroVacacionesPendientes = datosReintegrosDescarga;
                        return PartialView("_AdministracionSolicitudes", model);
                    }
                    else
                    {
                        ModelState.AddModelError("Busqueda", "No tiene permiso para acceder a sus registros de Reintegros.");
                        throw new Exception("Error al cargar el modelo");
                    }
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorReintegros");
            }
        }
        public ActionResult MisReintegros()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);
                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
                else
                {
                    if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                        Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                        Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Operativo))] != null)
                    {
                        PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                        var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                        modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                        FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();
                        model.Funcionario = modelUsuario.Funcionario;
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                        model.Puesto = (CPuestoDTO)datosFuncionario[1];
                        model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                        var datosReintegros = ServicioVacaciones.ObtenerReintegros(model.Funcionario.Cedula);
                        if(datosReintegros.Count() > 0)
                        {
                            if (datosReintegros.FirstOrDefault().GetType() != typeof(CErrorDTO))
                            {
                                model.ListaReintegroVacaciones = datosReintegros.Select(F => (CReintegroVacacionesDTO)F).ToList();
                                model.ListaReintegroVacacionesAprobadas = datosReintegros.Select(F => (CReintegroVacacionesDTO)F).Where(F => F.Estado == 1).ToList();
                                model.ListaReintegroVacacionesPendientes = datosReintegros.Select(F => (CReintegroVacacionesDTO)F).Where(F => F.Estado == 2 || F.Estado == 3).ToList();
                                model.ListaReintegroVacacionesRechazadas = datosReintegros.Select(F => (CReintegroVacacionesDTO)F).Where(F => F.Estado == 4 || F.Estado == 5 || F.Estado == 6).ToList();
                                model.ListaReintegroVacacionesAnuladas = datosReintegros.Select(F => (CReintegroVacacionesDTO)F).Where(F => F.Estado == 7).ToList();
                            }
                        }

                        var datosJefatura = ServicioVacaciones.ListarJefatura(model.Funcionario.Cedula);

                        if (datosJefatura.GetType() != typeof(CErrorDTO))
                            model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }

                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            return PartialView("MisReintegros", model);
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                    }
                    else
                    {
                        CAccesoWeb.CargarErrorAcceso(Session);
                        return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                    }
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
        }
        [HttpPost]
        public ActionResult ActualizarReintegro(FormularioRegistroVacacionesVM model, string SubmitButton,
            string Solicitud, string Cedula)
        {
            try
            {
                string funcAprobar = "";
                string Comentario = "";
                var datosUsuarioAprobar = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                //var datosUsuarioAprobar = perfilUsuario.RetornarPerfilUsuario("MOPT\\" + Session["NombreUsuario"].ToString());
                if (SubmitButton != "Aprobar")
                {
                    Comentario = model.ReintegroVacaciones.Comentario;
                }
                if (datosUsuarioAprobar != null)
                {
                    if (datosUsuarioAprobar.Count() >= 3)
                    {
                        List<CCatPermisoDTO> permisos = new List<CCatPermisoDTO>();
                        for (int j = 2; j < datosUsuarioAprobar.Count(); j++)
                        {
                            for (int i = 0; i < datosUsuarioAprobar.ElementAt(j).Count(); i++)
                            {
                                if (datosUsuarioAprobar.ElementAt(j).ElementAt(i).GetType() == typeof(CCatPermisoDTO))
                                    permisos.Add((CCatPermisoDTO)datosUsuarioAprobar.ElementAt(j).ElementAt(i));
                            }
                        }
                        foreach (CCatPermisoDTO p in permisos)
                        {
                            if (p.NomPermiso == "Jefatura" || p.NomPermiso == "Global")
                            {
                                funcAprobar = "Jefatura";
                            }
                            else if (p.NomPermiso == "RH")
                            {
                                funcAprobar = "RH";
                            }
                        }
                    }
                }
                if (SubmitButton == "Responder")
                {
                    funcAprobar = "RespuestaFuncionario";
                }
                var resultado = ServicioVacaciones.ActualizarReintegros(Solicitud, SubmitButton, Comentario,
                    Cedula, funcAprobar);
                if (resultado.GetType() != typeof(CErrorDTO))
                {
                    var usuario = perfilUsuario.NombreUsuarioPorCedula(Cedula);
                    if (usuario.GetType() != typeof(CErrorDTO))
                    {
                        /*EmailWebHelper correo = new EmailWebHelper();
                        correo.Destinos = ((CBaseDTO)usuario).Mensaje.Split('\\').Last() + "@mopt.go.cr, deivert.guiltrichs@mopt.go.cr";
                        correo.Asunto = "Registro de vacaciones ";
                        var funcionarioNombre = model.Funcionario.Nombre + " " + model.Funcionario.PrimerApellido + " " + model.Funcionario.SegundoApellido;
                        if (SubmitButton == "Aprobar")
                        {
                            correo.EmailBody = CorreoAprobacionReintegros(funcionarioNombre);
                        }
                        if (SubmitButton == "Discusion")
                        {
                            correo.EmailBody = CorreoDiscusionReintegro(funcionarioNombre, Comentario);
                        }
                        if (SubmitButton == "Rechazar")
                        {
                            correo.EmailBody = CorreoRechazoReintegro(funcionarioNombre, Comentario);
                        }
                        if (SubmitButton == "Responder")
                        {
                            model.Funcionario.Sexo = GeneroEnum.Indefinido;
                            var encargado = servicioCalificacion.BuscarEncargado(model.Funcionario, model.Puesto.UbicacionAdministrativa);
                            if (encargado.ElementAt(0).GetType() != typeof(CErrorDTO))
                            {
                                correo.Destinos = encargado.ElementAt(0).Mensaje;
                                correo.EmailBody = CorreoRespuestaDiscusionReintegro(funcionarioNombre, Comentario);
                            }
                        }
                        correo.EnviarCorreo();*/
                    }
                    if(funcAprobar != "RespuestaFuncionario")
                    {
                        return JavaScript("window.location = '/Vacaciones/AdministracionReintegros'");
                    }
                    else
                    {
                        return JavaScript("window.location.reload()");
                    }
                }
                else
                {
                    ModelState.AddModelError("errorActualizar",
                              ((CErrorDTO)resultado).MensajeError);
                    throw new Exception("BusquedaFuncionario");
                }
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("errorActualizar", e.Message);
                return PartialView("_ErrorVacaciones");
            }
        }

        [HttpPost]
        public ActionResult GetDiasFeriado()
        {
            List<CCatalogoDiaDTO> listado = new List<CCatalogoDiaDTO>();
            try
            {
                var respuesta = ServicioVacaciones.ListarDiasPorTipo(1, "");
                foreach (var dia in respuesta)
                {
                    listado.Add((CCatalogoDiaDTO)dia);
                }

                return Json(new
                {
                    success = true,
                    listado = listado
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { success = false, mensaje = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        

        public ActionResult ListFuncionario()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                  Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                  Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Administrador))] != null)
                {
                    context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), Convert.ToInt32(EAccionesBitacora.Login), 0,
                       CAccesoWeb.ListarEntidades(typeof(CVacacionesJefaturaDTO).Name));

                    return View();
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }

        [HttpPost]
        public ActionResult ListFuncionario(FormularioPeriodoVacacionesVM modelo, string cedula, string cedulaJefe,
                                 string coddivision, string coddireccion, string coddepartamento, string codseccion, int? page, string codperiodo)
        {
            Session["errorF"] = null;
            try
            {
                //FuncionarioModel modelo = new FuncionarioModel();
                int paginaActual = page.HasValue ? page.Value : 1;


                if (String.IsNullOrEmpty(cedula) && String.IsNullOrEmpty(cedulaJefe) && String.IsNullOrEmpty(coddivision) &&
                    String.IsNullOrEmpty(coddireccion) && String.IsNullOrEmpty(coddepartamento) && String.IsNullOrEmpty(codseccion))
                {
                    page = 1;
                    return View();
                }
                else
                {
                    if (cedula == null)
                    {
                        cedula = "";
                    }

                    string[] division = coddivision != "" ? coddivision.Split('-') : new string[] { "0" };
                    string[] direccion = coddireccion != "" ? coddireccion.Split('-') : new string[] { "0" };
                    string[] departamento = coddepartamento != "" ? coddepartamento.Split('-') : new string[] { "0" };
                    string[] seccion = codseccion != "" ? codseccion.Split('-') : new string[] { "0" };

                    var datos = ServicioVacaciones.ListarFuncionarios(cedula, cedulaJefe, "", Convert.ToInt32(seccion[0]), Convert.ToInt32(direccion[0]), Convert.ToInt32(division[0]));

                    modelo.ListaFuncionarios = new List<CVacacionesJefaturaDTO>();
                    foreach (var item in datos)
                    {
                        modelo.ListaFuncionarios.Add((CVacacionesJefaturaDTO)item);
                    }

                    //modelo.TotalFuncionarios = funcionarios.Count();
                    //modelo.TotalPaginas = (int)Math.Ceiling((double)modelo.TotalFuncionarios / 10);
                    //modelo.PaginaActual = paginaActual;
                    //Session["funcionarios"] = funcionarios.ToList();
                    //if ((((paginaActual - 1) * 10) + 10) > modelo.TotalFuncionarios)
                    //{
                    //    modelo.Funcionario = funcionarios.ToList().GetRange(((paginaActual - 1) * 10), (modelo.TotalFuncionarios) - (((paginaActual - 1) * 10))).ToList(); ;
                    //}
                    //else
                    //{
                    //    modelo.Funcionario = funcionarios.ToList().GetRange(((paginaActual - 1) * 10), 10).ToList(); ;
                    //}


                    return PartialView("_ListFuncionario", modelo);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de realizar la búsqueda, ponerse en contacto con el personal autorizado. \n\n" + error.ToString());
                return PartialView("_ErrorFuncionario");
            }
        }

        [HttpPost]
        public ActionResult AsignarJefatura(int idFuncionario, int idJefatura)
        {
            try
            {
                var respuesta = ServicioVacaciones.AsignarJefatura(idFuncionario, idJefatura);
                if (respuesta.GetType() != typeof(CErrorDTO))
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { success = false, idEntidad = "0", mensaje = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult Jefatura_Index(string cedula, string nombre, string apellido1, string apellido2, int? page)
        {
            Session["errorU"] = null;
            try
            {
                FuncionarioModel modelo = new FuncionarioModel();
                int periodo = DateTime.Now.AddYears(-1).Year;

                int paginaActual = page.HasValue ? page.Value : 1;

                if (String.IsNullOrEmpty(cedula) && String.IsNullOrEmpty(nombre) && String.IsNullOrEmpty(apellido1) && String.IsNullOrEmpty(apellido2))
                {
                    return PartialView();
                }
                else
                {
                    modelo.CedulaSearch = cedula;
                    modelo.NombreSearch = nombre;
                    modelo.PrimerApellidoSearch = apellido1;
                    modelo.SegundoApellidoSearch = apellido2;

                    List<CFuncionarioDTO> lista = new List<CFuncionarioDTO>();

                    //modelo.Grupo = periodo.ToString();
                    //modelo.PrimerApellidoSearch = idFuncionario;

                    //var datos = servicioCalificacion.ListarJefaturas(periodo);

                    //foreach (var item in datos.ToList())
                    //{
                    //    var func = ((CCalificacionNombramientoFuncionarioDTO)item).Funcionario;

                    //    if (cedulaJefe != "" && func.Cedula.Equals(cedulaJefe))
                    //    {
                    //        lista.Add(func);
                    //    }
                    //    else
                    //    {
                    //        if (nomJefe != null && func.Nombre.ToUpper().Contains(nomJefe.ToUpper()))
                    //        {
                    //            lista.Add(func);
                    //        }
                    //    }
                    //}

                    var datos = ServicioFuncionario.BuscarFuncionarioParam(cedula, nombre, apellido1, apellido2);
                    foreach (var item in datos.ToList())
                    {
                        item.Nombre = item.Nombre.TrimEnd() + " " + item.PrimerApellido.TrimEnd() + " " + item.SegundoApellido.TrimEnd();
                        lista.Add(item);
                    }

                    modelo.TotalFuncionarios = lista.Count();
                    modelo.TotalPaginas = (int)Math.Ceiling((double)modelo.TotalFuncionarios / 10);
                    modelo.PaginaActual = paginaActual;
                    if ((((paginaActual - 1) * 10) + 10) > modelo.TotalFuncionarios)
                    {
                        modelo.Funcionario = lista.ToList().GetRange(((paginaActual - 1) * 10), (modelo.TotalFuncionarios) - (((paginaActual - 1) * 10))).ToList(); ;
                    }
                    else
                    {
                        modelo.Funcionario = lista.ToList().GetRange(((paginaActual - 1) * 10), 10).ToList(); ;
                    }

                    return PartialView("Jefatura_Index_Result", modelo);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de realizar la búsqueda, ponerse en contacto con el personal autorizado. \n\n");
                return PartialView("_ErrorJefatura");
            }
        }


        public ActionResult RegistrarVacacionesAdministrativo()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.SolicitarTemporal))] != null)
                {
                    FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();

                    var listadoJefaturaSuperior = new List<SelectListItem>();
                    var listadoFuncionarios = new List<SelectListItem>();

                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    model.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);

                    var datosJefatura = ServicioVacaciones.ListarFuncionarios(model.Funcionario.Cedula, "", "", 0, 0, 0);

                    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura.ElementAt(0);

                    if(model.Jefatura.JefeSuperior.Cedula != "")
                    {
                        listadoJefaturaSuperior = ServicioVacaciones.ListarFuncionarios("", model.Jefatura.JefeSuperior.Cedula, "", 0, 0, 0)
                                            .Select(Q => new SelectListItem
                                            {
                                                Value = ((CVacacionesJefaturaDTO)Q).Funcionario.Cedula,
                                                Text = ((CVacacionesJefaturaDTO)Q).Funcionario.Mensaje //Nombre + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.PrimerApellido + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.SegundoApellido
                                            }).ToList();

                        listadoFuncionarios = listadoJefaturaSuperior;

                        foreach (var item in listadoJefaturaSuperior.ToList())
                        {
                            var datos = ServicioVacaciones.ListarFuncionarios("", item.Value, "", 0, 0, 0)
                                                 .Select(Q => new SelectListItem
                                                 {
                                                     Value = ((CVacacionesJefaturaDTO)Q).Funcionario.Cedula,
                                                     Text = ((CVacacionesJefaturaDTO)Q).Funcionario.Mensaje //Nombre + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.PrimerApellido + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.SegundoApellido
                                            }).ToList();

                            listadoFuncionarios.AddRange(datos);
                        }

                        listadoFuncionarios.Add(new SelectListItem { Value = model.Jefatura.JefeSuperior.Cedula, Text = model.Jefatura.JefeSuperior.Mensaje });
                    }
                                        
                    model.FuncionariosAsociados = new SelectList(listadoFuncionarios.OrderBy(Q => Q.Text), "Value", "Text");

                    return View(model);
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult RegistrarVacacionesAdministrativo(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.funcionarioSeleccionado);

                        var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.funcionarioSeleccionado).OrderBy(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();

                        /*//////////////////////// NUEVO //////////////////////////////////////////////*/

                        //var datosJefatura = ServicioVacaciones.ListarJefatura(model.funcionarioSeleccionado);
                        //if (datosJefatura.GetType() != typeof(CErrorDTO))
                        //    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                        //else
                        //{
                        //    ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                        //    throw new Exception("BusquedaFuncionario");
                        //}

                        var periodosActuales = new List<string>();

                        List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();
                        if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                            {
                                if (item.Saldo > 0)
                                {
                                    datosDescarga.Add(item);
                                }
                            }
                        }
                        if (datosDescarga.Count < 1)
                        {
                            datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
                        }
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            ViewBag.DiasTotales = 0;
                            if (datosDescarga[0].IdEntidad > -1)
                            {
                                model.PeriodoVacaciones = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault());
                                model.UltimoPeriodo = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault()).Periodo;
                                model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                                if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                                {
                                    foreach (var item in periodosActivos)
                                    {
                                        periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                                    }
                                }
                                if (periodosActivos[0].GetType() != typeof(CErrorDTO))
                                {
                                    model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).Where(F => F.Saldo > 0).ToList();
                                    ViewBag.DiasTotales = model.PeriodosActivos.Sum(Q => Q.Saldo);
                                }
                                model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];

                                List<string> estadosTipoVacaciones = new List<string>();
                                estadosTipoVacaciones.Add("Vacaciones");
                                estadosTipoVacaciones.Add("Permiso con goce de salario");
                                model.tipoDocumento = new SelectList(estadosTipoVacaciones);
                                return PartialView("_FormularioVacaciones", model);
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                                throw new Exception("Error al cargar el modelo");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }
                else if (SubmitButton == "Guardar")
                {
                    String tipoUsuario;
                    PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                    if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Administrador))] != null)
                    {
                        tipoUsuario = "RH";
                    }
                    else
                    {
                        tipoUsuario = "Funcionario";
                    }
                    tipoUsuario = "RH";
                    var solicitadoPor = int.Parse(modelUsuario.Funcionario.Cedula);
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                    if (ModelState.IsValid && model.PeriodosActivos != null && model.tipoDocumentoSeleccion != null)
                    {
                        var vacaciones = 0;
                        if (model.tipoDocumentoSeleccion == "Vacaciones")
                        {
                            vacaciones = 1;
                        }
                        else if (model.tipoDocumentoSeleccion == "Permiso sin goce de salario")
                        {
                            vacaciones = 6;
                        }
                        var medioDia = 0;
                        if (model.MedioDia == "Mañana")
                        {
                            medioDia = 1;
                        }
                        else if (model.MedioDia == "Tarde")
                        {
                            medioDia = 2;

                        }
                        model.RegistroVacaciones.SolicitadoPor = solicitadoPor;

                        model.RegistroVacaciones.Bitacora = new CBitacoraDTO { Usuario = Session["CedulaUsuario"].ToString() };

                        var guardarDatos = ServicioVacaciones.GuardarRegistroVacacionesNuevo(model.RegistroVacaciones, model.Funcionario.Cedula, model.PeriodosActivos.First().Periodo, vacaciones, medioDia, tipoUsuario);

                        if (((CRespuestaDTO)guardarDatos).Codigo > 0)
                        {
                            return Content("<div class='alert alert-success'>Cambios guardados correctamente</div>");

                            //return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                            //                                                  model.Funcionario.Cedula + "&CodPeriodo=" +
                            //                                                   model.PeriodosActivos.First().Periodo + "&Codigo=" + ((CRespuestaDTO)guardarDatos).Codigo + "&detalle=4'");
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo", ((CRespuestaDTO)guardarDatos).Mensaje);
                            throw new Exception("Guardar");
                        }
                    }
                    else
                    {
                        if (model.PeriodosActivos == null)
                        {
                            ModelState.AddModelError("Busqueda", "El periodo de vacaciones es obligatorio.");
                            throw new Exception("Error al cargar el modelo");
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", "El tipo de transacción es obligatorio.");
                            throw new Exception("Error al cargar el modelo");
                        }
                    }
                }
                else
                {
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }


        public ActionResult ConsultarVacacionesAdministrativo()
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.SolicitarTemporal))] != null)
                {
                    FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();

                    var listadoJefaturaSuperior = new List<SelectListItem>();
                    var listadoFuncionarios = new List<SelectListItem>();

                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    model.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);

                    var datosJefatura = ServicioVacaciones.ListarFuncionarios(model.Funcionario.Cedula, "", "", 0, 0, 0);

                    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura.ElementAt(0);

                    if (model.Jefatura.JefeSuperior.Cedula != "")
                    {
                        listadoJefaturaSuperior = ServicioVacaciones.ListarFuncionarios("", model.Jefatura.JefeSuperior.Cedula, "", 0, 0, 0)
                                            .Select(Q => new SelectListItem
                                            {
                                                Value = ((CVacacionesJefaturaDTO)Q).Funcionario.Cedula,
                                                Text = ((CVacacionesJefaturaDTO)Q).Funcionario.Mensaje //Nombre + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.PrimerApellido + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.SegundoApellido
                                            }).ToList();

                        listadoFuncionarios = listadoJefaturaSuperior;

                        foreach (var item in listadoJefaturaSuperior.ToList())
                        {
                            var datos = ServicioVacaciones.ListarFuncionarios("", item.Value, "", 0, 0, 0)
                                                 .Select(Q => new SelectListItem
                                                 {
                                                     Value = ((CVacacionesJefaturaDTO)Q).Funcionario.Cedula,
                                                     Text = ((CVacacionesJefaturaDTO)Q).Funcionario.Mensaje //Nombre + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.PrimerApellido + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.SegundoApellido
                                                 }).ToList();

                            listadoFuncionarios.AddRange(datos);
                        }

                        listadoFuncionarios.Add(new SelectListItem { Value = model.Jefatura.JefeSuperior.Cedula, Text = model.Jefatura.JefeSuperior.Mensaje });
                    }

                    model.FuncionariosAsociados = new SelectList(listadoFuncionarios.OrderBy(Q => Q.Text), "Value", "Text");

                    return View(model);
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult ConsultarVacacionesAdministrativo(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.funcionarioSeleccionado);

                        var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.funcionarioSeleccionado).OrderBy(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();

                        /*//////////////////////// NUEVO //////////////////////////////////////////////*/

                        //var datosJefatura = ServicioVacaciones.ListarJefatura(model.funcionarioSeleccionado);
                        //if (datosJefatura.GetType() != typeof(CErrorDTO))
                        //    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura;
                        //else
                        //{
                        //    ModelState.AddModelError("BusquedaPeriodo", ((CErrorDTO)datosJefatura).MensajeError);
                        //    throw new Exception("BusquedaFuncionario");
                        //}

                        var periodosActuales = new List<string>();

                        List<CPeriodoVacacionesDTO> datosDescarga = new List<CPeriodoVacacionesDTO>();
                        if (datosPeriodo[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (CPeriodoVacacionesDTO item in datosPeriodo)
                            {
                                if (item.Saldo > 0)
                                {
                                    datosDescarga.Add(item);
                                }
                            }
                        }
                        if (datosDescarga.Count < 1)
                        {
                            datosDescarga.Add(new CPeriodoVacacionesDTO { IdEntidad = -1 });
                        }
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            ViewBag.DiasTotales = 0;
                            if (datosDescarga[0].IdEntidad > -1)
                            {
                                model.PeriodoVacaciones = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault());
                                model.UltimoPeriodo = ((CPeriodoVacacionesDTO)datosDescarga.FirstOrDefault()).Periodo;
                                model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                var periodosActivos = ServicioVacaciones.ListarPeriodosActivos(model.Funcionario.Cedula);
                                if (periodosActivos.FirstOrDefault().GetType() != typeof(CErrorDTO))
                                {
                                    foreach (var item in periodosActivos)
                                    {
                                        periodosActuales.Add(((CPeriodoVacacionesDTO)item).Periodo);
                                    }
                                }
                                if (periodosActivos[0].GetType() != typeof(CErrorDTO))
                                {
                                    model.PeriodosActivos = periodosActivos.Select(F => (CPeriodoVacacionesDTO)F).Where(F => F.Saldo > 0).ToList();
                                    ViewBag.DiasTotales = model.PeriodosActivos.Sum(Q => Q.Saldo);
                                }
                                model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];

                                List<string> estadosTipoVacaciones = new List<string>();
                                estadosTipoVacaciones.Add("Vacaciones");
                                estadosTipoVacaciones.Add("Permiso con goce de salario");
                                model.tipoDocumento = new SelectList(estadosTipoVacaciones);
                                return PartialView("_DetalleVacacionesAdministrativo", model);
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                                throw new Exception("Error al cargar el modelo");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo",
                              ((CErrorDTO)datosFuncionario[0]).MensajeError);
                            throw new Exception("BusquedaFuncionario");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }
                else if (SubmitButton == "Guardar")
                {
                    String tipoUsuario;
                    PerfilUsuarioVM modelUsuario = new PerfilUsuarioVM();
                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    modelUsuario.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);
                    if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.Administrador))] != null)
                    {
                        tipoUsuario = "RH";
                    }
                    else
                    {
                        tipoUsuario = "Funcionario";
                    }
                    tipoUsuario = "RH";
                    var solicitadoPor = int.Parse(modelUsuario.Funcionario.Cedula);
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                    if (ModelState.IsValid && model.PeriodosActivos != null && model.tipoDocumentoSeleccion != null)
                    {
                        var vacaciones = 0;
                        if (model.tipoDocumentoSeleccion == "Vacaciones")
                        {
                            vacaciones = 1;
                        }
                        else if (model.tipoDocumentoSeleccion == "Permiso sin goce de salario")
                        {
                            vacaciones = 6;
                        }
                        var medioDia = 0;
                        if (model.MedioDia == "Mañana")
                        {
                            medioDia = 1;
                        }
                        else if (model.MedioDia == "Tarde")
                        {
                            medioDia = 2;

                        }
                        model.RegistroVacaciones.SolicitadoPor = solicitadoPor;

                        model.RegistroVacaciones.Bitacora = new CBitacoraDTO { Usuario = Session["CedulaUsuario"].ToString() };

                        var guardarDatos = ServicioVacaciones.GuardarRegistroVacacionesNuevo(model.RegistroVacaciones, model.Funcionario.Cedula, model.PeriodosActivos.First().Periodo, vacaciones, medioDia, tipoUsuario);

                        if (((CRespuestaDTO)guardarDatos).Codigo > 0)
                        {
                            return Content("<div class='alert alert-success'>Cambios guardados correctamente</div>");

                            //return JavaScript("window.location = '/Vacaciones/Details?cedula=" +
                            //                                                  model.Funcionario.Cedula + "&CodPeriodo=" +
                            //                                                   model.PeriodosActivos.First().Periodo + "&Codigo=" + ((CRespuestaDTO)guardarDatos).Codigo + "&detalle=4'");
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaPeriodo", ((CRespuestaDTO)guardarDatos).Mensaje);
                            throw new Exception("Guardar");
                        }
                    }
                    else
                    {
                        if (model.PeriodosActivos == null)
                        {
                            ModelState.AddModelError("Busqueda", "El periodo de vacaciones es obligatorio.");
                            throw new Exception("Error al cargar el modelo");
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", "El tipo de transacción es obligatorio.");
                            throw new Exception("Error al cargar el modelo");
                        }
                    }
                }
                else
                {
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }

        public ActionResult ConsultarVacacionesFuncionario(string SubmitButton)
        {
            context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Vacaciones), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Vacaciones)].ToString().StartsWith("Error"))
            {
                return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Vacaciones)]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Vacaciones, Convert.ToInt32(ENivelesVacaciones.SolicitarTemporal))] != null)
                {
                    FormularioRegistroVacacionesVM model = new FormularioRegistroVacacionesVM();

                    var listadoJefaturaSuperior = new List<SelectListItem>();
                    var listadoFuncionarios = new List<SelectListItem>();

                    var usuario = perfilUsuario.RetornarPerfilUsuario(Session["NombreUsuario"].ToString());
                    model.Funcionario = (CFuncionarioDTO)usuario.ElementAt(1).ElementAt(0);

                    var datosJefatura = ServicioVacaciones.ListarFuncionarios(model.Funcionario.Cedula, "", "", 0, 0, 0);

                    model.Jefatura = (CVacacionesJefaturaDTO)datosJefatura.ElementAt(0);

                    if (model.Jefatura.JefeSuperior.Cedula != "")
                    {
                        listadoJefaturaSuperior = ServicioVacaciones.ListarFuncionarios("", model.Jefatura.JefeSuperior.Cedula, "", 0, 0, 0)
                                            .Select(Q => new SelectListItem
                                            {
                                                Value = ((CVacacionesJefaturaDTO)Q).Funcionario.Cedula,
                                                Text = ((CVacacionesJefaturaDTO)Q).Funcionario.Mensaje //Nombre + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.PrimerApellido + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.SegundoApellido
                                            }).ToList();

                        listadoFuncionarios = listadoJefaturaSuperior;

                        foreach (var item in listadoJefaturaSuperior.ToList())
                        {
                            var datos = ServicioVacaciones.ListarFuncionarios("", item.Value, "", 0, 0, 0)
                                                 .Select(Q => new SelectListItem
                                                 {
                                                     Value = ((CVacacionesJefaturaDTO)Q).Funcionario.Cedula,
                                                     Text = ((CVacacionesJefaturaDTO)Q).Funcionario.Mensaje //Nombre + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.PrimerApellido + " " + ((CCalificacionNombramientoFuncionarioDTO)Q).Funcionario.SegundoApellido
                                                 }).ToList();

                            listadoFuncionarios.AddRange(datos);
                        }

                        listadoFuncionarios.Add(new SelectListItem { Value = model.Jefatura.JefeSuperior.Cedula, Text = model.Jefatura.JefeSuperior.Mensaje });
                    }

                    model.FuncionariosAsociados = new SelectList(listadoFuncionarios.OrderBy(Q => Q.Text), "Value", "Text");

                    return View(model);
                }
                else
                {
                    CAccesoWeb.CargarErrorAcceso(Session);
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Vacaciones) });
                }
            }
        }
        [HttpPost]
        public ActionResult ConsultarVacacionesFuncionario(FormularioRegistroVacacionesVM model, string SubmitButton)
        {
            try
            {
                if (SubmitButton == "Buscar")
                {
                    if (ModelState.IsValid == true)
                    {
                        var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.funcionarioSeleccionado);
                       
                        if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                        {
                            var dato = new CPeriodoVacacionesDTO();
                            var periodos = new List<CPeriodoVacacionesDTO>();
                            var periodosActuales = new List<string>();

                            var datosPeriodo = ServicioVacaciones.ListarPeriodosActivos(model.funcionarioSeleccionado).OrderBy(P => ((CPeriodoVacacionesDTO)P).Periodo).ToList();
                                                                
                            if (datosPeriodo.FirstOrDefault().GetType() != typeof(CErrorDTO))
                            {
                                foreach (var item in datosPeriodo)
                                {
                                    dato = (CPeriodoVacacionesDTO)item;
                                    dato.Mensaje = "SIRH";
                                    periodos.Add(dato);
                                    periodosActuales.Add(dato.Periodo);
                                }
                            }

                            var periodosEmulacion = ServicioVacaciones.BuscarHistorialPeriodoVacacionesSinActuales(model.funcionarioSeleccionado, periodosActuales.ToArray());

                            if (periodosEmulacion[0].GetType() != typeof(CErrorDTO))
                            {
                                Decimal saldo = 0;
                                foreach (var item in periodosEmulacion)
                                {
                                    dato = (CPeriodoVacacionesDTO)item;
                                    saldo = Convert.ToDecimal(dato.Saldo);
                                    dato.Saldo = Convert.ToDouble(dato.DiasDerecho);
                                    dato.DiasDerecho = saldo;
                                    dato.Mensaje = "EMULACIÓN";
                                    periodos.Add(dato);
                                    periodosActuales.Add(dato.Periodo);
                                }
                            }

                            model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                            model.Puesto = (CPuestoDTO)datosFuncionario[1];
                            model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                            model.PeriodosActivos = periodos.OrderByDescending(Q => Q.Periodo).ToList();

                            return PartialView("_DetalleVacacionesFuncionario", model);
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", "El funcionario no tiene periodos de vacaciones disponibles.");
                            throw new Exception("Error al cargar el modelo");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }
                else
                {
                    return PartialView("_ErrorVacaciones");
                }
            }
            catch (Exception e)
            {
                return PartialView("_ErrorVacaciones");
            }
        }
    }
}