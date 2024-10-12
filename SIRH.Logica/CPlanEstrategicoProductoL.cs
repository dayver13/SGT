using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanEstrategicoProductoL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanEstrategicoProductoD productoDescarga;

        #endregion

        #region Constructor

        public CPlanEstrategicoProductoL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanEstrategicoProductoDTO ConvertirProductoADTO(PlanEstrategicoProducto item)
        {
            var listaAcciones = new List<CPlanEstrategicoAccionDTO>();  //Hacer cuando se tengan los acciones.
            foreach (var accion in item.PlanEstrategicoAccion)
            {
                listaAcciones.Add(CPlanEstrategicoAccionL.ConvertirAccionADTO(accion));
            }

            CPlanEstrategicoProductoDTO respuesta = new CPlanEstrategicoProductoDTO
            {
                IdEntidad = item.PK_Producto,
                PrioridadProducto = item.IndPrioridad,
                Descripcion = item.DesProducto,
                EstadoProducto = item.IndEstado,
                SituacionActual = item.ObsSituacionActual,
                ResultadoEsperado = item.ObsResultadoEsperado,
                Linea = item.PlanEstrategicoLinea != null ?
                                new CPlanEstrategicoLineaDTO {
                                    IdEntidad = item.PlanEstrategicoLinea.PK_Linea,
                                    NumeroLinea = item.PlanEstrategicoLinea.NumLinea,
                                    Descripcion =item.PlanEstrategicoLinea.DesLinea,
                                    EstadoLinea = item.IndEstado
                                } :
                                 new CPlanEstrategicoLineaDTO { IdEntidad = 0, NumeroLinea = 0, Descripcion="", EstadoLinea=0 },

                                
               ListaAcciones = listaAcciones
            };
            return respuesta;
        }

        internal static PlanEstrategicoProducto ConvertirProductoDTOaDatos(CPlanEstrategicoProductoDTO item)
        {
            var respuesta = new PlanEstrategicoProducto
            {
                //PK_Producto = item.IdEntidad, // Tuve que agregarlo porque llegaba un 0 a datos
                IndPrioridad = Convert.ToInt32(item.PrioridadProducto),
                DesProducto = item.Descripcion,
                IndEstado = item.EstadoProducto,
                ObsSituacionActual = item.SituacionActual,
                ObsResultadoEsperado = item.ResultadoEsperado
            };
            return respuesta;
        }

        public CBaseDTO AgregarProducto(CPlanEstrategicoProductoDTO producto)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanEstrategicoLineaD entidadLinea = new CPlanEstrategicoLineaD(contexto);

                productoDescarga = new CPlanEstrategicoProductoD(contexto);
                var datoProducto = ConvertirProductoDTOaDatos(producto);

                // Validar de que exista una linea padre
                if (producto.Linea != null)
                {
                    datoProducto.PlanEstrategicoLinea = entidadLinea.ObtenerLinea(producto.Linea.IdEntidad);
                }

                var respuesta = productoDescarga.GuardarProducto(datoProducto);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO { 
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar el producto");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }          
        }

        //NUEVO
        public CBaseDTO UpdateProducto(CPlanEstrategicoProductoDTO producto)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                productoDescarga = new CPlanEstrategicoProductoD(contexto);
                var datoProducto = ConvertirProductoDTOaDatos(producto);
                datoProducto.PK_Producto = producto.IdEntidad; // IMPORTANTE
                
                var respuesta = productoDescarga.UpdateProducto(datoProducto);

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
                    throw new Exception("No se pudo actualizar el producto");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO DeleteProducto(CPlanEstrategicoProductoDTO producto)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                productoDescarga = new CPlanEstrategicoProductoD(contexto);
                var datoProducto = ConvertirProductoDTOaDatos(producto);
                datoProducto.PK_Producto = producto.IdEntidad;
                var respuesta = productoDescarga.DeleteProducto(datoProducto);
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
                    throw new Exception("No se pudo remover el producto");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> CargarProductosLinea(int idLinea)
        {
            List<CBaseDTO> resultado = new List<CBaseDTO>();
            productoDescarga = new CPlanEstrategicoProductoD(contexto);
            var item = productoDescarga.CargarProductos(idLinea);
            foreach (var aux in item)
            { 
                resultado.Add(ConvertirProductoADTO(aux));
            }
            return resultado;
        }

        public CBaseDTO CargarProductoPorId(int idProducto)
        {
            productoDescarga = new CPlanEstrategicoProductoD(contexto);
            var item = productoDescarga.ObtenerProducto(idProducto);
            var datoProducto = ConvertirProductoADTO(item);

            datoProducto.Linea.Eje = CPlanEstrategicoEjeL.ConvertirEjeADTO(item.PlanEstrategicoLinea.PlanEstrategicoEje);
            datoProducto.Linea.Eje.PlanEstrategico = CPlanEstrategicoL.ConvertirPlanADTO(item.PlanEstrategicoLinea.PlanEstrategicoEje.PlanEstrategico);

            return datoProducto;
        }

        #endregion
    }
}
