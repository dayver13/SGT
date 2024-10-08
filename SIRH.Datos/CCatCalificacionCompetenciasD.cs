using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
  public  class CCatCalificacionCompetenciasD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCatCalificacionCompetenciasD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene la lista de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna una lista los tipos de contacto</returns>
        public List<CatCalificacionCompetencias> CargarCatCalificacionCompetencias()
        {
            var  resultados = entidadBase.CatCalificacionCompetencias.ToList();
            return resultados;
        }

        #endregion
        /// <summary>
        /// Obtiene la carga de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna las Tipos de Contacto</returns>       
        public CatCalificacionCompetencias CargarPorID(int idTipo)
        {
            var resultado = entidadBase.CatCalificacionCompetencias.Where(R => R.PK_Competencia == idTipo).FirstOrDefault();
            return resultado;
        }

        public List<CatCalificacionCompetencias> CargarPorClase(int idClase)
        {
            var resultado = entidadBase.CatCalificacionCompetencias.Where(R => R.FK_Clase == idClase).ToList();
            return resultado;
        }
    }
}
