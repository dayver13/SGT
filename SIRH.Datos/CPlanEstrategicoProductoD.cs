using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanEstrategicoProductoD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanEstrategicoProductoD(SIRHEntities entidadGlobal)
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

        public int UpdateProducto(PlanEstrategicoProducto producto)
        {
            var productoAnterior = entidadBase.PlanEstrategicoProducto.Where(Q => Q.PK_Producto == producto.PK_Producto).FirstOrDefault();

            if (productoAnterior != null)
            {
                productoAnterior.DesProducto = producto.DesProducto;
                productoAnterior.IndPrioridad = producto.IndPrioridad;
                productoAnterior.ObsResultadoEsperado = producto.ObsResultadoEsperado;
                if(producto.ObsSituacionActual!=null && producto.ObsSituacionActual!="")
                productoAnterior.ObsSituacionActual = producto.ObsSituacionActual;
                //Falta cosas futuras.
            }

            entidadBase.SaveChanges();
            return producto.PK_Producto;
        }

        public int GuardarProducto(PlanEstrategicoProducto producto)
        {
            entidadBase.PlanEstrategicoProducto.Add(producto);
            entidadBase.SaveChanges();
            return producto.PK_Producto;
        }
        /// <summary>
        /// Obtiene la lista de los productos de la BD
        /// </summary>
        /// <returns>Retorna una lista de productos</returns>
        public List<PlanEstrategicoProducto> CargarProductos(int idLinea)
        {
            List<PlanEstrategicoProducto> resultados = new List<PlanEstrategicoProducto>();

            resultados = entidadBase.PlanEstrategicoProducto.Where(q=>q.FK_Linea== idLinea && q.IndEstado == 1).ToList();

            return resultados;
        }

        public int DeleteProducto(PlanEstrategicoProducto producto)
        {
            var productoAnterior = entidadBase.PlanEstrategicoProducto.Where(Q => Q.PK_Producto == producto.PK_Producto).FirstOrDefault();
            if (productoAnterior != null)
            {
                productoAnterior.IndEstado = 2;

                List<PlanEstrategicoAccion> acciones = new List<PlanEstrategicoAccion>();

                acciones = entidadBase.PlanEstrategicoAccion.Where(q => q.FK_Producto == producto.PK_Producto && q.IndEstado == 1).ToList();

                //List<Meta> metas = new List<Meta>();

                foreach (var accion in acciones)
                {
                    //metas.AddRange(entidadBase.Meta.Where(q => q.FK_Accion == accion.PK_AccionEstrategica && q.IndEstado == 1).ToList());
                    accion.IndEstado = 2;
                }
                //foreach (Meta accion in metas)
                //{
                //    accion.IndEstado = 2;
                //}
            }
            entidadBase.SaveChanges();
            return productoAnterior.PK_Producto;
        }

        public PlanEstrategicoProducto ObtenerProducto(int idProducto)
        {
            var resultado = entidadBase.PlanEstrategicoProducto.Where(q => q.PK_Producto == idProducto && q.IndEstado == 1).FirstOrDefault();
            return resultado;
        }
        #endregion

    }
}

