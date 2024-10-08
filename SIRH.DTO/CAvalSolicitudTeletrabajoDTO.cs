using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SIRH.DTO
{
    [DataContract]
    public class CAvalSolicitudTeletrabajoDTO : CBaseDTO
    {
        [DataMember]
        [DisplayName("De acuerdo con el puesto que ejecuta el funcionario ¿usted está de acuerdo con la descripción de funciones realizada por el funcionario?")]
        public bool AvalFunciones { get; set; }

        [DataMember]
        [DisplayName("Por favor, indique sus motivos para la respuesta anterior")]
        public string MotivoNoAvalFunciones { get; set; }

        [DataMember]
        [DisplayName("¿Las actividades que se desarrolla en el puesto del funcionario tiene objetivos claros y metas específicas que permiten la planificación, seguimiento y evaluación de una forma objetiva?")]
        public int AvalObjetivosMetas { get; set; }

        [DataMember]
        [DisplayName("¿La supervisión sobre las actividades es indirecta y por resultados?")]
        public int AvalSupervision { get; set; }

        [DataMember]
        [DisplayName("¿Las actividades que se desarrolla se pueden realizar fuera de la oficina sin afectar el normal desempeño del proceso, mediante el uso de las tecnologías de información y comunicación que permiten el contacto para atención de los compañeros y clientes?")]
        public int AvalFueraOficina { get; set; }

        [DataMember]
        [DisplayName("¿Los insumos y salidas de información del puesto de trabajo son principalmente gestionados por sistemas informáticos (software), sitios colaborativos, archivos digitales?")]
        public int AvalSistemas { get; set; }

        [DataMember]
        [DisplayName("¿El (la) funcionario (a) tiene conocimiento para el uso de las herramientas de comunicación institucionales: email, chat, video conferencias, llamadas telefónicas, Sistema de correspondencia institucional ¿etc?")]
        public int AvalHerramientasComunicacion { get; set; }

        [DataMember]
        [DisplayName("¿Tiene habilidades en temas de Organización del tiempo y planificación?")]
        public int AvalHabilidadesOrganizacion { get; set; }

        [DataMember]
        [DisplayName("¿El (la) funcionario (a) tiene habilidades para trabajar de forma autónoma y tomar decisiones?")]
        public int AvalTrabajoAutonomo { get; set; }

        [DataMember]
        [DisplayName("¿Tiene la capacidad para adaptarse a nuevas situaciones y flexibilidad?")]
        public int AvalFlexibilidad { get; set; }

        [DataMember]
        [DisplayName("¿Tiene actitudes de responsabilidad orientación al logro y disciplina?")]
        public int AvalLogro { get; set; }

        [DataMember]
        [DisplayName("¿Tiene actitudes de iniciativa, proactividad y automotivación?")]
        public int AvalIniciativa { get; set; }

        [DataMember]
        [DisplayName("¿Tiene actitudes de seguridad en sí mismo, autocontrol y compromiso con las tareas?")]
        public int AvalSeguridad { get; set; }

        [DataMember]
        [DisplayName("¿Tiene disposición de que su trabajo sea evaluado?")]
        public int AvalDisposicion { get; set; }

        [DataMember]
        [DisplayName("¿En la gestión que se realiza la interacción o contacto presencial con compañeros y clientes pueden preverse o calendarizarse previamente?")]
        public bool AvalInteraccion { get; set; }

        [DataMember]
        [DisplayName("¿De acuerdo a lo anterior, usted considera que el puesto es teletrabajable?")]
        public bool AvalTeletrabajable { get; set; }

        [DataMember]
        [DisplayName("Justifique")]
        public string NoTeletrabajable { get; set; }

        [DataMember]
        [DisplayName("Se considera un puesto que tienen dentro de sus actividades la atención presencial de público, tareas donde se utilizan materiales, documentos, equipos y herramientas que solo se encuentran en la Institución de forma física. (Si selecciona esta opción, puede dar un máximo de 1 día de teletrabajo).")]
        public bool AtencionPublico { get; set; }

        [DataMember]
        [DisplayName("Se considera un puesto que tienen definidas la atención de personas en días específicos dentro de la semana y la otra parte de la jornada deben atender funciones relacionadas con la elaboración análisis, investigaciones e informes, por la índole de sus funciones, resulta más efectivo realizarlo en la Institución. (Si selecciona esta opción, puede dar un máximo de 2 días de teletrabajo).")]
        public bool AtencionDiasEspecificos { get; set; }

        [DataMember]
        [DisplayName("Se considera un puesto donde las actividades a realizar son de análisis, investigación, ejecución de proyectos, redacción de informes, propuestas, elaboración de documentos y que, por la índole de sus funciones, resulta más efectivo realizarlo fuera de la Institución. (Si selecciona esta opción, puede dar un máximo de 3 días de teletrabajo).")]
        public bool RealizaInvestigacion { get; set; }

        [DataMember]
        [DisplayName("Las características del puesto, no están contempladas en las descripciones anteriores. (Si selecciona esta opción, dar la opción de ampliar y justificar su respuesta).")]
        public bool CaracteristicasPuesto { get; set; }

        [DataMember]
        [DisplayName("De acuerdo a las características y perfil del funcionario, conteste las siguientes consultas:")]
        public string DescripcionCaracteristicasPuesto { get; set; }

        [DataMember]
        [DisplayName("¿El (la) funcionario (a) cumple con excelente calidad de todos los objetivos y tareas asignadas?")]
        public int AvalCumplimiento { get; set; }

        [DataMember]
        [DisplayName("¿El (la) funcionario (a) tiene Accesibilidad y buena disposición para la comunicación cuando se requiere?")]
        public int AvalAccesibilidad { get; set; }

        [DataMember]
        [DisplayName("¿El (la) funcionario (a) en algún cumplimiento ha contado con la justificación debida?")]
        public int AvalJustificacion { get; set; }

        [DataMember]
        [DisplayName("¿De acuerdo a lo anterior, usted considera que el funcionario (a), tienen la cultura organizacional los conocimientos y las habilidades para realizar el trabajo mediante formas virtuales?")]
        public int AvalTeletrabajo { get; set; }

        [DataMember]
        [DisplayName("Justifique")]
        public string JustificacionNoAvalTeletrabajo { get; set; }
    }
}
