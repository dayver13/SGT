using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
    public class CPlanAnualActividadD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanAnualActividadD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public int GuardarActividad(PlanAnualActividad actividad)
        {
            PlanAnualMeta meta = entidadBase.PlanAnualMeta.Where(Q => Q.PK_Meta == actividad.FK_Meta).FirstOrDefault();
            meta.PorPeso = meta.PorPeso - actividad.PorMeta;
            entidadBase.PlanAnualActividad.Add(actividad);
            entidadBase.SaveChanges();
            return actividad.PK_Actividad;
        }

        public int UpdateActividad(PlanAnualActividad actividad)
        {
            PlanAnualActividad actividadAnterior = entidadBase.PlanAnualActividad.Where(Q => Q.PK_Actividad == actividad.PK_Actividad).FirstOrDefault();
            PlanAnualMeta meta = entidadBase.PlanAnualMeta.Where(Q => Q.PK_Meta == actividad.PlanAnualMeta.PK_Meta).FirstOrDefault();
            int porcentajes = 0;
            List<PlanAnualActividad> acts = new List<PlanAnualActividad>();
            acts = actividad.PlanAnualMeta.PlanAnualActividad.ToList();
            //acts = entidadBase.PlanAnualActividad.Where(q => q.FK_Meta == meta.PK_Meta && q.IndEstado == 1).ToList();

            for (int i = 0; i < acts.Count(); i++)
            {
                if (acts[i].PK_Actividad != actividad.PK_Actividad)
                {
                    porcentajes = porcentajes + (int)acts[i].PorMeta;
                }
            }
            porcentajes = porcentajes + (int)actividad.PorMeta;
            meta.PorPeso = 100 - porcentajes;

            if (actividadAnterior != null)
            {
                actividadAnterior.DesActividad = actividad.DesActividad;
                actividadAnterior.PorAvancePrevisto = actividad.PorAvancePrevisto;
                if(actividad.FecInicioProgramada.Value.Year > 1)
                    actividadAnterior.FecInicioProgramada = actividad.FecInicioProgramada;
                if (actividad.FecFinalProgramada.Value.Year > 1)
                    actividadAnterior.FecFinalProgramada = actividad.FecFinalProgramada;
                actividadAnterior.DesActividadAnual = actividad.DesActividadAnual;
                actividadAnterior.ObsActividad = actividad.ObsActividad;
                actividadAnterior.PorMeta = actividad.PorMeta;
                actividadAnterior.FK_EstadoActividad = actividad.FK_EstadoActividad;
            }
            entidadBase.SaveChanges();
            return actividad.PK_Actividad;
        }

        public int ActualizarFuncionariosAsignados(int idActividad, int[] lista)
        {
            var actividadFuncionarios = entidadBase.PlanAnualActividadFuncionario.Where(Q => Q.FK_Actividad == idActividad).ToList();
            
            foreach (var item in actividadFuncionarios)
            {
                item.IndActivo = false;
            }
            entidadBase.SaveChanges();

            foreach (int i in lista)
            {
               var dato = entidadBase.PlanAnualActividadFuncionario.Where(Q => Q.FK_Actividad == idActividad && Q.FK_Funcionario == i).FirstOrDefault();

                if(dato != null)
                {
                    dato.IndActivo = true;
                }
                else
                {
                    entidadBase.PlanAnualActividadFuncionario.Add(new PlanAnualActividadFuncionario {
                        FK_Actividad = idActividad,
                        FK_Funcionario = i,
                        IndActivo = true
                    });
                }
            }
            
            entidadBase.SaveChanges();
            return idActividad;
        }

        public int UpdateActividad_AccionPlanAnual(PlanAnualActividad actividad)
        {
            PlanAnualActividad actividadAnterior = entidadBase.PlanAnualActividad.Where(Q => Q.PK_Actividad == actividad.PK_Actividad).FirstOrDefault();
            if (actividadAnterior != null)
            {
                actividadAnterior.DesActividadAnual = actividad.DesActividadAnual;
            }
            entidadBase.SaveChanges();
            return actividad.PK_Actividad;
        }
      
        public int DeleteActividad(PlanAnualActividad actividad)
        {
            PlanAnualActividad actividadAnterior = entidadBase.PlanAnualActividad.Where(Q => Q.PK_Actividad == actividad.PK_Actividad).FirstOrDefault();
           
            actividad.PlanAnualMeta.PorPeso = actividad.PlanAnualMeta.PorPeso + actividad.PorMeta;
            if (actividadAnterior != null)
            {
                actividadAnterior.FK_EstadoActividad = 4;
            }
            entidadBase.SaveChanges();
            return actividadAnterior.PK_Actividad;
        }

        public PlanAnualActividad ObtenerActividad(int idActividad)
        {
            var resultado = entidadBase.PlanAnualActividad.Where(q => q.PK_Actividad == idActividad && q.FK_EstadoActividad != 4).FirstOrDefault();
            return resultado;
        }


        // Funcionarios Actividad
        public int GuardarFuncionario(PlanAnualActividadFuncionario funcionario)
        {
            entidadBase.PlanAnualActividadFuncionario.Add(funcionario);
            entidadBase.SaveChanges();
            return funcionario.PK_ActividadPlanFuncionario;
        }

        public int ModificarFuncionario(int idActividadF)
        {
            var actividadAnterior = entidadBase.PlanAnualActividadFuncionario.Where(Q => Q.PK_ActividadPlanFuncionario == idActividadF).FirstOrDefault();         
            if (actividadAnterior != null)
            {
                actividadAnterior.IndActivo = false;
                entidadBase.SaveChanges();
                return idActividadF;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}