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
    public class CPlanEstrategicoLineaDTO : CBaseDTO
    {
        //Referencias Padres
        [DataMember]
        public CPlanEstrategicoEjeDTO Eje { get; set; }

        [DataMember]
        [DisplayName("Línea")]
        [Required(ErrorMessage = "El Número de la línea es requerido.")]
        public int NumeroLinea { get; set; }

        [DataMember]
        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción de la línea es requerida.")]
        public string Descripcion { get; set; }

        [DataMember] 
        [DisplayName("Estado")]
        //[Required(ErrorMessage = "El estado de la línea es requerido")]
        public int EstadoLinea { get; set; }

        [DataMember]
        public List<CPlanEstrategicoProductoDTO> ListaProductos { get; set; }

    }
}

