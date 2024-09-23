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
    public class CCalificacionAutoEvaluacionDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("FK_Periodo")]
        public CPeriodoCalificacionDTO Periodo { get; set; }

        [DataMember]
        [DisplayName("FK_Funcionario")]
        public CFuncionarioDTO Funcionario { get; set; }

        [DataMember]
        [DisplayName("FK_Tipo")]
        public CTipoAutoEvaluacionDTO Tipo { get; set; }
        
        [DataMember]
        [DisplayName("Estado")]
        public int IndEstado { get; set; }
            
        [DataMember]
        [DisplayName("Nota")]
        public decimal PorNota { get; set; }

        [DataMember]
        [DisplayName("DetalleNota")]
        public string DesNota { get; set; }

        [DataMember]
        [DisplayName("NECESITA DESARROLLAR")]
        public decimal PorDesarrollar { get; set; }

        [DataMember]
        [DisplayName("NECESITA MEJORAR")]
        public decimal PorMejorar { get; set; }

        [DataMember]
        [DisplayName("CUMPLE CON LAS ESPECTATIVAS")]
        public decimal PorCumple { get; set; }

        [DataMember]
        [DisplayName("Valor Calificacion")]
        public string seleccion { get; set; }
    }
}
