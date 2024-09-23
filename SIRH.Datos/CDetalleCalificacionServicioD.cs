using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CDetalleCalificacionServicioD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CDetalleCalificacionServicioD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarServicio(DetalleCalificacionServicio registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datoOld = entidadBase.DetalleCalificacionServicio
                                          .Where(Q => Q.FK_CalificacionNombramiento == registro.CalificacionNombramiento.PK_CalificacionNombramiento &&
                                                  Q.FK_Tipo == registro.TipoCategoriaServicio.PK_TipoCategoria)
                                          .FirstOrDefault();

                if (datoOld != null)
                {
                    datoOld.PorNota = registro.PorNota;
                    datoOld.DesNota = registro.DesNota;
                }
                else
                {
                    entidadBase.DetalleCalificacionServicio.Add(registro);
                }
                
                entidadBase.SaveChanges();

                respuesta = new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = registro
                };
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
            }

            return respuesta;
        }

        public CRespuestaDTO ConsultarServicio(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.DetalleCalificacionServicio.Where(Q => Q.PK_CalificacionServicio == codigo).FirstOrDefault();

                if (dato != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = dato
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de AutoEvaluación" }
                    };
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { Mensaje = error.Message }
                };
                return respuesta;
            }
        }

        #endregion
    }
}