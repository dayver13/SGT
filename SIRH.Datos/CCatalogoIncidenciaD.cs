using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;
using SIRH.Datos.Helpers;

namespace SIRH.Datos
{
    public class CCatalogoIncidenciaD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCatalogoIncidenciaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public CRespuestaDTO ObtenerCatalogoIncidencia(int IdEntidad)
        {
            CRespuestaDTO respuesta;
            try
            {
                var catalogoIncidencia = entidadBase.CatalogoIncidencia.Where(C => C.FK_Perfil == IdEntidad).FirstOrDefault();

                if (catalogoIncidencia != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = catalogoIncidencia
                    };
                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontró el módulo indicado en la incidencia");
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