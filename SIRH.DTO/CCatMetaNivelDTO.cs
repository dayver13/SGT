using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SIRH.DTO
{
    [DataContract]
    public class CCatMetaNivelDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("Nivel")]
        public string DesNivel { get; set; }

        [DataMember]
        [DisplayName("Detalle")]
        public string DesDetalle { get; set; }
    }
}