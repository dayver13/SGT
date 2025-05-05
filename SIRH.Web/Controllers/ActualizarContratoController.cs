using System;
using System.IO;
using SIRH.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using SIRH.Web.PerfilUsuarioService;
//using SIRH.Web.FuncionarioService;
//using SIRH.Web.CalificacionService;
using SIRH.Web.FuncionarioLocal;
using SIRH.Web.CalificacionLocal;
using SIRH.Web.PuestoLocal;
using System.Security.Principal;
using System.Threading;
using SIRH.Web.Helpers;
using SIRH.Web.Models;
using SIRH.Web.ViewModels;
using SIRH.Web.Reports.PDF;
using SIRH.Web.Reports.Calificacion;
using SIRH.Web.Reports.Historial;
using SIRH.Web.Reports.Datos;
using SIRH.Web.UserValidation;
using System.Xml;
using Microsoft.Data.SqlClient;
using Antlr.Runtime.Misc;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using System.Text;
using System.Web.Services.Description;
using SIRH.Web.AntecedentesPenalesService;

namespace SIRH.Web.Controllers
{
    public class ActualizarContratoController : Controller
    {
        CFuncionarioServiceClient funcionarioReference = new CFuncionarioServiceClient();
        CPuestoServiceClient puestoLocal = new CPuestoServiceClient();


