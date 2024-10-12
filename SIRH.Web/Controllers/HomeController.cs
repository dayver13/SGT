using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using SIRH.Web.FuncionarioService;
using SIRH.Web.FuncionarioLocal;
using SIRH.Web.Models;
using SIRH.Web.AntecedentesPenalesService;
using SIRH.Web.ServiciosGeneralesService;
using SIRH.Web.PerfilUsuarioLocal;
//using SIRH.Web.PerfilUsuarioService;
//using SIRH.Web.PuestoService;
using SIRH.Web.PuestoLocal;
using System.Net.Sockets;
using System.IO;
using SIRH.Web.ViewModels;
using SIRH.DTO;
using SIRH.Web.Reports.Funcionarios;
using SIRH.Web.Reports.PDF;
using SIRH.Web.Helpers;
using System.DirectoryServices.AccountManagement;
using ExcelDataReader;
using System.Data;

namespace SIRH.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        CFuncionarioServiceClient funcionarioReference = new CFuncionarioServiceClient();
        CServiciosGeneralesServiceClient servicioReference = new CServiciosGeneralesServiceClient();
        CPerfilUsuarioServiceClient usuarioReference = new CPerfilUsuarioServiceClient();
        CPuestoServiceClient puestoLocal = new CPuestoServiceClient();

        public ActionResult Index()
        {
            return View();
        }

      


        public ActionResult GetUser(string username)
        {
            var cedula = GestionUsuariosHelper.Decrypt(HttpUtility.UrlDecode(username));

            if (cedula.StartsWith("Error"))
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = EErrorAcceso.Sistema, modulo = 3 });
            }

            var usuario = usuarioReference.NombreUsuarioPorCedula(cedula);

            if (usuario.GetType() != typeof(CErrorDTO))
            {
                Session["NombreUsuario"] = ((CBaseDTO)usuario).Mensaje;
                Session["CedulaUsuario"] = cedula;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = EErrorAcceso.Acceso, modulo = 3 });
            }
        }

        public ActionResult GetUser2(string username)
        {
            var cedula = username;

            if (cedula.StartsWith("Error"))
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = EErrorAcceso.Sistema, modulo = 3 });
            }

            var usuario = usuarioReference.NombreUsuarioPorCedula(cedula);

            if (usuario.GetType() != typeof(CErrorDTO))
            {
                Session["NombreUsuario"] = ((CBaseDTO)usuario).Mensaje;
                Session["CedulaUsuario"] = cedula;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ErrorGeneral", "Error", new { errorType = EErrorAcceso.Acceso, modulo = 3 });
            }
        }

        [HttpPost]
        public ActionResult Index(string email_envio, string cedula, string usuario)
        {
            string name = "";
            try
            {
                EmailWebHelper email = new EmailWebHelper();
                email.Asunto = "Acceso al SIRH";
                email.Destinos = email_envio + ", " + "dguiltrc@mopt.go.cr, aarguelv@mopt.go.cr";
                email.EmailBody = "<div style=\"color: #153643; font-family: Arial, sans-serif; font-size: 16px;\">"+
                                  "<b> Solicitud de acceso al SIRH </b></div><br />" +
                                  "<div style=\"padding: 20px 0 30px 0; color: #153643; font-family: Arial, sans-serif; font-size: 14px; line-height: 20px;\">" +
                                  "El funcionario con cedula: <b>" + cedula +
                                  "</b> y usuario de dominio: <b>" + usuario + "</b> requiere acceso al SIRH, por favor verifique los permisos que tenía en el sistema Emulación, para grantizarle los accesos correspondientes.<br/>"
                                  + "<br/>Por favor, no responda a este correo electrónico ya que se ha generado de forma automática."
                                  + "</div>";
                var correo = email.EnviarMensajeCorreo();
                if (correo == "Enviado")
                {
                    return PartialView("_CorreoEnviado", new CBaseDTO { IdEntidad = 1 });
                }
                else
                {
                    throw new Exception("El servidor de correo no respondió a nuestra solicitud de envío. Por favor inténtelo de nuevo en unos minutos. " + correo + name);
                }
            }
            catch (Exception error)
            {
                return PartialView("_CorreoEnviado", new CBaseDTO { IdEntidad = -1, Mensaje = error.Message + name });
            }
        }

        public ActionResult Result(string query, int? page, string primera)
        {
            Session["error"] = null;
            FuncionarioModel modelo = new FuncionarioModel();
            try {
                int paginaActual = page.HasValue ? page.Value : 1;

                if (String.IsNullOrEmpty(query))
                {
                    ModelState.AddModelError("Busqueda", "Los parámetros ingresados son insuficientes para realizar la búsqueda.");
                    throw new Exception("Busqueda");
                    
                }

                var palabras = query.Split(' ').ToArray();

                modelo.NombreSearch = query;
                var funcionarios = funcionarioReference.BuscarFuncionarioGeneral(palabras);
                modelo.TotalFuncionarios = funcionarios.Count();
                modelo.TotalPaginas = (int)Math.Ceiling((double)modelo.TotalFuncionarios / 10);
                modelo.PaginaActual = paginaActual;
                Session["funcionarios"] = funcionarios.ToList();
                if ((((paginaActual - 1) * 10) + 10) > modelo.TotalFuncionarios)
                {
                    modelo.Funcionario = funcionarios.ToList().GetRange(((paginaActual - 1) * 10), (modelo.TotalFuncionarios) - (((paginaActual - 1) * 10))).ToList(); ;
                }
                else
                {
                    modelo.Funcionario = funcionarios.ToList().GetRange(((paginaActual - 1) * 10), 10).ToList(); ;
                }
                Session["model"] = modelo;
                if (primera.Equals("Si"))
                {
                    return View(modelo);
                }
                else
                {
                    return PartialView("Result_Details", modelo);
                }
            }
            catch (Exception error) {
                Session["error"] = "error";
                return View("Result");
            }
            
        }

        public ActionResult About()
        {
            return View();
        }

        public bool EntidadCompleta(CBaseDTO objeto)
        {
            bool respuesta = true;
            if (!String.IsNullOrEmpty(objeto.Mensaje))
            {
                respuesta = false;
            }
            return respuesta;
        }

        private PerfilFuncionarioVM ConstruirPerfil(CBaseDTO[][] perfil, PerfilFuncionarioVM modelo)
        {
            try
            {

                if (perfil.Length < 10)
                {
                    throw new Exception("modelo");
                }
                modelo.Funcionario = EntidadCompleta(perfil[0][0]) ? (CFuncionarioDTO)perfil[0][0] : null;
                //modelo.EstadoFuncionario = EntidadCompleta(perfil[0][1]) ? (CEstadoFuncionarioDTO)perfil[0][1] : null;
                modelo.EstadoCivil = new List<CHistorialEstadoCivilDTO>();
                if (perfil[1].Count() > 0)
                {
                    foreach (var item in perfil[1])
                    {
                        modelo.EstadoCivil.Add((CHistorialEstadoCivilDTO)item);
                    }
                }
                modelo.InformacionContacto = new List<CInformacionContactoDTO>();
                if (perfil[2].Count() > 0)
                {
                    foreach (var item in perfil[2])
                    {
                        modelo.InformacionContacto.Add((CInformacionContactoDTO)item);
                    }
                }
                modelo.Direccion = EntidadCompleta(perfil[3][0]) ? (CDireccionDTO)perfil[3][0] : null;
                modelo.ProvinciaDireccion = EntidadCompleta(perfil[3][1]) ? (CProvinciaDTO)perfil[3][1] : null;
                modelo.CantonDireccion = EntidadCompleta(perfil[3][2]) ? (CCantonDTO)perfil[3][2] : null;
                modelo.DistritoDireccion = EntidadCompleta(perfil[3][3]) ? (CDistritoDTO)perfil[3][3] : null;
                modelo.DetalleContrato = EntidadCompleta(perfil[4][0]) ? (CDetalleContratacionDTO)perfil[4][0] : null;
                modelo.Nombramiento = EntidadCompleta(perfil[5][0]) ? (CNombramientoDTO)perfil[5][0] : null;
                modelo.Calificaciones = new List<CCalificacionNombramientoDTO>();
                if (perfil[6].Count() > 0)
                {
                    foreach (var item in perfil[6])
                    {
                        modelo.Calificaciones.Add((CCalificacionNombramientoDTO)item);
                    }
                }
                modelo.Puesto = EntidadCompleta(perfil[7][0]) ? (CPuestoDTO)perfil[7][0] : null;
                modelo.EstadoPuesto = EntidadCompleta(perfil[7][1]) ? (CEstadoPuestoDTO)perfil[7][1] : null;
                modelo.ClasePuesto = EntidadCompleta(perfil[7][2]) ? (CClaseDTO)perfil[7][2] : null;
                modelo.EspecialidadPuesto = EntidadCompleta(perfil[7][3]) ? (CEspecialidadDTO)perfil[7][3] : null;
                modelo.SubEspecialidadPuesto = EntidadCompleta(perfil[7][4]) ? (CSubEspecialidadDTO)perfil[7][4] : null;
                modelo.OcupacionRealPuesto = EntidadCompleta(perfil[7][5]) ? (COcupacionRealDTO)perfil[7][5] : null;
                modelo.DetallePuesto = EntidadCompleta(perfil[7][6]) ? (CDetallePuestoDTO)perfil[7][6] : null;
                modelo.PresupuestoPuesto = EntidadCompleta(perfil[8][0]) ? (CPresupuestoDTO)perfil[8][0] : null;
                modelo.ProgramaPuesto = EntidadCompleta(perfil[8][1]) ? (CProgramaDTO)perfil[8][1] : null;
                //modelo.AreaPuesto = EntidadCompleta(perfil[8][2]) ? (CAreaDTO)perfil[8][2] : null;
                //modelo.ActividadPuesto = EntidadCompleta(perfil[8][3]) ? (CActividadDTO)perfil[8][3] : null;
                modelo.DivisionPuesto = EntidadCompleta(perfil[8][2]) ? (CDivisionDTO)perfil[8][2] : null;
                modelo.DireccionGeneralPuesto = EntidadCompleta(perfil[8][3]) ? (CDireccionGeneralDTO)perfil[8][3] : null;
                modelo.DepartamentoPuesto = EntidadCompleta(perfil[8][4]) ? (CDepartamentoDTO)perfil[8][4] : null;
                modelo.SeccionPuesto = EntidadCompleta(perfil[8][5]) ? (CSeccionDTO)perfil[8][5] : null;
                if (((CTipoUbicacionDTO)perfil[9][0]).IdEntidad.Equals(1))
                {
                    modelo.TipoUbicacionContrato = EntidadCompleta(perfil[9][0]) ? (CTipoUbicacionDTO)perfil[9][0] : null;
                    modelo.ProvinciaContrato = EntidadCompleta(perfil[9][1]) ? (CProvinciaDTO)perfil[9][1] : null;
                    modelo.CantonContrato = EntidadCompleta(perfil[9][2]) ? (CCantonDTO)perfil[9][2] : null;
                    modelo.DistritoContrato = EntidadCompleta(perfil[9][3]) ? (CDistritoDTO)perfil[9][3] : null;
                    modelo.UbicacionContrato = EntidadCompleta(perfil[9][4]) ? (CUbicacionPuestoDTO)perfil[9][4] : null;
                    modelo.TipoUbicacionTrabajo = EntidadCompleta(perfil[10][0]) ? (CTipoUbicacionDTO)perfil[10][0] : null;
                    modelo.ProvinciaTrabajo = EntidadCompleta(perfil[10][1]) ? (CProvinciaDTO)perfil[10][1] : null;
                    modelo.CantonTrabajo = EntidadCompleta(perfil[10][2]) ? (CCantonDTO)perfil[10][2] : null;
                    modelo.DistritoTrabajo = EntidadCompleta(perfil[10][3]) ? (CDistritoDTO)perfil[10][3] : null;
                    modelo.UbicacionTrabajo = EntidadCompleta(perfil[10][4]) ? (CUbicacionPuestoDTO)perfil[10][4] : null;
                }
                else
                {
                    modelo.TipoUbicacionContrato = EntidadCompleta(perfil[10][0]) ? (CTipoUbicacionDTO)perfil[10][0] : null;
                    modelo.ProvinciaContrato = EntidadCompleta(perfil[10][1]) ? (CProvinciaDTO)perfil[10][1] : null;
                    modelo.CantonContrato = EntidadCompleta(perfil[10][2]) ? (CCantonDTO)perfil[10][2] : null;
                    modelo.DistritoContrato = EntidadCompleta(perfil[10][3]) ? (CDistritoDTO)perfil[10][3] : null;
                    modelo.UbicacionContrato = EntidadCompleta(perfil[10][4]) ? (CUbicacionPuestoDTO)perfil[10][4] : null;
                    modelo.TipoUbicacionTrabajo = EntidadCompleta(perfil[9][0]) ? (CTipoUbicacionDTO)perfil[9][0] : null;
                    modelo.ProvinciaTrabajo = EntidadCompleta(perfil[9][1]) ? (CProvinciaDTO)perfil[9][1] : null;
                    modelo.CantonTrabajo = EntidadCompleta(perfil[9][2]) ? (CCantonDTO)perfil[9][2] : null;
                    modelo.DistritoTrabajo = EntidadCompleta(perfil[9][3]) ? (CDistritoDTO)perfil[9][3] : null;
                    modelo.UbicacionTrabajo = EntidadCompleta(perfil[9][4]) ? (CUbicacionPuestoDTO)perfil[9][4] : null;
                }

                return modelo;
            }
            catch (Exception error)
            {
                if (error.Message == "modelo")
                    return null;
                else
                    throw new Exception(error.ToString());
            }

        }

        public ActionResult Generar()
        {
            Session["error"] = null;
            try
            {
                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();
                List<FuncionariosRptData> modelo1 = new List<FuncionariosRptData>();
                List<CFuncionarioDTO> fun = (List<CFuncionarioDTO>)Session["funcionarios"];
                foreach (var item in fun)
                {
                    var perfil = funcionarioReference.DescargarPerfilFuncionarioCompleto(item.Cedula);

                    modelo = ConstruirPerfil(perfil, modelo);
                    if (modelo == null) throw new Exception("modelo");
                    modelo1.Add(FuncionariosRptData.GenerarDatosReportePorFuncionarios(modelo));
                }

                return ReporteFuncionarios(modelo1);
            }
            catch (Exception error)
            {
                Session["error"] = "error";
                if(error.Message == "modelo")
                    ModelState.AddModelError("modelo", "No existen datos del lugar de contrato ni el lugar de trabajo.\n\n Pongase en contacto con el personal autorizado.");
                else
                    ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de generar el reporte, ponerse en contacto con el personal autorizado. \n\n");


                return View("Result");

            }
            
           
        }

        private CrystalReportPdfResult ReporteFuncionarios(List<FuncionariosRptData> modelo)
        {
            string reportPath = Path.Combine(Server.MapPath("~/Reports/Funcionarios"), "ReporteFuncionarios.rpt");
            return new CrystalReportPdfResult(reportPath, modelo,"EXCEL");
        }


        private void CargarComboMotivos(FormularioCorreoVM model)
        {
            List<SelectListItem> listadoMotivos = new List<SelectListItem>();
            SelectListItem selListItem = new SelectListItem() { Value = "1", Text = "Convocatorias a las pruebas Físicas" };
            listadoMotivos.Add(selListItem);
            selListItem = new SelectListItem() { Value = "2", Text = "Participantes no aptos (reprobaron las pruebas físicas)" };
            listadoMotivos.Add(selListItem);
            selListItem = new SelectListItem() { Value = "3", Text = "Rechazadas - Por no completar satisfactoriamente la oferta" };
            listadoMotivos.Add(selListItem);
            selListItem = new SelectListItem() { Value = "4", Text = "Rechazadas - Participantes que no cuentan con la licencia de conducir de requisito o la tienen vencida" };
            listadoMotivos.Add(selListItem);
            selListItem = new SelectListItem() { Value = "5", Text = "Rechazadas - Por no contar con registro del todo o por error del participante al ingresar datos personales)" };
            listadoMotivos.Add(selListItem);
            selListItem = new SelectListItem() { Value = "6", Text = "Convocatorias a las pruebas Psicológicas" };
            listadoMotivos.Add(selListItem);

            model.Motivos = new SelectList(listadoMotivos, "Value", "Text");
        }

        public ActionResult EnviarCorreo()
        {
            // Instalar via nugget 
            // ExcelDataReader
            // ExcelDataReader.DataSet

            FormularioCorreoVM model = new FormularioCorreoVM();
            CargarComboMotivos(model);

            model.Registros = new List<ArchivoExcel>();
            return View(model);
        }

        [HttpPost]
        public ActionResult EnviarCorreo(FormularioCorreoVM model, string SubmitButton)
        {
            try
            {
                switch (SubmitButton)
                {
                    case "Cargar Excel":

                        if (model.MotivoSeleccionado == null || model.MotivoSeleccionado == "")
                            throw new Exception("Debe seleccionar un Motivo");

                        if (model.File == null)
                            throw new Exception("Debe seleccionar el archivo");

                        // Ejemplos de acceso a datos
                        DataTable table;
                        DataRow row;

                        using (var stream = model.File.InputStream)
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet();

                                // Ejemplos de acceso a datos
                                table = result.Tables[0];
                                row = table.Rows[0];
                                string cell = row[0].ToString();
                            }
                        }

                        /////// Validar cuántos correos se enviaron el día de hoy
                        var cantidad = servicioReference.VerificarCorreosEnviados(DateTime.Now);

                        model.CantidadCorreos = Int16.Parse(cantidad.Mensaje);
                        var CantidadMax = 100 - model.CantidadCorreos;
                        if (table.Rows.Count > CantidadMax)
                            throw new Exception("Ya se enviaron hoy " + model.CantidadCorreos.ToString() + " correos. El archivo contiene más de "+ CantidadMax + " registros permitidos para enviar el día de hoy.");
                        
                        switch (model.MotivoSeleccionado)
                        {
                            case "1": // Pruebas Físicas
                                model.Registros = new List<ArchivoExcel>();
                                model.Registros = (from DataRow dr in table.Rows
                                                   select new ArchivoExcel()
                                                   {
                                                       Numero = dr[0].ToString(),
                                                       Cedula = dr[1].ToString(),
                                                       PrimerApellido = dr[2].ToString(),
                                                       SegundoApellido = dr[3].ToString(),
                                                       Nombre = dr[4].ToString(),
                                                       Correo = dr[5].ToString(),
                                                       Fecha = dr[6].ToString(),
                                                       Hora = dr[7].ToString(),
                                                       Estado = "Por enviar",
                                                       FechaEnvio = ""
                                                   }).ToList();

                                model.Registros = model.Registros.Where(Q => Q.Correo.Contains("@")).ToList();
                                break;

                            case "2":  // Participantes no aptos  
                            case "3":  // Rechazadas - Por no completar
                            case "4":  // Rechazadas - Sin Licencia
                            case "5":  // Rechazadas - Por Error de Registro
                                model.Registros = new List<ArchivoExcel>();
                                model.Registros = (from DataRow dr in table.Rows
                                                   select new ArchivoExcel()
                                                   {
                                                       Numero = dr[0].ToString(),
                                                       Cedula = dr[1].ToString(),
                                                       PrimerApellido = dr[2].ToString(),
                                                       SegundoApellido = dr[3].ToString(),
                                                       Nombre = dr[4].ToString(),
                                                       Correo = dr[5].ToString(),
                                                       Estado = "Por enviar",
                                                       FechaEnvio = ""
                                                   }).ToList();

                                model.Registros = model.Registros.Where(Q => Q.Correo.Contains("@")).ToList();
                                break;

                            case "6":  // Pruebas Psicológicas
                                model.Registros = new List<ArchivoExcel>();
                                model.Registros = (from DataRow dr in table.Rows
                                                   select new ArchivoExcel()
                                                   {
                                                       Numero = dr[0].ToString(),
                                                       Cedula = dr[1].ToString(),
                                                       PrimerApellido = dr[2].ToString(),
                                                       SegundoApellido = dr[3].ToString(),
                                                       Nombre = dr[4].ToString(),
                                                       Correo = dr[5].ToString(),
                                                       Fecha = dr[6].ToString(),
                                                       Hora = dr[7].ToString(),
                                                       Estado = "Por enviar",
                                                       FechaEnvio = ""
                                                   }).ToList();

                                model.Registros = model.Registros.Where(Q => Q.Correo.Contains("@")).ToList();


                                break;


                        }
                        model.File = null;
                        model.Registros = RetornarRespuestas(model.Registros, model.MotivoSeleccionado);
                        CargarComboMotivos(model);
                        //return PartialView("_ListCorreo", model);
                        return View(model);

                    case "Enviar Correos":
                        return null;

                    default:
                        return View(model);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("Error", error.Message);
                model.Error = new CErrorDTO { MensajeError = error.Message };
                CargarComboMotivos(model);
                return View(model);
            }
        }

        public List<ArchivoExcel> RetornarRespuestas(List<ArchivoExcel> input, string tipo)
        {
            List<CTemp_EnviarCorreoDTO> correos = new List<CTemp_EnviarCorreoDTO>();
            foreach (var item in input)
            {
                item.Fecha = item.Fecha != null || item.Fecha != "" ? Convert.ToDateTime(item.Fecha).ToString("D") : item.Fecha;
                EmailWebHelper correo = new EmailWebHelper();
                var resultado = correo.EnviarCorreoSendGrid(item.Correo, item.Nombre, item.Cedula, item.Fecha, item.Hora, item.PrimerApellido, item.SegundoApellido, tipo);
                item.Estado = resultado == true ? "Enviado" : "Error en el envío";
                correos.Add(new CTemp_EnviarCorreoDTO
                {
                    Cedula = item.Cedula,
                    Correo = item.Correo,
                    FechaEnvio = Convert.ToDateTime(item.FechaEnvio),
                    IdMotivo = item.Estado == "Enviado" ? Convert.ToInt32(tipo) : 7,
                    Nombre = item.Nombre
                });
            }

            servicioReference.GuardarEnvioCorreos(correos.ToArray());
            return input;
        }


        public ActionResult AvalJefatura()
        {
            return View();
        }

        public ActionResult SolicitarTeletrabajo()
        {
            Session["errorF"] = null;
            try
            {
                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();

                var perfil = puestoLocal.DescargarPerfilPuestoAccionesFuncionarioPP(Session["CedulaUsuario"].ToString());
                if (perfil.ElementAt(0).ElementAt(0).GetType() != typeof(CErrorDTO))
                {
                    modelo = ConstruirModeloPuesto(modelo, perfil);

                    var datos = funcionarioReference.BuscarFuncionarioSalario(Session["CedulaUsuario"].ToString());
                    modelo.Salario = (CSalarioDTO)datos.ElementAt(1);
                }
                else
                {
                    var mensaje = ((CErrorDTO)perfil.ElementAt(0).ElementAt(0)).MensajeError;
                    throw new Exception(mensaje); // throw new Exception("Busqueda");
                }
                if (modelo == null) throw new Exception("modelo");
                Session["funcionario"] = modelo;

                List<SelectListItem> listaEscolaridadSelect = new List<SelectListItem>{
                    new SelectListItem { Text = "Primaria", Value =  "1"},
                    new SelectListItem { Text = "Secundaria", Value =  "2"},
                    new SelectListItem { Text = "Bachillerato Universitario", Value =  "3"},
                    new SelectListItem { Text = "Licenciatura Universitaria", Value =  "4"},
                    new SelectListItem { Text = "Maestría", Value =  "5"},
                    new SelectListItem { Text = "Otros", Value =  "6"}
                };
                modelo.ListaEscolaridad = new SelectList(listaEscolaridadSelect, "Value", "Text");

                List<SelectListItem> listaProvinciaSelect = new List<SelectListItem>{
                    new SelectListItem { Text = "San José", Value = "1" },
                    new SelectListItem { Text = "Alajuela", Value = "2" },
                    new SelectListItem { Text = "Cartago", Value = "3" },
                    new SelectListItem { Text = "Heredia", Value = "4" },
                    new SelectListItem { Text = "Guanacaste", Value = "5" },
                    new SelectListItem { Text = "Puntarenas", Value = "6" },
                    new SelectListItem { Text = "Limón", Value = "7" }
                };

                modelo.ListaProvincia = new SelectList(listaProvinciaSelect, "Value", "Text");

                var localizacion = puestoLocal.GetLocalizacion(true, 0, true, true, 0);
                //modelo.Provincias = new SelectList(localizacion.ElementAt(2).Select(Q => new SelectListItem
                //{
                //    Value = ((CProvinciaDTO)Q).IdEntidad.ToString(),
                //    Text = ((CProvinciaDTO)Q).NomProvincia
                //}), "Value", "Text");

                modelo.ListaCantones = new SelectList(localizacion.ElementAt(0).Select(Q => new SelectListItem
                {
                    Value = ((CCantonDTO)Q).IdEntidad.ToString(),
                    Text = ((CCantonDTO)Q).NomCanton
                }), "Value", "Text");
                modelo.ListaDistritos = new SelectList(localizacion.ElementAt(1).Select(Q => new SelectListItem
                {
                    Value = ((CDistritoDTO)Q).IdEntidad.ToString(),
                    Text = ((CDistritoDTO)Q).NomDistrito
                }), "Value", "Text");

                //modelo.ListaCantones = LlenarCantones();



                //List<SelectListItem> listaDistritosSelect = new List<SelectListItem>{
                //    new SelectListItem { Text = "Carmen (San José)", Value = "1" },
                //    new SelectListItem { Text = "Merced (San José)", Value = "2" },
                //    new SelectListItem { Text = "Hospital (San José)", Value = "3" },
                //    new SelectListItem { Text = "Catedral (San José)", Value = "4" },
                //    new SelectListItem { Text = "Zapote (San José)", Value = "5" },
                //    new SelectListItem { Text = "San Francisco de Dos Ríos (San José)", Value = "6" },
                //    new SelectListItem { Text = "Uruca (San José)", Value = "7" },
                //    new SelectListItem { Text = "Mata Redonda (San José)", Value = "8" },
                //    new SelectListItem { Text = "Pavas (San José)", Value = "9" },
                //    new SelectListItem { Text = "Hatillo (San José)", Value = "10" },
                //    new SelectListItem { Text = "San Sebastián (San José)", Value = "11" }
                //};

                //modelo.ListaDistritos = new SelectList(listaDistritosSelect, "Value", "Text");

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
        public ActionResult SolicitarTeletrabajo(PerfilFuncionarioVM model, string SubmitButton)
        {
            Session["errorF"] = null;
            try
            {
                if (SubmitButton == "Enviar solicitud")
                {
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                    if (ModelState.IsValid == true)
                    {
                        model.SolicitudTeletrabajo.Escolaridad = Int32.Parse(model.EscolaridadSeleccionada);
                        model.SolicitudTeletrabajo.DistritoSecundario = Int32.Parse(model.DistritoSeleccionado);
                        model.SolicitudTeletrabajo.FuncionarioTeletrabajo = model.Funcionario;
                        model.SolicitudTeletrabajo.AprobadoJefaturaInmediata = false;
                        model.SolicitudTeletrabajo.AprobadoJefaturaSuperior = false;

                        //model.SolicitudTeletrabajo.DistritoSecundario = Int32.Parse(model.DistritoSeleccionado);

                        var guardarDatos = funcionarioReference.GuardarSolicitud(model.SolicitudTeletrabajo);

                        if (((CRespuestaDTO)guardarDatos).Codigo > 0)
                        {
                            return Content("<div class='alert alert-success'>Cambios guardados correctamente</div>");
                        }
                        else
                        {
                            ModelState.AddModelError("BusquedaSolicitud", ((CRespuestaDTO)guardarDatos).Mensaje);
                            throw new Exception("Guardar");
                        }
                    }
                    else
                    {
                        throw new Exception("Busqueda");
                    }
                }

                return View(model);
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

        private SelectList LlenarCantones()
        {
            List<SelectListItem> listaCantonesSelect = new List<SelectListItem>{
                new SelectListItem { Text = "San José", Value = "1" },
                new SelectListItem { Text = "Escazú", Value = "2" },
                new SelectListItem { Text = "Desamparados", Value = "3" },
                new SelectListItem { Text = "Puriscal", Value = "4" },
                new SelectListItem { Text = "Tarrazú", Value = "5" },
                new SelectListItem { Text = "Aserrí", Value = "6" },
                new SelectListItem { Text = "Mora", Value = "7" },
                new SelectListItem { Text = "Goicoechea", Value = "8" },
                new SelectListItem { Text = "Santa Ana", Value = "9" },
                new SelectListItem { Text = "Alajuelita", Value = "10" },
                new SelectListItem { Text = "Vásquez de Coronado", Value = "11" },
                new SelectListItem { Text = "Acosta", Value = "12" },
                new SelectListItem { Text = "Tibás", Value = "13" },
                new SelectListItem { Text = "Moravia", Value = "14" },
                new SelectListItem { Text = "Montes de Oca", Value = "15" },
                new SelectListItem { Text = "Turrubares", Value = "16" },
                new SelectListItem { Text = "Dota", Value = "17" },
                new SelectListItem { Text = "Curridabat", Value = "18" },
                new SelectListItem { Text = "Pérez Zeledón", Value = "19" },
                new SelectListItem { Text = "León Cortés", Value = "20" },

                new SelectListItem { Text = "Alajuela", Value = "21" },
                new SelectListItem { Text = "San Ramón", Value = "22" },
                new SelectListItem { Text = "Grecia", Value = "23" },
                new SelectListItem { Text = "San Mateo", Value = "24" },
                new SelectListItem { Text = "Atenas", Value = "25" },
                new SelectListItem { Text = "Naranjo", Value = "26" },
                new SelectListItem { Text = "Palmares", Value = "27" },
                new SelectListItem { Text = "Poás", Value = "28" },
                new SelectListItem { Text = "Orotina", Value = "29" },
                new SelectListItem { Text = "San Carlos", Value = "30" },
                new SelectListItem { Text = "Zarcero", Value = "31" },
                new SelectListItem { Text = "Valverde Vega", Value = "32" },
                new SelectListItem { Text = "Upala", Value = "33" },
                new SelectListItem { Text = "Los Chiles", Value = "34" },
                new SelectListItem { Text = "Guatuso", Value = "35" },
                new SelectListItem { Text = "Río Cuarto", Value = "36" },

                new SelectListItem { Text = "Cartago", Value = "37" },
                new SelectListItem { Text = "Paraíso", Value = "38" },
                new SelectListItem { Text = "La Unión", Value = "39" },
                new SelectListItem { Text = "Jiménez", Value = "40" },
                new SelectListItem { Text = "Turrialba", Value = "41" },
                new SelectListItem { Text = "Alvarado", Value = "42" },
                new SelectListItem { Text = "Oreamuno", Value = "43" },
                new SelectListItem { Text = "El Guarco", Value = "44" },

                new SelectListItem { Text = "Heredia", Value = "45" },
                new SelectListItem { Text = "Barva", Value = "46" },
                new SelectListItem { Text = "Santo Domingo", Value = "47" },
                new SelectListItem { Text = "Santa Bárbara", Value = "48" },
                new SelectListItem { Text = "San Rafael", Value = "49" },
                new SelectListItem { Text = "San Isidro", Value = "50" },
                new SelectListItem { Text = "Belén", Value = "51" },
                new SelectListItem { Text = "Flores", Value = "52" },
                new SelectListItem { Text = "San Pablo", Value = "53" },
                new SelectListItem { Text = "Sarapiquí", Value = "54" },

                new SelectListItem { Text = "Liberia", Value = "55" },
                new SelectListItem { Text = "Nicoya", Value = "56" },
                new SelectListItem { Text = "Santa Cruz", Value = "57" },
                new SelectListItem { Text = "Bagaces", Value = "58" },
                new SelectListItem { Text = "Carrillo", Value = "59" },
                new SelectListItem { Text = "Cañas", Value = "60" },
                new SelectListItem { Text = "Abangares", Value = "61" },
                new SelectListItem { Text = "Tilarán", Value = "62" },
                new SelectListItem { Text = "Nandayure", Value = "63" },
                new SelectListItem { Text = "La Cruz", Value = "64" },
                new SelectListItem { Text = "Hojancha", Value = "65" },

                new SelectListItem { Text = "Puntarenas", Value = "66" },
                new SelectListItem { Text = "Esparza", Value = "67" },
                new SelectListItem { Text = "Buenos Aires", Value = "68" },
                new SelectListItem { Text = "Montes de Oro", Value = "69" },
                new SelectListItem { Text = "Osa", Value = "70" },
                new SelectListItem { Text = "Quepos", Value = "71" },
                new SelectListItem { Text = "Golfito", Value = "72" },
                new SelectListItem { Text = "Coto Brus", Value = "73" },
                new SelectListItem { Text = "Parrita", Value = "74" },
                new SelectListItem { Text = "Corredores", Value = "75" },
                new SelectListItem { Text = "Garabito", Value = "76" },

                new SelectListItem { Text = "Limón", Value = "77" },
                new SelectListItem { Text = "Pococí", Value = "78" },
                new SelectListItem { Text = "Siquirres", Value = "79" },
                new SelectListItem { Text = "Talamanca", Value = "80" },
                new SelectListItem { Text = "Matina", Value = "81" },
                new SelectListItem { Text = "Guácimo", Value = "82" }

                };

            return new SelectList(listaCantonesSelect, "Value", "Text");
        }

        private PerfilFuncionarioVM ConstruirModeloPuesto(PerfilFuncionarioVM modelo, CBaseDTO[][] datos)
        {
            modelo.Funcionario = (CFuncionarioDTO)datos.ElementAt(0).ElementAt(0);
            modelo.Nombramiento = (CNombramientoDTO)datos.ElementAt(1).ElementAt(0);
            modelo.DetalleContrato = (CDetalleContratacionDTO)datos.ElementAt(2).ElementAt(0);
            modelo.Puesto = (CPuestoDTO)datos.ElementAt(3).ElementAt(0);
            modelo.DetallePuesto = (CDetallePuestoDTO)datos.ElementAt(4).ElementAt(0);
            modelo.Direccion = (CDireccionDTO)datos.ElementAt(12).ElementAt(0);

            if (datos.ElementAt(5).Count() > 0)
            {
                if (((CUbicacionPuestoDTO)datos.ElementAt(5).ElementAt(0)).TipoUbicacion.IdEntidad.Equals(1))
                {
                    modelo.UbicacionContrato = (CUbicacionPuestoDTO)datos.ElementAt(5).ElementAt(0);
                    modelo.UbicacionTrabajo = (CUbicacionPuestoDTO)datos.ElementAt(5).ElementAt(1);
                }
                else
                {
                    modelo.UbicacionContrato = (CUbicacionPuestoDTO)datos.ElementAt(5).ElementAt(1);
                    modelo.UbicacionTrabajo = (CUbicacionPuestoDTO)datos.ElementAt(5).ElementAt(0);
                }
            }

            if (datos.ElementAt(6).ElementAt(0).IdEntidad != -1)
            {
                modelo.MensajeEstudio = "El puesto actualmente está en estudio por el Departamento de Gestión de la Organización del Trabajo, bajo el número de oficio: "
                                        + ((CEstudioPuestoDTO)datos.ElementAt(6).ElementAt(0)).NumeroOficio;
            }

            if (datos.ElementAt(7).ElementAt(0).IdEntidad != -1)
            {
                modelo.MensajePedimento = "El puesto ya cuenta con un pedimento de personal activo: "
                                        + ((CPedimentoPuestoDTO)datos.ElementAt(7).ElementAt(0)).NumeroPedimento;
            }

            if (datos.ElementAt(8).ElementAt(0).IdEntidad != -1)
            {
                modelo.MensajePrestamo = "El puesto se encuentra actualmente en calidad de préstamo, bajo la resolución número: "
                                        + ((CPrestamoPuestoDTO)datos.ElementAt(8).ElementAt(0)).NumDeResolucion;
            }

            if (datos.ElementAt(9).Count() > 0)
            {
                if (datos.ElementAt(9).ElementAt(0).IdEntidad != -1)
                {
                    modelo.EstadoCivil = new List<CHistorialEstadoCivilDTO>();
                    foreach (var item in datos.ElementAt(9))
                    {
                        modelo.EstadoCivil.Add((CHistorialEstadoCivilDTO)item);
                    }
                }
            }

            modelo.InformacionContacto = new List<CInformacionContactoDTO>();
            if (datos.ElementAt(10) != null)
            {
                if (datos.ElementAt(10).Count() > 0) //(datos.ElementAt(10).ElementAt(0).IdEntidad != -1)
                {
                    foreach (var item in datos.ElementAt(10))
                    {
                        modelo.InformacionContacto.Add((CInformacionContactoDTO)item);
                    }
                }
            }

            modelo.Calificaciones = new List<CCalificacionNombramientoDTO>();
            if (datos.ElementAt(11).Count() > 0)
            {
                if (datos.ElementAt(11).ElementAt(0).IdEntidad != -1)
                {
                    foreach (var item in datos.ElementAt(11))
                    {
                        modelo.Calificaciones.Add((CCalificacionNombramientoDTO)item);
                    }
                }
            }

            if (datos.Count() > 14)
            {
                if (datos.ElementAt(14).ElementAt(0).IdEntidad != -1)
                {
                    modelo.FuncionarioPropietario = (CNombramientoDTO)datos.ElementAt(14).ElementAt(0);
                }
                if (datos.ElementAt(15).ElementAt(0).IdEntidad != -1)
                {
                    modelo.FuncionarioOcupante = (CNombramientoDTO)datos.ElementAt(15).ElementAt(0);
                }
            }
            return modelo;
        }

        [HttpPost]
        public ActionResult GetCantones(int idProvincia)
        {
            List<CCantonDTO> listado = new List<CCantonDTO>();
            try
            {
                var localizacion = puestoLocal.GetLocalizacion(true, 0, true, true, idProvincia);

                foreach (CCantonDTO canton in localizacion.ElementAt(0))
                {
                    listado.Add(new CCantonDTO
                    {
                        IdEntidad = canton.IdEntidad,
                        NomCanton = canton.NomCanton
                    });
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

        [HttpPost]
        public ActionResult GetDistritos(int idCanton)
        {
            List<CDistritoDTO> listado = new List<CDistritoDTO>();
            try
            {
                var localizacion = puestoLocal.GetLocalizacion(true, idCanton, true, true, 0);

                foreach (CDistritoDTO distrito in localizacion.ElementAt(1))
                {
                    listado.Add(new CDistritoDTO
                    {
                        IdEntidad = distrito.IdEntidad,
                        NomDistrito = distrito.NomDistrito
                    });
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

    }
}
