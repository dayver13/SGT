using SIRH.Web.ViewModels;
using System;

namespace SIRH.Web.Reports.Desarraigos
{
    public class DesarraigoRptData {
        public string Funcionario { get; set; }
        public string CodigoDesarraigo { get; set; }
        public string MontoDesarraigo { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVencimiento { get; set; }
        public string Estado { get; set; }
        public string MotivoSuspension { get; set; }
        public string Observaciones { get; set; }
        public string ObservacionesEstado { get; set; }
        public string LugarTrabajo { get; set; }
        public string LugarContrato { get; set; }
        public string LugarPernocte{ get; set; }
        public string Proyecto { get; set; }
        public string Jefatura { get; set; }
        public string RegistradoPor { get; set; }
        public string AnalizadoPor { get; set; }
        public string RevisadoPor { get; set; }
        public string AprobadoPor { get; set; }
        public string OcupacionReal { get; set; }
        public string Seccion { get; set; }
        public string Autor { get; set; }
        public string Filtros { get; set; }
        public byte[] barcodeQR { get; set; }

        internal static DesarraigoRptData GenerarDatosReporte(FormularioDesarraigoVM dato,string filtros)
        {
            var detalleSuspension = "";
            if (dato.Desarraigo.DetalleEliminacion != null)
                foreach (var detalle in dato.Desarraigo.DetalleEliminacion)
                {
                    detalleSuspension = detalle.FecEliminacion.ToShortDateString() + " - " + detalle.ObsEliminacion.TrimEnd();
                }

            return new DesarraigoRptData
            {
                Funcionario = dato.Funcionario.Cedula + " - " + dato.Funcionario.Nombre.TrimEnd() + " " +
                                dato.Funcionario.PrimerApellido.TrimEnd() + " " + dato.Funcionario.SegundoApellido.TrimEnd(),
                CodigoDesarraigo = dato.Desarraigo.CodigoDesarraigo,
                MontoDesarraigo = dato.Desarraigo.MontoDesarraigo.ToString("₡ #,#.00#;(#,#.00#)"),
                FechaEmision = dato.Desarraigo.FechaInicio.ToShortDateString(),
                FechaVencimiento = dato.Desarraigo.FechaFin.ToShortDateString(),
                Estado = dato.Desarraigo.EstadoDesarraigo.NomEstadoDesarraigo,
                MotivoSuspension= detalleSuspension,
                Observaciones = dato.Desarraigo.ObservacionesDesarraigo != null ? dato.Desarraigo.ObservacionesDesarraigo : "No hay observaciones",
                ObservacionesEstado = dato.Desarraigo.ObservacionesEstado != null ? dato.Desarraigo.ObservacionesEstado : "",
                LugarTrabajo = dato.Desarraigo.DistritoTrabajo.Canton.Provincia.NomProvincia + ", " +
                               dato.Desarraigo.DistritoTrabajo.Canton.NomCanton + ", " +
                               dato.Desarraigo.DistritoTrabajo.NomDistrito,
                LugarContrato = dato.Desarraigo.DistritoContrato.Canton.Provincia.NomProvincia + ", " +
                               dato.Desarraigo.DistritoContrato.Canton.NomCanton + ", " +
                               dato.Desarraigo.DistritoContrato.NomDistrito,
                LugarPernocte = dato.Desarraigo.DistritoPernocte.Canton.Provincia.NomProvincia + ", " +
                               dato.Desarraigo.DistritoPernocte.Canton.NomCanton + ", " +
                               dato.Desarraigo.DistritoPernocte.NomDistrito + ", " +
                               dato.Desarraigo.LugarPernocte,
                Jefatura = dato.Desarraigo.JefeInmediato.Cedula + " - " + dato.Desarraigo.JefeInmediato.Nombre.TrimEnd() + " " +
                                dato.Desarraigo.JefeInmediato.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.JefeInmediato.SegundoApellido.TrimEnd(),
                RegistradoPor = dato.Desarraigo.RegistradoPor.IdEntidad > 0 ? 
                                dato.Desarraigo.RegistradoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.RegistradoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.RegistradoPor.SegundoApellido.TrimEnd() 
                                : "",
                AnalizadoPor = dato.Desarraigo.AnalizadoPor.IdEntidad > 0 ?
                                dato.Desarraigo.AnalizadoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.AnalizadoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.AnalizadoPor.SegundoApellido.TrimEnd()
                               : "",
                RevisadoPor = dato.Desarraigo.RevisadoPor.IdEntidad > 0 ? 
                                dato.Desarraigo.RevisadoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.RevisadoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.RevisadoPor.SegundoApellido.TrimEnd()
                                : "",
                AprobadoPor = dato.Desarraigo.AprobadoPor.IdEntidad > 0 ?
                                dato.Desarraigo.AprobadoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.AprobadoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.AprobadoPor.SegundoApellido.TrimEnd()
                                : "",
                Proyecto = dato.Desarraigo.NomProyecto,
                OcupacionReal = dato.DetallePuesto.OcupacionReal.DesOcupacionReal,
                Seccion = dato.Desarraigo.Seccion != null ?
                                dato.Desarraigo.Seccion.NomSeccion.TrimEnd() :
                                dato.Desarraigo.Departamento != null ? dato.Desarraigo.Departamento.NomDepartamento.TrimEnd() : "",
                barcodeQR = dato.Desarraigo.EstadoDesarraigo.IdEntidad != 6 ? dato.codigoQR : null,
                Autor = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                Filtros = filtros
            };
        }

        internal static DesarraigoRptData GenerarReporteContratos(FormularioDesarraigoVM dato, string filtros)
        {
            var detalleSuspension = "";
            if (dato.Desarraigo.DetalleEliminacion != null)
                foreach (var detalle in dato.Desarraigo.DetalleEliminacion)
                {
                    detalleSuspension = detalle.FecEliminacion.ToShortDateString() + " - " + detalle.ObsEliminacion.TrimEnd();
                }

            return new DesarraigoRptData
            {
                Funcionario = dato.Funcionario.Cedula + " - " +
                                dato.Funcionario.Nombre.TrimEnd() + " " +
                                dato.Funcionario.PrimerApellido.TrimEnd() + " " +
                                dato.Funcionario.SegundoApellido.TrimEnd(),
                //CodigoDesarraigo = dato.Desarraigo.CodigoDesarraigo,
                MontoDesarraigo = dato.Desarraigo.MontoDesarraigo.ToString().Replace(".", ","),//.ToString("₡ #,#.00#;(#,#.00#)"),
                FechaEmision = dato.Desarraigo.FechaInicio.ToShortDateString(),
                FechaVencimiento = dato.Desarraigo.FechaFin.ToShortDateString(),
                Estado = dato.Desarraigo.EstadoDesarraigo.NomEstadoDesarraigo,
                LugarTrabajo = dato.Desarraigo.DistritoTrabajo.Canton.Provincia.NomProvincia + ", " +
                               dato.Desarraigo.DistritoTrabajo.Canton.NomCanton + ", " +
                               dato.Desarraigo.DistritoTrabajo.NomDistrito,
                LugarContrato = dato.Desarraigo.DistritoContrato.Canton.Provincia.NomProvincia + ", " +
                               dato.Desarraigo.DistritoContrato.Canton.NomCanton + ", " +
                               dato.Desarraigo.DistritoContrato.NomDistrito,
                //LugarPernocte = dato.Desarraigo.DistritoPernocte.Canton.Provincia.NomProvincia + ", " +
                //               dato.Desarraigo.DistritoPernocte.Canton.NomCanton + ", " +
                //               dato.Desarraigo.DistritoPernocte.NomDistrito + ", " +
                //               dato.Desarraigo.LugarPernocte,
                //Jefatura = dato.Desarraigo.JefeInmediato.Cedula + " - " + dato.Desarraigo.JefeInmediato.Nombre.TrimEnd() + " " +
                //                dato.Desarraigo.JefeInmediato.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.JefeInmediato.SegundoApellido.TrimEnd(),
                //RegistradoPor = dato.Desarraigo.RegistradoPor.IdEntidad > 0 ?
                //                dato.Desarraigo.RegistradoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.RegistradoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.RegistradoPor.SegundoApellido.TrimEnd()
                //                : "",
                //AnalizadoPor = dato.Desarraigo.AnalizadoPor.IdEntidad > 0 ?
                //                dato.Desarraigo.AnalizadoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.AnalizadoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.AnalizadoPor.SegundoApellido.TrimEnd()
                //               : "",
                //RevisadoPor = dato.Desarraigo.RevisadoPor.IdEntidad > 0 ?
                //                dato.Desarraigo.RevisadoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.RevisadoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.RevisadoPor.SegundoApellido.TrimEnd()
                //                : "",
                //AprobadoPor = dato.Desarraigo.AprobadoPor.IdEntidad > 0 ?
                //                dato.Desarraigo.AprobadoPor.Nombre.TrimEnd() + " " + dato.Desarraigo.AprobadoPor.PrimerApellido.TrimEnd() + " " + dato.Desarraigo.AprobadoPor.SegundoApellido.TrimEnd()
                //                : "",
                //Proyecto = dato.Desarraigo.NomProyecto,
                OcupacionReal = dato.DetallePuesto.OcupacionReal.DesOcupacionReal.TrimEnd(),
                Seccion = dato.Desarraigo.Seccion != null ?
                                dato.Desarraigo.Seccion.NomSeccion.TrimEnd() :
                                dato.Desarraigo.Departamento != null ? dato.Desarraigo.Departamento.NomDepartamento.TrimEnd() : "",
                barcodeQR = dato.Desarraigo.EstadoDesarraigo.IdEntidad != 6 ? dato.codigoQR : null,
                Autor = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                Filtros = filtros
            };
        }
    }
}