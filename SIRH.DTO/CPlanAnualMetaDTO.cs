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
    public class CPlanAnualMetaDTO : CBaseDTO
    {
        [DataMember]
        public CPlanAnualDTO PlanAnual { get; set; }

        [DataMember]
        public CPlanEstrategicoProductoDTO Producto { get; set; }

        [DataMember]
        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción de la meta es requerida.")]
        public string Descripcion { get; set; }

        [DataMember]
        [DisplayName("Porcentaje meta")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El porcentaje de la meta es requerido.")]
        public float PorcentajeMeta { get; set; }

        [DataMember]
        [DisplayName("Estado")]
        public int EstadoMeta { get; set; }

        [DataMember]
        public List<CPlanAnualActividadDTO> ListaActividades { get; set; }
        
        [DataMember]
        public float PorcentajeRealMetaInstitucional { get; set; }

    }
}

