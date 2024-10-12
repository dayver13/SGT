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
    public class CPlanEstrategicoAccionDTO : CBaseDTO
    {
        //Referencias Padres
        [DataMember]
        public CPlanEstrategicoProductoDTO Producto { get; set; }

        //Propio de la Acción.
        [DataMember]
        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción de la acción es requerida.")]
        public string Descripcion { get; set; }

        //Descripción de la Acción para aignarla como Meta en el Plan Anual (POI)
        [DataMember]
        [DisplayName("Descripción POI")]     
        public string DescripcionPOI { get; set; }

        [DataMember]
        [DisplayName("Indicadores")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Los indicadores de la acción son requeridos.")]
        public string Indicadores { get; set; }
        [DataMember]
        [DisplayName("AnioInicio")]
        [Required(ErrorMessage = "El año de inicio de la acción es requerido.")]
        public int AnioInicioEsperado { get; set; }
        [DataMember]
        [DisplayName("AnioFinalEsperado")]
        [Required(ErrorMessage = "El año final de la acción es requerido.")]
        public int AnioFinalEsperado { get; set; }
        [DataMember]
        [DisplayName("Anio Final Oficial")]
        //[Required(ErrorMessage = "El año final oficial de la acción es requerido")]
        public int AnioFinalOficial { get; set; }
        [DataMember] 
        [DisplayName("Estado")]
        public int EstadoAccionEstrategica { get; set; }

    }
}

