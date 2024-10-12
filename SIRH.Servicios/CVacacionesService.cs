using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SIRH.DTO;
using SIRH.Logica;

namespace SIRH.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CVacacionesService" in both code and config file together.
    public class CVacacionesService : ICVacacionesService
    {
        public CBaseDTO ObtenerPeriodo(string cedFuncionario, string codigoPeriodo, int codigo)
        {

            return new CPeriodoVacacionesL().ObtenerPeriodo(cedFuncionario, codigoPeriodo, codigo);
        }

        public CBaseDTO AnularPeriodoVacaciones(int codigo)
        {
            return new CPeriodoVacacionesL().AnularPeriodoVacaciones(codigo);
        }

        public CBaseDTO RegistraReintegroVacaciones(string numeroDocumento, CReintegroVacacionesDTO reintegroVacaciones, string cedFuncionario)
        {
            return new CReintegroVacacionesL().RegistraReintegroVacaciones(numeroDocumento, reintegroVacaciones, cedFuncionario);
        }
        public List<CBaseDTO> ListarReintegrosPeriodos(string cedula, string periodo, int codigo)
        {
            return new CReintegroVacacionesL().ListarReintegrosPeriodos(cedula, periodo, codigo);

        }
        public CBaseDTO GuardarRegistroVacaciones(CRegistroVacacionesDTO registroVacaciones, string cedulaFuncionario, string periodo, int documento)
        {
            return new CRegistroVacacionesL().GuardaRegistroVacaciones(registroVacaciones, cedulaFuncionario, periodo, documento);
        }
        public CBaseDTO GuardarRegistroVacacionesNuevo(CRegistroVacacionesDTO registroVacaciones, string cedulaFuncionario, string periodo, int documento, int medioDia, string tipoUsuario)
        {
            return new CRegistroVacacionesL().GuardaRegistroVacaciones(registroVacaciones, cedulaFuncionario, periodo, documento, medioDia, tipoUsuario);
        }
        public CBaseDTO AgregarPermisosAprobacion(string FK_funcionario, string idAprobar)
        {
            return new CAprobacionVacacionesL().AgregarPermisosAprobacion(FK_funcionario, idAprobar);
        }

        public List<List<CBaseDTO>> BuscarVacacionesFuncionario(CFuncionarioDTO funcionario, string periodoVacaciones,
                                   List<DateTime> fechas, string estadoSeleccion, string tipoVacaciones)
        {
            return new CRegistroVacacionesL().BuscarVacacionesFuncionario(funcionario, periodoVacaciones, fechas, estadoSeleccion, tipoVacaciones);
        }
        public List<List<CBaseDTO>> BuscarVacacionesDivision(string division, CPeriodoVacacionesDTO periodoVacaciones,
                                   List<DateTime> fechas, string estadoSeleccion, string tipoVacaciones)
        {
            return new CRegistroVacacionesL().BuscarVacacionesDivision(division, periodoVacaciones, fechas, estadoSeleccion, tipoVacaciones);
        }
        public List<CBaseDTO> ObtenerVacacionesPorSeccion(string nomSeccion)
        {
            return new CRegistroVacacionesL().ObtenerVacacionesPorSeccion(nomSeccion);
        }
        public List<CBaseDTO> ObtenerVacacionesPorDivision(string nomDivision)
        {
            return new CRegistroVacacionesL().ObtenerVacacionesPorDivision(nomDivision);
        }
        public List<CBaseDTO> ObtenerReintegrosPorSeccion(string nomSeccion)
        {
            return new CReintegroVacacionesL().ObtenerReintegrosPorSeccion(nomSeccion);
        }
        public List<CBaseDTO> ObtenerReintegrosPorDivision(string nomDivision)
        {
            return new CReintegroVacacionesL().ObtenerReintegrosPorDivision(nomDivision);
        }
        public List<CBaseDTO> ObtenerVacaciones(string cedFuncionario)
        {
            return new CRegistroVacacionesL().ObtenerVacaciones(cedFuncionario);
        }
        public List<CBaseDTO> ObtenerReintegros(string cedFuncionario)
        {
            return new CReintegroVacacionesL().ObtenerReintegros(cedFuncionario);
        }
        public List<CBaseDTO> ObtenerVacacionesTipoSolicitud(string cedFuncionario, int indEstado)
        {
            return new CRegistroVacacionesL().ObtenerVacacionesTipoSolicitud(cedFuncionario, indEstado);
        }

        public List<List<CBaseDTO>> BuscarReintegrosFuncionario(CFuncionarioDTO funcionario, string periodoVacaciones, List<DateTime> fechas)
        {
            return new CReintegroVacacionesL().BuscarReintegrosFuncionario(funcionario, periodoVacaciones, fechas);
        }
        public List<List<CBaseDTO>> BuscarReintegrosDivision(string division, CPeriodoVacacionesDTO periodoVacaciones, List<DateTime> fechas)
        {
            return new CReintegroVacacionesL().BuscarReintegrosDivision(division, periodoVacaciones, fechas);
        }
        public List<List<CBaseDTO>> ObtenerDetalleVacaciones(string cedFuncionario)
        {
            return new CPeriodoVacacionesL().ObtenerDetalleVacaciones(cedFuncionario);
        }
        public CBaseDTO GuardaRegistroPeriodo(CPeriodoVacacionesDTO registroPeriodo, string cedulaFuncionario)
        {
            return new CPeriodoVacacionesL().GuardaRegistroPeriodo(registroPeriodo, cedulaFuncionario);
        }
        public List<CBaseDTO> ListarRegistroVacaciones(string cedula, string periodo, int codigo)
        {
            return new CRegistroVacacionesL().ListarRegistroVacaciones(cedula, periodo, codigo);
        }
        public List<CBaseDTO> ListarPeriodosActivos(string cedula)
        {
            return new CPeriodoVacacionesL().ListarPeriodosActivos(cedula);
        }
        public List<CBaseDTO> ListarPeriodosNoActivos(string cedula)
        {
            return new CPeriodoVacacionesL().ListarPeriodosNoActivos(cedula);
        }
        public List<CBaseDTO> ListarDivisiones()
        {
            return new CDivisionL().ListarDivisiones();
        }
        public List<CBaseDTO> ListarDireccionGeneral()
        {
            return new CDireccionGeneralL().ListarDireccionGeneral();
        }
        public List<CBaseDTO> ListarDepartamentos()
        {
            return new CDepartamentoL().ListarDepartamentos();
        }
        public List<CBaseDTO> ListarSecciones()
        {
            return new CSeccionL().ListarSecciones();
        }
        public List<List<CBaseDTO>> BuscarVacaciones(CFuncionarioDTO funcionario, CPeriodoVacacionesDTO periodoVacaciones, CRegistroVacacionesDTO registroVacaciones,
                                   List<DateTime> fechas, string direccion, string seccion, string division, string departamento, string estadoSeleccion, string tipoVacaciones)
        {
            return new CRegistroVacacionesL().BuscarVacaciones(funcionario, periodoVacaciones, registroVacaciones, fechas, direccion, seccion, division, departamento, estadoSeleccion, tipoVacaciones);
        }
        public CBaseDTO DetalleContratacion(string cedula)
        {
            return new CDetalleContratacionL().DetalleContratacion(cedula);
        }
        public List<CBaseDTO> ObtenerRegistro(string cedFuncionario, string numeroDocumento)
        {
            return new CRegistroVacacionesL().ObtenerRegistro(cedFuncionario, numeroDocumento);
        }
        public List<List<CBaseDTO>> BuscarReintegros(CFuncionarioDTO funcionario, CPeriodoVacacionesDTO periodoVacaciones, CRegistroVacacionesDTO registroVacaciones,
                              List<DateTime> fechas, string direccion, string seccion, string division, string departamento)
        {
            return new CReintegroVacacionesL().BuscarReintegros(funcionario, periodoVacaciones, registroVacaciones, fechas, direccion, seccion, division, departamento);
        }
        public CBaseDTO GuardarRebajoColectivo(CFuncionarioDTO funcionario, CRegistroVacacionesDTO rebajoColectivo)
        {
            return new CRegistroVacacionesL().GuardarRebajoColectivo(funcionario, rebajoColectivo);
        }
        public List<CBaseDTO> ListarFuncionariosActivos(bool guardasSeguridad, bool oficialesTransito)
        {
            return new CFuncionarioL().ListarFuncionariosActivos(guardasSeguridad, oficialesTransito);
        }

        public CBaseDTO ValidarNumeroDocumento(string numTransaccion)
        {
            return new CRegistroVacacionesL().ValidarNumeroDocumento(numTransaccion);

        }
        public CBaseDTO AnularRebajoColectivo(CFuncionarioDTO funcionario, string rebajoColectivo)
        {
            return new CRegistroVacacionesL().AnularRebajoColectivo(funcionario, rebajoColectivo);
        }
        public List<List<CBaseDTO>> ObtenerInconsistencias(DateTime fechaInicio, DateTime fechaFin, string cedula)
        {
            return new CRegistroVacacionesL().ObtenerInconsistencias(fechaInicio, fechaFin, cedula);
        }
        public List<CBaseDTO> ListaPeriodos(string cedula)
        {
            return new CPeriodoVacacionesL().ListaPeriodos(cedula);

        }

        public CBaseDTO ActualizarDatosVacaciones(int idregistro, string cambio, decimal saldo)
        {
            return new CPeriodoVacacionesL().ActualizarDatosVacaciones(idregistro, cambio, saldo);
        }

        public CBaseDTO TrasladarRegistroVacaciones(int idRegistro, decimal dias, int periodoDestino) => new CRegistroVacacionesL().TrasladarRegistroVacaciones(idRegistro, dias, periodoDestino);

        public List<CBaseDTO> BuscarHistorialMovimientoVacaciones(string cedula, string periodo) => new CPeriodoVacacionesL().BuscarHistorialMovimientoVacaciones(cedula, periodo);

        public List<CBaseDTO> BuscarHistorialPeriodoVacacionesSinActuales(string cedula, List<string> actuales) => new CPeriodoVacacionesL().BuscarHistorialPeriodoVacacionesSinActuales(cedula, actuales);

        public CBaseDTO RegistrarReintegroRegistro(CReintegroVacacionesDTO reintegro) => new CReintegroVacacionesL().RegistrarReintegroRegistro(reintegro);
        public CBaseDTO AnularSolicitudVacaciones(int idSolicitud) => new CRegistroVacacionesL().AnularSolicitudVacaciones(idSolicitud);
        public CBaseDTO AnularSolicitudReintegro(int idSolicitud) => new CReintegroVacacionesL().AnularSolicitudReintegro(idSolicitud);
        public CBaseDTO ActualizarSolicitudVacaciones(string numTransaccion, string estado, string comentario, string cedulaFunc, string funcAprobar) => new CRegistroVacacionesL().ActualizarSolicitudVacaciones(numTransaccion, estado, comentario, cedulaFunc, funcAprobar);
        public CBaseDTO ActualizarReintegros(string SolReintegro, string estado, string comentario, string cedulaFunc, string funcAprobar) => new CReintegroVacacionesL().ActualizarReintegros(SolReintegro, estado, comentario, cedulaFunc, funcAprobar);
        public List<CBaseDTO> ObtenerPermisosAprobacion(string cedulaConPermiso, string cedulaParaAprobar)
        {
            return new CAprobacionVacacionesL().ObtenerPermisosAprobacion(cedulaConPermiso, cedulaParaAprobar);
        }

        public CBaseDTO ListarJefatura(string cedula)
        {
            CVacacionesJefaturaL respuesta = new CVacacionesJefaturaL();
            return respuesta.ListarJefatura(cedula);
        }

        public List<CBaseDTO> ListarDiasPorTipo(int tipo, string cedula)
        {
            CRegistroVacacionesL respuesta = new CRegistroVacacionesL();
            return respuesta.ListarDiasPorTipo(tipo, cedula);
        }

        public CBaseDTO AsignarJefatura(int idFuncionario, int idJefatura)
        {
            return new CVacacionesJefaturaL().AsignarVacacionesJefatura(idFuncionario, idJefatura);
        }
        public List<CBaseDTO> ListarFuncionarios(string cedulaFuncionario, string cedulaJefe, string cedulaJefeSuperior, int idSeccion, int idDireccion, int idDivision)
        {
            return new CVacacionesJefaturaL().ListarFuncionarios(cedulaFuncionario, cedulaJefe, cedulaJefeSuperior, idSeccion, idDireccion, idDivision);
        }

    }
}
