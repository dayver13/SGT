using SIRH.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanAnualD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanAnualD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el plan en la BD
        /// </summary>
        

        public int GuardarPlan(PlanAnual POI)
        {
            PlanAnual existe = entidadBase.PlanAnual.Where(Q => Q.NumAnnio == POI.NumAnnio && Q.Seccion.PK_Seccion == POI.Seccion.PK_Seccion).FirstOrDefault();
            if (existe == null)
            {
                entidadBase.PlanAnual.Add(POI);

            }


            entidadBase.SaveChanges();
            return POI.PK_PlanAnual;
        }

        public int ActualizarPlan(PlanAnual POI)
        {
            PlanAnual PlanAnterior = entidadBase.PlanAnual.Where(Q => Q.PK_PlanAnual == POI.PK_PlanAnual).FirstOrDefault();

            if (PlanAnterior != null)
            {
                PlanAnterior.ObsObjetivoEspecifico = POI.ObsObjetivoEspecifico;
                PlanAnterior.NumAnnio = POI.NumAnnio;
                PlanAnterior.NomPlan = POI.NomPlan;
                PlanAnterior.Seccion = POI.Seccion;
                PlanAnterior.PlanEstrategico = POI.PlanEstrategico;
            }
            entidadBase.SaveChanges();
            return POI.PK_PlanAnual;
        }

        public PlanAnual ObtenerPlan(int idPlan)
        {
            var resultado = entidadBase.PlanAnual.Where(q => q.PK_PlanAnual==idPlan).FirstOrDefault();
            return resultado;
        }

        public CRespuestaDTO BuscarPlanAnual(List<PlanAnual> datosPrevios, object parametro, string elemento)
        {
            CRespuestaDTO respuesta;
            try
            {

                var datos = CargarDatos(elemento, datosPrevios, parametro);
                if (datos.Count > 0)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datos //DesarraigosCodigo(datos)
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontraron resultados para los parámetros de búsqueda establecidos" }
                    };
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { Mensaje = error.Message }
                };
                return respuesta;
            }
        }


        private List<PlanAnual> CargarDatos(string elemento, List<PlanAnual> datosPrevios, object parametro)
        {
            string param = "";
            int iParam = 0;


            if (parametro.GetType().Name.Equals("String"))
            {
                param = parametro.ToString();
            }
            else
            {
                if (parametro.GetType() == typeof(int))
                {
                    iParam = Convert.ToInt32(parametro);
                }
            }

            if (datosPrevios.Count < 1)
            {
                switch (elemento)
                {
                    case "Nombre":
                        datosPrevios = entidadBase.PlanAnual
                                                    .Where(C => C.NomPlan.Contains(param)).ToList();
                        break;

                    case "Objetivo":
                        datosPrevios = entidadBase.PlanAnual
                                                    .Where(C => C.ObsObjetivoEspecifico.Contains(param)).ToList();
                        break;

                    case "Estado":
                        if (iParam == -1) // No mostrar las Anuladas
                            datosPrevios = entidadBase.PlanAnual
                                                    .Where(C => C.FK_EstadoPlan != 2).ToList();
                        else
                            datosPrevios = entidadBase.PlanAnual
                                                   .Where(C => C.FK_EstadoPlan == iParam).ToList();
                        break;
                    case "Sección":
                        datosPrevios = entidadBase.PlanAnual
                                                    .Where(C => C.FK_Seccion == iParam).ToList();
                        break;
                    case "Año":
                        datosPrevios = entidadBase.PlanAnual
                                                    .Where(C => C.NumAnnio == iParam).ToList();
                        break;
                    default:
                        datosPrevios = new List<PlanAnual>();
                        break;
                }
            }
            else
            {
                switch (elemento)
                {
                    case "Nombre":
                        datosPrevios = datosPrevios.Where(C => C.NomPlan.Contains(param)).ToList();
                        break;
                    case "Objetivo":
                        datosPrevios = datosPrevios.Where(C => C.ObsObjetivoEspecifico.Contains(param)).ToList();
                        break;
                    case "Sección":
                        datosPrevios = datosPrevios.Where(C => C.FK_Seccion == iParam).ToList();
                        break;
                    case "Estado":
                        datosPrevios = datosPrevios.Where(C => C.FK_EstadoPlan== iParam).ToList();
                        break;
                    case "Año":
                        datosPrevios = datosPrevios.Where(C => C.NumAnnio == iParam).ToList();
                        break;

                    default:
                        datosPrevios = new List<PlanAnual>();
                        break;
                }
            }

            return datosPrevios;
        }

        public int EnlazarProductoAlPlanAnual(PlanEstrategicoProducto producto, PlanAnual plan)
        {
            //Producto productoAnterior = entidadBase.Producto.Where(Q => Q.PK_Producto == producto.PK_Producto).FirstOrDefault();
            PlanAnualProductos productoPlan = entidadBase.PlanAnualProductos.Where(q => q.FK_Producto == producto.PK_Producto && q.FK_Plan == plan.PK_PlanAnual && q.IndEstado == 1).FirstOrDefault();

            if (productoPlan == null )
            {
                productoPlan = new PlanAnualProductos();
                productoPlan.FK_Producto = producto.PK_Producto;
                productoPlan.FK_Plan = plan.PK_PlanAnual;
                productoPlan.IndEstado = 1;
                entidadBase.PlanAnualProductos.Add(productoPlan);
            }
            entidadBase.SaveChanges();
            return productoPlan.PK_ProductoPlan;
        }

        //public int DesenlazarProductoAlPlanAnual(PlanEstrategicoProducto producto, PlanAnual plan)
        //{
        //    PlanAnualProductos productoPlan = new PlanAnualProductos();

        //    productoPlan = entidadBase.PlanAnualProductos.Where(Q => Q.FK_Producto == producto.PK_Producto && Q.FK_Plan == plan.PK_PlanAnual && Q.IndEstado == 1).FirstOrDefault();

        //    if(productoPlan != null)
        //    {
        //        productoPlan.IndEstado = 2;
        //        List<PlanAnualMeta> ms = new List<PlanAnualMeta>();
        //        ms = entidadBase.PlanAnualMeta.Where(q => q.FK_ProductoPlanInstitucional == producto.PK_Producto && q.IndEstado == 1).ToList();
        //        List<PlanAnualActividad> acs = new List<PlanAnualActividad>();
        //        foreach(PlanAnualMeta m in ms)
        //        {
        //            acs.AddRange(entidadBase.PlanAnualActividad.Where(q => q.FK_Meta == m.PK_Meta && q.IndEstado == 1).ToList());
        //            m.IndEstado = 2;
        //        }
        //        foreach(PlanAnualActividad ac in acs)
        //        {
        //            ac.IndEstado = 2;
        //        }
        //    }

        //    entidadBase.SaveChanges();
        //    return productoPlan.PK_ProductoPlan;

        //}
        public int DesenlazarProductoAlPlanAnual(int idPlanProducto)
        {
            var productoPlanOld = entidadBase.PlanAnualProductos.Where(Q => Q.PK_ProductoPlan == idPlanProducto).FirstOrDefault();

            if (productoPlanOld != null)
            {
                productoPlanOld.IndEstado = 2;
                var metaPlanOld = entidadBase.PlanAnualMeta.Where(q => q.FK_ProductoPlanInstitucional == idPlanProducto).ToList();
                
                foreach (var meta in metaPlanOld)
                {
                    meta.IndEstado = 2;
                    var actividadPlanOld = entidadBase.PlanAnualActividad.Where(q => q.FK_Meta == meta.PK_Meta).ToList();
                    foreach (var actividad in actividadPlanOld)
                    {
                        actividad.FK_EstadoActividad = 4;
                    }
                }
                entidadBase.SaveChanges();
                return productoPlanOld.PK_ProductoPlan;
            }

            return 0;
        }

        public List<PlanAnualProductos> ObtenerProductoPlanAnual(int idPlan)
        {
            var resultado = entidadBase.PlanAnualProductos.Where(q => q.FK_Plan == idPlan && q.IndEstado == 1).ToList();
            return resultado;
        }

        public int ModificarEstadoPlan(PlanAnual POI)
        {
            PlanAnual PlanAnterior = entidadBase.PlanAnual.Where(Q => Q.PK_PlanAnual == POI.PK_PlanAnual).FirstOrDefault();

            if (PlanAnterior != null)
            {
                PlanAnterior.FK_EstadoPlan = POI.EstadoPlan.PK_EstadoPlan;
                entidadBase.SaveChanges();
            }
           
            return POI.PK_PlanAnual;
        }

        //public int RemitirPlanAnual(PlanAnual POI, String De, String Para, String Mensaje)
        //{
        //    PlanAnual PlanAnterior = entidadBase.PlanAnual.Where(Q => Q.PK_PlanAnual == POI.PK_PlanAnual).FirstOrDefault();

        //    if (PlanAnterior != null)
        //    {
        //        PlanAnterior.FK_EstadoPlan = 3; //PlanAnterior.FK_EstadoPlanAnual = 3;
        //    }
        //    entidadBase.SaveChanges();
        //    return POI.PK_PlanAnual;
        //}

        #endregion

    }
}

