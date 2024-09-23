using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CCalificacionJefeColaboradorD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCalificacionJefeColaboradorD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarCalificacionColaborador(CalificacionJefeColaborador registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datoOld = entidadBase.CalificacionJefeColaborador
                                          .Where(Q => Q.FK_Jefatura == registro.Funcionario.PK_Funcionario &&
                                                  Q.FK_Periodo == registro.PeriodoCalificacion.PK_PeriodoCalificacion &&
                                                  Q.FK_Colaborador == registro.Funcionario1.PK_Funcionario &&
                                                  Q.FK_TipoCategoria == registro.TipoCalJefeColaborador.PK_Tipo &&
                                                  Q.IndEstado == 1)
                                          .FirstOrDefault();

                if (datoOld != null)
                {
                    datoOld.PorNota = registro.PorNota;
                    datoOld.DesNota = registro.DesNota;
                }
                else
                {
                    entidadBase.CalificacionJefeColaborador.Add(registro);
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

        public CRespuestaDTO ConsultarCalificacionColaborador(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.CalificacionJefeColaborador.Where(Q => Q.PK_CalificacionColaborador == codigo).FirstOrDefault();

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de la Calificación de los Colaboradores" }
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

        public CRespuestaDTO ConsultarCalificacionJefeColaborador(int periodo, int codJefatura)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.CalificacionJefeColaborador
                                            .Where(Q => Q.FK_Jefatura == codJefatura && 
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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificaciones de los Colaboradores" }
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
              

        public CRespuestaDTO EditarCalificacioColaborador(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.CalificacionJefeColaborador.Where(Q => Q.PK_CalificacionColaborador == codigo).FirstOrDefault();

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
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ningún registro de Calificación de los Colaboradores" }
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
