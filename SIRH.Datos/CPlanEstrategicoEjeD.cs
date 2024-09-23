using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanEstrategicoEjeD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanEstrategicoEjeD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los Ejes en la BD
        /// </summary>
        /// <returns>Retorna los Ejes</returns>

        public int GuardarEje(PlanEstrategicoEje Eje)
        {
            entidadBase.PlanEstrategicoEje.Add(Eje);
            entidadBase.SaveChanges();
            return Eje.PK_Eje;
        }


        public int ActualizarEje(PlanEstrategicoEje eje)
        {
            var EjeAnterior = entidadBase.PlanEstrategicoEje.Where(Q => Q.PK_Eje == eje.PK_Eje).FirstOrDefault();

            if (EjeAnterior != null)
            {
                EjeAnterior.NumEje = eje.NumEje;
                EjeAnterior.DesEje = eje.DesEje;
                EjeAnterior.Seccion = eje.Seccion;
                //Falta el departamento, acciones futuras.
            }

            entidadBase.SaveChanges();
            return eje.PK_Eje;
        }

        public int DeleteEje(PlanEstrategicoEje eje)
        {
            var ejeAnterior = entidadBase.PlanEstrategicoEje.Where(Q => Q.PK_Eje == eje.PK_Eje).FirstOrDefault();

            if (ejeAnterior != null)
            {
                ejeAnterior.IndEstado = 2;

                List<PlanEstrategicoLinea> lineas = new List<PlanEstrategicoLinea>();

                lineas = entidadBase.PlanEstrategicoLinea.Where(q => q.FK_Eje == eje.PK_Eje && q.IndEstado == 1).ToList();

                List<PlanEstrategicoProducto> productos = new List<PlanEstrategicoProducto>();

                foreach (var linea in lineas)
                {
                    productos.AddRange(entidadBase.PlanEstrategicoProducto.Where(q => q.FK_Linea == linea.PK_Linea && q.IndEstado == 1).ToList());
                    linea.IndEstado = 2;
                }

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

                //Falta cosas futuras.

                // NOTA
                // debe buscar los hijos y eliminarlos en el caso de los demas objetos
                // Entiendase eliminar como, colocar el estado en 2

                // PARA IMPLEMENTAR ESA PARTE NECESITO QUE A LOS QUE LE TOCA EL ELIMINAR DE LÍNEAS Y PRODUCTO LO SAQUEN
                // Y LUEGO YO PUEDO HACER LA CONEXION ENTRE ELLOS.
            }

            entidadBase.SaveChanges();
            return ejeAnterior.PK_Eje;
        }

        //NUEVO
        public List<PlanEstrategicoEje> CargarEjesPlan(int idPlan)
        {
            List<PlanEstrategicoEje> ejes = new List<PlanEstrategicoEje>();

            ejes = entidadBase.PlanEstrategicoEje.Where(q => q.FK_PlanEstrategico == idPlan && q.IndEstado == 1).ToList();

            return ejes;
        }

        /// <summary>
        /// Obtiene la lista de las ejes de la BD
        /// </summary>
        /// <returns>Retorna una lista de ejes</returns>
        public List<PlanEstrategicoEje> CargarEjes(int idPlan)
        {
            List<PlanEstrategicoEje> resultados = new List<PlanEstrategicoEje>();

            resultados = entidadBase.PlanEstrategicoEje.Where(q=>q.FK_PlanEstrategico==idPlan && q.IndEstado==1).ToList();//aquí ocupa un where para hacer referencia al plan actual

            return resultados;
        }

        public PlanEstrategicoEje ObtenerEje(int idEje)
        {
            var resultado = entidadBase.PlanEstrategicoEje.Where(q => q.PK_Eje==idEje && q.IndEstado==1).FirstOrDefault();//aquí ocupa un where para hacer referencia al plan actual
            return resultado;
        }
        #endregion

    }
}

