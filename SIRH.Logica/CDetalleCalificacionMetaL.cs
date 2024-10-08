using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CDetalleCalificacionMetaL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CDetalleCalificacionMetaL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CDetalleCalificacionMetaDTO ConvertirDatoADto(DetalleCalificacionMeta item)
        {
            return new CDetalleCalificacionMetaDTO
            {
                IdEntidad = item.PK_DetalleMeta,
                PorNota = item.PorNota,
                PorNotaOriginal = item.PorNotaOriginal,
                Meta = CMetaIndividualCalificacionL.ConvertirDatosMetaADto(item.MetaIndividualCalificacion)
            };
        }

        internal static DetalleCalificacionMeta ConvertirDTOADatos(CDetalleCalificacionMetaDTO item)
        {
            return new DetalleCalificacionMeta
            {
                PK_DetalleMeta  = item.IdEntidad,
                PorNota = item.PorNota,
                PorNotaOriginal = item.PorNotaOriginal
            };
        }

        public CBaseDTO GuardarMeta(CDetalleCalificacionMetaDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CDetalleCalificacionMetaD intermedio = new CDetalleCalificacionMetaD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                DetalleCalificacionMeta datos = ConvertirDTOADatos(registro);

                //// Calificacion Nombramiento
                var entidadCal = intermedioCal.CargarCalificacionNombramientoPorID(registro.Calificacion.IdEntidad);
                if (entidadCal != null)
                    datos.CalificacionNombramiento = entidadCal;
                else
                    throw new Exception("No se encontró la información de la Calificación. No se pudo registrar las Metas" );
                             
                datos.PorNotaOriginal = datos.PorNota;

                var insertaCN = intermedio.AgregarMeta(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_DetalleMeta;
                    respuesta=registro;
                }
                else
                {
                    throw new Exception(((CErrorDTO)insertaCN.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {              
                respuesta=new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                };
            }

            return respuesta;
        }

        public CBaseDTO ModificarMeta(CDetalleCalificacionMetaDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CDetalleCalificacionMetaD intermedio = new CDetalleCalificacionMetaD(contexto);

                DetalleCalificacionMeta datos = ConvertirDTOADatos(registro);

                var modificar = intermedio.EditarMeta(datos);

                //pregunto si da error
                if (modificar.Codigo > 0)
                    respuesta = new CBaseDTO { IdEntidad = registro.IdEntidad };
                else
                    throw new Exception(((CErrorDTO)modificar.Contenido).MensajeError);
            }
            catch (Exception error)
            {
                return new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                };
                // respuesta.Add(((CErrorDTO)((CRespuestaDTO)respuesta[0]).Contenido));
            }

            return respuesta;
        }
        
        #endregion
    }
}