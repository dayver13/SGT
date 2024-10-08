using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanEstrategicoAccionL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanEstrategicoAccionD accionDescarga;

        #endregion

        #region Constructor

        public CPlanEstrategicoAccionL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanEstrategicoAccionDTO ConvertirAccionADTO(PlanEstrategicoAccion item)
        {

            CPlanEstrategicoAccionDTO respuesta = new CPlanEstrategicoAccionDTO
            {
                IdEntidad = item.PK_AccionEstrategica,
                Descripcion = item.DesAccionEstrategica,
                DescripcionPOI = item.DesAccionEstrategica,
                Indicadores = item.IndAccionEstrategica,
                AnioInicioEsperado = item.NumAnioInicioEsperado,
                AnioFinalEsperado = item.NumAnioFinalEsperado,
                AnioFinalOficial = (int) item.NumAnioFinalOficial,
                EstadoAccionEstrategica = item.IndEstado,

                Producto = item.PlanEstrategicoProducto != null ?
                                new CPlanEstrategicoProductoDTO {
                                    IdEntidad = item.PlanEstrategicoProducto.PK_Producto,
                                    Descripcion = item.PlanEstrategicoProducto.DesProducto,
                                    PrioridadProducto =item.PlanEstrategicoProducto.IndPrioridad,
                                    SituacionActual = item.PlanEstrategicoProducto.ObsSituacionActual,
                                    ResultadoEsperado = item.PlanEstrategicoProducto.ObsResultadoEsperado,
                                    EstadoProducto = item.PlanEstrategicoProducto.IndEstado
                                } :
                                 new CPlanEstrategicoProductoDTO { IdEntidad = 0,  Descripcion="", PrioridadProducto = 0,SituacionActual = "",ResultadoEsperado= "", EstadoProducto = 0 },
            };
            return respuesta;
        }

        internal static PlanEstrategicoAccion ConvertirAccionDTOaDatos(CPlanEstrategicoAccionDTO item)
        {
            PlanEstrategicoAccion respuesta = new PlanEstrategicoAccion
            {
                //PK_AccionEstrategica = item.IdEntidad, // Tuve que agregarlo porque llega un 0 a datos
                DesAccionEstrategica = item.Descripcion,
                IndAccionEstrategica = item.Indicadores,
                NumAnioInicioEsperado = item.AnioInicioEsperado,
                NumAnioFinalEsperado = item.AnioFinalEsperado,
                NumAnioFinalOficial = item.AnioFinalOficial,
                IndEstado = item.EstadoAccionEstrategica
            };
            return respuesta;
        }

        public CBaseDTO AgregarAccion(CPlanEstrategicoAccionDTO accion)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanEstrategicoProductoD entidadProducto = new CPlanEstrategicoProductoD(contexto);

                accionDescarga = new CPlanEstrategicoAccionD(contexto);
                var datoAccion = ConvertirAccionDTOaDatos(accion);

                // Validar de que exista un producto padre
                if (accion.Producto != null)
                {
                    datoAccion.PlanEstrategicoProducto = entidadProducto.ObtenerProducto(accion.Producto.IdEntidad);
                }

                var respuesta = accionDescarga.GuardarAccionEstrategica(datoAccion);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO { 
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar la Acción Estratégica");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }          
        }

        //NUEVO
        public CBaseDTO DeleteAccion(CPlanEstrategicoAccionDTO accion)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                accionDescarga = new CPlanEstrategicoAccionD(contexto);
                var datoAccion = ConvertirAccionDTOaDatos(accion);
                datoAccion.PK_AccionEstrategica = accion.IdEntidad;
                
                var respuesta = accionDescarga.DeleteAccionEstrategica(datoAccion);

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
                    throw new Exception("No se pudo anular la Acción Estratégica");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        //

        public CBaseDTO UpdateAccionEstrategica(CPlanEstrategicoAccionDTO accion)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                accionDescarga = new CPlanEstrategicoAccionD(contexto);
                var datoAccion = ConvertirAccionDTOaDatos(accion);
                datoAccion.PK_AccionEstrategica = accion.IdEntidad; // IMPORTANTE

                var respuesta = accionDescarga.UpdateAccionEstrategica(datoAccion);

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
                    throw new Exception("No se pudo actualizar la Acción Estratégica");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> CargarAccionesProducto(int idProducto)
        {
            List<CBaseDTO> resultado = new List<CBaseDTO>();
            accionDescarga = new CPlanEstrategicoAccionD(contexto);
            var item = accionDescarga.CargarAccionesEstrategicas(idProducto);
            foreach (var aux in item)
            { 
                resultado.Add(ConvertirAccionADTO(aux));
            }
            return resultado;
        }

        public CPlanEstrategicoAccionDTO CargarAccionPorId(int idAccion)
        {
            CPlanEstrategicoAccionDTO resultado = new CPlanEstrategicoAccionDTO();
            accionDescarga = new CPlanEstrategicoAccionD(contexto);
            var item = accionDescarga.ObtenerAccionEstrategica(idAccion);

            var datoAccion = ConvertirAccionADTO(item);

            datoAccion.Producto = CPlanEstrategicoProductoL.ConvertirProductoADTO(item.PlanEstrategicoProducto);
            datoAccion.Producto.Linea = CPlanEstrategicoLineaL.ConvertirLineaADTO(item.PlanEstrategicoProducto.PlanEstrategicoLinea);
            datoAccion.Producto.Linea.Eje = CPlanEstrategicoEjeL.ConvertirEjeADTO(item.PlanEstrategicoProducto.PlanEstrategicoLinea.PlanEstrategicoEje);
            datoAccion.Producto.Linea.Eje.PlanEstrategico = CPlanEstrategicoL.ConvertirPlanADTO(item.PlanEstrategicoProducto.PlanEstrategicoLinea.PlanEstrategicoEje.PlanEstrategico);

            return datoAccion;
        }

        #endregion
    }
}
