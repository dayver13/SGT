using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanAnualMetaL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanAnualMetaD metaDescarga;

        #endregion

        #region Constructor

        public CPlanAnualMetaL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanAnualMetaDTO ConvertirMetaADTO(PlanAnualMeta item)
        {
            var listaActividades = new List<CPlanAnualActividadDTO>();
            foreach (var actividad in item.PlanAnualActividad.Where(Q=> Q.EstadoActividadPlan.PK_Estado != 4))
            {
                listaActividades.Add(CPlanAnualActividadL.ConvertirActividadADTO(actividad));
            }

            float contadorValores = 0;

            //Valor de cada una
            if (listaActividades != null && listaActividades.Count() > 0)
            {
                contadorValores = 0;
                foreach (var x in listaActividades)
                {
                    if (x.PorcentajeRealActInstitucional >= 100)
                    {
                        contadorValores = contadorValores +  x.PorcentajeMeta;
                    }
                }

            }
            
            CPlanAnualMetaDTO respuesta = new CPlanAnualMetaDTO
            {
                IdEntidad = item.PK_Meta,
                Descripcion = item.DesMeta,
                PorcentajeMeta = (float)item.PorPeso,
                EstadoMeta = item.IndEstado,
                Producto = item.PlanAnualProductos.PlanEstrategicoProducto != null ?
                                new CPlanEstrategicoProductoDTO
                                {
                                    IdEntidad = item.PlanAnualProductos.PlanEstrategicoProducto.PK_Producto,
                                    Descripcion = item.PlanAnualProductos.PlanEstrategicoProducto.DesProducto,
                                    PrioridadProducto = item.PlanAnualProductos.PlanEstrategicoProducto.IndPrioridad,
                                    SituacionActual = item.PlanAnualProductos.PlanEstrategicoProducto.ObsSituacionActual,
                                    ResultadoEsperado = item.PlanAnualProductos.PlanEstrategicoProducto.ObsResultadoEsperado,
                                    EstadoProducto = item.PlanAnualProductos.PlanEstrategicoProducto.IndEstado
                                } :
                                 new CPlanEstrategicoProductoDTO { IdEntidad = 0, Descripcion = "", PrioridadProducto = 0, SituacionActual = "", ResultadoEsperado = "", EstadoProducto = 0 },

                PlanAnual = item.PlanAnualProductos.PlanAnual != null ?
                                new CPlanAnualDTO
                                {
                                    IdEntidad = item.PlanAnualProductos.PlanAnual.PK_PlanAnual,
                                    NumeroVersion = item.PlanAnualProductos.PlanAnual.NumVersion,
                                    NumeroVersionAnual = item.PlanAnualProductos.PlanAnual.NumVersionPlanAnual,
                                    Nombre = item.PlanAnualProductos.PlanAnual.NomPlan,
                                    AnnioPlanInstitucional = item.PlanAnualProductos.PlanAnual.NumAnnio,
                                    ObjetivoE = item.PlanAnualProductos.PlanAnual.ObsObjetivoEspecifico,
                                    Seccion = item.PlanAnualProductos.PlanAnual.Seccion != null ?
                                        new CSeccionDTO
                                        {
                                            IdEntidad = item.PlanAnualProductos.PlanAnual.Seccion.PK_Seccion,
                                            NomSeccion = item.PlanAnualProductos.PlanAnual.Seccion.NomSeccion
                                        } :
                                         new CSeccionDTO { IdEntidad = 0, NomSeccion = "" },

            EstadoPlan = item.PlanAnualProductos.PlanAnual.EstadoPlan != null ?
                                new CEstadoPlanDTO
                                {
                                    IdEntidad = item.PlanAnualProductos.PlanAnual.EstadoPlan.PK_EstadoPlan,
                                    DesEstadoPlan = item.PlanAnualProductos.PlanAnual.EstadoPlan.DesEstadoPlan
                                } :
                                // new CEstadoPlanDTO { IdEntidad = 0, DesEstadoPlan = "" },
                                //    EstadoPlanAnual = item.DetallePlanEstrategicoProductos.PlanAnual.EstadoPlan1 != null ?
                                //new CEstadoPlanDTO
                                //{
                                //    IdEntidad = item.DetallePlanEstrategicoProductos.PlanAnual.EstadoPlan1.PK_EstadoPlan,
                                //    DesEstadoPlan = item.DetallePlanEstrategicoProductos.PlanAnual.EstadoPlan1.DesEstadoPlan
                                //} :
                                 new CEstadoPlanDTO { IdEntidad = 0, DesEstadoPlan = "" },
            PlanEstrategico = item.PlanAnualProductos.PlanAnual.PlanEstrategico != null ?
                                new CPlanEstrategicoDTO
                                {
                                    IdEntidad = item.PlanAnualProductos.PlanAnual.PlanEstrategico.PK_PlanEstrategico,
                                    NumeroVersion = item.PlanAnualProductos.PlanAnual.PlanEstrategico.NumVersion,
                                    Nombre = item.PlanAnualProductos.PlanAnual.PlanEstrategico.NomPlanEstrategico,
                                    FechaFinal = Convert.ToDateTime(item.PlanAnualProductos.PlanAnual.PlanEstrategico.FecFinal),
                                    FechaInicio = Convert.ToDateTime(item.PlanAnualProductos.PlanAnual.PlanEstrategico.FecInicio),
                                    EstadoPlan = new CEstadoPlanDTO { DesEstadoPlan = item.PlanAnualProductos.PlanAnual.PlanEstrategico.EstadoPlan.DesEstadoPlan, IdEntidad = item.PlanAnualProductos.PlanAnual.PlanEstrategico.EstadoPlan.PK_EstadoPlan },

                                } :
                                new CPlanEstrategicoDTO { IdEntidad = 0, NumeroVersion = 0, Nombre = "", FechaFinal = new DateTime(), FechaInicio = new DateTime() },
                                    ListaMetas = new List<CPlanAnualMetaDTO>(),
                                    ListaProductos = new List<CPlanAnualProductosDTO>(),
                                    ListaActividades = new List<CPlanAnualActividadDTO>()
                                } :
                                new CPlanAnualDTO
                                {
                                    IdEntidad = 0,
                                    NumeroVersion = 0,
                                    NumeroVersionAnual = 0,
                                    Nombre = "",
                                    AnnioPlanInstitucional = 0,
                                    ObjetivoE = "",
                                    Seccion = null
                                },

                ListaActividades = listaActividades,
                PorcentajeRealMetaInstitucional = contadorValores
                //aqui va la referencia del poi (padre)

            };
            return respuesta;
        }

        public List<CPlanAnualMetaDTO> ObtenerMetasPorPlan(int idPlan)
        {
            List<PlanAnualMeta> metas = null;
            List<CPlanAnualMetaDTO> listaMetas = new List<CPlanAnualMetaDTO>();
            CPlanAnualD PlanAnualDescarga = new CPlanAnualD(contexto);
            metaDescarga = new CPlanAnualMetaD(contexto);
            List<PlanAnualProductos> intermedia = PlanAnualDescarga.ObtenerProductoPlanAnual(idPlan);
            if(intermedia == null)
            {
                throw new Exception("El plan institucional no existe");
            }
            for(int i = 0; i < intermedia.Count(); i++)
            {
                metas = metaDescarga.ObtenerMetaPorPlan(intermedia[i].PK_ProductoPlan);
                if(metas != null)
                {
                    for(int j = 0; j < metas.Count(); j++)
                    {
                        listaMetas.Add(ConvertirMetaADTO(metas[j]));
                    }
                }
            }
            return listaMetas;
        }

        internal static PlanAnualMeta ConvertirMetaDTOaDatos(CPlanAnualMetaDTO item)
        {
            PlanAnualMeta respuesta = new PlanAnualMeta
            {
                //PK_Meta = item.IdEntidad, // Tuve que agregarlo porque llega un 0 a datos
                DesMeta = item.Descripcion,
                PorPeso = (decimal) item.PorcentajeMeta,
                IndEstado = item.EstadoMeta
            };
            return respuesta;
        }

        public CBaseDTO AgregarMeta(CPlanAnualMetaDTO meta, CPlanAnualDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanAnualD entidadPlan = new CPlanAnualD(contexto);
                metaDescarga = new CPlanAnualMetaD(contexto);
                var datoMeta = new PlanAnualMeta();
                datoMeta = ConvertirMetaDTOaDatos(meta);
                datoMeta.PlanAnualProductos = entidadPlan.ObtenerProductoPlanAnual(plan.IdEntidad).FirstOrDefault();
                var respuesta = 0;
                respuesta = metaDescarga.GuardarMeta(datoMeta);
              
                if (respuesta > 0)
                {
                    return new CRespuestaDTO { 
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar la meta");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }          
        }

        //NUEVO
        public CBaseDTO DeleteMeta(CPlanAnualMetaDTO meta)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                metaDescarga = new CPlanAnualMetaD(contexto);
                var datoMeta = new PlanAnualMeta();
                datoMeta = ConvertirMetaDTOaDatos(meta);
                datoMeta.PK_Meta = meta.IdEntidad;


                var respuesta = metaDescarga.DeleteMeta(datoMeta);

                if (respuesta > 0 || meta.ListaActividades.Count() > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo remover la meta");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        //

        public CBaseDTO UpdateMeta(CPlanAnualMetaDTO meta)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                metaDescarga = new CPlanAnualMetaD(contexto);
                var datoMeta = new PlanAnualMeta();
                datoMeta= ConvertirMetaDTOaDatos(meta);
                datoMeta.PK_Meta = meta.IdEntidad; // IMPORTANTE

                var respuesta = metaDescarga.UpdateMeta(datoMeta);

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
                    throw new Exception("No se pudo actualizar la Meta");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }



        public CPlanAnualMetaDTO CargarMetaPorId(int idMeta)
        {
            CPlanAnualMetaDTO resultado = new CPlanAnualMetaDTO();
            metaDescarga = new CPlanAnualMetaD(contexto);
            var item = metaDescarga.ObtenerMeta(idMeta);
            resultado = ConvertirMetaADTO(item);
            return resultado;
        }

        #endregion
    }
}
