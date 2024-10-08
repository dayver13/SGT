using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanAnualL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanAnualD PlanAnualDescarga;

        #endregion

        #region Constructor

        public CPlanAnualL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanAnualDTO ConvertirPlanADTO(PlanAnual item)
        {
            var intermedia = new CPlanAnualMetaL();
            var listaProductos = new List<CPlanAnualProductosDTO>();
            var listaMetas = new List<CPlanAnualMetaDTO>();
            // var listaMetas = intermedia.ObtenerMetasPorPlan(item.PK_PlanAnual);
            //  var listaActividades = new List<CPlanAnualActividadDTO>();

            var producto = new CPlanEstrategicoProductoDTO();
            var listaEjes = new List<CPlanEstrategicoEjeDTO>(); 

            foreach (var eje in item.PlanEstrategico.PlanEstrategicoEje.Where(Q => Q.IndEstado == 1).ToList())
            {
                listaEjes.Add(CPlanEstrategicoEjeL.ConvertirEjeADTO(eje));
            }

            foreach (var elemento in item.PlanAnualProductos.Where(Q => Q.IndEstado == 1).ToList())
            {
                producto = CPlanEstrategicoProductoL.ConvertirProductoADTO(elemento.PlanEstrategicoProducto);

                listaMetas = new List<CPlanAnualMetaDTO>();
                foreach (var meta in elemento.PlanAnualMeta.Where(Q => Q.IndEstado ==1).ToList())
                {
                    listaMetas.Add(CPlanAnualMetaL.ConvertirMetaADTO(meta));
                }

                listaProductos.Add(new CPlanAnualProductosDTO
                {
                    IdEntidad = elemento.PK_ProductoPlan,
                    Producto = producto,
                    IndEstado = elemento.IndEstado,
                    Plan = new CPlanAnualDTO { IdEntidad = elemento.PlanAnual.PK_PlanAnual},
                    ListaMetas = listaMetas
                }); 
            }

            //foreach (var producto in item.PlanAnualProductos)
            //{
            //    foreach(var actividad in meta.ListaActividades)
            //    {
            //        if (actividad.Estado.IdEntidad != 4) // Anulado
            //        {
            //            listaActividades.Add(actividad);
            //        }
            //    }
            //}

            CPlanAnualDTO respuesta = new CPlanAnualDTO
            {
                IdEntidad = item.PK_PlanAnual,
                NumeroVersion = item.NumVersion,
                NumeroVersionAnual = item.NumVersionPlanAnual,
                Nombre = item.NomPlan,
                AnnioPlanInstitucional = item.NumAnnio,
                ObjetivoE = item.ObsObjetivoEspecifico,
                Seccion = CSeccionL.ConvertirSeccionADTO(item.Seccion),
                EstadoPlan = item.EstadoPlan != null ?
                                new CEstadoPlanDTO
                                {
                                    IdEntidad = item.EstadoPlan.PK_EstadoPlan,
                                    DesEstadoPlan = item.EstadoPlan.DesEstadoPlan
                                } :
                                new CEstadoPlanDTO { IdEntidad = 0, DesEstadoPlan = "" },
                //EstadoPlanAnual = item.EstadoPlan1 != null ?
                //                new CEstadoPlanDTO
                //                {
                //                    IdEntidad = item.EstadoPlan1.PK_EstadoPlan,
                //                    DesEstadoPlan = item.EstadoPlan1.DesEstadoPlan
                //                } :
                //                 new CEstadoPlanDTO { IdEntidad = 0, DesEstadoPlan = "" },
                PlanEstrategico = item.PlanEstrategico != null ?
                                new CPlanEstrategicoDTO
                                {
                                    IdEntidad = item.PlanEstrategico.PK_PlanEstrategico,
                                    NumeroVersion = item.PlanEstrategico.NumVersion,
                                    Nombre = item.PlanEstrategico.NomPlanEstrategico,
                                    FechaFinal = Convert.ToDateTime(item.PlanEstrategico.FecFinal),
                                    FechaInicio = Convert.ToDateTime(item.PlanEstrategico.FecInicio),
                                    EstadoPlan = new CEstadoPlanDTO { DesEstadoPlan = item.PlanEstrategico.EstadoPlan.DesEstadoPlan, IdEntidad = item.PlanEstrategico.EstadoPlan.PK_EstadoPlan },
                                    ListaEjes = listaEjes 
                                } :
                                new CPlanEstrategicoDTO { IdEntidad = 0, NumeroVersion = 0, Nombre = "", FechaFinal = new DateTime(), FechaInicio = new DateTime() },
                //ListaMetas = listaMetas,
                ListaProductos=listaProductos
               // ListaActividades = listaActividades
            };
            return respuesta;
        }

        internal static PlanAnual ConvertirPlanDTOaDatos(CPlanAnualDTO item)
        {

            PlanAnual respuesta = new PlanAnual
            {
                PK_PlanAnual = item.IdEntidad,
                NomPlan=item.Nombre,
                NumVersion= Convert.ToInt32(item.NumeroVersion),
                NumAnnio=Convert.ToInt32(item.AnnioPlanInstitucional),
                ObsObjetivoEspecifico=item.ObjetivoE,
                NumVersionPlanAnual = Convert.ToInt32(item.NumeroVersionAnual),
            };
            return respuesta;
        }

        public CBaseDTO AgregarPlan(CPlanAnualDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CSeccionD entidadSeccion = new CSeccionD(contexto);
                CEstadoPlanD entidadestado = new CEstadoPlanD(contexto);
                CPlanEstrategicoD entidadPlanEstrategico = new CPlanEstrategicoD(contexto);
                
                PlanAnualDescarga = new CPlanAnualD(contexto);

                var datoplan = new PlanAnual();
                datoplan = ConvertirPlanDTOaDatos(plan);
                if (plan.Seccion != null)
                {
                    datoplan.Seccion = entidadSeccion.CargarSeccionPorID(plan.Seccion.IdEntidad);
                }
                if (plan.EstadoPlan != null)
                {
                    datoplan.EstadoPlan = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlan.IdEntidad);
                }
                //
                //if (plan.EstadoPlanAnual != null)
                //{
                //    datoplan.EstadoPlan1 = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlanAnual.IdEntidad);
                //}
                //
                if (plan.PlanEstrategico != null)
                {
                    datoplan.PlanEstrategico = entidadPlanEstrategico.ObtenerPlan(plan.PlanEstrategico.IdEntidad);
                }

                var respuesta = PlanAnualDescarga.GuardarPlan(datoplan);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar el plan institucional");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }


        public CBaseDTO ActualizarPlan(CPlanAnualDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CSeccionD entidadSeccion = new CSeccionD(contexto);
                CEstadoPlanD entidadestado = new CEstadoPlanD(contexto);
                CPlanEstrategicoD entidadPlanEstrategico = new CPlanEstrategicoD(contexto);
                //-----
                PlanAnualDescarga = new CPlanAnualD(contexto);

                var datoplan = new PlanAnual();
                datoplan = ConvertirPlanDTOaDatos(plan);
                datoplan.PK_PlanAnual = plan.IdEntidad;
                if (plan.Seccion != null)
                {
                    datoplan.Seccion = entidadSeccion.CargarSeccionPorID(plan.Seccion.IdEntidad);
                }
                if (plan.EstadoPlan != null)
                {
                    datoplan.EstadoPlan = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlan.IdEntidad);
                }

                if (plan.PlanEstrategico != null)
                {
                    datoplan.PlanEstrategico = entidadPlanEstrategico.ObtenerPlan(plan.PlanEstrategico.IdEntidad);
                }
                var respuesta = PlanAnualDescarga.ActualizarPlan(datoplan);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo actulizar el plan institucional");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CPlanAnualDTO CargarPlanPorId(int idPlan)
        {
            PlanAnualDescarga = new CPlanAnualD(contexto);
            var item = PlanAnualDescarga.ObtenerPlan(idPlan);
            return ConvertirPlanADTO(item);
        }


        public List<CBaseDTO> BuscarPlanAnual(CPlanAnualDTO plan, CSeccionDTO seccion)            
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            CPlanAnualD intermedio = new CPlanAnualD(contexto);
            
            List<PlanAnual> datosPlanes = new List<PlanAnual>();
            List<object> parametros = new List<object>();
            List<string> codigos = new List<string>();
            CRespuestaDTO resultado = new CRespuestaDTO { Codigo = -1 };

            bool buscar = true;

            if (plan.Nombre != null)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanAnual(datosPlanes, plan.Nombre, "Nombre"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanAnual>)resultado.Contenido;
                else
                    buscar = false;
            }
            if (plan.ObjetivoE != null && buscar)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanAnual(datosPlanes, plan.ObjetivoE, "Objetivo"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanAnual>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (plan.EstadoPlan != null && buscar)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanAnual(datosPlanes, plan.EstadoPlan, "Estado"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanAnual>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (plan.AnnioPlanInstitucional > 0 && buscar)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanAnual(datosPlanes, plan.AnnioPlanInstitucional, "Año"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanAnual>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (seccion != null && seccion.IdEntidad > 0 && buscar)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanAnual(datosPlanes, seccion.IdEntidad, "Sección"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanAnual>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (datosPlanes.Count > 0 && buscar)
            {
                for (int i = 0; i < datosPlanes.Count; i++)
                {
                    var planDTO = ConvertirPlanADTO(datosPlanes[i]);
                    respuesta.Add(planDTO);
                }
            }
            else
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontraron resultados para los parámetros especificados." });
            }
            return respuesta;
        }

        public CBaseDTO EnlazarProductoAlPlanAnual(CPlanEstrategicoProductoDTO producto, CPlanAnualDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                CPlanEstrategicoProductoD productoDescarga = new CPlanEstrategicoProductoD(contexto);
                CPlanAnualD planDescarga = new CPlanAnualD(contexto);

                var datoProducto = CPlanEstrategicoProductoL.ConvertirProductoDTOaDatos(producto);
                var datoPlan = new PlanAnual();
                datoPlan = ConvertirPlanDTOaDatos(plan);

                datoProducto.PK_Producto = producto.IdEntidad; // IMPORTANTE
                datoPlan.PK_PlanAnual = plan.IdEntidad; // IMPORTANTE

                var respuesta = planDescarga.EnlazarProductoAlPlanAnual(datoProducto,datoPlan);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo enlazar el producto");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }
        public CBaseDTO DesenlazarProductoAlPlanAnual(CPlanAnualProductosDTO producto)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanAnualD planDescarga = new CPlanAnualD(contexto);

                //CPlanEstrategicoProductoD productoDescarga = new CPlanEstrategicoProductoD(contexto);
                //var datoProducto = CPlanEstrategicoProductoL.ConvertirProductoDTOaDatos(producto);
                //var datoPlan = new PlanAnual();
                //datoPlan = ConvertirPlanDTOaDatos(plan);

                //datoProducto.PK_Producto = producto.IdEntidad; // IMPORTANTE
                //datoPlan.PK_PlanAnual = plan.IdEntidad; // IMPORTANTE

                //var respuesta = planDescarga.DesenlazarProductoAlPlanAnual(datoProducto, datoPlan);

                var respuesta = planDescarga.DesenlazarProductoAlPlanAnual(producto.IdEntidad);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo desenlazar el producto");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }
        public CBaseDTO ModificarEstadoPlan(CPlanAnualDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();                
                CEstadoPlanD entidadestado = new CEstadoPlanD(contexto);
                PlanAnualDescarga = new CPlanAnualD(contexto);

                var datoplan = ConvertirPlanDTOaDatos(plan);

                if (plan.EstadoPlan != null)
                {
                    datoplan.EstadoPlan = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlan.IdEntidad);
                }
                var respuesta = PlanAnualDescarga.ModificarEstadoPlan(datoplan);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo remitir el Plan Operativo Institucional");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        #endregion
    }
}