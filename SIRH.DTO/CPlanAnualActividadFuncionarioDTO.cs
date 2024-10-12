using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SIRH.DTO
{
    [DataContract]
    public class CPlanAnualActividadFuncionarioDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("FK_Actividad")]
        public CPlanAnualActividadDTO Actividad { get; set; }

        [DataMember]
        [DisplayName("FK_Funcionario")]
        public CFuncionarioDTO Funcionario { get; set; }

        [DataMember]
        [DisplayName("IndActivo")]
        public bool IndActivo { get; set; }
    }
}

