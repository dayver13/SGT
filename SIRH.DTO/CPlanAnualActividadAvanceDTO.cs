using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIRH.DTO
{
    public class CPlanAnualActividadAvanceDTO : CBaseDTO
    {
        //Referencia a Padre
        [DataMember]
        public CPlanAnualActividadDTO PlanAnualActividad { get; set;}
        [DataMember]
        [DisplayName("Observaciones")]
        public string ObsAvance { get; set; }
        [DataMember]
        [DisplayName("Número de mes")]
        public int NumMes { get; set; }
        [DataMember]
        [DisplayName("Nombre de mes")]
        public string NombreMes { get; set; }
        [DataMember]
        [DisplayName("Evidencias")]
        public string DescEvidencias { get; set; }
        [DataMember]
        [DisplayName("Porcentaje Avance")]
        public float PorAvance { get; set; }
        [DataMember]
        [DisplayName("Estado")]
        public int IndEstado { get; set; }
    }
}
