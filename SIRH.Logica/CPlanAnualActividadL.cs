using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanAnualActividadL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanAnualActividadD actividadDescarga;

        #endregion

        #region Constructor

        public CPlanAnualActividadL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanAnualActividadDTO ConvertirActividadADTO(PlanAnualActividad item)
        {
            
            var listaFuncionario = new List<CFuncionarioDTO>();  
            foreach (var funcionario in item.PlanAnualActividadFuncionario.Where(Q => Q.IndActivo == true).ToList()) 
            {
                listaFuncionario.Add(CFuncionarioL.ConvertirDatosFuncionarioADTO(funcionario.Funcionario));
            }


            var listaAvances = new List<CPlanAnualActividadAvanceDTO>();
            for (int i = 1; i <= 12; i++)
            {
                var avance = new CPlanAnualActividadAvanceDTO {
                    IdEntidad = -1, // -1, Actividad no programada para trabajar ese mes
                    NumMes = i,
                    NombreMes = new DateTime(1, i, 1).ToString("MMMM").ToUpper(),
                }; 

                if (i >= item.FecInicioProgramada.Value.Month && i <= item.FecFinalProgramada.Value.Month)
                {
                    var accion = item.PlanAnualActividadAvance.Where(Q => Q.IndEstado == 1 && Q.NumMes == i).FirstOrDefault();
                    if (accion != null)
                        avance = CPlanAnualActividadAvanceL.ConvertirActividadADTO(accion);
                    else
                        avance.IdEntidad = 0;
                }
                listaAvances.Add(avance);
            }

            //foreach (var accion in item.PlanAnualActividadAvance.Where(Q => Q.IndEstado == 1).ToList())
            //{
            //    listaAvances.Add(CPlanAnualActividadAvanceL.ConvertirActividadADTO(accion));
            //}



            var valorIndividual = 0;
            var contadorCompletas = 0;
            ////Valor de cada una
            //if (listaActividades != null && listaActividades.Count()>0)
            //{
            //    valorIndividual = 100 / listaActividades.Count();
            //    contadorCompletas = 0;
            //    foreach(var x in listaActividades)
            //    {
            //        if(x.PorAvanceReal >= 100)
            //        {
            //            contadorCompletas++;
            //        }
            //    }
            //}
            
            CPlanAnualActividadDTO respuesta = new CPlanAnualActividadDTO
            {
                IdEntidad = item.PK_Actividad,
                Meta = item.PlanAnualMeta != null ?
                new CPlanAnualMetaDTO { Descripcion = item.PlanAnualMeta.DesMeta, PorcentajeMeta = (float)item.PlanAnualMeta.PorPeso, IdEntidad = item.PlanAnualMeta.PK_Meta, EstadoMeta = item.PlanAnualMeta.IndEstado }
                : new CPlanAnualMetaDTO { Descripcion = "", PorcentajeMeta = 0, IdEntidad = 0 },
                DescripcionActividad = item.DesActividad,
                DesActividadAnual = item.DesActividadAnual,
                PorcentajeMeta = (float)item.PorMeta,
                Estado = new CEstadoActividadDTO { IdEntidad = item.EstadoActividadPlan.PK_Estado , DesEstadoActividad = item.EstadoActividadPlan.DesEstado},
                PorAvanceReal = (float)item.PorAvanceReal,
                PorAvancePrevio = (float)item.PorAvancePrevisto,
                FechaInicioProgramada = Convert.ToDateTime(item.FecInicioProgramada),
                FechaFinalProgramada = Convert.ToDateTime(item.FecFinalProgramada),
                FechaInicioReal = Convert.ToDateTime(item.FecInicioReal),
                FechaFinalReal = Convert.ToDateTime(item.FecFinalReal),
                ObsActividad = item.ObsActividad,
                ListaAvances = listaAvances,
                ListaFuncionarios = listaFuncionario,
                PorcentajeRealActInstitucional = valorIndividual * contadorCompletas
            };

            return respuesta;
        }


        internal static PlanAnualActividad ConvertirActividadDTOaDatos(CPlanAnualActividadDTO item)
        {
            PlanAnualActividad respuesta = new PlanAnualActividad
            {
                DesActividad = item.DescripcionActividad,
                DesActividadAnual = item.DesActividadAnual != null ? item.DesActividadAnual  : "",
                PorMeta = (decimal)item.PorcentajeMeta,
                PorAvanceReal = (decimal)item.PorAvanceReal,
                PorAvancePrevisto = (decimal)item.PorAvancePrevio,
                FecInicioProgramada = item.FechaInicioProgramada,
                FecFinalProgramada = item.FechaFinalProgramada,
                FecInicioReal = item.FechaInicioReal,
                FecFinalReal = item.FechaFinalReal,
                FK_EstadoActividad = item.Estado.IdEntidad,
                NumVersion = item.Version,
                ObsActividad = item.ObsActividad != null ? item.ObsActividad : ""
            };
            return respuesta;
        }

        public CBaseDTO AgregarActividad(CPlanAnualActividadDTO actividad)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanAnualMetaD entidadMeta = new CPlanAnualMetaD(contexto);

                actividadDescarga = new CPlanAnualActividadD(contexto);
                var datoActividad = new PlanAnualActividad();
                datoActividad = ConvertirActividadDTOaDatos(actividad);


                // Validar de que exista una meta madre
                if (actividad.Meta != null)
                {
                    datoActividad.PlanAnualMeta = entidadMeta.ObtenerMeta(actividad.Meta.IdEntidad);
                }
                var respuesta = 0;
                datoActividad.FK_Meta = datoActividad.PlanAnualMeta.PK_Meta;

                var pm = datoActividad.PlanAnualMeta.PorPeso;
                var pa = datoActividad.PorMeta;
                var pp = pm - pa;

                if (pp < 0)
                {
                    throw new Exception("No se pudo registrar la actividad porque el porcentaje de la actividad es mayor que el porcentaje de la meta");
                }

                respuesta = actividadDescarga.GuardarActividad(datoActividad);
                if (respuesta > 0)
                {
                    foreach (var item in actividad.ListaFuncionarios)
                    {
                        var datoFuncionario = new PlanAnualActividadFuncionario
                        {
                            FK_Actividad = respuesta,
                            FK_Funcionario = item.IdEntidad,
                            IndActivo = true
                        };
                        actividadDescarga.GuardarFuncionario(datoFuncionario);
                    }

                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo registrar la actividad");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        //NUEVO
        public CBaseDTO DeleteActividad(CPlanAnualActividadDTO actividad)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                actividadDescarga = new CPlanAnualActividadD(contexto);
                
                var datoActividad = actividadDescarga.ObtenerActividad(actividad.IdEntidad);
                datoActividad.PK_Actividad = actividad.IdEntidad;
                
                var respuesta = actividadDescarga.DeleteActividad(datoActividad);

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
                    throw new Exception("No se pudo remover la actividad");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        //

        public CBaseDTO ModificarActividad(CPlanAnualActividadDTO actividad)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanAnualMetaD entidadMeta = new CPlanAnualMetaD(contexto);
                actividadDescarga = new CPlanAnualActividadD(contexto);
                var datoActividad = new PlanAnualActividad();
                datoActividad = ConvertirActividadDTOaDatos(actividad);
                datoActividad.PK_Actividad = actividad.IdEntidad; // IMPORTANTE
                datoActividad.PlanAnualMeta = entidadMeta.ObtenerMeta(actividad.Meta.IdEntidad);
                datoActividad.FK_Meta = actividad.Meta.IdEntidad;
                int pp = 0;
                int porcentajes = 0;
                List<PlanAnualActividad> acts = new List<PlanAnualActividad>();
                acts = datoActividad.PlanAnualMeta.PlanAnualActividad.ToList();
                for (int i = 0; i < acts.Count(); i++)
                {
                    if (acts[i].PK_Actividad != datoActividad.PK_Actividad)
                    {
                        porcentajes = porcentajes + (int)acts[i].PorMeta;
                    }
                }
                porcentajes = porcentajes + (int)datoActividad.PorMeta;
                pp = 100 - porcentajes;

                if (pp < 0)
                {
                    throw new Exception("No se pudo registrar la actividad porque el porcentaje de la actividad es mayor que el porcentaje de la meta");
                }

                var respuesta = actividadDescarga.UpdateActividad(datoActividad);

                if (respuesta > 0)
                {
                    // Actualizar los Funcionarios asignados
                    var lista = actividad.ListaFuncionarios.Select(Q => Q.IdEntidad).ToArray();
                    respuesta = actividadDescarga.ActualizarFuncionariosAsignados(actividad.IdEntidad, lista);

                    return new CRespuestaDTO
                    {
                        IdEntidad = 1,
                        Contenido = respuesta
                    };
                }
                else
                {
                    throw new Exception("No se pudo actualizar la actividad");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO UpdateActividad_AccionPlanAnual(CPlanAnualActividadDTO actividad)
        {
            try
            {

                actividadDescarga = new CPlanAnualActividadD(contexto);
                var datoActividad = new PlanAnualActividad();
                datoActividad = ConvertirActividadDTOaDatos(actividad);
                datoActividad.PK_Actividad = actividad.IdEntidad; // IMPORTANTE

                var respuesta = actividadDescarga.UpdateActividad_AccionPlanAnual(datoActividad);

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
                    throw new Exception("No se pudo actualizar la accion del plan anual");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }



        public CPlanAnualActividadDTO CargarActividadPorId(int idActividad)
        {
            CPlanAnualActividadDTO resultado = new CPlanAnualActividadDTO();
            CPlanAnualMetaD metaDescarga = new CPlanAnualMetaD(contexto);
            actividadDescarga = new CPlanAnualActividadD(contexto);
            var item = actividadDescarga.ObtenerActividad(idActividad);
            resultado = ConvertirActividadADTO(item);
            return resultado;
        }


        public CBaseDTO ModificarFuncionario(CPlanAnualActividadFuncionarioDTO actividad)
        {
            try
            {
                CPlanAnualMetaD entidadMeta = new CPlanAnualMetaD(contexto);

                var respuesta = actividadDescarga.ModificarFuncionario(actividad.IdEntidad);
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
                    throw new Exception("No se pudo registrar la actividad");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        #endregion
    }
}