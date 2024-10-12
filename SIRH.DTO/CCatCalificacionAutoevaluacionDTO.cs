using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SIRH.DTO
{
    [DataContract]
    public class CCatCalificacionAutoevaluacionDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("FK_Clase")]
        public CClaseDTO Clase { get; set; }
        
        [DataMember]
        [DisplayName("FK_Tipo")]
        public CTipoAutoEvaluacionDTO Tipo { get; set; }
                  
        [DataMember]
        [DisplayName("PorDesarrollar")]
        public decimal PorDesarrollar { get; set; }

        [DataMember]
        [DisplayName("PorMejorar")]
        public decimal PorMejorar { get; set; }

        [DataMember]
        [DisplayName("Cumple")]
        public decimal PorCumple { get; set; }

        [DataMember]
        [DisplayName("INTERMEDIO")]
        public bool bolDesarrollar { get; set; }

        [DataMember]
        [DisplayName("POR MEJORAR")]
        public bool bolMejorar { get; set; }

        [DataMember]
        [DisplayName("CUMPLE")]
        public bool bolCumple { get; set; }

        [DataMember]
        [DisplayName("Valor Calificacion")]
        public string seleccion { get; set; }
    }
}
