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
    public class CPlanEstrategicoDTO : CBaseDTO
    {
        [DataMember]
        public CEstadoPlanDTO EstadoPlan { get; set; }
        [DataMember]
        public CDireccionGeneralDTO DireccionGeneral { get; set; }

        [DataMember]
        [DisplayName("Fecha de Inicio")]
        [Required(ErrorMessage = "Fecha de Inicio del Plan Estratégico requerida.")]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        [DisplayName("Fecha Final")]
        [Required(ErrorMessage = "Fecha Final del Plan Estratégico requerida.")]
        public DateTime FechaFinal { get; set; }


        [DataMember]
        [DisplayName("Nombre del Plan")]
        //
        //[RegularExpression(@"^[^\s]*$", ErrorMessage = "Error nombre plan.")]
        //
        [Required(AllowEmptyStrings = false,ErrorMessage = "Nombre del Plan Estratégico requerido.")]
        public string Nombre { get; set; }



        [DataMember]
        [DisplayName("Versión")]
        public int NumeroVersion { get; set; }
        [DataMember]
        public List<CPlanEstrategicoEjeDTO> ListaEjes { get; set; }
        [DataMember]
        public List<CPlanEstrategicoLineaDTO> ListaLineas { get; set; }
        [DataMember]
        public List<CPlanEstrategicoProductoDTO> ListaProductos { get; set; }
        [DataMember]
        public List<CPlanEstrategicoAccionDTO> ListaAcciones { get; set; }

    }
}

