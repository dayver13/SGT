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
    public class CPlanAnualDTO : CBaseDTO
    {
        [DataMember]
        public CPlanEstrategicoDTO PlanEstrategico { get; set; }
        [DataMember]
        public CEstadoPlanDTO EstadoPlan { get; set; }
        [DataMember]
        public CSeccionDTO Seccion { get; set; }
        
        [DataMember]
        [DisplayName("Nombre del Plan")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre del Plan Operativo requerido.")]
        public string Nombre { get; set; }

        [DataMember]
        [DisplayName("Versión")]
        public int NumeroVersion { get; set; }

        [DataMember]
        [DisplayName("Objetivo Específico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El objetivo específico es requerido")]
        public string ObjetivoE { get; set; }

        [DataMember]
        [DisplayName("Año")]
        [Required(ErrorMessage = "El año del plan operativo es requerido.")]
        public int AnnioPlanInstitucional { get; set; }


        [DataMember]
        [DisplayName("Versión Anual")]
        public int NumeroVersionAnual { get; set; }

        [DataMember]
        public List<CPlanAnualProductosDTO> ListaProductos { get; set; }
        [DataMember]
        public List<CPlanAnualMetaDTO> ListaMetas { get; set; }
        [DataMember]
        public List<CPlanAnualActividadDTO> ListaActividades { get; set; }
    }
}

