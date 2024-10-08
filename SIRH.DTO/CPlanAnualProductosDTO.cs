using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SIRH.DTO
{
    [DataContract]
    public class CPlanAnualProductosDTO : CBaseDTO
    {
        [DisplayName("PK_ProductoPlan")]
        public int PK_ProductoPlan { get; set; }

        [DataMember]
        [DisplayName("FK_Plan")]
        public CPlanAnualDTO Plan { get; set; }

        [DataMember]
        [DisplayName("FK_Producto")]
        public CPlanEstrategicoProductoDTO Producto { get; set; }

        [DataMember]
        [DisplayName("IndEstado")]
        public int IndEstado { get; set; }

        [DataMember]
        public List<CPlanAnualMetaDTO> ListaMetas { get; set; }
    }
}

