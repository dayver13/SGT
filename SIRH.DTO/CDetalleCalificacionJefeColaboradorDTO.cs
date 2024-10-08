using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SIRH.DTO
{
    [DataContract]
    public class CDetalleCalificacionJefeColaboradorDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("FK_CalificacionNombramiento")]
        public CCalificacionNombramientoDTO Calificacion { get; set; }

        [DataMember]
        [DisplayName("FK_Tipo")]
        public CTipoCalJefeColaboradorDTO Tipo { get; set; }
        
        [DataMember]
        [DisplayName("Nota")]
        public decimal PorNota { get; set; }

        [DataMember]
        [DisplayName("Detalle Nota")]
        public string DesNota { get; set; }
    }
}
