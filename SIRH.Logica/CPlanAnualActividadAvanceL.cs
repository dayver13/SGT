using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CPlanAnualActividadAvanceL
    {
        #region Variables

        SIRHEntities contexto;
        CPlanAnualActividadAvanceD actividadAvanceDescarga;

        #endregion

        #region Constructor

        public CPlanAnualActividadAvanceL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos
        internal static CPlanAnualActividadAvanceDTO ConvertirActividadADTO(PlanAnualActividadAvance item)
        {

            CPlanAnualActividadAvanceDTO respuesta = new CPlanAnualActividadAvanceDTO
            {
                IdEntidad = item.PK_Avance, 
                IndEstado = item.IndEstado,
                ObsAvance = item.DesObservacion,
                DescEvidencias = item.DesEvidencia,
                PorAvance = (float)item.PorAvance,
                NumMes = item.NumMes,
                NombreMes = new DateTime(1,item.NumMes,1).ToString("MMMM").ToUpper(),
                PlanAnualActividad = item.PlanAnualActividad != null?
                                new CPlanAnualActividadDTO
                                { 
                                    IdEntidad = item.PlanAnualActividad.PK_Actividad,
                                    DescripcionActividad = item.PlanAnualActividad.DesActividad
                                } :
                                new CPlanAnualActividadDTO
                                {
                                    IdEntidad = 0,
                                    DescripcionActividad = ""},
            };
            return respuesta;
        }


        internal static PlanAnualActividadAvance ConvertirActividadDTOaDatos(CPlanAnualActividadAvanceDTO item)
        {
            PlanAnualActividadAvance respuesta = new PlanAnualActividadAvance() 
            {
                PK_Avance = item.IdEntidad,
                IndEstado = item.IndEstado,
                DesObservacion = item.ObsAvance,
                DesEvidencia = item.DescEvidencias,
                PorAvance = (decimal)item.PorAvance,
                NumMes = item.NumMes
        };

            return respuesta;
        }

        public CBaseDTO AgregarAvance(CPlanAnualActividadAvanceDTO avance)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanAnualActividadD entidadPlanAnual = new CPlanAnualActividadD(contexto);
                actividadAvanceDescarga = new CPlanAnualActividadAvanceD(contexto);
                var datoAvance = ConvertirActividadDTOaDatos(avance);


                // Validar de que exista una actividad padre
                if (avance.PlanAnualActividad != null)
                {
                    datoAvance.PlanAnualActividad = entidadPlanAnual.ObtenerActividad(avance.PlanAnualActividad.IdEntidad);
                }
                var respuesta = 0;

                datoAvance.FK_ActividadPlanAnual = datoAvance.PlanAnualActividad.PK_Actividad;

                var porcentajeReal = datoAvance.PlanAnualActividad.PorAvanceReal;
                var porcentajeAvance = datoAvance.PorAvance;
                var porcentaje = porcentajeReal + porcentajeAvance;

                // Validar que no se exceda el avance real
                if (porcentaje > 100)
                {
                    throw new Exception("El Avance Real no puede exceder el 100%");
                }

                respuesta = actividadAvanceDescarga.GuardarAvance(datoAvance);
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
                    throw new Exception("No se pudo registrar el avance");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        //NUEVO
        public CBaseDTO DeleteAvance(CPlanAnualActividadAvanceDTO avance)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();

                actividadAvanceDescarga = new CPlanAnualActividadAvanceD(contexto);

                var datoAvance = actividadAvanceDescarga.ObtenerAvance(avance.IdEntidad);

                datoAvance.PK_Avance = avance.IdEntidad;
                var respuesta = actividadAvanceDescarga.DeleteAvance(datoAvance);

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
                    throw new Exception("No se pudo remover la actividad del plan anual");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
            
        }

        public List<CBaseDTO> CargarAvancesActividad(int idActividad)
        {
            List<CBaseDTO> resultado = new List<CBaseDTO>();
            actividadAvanceDescarga = new CPlanAnualActividadAvanceD(contexto);
            var item = actividadAvanceDescarga.CargarAvancesPorActividad(idActividad);
            foreach (var aux in item)
            {
                resultado.Add(ConvertirActividadADTO(aux));
            }
            return resultado;
        }

        public CBaseDTO UpdateAvance(CPlanAnualActividadAvanceDTO avance)
        {
            try
            {
                CBaseDTO resultado = new CBaseDTO();
                CPlanAnualActividadD entidadPlanAnual = new CPlanAnualActividadD(contexto);

                actividadAvanceDescarga = new CPlanAnualActividadAvanceD(contexto);
                var datoAvance = ConvertirActividadDTOaDatos(avance);
                
                // Validar de que exista una actividad padre
                if (avance.PlanAnualActividad != null)
                {
                    datoAvance.PlanAnualActividad = entidadPlanAnual.ObtenerActividad(avance.PlanAnualActividad.IdEntidad);
                }
                var respuesta = 0;

                respuesta = actividadAvanceDescarga.UpdateAvance(datoAvance);
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
                    throw new Exception("No se pudo registrar el Avance");
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }



        public CPlanAnualActividadAvanceDTO CargarAvancePorId(int idAvance)
        {
            actividadAvanceDescarga = new CPlanAnualActividadAvanceD(contexto);
            var item = actividadAvanceDescarga.ObtenerAvance(idAvance);
            var resultado = ConvertirActividadADTO(item);
            return resultado;
        }

        #endregion
    }
}