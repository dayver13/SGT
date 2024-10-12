using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIRH.DTO
{
    public class CPlanAnualActividadDTO : CBaseDTO
    {
        [DataMember]
        public CPlanAnualMetaDTO Meta {get; set;}
        [DataMember]
        public CEstadoActividadDTO Estado { get; set; }
        [DataMember]
        public float PorcentajeMeta { get; set; }
        [DataMember]
        public string DescripcionActividad { get; set; }
       
        [DataMember]
        public string DesActividadAnual { get; set; }

        //[DataMember]
        //public List<CPlanAnualActividadDTO> ListaActividadPlanAnual { get; set; }

        [DataMember]
        public float PorcentajeRealActInstitucional{ get; set; }

        [DataMember]
        [DisplayName("Porcentaje Avance Real")]
        public float PorAvanceReal { get; set; }
        [DataMember]
        [DisplayName("Porcentaje Avance Previo")]
        public float PorAvancePrevio { get; set; }
        [DataMember]
        [DisplayName("Fecha Inicio Programada")]
        public DateTime FechaInicioProgramada { get; set; }
        [DataMember]
        [DisplayName("Fecha Final Programada")]
        public DateTime FechaFinalProgramada { get; set; }
        [DataMember]
        [DisplayName("Fecha Inicio Real")]
        public DateTime FechaInicioReal { get; set; }
        [DataMember]
        [DisplayName("Fecha Final Programada")]
        public DateTime FechaFinalReal { get; set; }

        [DataMember]
        [DisplayName("Observaciones")]
        public string ObsActividad { get; set; }

        [DisplayName("Versión")]
        public int Version { get; set; }

        [DataMember]
        public List<CPlanAnualActividadAvanceDTO> ListaAvances { get; set; }

        [DataMember]
        public List<CFuncionarioDTO> ListaFuncionarios { get; set; }

    }
}
