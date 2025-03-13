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
    public class SolicitudTeletrabajoDTO : CBaseDTO
    {
        [DataMember]

        [DisplayName("Escolaridad")]
        public int Escolaridad { get; set; }

        [DataMember]
        public int DistritoSecundario { get; set; }

        [DataMember]
        [DisplayName("Dirección exacta de lugar de Teletrabajo Secundario")]
        public string DireccionExactaSecundaria { get; set; }

        [DataMember]
        [DisplayName("Cantidad de personas con las que comparte la conexión de internet en su hogar")]
        public int CantidadPersonasDireccionPrimaria { get; set; }

        [DataMember]
        [DisplayName("Cantidad de personas con las que comparte la conexión de internet en su lugar secundario")]
        public int CantidadPersonasDireccionSecundaria { get; set; }

        [DataMember]
        [DisplayName("Tiempo de laborar en esa dependencia")]
        public string TiempoLaborarDependencia { get; set; }

        [DataMember]
        [DisplayName("Tiempo de laborar para el MOPT")]
        public string TiempoLaborarMOPT { get; set; }

        [DataMember]
        [DisplayName("¿El puesto es teletrabajable?")]
        public bool Teletrabajable { get; set; }

        [DataMember]
        [DisplayName("Días que se solicita teletrabajar acordados con la jefatura según las funciones que realiza y garantizando el servicio.")]
        public int CantidadDiasTeletrabajo { get; set; }

        [DataMember]
        [DisplayName("Días que se solicita teletrabajar acordados con la jefatura")]
        public string DetalleDiasTeletrabajo { get; set; }

        [DataMember]
        [DisplayName("Horario Laboral establecido para teletrabajar acordado con la jefatura garantizando la disponibilidad y el servicio a los clientes internos o externos")]
        public string Horario { get; set; }

        [DataMember]
        [DisplayName("Enumere y describa las funciones que realiza el funcionario, el tiempo que dura realizándolas e indique cuales son teletrabajables")]
        public string Funciones { get; set; }

        [DataMember]
        [DisplayName("Tiempo realizando dichas funciones dentro de la dependencia (Indicar el tiempo en días, meses o años)")]
        public int TiempoFunciones { get; set; }

        [DataMember]
        [DisplayName("Indique las razones objetivas sobre la pertinencia de la modalidad de teletrabajo para este puesto")]
        public string Razones { get; set; }

        [DataMember]
        public bool DeclaracionJurada { get; set; }

        [DataMember]
        [DisplayName("Seleccione los sistemas que usted requiere utilizar para realizar su trabajo en condiciones normales")]
        public string Sistemas { get; set; }

        [DataMember]
        [DisplayName("¿Aprobado por la jefatura inmediata?")]
        public bool AprobadoJefaturaInmediata { get; set; }

        [DataMember]
        [DisplayName("¿Aprobado por la jefatura superior?")]
        public bool AprobadoJefaturaSuperior { get; set; }

        [DataMember]
        public CFuncionarioDTO FuncionarioTeletrabajo { get; set; }

        [DataMember]
        [DisplayName("Comentario de la jefatura")]
        public string ComentarioAval { get; set; }
    }
}
