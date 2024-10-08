using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CDetalleCalificacionAutoEvaluacionL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CDetalleCalificacionAutoEvaluacionL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CDetalleCalificacionAutoEvaluacionDTO ConvertirDatoADto(DetalleCalificacionAutoEvaluacion item)
        {
            return new CDetalleCalificacionAutoEvaluacionDTO
            {
                IdEntidad = item.PK_CalificacionAutoEvaluacion,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                Tipo = new CTipoAutoEvaluacionDTO
                {
                    IdEntidad = item.TipoAutoevaluacion.PK_Tipo,
                    DesTipo = item.TipoAutoevaluacion.DesTipo,
                    DesDetalle = item.TipoAutoevaluacion.DesDetalle
                }
            };
        }

        internal static DetalleCalificacionAutoEvaluacion ConvertirDTOADatos(CDetalleCalificacionAutoEvaluacionDTO item)
        {
            return new DetalleCalificacionAutoEvaluacion
            {
                PK_CalificacionAutoEvaluacion  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota
            };
        }

        public List<CBaseDTO> GuardarAutoEvaluacion(CDetalleCalificacionAutoEvaluacionDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CDetalleCalificacionAutoEvaluacionD intermedio = new CDetalleCalificacionAutoEvaluacionD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                DetalleCalificacionAutoEvaluacion datos = ConvertirDTOADatos(registro);

                //// Calificacion Nombramiento
                var entidadCal = intermedioCal.CargarCalificacionNombramientoPorID(registro.Calificacion.IdEntidad);
                if (entidadCal != null)
                    datos.CalificacionNombramiento = entidadCal;
                else
                    throw new Exception("No se encontró la información de la Calificación. No se pudo registrar las AutoEvaluacions" );

                // Tipo 
                CTipoAutoEvaluacionD intermedioTipo = new CTipoAutoEvaluacionD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.Tipo.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoAutoevaluacion = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo de AutoEvaluacion");

                var insertaCN = intermedio.AgregarAutoEvaluacion(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionAutoEvaluacion;
                    respuesta.Add(registro);
                }
                else
                {
                    throw new Exception(((CErrorDTO)respuesta[0]).MensajeError);
                }
            }
            catch (Exception error)
            {              
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                });
               // respuesta.Add(((CErrorDTO)((CRespuestaDTO)respuesta[0]).Contenido));
            }

            return respuesta;
        }

        #endregion
    }
}