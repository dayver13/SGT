using SIRH.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
   public class CPlanEstrategicoD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanEstrategicoD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el plan en la BD
        /// </summary>
        

        public int GuardarPlan(PlanEstrategico PEI)
        {
            entidadBase.PlanEstrategico.Add(PEI);
            entidadBase.SaveChanges();
            return PEI.PK_PlanEstrategico;
        }

        public int ActualizarPlan(PlanEstrategico PEI)
        {
            var PlanAnterior = entidadBase.PlanEstrategico.Where(Q => Q.PK_PlanEstrategico == PEI.PK_PlanEstrategico).FirstOrDefault();

            if (PlanAnterior != null)
            {
                PlanAnterior.FecInicio = PEI.FecInicio;
                PlanAnterior.FecFinal = PEI.FecFinal;
                PlanAnterior.NomPlanEstrategico = PEI.NomPlanEstrategico;
                PlanAnterior.DireccionGeneral = PEI.DireccionGeneral;
            }
            
            entidadBase.SaveChanges();
            return PEI.PK_PlanEstrategico;
        }

        public int RemitirPlanEstrategico(PlanEstrategico PEI, String De, String Para, String Mensaje)
        {
            var PlanAnterior = entidadBase.PlanEstrategico.Where(Q => Q.PK_PlanEstrategico == PEI.PK_PlanEstrategico).FirstOrDefault();
            var EstadoAnterior = entidadBase.EstadoPlan.Where(Q => Q.PK_EstadoPlan == 3).FirstOrDefault();

            if (PlanAnterior != null && EstadoAnterior != null)
            {
                PlanAnterior.EstadoPlan = EstadoAnterior;
            }

            entidadBase.SaveChanges();
            return PEI.PK_PlanEstrategico;
        }

        public PlanEstrategico ObtenerPlan(int idPlan)
        {
            var resultado = entidadBase.PlanEstrategico.Where(q => q.PK_PlanEstrategico==idPlan).FirstOrDefault();
            return resultado;
        }

        public CRespuestaDTO BuscarPlanEstrategico(List<PlanEstrategico> datosPrevios, object parametro, string elemento)
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
                        Contenido = datos
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

        private List<PlanEstrategico> CargarDatos(string elemento, List<PlanEstrategico> datosPrevios, object parametro)
        {
            string param = "";
            int iParam = 0;
            DateTime paramFechaInicio = new DateTime();
            DateTime paramFechaFinal = new DateTime();

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
                else
                {
                    paramFechaInicio = ((List<DateTime>)parametro).ElementAt(0);
                    paramFechaFinal = ((List<DateTime>)parametro).ElementAt(1);
                }
            }

            if (datosPrevios.Count < 1)
            {
                switch (elemento)
                {
                    case "Nombre":
                        datosPrevios = entidadBase.PlanEstrategico
                                                    .Where(C => C.NomPlanEstrategico.Contains(param)).ToList();
                        break;
                    case "Fechas":
                        datosPrevios = entidadBase.PlanEstrategico
                                                    .Where(C => C.FecInicio >= paramFechaInicio &&
                                                        C.FecFinal <= paramFechaFinal)
                                                    .ToList();
                        break;
                    case "Estado":
                        if (iParam == -1) // No mostrar las Anuladas
                            datosPrevios = entidadBase.PlanEstrategico
                                                    .Where(C => C.FK_EstadoPlan != 2).ToList();
                        else
                            datosPrevios = entidadBase.PlanEstrategico
                                                   .Where(C => C.FK_EstadoPlan == iParam).ToList();
                        break;
                    case "Direccion":
                        datosPrevios = entidadBase.PlanEstrategico
                                                    .Where(C => C.FK_Direccion == iParam).ToList();
                        break;
                    default:
                        datosPrevios = new List<PlanEstrategico>();
                        break;
                }
            }
            else
            {
                switch (elemento)
                {
                    case "Nombre":
                        datosPrevios = datosPrevios.Where(C => C.NomPlanEstrategico.Contains(param)).ToList();
                        break;
                    case "Fechas":
                        datosPrevios = datosPrevios.Where(C => C.FecInicio >= paramFechaInicio &&
                                                        C.FecFinal <= paramFechaFinal)
                                                    .ToList();
                        break;
                    case "Direccion":
                        datosPrevios = datosPrevios.Where(C => C.FK_Direccion == iParam).ToList();
                        break;
                    case "Estado":
                        datosPrevios = datosPrevios.Where(C => C.FK_EstadoPlan== iParam).ToList();
                        break;
                    default:
                        datosPrevios = new List<PlanEstrategico>();
                        break;
                }
            }

            return datosPrevios;
        }

        #endregion
    }
}

