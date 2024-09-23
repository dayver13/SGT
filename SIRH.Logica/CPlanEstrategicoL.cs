using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanEstrategicoL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanEstrategicoD planEstrategicoDescarga;

        #endregion

        #region Constructor

        public CPlanEstrategicoL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos
        internal static CPlanEstrategicoDTO ConvertirPlanADTO(PlanEstrategico item)
        {
            var listaEjes = new List<CPlanEstrategicoEjeDTO>();

            foreach (var eje in item.PlanEstrategicoEje.Where(Q => Q.IndEstado ==1))
            {
                listaEjes.Add(CPlanEstrategicoEjeL.ConvertirEjeADTO(eje));
            }

            CPlanEstrategicoDTO respuesta = new CPlanEstrategicoDTO
            {
                IdEntidad = item.PK_PlanEstrategico,
                NumeroVersion = item.NumVersion,
                Nombre = item.NomPlanEstrategico,
                FechaFinal=Convert.ToDateTime(item.FecFinal),
                FechaInicio=Convert.ToDateTime(item.FecInicio),
                DireccionGeneral = item.DireccionGeneral != null ?
                                new CDireccionGeneralDTO {
                                    IdEntidad = item.DireccionGeneral.PK_DireccionGeneral,
                                    NomDireccion = item.DireccionGeneral.NomDireccion
                                } :
                                 new CDireccionGeneralDTO { IdEntidad = 0, NomDireccion = "" },
                EstadoPlan = item.EstadoPlan != null ?
                                new CEstadoPlanDTO
                                {
                                    IdEntidad = item.EstadoPlan.PK_EstadoPlan,
                                    DesEstadoPlan=item.EstadoPlan.DesEstadoPlan
                                } :
                                 new CEstadoPlanDTO { IdEntidad = 0, DesEstadoPlan = "" },
                ListaEjes = listaEjes
            };
            return respuesta;
        }

        internal static PlanEstrategico ConvertirPlanDTOaDatos(CPlanEstrategicoDTO item)
        {
            PlanEstrategico respuesta = new PlanEstrategico
            {
                FecFinal= item.FechaFinal,
                FecInicio = item.FechaInicio,
                NomPlanEstrategico=item.Nombre,
                NumVersion= Convert.ToInt32(item.NumeroVersion)
            };
            return respuesta;
        }

        public CBaseDTO AgregarPlan(CPlanEstrategicoDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CDireccionGeneralD entidaddireccion = new CDireccionGeneralD(contexto);
                CEstadoPlanD entidadestado = new CEstadoPlanD(contexto);
                planEstrategicoDescarga = new CPlanEstrategicoD(contexto);

                var datoplan = new PlanEstrategico();
                datoplan = ConvertirPlanDTOaDatos(plan);


                //Validar de que exista una una Dirección General
                if (plan.DireccionGeneral != null)
                {
                    datoplan.DireccionGeneral = entidaddireccion.CargarDireccionGeneralPorID(plan.DireccionGeneral.IdEntidad);
                }

                if (plan.EstadoPlan != null)
                {
                    datoplan.EstadoPlan = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlan.IdEntidad);
                }
                var respuesta = planEstrategicoDescarga.GuardarPlan(datoplan);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar el plan Estratégico");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }


        public CBaseDTO ActualizarPlan(CPlanEstrategicoDTO plan)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CDireccionGeneralD entidaddireccion = new CDireccionGeneralD(contexto);
                CEstadoPlanD entidadestado = new CEstadoPlanD(contexto);
                planEstrategicoDescarga = new CPlanEstrategicoD(contexto);

                var datoplan = new PlanEstrategico();
                datoplan = ConvertirPlanDTOaDatos(plan);
                datoplan.PK_PlanEstrategico = plan.IdEntidad;
                //Validar de que exista una una Dirección General
                if (plan.DireccionGeneral != null)
                {
                    datoplan.DireccionGeneral = entidaddireccion.CargarDireccionGeneralPorID(plan.DireccionGeneral.IdEntidad);
                }

                if (plan.EstadoPlan != null)
                {
                    datoplan.EstadoPlan = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlan.IdEntidad);
                }
                var respuesta = planEstrategicoDescarga.ActualizarPlan(datoplan);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar el plan Estratégico");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RemitirPlanEstrategico(CPlanEstrategicoDTO plan, String De, String Para, String Mensaje)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CDireccionGeneralD entidaddireccion = new CDireccionGeneralD(contexto);
                CEstadoPlanD entidadestado = new CEstadoPlanD(contexto);
                planEstrategicoDescarga = new CPlanEstrategicoD(contexto);

                var datoplan = new PlanEstrategico();
                //datoplan = ConvertirPlanDTOaDatos(plan);
                datoplan.PK_PlanEstrategico = plan.IdEntidad;
                //Validar de que exista una una Dirección General

                if (plan.EstadoPlan != null)
                {
                    datoplan.EstadoPlan = entidadestado.CargarEstadoPlanPorID(plan.EstadoPlan.IdEntidad);
                }
                var respuesta = planEstrategicoDescarga.RemitirPlanEstrategico(datoplan, De, Para, Mensaje);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar el plan Estratégico");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO CargarPlanPorId(int idPlan)
        {
            planEstrategicoDescarga = new CPlanEstrategicoD(contexto);
            var item = planEstrategicoDescarga.ObtenerPlan(idPlan);
            var resultado = ConvertirPlanADTO(item);
            return resultado;
        }


        public List<CBaseDTO> BuscarPlanEstrategico(CPlanEstrategicoDTO plan, CDireccionGeneralDTO direccion,
                                            List<DateTime> fechas)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            CPlanEstrategicoD intermedio = new CPlanEstrategicoD(contexto);
            
            List<PlanEstrategico> datosPlanes = new List<PlanEstrategico>();
            List<object> parametros = new List<object>();
            List<string> codigos = new List<string>();
            CRespuestaDTO resultado = new CRespuestaDTO { Codigo = -1 }; ;

            bool buscar = true;

            if (plan.Nombre != null)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanEstrategico(datosPlanes, plan.Nombre, "Nombre"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanEstrategico>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (plan.EstadoPlan != null)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanEstrategico(datosPlanes, plan.EstadoPlan, "Estado"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanEstrategico>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (fechas.Count > 0 && buscar)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanEstrategico(datosPlanes, fechas, "Fechas"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanEstrategico>)resultado.Contenido;
                else
                    buscar = false;
            }


            //if (buscar) // Buscar por estado, Si deduccion.Estado == -1, no mostrar las Anuladas (idEstado = 2)
            //{
            //    resultado = ((CRespuestaDTO)intermedio.BuscarDesarraigo(datosDesarraigo, desarraigo.EstadoDesarraigo.IdEntidad, "Estado"));
            //    if (resultado.Codigo > 0)
            //        datosDesarraigo = (List<Desarraigo>)resultado.Contenido;
            //    else
            //        buscar = false;
            //}


            if (direccion != null && direccion.IdEntidad > 0)
            {
                resultado = ((CRespuestaDTO)intermedio.BuscarPlanEstrategico(datosPlanes, direccion.IdEntidad, "Direccion"));
                if (resultado.Codigo > 0)
                    datosPlanes = (List<PlanEstrategico>)resultado.Contenido;
                else
                    buscar = false;
            }

            if (datosPlanes.Count > 0)
            {
                for (int i = 0; i < datosPlanes.Count; i++)
                {
                    var planDTO = ConvertirPlanADTO(datosPlanes[i]);
                    respuesta.Add(planDTO);
                }
            }
            else
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontraron resultados para los parámetros especificados." });
            }
            return respuesta;
        }


        #endregion
    }
}
