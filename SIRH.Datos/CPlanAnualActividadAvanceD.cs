using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRH.Datos
{
    public class CPlanAnualActividadAvanceD
    {

        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CPlanAnualActividadAvanceD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos


        public int UpdateAvance(PlanAnualActividadAvance avance)
        {
            var avanceAnterior = entidadBase.PlanAnualActividadAvance.Where(Q => Q.NumMes == avance.NumMes && Q.PlanAnualActividad.PK_Actividad == avance.PlanAnualActividad.PK_Actividad).FirstOrDefault();
            if (avanceAnterior != null)
            {
                var diferencia = avance.PorAvance - avanceAnterior.PorAvance;
                if(avance.PlanAnualActividad.PorAvanceReal + diferencia > 100 || avance.PlanAnualActividad.PorAvanceReal + diferencia < 0)
                {
                    throw new Exception("El porcentaje no puede exceder los límites permitidos");
                }
                avance.PlanAnualActividad.PorAvanceReal += diferencia;
                if (avance.PlanAnualActividad.PorAvanceReal >= 0 && avance.PlanAnualActividad.PorAvanceReal < 50)
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 3; // CRITICO
                }
                else if (avance.PlanAnualActividad.PorAvanceReal < 80)
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 2; // ATRASADO
                }
                else
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 1; // EXCELENTE
                }
                avanceAnterior.DesObservacion = avance.DesObservacion;
                avanceAnterior.DesEvidencia = avance.DesEvidencia;
                avanceAnterior.NumMes = avance.NumMes;
                avanceAnterior.PorAvance = avance.PorAvance;
            }
            entidadBase.SaveChanges();
            return avance.PK_Avance;
        }

        public int GuardarAvance(PlanAnualActividadAvance avance)
        {
            var avanceAnterior = entidadBase.PlanAnualActividadAvance.Where(Q => Q.NumMes == avance.NumMes && Q.PlanAnualActividad.PK_Actividad == avance.PlanAnualActividad.PK_Actividad).FirstOrDefault();
            if (avanceAnterior == null)
            {
                avance.PlanAnualActividad.PorAvanceReal += avance.PorAvance;
                if(avance.PlanAnualActividad.PorAvanceReal >= 0 && avance.PlanAnualActividad.PorAvanceReal < 50)
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 3; // CRITICO
                }
                else if(avance.PlanAnualActividad.PorAvanceReal < 80)
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 2; // ATRASADO
                }
                else
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 1; // EXCELENTE
                }
                entidadBase.PlanAnualActividadAvance.Add(avance);
                entidadBase.SaveChanges();
            }
            else
            {
                return 0;
            }
            return avance.PK_Avance;
        }
        //eliminar Avance
        public int DeleteAvance(PlanAnualActividadAvance avance)
        {
            var avanceAnterior = entidadBase.PlanAnualActividadAvance.Where(Q => Q.PK_Avance == avance.PK_Avance).FirstOrDefault();

            //Avance.PlanAnualMeta.PorPeso = Avance.PlanAnualMeta.PorPeso + Avance.PorMeta;
            if (avanceAnterior != null)
            {
                avance.PlanAnualActividad.PorAvanceReal -= avance.PorAvance;
                if (avance.PlanAnualActividad.PorAvanceReal >= 0 && avance.PlanAnualActividad.PorAvanceReal < 50)
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 3; // CRITICO
                }
                else if (avance.PlanAnualActividad.PorAvanceReal < 80)
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 2; // ATRASADO
                }
                else
                {
                    avance.PlanAnualActividad.FK_EstadoActividad = 1; // EXCELENTE
                }
                avanceAnterior.IndEstado = 2;
            }
            entidadBase.SaveChanges();
            return avanceAnterior.PK_Avance;
            
        }

        public List<PlanAnualActividadAvance> CargarAvancesPorActividad(int idActividad)
        {
            var resultados = entidadBase.PlanAnualActividadAvance.Where(q => q.PK_Avance == idActividad && q.IndEstado == 1).ToList();
            return resultados;
        }

        public PlanAnualActividadAvance ObtenerAvance(int idAvance)
        {
            var resultado = entidadBase.PlanAnualActividadAvance.Where(q => q.PK_Avance == idAvance && q.IndEstado == 1).FirstOrDefault();
            return resultado;
        }
        #endregion

    }
}