using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
    public class CEstadoPlanD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CEstadoPlanD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Obtiene y Enlista los Estados del Plan Estrategico de la BD
        /// </summary>
        /// <returns>Retorna los Estados de los planes</returns>
        public List<EstadoPlan> CargarEstadosDePlan()
        {
            var resultados = entidadBase.EstadoPlan.ToList();
            return resultados;
        }       
         
        /// <summary>
        /// Obtiene la carga de los Estados de los planes de la BD
        /// </summary>
        /// <returns>Retorna los Estados de los planes</returns>
        public EstadoPlan CargarEstadoPlanPorID(int idEstadoPlan)
        {
            var resultado = entidadBase.EstadoPlan.Where(R => R.PK_EstadoPlan == idEstadoPlan).FirstOrDefault();
            return resultado;
        }

        #endregion
    }
}