using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using SIRH.DTO;

//using SIRH.Web.DesarraigoLocal;
//using SIRH.Web.AccionPersonalLocal;
//using SIRH.Web.FuncionarioLocal;
//using SIRH.Web.PuestoLocal;
//using SIRH.Web.ViaticoGastosLocal;
//using SIRH.Web.CalificacionLocal;
//using SIRH.Web.PerfilUsuarioLocal;

using SIRH.Web.DesarraigoService;
using SIRH.Web.AccionPersonalService;
using SIRH.Web.FuncionarioService;
using SIRH.Web.PuestoService;
using SIRH.Web.PerfilUsuarioService;
using SIRH.Web.ViaticoGastosService;
using SIRH.Web.CalificacionService;

using SIRH.Web.Helpers;
using SIRH.Web.Reports.Desarraigos;
using SIRH.Web.Reports.PDF;
using SIRH.Web.ViewModels;
using SIRH.Web.UserValidation;

using System.Drawing;
//using QRCoder;

namespace SIRH.Web.Controllers
{
    public class DesarraigoController : Controller
    {
        // Versión para Orlando
        #region Variables

        CDesarraigoServiceClient ServicioDesarraigo = new CDesarraigoServiceClient();
        CPerfilUsuarioServiceClient ServicioUsuario = new CPerfilUsuarioServiceClient();
        CFuncionarioServiceClient ServicioFuncionario = new CFuncionarioServiceClient();
        CAccionPersonalServiceClient servicioAccion = new CAccionPersonalServiceClient();
        CPuestoServiceClient ServicioPuesto = new CPuestoServiceClient();
        CViaticoCorridoGastoTransporteServiceClient ServicioViaticoCorridoGastoTransporte = new CViaticoCorridoGastoTransporteServiceClient();
        CCalificacionServiceClient servicioCal = new CCalificacionServiceClient();

        CPerfilUsuarioServiceClient perfilUsuario = new CPerfilUsuarioServiceClient();
        CAccesoWeb context = new CAccesoWeb();
        WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        EmailWebHelper em = new EmailWebHelper();

        #endregion

        #region Metodos Privados

        private string[] GetEmailNameUser(string username)
        {
            try
            {
                var userData = perfilUsuario.RetornarPerfilUsuario(username);
                if (userData != null)
                {
                    var fun = ((CFuncionarioDTO)userData[1][0]);
                    if (fun != null)
                        return new string[] { ((CUsuarioDTO)userData[0][0]).EmailOficial, fun.Nombre + " " + fun.PrimerApellido + " " + fun.SegundoApellido };
                    else
                        return null;
                }
                else
                    return null;

            }
            catch (Exception error)
            {
                return null;
            }
        }

        private object AccesoEsPermitido(int permiso, int perfil)
        {
            if (Session["Iniciada"] == null)
            {
                Session["Iniciada"] = true;
            }
            if (Session["Desarraigo"] == null)
            {
                Session["Desarraigo"] = true;
                var principal = WindowsIdentity.GetCurrent();
                //WindowsPrincipal principal = (WindowsPrincipal)Thread.CurrentPrincipal;
                string resultado = GestionUsuariosHelper.UsuarioPermitido(ServicioUsuario, principal.Name, permiso, perfil);
                if (resultado == "Denegado")
                {
                    Session["Perfil_Desarraigo"] = "Denegado";
                    return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "acceso", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
                else
                {
                    if (resultado.StartsWith("Error"))
                    {
                        Session["Perfil_Desarraigo"] = "Error";
                        return RedirectToAction("ErrorGeneral", "Error", new { @errorType = resultado, @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                    }
                    else
                    {
                        var permisos = ServicioUsuario.CargarPerfilUsuarioCompleto(principal.Name, permiso, perfil);
                        if (permisos.FirstOrDefault().FirstOrDefault().GetType() != typeof(CErrorDTO))
                        {

                            Session["Perfil_Desarraigo"] = "Autorizado";
                            Session["Nombre_Usuario"] = principal.Name;

                            var datosFun = (CFuncionarioDTO)((permisos[0])[0]);

                            Session["Nombre_Completo"] = datosFun.Nombre + " " + datosFun.PrimerApellido + " "
                                                         + datosFun.SegundoApellido;

                            var perfiles = permisos[1];

                            Session["Administrador_Global"] = perfiles.Where(Q => Q.GetType() == typeof(CPerfilDTO)
                                                                                  && Q.IdEntidad == 1).Count() > 0 ? true : false;

                            if (Convert.ToBoolean(Session["Administrador_Global"]) == false)
                            {
                                Session["Administrador_Desarraigo"] = perfiles.Where(Q => Q.GetType() == typeof(CCatPermisoDTO)
                                                                   && ((CCatPermisoDTO)Q).NomPermiso.StartsWith("Administrador")).Count() > 0 ? true : false;
                                if (Convert.ToBoolean(Session["Administrador_Desarraigo"]) == false)
                                {
                                    var restantes = perfiles.Where(Q => Q.GetType() == typeof(CCatPermisoDTO)).ToList();

                                    foreach (var item in restantes)
                                    {
                                        //if (item.GetType() != typeof(CPerfilDTO))
                                        //{
                                        Session["Permiso_Desarraigo_" + ((CCatPermisoDTO)item).NomPermiso.Trim()] = ((CCatPermisoDTO)item).NomPermiso;
                                        Session["Descripcion_Permiso_Desarraigo_" + ((CCatPermisoDTO)item).NomPermiso.Trim()] = ((CCatPermisoDTO)item).DesPermiso;
                                        //}
                                    }
                                }
                            }
                        }
                        else
                        {
                            Session["Perfil_Desarraigo"] = "Error";
                            return RedirectToAction("ErrorGeneral", "Error", new { @errorType = ((CErrorDTO)permisos.FirstOrDefault().FirstOrDefault()).MensajeError, @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                        }
                        return true;
                    }
                }
            }
            else
            {
                if (Session["Perfil_Desarraigo"].ToString() == "Autorizado")
                {
                    return true;
                }
                else
                {
                    if (Session["Perfil_Desarraigo"].ToString() == "Denegado")
                    {
                        return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "acceso", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                    }
                    else
                    {
                        return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "sistema", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                    }
                }
            }
        }

        private void InsertarEstado(FormularioDesarraigoVM model, bool extras, bool extras2)
        {
            List<string> estados = new List<string>();
            estados.Add("Valido");
            estados.Add("Espera");
            if (extras)
            {
                estados.Add("Vencido");
                estados.Add("Vencido por vacaciones");
                estados.Add("Vencido por incapacidad");
                estados.Add("Vencido por permiso sin salario");
            }
            if (extras2) {
                estados.Add("Anulado");
            }
            model.Estado = new SelectList(estados);
        }

        private void LlenarModeloParaEnviar(FormularioDesarraigoVM model)
        {
            model.Funcionario.Sexo = GeneroEnum.Indefinido;
            model.Desarraigo.Nombramiento = new CNombramientoDTO { IdEntidad = model.Nombramiento.IdEntidad };
            if(model.Desarraigo.EstadoDesarraigo == null)
                model.Desarraigo.EstadoDesarraigo = new CEstadoDesarraigoDTO { NomEstadoDesarraigo = model.EstadoSeleccion };
            model.Desarraigo.Nombramiento = model.Nombramiento ;
            if(model.Desarraigo.DistritoContrato == null)
                model.Desarraigo.DistritoContrato = model.UbicacionContrato.Distrito;
            if(model.Desarraigo.DistritoTrabajo == null)
                model.Desarraigo.DistritoTrabajo = model.UbicacionTrabajo.Distrito;
            model.Desarraigo.MontoDesarraigo = model.MontoDesarraigo;
            model.Desarraigo.MontoSalario = model.MontoSalario;
            model.Desarraigo.Presupuesto = new CPresupuestoDTO { CodigoPresupuesto = model.PresupuestoSelected };

            if (model.Puesto.UbicacionAdministrativa.Seccion != null && model.Desarraigo.Seccion == null)
                model.Desarraigo.Seccion = model.Puesto.UbicacionAdministrativa.Seccion;
            if (model.Puesto.UbicacionAdministrativa.Departamento != null && model.Desarraigo.Departamento == null)
                model.Desarraigo.Departamento = model.Puesto.UbicacionAdministrativa.Departamento;
            model.Desarraigo.ObservacionesEstado = "";

            if (model.Facturas == null)
                model.Facturas = new List<CFacturaDesarraigoDTO>();
            if (model.ContratosArrendamiento == null)
                model.ContratosArrendamiento = new List<CContratoArrendamientoDTO>();
            if (model.File != null)
            {
                Stream str = model.File.InputStream;
                BinaryReader Br = new BinaryReader(str);
                model.Desarraigo.DocAdjunto = Br.ReadBytes((Int32)str.Length);
            }
        }

        private void ValidarExtraFormularioDesarraigo(FormularioDesarraigoVM model)
        {
            bool error = false; //si ocurre alguno de los errores se activa
                                
            //if (model.NumCartaPresentacion == null)
            //{
            //    ModelState.AddModelError("Formulario", "El campo N° de Carta de Presentación es obligatorio.");
            //}

            //if (model.EstadoSeleccion == null)
            //{
            //    ModelState.AddModelError("Formulario", "El campo Estado del Desarraigo es obligatorio.");
            //}
            if (model.validarInfoFuncionario == false)
            {
                ModelState.AddModelError("Formulario", "Debe validar los datos de la Información del Funcionario.");
                throw new Exception("Formulario");
            }
            if (model.validarLugarTrabajo == false)
            {
                ModelState.AddModelError("Formulario", "Debe validar los datos de la Información del Lugar de Trabajo.");
                throw new Exception("Formulario");
            }
            if (model.validarLugarContrato == false)
            {
                ModelState.AddModelError("Formulario", "Debe validar los datos de la Información del Lugar de Contrato.");
                throw new Exception("Formulario");
            }

            if (model.PresupuestoSelected == null)
            {
                ModelState.AddModelError("Formulario", "El campo de presupuesto es obligatorio.");
                error = true;
            }
            if (model.ProvinciaSeleccion == null)
            {
                ModelState.AddModelError("Formulario", "El campo de Provincia de Pernocte es obligatorio.");
                error = true;
            }
            if (model.CantonSeleccion == null)
            {
                ModelState.AddModelError("Formulario", "El campo de Cantón de Pernocte es obligatorio.");
                error = true;
            }
            if (model.DistritoSeleccion == null)
            {
                ModelState.AddModelError("Formulario", "El campo de Distrito de Pernocte es obligatorio.");
                error = true;
            }
            if (model.Desarraigo.LugarPernocte == null || model.Desarraigo.LugarPernocte == "")
            {
                ModelState.AddModelError("Formulario", "El campo de la Dirección de Pernocte es obligatorio.");
                error = true;
            }
            if (model.Desarraigo.NomProyecto == null || model.Desarraigo.NomProyecto == "")
            {
                ModelState.AddModelError("Formulario", "El campo del Nombre del Proyecto es obligatorio.");
                error = true;
            }
            if (model.Desarraigo.FechaInicio > model.Desarraigo.FechaFin)
            {
                ModelState.AddModelError("Formulario", "La fecha de inicio no puede ser después de la fecha final");
                error = true;
            }
            if (model.Desarraigo.FechaInicio < model.Nombramiento.FecRige)
            {
                ModelState.AddModelError("Formulario", "La fecha de inicio del Desarraigo no puede ser anterior al inicio de nombramiento del funcionario");
                error = true;
            }
            if (model.Desarraigo.FechaFin.Year > model.Desarraigo.FechaInicio.Year)
            {
                ModelState.AddModelError("Formulario", "La fecha final máxima es el 31 de diciembre del mismo año que la fecha de inicio");
                error = true;
            }
            if (model.Nombramiento.FecVence.ToShortDateString() != "01/01/0001")//!= null
            {
                if (model.Desarraigo.FechaFin > Convert.ToDateTime(model.Nombramiento.FecVence))
                {
                    ModelState.AddModelError("Formulario", "La fecha final del Desarraigo no puede exceder el periodo de nombramiento del funcionario.");
                    error = true;
                }
            }

            if (error)
                throw new Exception("Formulario");
        }

        private void ObtenerFacturasContratos(FormularioDesarraigoVM model)
        {
            var facturas = ServicioDesarraigo.ObtenerFacturasDesarraigo(model.Desarraigo);
            if (facturas.Length > 0 && facturas[0].GetType() == typeof(CErrorDTO))
                model.Facturas = new List<CFacturaDesarraigoDTO>();
            else model.Facturas = facturas.Select(C => (CFacturaDesarraigoDTO)C).ToList();
            var contratosArrendamiento = ServicioDesarraigo.ObtenerContratosArrendamientos(model.Desarraigo);

            if (contratosArrendamiento.Length > 0 && contratosArrendamiento[0].GetType() == typeof(CErrorDTO))
                model.ContratosArrendamiento = new List<CContratoArrendamientoDTO>();
            else model.ContratosArrendamiento = contratosArrendamiento.Select(C => (CContratoArrendamientoDTO)C).ToList();

        }


        private void LlenarCorreoInformacion(NotificacionesCorreoVM model)
        {
            var nombreFuncionario = (model.NombreFuncionario).Replace("    ", " ").Trim(' ');
            var nombreUsuario = (model.NombreUsuario).Trim(' ');
            model.Asunto = "Tramite de desarraigo incompleto";
            model.MensajePrevio = "Se le informa a " + nombreFuncionario + " que su tramite de desarraigo N° " + model.CodigoDesarraigo + " se detuvo, por falta de documentación, por lo que se le solicita que presente la siguiente documentación:";
            model.PiePagina += "Por favor no responder a este correo, ya que fue generado automáticamente";
            //model.PiePagina2 += "Atentamente, " + nombreUsuario;
            //model.PiePagina2 += "Dirección de Gestión Institucional de Recursos Humanos.";
        }

        #endregion

        #region Control

        /// <summary>
        /// Pagina principal del desarraigo
        /// </summary>
        /// <example>GET: /Desarraigo/</example>
        /// <param name="permiso">Permiso del usuario</param>
        /// <param name="perfil">Perfil del usuario</param>
        /// <returns>Retorna un error o la vista principal del modulo de desarraigo</returns>
        public ActionResult Index()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Desarraigo), 0);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Desarraigo)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
                else
                {
                    context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Desarraigo), Convert.ToInt32(EAccionesBitacora.Login), 0,
                        CAccesoWeb.ListarEntidades(typeof(CPerfilDTO).Name));
                    return View();
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

