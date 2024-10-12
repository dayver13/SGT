using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIRH.Web.ViewModels;

namespace SIRH.Web.Reports.Vacaciones
{
    public class VacacionesRptData
    {
        public string CedulaFuncionario { get; set; }
        public string NombreFuncionario { get; set; }
        public string PeriodoVacaciones { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Dias { get; set; }
        public string NumeroDocumento { get; set; }
        public string Estado { get; set; }
        public string Autor { get; set; }
        public string Filtros { get; set; }
        internal static VacacionesRptData GenerarDatosReporte(FormularioRegistroVacacionesVM dato, string filtros)
        {
            return new VacacionesRptData
            {
                CedulaFuncionario = dato.Funcionario.Cedula,
                NombreFuncionario = dato.Funcionario.Nombre + " " + dato.Funcionario.PrimerApellido + " " + dato.Funcionario.SegundoApellido,
                PeriodoVacaciones = dato.RegistroVacaciones.Periodo.Periodo,
                FechaInicio = dato.RegistroVacaciones.FechaRige.ToShortDateString(),
                FechaFin = dato.RegistroVacaciones.FechaVence.ToShortDateString(),
                Dias = Convert.ToString(dato.RegistroVacaciones.Dias),
                NumeroDocumento = dato.RegistroVacaciones.NumeroTransaccion,
                Estado = Convert.ToString(dato.RegistroVacaciones.Estado),
                Autor = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                Filtros = filtros
            };
        }
        internal static VacacionesRptData GenerarDatosReporteLista(BusquedaVacacionesReportesVM dato, string filtros)
        {
            return new VacacionesRptData
            {
                CedulaFuncionario = dato.Funcionario.Cedula,
                NombreFuncionario = dato.Funcionario.Nombre + " " + dato.Funcionario.PrimerApellido + " " + dato.Funcionario.SegundoApellido,
                PeriodoVacaciones = dato.RegistroVacaciones.FirstOrDefault().Periodo.Periodo,
                FechaInicio = dato.RegistroVacaciones.FirstOrDefault().FechaRige.ToShortDateString(),
                FechaFin = dato.RegistroVacaciones.FirstOrDefault().FechaVence.ToShortDateString(),
                Dias = Convert.ToString(dato.RegistroVacaciones.FirstOrDefault().Dias),
                NumeroDocumento = dato.RegistroVacaciones.FirstOrDefault().NumeroTransaccion,
                Estado = Convert.ToString(dato.RegistroVacaciones.FirstOrDefault().Estado),
                Autor = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                Filtros = filtros
            };
        }
    }
}