using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;


namespace SIRH.Logica
{
    public class CCatMetaNivelL
    {
        #region Variables

        SIRHEntities contexto;
        CCatMetaNivelD NivelDescarga;

        #endregion

        #region constructor

        public CCatMetaNivelL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CCatMetaNivelDTO ConvertirNivelADTO(CatMetaNivel item)
        {
            return new CCatMetaNivelDTO
            {
                IdEntidad = item.PK_Nivel,
                DesNivel = item.DesNivel,
                DesDetalle = item.DesDetalle
            };
        }

        public CBaseDTO ObtenerNivel(int codigo)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CCatMetaNivelD datos = new CCatMetaNivelD(contexto);

                var nivel = datos.ObtenerNivel(codigo);

                if (nivel != null)
                    respuesta = ConvertirNivelADTO(nivel);
                else
                    throw new Exception("No existe registro");
            }
            catch (Exception error)
            {
                respuesta = new CErrorDTO { MensajeError = error.Message };
            }
            return respuesta;
        }

        public List<CBaseDTO> ListarNiveles()
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCatMetaNivelD datos = new CCatMetaNivelD(contexto);

                var niveles = datos.ListarNiveles();

                if (niveles.Contenido.GetType() != typeof(CErrorDTO))
                {
                    foreach (var item in ((List<CatMetaNivel>)niveles.Contenido))
                    {
                        respuesta.Add(ConvertirNivelADTO(item));
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)niveles.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }

        #endregion
    }
}

        
       

         