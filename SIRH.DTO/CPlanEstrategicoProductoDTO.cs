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
    public class CPlanEstrategicoProductoDTO : CBaseDTO
    {
        //Referencias Padres
        [DataMember]
        public CPlanEstrategicoLineaDTO Linea { get; set; } // Se jala el error de seccion

        //Propio del Producto.
        [DataMember]
        [DisplayName("Prioridad")]
        [Required(ErrorMessage = "La prioridad del producto es requerida.")]
        public int PrioridadProducto { get; set; }
        [DataMember]
        [DisplayName("SituacionActual")]
        //[Required(ErrorMessage = "La situación actual del producto es requerida.")]
        public string SituacionActual { get; set; }
        [DataMember]
        [DisplayName("ResultadoEsperado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El resultado esperado del producto es requerido.")]
        public string ResultadoEsperado { get; set; }
        [DataMember]
        [DisplayName("Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción del producto es requerida.")]
        public string Descripcion { get; set; }
        [DataMember] 
        [DisplayName("Estado")]
        public int EstadoProducto { get; set; }
        [DataMember]
        public List<CPlanEstrategicoAccionDTO> ListaAcciones { get; set; }

    }
}

