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
    public class CEstadoCargoDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("Observaciones")]
        public string ObservacionesEstado { get; set; }

        [DataMember]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [DataMember]
        public int IndicadorEstado { get; set; }

        [DataMember]
        [DisplayName("Fecha de actualización")]
        public DateTime FechaActualizacion { get; set; }

        [DataMember]
        [DisplayName("Usuario de actualización")]
        public string UsuarioActualizacion { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string NombreCompletoUsuario { get; set; }

        [DataMember]
        public string PerfilUsuario { get; set; }

        [DataMember]
        public CCargoDTO CargoAsociado { get; set; }
    }
}
