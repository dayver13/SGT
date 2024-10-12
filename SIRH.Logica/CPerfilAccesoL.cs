using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPerfilAccesoL
    {
        #region Variables

        SIRHEntities contexto;
        CPerfilAccesoD perfilAccesoDescarga;

        #endregion

        #region Constructor

        public CPerfilAccesoL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CPerfilAccesoDTO PerfilAccesoADTO(PerfilAcceso item)
        {
            return new CPerfilAccesoDTO
            {
                IdEntidad = item.PK_PerfilAcceso,
                DetalleAcceso= CDetalleAccesoL.DetalleAccesoADTO(item.DetalleAcceso),
                CatPermiso = CCatPermisoL.PermisoADto(item.CatPermiso),
                FecAsignacion = Convert.ToDateTime(item.FecAsignacion),
                //IndEstPerfilAcceso = Convert.ToInt32(item.IndEstadoPerfilAcceso)
            };
        }
        public List<CBaseDTO> ListarPermisos(string cedFuncionario)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                perfilAccesoDescarga = new CPerfilAccesoD(contexto);

                var acceso = perfilAccesoDescarga.ListarPermisos(cedFuncionario);

                if (acceso.Contenido.GetType() != typeof(CErrorDTO))
                {
                    foreach (var item in ((List<PerfilAcceso>)acceso.Contenido))
                    {
                        respuesta.Add(PerfilAccesoADTO(item));
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)acceso.Contenido).MensajeError);
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
