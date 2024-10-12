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
    public class CPlanEstrategicoEjeDTO : CBaseDTO
    {
        //Referencias Padres
        [DataMember]
        public CPlanEstrategicoDTO PlanEstrategico { get; set; }
        [DataMember]
        public CDepartamentoDTO Departamento { get; set; }
        [DataMember]
        //[DisplayName("Sección")]
        //[Required(ErrorMessage = "La sección es requerida")] Se necesita el required aca?
        public CSeccionDTO Seccion { get; set; }


        //Propio del Eje.
        [DataMember]
        [DisplayName("Eje")]
        [Required(ErrorMessage = "El Número de Eje es requerido")]
        public int NumeroEje { get; set; }
        [DataMember]
        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción del Eje es requerida")]
        public string Descripcion { get; set; }
        [DataMember]
        [DisplayName("Estado")]
        [Required(ErrorMessage = "El estado del Eje es requerido")]
        public int EstadoEje { get; set; }

        //Listas del Eje
        [DataMember]
        public List<CPlanEstrategicoLineaDTO> ListaLinea { get; set; }//ejemplo

    }
}

