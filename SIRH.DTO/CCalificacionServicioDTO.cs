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
    public class CCalificacionServicioDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("FK_Periodo")]
        public CPeriodoCalificacionDTO Periodo { get; set; }

        [DataMember]
        [DisplayName("FK_Direccion")]
        public CDireccionGeneralDTO Direccion { get; set; }

        [DataMember]
        [DisplayName("FK_Tipo")]
        public CTipoCategoriaServicioDTO TipoCategoria { get; set; }
        
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
        [DisplayName("NECESITA DESARROLLAR")]
        public bool bolDesarrollar { get; set; }

        [DataMember]
        [DisplayName("NECESITA MEJORAR")]
        public bool bolMejorar { get; set; }

        [DataMember]
        [DisplayName("CUMPLE CON LAS ESPECTATIVAS")]
        public bool bolCumple { get; set; }

        [DataMember]
        [DisplayName("Valor Calificacion")]
        public string seleccion { get; set; }
    }
}
