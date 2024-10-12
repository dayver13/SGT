using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanEstrategicoLineaD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanEstrategicoLineaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los Ejes en la BD
        /// </summary>
        /// <returns>Retorna los Ejes</returns>

        public int GuardarLinea(PlanEstrategicoLinea linea)
        {
            entidadBase.PlanEstrategicoLinea.Add(linea);
            entidadBase.SaveChanges();
            return linea.PK_Linea;
        }
        /// <summary>
        /// Obtiene la lista de las ejes de la BD
        /// </summary>
        /// <returns>Retorna una lista de ejes</returns>
        public List<PlanEstrategicoLinea> CargarLineas(int idEje)
        {
            var resultados = entidadBase.PlanEstrategicoLinea.Where(q=>q.FK_Eje== idEje && q.IndEstado == 1).ToList();
            return resultados;
        }

        //NUEVO
        public List<PlanEstrategicoLinea> CargarLineasPlan(int idPlan)
        {
            List<PlanEstrategicoEje> ejes = new List<PlanEstrategicoEje>();

            ejes = entidadBase.PlanEstrategicoEje.Where(q => q.FK_PlanEstrategico == idPlan && q.IndEstado == 1).ToList();


            List<PlanEstrategicoLinea> resultados = new List<PlanEstrategicoLinea>();

            foreach (var eje in ejes)
            {
                resultados.AddRange(entidadBase.PlanEstrategicoLinea.Where(q => q.FK_Eje == eje.PK_Eje && q.IndEstado == 1).ToList());
            }

            return resultados;
        }
        //

        public PlanEstrategicoLinea ObtenerLinea(int idLinea)
        {
            var resultado = entidadBase.PlanEstrategicoLinea.Where(q => q.PK_Linea== idLinea && q.IndEstado == 1).FirstOrDefault();
            return resultado;
        }


        public int ActualizarLinea(PlanEstrategicoLinea linea)
        {
            var LineaAnterior = entidadBase.PlanEstrategicoLinea.Where(Q => Q.PK_Linea == linea.PK_Linea).FirstOrDefault();

            if (LineaAnterior != null)
            {
                LineaAnterior.NumLinea = linea.NumLinea;
                LineaAnterior.DesLinea = linea.DesLinea;
            }
            entidadBase.SaveChanges();
            return linea.PK_Linea;
        }
        public int DeleteLinea(PlanEstrategicoLinea linea)
        {
            var lineaAnterior = entidadBase.PlanEstrategicoLinea.Where(Q => Q.PK_Linea == linea.PK_Linea).FirstOrDefault();
            if (lineaAnterior != null)
            {
                lineaAnterior.IndEstado = 2;

                List<PlanEstrategicoProducto> productos = new List<PlanEstrategicoProducto>();

                productos = entidadBase.PlanEstrategicoProducto.Where(q => q.FK_Linea == linea.PK_Linea && q.IndEstado == 1).ToList();

                List<PlanEstrategicoAccion> acciones = new List<PlanEstrategicoAccion>();

                foreach (var producto in productos)
                {
                    acciones.AddRange(entidadBase.PlanEstrategicoAccion.Where(q => q.FK_Producto == producto.PK_Producto && q.IndEstado == 1).ToList());
                    producto.IndEstado = 2;
                }
                foreach (var accion in acciones)
                {
                    accion.IndEstado = 2;
                }
            }
            entidadBase.SaveChanges();
            return lineaAnterior.PK_Linea;
        }

        #endregion

    }

}

