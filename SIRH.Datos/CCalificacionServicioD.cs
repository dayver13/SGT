using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CCalificacionServicioD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCalificacionServicioD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarServicio(CalificacionServicio servicio)
        {
            CRespuestaDTO respuesta;
            try
            {
                var servicioOld = entidadBase.CalificacionServicio
                                          .Where(Q => Q.FK_Direccion == servicio.DireccionGeneral.PK_DireccionGeneral &&
                                                  Q.FK_Periodo == servicio.PeriodoCalificacion.PK_PeriodoCalificacion &&
                                                  Q.FK_TipoCategoria == servicio.TipoCategoriaServicio.PK_TipoCategoria &&
                                                  Q.IndEstado == 1)
                                          .FirstOrDefault();

                if (servicioOld != null)
                {
                    servicioOld.PorNota = servicio.PorNota;
                    servicioOld.DesNota = servicio.DesNota;
                }
                else
                {
                    entidadBase.CalificacionServicio.Add(servicio);
                }
                
                entidadBase.SaveChanges();

                respuesta = new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = servicio
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
                var servicio = entidadBase.CalificacionServicio.Where(Q => Q.PK_CalificacionServicio == codigo).FirstOrDefault();

                if (servicio != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = servicio
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de Servicio" }
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

        public CRespuestaDTO ConsultarCalificacionDireccion(int periodo, int codDireccion)
        {
            CRespuestaDTO respuesta;
            try
            {
                var servicio = entidadBase.CalificacionServicio
                                            .Where(Q => Q.FK_Direccion == codDireccion && 
                                                    Q.FK_Periodo == periodo && 
                                                    Q.IndEstado ==1)
                                            .ToList();

                if (servicio != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = servicio
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de Servicio" }
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

        public CRespuestaDTO ConsultarCalificacionPeriodo(int periodo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var servicio = entidadBase.CalificacionServicio
                                            .Where(Q => Q.FK_Periodo == periodo &&
                                                    Q.IndEstado == 1)
                                            .ToList();

                if (servicio != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = servicio
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de Servicio" }
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

        public CRespuestaDTO EditarServicio(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var servicio = entidadBase.CalificacionServicio.Where(Q => Q.PK_CalificacionServicio == codigo).FirstOrDefault();

                if (servicio != null)
                {
                    servicio.IndEstado = 2;

                    entidadBase.SaveChanges();

                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = servicio
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de Servicio" }
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
