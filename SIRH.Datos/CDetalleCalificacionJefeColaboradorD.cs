using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CDetalleCalificacionJefeColaboradorD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CDetalleCalificacionJefeColaboradorD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion


        #region Metodos

        public CRespuestaDTO AgregarJefeColaborador(DetalleCalificacionJefeColaborador registro)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datoOld = entidadBase.DetalleCalificacionJefeColaborador
                                          .Where(Q => Q.FK_CalificacionNombramiento == registro.CalificacionNombramiento.PK_CalificacionNombramiento &&
                                                  Q.FK_Tipo == registro.TipoCalJefeColaborador.PK_Tipo)
                                          .FirstOrDefault();

                if (datoOld != null)
                {
                    datoOld.PorNota = registro.PorNota;
                    datoOld.DesNota = registro.DesNota;
                }
                else
                {
                    entidadBase.DetalleCalificacionJefeColaborador.Add(registro);
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

        public CRespuestaDTO ConsultarCalificacionJefeColaborador(int codigo)
        {
            CRespuestaDTO respuesta;
            try
            {
                var dato = entidadBase.DetalleCalificacionJefeColaborador.Where(Q => Q.PK_CalificacionJefeColaborador == codigo).FirstOrDefault();

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