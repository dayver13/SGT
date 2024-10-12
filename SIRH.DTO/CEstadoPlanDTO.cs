using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SIRH.DTO
{
    public class CEstadoPlanDTO : CBaseDTO
    {
        [DataMember] 
        [DisplayName( "Estado del Plan")]        
        public string DesEstadoPlan { get; set; }
    }
}
