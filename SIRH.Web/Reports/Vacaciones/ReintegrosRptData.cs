using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIRH.Web.ViewModels;

namespace SIRH.Web.Reports.Vacaciones
{
    public class ReintegrosRptData
    {
        public string CedulaFuncionario { get; set; }
        public string NombreFuncionario { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Dias { get; set; }
        public string NumeroDocumento { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public string Autor { get; set; }
        public string Filtros { get; set; }
        internal static ReintegrosRptData GenerarDatosReporte(FormularioRegistroVacacionesVM dato, string filtros)
        {
            return new ReintegrosRptData 
            {
                CedulaFuncionario = dato.Funcionario.Cedula,
                NombreFuncionario = dato.Funcionario.Nombre + " " + dato.Funcionario.PrimerApellido + " " + dato.Funcionario.SegundoApellido,
                FechaInicio = dato.ReintegroVacaciones.FechaRige.ToShortDateString(),
                FechaFin = dato.ReintegroVacaciones.FechaVence.ToShortDateString(),
                Dias = Convert.ToString(dato.ReintegroVacaciones.CantidadDias),
                NumeroDocumento = dato.ReintegroVacaciones.SolReintegro,
                Estado = Convert.ToString(dato.ReintegroVacaciones.Estado),
                Observacion = dato.ReintegroVacaciones.Observaciones,
                Autor = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                Filtros = filtros
            };
        }
    }
}