        // GET: ActualizarContrato
        public ActionResult Index()
        {
            Session["errorF"] = null;
            try
            {
                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();

                Session["CedulaUsuario"] = "3214567370";
                var data = getUsuario(Session["CedulaUsuario"].ToString());
                modelo.Funcionario = (CFuncionarioDTO)data;
                modelo = ConstruirModeloPuestoSQL(modelo);
                modelo.SolicitudTeletrabajo = descargarsolicitud(Session["CedulaUsuario"].ToString(), modelo);
                //var perfil = puestoLocal.DescargarPerfilPuestoAccionesFuncionarioPP(Session["CedulaUsuario"].ToString());
                /*if (perfil.ElementAt(0).ElementAt(0).GetType() != typeof(CErrorDTO))
                {
                    modelo = ConstruirModeloPuesto(modelo, perfil);

                    var datos = funcionarioReference.BuscarFuncionarioSalario(Session["CedulaUsuario"].ToString());
                    modelo.Salario = (CSalarioDTO)datos.ElementAt(1);
                    modelo.SolicitudTeletrabajo = funcionarioReference.SolicitudActual(Session["CedulaUsuario"].ToString());
                }
                else
                {
                    var mensaje = ((CErrorDTO)perfil.ElementAt(0).ElementAt(0)).MensajeError;
                    throw new Exception(mensaje); // throw new Exception("Busqueda");
                }*/
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

                List<SelectListItem> listaCantonSelect = new List<SelectListItem>{
                    new SelectListItem { Text = "", Value = "" },

                };

                modelo.ListaCantones = new SelectList(listaCantonSelect, "Value", "Text");

                List<SelectListItem> listaDistritoSelect = new List<SelectListItem>{
                    new SelectListItem { Text = "", Value = "" },

                };

                modelo.ListaDistritos = new SelectList(listaDistritoSelect, "Value", "Text");


                /*var localizacion = puestoLocal.GetLocalizacion(true, 0, true, true, 0);


                modelo.ListaCantones = new SelectList(localizacion.ElementAt(0).Select(Q => new SelectListItem
                {
                    Value = ((CCantonDTO)Q).IdEntidad.ToString(),
                    Text = ((CCantonDTO)Q).NomCanton
                }), "Value", "Text");
                modelo.ListaDistritos = new SelectList(localizacion.ElementAt(1).Select(Q => new SelectListItem
                {
                    Value = ((CDistritoDTO)Q).IdEntidad.ToString(),
                    Text = ((CDistritoDTO)Q).NomDistrito
                }), "Value", "Text");*/


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

        public ActionResult VerSolicitud(string id)
        {
            Session["errorF"] = null;
            try
            {

                PerfilFuncionarioVM modelo = new PerfilFuncionarioVM();

                List<SolicitudTeletrabajoDTO> solicitudes = (List<SolicitudTeletrabajoDTO>)Session["Solicitudes"];
                var data = getUsuario(Session["CedulaUsuario"].ToString());
                modelo.Funcionario = (CFuncionarioDTO)data;
                modelo = ConstruirModeloPuestoSQL(modelo);

                modelo.SolicitudTeletrabajo = solicitudes.FirstOrDefault(item => item.IdEntidad == Convert.ToInt32(id));
                Session["SolicitudActual"] = solicitudes.FirstOrDefault(item => item.IdEntidad == Convert.ToInt32(id));
                CDistritoDTO distrito = new CDistritoDTO();
                distrito = getDistrito(modelo.SolicitudTeletrabajo.DistritoSecundario);
                modelo.DistritoSeleccionado = distrito.NomDistrito;
                modelo.CantonSeleccionado = distrito.Canton.NomCanton;
                modelo.ProvinciaSeleccionada = distrito.Canton.Provincia.NomProvincia;

                //var perfil = puestoLocal.DescargarPerfilPuestoAccionesFuncionarioPP(Session["CedulaUsuario"].ToString());
                /*if (perfil.ElementAt(0).ElementAt(0).GetType() != typeof(CErrorDTO))
                {
                    modelo = ConstruirModeloPuesto(modelo, perfil);

                    var datos = funcionarioReference.BuscarFuncionarioSalario(Session["CedulaUsuario"].ToString());
                    modelo.Salario = (CSalarioDTO)datos.ElementAt(1);
                    modelo.SolicitudTeletrabajo = funcionarioReference.SolicitudActual(Session["CedulaUsuario"].ToString());
                }
                else
                {
                    var mensaje = ((CErrorDTO)perfil.ElementAt(0).ElementAt(0)).MensajeError;
                    throw new Exception(mensaje); // throw new Exception("Busqueda");
                }*/
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

                if (modelo.SolicitudTeletrabajo.Escolaridad == 1) {
                    modelo.EscolaridadSeleccionada = "Primaria";
                }
                if (modelo.SolicitudTeletrabajo.Escolaridad == 2)
                {
                    modelo.EscolaridadSeleccionada = "Secundaria";
                }
                if (modelo.SolicitudTeletrabajo.Escolaridad == 3)
                {
                    modelo.EscolaridadSeleccionada = "Bachillerato Universitario";
                }
                if (modelo.SolicitudTeletrabajo.Escolaridad == 4)
                {
                    modelo.EscolaridadSeleccionada = "Licenciatura Universitaria";
                }
                if (modelo.SolicitudTeletrabajo.Escolaridad ==5)
                {
                    modelo.EscolaridadSeleccionada = "Maestría";
                }
                if (modelo.SolicitudTeletrabajo.Escolaridad == 6)
                {
                    modelo.EscolaridadSeleccionada = "Otros";
                }

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

                List<SelectListItem> listaCantonSelect = new List<SelectListItem>{
                    new SelectListItem { Text = "", Value = "" },

                };

                modelo.ListaCantones = new SelectList(listaCantonSelect, "Value", "Text");

                List<SelectListItem> listaDistritoSelect = new List<SelectListItem>{
                    new SelectListItem { Text = "", Value = "" },

                };

                modelo.ListaDistritos = new SelectList(listaDistritoSelect, "Value", "Text");


                /*var localizacion = puestoLocal.GetLocalizacion(true, 0, true, true, 0);


                modelo.ListaCantones = new SelectList(localizacion.ElementAt(0).Select(Q => new SelectListItem
                {
                    Value = ((CCantonDTO)Q).IdEntidad.ToString(),
                    Text = ((CCantonDTO)Q).NomCanton
                }), "Value", "Text");
                modelo.ListaDistritos = new SelectList(localizacion.ElementAt(1).Select(Q => new SelectListItem
                {
                    Value = ((CDistritoDTO)Q).IdEntidad.ToString(),
                    Text = ((CDistritoDTO)Q).NomDistrito
                }), "Value", "Text");*/


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
        public ActionResult NuevaSolicitudTeletrabajo(PerfilFuncionarioVM model, string SubmitButton, string lunes, string miercoles, string martes, string jueves, string viernes)
        {
            Session["errorF"] = null;
            try
            {
                SolicitudTeletrabajoDTO solicitud = (SolicitudTeletrabajoDTO)Session["SolicitudActual"];

                if(Int32.Parse(model.DistritoSeleccionado) != 0) { 
                    solicitud.DireccionExactaSecundaria = model.SolicitudTeletrabajo.DireccionExactaSecundaria;
                    solicitud.DistritoSecundario = Int32.Parse(model.DistritoSeleccionado);
                }
                solicitud.CantidadDiasTeletrabajo = model.SolicitudTeletrabajo.CantidadDiasTeletrabajo;
                solicitud.DetalleDiasTeletrabajo = lunes + martes + miercoles + jueves + viernes;


                int solicitudId = 0;
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
                string query = @"
                    INSERT INTO solicitudteletrabajo (
                        IndEscolaridad,
                        IndDistritoSecundario,
                        DirExactaSecundario,
                        CntPersonasDirSecundario,
                        CntPersonasDirPrimario,
                        DesTiempolaborarMopt,
                        IndTeletrabajable,
                        CntDiasSolicita,
                        DesDiasSolicita,
                        IndHorario,
                        DesFunciones,
                        IndTiempoFunciones,
                        DesRazones,
                        IndDeclaracionJurada,
                        DesSistemas,
                        FK_Funcionario,
                        IndAprobadoJefatura,
                        IndAprobadoSuperior,
                        DesTiempoLaboradoDependencia
                    )
                    OUTPUT INSERTED.PK_SolicitudTeletrabajo
                    VALUES (
                        @Escolaridad,
                        @DistritoSecundario,
                        @DireccionExactaSecundaria,
                        @CantidadPersonasDireccionSecundaria,
                        @CantidadPersonasDireccionPrimaria,
                        @TiempoLaborarMOPT,
                        @Teletrabajable,
                        @CantidadDiasTeletrabajo,
                        @DetalleDiasTeletrabajo,
                        @Horario,
                        @Funciones,
                        @TiempoFunciones,
                        @Razones,
                        @DeclaracionJurada,
                        @Sistemas,
                        @FuncionarioTeletrabajoID,
                        @AprobadoJefaturaInmediata,
                        @AprobadoJefaturaSuperior,
                        @TiempoLaborarDependencia
                    );";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Escolaridad", solicitud.Escolaridad);
                        command.Parameters.AddWithValue("@DistritoSecundario", solicitud.DistritoSecundario);
                        command.Parameters.AddWithValue("@DireccionExactaSecundaria", solicitud.DireccionExactaSecundaria);
                        command.Parameters.AddWithValue("@CantidadPersonasDireccionSecundaria", solicitud.CantidadPersonasDireccionSecundaria);
                        command.Parameters.AddWithValue("@CantidadPersonasDireccionPrimaria", solicitud.CantidadPersonasDireccionPrimaria);
                        command.Parameters.AddWithValue("@TiempoLaborarMOPT", solicitud.TiempoLaborarMOPT);
                        command.Parameters.AddWithValue("@Teletrabajable", solicitud.Teletrabajable);
                        command.Parameters.AddWithValue("@CantidadDiasTeletrabajo", solicitud.CantidadDiasTeletrabajo);
                        command.Parameters.AddWithValue("@DetalleDiasTeletrabajo", solicitud.DetalleDiasTeletrabajo);
                        command.Parameters.AddWithValue("@Horario", solicitud.Horario);
                        command.Parameters.AddWithValue("@Funciones", solicitud.Funciones);
                        command.Parameters.AddWithValue("@TiempoFunciones", solicitud.TiempoFunciones);
                        command.Parameters.AddWithValue("@Razones", solicitud.Razones);
                        command.Parameters.AddWithValue("@DeclaracionJurada", solicitud.DeclaracionJurada);
                        command.Parameters.AddWithValue("@Sistemas", solicitud.Sistemas);
                        command.Parameters.AddWithValue("@FuncionarioTeletrabajoID", Convert.ToInt32(Session["Identidad"]));
                        command.Parameters.AddWithValue("@AprobadoJefaturaInmediata", false);
                        command.Parameters.AddWithValue("@AprobadoJefaturaSuperior", false);
                        command.Parameters.AddWithValue("@TiempoLaborarDependencia", solicitud.TiempoLaborarDependencia);

                        connection.Open();
                        solicitudId = (int)command.ExecuteScalar();
                        guardaractividades(solicitudId);
                    }
                }




                return View();
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";

                System.Diagnostics.Debug.WriteLine($"2-Error al conectar a la base de datos: {error.Message}");
                ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de ver el perfil del funcionario, ponerse en contacto con el personal autorizado. \n" + error.Message);


                return View();

            }

        }

        [HttpPost]
        public ActionResult ActualizarSolicitudTeletrabajo(PerfilFuncionarioVM model, string SubmitButton, string lunes, string miercoles, string martes, string jueves, string viernes)
        {
            Session["errorF"] = null;
            try
            {
                
                SolicitudTeletrabajoDTO solicitud = (SolicitudTeletrabajoDTO)Session["SolicitudActual"];
                if (Int32.Parse(model.DistritoSeleccionado) != 0)
                {
                    solicitud.DireccionExactaSecundaria = model.SolicitudTeletrabajo.DireccionExactaSecundaria;
                    solicitud.DistritoSecundario = Int32.Parse(model.DistritoSeleccionado);
                }
                if (Int32.Parse(model.EscolaridadSeleccionada) != 0) {
                    solicitud.Escolaridad = Int32.Parse(model.EscolaridadSeleccionada);
                }
                solicitud.CantidadDiasTeletrabajo = model.SolicitudTeletrabajo.CantidadDiasTeletrabajo;
                solicitud.DetalleDiasTeletrabajo = lunes + martes + miercoles + jueves + viernes;

                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
                string query = @"
                            UPDATE SolicitudTeletrabajo
                            SET 
                                IndEscolaridad = @Escolaridad,
                                IndDistritoSecundario = @DistritoSecundario,
                                DirExactaSecundario = @DireccionExactaSecundaria,
                                CntPersonasDirSecundario = @CantidadPersonasDireccionSecundaria,
                                CntPersonasDirPrimario = @CantidadPersonasDireccionPrimaria,
                                DesTiempolaborarMopt = @TiempoLaborarMOPT,
                                IndTeletrabajable = @Teletrabajable,
                                CntDiasSolicita = @CantidadDiasTeletrabajo,
                                DesDiasSolicita = @DetalleDiasTeletrabajo,
                                IndHorario = @Horario,
                                DesFunciones = @Funciones,
                                IndTiempoFunciones = @TiempoFunciones,
                                DesRazones = @Razones,
                                IndDeclaracionJurada = @DeclaracionJurada,
                                DesSistemas = @Sistemas,
                                FK_Funcionario = @FuncionarioTeletrabajoID,
                                IndAprobadoJefatura = @AprobadoJefaturaInmediata,
                                IndAprobadoSuperior = @AprobadoJefaturaSuperior,
                                DesTiempoLaboradoDependencia = @TiempoLaborarDependencia
                            WHERE
                                PK_SolicitudTeletrabajo = @SolicitudTeletrabajoID;
                            ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Escolaridad", solicitud.Escolaridad);
                        command.Parameters.AddWithValue("@DistritoSecundario", solicitud.DistritoSecundario);
                        command.Parameters.AddWithValue("@DireccionExactaSecundaria", solicitud.DireccionExactaSecundaria);
                        command.Parameters.AddWithValue("@CantidadPersonasDireccionSecundaria", solicitud.CantidadPersonasDireccionSecundaria);
                        command.Parameters.AddWithValue("@CantidadPersonasDireccionPrimaria", solicitud.CantidadPersonasDireccionPrimaria);
                        command.Parameters.AddWithValue("@TiempoLaborarMOPT", solicitud.TiempoLaborarMOPT);
                        command.Parameters.AddWithValue("@Teletrabajable", solicitud.Teletrabajable);
                        command.Parameters.AddWithValue("@CantidadDiasTeletrabajo", solicitud.CantidadDiasTeletrabajo);
                        command.Parameters.AddWithValue("@DetalleDiasTeletrabajo", solicitud.DetalleDiasTeletrabajo);
                        command.Parameters.AddWithValue("@Horario", solicitud.Horario);
                        command.Parameters.AddWithValue("@Funciones", solicitud.Funciones);
                        command.Parameters.AddWithValue("@TiempoFunciones", solicitud.TiempoFunciones);
                        command.Parameters.AddWithValue("@Razones", solicitud.Razones);
                        command.Parameters.AddWithValue("@DeclaracionJurada", solicitud.DeclaracionJurada);
                        command.Parameters.AddWithValue("@Sistemas", solicitud.Sistemas);
                        command.Parameters.AddWithValue("@FuncionarioTeletrabajoID", Convert.ToInt32(Session["Identidad"]));
                        command.Parameters.AddWithValue("@AprobadoJefaturaInmediata", false);
                        command.Parameters.AddWithValue("@AprobadoJefaturaSuperior", false);
                        command.Parameters.AddWithValue("@TiempoLaborarDependencia", solicitud.TiempoLaborarDependencia);
                        command.Parameters.AddWithValue("SolicitudTeletrabajoID", solicitud.IdEntidad);

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

        [HttpGet]
        public ActionResult DescargarActividades()
        {
            // Simulando una lista de actividades


            // Convertir la lista a CSV
            var csv = new StringBuilder();
            csv.AppendLine("Descripcion"); // Encabezados

            List<CActividadSolicitudTeletrabajoDTO> activList = (List<CActividadSolicitudTeletrabajoDTO>)Session["Actividades"];

            foreach (var actividad in activList)
            {

                csv.AppendLine($"{actividad.DescripcionActividad}");
            }


            // Devolver el CSV como archivo descargable
            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "actividades.csv");
        }

        [HttpPost]
        public ActionResult EliminarActividad(string actividad)
        {
            // Simulando una lista de actividades
            var csv = new StringBuilder();
            csv.AppendLine("Descripcion");
            System.Diagnostics.Debug.WriteLine("Actividad: " + actividad);
            List<CActividadSolicitudTeletrabajoDTO> activList = (List<CActividadSolicitudTeletrabajoDTO>)Session["Actividades"];
            activList.RemoveAll(item => item.DescripcionActividad == actividad);
            Session["Actividades"] = activList;
            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "actividades.csv");
        }

        [HttpPost]
        public ActionResult AgregarActividad(string actividad, bool medios, bool medible, bool supervision)
        {
            CActividadSolicitudTeletrabajoDTO activ = new CActividadSolicitudTeletrabajoDTO();
            activ.DescripcionActividad = actividad;
            activ.Medible = medible;
            activ.Medios = medios;
            activ.Supervision = supervision;

            var csv = new StringBuilder();
            csv.AppendLine("Descripcion");
            List<CActividadSolicitudTeletrabajoDTO> activList = (List<CActividadSolicitudTeletrabajoDTO>)Session["Actividades"];
            activList.Add(activ);
            Session["Actividades"] = activList;
            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "actividades.csv");
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


        private object getUsuario(string v)
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
                    string query = "SELECT * FROM Funcionario WHERE IdCedulaFuncionario = " + v; // Cambia 'tu_tabla' por el nombre de tu tabla
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

        private string guardaractividades(int solicitudfk) {
            Session["errorF"] = null;
            try
            {
                List<CActividadSolicitudTeletrabajoDTO> actividades = (List<CActividadSolicitudTeletrabajoDTO>)Session["Actividades"];


                System.Diagnostics.Debug.WriteLine(actividades.Count);
                int solicitudId = 0;
                string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
                string query = @"
                    INSERT INTO ActividadSolicitudTeletrabajo (
                        DesActividad,
                        IndMedios,
                        IndMedible,
                        IndSupervision,
                        FK_SolicitudTeletrabajo
                    )
                    OUTPUT INSERTED.PK_ActividadSolicitudTeletrabajo
                    VALUES (
                        @Actividad,
                        @Medios,
                        @Medible,
                        @Supervision,
                        @SolicitudID
                    );";

                for (int i = 0; i < actividades.Count; i++)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {

                            command.Parameters.AddWithValue("@Actividad", actividades[i].DescripcionActividad);
                            command.Parameters.AddWithValue("@Medios", actividades[i].Medios);
                            command.Parameters.AddWithValue("@Medible", actividades[i].Medible);
                            command.Parameters.AddWithValue("@Supervision", actividades[i].Supervision);
                            command.Parameters.AddWithValue("SolicitudID", solicitudfk);

                            connection.Open();
                            solicitudId = (int)command.ExecuteScalar();
                            connection.Close();
                        }
                    }
                }


                return "exitoso";
            }
            catch (Exception error)
            {
                Session["errorF"] = "error";

                System.Diagnostics.Debug.WriteLine($"Hi2-Error al conectar a la base de datos: {error.Message}");
                ModelState.AddModelError("Busqueda", "Ha ocurrido un error a la hora de ver el perfil del funcionario, ponerse en contacto con el personal autorizado. \n" + error.Message);


                return "Fallo";

            }
        }

