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
    public class CAprobacionVacacionesDTO : CBaseDTO
    {

        [DataMember]
        public CFuncionarioDTO Funcionario { get; set; }


        [DataMember]
        [DisplayName("Id Aprobar")]
        public string IdAprobar { get; set; }



    }
}
