using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Actualización 22/08/2022
namespace SIRH.DTO
{
    [DataContract]
    public class CViaticoCorridoDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("[FK_Nombramiento]")]
        public CNombramientoDTO NombramientoDTO { get; set; }
        [DataMember]
        [DisplayName("[FK_EstadoViaticoCorrido]")]
        public CEstadoViaticoCorridoDTO EstadoViaticoCorridoDTO { get; set; }
        [DataMember]
        [DisplayName("[FK_Presupuesto]")]
        public CPresupuestoDTO PresupuestoDTO { get; set; }
        [DataMember]
        [DisplayName("Fecha Inicio")]
        public DateTime FecInicioDTO { get; set; }
        [DataMember]
        [DisplayName("Fecha Fin")]
        public DateTime FecFinDTO { get; set; }
        [DataMember]
        [DisplayName("Monto Viático Corrido")]
        public decimal MontViaticoCorridoDTO { get; set; }
        [DataMember]
        [DisplayName("Monto Actual")]
        public decimal MonActual { get; set; }
        [DataMember]
        [DisplayName("Observacion Viático Corrido")]
        public string ObsViaticoCorridoDTO { get; set; }
        [DataMember]
        [DisplayName("Otras señas")]
        public string DesSenasDTO { get; set; }
        [DataMember]
        [DisplayName("Número telefónico")]
        public string NumTelDomicilioDTO { get; set; }
   
        [DataMember]
        [DisplayName("Distrito")]
        public CDistritoDTO NomDistritoDTO { get; set; }
        [DataMember]
        [DisplayName("Lugar de Pernocte")]
        public string PernocteDTO { get; set; }
        [DataMember]
        [DisplayName("Lugar Hospedaje")]
        public string HospedajeDTO { get; set; }

        //[DataMember]
        //[DisplayName("Hoja Individualizada")]
        //public string HojaIndividualizadaDTO { get; set; }

        [DataMember]
        [DisplayName("N° de registro del Viático Corrido")]
        [RegularExpression("^[0-9]{4}-[0-9]*$", ErrorMessage = "Formato inválido")]
        public string CodigoViaticoCorrido { get; set; }

        [DataMember]
        [DisplayName("Fecha Registro")]
        public DateTime FecRegistroDTO { get; set; }
        [DataMember]
        [DisplayName("Fecha Contrato")]
        public DateTime FecContratoDTO { get; set; }

        [DataMember]
        [DisplayName("Num Documento")]
        public string NumDocumentoDTO { get; set; }

        [DataMember]
        [DisplayName("Fecha Pago")]
        public DateTime FecPagoDTO { get; set; }

        [DataMember]
        [DisplayName("Monto Pago")]
        public Decimal MonPagoDTO { get; set; }

        [DataMember]
        [DisplayName("Utiliza Cabinas del MOPT")]
        public int IndCabinas { get; set; }

        [DataMember]
        [DisplayName("Documentos Adjuntos")]
        public byte[] DocAdjunto { get; set; }
        [DataMember]
        [DisplayName("Lugar Contrato")]
        public CDistritoDTO DistritoContrato { get; set; }

        [DataMember]
        [DisplayName("Lugar Trabajo")]
        public CDistritoDTO DistritoTrabajo { get; set; }

        [DataMember]
        [DisplayName("Registrado por")]
        public CFuncionarioDTO RegistradoPor { get; set; }

        [DataMember]
        [DisplayName("Analizado por")]
        public CFuncionarioDTO AnalizadoPor { get; set; }

        [DataMember]
        [DisplayName("Revisado por")]
        public CFuncionarioDTO RevisadoPor { get; set; }

        [DataMember]
        [DisplayName("Aprobado / Anulado por")]
        public CFuncionarioDTO AprobadoPor { get; set; }

        [DataMember]
        [DisplayName("Observaciones RRHH")]
        public string ObservacionesEstado { get; set; }

        [DataMember]
        public List<CPagoViaticoCorridoDTO> Pagos { get; set; }

        [DataMember]
        public List<CMovimientoViaticoCorridoDTO> Movimientos { get; set; }

        [DataMember]
        public List<CViaticoCorridoReintegroDTO> Reintegros { get; set; }
        
    }
}
