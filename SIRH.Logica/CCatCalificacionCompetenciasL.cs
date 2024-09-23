using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CCatCalificacionCompetenciasL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CCatCalificacionCompetenciasL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CCatCalificacionCompetenciaDTO ConvertirDatoADto(CatCalificacionCompetencias item)
        {
            return new CCatCalificacionCompetenciaDTO
            {
                IdEntidad = item.PK_Competencia,
                PorDesarrollar = item.PorDesarrollar,
                PorMejorar = item.PorMejorar,
                PorCumple = item.PorCumple,
                Tipo = new CTipoCompetenciaDTO
                {
                    IdEntidad = item.TipoCalificacionCompetencia.PK_TipoCompetencia,
                    DesTipo = item.TipoCalificacionCompetencia.DesTipoCompetencia,
                    DesDetalle = item.TipoCalificacionCompetencia.DesCategoria
                },
                Clase = new CClaseDTO
                {
                    IdEntidad= item.Clase.PK_Clase,
                    DesClase = item.Clase.DesClase.TrimEnd()
                }
            };
        }

        internal static CatCalificacionCompetencias ConvertirDTOADatos(CCatCalificacionCompetenciaDTO item)
        {
            return new CatCalificacionCompetencias
            {
                PK_Competencia  = item.IdEntidad,
                PorDesarrollar = item.PorDesarrollar,
                PorMejorar = item.PorMejorar,
                PorCumple = item.PorCumple
            };
        }
            
        public List<CBaseDTO> ObtenerCatalagoCompetenciasClase(CClaseDTO clase)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCatCalificacionCompetenciasD intermedio = new CCatCalificacionCompetenciasD(contexto);

                var dato = intermedio.CargarPorClase(clase.IdEntidad);
                if (dato != null)
                {
                    foreach(var item in dato)
                    {
                        respuesta.Add(ConvertirDatoADto(item));
                    }
                }
                else
                {
                   throw new Exception ("No existe información de Competencias de la Clase " + clase.IdEntidad.ToString() + " - " + clase.DesClase != null ? clase.DesClase.TrimEnd() : "" + ". Favor comunicarse con Recursos Humanos");
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                });
            }

            return respuesta;
        }

        #endregion
    }
}