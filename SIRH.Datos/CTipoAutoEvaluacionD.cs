using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
  public  class CTipoAutoEvaluacionD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CTipoAutoEvaluacionD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene la lista de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna una lista los tipos de contacto</returns>
        public List<TipoAutoevaluacion> CargarTipos()
        {
            var  resultados = entidadBase.TipoAutoevaluacion.ToList();
            return resultados;
        }

        #endregion
        /// <summary>
        /// Obtiene la carga de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna las Tipos de Contacto</returns>       
        public TipoAutoevaluacion CargarTipoPorID(int idTipo)
        {
            var resultado = entidadBase.TipoAutoevaluacion.Where(R => R.PK_Tipo == idTipo).FirstOrDefault();
            return resultado;
        }
  }
}
