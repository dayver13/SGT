using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CCatMetaNivelD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCatMetaNivelD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public CRespuestaDTO AgregarNivel(CatMetaNivel nivel)
        {
            CRespuestaDTO respuesta;
            try
            {
                entidadBase.CatMetaNivel.Add(nivel);
                entidadBase.SaveChanges();
                respuesta = new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = nivel
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

        public CatMetaNivel ObtenerNivel(int codigo)
        {
            var nivel = entidadBase.CatMetaNivel.Where(Q => Q.PK_Nivel == codigo).FirstOrDefault();
            return nivel;
        }

        public CRespuestaDTO ListarNiveles()
        {
            CRespuestaDTO respuesta;
            try
            {
                var datos = entidadBase.CatMetaNivel.ToList();

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
                    throw new Exception("No se encontraron Niveles registrados.");
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
