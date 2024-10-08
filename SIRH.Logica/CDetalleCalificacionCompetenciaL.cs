using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CDetalleCalificacionCompetenciaL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CDetalleCalificacionCompetenciaL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CDetalleCalificacionCompetenciaDTO ConvertirDatoADto(DetalleCalificacionCompetencia item)
        {
            return new CDetalleCalificacionCompetenciaDTO
            {
                IdEntidad = item.PK_CalificacionCompetencia,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                DesNotaOriginal = item.DesNotaOriginal,
                PorNotaOriginal = item.PorNotaOriginal,
                Tipo = new CTipoCompetenciaDTO
                {
                    IdEntidad = item.TipoCalificacionCompetencia.PK_TipoCompetencia,
                    DesTipo = item.TipoCalificacionCompetencia.DesTipoCompetencia,
                    DesDetalle = item.TipoCalificacionCompetencia.DesCategoria
                }
            };
        }

        internal static DetalleCalificacionCompetencia ConvertirDTOADatos(CDetalleCalificacionCompetenciaDTO item)
        {
            return new DetalleCalificacionCompetencia
            {
                PK_CalificacionCompetencia  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                DesNotaOriginal = item.DesNotaOriginal,
                PorNotaOriginal = item.PorNotaOriginal
            };
        }

        public List<CBaseDTO> GuardarCompetencia(CDetalleCalificacionCompetenciaDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CDetalleCalificacionCompetenciaD intermedio = new CDetalleCalificacionCompetenciaD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                DetalleCalificacionCompetencia datos = ConvertirDTOADatos(registro);

                //// Calificacion Nombramiento
                var entidadCal = intermedioCal.CargarCalificacionNombramientoPorID(registro.Calificacion.IdEntidad);
                if (entidadCal != null)
                    datos.CalificacionNombramiento = entidadCal;
                else
                    throw new Exception("No se encontró la información de la Calificación. No se pudo registrar las Competencias" );

                // Tipo 
                CTipoCalificacionCompetenciaD intermedioTipo = new CTipoCalificacionCompetenciaD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.Tipo.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoCalificacionCompetencia = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo de Competencia");

                datos.PorNotaOriginal = datos.PorNota;
                datos.DesNotaOriginal = datos.DesNotaOriginal;

                var insertaCN = intermedio.AgregarCompetencia(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionCompetencia;
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

        public CBaseDTO ModificarCompetencia(CDetalleCalificacionCompetenciaDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CDetalleCalificacionCompetenciaD intermedio = new CDetalleCalificacionCompetenciaD(contexto);

                DetalleCalificacionCompetencia datos = ConvertirDTOADatos(registro);

                var modificar = intermedio.EditarCompetencia(datos);

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