        private PerfilFuncionarioVM ConstruirModeloPuestoSQL(PerfilFuncionarioVM modelo)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CNombramientoDTO nombramiento = new CNombramientoDTO();
            int fkestado;
            int fkpuesto;
            CPuestoDTO puesto = new CPuestoDTO();
            CEstadoPuestoDTO estadopdto = new CEstadoPuestoDTO();
            CDetalleContratacionDTO contratacion = new CDetalleContratacionDTO();
            CDistritoDTO distrito = new CDistritoDTO();
            int fkdistrito;
            CCantonDTO canton = new CCantonDTO();
            int fkcanton;
            CProvinciaDTO provincia = new CProvinciaDTO();
            int fkprovincia;
            CDireccionDTO direccion = new CDireccionDTO();



            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Nombramiento WHERE FK_Funcionario IN (SELECT PK_Funcionario FROM Funcionario WHERE IdCedulaFuncionario =" + modelo.Funcionario.Cedula + ");"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fkpuesto = reader.GetInt32(2);
                            fkestado = reader.GetInt32(1);
                            nombramiento.FecRige = reader.GetDateTime(4);
                            nombramiento.FecVence = reader.GetDateTime(5);
                            nombramiento.FecNombramiento = reader.GetDateTime(6);
                            nombramiento.EstadoNombramiento = funcEstado(fkestado);
                            nombramiento.Puesto = funcpuesto(fkpuesto);
                        }
                    }

                    /*string querycontra = "SELECT * FROM DetalleContratacion WHERE FK_Funcionario IN (SELECT PK_Funcionario FROM Funcionario WHERE CedulaReal =" + modelo.Funcionario.Cedula + ");"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    command = new SqlCommand(querycontra, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            contratacion.FechaIngreso = reader.GetDateTime(2);
                            contratacion.FechaCese = reader.GetDateTime(3);
                            contratacion.NumeroAnualidades = reader.GetInt32(4);
                            contratacion.NumeroAnniosServicioPublico = reader.GetInt32(5);
                            contratacion.FechaMesAumento = reader.GetString(6);
                            contratacion.CodigoPolicial = reader.GetInt32(7);
                            contratacion.EstadoMarcacion = reader.GetBoolean(8);
                            contratacion.UbicacionReal = reader.GetString(9);
                            contratacion.FechaRegimenPolicial = reader.GetDateTime(11);
                            contratacion.FechaVacaciones = reader.GetDateTime(12);
                        }
                        
                    }

                    string querydireccion = "SELECT * FROM Direccion WHERE FK_Funcionario IN (SELECT PK_Funcionario FROM Funcionario WHERE CedulaReal =" + modelo.Funcionario.Cedula + ");"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    command = new SqlCommand(querydireccion, connectionfake);

                    

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            direccion.DirExacta = reader.GetString(3);
                            direccion.IndEstDireccion = reader.GetInt32(4);
                            fkdistrito = reader.GetInt32(1);

                            string querydistrito = "SELECT * FROM Distrito WHERE PK_Distrito=" + fkdistrito; // Cambia 'tu_tabla' por el nombre de tu tabla
                            command = new SqlCommand(querydistrito, connectionfake);


                            reader.Close();
                            using (SqlDataReader readerd = command.ExecuteReader())
                            {
                                while (readerd.Read())
                                {
                                    distrito.NomDistrito = readerd.GetString(2);
                                    distrito.CodPostalDistrito = readerd.GetString(3);
                                    fkcanton = readerd.GetInt32(1);

                                    string querycanton = "SELECT * FROM Canton WHERE PK_Canton=" + fkcanton; // Cambia 'tu_tabla' por el nombre de tu tabla
                                    command = new SqlCommand(querycanton, connectionfake);
                                    readerd.Read();


                                    using (SqlDataReader readerc = command.ExecuteReader())
                                    {
                                        while (readerc.Read())
                                        {
                                            canton.NomCanton = readerc.GetString(2);
                                            canton.CodPostalCanton = reader.GetString(3);
                                            fkprovincia = readerc.GetInt32(1);

                                            string queryprovincia = "SELECT * FROM Provincia WHERE PK_Provincia=" + fkprovincia; // Cambia 'tu_tabla' por el nombre de tu tabla
                                            command = new SqlCommand(queryprovincia, connectionfake);


                                            readerc.Close();
                                            using (SqlDataReader readerp = command.ExecuteReader())
                                            {
                                                while (readerp.Read())
                                                {
                                                    provincia.NomProvincia = reader.GetString(1);
                                                }
                                                readerp.Close();
                                            }
                                            canton.Provincia = provincia;
                                        }
                                    }
                                    distrito.Canton = canton;
                                }
                                direccion.Distrito = distrito;
                            }
                        }
                    }*/
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Hi3-Error al conectar a la base de datos: {ex.Message}");
                }

            }

            modelo.Nombramiento = nombramiento;
            //modelo.DetalleContrato = contratacion;
            modelo.Puesto = nombramiento.Puesto;
            //modelo.Direccion = direccion;

            /*if (datos.ElementAt(5).Count() > 0)
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
            }*/
            return modelo;
        }

        [HttpPost]
        public ActionResult GetCantones(int idProvincia)
        {
            List<CCantonDTO> listado = new List<CCantonDTO>();
            try
            {
                var localizacion = cantones(idProvincia);

                foreach (CCantonDTO canton in localizacion)
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
                var localizacion = distritos(idCanton);

                foreach (CDistritoDTO distrito in localizacion)
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

        List<CCantonDTO> cantones(int idProvincia) {
            List<CCantonDTO> listado = new List<CCantonDTO>();
            CCantonDTO canton = new CCantonDTO();
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consult
                    string querynom = "SELECT * FROM Canton WHERE FK_Provincia IN(SELECT PK_Provincia FROM Provincia WHERE PK_Provincia = " + idProvincia + ");"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            canton.IdEntidad = reader.GetInt32(0);
                            canton.NomCanton = reader.GetString(2);
                            canton.CodPostalCanton = reader.GetString(3);
                            canton.Provincia = getProvincia(idProvincia);
                            listado.Add(canton);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"4-Error al conectar a la base de datos: {ex.Message}");
            }
            return listado;
        }

        List<CDistritoDTO> distritos(int idCanton)
        {
            List<CDistritoDTO> listado = new List<CDistritoDTO>();
            CDistritoDTO distrito = new CDistritoDTO();

            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            try
            {
                using (SqlConnection connectionfake = new SqlConnection(connectionString))
                {

                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Distrito WHERE FK_Canton IN(SELECT PK_Canton FROM Canton WHERE PK_Canton = " + idCanton + ");"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            distrito.IdEntidad = reader.GetInt32(0);

                            distrito.NomDistrito = reader.GetString(2);

                            distrito.CodPostalDistrito = reader.GetString(3);

                            distrito.Canton = getCanton(idCanton);

                            listado.Add(distrito);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"5-Error al conectar a la base de datos: {ex.Message}");
            }
            return listado;
        }

        CProvinciaDTO getProvincia(int idProvincia) {
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

        CEstadoNombramientoDTO funcEstado(int estado) {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CEstadoNombramientoDTO estadonom = new CEstadoNombramientoDTO();

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM EstadoNombramiento WHERE PK_EstadoNombramiento=" + estado; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estadonom.DesEstado = reader.GetString(1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"9-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return estadonom;
        }

        CDepartamentoDTO funcdepartamento(int fkdepartamento)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CDepartamentoDTO departamento = new CDepartamentoDTO();

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Departamento WHERE PK_Departamento=" + fkdepartamento; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departamento.NomDepartamento = reader.GetString(1);
                            departamento.IndEstDepartamento = reader.GetInt32(2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"10-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return departamento;
        }

        CUbicacionAdministrativaDTO funcubicacion(int fkubicacion)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CUbicacionAdministrativaDTO ubicacion = new CUbicacionAdministrativaDTO();
            int fkdepartamento;

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM UbicacionAdministrativa WHERE PK_UbicacionAdministrativa=" + fkubicacion; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fkdepartamento = reader.GetInt32(3);
                            ubicacion.IdEntidad = reader.GetInt32(0);
                            ubicacion.DesObservaciones = reader.GetString(6);
                            ubicacion.Departamento = funcdepartamento(fkdepartamento);
                            Session["Ubicacion"] = ubicacion.IdEntidad;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"11-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return ubicacion;
        }

        CEstadoPuestoDTO funcestadopuesto(int fkestado)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CEstadoPuestoDTO estadopdto = new CEstadoPuestoDTO();

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM EstadoPuesto WHERE PK_EstadoPuesto=" + fkestado; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estadopdto.DesEstadoPuesto = reader.GetString(1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"12-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return estadopdto;
        }

        CPuestoDTO funcpuesto(int fkpuesto)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CPuestoDTO puesto = new CPuestoDTO();
            int fkubicacion;
            int fkestadop;

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM Puesto WHERE PK_Puesto=" + fkpuesto; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fkubicacion = reader.GetInt32(1);
                            fkestadop = reader.GetInt32(2);
                            puesto.CodPuesto = reader.GetString(3);
                            puesto.PuestoConfianza = reader.GetBoolean(4);
                            puesto.ObservacionesPuesto = reader.GetString(5);
                            puesto.NivelOcupacional = reader.GetInt32(6);
                            puesto.UbicacionAdministrativa = funcubicacion(fkubicacion);
                            puesto.EstadoPuesto = funcestadopuesto(fkestadop);
                            puesto.FamiliaPuesto = funcfamiliapuesto(reader.GetInt32(7));
                            Session["FamiliaPuesto"] = puesto.FamiliaPuesto.IdEntidad;

                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"13-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return puesto;
        }

        CFamiliaPuestoDTO funcfamiliapuesto(int fkfamilia)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CFamiliaPuestoDTO familia = new CFamiliaPuestoDTO();
           

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM FamiliaPuestos WHERE PK_Familia=" + fkfamilia; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            familia.IdEntidad = reader.GetInt32(0);
                            familia.DesFamilia = reader.GetString(1);
                            familia.DesObservaciones = reader.GetString(2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"13-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return familia;
        }

        SolicitudTeletrabajoDTO descargarsolicitud(string cedula, PerfilFuncionarioVM model)
        {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            SolicitudTeletrabajoDTO solicitud = new SolicitudTeletrabajoDTO();
            CDistritoDTO distrito = new CDistritoDTO();
            int index;

            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = @"SELECT TOP 1 *
                    FROM SolicitudTeletrabajo
                    WHERE FK_Funcionario IN(SELECT PK_Funcionario FROM Funcionario WHERE IdCedulaFuncionario = @cedula)
                    ORDER BY PK_SolicitudTeletrabajo DESC"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    command.Parameters.AddWithValue("@cedula", cedula);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            index = reader.GetInt32(0);
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
                            solicitud.AprobadoJefaturaInmediata = false;
                            solicitud.AprobadoJefaturaSuperior = false;
                            solicitud.TiempoLaborarDependencia = reader.GetString(19);
                            model.ActividadesTeletrabajo = actividades(index);
                            distrito = getDistrito(solicitud.DistritoSecundario);
                            model.DistritoSeleccionado = distrito.NomDistrito;
                            model.CantonSeleccionado = distrito.Canton.NomCanton;
                            model.ProvinciaSeleccionada = distrito.Canton.Provincia.NomProvincia;
                            Session["IdSolicitud"] = index;
                            Session["SolicitudActual"] = solicitud;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"1-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return solicitud;
        }

        List<CActividadSolicitudTeletrabajoDTO> actividades(int ind) {
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

        CCatEstadoCivilDTO categoriaestado(int id) {
            string connectionString = "Server=35.239.79.131,1433;Database=SIRH;User ID=sqlserver;Password=hola1234;TrustServerCertificate=True";
            CCatEstadoCivilDTO estado = new CCatEstadoCivilDTO();


            using (SqlConnection connectionfake = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connectionfake.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión exitosa a la base de datos.");

                    // Aquí puedes ejecutar comandos SQL, por ejemplo, una consulta
                    string querynom = "SELECT * FROM CatEstadoCivil WHERE PK_CatEstadoCivil=" + id; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estado.IdEntidad = reader.GetInt32(0);
                            estado.DesEstadoCivil = reader.GetString(1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"15-Error al conectar a la base de datos: {ex.Message}");
                }
            }
            return estado;

        }

        List<CHistorialEstadoCivilDTO> historial(string cedula)
        {
            List<CHistorialEstadoCivilDTO> historial = new List<CHistorialEstadoCivilDTO>();
            CHistorialEstadoCivilDTO estado;
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
                    FROM HistorialEstadoCivil
                    WHERE FK_Funcionario IN(SELECT PK_Funcionario FROM Funcionario WHERE IdCedulaFuncionario = @cedula)"; // Cambia 'tu_tabla' por el nombre de tu tabla
                    SqlCommand command = new SqlCommand(querynom, connectionfake);
                    command.Parameters.AddWithValue("@cedula", cedula);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            estado = new CHistorialEstadoCivilDTO();
                            estado.IdEntidad = reader.GetInt32(0);
                            estado.CatEstadoCivil = categoriaestado(reader.GetInt32(1));
                            estado.FecIncio = reader.GetDateTime(3);
                            estado.FecFin = reader.GetDateTime(4);
                            historial.Add(estado);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"16-Error al conectar a la base de datos: {ex.Message}");
                }
            }
           
            return historial;
        }

    }
}
