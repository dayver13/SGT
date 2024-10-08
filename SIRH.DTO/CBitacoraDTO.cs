using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SIRH.DTO
{
    [DataContract]
    public class CBitacoraDTO : CBaseDTO
    {
        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public string TipoMovimiento { get; set; }

        [DataMember]
        public string NumMovimiento { get; set; }
        [DataMember]
        public string NombreCampo { get; set; }

        public string ValorInicial { get; set; }

        public string ValorFinal { get; set; }

        [DataMember]
        public DateTime FechaMovimiento { get; set; }

        [DataMember]
        public TimeSpan HoraMovimiento { get; set; }

        [DataMember]
        public string TipoTransaccion { get; set; }

        [DataMember]
        public string Estructura { get; set; }
    }
}
