using SIRH.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIRH.Web.ViewModels
{
    public class FormularioRegistroVacacionesVM
    {
        public CErrorDTO Error { get; set; }
        public CRegistroVacacionesDTO RegistroVacaciones { get; set; }
        public CReintegroVacacionesDTO ReintegroVacaciones { get; set; }
        public CPeriodoVacacionesDTO PeriodoVacaciones { get; set; }
        public CFuncionarioDTO Funcionario { get; set; }
        public CPuestoDTO Puesto { get; set; }
        public CNombramientoDTO Nombramiento { get; set; }
        public CDetallePuestoDTO DetallePuesto { get; set; }
        public CAprobacionVacacionesDTO AprobacionVacaciones { get; set; }
        //public SelectList PeriodosActivos { get; set; }
        //public string PeriodoSeleccion { get; set; }

        public CVacacionesJefaturaDTO Jefatura { get; set; }

        public SelectList tipoDocumento { get; set; }
        public string tipoDocumentoSeleccion { get; set; }
        public string UltimoPeriodo { get; set; }
        public List<CRegistroVacacionesDTO> ListaRegistroVacacionesAprobadas { get; set; }
        public List<CRegistroVacacionesDTO> ListaRegistroVacacionesRechazadas { get; set; }
        public List<CRegistroVacacionesDTO> ListaRegistroVacacionesPendientes { get; set; }
        public List<CRegistroVacacionesDTO> ListaRegistroVacacionesAnuladas { get; set; }
        public List<string> ListaPeriodos { get; set; }
        public List<CPeriodoVacacionesDTO> PeriodosActivos { get; set; }
        public String estadoPeriodo = "Valido";
        public List<CRegistroVacacionesDTO> ListaVacacionesPendientesPorSeccion { get; set; }
        public List<CRegistroVacacionesDTO> ListaVacacionesPendientesPorDivision { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegroVacaciones { get; set; }
        public string MedioDia { get; set; }
        public String estadoRegistroVacaciones { get; set; }
        public String permiso { get; set; }
        public String seccion { get; set; }
        public String division { get; set; }
        public SelectList Divisiones { get; set; }
        public SelectList Secciones { get; set; }
        public SelectList FuncionariosAsociados { get; set; }

        public string funcionarioSeleccionado { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegroVacacionesAprobadas { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegroVacacionesRechazadas { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegroVacacionesPendientes { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegroVacacionesAnuladas { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegrosPendientesPorSeccion { get; set; }
        public List<CReintegroVacacionesDTO> ListaReintegrosPendientesPorDivision { get; set; }
        public String estadoReintegroVacaciones { get; set; }
    }
}