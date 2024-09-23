using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CDetalleCalificacionCompetenciaD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CDetalleCalificacionCompetenciaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarCompetencia(DetalleCalificacionCompetencia registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datoOld = entidadBase.DetalleCalificacionCompetencia
                                          .Where(Q => Q.FK_CalificacionNombramiento == registro.CalificacionNombramiento.PK_CalificacionNombramiento &&
                                                  Q.FK_Tipo == registro.TipoCalificacionCompetencia.PK_TipoCompetencia)
                                          .FirstOrDefault();

                if (datoOld != null)
                {
                    datoOld.PorNota = registro.PorNota;
                    datoOld.DesNota = registro.DesNota;
                }
                else
                {
                    entidadBase.DetalleCalificacionCompetencia.Add(registro);
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

        public CRespuestaDTO ConsultarCompetencia(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.DetalleCalificacionCompetencia.Where(Q => Q.PK_CalificacionCompetencia == codigo).FirstOrDefault();

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de Competencia" }
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

        public CRespuestaDTO EditarCompetencia(DetalleCalificacionCompetencia registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.DetalleCalificacionCompetencia.Where(Q => Q.PK_CalificacionCompetencia == registro.PK_CalificacionCompetencia).FirstOrDefault();

                if (dato != null)
                {
                    dato.PorNota = registro.PorNota;
                    dato.DesNota = registro.DesNota;

                    entidadBase.SaveChanges();

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Competencia" }
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