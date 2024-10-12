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
    }
}