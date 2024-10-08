using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SIRH.DTO
{
    [DataContract]
    public class CVacacionesJefaturaDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("Funcionario")]
        public CFuncionarioDTO Funcionario { get; set; }

        [DataMember]
        [DisplayName("Jefe Inmediato")]
        public CFuncionarioDTO JefeInmediato { get; set; }

        [DataMember]
        [DisplayName("Jefe Superior")]
        public CFuncionarioDTO JefeSuperior { get; set; }
    }
}
