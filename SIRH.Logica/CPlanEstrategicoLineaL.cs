using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanEstrategicoLineaL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanEstrategicoLineaD lineaDescarga;

        #endregion

        #region Constructor

        public CPlanEstrategicoLineaL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanEstrategicoLineaDTO ConvertirLineaADTO(PlanEstrategicoLinea item)
        {
            var listaProductos = new List<CPlanEstrategicoProductoDTO>();
            foreach (var producto in item.PlanEstrategicoProducto.Where(Q => Q.IndEstado == 1).ToList())
            {
                listaProductos.Add(CPlanEstrategicoProductoL.ConvertirProductoADTO(producto));
            }
            
            CPlanEstrategicoLineaDTO respuesta = new CPlanEstrategicoLineaDTO
            {
                IdEntidad = item.PK_Linea,
                NumeroLinea = item.NumLinea,
                Descripcion = item.DesLinea,
                EstadoLinea = item.IndEstado,
                Eje = item.PlanEstrategicoEje != null ?
                                new CPlanEstrategicoEjeDTO {
                                    IdEntidad = item.PlanEstrategicoEje.PK_Eje,
                                    NumeroEje = item.PlanEstrategicoEje.NumEje,
                                    Descripcion =item.PlanEstrategicoEje.DesEje,
                                    EstadoEje = item.IndEstado
                                } :
                                new CPlanEstrategicoEjeDTO { IdEntidad = 0, NumeroEje = 0, Descripcion="" },

               ListaProductos = listaProductos
            };

            return respuesta;
        }

        internal static PlanEstrategicoLinea ConvertirLineaDTOaDatos(CPlanEstrategicoLineaDTO item)
        {
            var respuesta = new PlanEstrategicoLinea
            {
                NumLinea = Convert.ToInt32(item.NumeroLinea),
                DesLinea = item.Descripcion,
                IndEstado = item.EstadoLinea
            };
            return respuesta;
        }

        public CBaseDTO AgregarLinea(CPlanEstrategicoLineaDTO linea)
        {
            try
            {
                //
                CBaseDTO resultado = new CBaseDTO();
                CPlanEstrategicoEjeD entidadEje = new CPlanEstrategicoEjeD(contexto);
                //

                lineaDescarga = new CPlanEstrategicoLineaD(contexto);
                var datoLinea = new PlanEstrategicoLinea();
                datoLinea = ConvertirLineaDTOaDatos(linea);


                // Validar de que exista un eje  padre
                if (linea.Eje != null)
                {
                    datoLinea.PlanEstrategicoEje = entidadEje.ObtenerEje(linea.Eje.IdEntidad);
                }

                var respuesta = lineaDescarga.GuardarLinea(datoLinea);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO { 
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar la linea");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }          
        }

        //NUEVO

        public List<CPlanEstrategicoLineaDTO> CargarLineasPlan(int idPlan)
        {
            List<CPlanEstrategicoLineaDTO> resultado = new List<CPlanEstrategicoLineaDTO>();
            lineaDescarga = new CPlanEstrategicoLineaD(contexto);
            var item = lineaDescarga.CargarLineasPlan(idPlan);
            foreach (var aux in item)
            {
                resultado.Add(ConvertirLineaADTO(aux));
            }
            return resultado;
        }

        //

        public List<CBaseDTO> CargarLineasEje(int idEje)
        {
            var resultado = new List<CBaseDTO>();
            lineaDescarga = new CPlanEstrategicoLineaD(contexto);
            var item = lineaDescarga.CargarLineas(idEje);
            foreach (var aux in item)
            { 
                resultado.Add(ConvertirLineaADTO(aux));
            }
            return resultado;
        }

        public CPlanEstrategicoLineaDTO CargarLineaPorId(int idLinea)
        {
            lineaDescarga = new CPlanEstrategicoLineaD(contexto);
            var item = lineaDescarga.ObtenerLinea(idLinea);
            var resultado = ConvertirLineaADTO(item);
            resultado.Eje = CPlanEstrategicoEjeL.ConvertirEjeADTO(item.PlanEstrategicoEje);
            return resultado;
        }

        public CBaseDTO DeleteLinea(CPlanEstrategicoLineaDTO linea)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                lineaDescarga = new CPlanEstrategicoLineaD(contexto);
                var datoLinea = ConvertirLineaDTOaDatos(linea);
                datoLinea.PK_Linea = linea.IdEntidad;

                var respuesta = lineaDescarga.DeleteLinea(datoLinea);

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
                    throw new Exception("No se pudo remover la linea");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO ActualizarLinea(CPlanEstrategicoLineaDTO linea)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanEstrategicoEjeD entidadEje = new CPlanEstrategicoEjeD(contexto);

                lineaDescarga = new CPlanEstrategicoLineaD(contexto);
                var datoLinea = ConvertirLineaDTOaDatos(linea);

                datoLinea.PK_Linea = linea.IdEntidad;

                if (linea.Eje != null)
                {
                    datoLinea.PlanEstrategicoEje = entidadEje.ObtenerEje(linea.Eje.IdEntidad);
                }

                var respuesta = lineaDescarga.ActualizarLinea(datoLinea);

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
                    throw new Exception("No se pudo actualizar la Línea");
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
