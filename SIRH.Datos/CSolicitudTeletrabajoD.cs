using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CSolicitudTeletrabajoD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CSolicitudTeletrabajoD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public CRespuestaDTO GuardarSolicitud(SolicitudTeletrabajo solicitud)
        {
            try
            {
                entidadBase.SolicitudTeletrabajo.Add(solicitud);

                if(entidadBase.SaveChanges() > 0) {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = solicitud
                    };
                }
                else
                {
                    throw new Exception("No se pudo guardar la solicitud!");
                }
            }
            catch (Exception error)
            {
                return new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { Codigo = -1, MensajeError = error.Message }
                };
            }
        }

        public CRespuestaDTO AprobacionInmediato(int solicitud)
        {
            try
            {
                var solicitudRetorno = entidadBase.SolicitudTeletrabajo.FirstOrDefault(Q => Q.PK_SolicitudTeletrabajo == solicitud);

                if(solicitudRetorno != null) { 

                    solicitudRetorno.IndAprobadoJefatura = true;

                    if (entidadBase.SaveChanges() > 0)
                    {
                        return new CRespuestaDTO
                        {
                            Codigo = 1,
                            Contenido = solicitud
                        };
                    }
                    else
                    {
                        throw new Exception("No se pudo guardar la solicitud!");
                    }
                }
                else
                {
                    throw new Exception("No se encontró la solicitud a actualizar!");
                }
            }
            catch (Exception error)
            {
                return new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { Codigo = -1, MensajeError = error.Message }
                };
            }
        }

        public CRespuestaDTO AprobacionSuperior(int solicitud)
        {
            try
            {
                var solicitudRetorno = entidadBase.SolicitudTeletrabajo.FirstOrDefault(Q => Q.PK_SolicitudTeletrabajo == solicitud);

                if (solicitudRetorno != null && solicitudRetorno.IndAprobadoJefatura == true)
                {

                    solicitudRetorno.IndAprobadoSuperior = true;

                    if (entidadBase.SaveChanges() > 0)
                    {
                        return new CRespuestaDTO
                        {
                            Codigo = 1,
                            Contenido = solicitud
                        };
                    }
                    else
                    {
                        throw new Exception("No se pudo guardar la solicitud!");
                    }
                }
                else
                {
                    throw new Exception("No se encontró la solicitud a actualizar o bien, esta no ha sido aprobada por el jefe inmediato del funcionario!");
                }
            }
            catch (Exception error)
            {
                return new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { Codigo = -1, MensajeError = error.Message }
                };
            }
        }

        public List<SolicitudTeletrabajo> ListarSolicitudes(string cedula)
        {
            try
            {

                var datos = entidadBase.SolicitudTeletrabajo.Where(F => F.Funcionario.IdCedulaFuncionario == cedula).ToList();

                if (datos != null)
                {
                    return datos;
                }
                else
                {
                    throw new Exception("Ocurrió un error al descargar los datos de las solicitudes");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }


        #endregion
    }
}
