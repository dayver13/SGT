using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using SIRH.DTO;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIRH.Web.ViewModels
{
    public class FormularioDesarraigoVM
    {
        public CDesarraigoDTO Desarraigo { get; set; }
        public CFuncionarioDTO Funcionario { get; set; }
        public CNombramientoDTO Nombramiento { get; set; }
        public CPuestoDTO Puesto { get; set; }
        public CDetallePuestoDTO DetallePuesto { get; set; }
        public CUbicacionPuestoDTO UbicacionContrato { get; set; }
        public CUbicacionPuestoDTO UbicacionTrabajo { get; set; }
        public CDireccionDTO Direccion { get; set; }

        public CFuncionarioDTO Jefe { get; set; }
        public CDetalleContratacionDTO Contrato { get; set; }
        public CErrorDTO Error { get; set; }
        public List<CFacturaDesarraigoDTO> Facturas { get; set; }
        public List<CContratoArrendamientoDTO> ContratosArrendamiento { get; set; }

        [DisplayName("N° de Carta")]
        public string NumCartaPresentacion { get; set; }
        //[DisplayName("40% Salario Base")]
        //public decimal CaculoSalario { get; set; }

        [DisplayName("Estado del Desarraigo")]
        public string EstadoSeleccion { get; set; }
        public SelectList Estado { get; set; }

        public FormularioFacturaDesarraigoVM GetModelFacturas { get { return new FormularioFacturaDesarraigoVM { CodigoFactura = null }; } }
        public FormularioContratoArrendamientoVM GetModelContratos { get { return new FormularioContratoArrendamientoVM(); } }

        public decimal MontoDesarraigo { get; set; }
        public decimal MontoSalario { get; set; }

        [DisplayName("Códigos Presupuestarios")]
        public SelectList CodigosPresupuestoList { get; set; }
        [DisplayName("Códigos Presupuestarios")]
        public string PresupuestoSelected { get; set; }

        [DisplayName("Distrito")]
        public string DistritoSeleccion { get; set; }
        [DisplayName("Cantón")]
        public string CantonSeleccion { get; set; }
        [DisplayName("Provincias")]
        public string ProvinciaSeleccion { get; set; }

        public SelectList Distritos { get; set; }
        public SelectList Cantones { get; set; }
        public SelectList Provincias { get; set; }

        public HttpPostedFileBase File { get; set; }
        [RegularExpression(@"^.*\.(pdf)$", ErrorMessage = "Extensión de imagen no válida, solo se admite pdf.")]
        public string Imagen { get; set; }

        public bool validarInfoFuncionario { get; set; }
        public bool validarLugarTrabajo { get; set; }
        public bool validarLugarContrato { get; set; }

        public bool permisoRegistrar { get; set; }
        public bool permisoAprobar { get; set; }
        public bool permisoRegistrarMovimiento { get; set; }
        public bool permisoAprobarMovimiento { get; set; }


        public byte[] codigoQR { get; set; }
    }
}