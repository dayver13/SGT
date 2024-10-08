using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SIRH.DTO
{
    [DataContract]
    public class CTipoCalJefeColaboradorDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("Tipo")]
        public string DesTipo { get; set; }

        [DataMember]
        [DisplayName("Detalle")]
        public string DesDetalle { get; set; }
    }
}