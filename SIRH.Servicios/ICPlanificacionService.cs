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
    // NOTE: If you change the interface name "ICPlanificacionService" here, you must also update the reference to "ICTipoIncapacidadService" in App.config.
    [ServiceContract]
    public interface ICPlanificacionService
    {
        [OperationContract]
        List<List<CBaseDTO>> ListarNombramientosActivos(CListaNombramientosActivosDTO datoBusqueda);

        [OperationContract]
        List<CBaseDTO> ListarNombramientosFuncionario(string cedula);

        [OperationContract]
        List<CBaseDTO> ListarPagosFuncionario(string cedula);

        [OperationContract]
        List<CBaseDTO> CrearSolicitudVacia();

        [OperationContract]
        List<CBaseDTO> ListarDivisiones();

        [OperationContract]
        List<CBaseDTO> ListarDireccionGeneral();

        [OperationContract]
        List<CBaseDTO> ListarDepartamentos();

        [OperationContract]
        List<CBaseDTO> ListarSecciones();

        [OperationContract]
        List<CBaseDTO> ListarClases();

        [OperationContract]
        List<CBaseDTO> ListarEstadoCivil();

        [OperationContract]
        List<CBaseDTO> ListarEstadoFuncionario();

        [OperationContract]
        List<string[]> GenerarDatosReportes(List<CParametrosDTO> parametros);

        
        //Plan Estratégico
        [OperationContract]
        CBaseDTO AgregarPlan(CPlanEstrategicoDTO plan);
        [OperationContract]
        CBaseDTO CargarPlanPorId(int idPlan);
        [OperationContract]
        List<CBaseDTO> BuscarPlanEstrategico(CPlanEstrategicoDTO plan, CDireccionGeneralDTO direccion, List<DateTime> fechas);
        [OperationContract]
        CBaseDTO ModificarPlan(CPlanEstrategicoDTO plan);

        //Ejes
        [OperationContract]
        CBaseDTO AgregarEje(CPlanEstrategicoEjeDTO eje);
        [OperationContract]
        CBaseDTO CargarEjePorId(int idEje);
        [OperationContract]
        List<CBaseDTO> ListarEjesPlan(int idPlan);
        [OperationContract]
        CBaseDTO ModificarEje(CPlanEstrategicoEjeDTO eje);
        [OperationContract]
        CBaseDTO AnularEje(CPlanEstrategicoEjeDTO eje);

        //Lineas
        [OperationContract]
        CBaseDTO AgregarLinea(CPlanEstrategicoLineaDTO linea);
        [OperationContract]
        CBaseDTO ModificarLinea(CPlanEstrategicoLineaDTO linea);
        [OperationContract]
        CBaseDTO AnularLinea(CPlanEstrategicoLineaDTO linea);
        [OperationContract]
        List<CBaseDTO> ListarLineasEje(int idEje);
        [OperationContract]
        CBaseDTO CargarLineaPorId(int idLinea);
      
        
        //Productos
        [OperationContract]
        CBaseDTO AgregarProducto(CPlanEstrategicoProductoDTO producto);
        [OperationContract]
        CBaseDTO ModificarProducto(CPlanEstrategicoProductoDTO producto);
        [OperationContract]
        CBaseDTO AnularProducto(CPlanEstrategicoProductoDTO producto);
        [OperationContract]
        List<CBaseDTO> ListarProductosLinea(int idLinea);
        [OperationContract]
        CBaseDTO CargarProductoPorId(int idProducto);


        //Acciones Estratégicas
        [OperationContract]
        CBaseDTO AgregarAccion(CPlanEstrategicoAccionDTO accion);
        [OperationContract]
        CBaseDTO ModificarAccion(CPlanEstrategicoAccionDTO accion);
        [OperationContract]
        CBaseDTO AnularAccion(CPlanEstrategicoAccionDTO accion);
        [OperationContract]
        List<CBaseDTO> ListarAccionesProducto(int idProducto);
        [OperationContract]
        CBaseDTO CargarAccionPorId(int idAccion);
      
       
        //Metas
        [OperationContract]
        CBaseDTO AgregarMeta(CPlanAnualMetaDTO meta, CPlanAnualDTO plan);
        [OperationContract]
        CBaseDTO ModificarMeta(CPlanAnualMetaDTO meta);
        [OperationContract]
        CBaseDTO AnularMeta(CPlanAnualMetaDTO meta);
        [OperationContract]
        CBaseDTO CargarMetaPorId(int idMeta);
        

        //Plan Institucional
        [OperationContract]
        CBaseDTO AgregarPlanAnual(CPlanAnualDTO plan);
        [OperationContract]
        CBaseDTO ModificarPlanAnual(CPlanAnualDTO plan);
        [OperationContract]
        CBaseDTO CargarPlanAnualPorId(int idPlan);
        [OperationContract]
        List<CBaseDTO> BuscarPlanAnual(CPlanAnualDTO plan, CSeccionDTO seccion);
        [OperationContract]
        CBaseDTO EnlazarProductoAlPlanAnual(CPlanEstrategicoProductoDTO producto, CPlanAnualDTO plan);
        [OperationContract]
        CBaseDTO DesenlazarProductoAlPlanAnual(CPlanAnualProductosDTO plan);
        [OperationContract]
        CBaseDTO ModificarEstadoPlanAnual(CPlanAnualDTO plan);
        [OperationContract]
        CBaseDTO RemitirPlanEstrategico(CPlanEstrategicoDTO plan, String De, String Para, String Mensaje);

        //ACTIVIDAD PLAN ANUAL
        [OperationContract]
        CBaseDTO AgregarPlanAnualActividad(CPlanAnualActividadDTO actividad);
        [OperationContract]
        CBaseDTO ModificarActividad_AccionPlanAnual(CPlanAnualActividadDTO actividad);
        [OperationContract]
        CBaseDTO CargarPlanAnualActividadPorId(int idActividad);
        [OperationContract]
        CBaseDTO ModificarPlanAnualActividad(CPlanAnualActividadDTO actividad);
        [OperationContract]
        CBaseDTO AnularPlanAnualActividad(CPlanAnualActividadDTO actividad);
        [OperationContract]
        CBaseDTO ModificarFuncionarioActividad(CPlanAnualActividadFuncionarioDTO actividad);

        //AVANCE ACTIVIDAD 
        [OperationContract]
        CBaseDTO AgregarAvance(CPlanAnualActividadAvanceDTO avance);
        [OperationContract]
        CBaseDTO CargarAvancePorId(int idAvance);
        [OperationContract]
        List<CBaseDTO> ListarAvancesActividad(int idActividad);
        [OperationContract]
        CBaseDTO ModificarAvance(CPlanAnualActividadAvanceDTO avance);
        [OperationContract]
        CBaseDTO AnularAvance(CPlanAnualActividadAvanceDTO avance);
        
    }
}