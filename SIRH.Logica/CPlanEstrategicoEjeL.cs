using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanEstrategicoEjeL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanEstrategicoEjeD ejeDescarga;

        #endregion

        #region Constructor

        public CPlanEstrategicoEjeL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanEstrategicoEjeDTO ConvertirEjeADTO(PlanEstrategicoEje item)
        {

            var listaLinea = new List<CPlanEstrategicoLineaDTO>();
            foreach (var linea in item.PlanEstrategicoLinea.Where(Q => Q.IndEstado ==1).ToList())
            {
                listaLinea.Add(CPlanEstrategicoLineaL.ConvertirLineaADTO(linea));
            }

            CPlanEstrategicoEjeDTO respuesta = new CPlanEstrategicoEjeDTO
            {
                IdEntidad = item.PK_Eje,
                NumeroEje = item.NumEje,
                Descripcion = item.DesEje,
                EstadoEje = item.IndEstado,
                Seccion = item.Seccion != null ?
                                new CSeccionDTO {
                                    IdEntidad = item.Seccion.PK_Seccion,
                                    NomSeccion = item.Seccion.NomSeccion
                                } :
                                new CSeccionDTO { IdEntidad = 0, NomSeccion = "" },

                PlanEstrategico = item.PlanEstrategico != null ?
                                new CPlanEstrategicoDTO
                                {
                                    IdEntidad = item.PlanEstrategico.PK_PlanEstrategico,
                                    NumeroVersion = item.PlanEstrategico.NumVersion,
                                    Nombre = item.PlanEstrategico.NomPlanEstrategico,
                                    FechaFinal = Convert.ToDateTime(item.PlanEstrategico.FecFinal),
                                    FechaInicio = Convert.ToDateTime(item.PlanEstrategico.FecInicio),
                                    EstadoPlan = new CEstadoPlanDTO { DesEstadoPlan = item.PlanEstrategico.EstadoPlan.DesEstadoPlan , IdEntidad = item.PlanEstrategico.EstadoPlan.PK_EstadoPlan }
                                } :
                                new CPlanEstrategicoDTO { IdEntidad = 0, NumeroVersion = 0, Nombre = "", FechaFinal = new DateTime(), FechaInicio = new DateTime() },
                Departamento = item.Departamento != null ?
                                new CDepartamentoDTO
                                {
                                    IdEntidad = item.Departamento.PK_Departamento,
                                    NomDepartamento = item.Departamento.NomDepartamento,
                                    IndEstDepartamento = Convert.ToInt32(item.Departamento.IndEstadoDepartamento),
                                } :
                                new CDepartamentoDTO { IdEntidad = 0, NomDepartamento = "", IndEstDepartamento = 0 },
                ListaLinea = listaLinea
            };

            return respuesta;
        }

        internal static PlanEstrategicoEje ConvertirEjeDTOaDatos(CPlanEstrategicoEjeDTO item)
        {
            var respuesta = new PlanEstrategicoEje
            {
                NumEje = Convert.ToInt32(item.NumeroEje),
                DesEje = item.Descripcion,
                IndEstado = item.EstadoEje
            };
            return respuesta;
        }

        public CBaseDTO AgregarEje(CPlanEstrategicoEjeDTO eje)
        {
            try
            {
                //
                CBaseDTO resultado = new CBaseDTO();
                CDepartamentoD entidadDepartameneto = new CDepartamentoD(contexto);
                CPlanEstrategicoD entidadPlan = new CPlanEstrategicoD(contexto);
                CSeccionD entidadSeccion = new CSeccionD(contexto);
                //

                ejeDescarga = new CPlanEstrategicoEjeD(contexto);
                var datoEje = ConvertirEjeDTOaDatos(eje);
                
                // Validar de que exista una Seccion 
                if (eje.Seccion != null)
                {
                    datoEje.Seccion = entidadSeccion.CargarSeccionPorID(eje.Seccion.IdEntidad);
                }

                // Validar de que exista un departamento
                if (eje.Departamento != null)
                {
                    datoEje.Departamento = entidadDepartameneto.CargarDepartamentoPorID(eje.Departamento.IdEntidad);
                }

                // Validar de que exista una Plan estrategico padre
                if (eje.PlanEstrategico != null)
                {
                    datoEje.PlanEstrategico = entidadPlan.ObtenerPlan(eje.PlanEstrategico.IdEntidad);
                }


                var respuesta = ejeDescarga.GuardarEje(datoEje);

                if (respuesta > 0)
                {
                    return new CRespuestaDTO { 
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar el Eje");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }          
        }

        //NUEVO
        public CBaseDTO DeleteEje(CPlanEstrategicoEjeDTO eje)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                ejeDescarga = new CPlanEstrategicoEjeD(contexto);
                var datoEje = ConvertirEjeDTOaDatos(eje);
                datoEje.PK_Eje = eje.IdEntidad;

                var respuesta = ejeDescarga.DeleteEje(datoEje);

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
                    throw new Exception("No se pudo remover el eje");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }
        
        public CBaseDTO ActulizarEje(CPlanEstrategicoEjeDTO eje)
        {
            try
            {
                //
                CBaseDTO resultado = new CBaseDTO();
                CDepartamentoD entidadDepartameneto = new CDepartamentoD(contexto);
                CPlanEstrategicoD entidadPlan = new CPlanEstrategicoD(contexto);
                CSeccionD entidadSeccion = new CSeccionD(contexto);
                //

                ejeDescarga = new CPlanEstrategicoEjeD(contexto);
                var datoEje = ConvertirEjeDTOaDatos(eje);

                //importante
                datoEje.PK_Eje = eje.IdEntidad;


                // Validar de que exista una Seccion 
                if (eje.Seccion != null)
                {
                    datoEje.Seccion = entidadSeccion.CargarSeccionPorID(eje.Seccion.IdEntidad);
                }

                // Validar de que exista un departamento
                if (eje.Departamento != null)
                {
                    datoEje.Departamento = entidadDepartameneto.CargarDepartamentoPorID(eje.Departamento.IdEntidad);
                }

                // Validar de que exista una Plan estrategico padre
                if (eje.PlanEstrategico != null)
                {
                    datoEje.PlanEstrategico = entidadPlan.ObtenerPlan(eje.PlanEstrategico.IdEntidad);
                }


                var respuesta = ejeDescarga.ActualizarEje(datoEje);

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
                    throw new Exception("No se pudo actulizar el Eje");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CPlanEstrategicoEjeDTO CargarEjePorId(int idEje)
        {
            CPlanEstrategicoEjeDTO resultado = new CPlanEstrategicoEjeDTO();
            ejeDescarga = new CPlanEstrategicoEjeD(contexto);
            var item = ejeDescarga.ObtenerEje(idEje);
            resultado = ConvertirEjeADTO(item);
            return resultado;
        }

        public List<CBaseDTO> CargarEjesPlan(int idPlan)
        {
            List<CBaseDTO> resultado = new List<CBaseDTO>();
            ejeDescarga = new CPlanEstrategicoEjeD(contexto);
            var item = ejeDescarga.CargarEjes(idPlan);
            foreach (var aux in item)
            { 
                resultado.Add(ConvertirEjeADTO(aux));
            }
            return resultado;
        }

        #endregion
    }
}
