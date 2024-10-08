using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanEstrategicoAccionD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanEstrategicoAccionD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los Ejes en la BD
        /// </summary>
        /// <returns>Retorna los Ejes</returns>
        /// 

        public int UpdateAccionEstrategica(PlanEstrategicoAccion accion)
        {
            var accionAnterior = entidadBase.PlanEstrategicoAccion.Where(Q => Q.PK_AccionEstrategica == accion.PK_AccionEstrategica).FirstOrDefault();

            if (accionAnterior != null)
            {
                accionAnterior.DesAccionEstrategica = accion.DesAccionEstrategica;
                accionAnterior.IndAccionEstrategica = accion.IndAccionEstrategica;
                accionAnterior.NumAnioFinalEsperado = accion.NumAnioFinalEsperado;
                accionAnterior.NumAnioInicioEsperado = accion.NumAnioInicioEsperado;
                if(accion.NumAnioFinalOficial!=null && accion.NumAnioFinalOficial>0)
                accionAnterior.NumAnioFinalOficial = accion.NumAnioFinalOficial;
                //Falta cosas futuras.
            }

            entidadBase.SaveChanges();
            return accion.PK_AccionEstrategica;
        }

        public int GuardarAccionEstrategica(PlanEstrategicoAccion accion)
        {
            entidadBase.PlanEstrategicoAccion.Add(accion);
            entidadBase.SaveChanges();
            return accion.PK_AccionEstrategica;
        }

        public int DeleteAccionEstrategica(PlanEstrategicoAccion accion)
        {
            var accionAnterior = entidadBase.PlanEstrategicoAccion.Where(Q => Q.PK_AccionEstrategica == accion.PK_AccionEstrategica).FirstOrDefault();

            if (accionAnterior != null)
            {
                accionAnterior.IndEstado = 2;
            }

            entidadBase.SaveChanges();
            return accionAnterior.PK_AccionEstrategica;
        }
        /// <summary>
        /// Obtiene la lista de las acciones de la BD
        /// </summary>
        /// <returns>Retorna una lista acciones</returns>
        public List<PlanEstrategicoAccion> CargarAccionesEstrategicas(int idProducto)
        {
            var resultados = entidadBase.PlanEstrategicoAccion.Where(q=>q.FK_Producto== idProducto && q.IndEstado == 1).ToList();
            return resultados;
        }

        //NUEVO
        public List<PlanEstrategicoAccion> CargarAccionesPlan(int idPlan)
        {
            var ejes = entidadBase.PlanEstrategicoEje.Where(q => q.FK_PlanEstrategico == idPlan && q.IndEstado == 1).ToList();

            List<PlanEstrategicoLinea> lineas = new List<PlanEstrategicoLinea>();

            foreach (var eje in ejes)
            {
                lineas.AddRange(entidadBase.PlanEstrategicoLinea.Where(q => q.FK_Eje == eje.PK_Eje && q.IndEstado == 1).ToList());
            }

            List<PlanEstrategicoProducto> productos = new List<PlanEstrategicoProducto>();

            foreach (var linea in lineas)
            {
                productos.AddRange(entidadBase.PlanEstrategicoProducto.Where(q => q.FK_Linea == linea.PK_Linea && q.IndEstado == 1).ToList());
            }

            List<PlanEstrategicoAccion> resultados = new List<PlanEstrategicoAccion>();

            foreach (var producto in productos)
            {
                resultados.AddRange(entidadBase.PlanEstrategicoAccion.Where(q => q.FK_Producto == producto.PK_Producto && q.IndEstado == 1).ToList());
            }

            return resultados;
        }
        //

        public PlanEstrategicoAccion ObtenerAccionEstrategica(int idAccion)
        {
            var resultado = entidadBase.PlanEstrategicoAccion.Where(q => q.PK_AccionEstrategica == idAccion && q.IndEstado == 1).FirstOrDefault();
            return resultado;
        }
        #endregion

    }
}

