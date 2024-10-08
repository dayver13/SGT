using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SIRH.DTO
{
    public class CEstadoActividadDTO : CBaseDTO
    {
        [DataMember] 
        [DisplayName( "Estado Actividad")]        
        public string DesEstadoActividad { get; set; }
    }
}