            /// <summary>
            /// Detalle de un desarraigo
            /// </summary>
            /// <example>GET: /Desarraigo/Details/5</example>
            /// <param name="codigo">Codigo del desarraigo</param>
            /// <param name="accion">La pantalla de la cual de se llama el detalle</param>
            /// <returns>Retorna un error o la vista del detalle</returns>
        public ActionResult Details(string codigo, string accion)
        {
            FormularioDesarraigoVM model = new FormularioDesarraigoVM();
            ValidarPermisos(model);

            ViewData["viewMode"] = accion;
            var datos = ServicioDesarraigo.ObtenerDesarraigo(Convert.ToInt32(codigo));
            int cod = Convert.ToInt32(codigo);

            if (datos.Count() > 1)
            {
                model.Desarraigo = (CDesarraigoDTO)datos[0][0];
                model.Funcionario = (CFuncionarioDTO)datos[0][1];
                model.NumCartaPresentacion = ((CCartaPresentacionDTO)datos[0][3]).NumeroCarta;
                model.Direccion = (CDireccionDTO)datos[0][4];
                model.Contrato = (CDetalleContratacionDTO)datos[0][5];
                model.Puesto = ((CPuestoDTO)datos[1][0]);
                model.DetallePuesto = ((CDetallePuestoDTO)datos[1][1]);
                model.Facturas = datos.ElementAt(2).Select(F => (CFacturaDesarraigoDTO)F).ToList();
                model.ContratosArrendamiento = datos.ElementAt(3).Select(C => (CContratoArrendamientoDTO)C).ToList();
                model.EstadoSeleccion = model.Desarraigo.EstadoDesarraigo.NomEstadoDesarraigo;
                model.Nombramiento = model.Desarraigo.Nombramiento;            

                InsertarEstado(model, true, true);

                //Cargar combobox de codigos presupuestarios
                var codpresupuestos = ServicioPuesto.BuscarPresupuestoParams("");
                //model.CodigosPresupuestoList = new List<string>();
                List<string> tempPresupuestos = new List<string>();
                if (codpresupuestos != null)
                {
                    foreach (var i in codpresupuestos.ElementAt(0).OrderBy(Q => Q.CodigoPresupuesto).ToList())
                    {
                        tempPresupuestos.Add(i.CodigoPresupuesto);
                    }
                    model.CodigosPresupuestoList = new SelectList(tempPresupuestos);
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "404", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

        [HttpPost]
        public ActionResult Details(FormularioDesarraigoVM modelo, string SubmitButton)
        {
            string reportPath = "";
            try
            {
                switch (SubmitButton)
                {
                    case "ModificarContrato":
                        ViewData["viewMode"] = "Detalle";

                        if (modelo.PresupuestoSelected == null)
                            modelo.PresupuestoSelected = modelo.Desarraigo.Presupuesto.CodigoPresupuesto;

                        //modelo.EstadoSeleccion = modelo.GastoTransporte.EstadoGastoTransporteDTO.NomEstadoDTO;

                        LlenarModeloParaEnviar(modelo);
                        var datosDesarraigo = ServicioDesarraigo.ModificarDesarraigo(modelo.Desarraigo, null, null);
                        if (datosDesarraigo.GetType() != typeof(CErrorDTO))
                        {
                            return RedirectToAction("Details", "Desarraigo", new { codigo = modelo.Desarraigo.IdEntidad, accion = "Detalle" });
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", ((CErrorDTO)datosDesarraigo).MensajeError);
                            throw new Exception("Busqueda");
                        }

                    case "AnalizarContrato":
                    case "RevisarContrato":
                    case "AprobarContrato":

                        ViewData["viewMode"] = "Detalle";

                        var usuario = ServicioUsuario.ObtenerUsuarioPorNombre(Session["NombreUsuario"].ToString());
                        var usrFuncionario = ((CFuncionarioDTO)usuario[1][0]);

                        switch (SubmitButton)
                        {
                            case "AnalizarContrato":
                                modelo.Desarraigo.EstadoDesarraigo.IdEntidad = 2; // Analizado
                                modelo.Desarraigo.AnalizadoPor = usrFuncionario;
                                break;

                            case "RevisarContrato":
                                modelo.Desarraigo.EstadoDesarraigo.IdEntidad = 3; // Revisado
                                modelo.Desarraigo.RevisadoPor = usrFuncionario;
                                break;

                            case "AprobarContrato":
                                modelo.Desarraigo.EstadoDesarraigo.IdEntidad = 4; // Aprobado
                                modelo.Desarraigo.AprobadoPor = usrFuncionario;
                                break;
                        }

                        var datosAprobar = ServicioDesarraigo.ModificarEstadoDesarraigo(modelo.Desarraigo);
                        if (datosAprobar.GetType() != typeof(CErrorDTO))
                        {
                            List<string> entidades = new List<string>();
                            entidades.Add(typeof(CAccionPersonalDTO).Name);

                            //context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.AccionPersonal),
                            //        Convert.ToInt32(EAccionesBitacora.Guardar), modelo.Desarraigo.IdEntidad,
                            //        CAccesoWeb.ListarEntidades(entidades.ToArray()));

                            //return JavaScript("window.location = '/Desarraigo/Details?codigo=" + respuesta.IdEntidad + "&accion=Guardar';");
                            return RedirectToAction("Details", "Desarraigo", new { codigo = modelo.Desarraigo.IdEntidad, accion = "Editar" });

                            ///// Agregar Acción Personal.
                            ///// 
                            //var accion = new CAccionPersonalDTO
                            //{
                            //    AnioRige = modelo.Desarraigo.FechaInicio.Year,
                            //    FecRige = modelo.Desarraigo.FechaInicio,
                            //    FecVence = modelo.Desarraigo.FechaFin,
                            //    FecRigeIntegra = modelo.Desarraigo.FechaInicio,
                            //    FecVenceIntegra = modelo.Desarraigo.FechaFin,
                            //    Observaciones = modelo.Desarraigo.ObservacionesDesarraigo,
                            //    Nombramiento = modelo.Desarraigo.Nombramiento,
                            //    IndDato = 40,
                            //    CodigoModulo = Convert.ToInt32(EModulosHelper.Desarraigo),
                            //    CodigoObjetoEntidad = Convert.ToInt32(modelo.Desarraigo.IdEntidad)
                            //};

                            //CEstadoBorradorDTO estado = new CEstadoBorradorDTO { IdEntidad = 7 }; // Registrado 
                            //CTipoAccionPersonalDTO tipoAP = new CTipoAccionPersonalDTO { IdEntidad = Convert.ToInt32(ETipoAccionesHelper.ReajAprobDesarraigo) };

                            //var detalleAccion = new CDetalleAccionPersonalDTO
                            //{
                            //    MtoOtros = 40,
                            //    NumAnualidad = modelo.Contrato.NumeroAnualidades,
                            //    NumAnualidadAnterior = modelo.Contrato.NumeroAnualidades,
                            //    CodDetallePuesto = modelo.DetallePuesto.IdEntidad,
                            //    CodPuesto = modelo.Puesto.IdEntidad.ToString(),
                            //};
                            //modelo.Funcionario.Sexo = GeneroEnum.Indefinido;
                            //var respuestaAcc = servicioAccion.AgregarAccion(modelo.Funcionario,
                            //                                            estado,
                            //                                            tipoAP,
                            //                                            accion,
                            //                                            detalleAccion);

                            //if (respuestaAcc.GetType() != typeof(CErrorDTO))
                            //{
                            //    if (((CRespuestaDTO)respuestaAcc).Codigo > 0)
                            //    {

                            //    }
                            //    else
                            //    {
                            //        ModelState.AddModelError("Agregar", respuestaAcc.Mensaje + " Cont 1");
                            //        throw new Exception(respuestaAcc.Mensaje);
                            //    }
                            //}
                            //else
                            //{
                            //    ModelState.AddModelError("Agregar", respuestaAcc.Mensaje + " Cont 2");
                            //    throw new Exception(respuestaAcc.Mensaje);
                            //}
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", ((CErrorDTO)datosAprobar).MensajeError);
                            throw new Exception("Busqueda");
                        }

                    case "AnularContrato":
                        modelo.Desarraigo.EstadoDesarraigo.IdEntidad = 6; // Anulado
                        var datosAnular = ServicioDesarraigo.AnularDesarraigo(modelo.Desarraigo);
                        if (datosAnular.GetType() != typeof(CErrorDTO))
                        {
                            return RedirectToAction("_DetailsAnularDesarraigo", "Desarraigo", new { codigo = modelo.Desarraigo.IdEntidad, accion = "Anular" });
                        }
                        else
                        {
                            ModelState.AddModelError("Busqueda", ((CErrorDTO)datosAnular).MensajeError);
                            throw new Exception("Busqueda");
                        }

                    case "ExportarContrato":
                        List<DesarraigoRptData> modelo1 = new List<DesarraigoRptData>();
                        List<DesarraigoFacturaRptData> modelo2 = new List<DesarraigoFacturaRptData>();
                        List<ContratosDesarraigoRptData> modelo3 = new List<ContratosDesarraigoRptData>();

                        modelo.codigoQR = null; // GenerateQrCode("http://sisrh.mopt.go.cr:84/Desarraigo/Details?codigo=" + modelo.Desarraigo.IdEntidad + "&accion=Detalle");
                        modelo1.Add(DesarraigoRptData.GenerarDatosReporte(modelo, String.Empty));
                        if (modelo.Facturas != null)
                            foreach (var elm in modelo.Facturas)
                            {
                                modelo2.Add(DesarraigoFacturaRptData.GenerarDatosReporte(elm));
                            }
                        if (modelo.ContratosArrendamiento != null)
                            foreach (var elm in modelo.ContratosArrendamiento)
                            {
                                modelo3.Add(ContratosDesarraigoRptData.GenerarDatosReporte(elm));
                            }

                        reportPath = Path.Combine(Server.MapPath("~/Reports/Desarraigos"), "DesarraigoRPT.rpt");
                        return new CrystalReportPdfResult(reportPath, modelo1, modelo3, modelo2);

                    default:
                        return View();
                }
            }
            catch (Exception error)
            {
                return PartialView("", modelo);
            }
        }

        /// <summary>
        /// Pagina principal de la creacion de un desarraigo
        /// </summary>
        /// <remarks>Solo es el campo para buscar la informacion del funcionario</remarks>
        /// <example>GET: /Desarraigo/Create</example>
        /// <returns>Retorna un error o la pagina principal para crear un desarraigo</returns>
        public ActionResult Create()
        {
            try
            {
                context.IniciarSesionModulo(Session, Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Desarraigo), 13);

                if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Desarraigo)].ToString().StartsWith("Error"))
                {
                    return RedirectToAction("Index", "Error", new { modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
                else
                {
                    //context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Desarraigo), Convert.ToInt32(EAccionesBitacora.Login), 0,
                    //    CAccesoWeb.ListarEntidades(typeof(CPerfilDTO).Name));
                    return View();
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

        /// <summary>
        /// Muestra el formulario de creacion y crea un funcionario
        /// </summary>
        /// <example>POST:/Desarraigo/Create</example>
        /// <param name="model">El formulario de creacion de un desarraigo</param>
        /// <param name="SubmitButton">La accion del metodo(si solo se esta buscando, o si se esta insertando un desarraigo)</param>
        /// <returns>Retorna un error o la vista de crecion de un desarraigo</returns>
        
        [HttpPost]
        public ActionResult Create(FormularioDesarraigoVM model, string SubmitButton, FormCollection form)
        {
            try
            {
                switch (SubmitButton)
                {
                    case "Buscar":
                        if (ModelState.IsValid == true)
                        {
                            //var datosFuncionario = ServicioFuncionario.BuscarFuncionarioDetallePuesto(model.Funcionario.Cedula);
                            var datosFuncionario = ServicioViaticoCorridoGastoTransporte.BuscarFuncionarioCedula(model.Funcionario.Cedula);

                            if (datosFuncionario.FirstOrDefault().GetType() != typeof(CErrorDTO))
                            {

                                if (datosFuncionario[0].GetType() != typeof(CErrorDTO))
                                {
                                    model.Funcionario = (CFuncionarioDTO)datosFuncionario[0];
                                    model.Puesto = (CPuestoDTO)datosFuncionario[1];
                                    model.DetallePuesto = (CDetallePuestoDTO)datosFuncionario[2];
                                    var ubicacion = (CUbicacionPuestoDTO)datosFuncionario[5];
                                    if (ubicacion.TipoUbicacion.IdEntidad == 1) // Contrato
                                    {
                                        model.UbicacionContrato = ubicacion;
                                        model.UbicacionTrabajo = (CUbicacionPuestoDTO)datosFuncionario[6];
                                    }
                                    else
                                    {
                                        model.UbicacionContrato = (CUbicacionPuestoDTO)datosFuncionario[6];
                                        model.UbicacionTrabajo = ubicacion;
                                    }
                                    model.Nombramiento = (CNombramientoDTO)datosFuncionario[7];

                                    var listaEstadosPropiedad = new List<int> { 1, 5, 13, 18, 19, 20, 21, 22, 24, 25, 27, 37, 38 };
                                    var listaEstadosInterino = new List<int> { 2, 9, 23, 39 };
                                    if (listaEstadosInterino.Contains(model.Nombramiento.EstadoNombramiento.IdEntidad))
                                    {
                                        model.Nombramiento.EstadoNombramiento.DesEstado = "Interino";
                                    }
                                    else
                                    {
                                        if (listaEstadosPropiedad.Contains(model.Nombramiento.EstadoNombramiento.IdEntidad))
                                        {
                                            model.Nombramiento.EstadoNombramiento.DesEstado = "Propiedad";
                                        }
                                        else
                                        {
                                            ModelState.AddModelError("Busqueda", "No tiene un nombramiento válido " + model.Nombramiento.EstadoNombramiento.IdEntidad.ToString());
                                            throw new Exception("Busqueda");
                                        }
                                    }

                                    var datosDireccion = ServicioFuncionario.DescargarDireccion(model.Funcionario.Cedula);
                                    if (datosDireccion[0].GetType() != typeof(CErrorDTO))
                                    {
                                        model.Direccion = (CDireccionDTO)datosDireccion[0];
                                        model.Direccion.Distrito = (CDistritoDTO)datosDireccion[3];
                                        model.Direccion.Distrito.Canton = (CCantonDTO)datosDireccion[2];
                                        model.Direccion.Distrito.Canton.Provincia = (CProvinciaDTO)datosDireccion[1];
                                    }
                                    else
                                    {
                                        model.Direccion = new CDireccionDTO();
                                    }

                                    var respuesta = ServicioDesarraigo.ObtenerSalarioBase(model.DetallePuesto.EscalaSalarial.CategoriaEscala);

                                    if (respuesta.GetType() != typeof(CErrorDTO))
                                    {
                                        model.MontoSalario = ((CEscalaSalarialDTO)respuesta).SalarioBase;
                                        model.MontoDesarraigo = Convert.ToDecimal(model.MontoSalario * Convert.ToDecimal(0.40));
                                    }
                                    else
                                    {
                                        ModelState.AddModelError("Busqueda", ((CErrorDTO)respuesta).MensajeError);
                                        throw new Exception("Busqueda");
                                    }
                                 

                                    // Buscar Jefe Inmediato
                                    var datoJefe = servicioCal.ListarFuncionarios(DateTime.Now.Year, model.Funcionario.Cedula, "", "", 0, 0, 0);
                                    if (datoJefe[0].GetType() != typeof(CErrorDTO))
                                    {
                                        model.Jefe = ((CCalificacionNombramientoFuncionarioDTO)datoJefe[0]).JefeInmediato;
                                    }
                                    else {
                                        model.Jefe = new CFuncionarioDTO { IdEntidad = 0, Cedula = "", Nombre = "", PrimerApellido = "", SegundoApellido = "" };
                                    }

                                    InsertarEstado(model, false, false);

                                    // Cargar Combos
                                    var localizacion = ServicioDesarraigo.GetLocalizacion(true, true, true);
                                    model.Provincias = new SelectList(localizacion.ElementAt(2).Select(Q => new SelectListItem
                                    {
                                        Value = ((CProvinciaDTO)Q).IdEntidad.ToString(),
                                        Text = ((CProvinciaDTO)Q).NomProvincia
                                    }), "Value", "Text");
                                    model.Cantones = new SelectList(localizacion.ElementAt(0).Select(Q => new SelectListItem
                                    {
                                        Value = ((CCantonDTO)Q).IdEntidad.ToString(),
                                        Text = ((CCantonDTO)Q).NomCanton
                                    }), "Value", "Text");
                                    model.Distritos = new SelectList(localizacion.ElementAt(1).Select(Q => new SelectListItem
                                    {
                                        Value = ((CDistritoDTO)Q).IdEntidad.ToString(),
                                        Text = ((CDistritoDTO)Q).NomDistrito
                                    }), "Value", "Text");

                                    //Cargar combobox de codigos presupuestarios
                                    ListarCodigosPresupuesto(model);

                                    return PartialView("_FormularioDesarraigo", model);
                                }
                                else
                                {
                                    ModelState.AddModelError("Busqueda", ((CErrorDTO)datosFuncionario[4]).MensajeError );
                                    throw new Exception("Busqueda");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("Busqueda", ((CErrorDTO)datosFuncionario.FirstOrDefault()).MensajeError);
                                throw new Exception("Busqueda");
                            }
                        }
                        else
                        {
                            throw new Exception("Busqueda");
                        }


                    //case "Calcular Monto":
                    //    return null;

                    //case "AgregarDesarraigo":
                    default:

                        // return RedirectToAction("Details", "Desarraigo", new { codigo = 9, accion = "Guardar" });
                        //return JavaScript("window.location = '/Desarraigo/Details?codigo=9&accion=Guardar';");
                        //return new JavaScriptResult("ObtenerDetalleDesarraigo('9','Guardar');");
                        
                        var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                                .Select(x => new { x.Key, x.Value.Errors })
                                                .ToArray();
                        if (ModelState.IsValid)
                        {
                            ValidarExtraFormularioDesarraigo(model);
                            LlenarModeloParaEnviar(model);

                            var usuario = ServicioUsuario.ObtenerUsuarioPorNombre(Session["NombreUsuario"].ToString());

                            model.Desarraigo.RegistradoPor = ((CFuncionarioDTO)usuario[1][0]);
                            model.Desarraigo.JefeInmediato = model.Jefe;
                            model.Desarraigo.JefeInmediato.Sexo = GeneroEnum.Indefinido;
                            model.Desarraigo.DistritoPernocte = new CDistritoDTO { IdEntidad = Convert.ToInt32(model.DistritoSeleccion) };

                            var respuesta = ServicioDesarraigo.AgregarDesarraigo(model.Funcionario, model.Desarraigo, model.Facturas.ToArray(),
                                                                                 model.ContratosArrendamiento.ToArray());
                            if (respuesta.GetType() == typeof(CErrorDTO))
                            {
                                ModelState.AddModelError("Formulario", ((CErrorDTO)respuesta).MensajeError);
                                throw new Exception("Formulario");
                            }

                            List<string> entidades = new List<string>();
                            entidades.Add(typeof(CDesarraigoDTO).Name);

                            context.GuardarBitacora(Session["NombreUsuario"].ToString(), Convert.ToInt32(EModulosHelper.Desarraigo),
                                    Convert.ToInt32(EAccionesBitacora.Guardar), Convert.ToInt32(((CRespuestaDTO)respuesta).Contenido),
                                    CAccesoWeb.ListarEntidades(entidades.ToArray()));

                            //return JavaScript("window.location = '/Desarraigo/Details?codigo=" + respuesta.IdEntidad + "&accion=Guardar';");
                            return RedirectToAction("Details", "Desarraigo", new { codigo = respuesta.IdEntidad, accion = "Guardar" });
                        }
                        else
                        {
                            //ValidarExtraFormularioDesarraigo(model);
                            throw new Exception("Formulario");
                        }

                    //default:
                    //    return null;
                }
            }
            catch(Exception error)
            {
                if (error.Message == "Formulario")
                {
                    var mensaje = "";
                    foreach (var modelError in ModelState.SelectMany(keyValuePair => keyValuePair.Value.Errors))
                    {
                        mensaje += modelError.ErrorMessage + "\n";
                    }

                    model.Error = new CErrorDTO { MensajeError = mensaje };
                    // Cargar Combos
                    var localizacion = ServicioDesarraigo.GetLocalizacion(true, true, true);
                    model.Provincias = new SelectList(localizacion.ElementAt(2).Select(Q => new SelectListItem
                    {
                        Value = ((CProvinciaDTO)Q).IdEntidad.ToString(),
                        Text = ((CProvinciaDTO)Q).NomProvincia
                    }), "Value", "Text");
                    model.Cantones = new SelectList(localizacion.ElementAt(0).Select(Q => new SelectListItem
                    {
                        Value = ((CCantonDTO)Q).IdEntidad.ToString(),
                        Text = ((CCantonDTO)Q).NomCanton
                    }), "Value", "Text");
                    model.Distritos = new SelectList(localizacion.ElementAt(1).Select(Q => new SelectListItem
                    {
                        Value = ((CDistritoDTO)Q).IdEntidad.ToString(),
                        Text = ((CDistritoDTO)Q).NomDistrito
                    }), "Value", "Text");

                    //Cargar combobox de codigos presupuestarios
                    ListarCodigosPresupuesto(model);

                    return PartialView("_FormularioDesarraigo", model);
                }
                else
                {
                    if (ViewData.ModelState.SelectMany(keyValuePair => keyValuePair.Value.Errors).Count() == 0)
                        ModelState.AddModelError("Agregar", error.InnerException != null && error.InnerException.Message != null ?
                                                                error.InnerException.Message :
                                                                error.Message);

                    return PartialView("_ErrorDesarraigo", model);
                }
            }
        }

        /// <summary>
        /// Muestra la vista de buscar desarraigo (formulario de busqueda)
        /// </summary>
        /// <example>GET: /Desarraigo/Search/</example>
        /// <returns>Retorna un error o la vista de buscar desarraigo</returns>
        public ActionResult Search()
        {
            var acceso = AccesoEsPermitido(15, 5);// permiso: Consulta, perfil: desarraigo 
            if (acceso.GetType() != typeof(bool))
            {
                return (RedirectToRouteResult)acceso;
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_Desarraigo"]) ||
                    Session["Permiso_Desarraigo_Operativo"] != null ||
                    Session["Permiso_Desarraigo_Consulta"] != null)
                {
                    BusquedaDesarraigoVM model = new BusquedaDesarraigoVM();
                    //List<string> estados = new List<string>();
                    //estados.Add("Valido");
                    //estados.Add("Espera");
                    //estados.Add("Anulado");
                    //estados.Add("Vencido");
                    //estados.Add("Vencido por permiso sin salario");
                    //estados.Add("Vencido por vacaciones");
                    //estados.Add("Vencido por incapacidad");

                    var listadoEstados = ServicioDesarraigo.ListarEstadosDesarraigo()
                        .Select(Q => new SelectListItem
                        {
                            Value = ((CEstadoDesarraigoDTO)Q).IdEntidad.ToString(),
                            Text = ((CEstadoDesarraigoDTO)Q).NomEstadoDesarraigo
                        });

                    model.Estados = new SelectList(listadoEstados, "Value", "Text");
                    // Cargar Combos
                    var localizacion = ServicioDesarraigo.GetLocalizacion(true, true, true);
                    model.Provincias = new SelectList(localizacion.ElementAt(2).Select(Q => new SelectListItem
                    {
                        Value = ((CProvinciaDTO)Q).IdEntidad.ToString(),
                        Text = ((CProvinciaDTO)Q).NomProvincia
                    }), "Value", "Text");
                    model.Cantones = new SelectList(localizacion.ElementAt(0).Select(Q => new SelectListItem
                    {
                        Value = ((CCantonDTO)Q).IdEntidad.ToString(),
                        Text = ((CCantonDTO)Q).NomCanton
                    }), "Value", "Text");
                    model.Distritos = new SelectList(localizacion.ElementAt(1).Select(Q => new SelectListItem
                    {
                        Value = ((CDistritoDTO)Q).IdEntidad.ToString(),
                        Text = ((CDistritoDTO)Q).NomDistrito
                    }), "Value", "Text");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "acceso", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
            }
        }

        /// <summary>
        /// Busca un desarraigo o muestra los errores cometidos
        /// </summary>
        /// <example>POST: /Desarraigo/Search</example>
        /// <param name="model">Modelo de la busqueda del desarraigo</param>
        /// <returns>Los datos obtenidos o los errores obtenidos</returns>
        [HttpPost]
        public ActionResult Search(BusquedaDesarraigoVM model)
        {
            try
            {
                if (model.Funcionario.Cedula != null || model.EstadoSeleccion != null ||
                    model.Desarraigo.CodigoDesarraigo != null || model.DistritoSeleccion != null ||
                    model.CantonSeleccion != null || model.ProvinciaSeleccion != null ||
                   (model.FechaInicioDesarraigoI.Year > 1 && model.FechaInicioDesarraigoF.Year > 1) ||
                   (model.FechaFinalDesarraigoI.Year > 1 && model.FechaFinalDesarraigoF.Year > 1))
                {
                    var filtro = new List<string>();
                    List<DateTime> fechasEmision = new List<DateTime>();
                    List<DateTime> fechasVencimiento = new List<DateTime>();

                    model.Funcionario.Sexo = GeneroEnum.Indefinido;

                    if (model.FechaInicioDesarraigoI.Year > 1 && model.FechaInicioDesarraigoF.Year > 1)
                    {
                        fechasEmision.Add(model.FechaInicioDesarraigoI);
                        fechasEmision.Add(model.FechaInicioDesarraigoF);
                        filtro.Add("Fecha de Inicio");
                    }

                    if (model.EstadoSeleccion != null)
                    {
                        model.Desarraigo.EstadoDesarraigo = new CEstadoDesarraigoDTO { IdEntidad = Convert.ToInt16(model.EstadoSeleccion) };
                        filtro.Add("Estado Desarraigo");
                    }
                    else
                    {
                        model.Desarraigo.EstadoDesarraigo = new CEstadoDesarraigoDTO { IdEntidad = -1 };
                    }

                    CDistritoDTO distritoContrato = new CDistritoDTO();
                    distritoContrato.Canton = new CCantonDTO { IdEntidad = 0,
                                                               Provincia = new CProvinciaDTO { IdEntidad = 0 } };

                    if (model.DistritoSeleccion != null && model.DistritoSeleccion != "0")
                        distritoContrato.IdEntidad = Convert.ToInt32(model.DistritoSeleccion);

                    if (model.CantonSeleccion != null && model.CantonSeleccion != "0")
                        distritoContrato.Canton.IdEntidad = Convert.ToInt32(model.CantonSeleccion);

                    if (model.ProvinciaSeleccion != null && model.ProvinciaSeleccion != "0")
                        distritoContrato.Canton.Provincia.IdEntidad = Convert.ToInt32(model.ProvinciaSeleccion);

                    var datos = ServicioDesarraigo.BuscarDesarraigo(model.Funcionario, model.Desarraigo, fechasEmision.ToArray(), distritoContrato);

                    if (datos.ElementAt(0).ElementAt(0).GetType().Equals(typeof(CErrorDTO)))
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Sistema", ((CErrorDTO)datos.ElementAt(0).ElementAt(0)).MensajeError);
                        throw new Exception(((CErrorDTO)datos.ElementAt(0).ElementAt(0)).MensajeError);
                    }
                    else
                    {
                        model.DesarraigosRes = new List<FormularioDesarraigoVM>();

                        foreach (var item in datos)
                        {
                            FormularioDesarraigoVM temp = new FormularioDesarraigoVM();
                            temp.Desarraigo = (CDesarraigoDTO)item.ElementAt(0);
                            temp.Funcionario = (CFuncionarioDTO)item.ElementAt(1);
                            temp.Puesto = (CPuestoDTO)item.ElementAt(2);
                            temp.DetallePuesto = ((CDetallePuestoDTO)item.ElementAt(3));
                            model.DesarraigosRes.Add(temp);
                        }

                        ViewData["filtro"] = string.Join(",", filtro.ToArray()) + ".";

                        return PartialView("_SearchResults", model.DesarraigosRes);
                    }
                }
                else
                {
                    ModelState.Clear();
                    if (model.FechaInicioDesarraigoI < model.FechaInicioDesarraigoF && model.FechaInicioDesarraigoI.Year > 1)
                    {
                        ModelState.AddModelError("Busqueda", "Para realizar una búsqueda con rango de fechas de Emisión, debe ingresar la fecha -desde- y la fecha -hasta-.");

                    }

                    if (model.FechaFinalDesarraigoI < model.FechaFinalDesarraigoF && model.FechaFinalDesarraigoI.Year > 1)
                    {
                        ModelState.AddModelError("Busqueda", "Para realizar una búsqueda con rango de fechas de Vencimiento, debe ingresar la fecha -desde- y la fecha -hasta-.");
                    }

                    ModelState.AddModelError("Busqueda", "Los parámetros ingresados son insuficientes para realizar la búsqueda.");
                    throw new Exception("Busqueda");
                }
            }
            catch
            { //El error se matiene porque no se para que lo usan
                return PartialView("_ErrorDesarraigo");
            }
        }

        public ActionResult List()
        {
            var acceso = AccesoEsPermitido(15, 5);// permiso: Consulta, perfil: desarraigo 
            if (acceso.GetType() != typeof(bool))
            {
                return (RedirectToRouteResult)acceso;
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_Desarraigo"]) ||
                    Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Desarraigo, Convert.ToInt32(ENivelesDesarraigo.Aprobador))] != null)
                {
                    BusquedaDesarraigoVM model = new BusquedaDesarraigoVM();

                    var listadoEstados = ServicioDesarraigo.ListarEstadosDesarraigo()
                        .Select(Q => new SelectListItem
                        {
                            Value = ((CEstadoDesarraigoDTO)Q).IdEntidad.ToString(),
                            Text = ((CEstadoDesarraigoDTO)Q).NomEstadoDesarraigo
                        });

                    model.Estados = new SelectList(listadoEstados, "Value", "Text");

                    return View(model);
                }
                else
                {
                    return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "acceso", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
            }
        }

        [HttpPost]
        public ActionResult List(BusquedaDesarraigoVM model)
        {
            try
            {
                if (model.Funcionario.Cedula != null || model.EstadoSeleccion != null ||
                   (model.FechaInicioDesarraigoI.Year > 1 && model.FechaInicioDesarraigoF.Year > 1) ||
                   (model.FechaFinalDesarraigoI.Year > 1 && model.FechaFinalDesarraigoF.Year > 1))
                {
                    var filtro = new List<string>();
                    List<DateTime> fechasEmision = new List<DateTime>();
                    List<DateTime> fechasVencimiento = new List<DateTime>();
                    model.Desarraigo = new CDesarraigoDTO();
                    model.Funcionario.Sexo = GeneroEnum.Indefinido;

                    if (model.FechaInicioDesarraigoI.Year > 1 && model.FechaInicioDesarraigoF.Year > 1)
                    {
                        fechasEmision.Add(model.FechaInicioDesarraigoI);
                        fechasEmision.Add(model.FechaInicioDesarraigoF);
                        filtro.Add("Fecha de Inicio");
                    }

                    if (model.EstadoSeleccion != null)
                    {
                        model.Desarraigo.EstadoDesarraigo = new CEstadoDesarraigoDTO { IdEntidad = Convert.ToInt16(model.EstadoSeleccion) };
                        filtro.Add("Estado Desarraigo");
                    }
                    else
                    {
                        model.Desarraigo.EstadoDesarraigo = new CEstadoDesarraigoDTO { IdEntidad = -1 };
                    }

                    CDistritoDTO distritoContrato = new CDistritoDTO();
                    distritoContrato.Canton = new CCantonDTO
                    {
                        IdEntidad = 0,
                        Provincia = new CProvinciaDTO { IdEntidad = 0 }
                    };

                    var datos = ServicioDesarraigo.BuscarDesarraigo(model.Funcionario, model.Desarraigo, fechasEmision.ToArray(), distritoContrato);

                    if (datos.ElementAt(0).ElementAt(0).GetType().Equals(typeof(CErrorDTO)))
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Sistema", ((CErrorDTO)datos.ElementAt(0).ElementAt(0)).MensajeError);
                        throw new Exception(((CErrorDTO)datos.ElementAt(0).ElementAt(0)).MensajeError);
                    }
                    else
                    {
                        model.DesarraigosRes = new List<FormularioDesarraigoVM>();

                        foreach (var item in datos)
                        {
                            FormularioDesarraigoVM temp = new FormularioDesarraigoVM();
                            temp.Desarraigo = (CDesarraigoDTO)item.ElementAt(0);
                            temp.Funcionario = (CFuncionarioDTO)item.ElementAt(1);
                            temp.Puesto = (CPuestoDTO)item.ElementAt(2);
                            temp.DetallePuesto = ((CDetallePuestoDTO)item.ElementAt(3));
                            model.DesarraigosRes.Add(temp);
                        }

                        ViewData["filtro"] = string.Join(",", filtro.ToArray()) + ".";

                        return PartialView("_ListResults", model.DesarraigosRes);
                    }
                }
                else
                {
                    ModelState.Clear();
                    if (model.FechaInicioDesarraigoI < model.FechaInicioDesarraigoF && model.FechaInicioDesarraigoI.Year > 1)
                    {
                        ModelState.AddModelError("Busqueda", "Para realizar una búsqueda con rango de fechas de Emisión, debe ingresar la fecha -desde- y la fecha -hasta-.");

                    }

                    if (model.FechaFinalDesarraigoI < model.FechaFinalDesarraigoF && model.FechaFinalDesarraigoI.Year > 1)
                    {
                        ModelState.AddModelError("Busqueda", "Para realizar una búsqueda con rango de fechas de Vencimiento, debe ingresar la fecha -desde- y la fecha -hasta-.");
                    }

                    ModelState.AddModelError("Busqueda", "Los parámetros ingresados son insuficientes para realizar la búsqueda.");
                    throw new Exception("Busqueda");
                }
            }
            catch
            { //El error se matiene porque no se para que lo usan
                return PartialView("_ErrorDesarraigo");
            }

        }
        /// <summary>
        /// Muestra la vista de anulacion o un error
        /// </summary>
        /// <example>GET: /Desarraigo/Nullify/5</example>
        /// <param name="codigo">codigo del desarraigo</param>
        /// <returns>Los datos obtenidos o los errores obtenidos</returns>
        public ActionResult Nullify(string codigo)
        {
            var acceso = AccesoEsPermitido(13, 5); // permiso: Operativo, perfil: desarraigo 
            //var estadoValido = false;

            if (acceso.GetType() != typeof(bool))
                return (RedirectToRouteResult)acceso;

            if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                Convert.ToBoolean(Session["Administrador_Desarraigo"]) ||
                Session["Permiso_Desarraigo_Operativo"] != null)
            {
                FormularioDesarraigoVM model = new FormularioDesarraigoVM();

                var datos = ServicioDesarraigo.ObtenerDesarraigo(Convert.ToInt32(codigo));
                //if (((CDesarraigoDTO)datos[0][0]).EstadoDesarraigo.NomEstadoDesarraigo == "Vencido_Vac" ||
                //    ((CDesarraigoDTO)datos[0][0]).EstadoDesarraigo.NomEstadoDesarraigo == "Vencido_Incap" ||
                //    ((CDesarraigoDTO)datos[0][0]).EstadoDesarraigo.NomEstadoDesarraigo == "Vencido_PSS" ||
                //    ((CDesarraigoDTO)datos[0][0]).EstadoDesarraigo.NomEstadoDesarraigo == "Vencido")
                //{
                //    estadoValido = true;
                //}

                if (datos.Count() > 1)
                {
                    model.Desarraigo = (CDesarraigoDTO)datos[0][0];
                    model.Funcionario = (CFuncionarioDTO)datos[0][1];
                    model.NumCartaPresentacion = ((CCartaPresentacionDTO)datos[0][3]).NumeroCarta;
                    model.Puesto = ((CPuestoDTO)datos[1][0]);
                    model.DetallePuesto = ((CDetallePuestoDTO)datos[1][1]);
                    model.UbicacionContrato = ((CUbicacionPuestoDTO)datos[1][2]);
                    model.UbicacionTrabajo = ((CUbicacionPuestoDTO)datos[1][3]);
                    model.Facturas = datos.ElementAt(2).Select(F => (CFacturaDesarraigoDTO)F).ToList();
                    model.ContratosArrendamiento = datos.ElementAt(3).Select(C => (CContratoArrendamientoDTO)C).ToList();
                    model.EstadoSeleccion = model.Desarraigo.EstadoDesarraigo.NomEstadoDesarraigo;
                    InsertarEstado(model, true,true);
                }
                else
                {
                    return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "404", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "acceso", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

        /// <summary>
        /// Realiza la anulacion de un desarraigo
        /// </summary>
        /// <example>POST: /Desarraigo/Nullify</example>
        /// <param name="model">El desarraigo a anular</param>
        /// <returns>La confirmacion del desarraigo o un error</returns>
        [HttpPost]
        public ActionResult Nullify(FormularioDesarraigoVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Desarraigo.ObservacionesDesarraigo == null)
                {
                    ModelState.AddModelError("Formulario", "El campo Observaciones del la anulación es obligatorio.");
                    return PartialView("_ErrorDesarraigo");
                }
                var respuesta = ServicioDesarraigo.AnularDesarraigo(model.Desarraigo);
                if (respuesta.GetType() == typeof(CErrorDTO))
                {
                    ModelState.AddModelError("Formulario", ((CErrorDTO)respuesta).MensajeError);
                    return PartialView("_ErrorDesarraigo");
                }
                return JavaScript("window.location = '/Desarraigo/Details?codigo=" + respuesta.IdEntidad + "&accion=Guardar';");
            }
            else
            {
                return PartialView("_ErrorDesarraigo");
            }
        }


        /// <summary>
        /// Muestra la vista de editar o un error
        /// </summary>
        /// <example>GET: /Desarraigo/Edit/5</example>
        /// <param name="codigo">El codigo del desarraigo a editar</param>
        /// <returns>La vista de editar o un error</returns>
        public ActionResult Edit(string codigo, string accion)
        {
            FormularioDesarraigoVM model = new FormularioDesarraigoVM();
            ValidarPermisos(model);

            ViewData["viewMode"] = accion;
            var datos = ServicioDesarraigo.ObtenerDesarraigo(Convert.ToInt32(codigo));
            int cod = Convert.ToInt32(codigo);

            if (datos.Count() > 1)
            {
                model.Desarraigo = (CDesarraigoDTO)datos[0][0];
                model.Funcionario = (CFuncionarioDTO)datos[0][1];
                model.NumCartaPresentacion = ((CCartaPresentacionDTO)datos[0][3]).NumeroCarta;
                model.Direccion = (CDireccionDTO)datos[0][4];
                model.Contrato = (CDetalleContratacionDTO)datos[0][5];
                model.Puesto = ((CPuestoDTO)datos[1][0]);
                model.DetallePuesto = ((CDetallePuestoDTO)datos[1][1]);
                model.Facturas = datos.ElementAt(2).Select(F => (CFacturaDesarraigoDTO)F).ToList();
                model.ContratosArrendamiento = datos.ElementAt(3).Select(C => (CContratoArrendamientoDTO)C).ToList();
                model.EstadoSeleccion = model.Desarraigo.EstadoDesarraigo.NomEstadoDesarraigo;
                model.Nombramiento = model.Desarraigo.Nombramiento;
                model.Desarraigo.DetalleEliminacion = new List<CDetalleDesarraigoEliminacionDTO>();
                model.Desarraigo.DetalleEliminacion.Add(new CDetalleDesarraigoEliminacionDTO { IdEntidad = 0 });
                InsertarEstado(model, true, true);
                              
                return View(model);
            }
            else
            {
                return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "404", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

        /// <summary>
        /// Edita un desarraigo
        /// </summary>
        /// <example>POST: /Desarraigo/Edit</example>
        /// <param name="model">El desarraigo a editar</param>
        /// <returns>La confirmacion o un errror</returns>
        [HttpPost]
        public ActionResult Edit(FormularioDesarraigoVM model)
        {
            try
            {
                if (model.Desarraigo.DetalleEliminacion.FirstOrDefault().FecEliminacion.ToShortDateString() != "01/01/0001")//!= null
                {
                    if (model.Desarraigo.FechaInicio > model.Desarraigo.DetalleEliminacion.FirstOrDefault().FecEliminacion)
                    {
                        ModelState.AddModelError("Formulario", "La fecha de Suspensión no puede ser menor al inicio del Desarraigo");
                        throw new Exception("Formulario");
                    }

                    if (model.Desarraigo.FechaFin < model.Desarraigo.DetalleEliminacion.FirstOrDefault().FecEliminacion)
                    {
                        ModelState.AddModelError("Formulario", "La fecha de Suspensión no puede ser mayor al final del Desarraigo");
                        throw new Exception("Formulario");
                    }
                }
                else
                {
                    ModelState.AddModelError("Formulario", "Debe seleccionar la fecha de Suspensión del Desarraigo");
                    throw new Exception("Formulario");
                }

                // Motivo de Suspensión
                if (model.Desarraigo.DetalleEliminacion.FirstOrDefault().ObsEliminacion == null || model.Desarraigo.DetalleEliminacion.FirstOrDefault().ObsEliminacion == "")
                {
                    ModelState.AddModelError("Formulario", "Debe digita el Motivo de Suspensión del Desarraigo");
                    throw new Exception("Formulario");
                }


                var respuesta = ServicioDesarraigo.AgregarDetalleDesarraigoEliminacion(model.Desarraigo.DetalleEliminacion.FirstOrDefault(), model.Desarraigo);
                if (respuesta.GetType() != typeof(CErrorDTO))
                {
                    return JavaScript("window.location = '/Desarraigo/Details?codigo=" + model.Desarraigo.IdEntidad + "&accion=Suspender';");
                }
                else
                {
                    ModelState.AddModelError("modificar", ((CErrorDTO)respuesta).MensajeError);
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return PartialView("_ErrorDesarraigo");
            }
        }

        /// <summary>
        /// Calcula el 40% del salario base en una fecha especifica
        /// </summary>
        /// <example>POST: /Desarraigo/CalcularRetroactivo</example>
        /// <param name="model">Los datos para calcular</param>
        /// <returns>El 40% del salario en la fecha indicada o un error</returns>
        [HttpPost]
        public ActionResult CalcularRetroactivo(FormularioCalculoRetroactivo model)
        {
            var acceso = AccesoEsPermitido(13, 5);// permiso: Operativo, perfil: desarraigo 
            if (acceso.GetType() != typeof(bool))
            {
                return (RedirectToRouteResult)acceso;
            }
            else
            {
                var fechas = new DateTime[] { model.FechaICalculo, model.FechaFCalculo };
                var respuesta = ServicioDesarraigo.ObtenerMontoRetroactivo(model.Cedula, fechas);
                if (respuesta.GetType() == typeof(CErrorDTO))
                {
                    return Json(((CErrorDTO)respuesta).MensajeError);
                }
                return Json(decimal.Parse(respuesta.Mensaje));
            }
        }

        //  ORIGINAL
        //public ActionResult CalcularRetroactivo(FormularioCalculoRetroactivo model)
        //{
        //    var acceso = AccesoEsPermitido(13, 5);// permiso: Operativo, perfil: desarraigo 
        //    if (acceso.GetType() != typeof(bool))
        //    {
        //        return (RedirectToRouteResult)acceso;
        //    }
        //    else
        //    {
        //        var fechas = new DateTime[] { model.FechaICalculo, model.FechaFCalculo };
        //        var respuesta = ServicioDesarraigo.ObtenerMontoRetroactivo(model.Carta, fechas);
        //        if (respuesta.GetType() == typeof(CErrorDTO))
        //        {
        //            return Json(((CErrorDTO)respuesta).MensajeError);
        //        }
        //        return Json(decimal.Parse(respuesta.Mensaje));
        //    }
        //}

        /// <summary>
        /// Muestra la vista de notificar por correo
        /// </summary>
        /// <example>GET: /Desarraigo/codigo=120&cedula=000&username=pedroMopt&nameFunc=pedro</example>
        /// <param name="codigo">Codigo del desarraigo</param>
        /// <param name="cedula">Cedula del funcionario</param>
        /// <param name="username">Nombre del funcionario</param>
        /// <param name="nameFunc">Nombre del funcionario</param>
        /// <returns>La vista de notificar o un error</returns>
        public ActionResult NotifyByEmail(string codigo, string cedula, string username, string nameFunc)
        {
            var acceso = AccesoEsPermitido(13, 5); // permiso: Operativo, perfil: desarraigo 

            if (acceso.GetType() != typeof(bool))
            {
                return (RedirectToRouteResult)acceso;
            }

            if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                Convert.ToBoolean(Session["Administrador_Desarraigo"]) ||
                Session["Permiso_Desarraigo_Operativo"] != null)
            {
                NotificacionesCorreoVM model = new NotificacionesCorreoVM();

                var datos = ServicioDesarraigo.ObtenerCorreosElectronicos(cedula).Where(I => ((CInformacionContactoDTO)I).TipoContacto.IdEntidad == 1)
                                                                                 .Select(I => ((CInformacionContactoDTO)I).DesContenido).ToArray();
                if (datos.Count() <= 0)
                {
                    return RedirectToAction("ErrorEmail", "Error", new { @errorFunc = nameFunc, @errorCod = "Desarraigo " + codigo, @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
                else
                if (datos.Count() > 0 && datos[0].GetType() != typeof(CErrorDTO))
                {
                    var dataUser = GetEmailNameUser(username);
                    if (dataUser == null)
                    {
                        return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "404", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                    }
                    model.CorreoUsuario = dataUser[0];
                    model.CorreoFuncionario = string.Join(",", datos);
                    model.NombreUsuario = username;
                    model.NombreFuncionario = nameFunc;
                    model.CodigoDesarraigo = codigo;
                    LlenarCorreoInformacion(model);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "404", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
                }
            }
            else
            {
                return RedirectToAction("ErrorGeneral", "Error", new { @errorType = "acceso", @modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

        /// <summary>
        /// Notifica por correo
        /// </summary>
        /// <example>POST: /Desarraigo/NotifyByEmail</example>
        /// <param name="model">Los datos del correo</param>
        /// <returns>La accion de enviar por correo</returns>
        [HttpPost]
        public ActionResult NotifyByEmail(NotificacionesCorreoVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    em.Asunto = model.Asunto;
                    em.Destinos = model.CorreoFuncionario;
                    em.EmailBody = model.MensajeCompleto;
                    em.EnviarCorreo();
                    return JavaScript("window.location = '/Desarraigo/EmailDetails';");

                }
                catch (Exception error)
                {
                    ModelState.AddModelError("Formulario", error.Message);
                    return PartialView("_ErrorDesarraigo");
                }
            }
            else
            {
                return PartialView("_ErrorDesarraigo");
            }
        }
        public ActionResult EmailDetails()
        {

            try
            {
                return View();
            }
            catch (Exception error)
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = error.Message, modulo = Convert.ToInt32(EModulosHelper.Desarraigo) });
            }
        }

        /// <summary>
        /// Genera el reporte del detalle de un desarriago
        /// </summary>
        /// <example>POST: /Desarraigo/ReporteDetalleDesarraigo</example>
        /// <param name="model">Los datos del desarraigo ha reportar</param>
        /// <returns>El reporte del desarraigo</returns>
        [HttpPost]
        public CrystalReportPdfResult ReporteDetalleDesarraigo(FormularioDesarraigoVM model)
        {

            List<DesarraigoRptData> modelo1 = new List<DesarraigoRptData>();
            List<DesarraigoFacturaRptData> modelo2 = new List<DesarraigoFacturaRptData>();
            List<ContratosDesarraigoRptData> modelo3 = new List<ContratosDesarraigoRptData>();

            //model.codigoQR = GenerateQrCode("http://localhost:51142/Desarraigo/Details?codigo=" + model.Desarraigo.IdEntidad + "&accion=Detalle");

            modelo1.Add(DesarraigoRptData.GenerarDatosReporte(model, String.Empty));
            if (model.Facturas != null)
                foreach (var elm in model.Facturas)
                {
                    modelo2.Add(DesarraigoFacturaRptData.GenerarDatosReporte(elm));
                }
            if (model.ContratosArrendamiento != null)
                foreach (var elm in model.ContratosArrendamiento)
                {
                    modelo3.Add(ContratosDesarraigoRptData.GenerarDatosReporte(elm));
                }

            string reportPath = Path.Combine(Server.MapPath("~/Reports/Desarraigos"), "DesarraigoRPT.rpt");
            return new CrystalReportPdfResult(reportPath, modelo1, modelo3, modelo2);
        }

        /// <summary>
        /// Genera el reporte de una busqueda de desarraigos
        /// </summary>
        /// <example>POST: /Desarraigo/ReporteBusquedaDesarraigo</example>
        /// <param name="model">Los datos de los desarraigos ha reportar</param>
        /// <returns>El reporte de los desarraigos</returns>
        [HttpPost]
        public CrystalReportPdfResult ReporteBusquedaDesarraigo(List<FormularioDesarraigoVM> model, string filtro)
        {
            List<DesarraigoRptData> modelo = new List<DesarraigoRptData>();

            foreach (var item in model)
            {
                modelo.Add(DesarraigoRptData.GenerarDatosReporte(item, filtro));
            }
            string reportPath = Path.Combine(Server.MapPath("~/Reports/Desarraigos"), "DetalleBusquedaDesarraigoPRT.rpt");
            return new CrystalReportPdfResult(reportPath, modelo);
        }

        [HttpPost]
        public CrystalReportPdfResult ReporteListaContratos(List<FormularioDesarraigoVM> model, string filtro)
        {
            List<DesarraigoRptData> modelo = new List<DesarraigoRptData>();

            foreach (var item in model)
            {
                modelo.Add(DesarraigoRptData.GenerarReporteContratos(item, filtro));
            }
            string reportPath = Path.Combine(Server.MapPath("~/Reports/Desarraigos"), "ListaContratos.rpt");
            return new CrystalReportPdfResult(reportPath, modelo, "EXCEL");
        }

        [HttpPost]
        public ActionResult GetCantones(int idProvincia)
        {
            var localizacion = ServicioDesarraigo.GetLocalizacion(true, true, true);
            var cantones = localizacion[0].Select(Q => new CCantonDTO
            {
                IdEntidad = ((CCantonDTO)Q).IdEntidad,
                NomCanton = ((CCantonDTO)Q).NomCanton

            });
            try
            {
                if (idProvincia!=0) {
                    BusquedaDesarraigoVM model = new BusquedaDesarraigoVM();
                    cantones = localizacion[0].Where(Q => ((CCantonDTO)Q).Provincia.IdEntidad == idProvincia).Select(Q => new CCantonDTO
                    {
                        IdEntidad = ((CCantonDTO)Q).IdEntidad,
                        NomCanton = ((CCantonDTO)Q).NomCanton
                    });
                }
                return Json(new
                {
                    success = true,
                    listado = cantones
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { success = false, mensaje = error.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult GetDistritos(string nombreCanton)
        {
            var localizacion = ServicioDesarraigo.GetLocalizacion(true, true, true);
            var distritos = localizacion[1].Select(Q => new CDistritoDTO
            {
                IdEntidad = ((CDistritoDTO)Q).IdEntidad,
                NomDistrito = ((CDistritoDTO)Q).NomDistrito

            });
            var idC = 0;
            var isNumeric = int.TryParse(nombreCanton, out idC);
            try
            {
                if (!isNumeric)
                {
                    BusquedaDesarraigoVM model = new BusquedaDesarraigoVM();
                    var idCanton = localizacion[0].Where(Q => ((CCantonDTO)Q).NomCanton == nombreCanton).FirstOrDefault();
                    distritos = localizacion[1].Where(Q => ((CDistritoDTO)Q).Canton.IdEntidad == idCanton.IdEntidad).Select(Q => new CDistritoDTO
                    {
                        IdEntidad = ((CDistritoDTO)Q).IdEntidad,
                        NomDistrito = ((CDistritoDTO)Q).NomDistrito

                    });
                }
                else
            if (isNumeric && idC!=1 && idC != 0)
                {
                    BusquedaDesarraigoVM model = new BusquedaDesarraigoVM();
                    var idProvincia = localizacion[0].Where(Q => ((CCantonDTO)Q).IdEntidad == idC).FirstOrDefault();
                    distritos = localizacion[1].Where(Q => ((CDistritoDTO)Q).Canton.IdEntidad == idProvincia.IdEntidad).Select(Q => new CDistritoDTO
                    {
                        IdEntidad = ((CDistritoDTO)Q).IdEntidad,
                        NomDistrito = ((CDistritoDTO)Q).NomDistrito

                    });
                }
                return Json(new
                    {
                        success = true,
                        listado = distritos
                    }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { success = false, mensaje = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetImage(string id)
        {
            var datos = ServicioDesarraigo.ObtenerDesarraigo(Convert.ToInt32(id));
            var image = ((CDesarraigoDTO)datos[0][0]).DocAdjunto;
            return File(image, "application/pdf");
        }

        private void ListarCodigosPresupuesto(FormularioDesarraigoVM model)
        {
            var codpresupuestos = ServicioPuesto.BuscarPresupuestoParams("");
            //model.CodigosPresupuestoList = new List<string>();
            List<string> tempPresupuestos = new List<string>();
            if (codpresupuestos != null)
            {
                foreach (var i in codpresupuestos.ElementAt(0).OrderBy(Q => Q.CodigoPresupuesto).ToList())
                {
                    tempPresupuestos.Add(i.CodigoPresupuesto);
                }
                model.CodigosPresupuestoList = new SelectList(tempPresupuestos);
            }
        }

        private void ValidarPermisos(FormularioDesarraigoVM model)
        {
            var usuario = Session["NombreUsuario"].ToString();
            //usuario = "MOPT\\berna.brenes";
            context.IniciarSesionModulo(Session, usuario, Convert.ToInt32(EModulosHelper.Desarraigo), 0);

            if (Session["Perfil_" + Convert.ToInt32(EModulosHelper.Desarraigo)].ToString().StartsWith("Error"))
            {
                model.permisoAprobar = false;
                model.permisoRegistrar = false;
                model.permisoRegistrarMovimiento = false;
                model.permisoAprobarMovimiento = false;
            }
            else
            {
                if (Convert.ToBoolean(Session["Administrador_Global"]) ||
                    Convert.ToBoolean(Session["Administrador_" + Convert.ToInt32(EModulosHelper.Desarraigo)]))
                {
                    model.permisoAprobar = true;
                    model.permisoRegistrar = true;
                    model.permisoRegistrarMovimiento = true;
                    model.permisoAprobarMovimiento = true;
                }

                if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Desarraigo, Convert.ToInt32(ENivelesDesarraigo.Operativo))] != null)
                    model.permisoRegistrar = true;

                if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Desarraigo, Convert.ToInt32(ENivelesDesarraigo.Aprobador))] != null)
                    model.permisoAprobar = true;

                if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Desarraigo, Convert.ToInt32(ENivelesDesarraigo.RegistrarMovimiento))] != null)
                    model.permisoRegistrarMovimiento = true;

                if (Session[CAccesoWeb.GenerarCadenaPermiso(EModulosHelper.Desarraigo, Convert.ToInt32(ENivelesDesarraigo.AprobadorMovimiento))] != null)
                    model.permisoAprobarMovimiento = true;
            }
        }

        //private byte[] GenerateQrCode(string cadena)
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadena, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //        return stream.ToArray();
        //    }
        //}
        #endregion

    }
}