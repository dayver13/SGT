using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CPerfilAccesoD
        //Por el momento no hay nada
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPerfilAccesoD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        //Obtiene todos los permisos activos de un funcionario en una lista
        public CRespuestaDTO ListarPermisos(string cedFuncionario)
        {
            CRespuestaDTO respuesta;
            try
            {
                var datos = entidadBase.PerfilAcceso
                    .Include("CatPermiso")
                    .Include("DetalleAcceso")
                    .Where(Q => (Q.DetalleAcceso.Funcionario.IdCedulaFuncionario == cedFuncionario) /*&& Q.IndEstadoPerfilAcceso == 1*/)
                    .OrderBy(Q => Q.FecAsignacion).ToList();

                if (datos != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datos
                    };
                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontraron permisos registrados.");
                }
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
