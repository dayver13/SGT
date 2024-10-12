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
    public class CActividadSolicitudTeletrabajoDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("Actividades del Puesto (lo que en realidad hace)")]
        public string DescripcionActividad { get; set; }

        [DataMember]
        [DisplayName("¿Se realiza por medios telemáticos?")]
        public bool Medios { get; set; }

        [DataMember]
        [DisplayName("¿Es medible?")]
        public bool Medible { get; set; }

        [DataMember]
        [DisplayName("¿Se puede realizar con supervisión indirecta, no presencial?")]
        public bool Supervision { get; set; }
    }
}
