using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
  public class CCatCalificacionAutoevaluacionD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCatCalificacionAutoevaluacionD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        //#region Metodos
        /// <summary>
        /// Obtiene la lista de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna una lista los tipos de contacto</returns>
        /*public List<CatCalificacionAutoevaluacion> CargarCatCalificacionAutoevaluacion()
        {
            var  resultados = entidadBase.CatCalificacionAutoevaluacion.ToList();
            return resultados;
        }

        #endregion
        /// <summary>
        /// Obtiene la carga de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna las Tipos de Contacto</returns>       
        public CatCalificacionAutoevaluacion CargarPorID(int idTipo)
        {
            var resultado = entidadBase.CatCalificacionAutoevaluacion.Where(R => R.PK_Autoevaluacion == idTipo).FirstOrDefault();
            return resultado;
        }

        public List<CatCalificacionAutoevaluacion> CargarPorClase(int idClase)
        {
            var resultado = entidadBase.CatCalificacionAutoevaluacion.Where(R => R.FK_Clase == idClase).ToList();
            return resultado;
        }*/
    }
}
