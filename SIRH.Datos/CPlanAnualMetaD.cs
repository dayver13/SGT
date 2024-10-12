using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanAnualMetaD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanAnualMetaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos

        public int GuardarMeta(PlanAnualMeta meta)
        {
            //var productosPlan = entidadBase.PlanAnualProductos.Where(q => q.FK_Plan == plan.PK_PlanAnual && q.FK_Producto == producto.PK_Producto && q.IndEstado == 1).FirstOrDefault();
            //meta.PlanAnualProductos = productosPlan;
            meta.PorPeso = 100;
            entidadBase.PlanAnualMeta.Add(meta);
            entidadBase.SaveChanges();
            return meta.PK_Meta;
        }

        public int UpdateMeta(PlanAnualMeta meta)
        {

            PlanAnualMeta metaAnterior = entidadBase.PlanAnualMeta.Where(Q => Q.PK_Meta == meta.PK_Meta).FirstOrDefault();

            if (metaAnterior != null)
            {
                metaAnterior.DesMeta = meta.DesMeta;
                metaAnterior.IndEstado = meta.IndEstado;
                metaAnterior.PorPeso = meta.PorPeso;
            }
            entidadBase.SaveChanges();
            return meta.PK_Meta;
        }
     
        public List<PlanAnualMeta> ObtenerMetaPorPlan(int idPlan)
        {
            var resultado = entidadBase.PlanAnualMeta.Where(q => q.FK_ProductoPlanInstitucional == idPlan && q.IndEstado == 1).ToList();
            return resultado;
        }

        public int DeleteMeta(PlanAnualMeta meta)
        {
            PlanAnualMeta metaAnterior = entidadBase.PlanAnualMeta.Where(Q => Q.PK_Meta == meta.PK_Meta).FirstOrDefault();

            if (metaAnterior != null)
            {
                metaAnterior.IndEstado = 2;

                List<PlanAnualActividad> actividades = new List<PlanAnualActividad>();

                actividades = entidadBase.PlanAnualActividad.Where(q => q.FK_Meta == meta.PK_Meta && q.FK_EstadoActividad != 4).ToList();

                foreach (PlanAnualActividad actividad in actividades)
                {
                    actividad.FK_EstadoActividad = 4;
                }
            }
            entidadBase.SaveChanges();
            return metaAnterior.PK_Meta;
        }


        public PlanAnualMeta ObtenerMeta(int idMeta)
        {
            var resultado = entidadBase.PlanAnualMeta.Where(q => q.PK_Meta == idMeta && q.IndEstado == 1).FirstOrDefault();
            return resultado;
        }

        #endregion
    }
}

