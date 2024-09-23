using SIRH.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIRH.Datos
{
    public class CAprobacionVacacionesD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CAprobacionVacacionesD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public CRespuestaDTO ObtenerPermisosAprobacion(string cedulaConPermiso, string cedulaParaAprobar)
        {

            try
            {
                var datosAprobacionVacaciones = entidadBase.AprobacionVacaciones.Include("Funcionario").Where(Q => Q.Funcionario.IdCedulaFuncionario  == cedulaConPermiso).ToList();
                var respuesta = 0;

                foreach (var item in datosAprobacionVacaciones)
                {
                    if (item.IdAprobar == cedulaParaAprobar)
                    {
                        respuesta = 1;
                    }
                }



                if (datosAprobacionVacaciones != null && respuesta == 1)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datosAprobacionVacaciones
                    };
                }
                else
                {
                    throw new Exception("No se encontraron permisos de aprobacion para el usuario solicitado");
                }
            }
            catch (Exception error)
            {
                return new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
            }
        }

        public CRespuestaDTO AgregarPermisosAprobacion(int FK_funcionario, string idAprobar)
        {
            CRespuestaDTO respuesta;
            AprobacionVacaciones datos = new AprobacionVacaciones();
            try
            {
                datos.FK_Funcionario = FK_funcionario;
                datos.IdAprobar = idAprobar;

                entidadBase.AprobacionVacaciones.Add(datos);
                entidadBase.SaveChanges();

                respuesta = new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = datos.PK_AprobacionVacaciones
                };
                return respuesta;
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };

                return respuesta;
            }
        }


        #endregion
    }
}
