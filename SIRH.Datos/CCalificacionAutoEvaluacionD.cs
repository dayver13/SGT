using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CCalificacionAutoEvaluacionD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCalificacionAutoEvaluacionD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarAutoEvaluacion(CalificacionAutoEvaluacion registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datoOld = entidadBase.CalificacionAutoEvaluacion
                                          .Where(Q => Q.FK_Funcionario == registro.Funcionario.PK_Funcionario &&
                                                  Q.FK_Periodo == registro.PeriodoCalificacion.PK_PeriodoCalificacion &&
                                                  Q.FK_Tipo == registro.TipoAutoevaluacion.PK_Tipo &&
                                                  Q.IndEstado == 1)
                                          .FirstOrDefault();

                if (datoOld != null)
                {
                    datoOld.PorNota = registro.PorNota;
                    datoOld.DesNota = registro.DesNota;
                }
                else
                {
                    entidadBase.CalificacionAutoEvaluacion.Add(registro);
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
                var dato = entidadBase.CalificacionAutoEvaluacion.Where(Q => Q.PK_CalificacionAutoEvaluacion == codigo).FirstOrDefault();

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Autoevaluación" }
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

        public CRespuestaDTO ConsultarAutoEvaluacion(int periodo, int codFuncionario)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.CalificacionAutoEvaluacion
                                            .Where(Q => Q.FK_Funcionario == codFuncionario && 
                                                    Q.FK_Periodo == periodo && 
                                                    Q.IndEstado ==1)
                                            .ToList();

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Autoevaluación" }
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
              

        public CRespuestaDTO EditarAutoEvaluacion(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.CalificacionAutoEvaluacion.Where(Q => Q.PK_CalificacionAutoEvaluacion == codigo).FirstOrDefault();

                if (dato != null)
                {
                    dato.IndEstado = 2;

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Autoevaluación" }
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