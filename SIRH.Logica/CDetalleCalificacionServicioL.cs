using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CDetalleCalificacionServicioL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CDetalleCalificacionServicioL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CDetalleCalificacionServicioDTO ConvertirDatoADto(DetalleCalificacionServicio item)
        {
            return new CDetalleCalificacionServicioDTO
            {
                IdEntidad = item.PK_CalificacionServicio,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                Tipo = new CTipoCategoriaServicioDTO
                {
                    IdEntidad = item.TipoCategoriaServicio.PK_TipoCategoria,
                    DesCategoria = item.TipoCategoriaServicio.DesCategoria
                }
            };
        }

        internal static DetalleCalificacionServicio ConvertirDTOADatos(CDetalleCalificacionServicioDTO item)
        {
            return new DetalleCalificacionServicio
            {
                PK_CalificacionServicio  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota
            };
        }

        public List<CBaseDTO> GuardarServicio(CDetalleCalificacionServicioDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CDetalleCalificacionServicioD intermedio = new CDetalleCalificacionServicioD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                DetalleCalificacionServicio datos = ConvertirDTOADatos(registro);

                //// Calificacion Nombramiento
                var entidadCal = intermedioCal.CargarCalificacionNombramientoPorID(registro.Calificacion.IdEntidad);
                if (entidadCal != null)
                    datos.CalificacionNombramiento = entidadCal;
                else
                    throw new Exception("No se encontró la información de la Calificación. No se pudo registrar las Servicios" );

                // Tipo 
                CTipoCategoriaServicioD intermedioTipo = new CTipoCategoriaServicioD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.Tipo.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoCategoriaServicio = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo de Servicio");

                var insertaCN = intermedio.AgregarServicio(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionServicio;
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