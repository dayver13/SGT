using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CDetalleCalificacionAutoEvaluacionD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CDetalleCalificacionAutoEvaluacionD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarAutoEvaluacion(DetalleCalificacionAutoEvaluacion registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datoOld = entidadBase.DetalleCalificacionAutoEvaluacion
                                          .Where(Q => Q.FK_CalificacionNombramiento == registro.CalificacionNombramiento.PK_CalificacionNombramiento &&
                                                  Q.FK_Tipo == registro.TipoAutoevaluacion.PK_Tipo)
                                          .FirstOrDefault();

                if (datoOld != null)
                {
                    datoOld.PorNota = registro.PorNota;
                    datoOld.DesNota = registro.DesNota;
                }
                else
                {
                    entidadBase.DetalleCalificacionAutoEvaluacion.Add(registro);
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

        public CRespuestaDTO ConsultarAutoEvaluacion(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.DetalleCalificacionAutoEvaluacion.Where(Q => Q.PK_CalificacionAutoEvaluacion == codigo).FirstOrDefault();

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