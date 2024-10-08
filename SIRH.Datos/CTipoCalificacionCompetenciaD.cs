using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
  public  class CTipoCalificacionCompetenciaD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CTipoCalificacionCompetenciaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene la lista de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna una lista los tipos de contacto</returns>
        public List<TipoCalificacionCompetencia> CargarTipoCalificacionCompetencia()
        {
            var  resultados = entidadBase.TipoCalificacionCompetencia.ToList();
            return resultados;
        }

        #endregion
        /// <summary>
        /// Obtiene la carga de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna las Tipos de Contacto</returns>       
        public TipoCalificacionCompetencia CargarTipoPorID(int idTipo)
        {
            var resultado = entidadBase.TipoCalificacionCompetencia.Where(R => R.PK_TipoCompetencia == idTipo).FirstOrDefault();
            return resultado;
        }
  }
}
