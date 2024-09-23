using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
  public  class CTipoCategoriaServicioD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CTipoCategoriaServicioD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Obtiene la lista de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna una lista los tipos de contacto</returns>
        public List<TipoCategoriaServicio> CargarTipoCategoriaServicio()
        {
            var  resultados = entidadBase.TipoCategoriaServicio.ToList();
            return resultados;
        }

        #endregion
        /// <summary>
        /// Obtiene la carga de los Tipos de Contacto de la BD
        /// </summary>
        /// <returns>Retorna las Tipos de Contacto</returns>       
        public TipoCategoriaServicio CargarTipoPorID(int idTipo)
        {
            var resultado = entidadBase.TipoCategoriaServicio.Where(R => R.PK_TipoCategoria == idTipo).FirstOrDefault();
            return resultado;
        }
  }
}
