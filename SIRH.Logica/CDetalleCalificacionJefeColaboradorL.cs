using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CDetalleCalificacionJefeColaboradorL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CDetalleCalificacionJefeColaboradorL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CDetalleCalificacionJefeColaboradorDTO ConvertirDatoADto(DetalleCalificacionJefeColaborador item)
        {
            return new CDetalleCalificacionJefeColaboradorDTO
            {
                IdEntidad = item.PK_CalificacionJefeColaborador,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                Tipo = new CTipoCalJefeColaboradorDTO
                {
                    IdEntidad = item.TipoCalJefeColaborador.PK_Tipo,
                    DesTipo = item.TipoCalJefeColaborador.DesTipo,
                    DesDetalle = item.TipoCalJefeColaborador.DesDetalle
                }
            };
        }

        internal static DetalleCalificacionJefeColaborador ConvertirDTOADatos(CDetalleCalificacionJefeColaboradorDTO item)
        {
            return new DetalleCalificacionJefeColaborador
            {
                PK_CalificacionJefeColaborador  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota
            };
        }

        public List<CBaseDTO> GuardarJefeColaborador(CDetalleCalificacionJefeColaboradorDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CDetalleCalificacionJefeColaboradorD intermedio = new CDetalleCalificacionJefeColaboradorD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                DetalleCalificacionJefeColaborador datos = ConvertirDTOADatos(registro);

                //// Calificacion Nombramiento
                var entidadCal = intermedioCal.CargarCalificacionNombramientoPorID(registro.Calificacion.IdEntidad);
                if (entidadCal != null)
                    datos.CalificacionNombramiento = entidadCal;
                else
                    throw new Exception("No se encontró la información de la Calificación. No se pudo registrar las JefeColaboradors" );

                // Tipo 
                CTipoCalJefeColaboradorD intermedioTipo = new CTipoCalJefeColaboradorD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.Tipo.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoCalJefeColaborador = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo de Jefe Colaborador");

                var insertaCN = intermedio.AgregarJefeColaborador(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionJefeColaborador;
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