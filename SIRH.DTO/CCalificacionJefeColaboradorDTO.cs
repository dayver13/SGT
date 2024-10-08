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
    public class CCalificacionJefeColaboradorDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("FK_Periodo")]
        public CPeriodoCalificacionDTO Periodo { get; set; }

        [DataMember]
        [DisplayName("FK_Jefatura")]
        public CFuncionarioDTO Jefatura { get; set; }

        [DataMember]
        [DisplayName("FK_Colaborador")]
        public CFuncionarioDTO Colaborador { get; set; }

        [DataMember]
        [DisplayName("FK_Tipo")]
        public CTipoCalJefeColaboradorDTO Tipo { get; set; }
        
        [DataMember]
        [DisplayName("Estado")]
        public int IndEstado { get; set; }
            
        [DataMember]
        [DisplayName("Nota")]
        public decimal PorNota { get; set; }

        [DataMember]
        [DisplayName("DetalleNota")]
        public string DesNota { get; set; }

        [DataMember]
        [DisplayName("Observaciones")]
        public string DesObservaciones { get; set; }

        [DataMember]
        [DisplayName("BASICO")]
        public bool bolBasico { get; set; }

        [DataMember]
        [DisplayName("INTERMEDIO")]
        public bool bolIntermedio { get; set; }

        [DataMember]
        [DisplayName("AVANZADO")]
        public bool bolAvanzado { get; set; }

        [DataMember]
        [DisplayName("DESTACADO")]
        public bool bolDestacado { get; set; }

        [DataMember]
        [DisplayName("Valor Calificacion")]
        public string seleccion { get; set; }
    }
}
