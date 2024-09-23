using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIRH.DTO
{
    [DataContract]
    public class CRequerimientoEspecificoCargoDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("Requisitos específicos")]
        public string RequisitosEspecificos { get; set; }

        [DataMember]
        [DisplayName("Conocimientos necesarios para el cargo")]
        public string Conocimientos { get; set; }

        [DataMember]
        [DisplayName("Conocimientos deseables o ideales para el cargo")]
        public string ConocimientosDeseables { get; set; }

        [DataMember]
        [DisplayName("Habilidades")]
        public string Habilidades { get; set; }

        [DataMember]
        public CCargoDTO Cargo { get; set; }

    }
}
