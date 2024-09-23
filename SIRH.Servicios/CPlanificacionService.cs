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
    // NOTE: If you change the class name "CTipoIncapacidadService" here, you must also update the reference to "CTipoIncapacidadService" in App.config.
    public class CPlanificacionService : ICPlanificacionService
    {
        CPlanificacionL respuesta = new CPlanificacionL();

        public List<List<CBaseDTO>> ListarNombramientosActivos(CListaNombramientosActivosDTO datoBusqueda)
        {
            return respuesta.ListarNombramientosActivos(datoBusqueda);
        }

        public List<CBaseDTO> ListarNombramientosFuncionario(string cedula)
        {
            return respuesta.ListarNombramientosFuncionario(cedula);
        }

        public List<CBaseDTO> ListarPagosFuncionario(string cedula)
        {
            return respuesta.ListarPagosFuncionario(cedula);
        }

        public List<CBaseDTO> CrearSolicitudVacia()
        {
            return respuesta.CrearSolicitudVacia();
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

        public List<CBaseDTO> ListarClases()
        {
            return respuesta.ListarClases();
        }
        public List<CBaseDTO> ListarEstadoCivil()
        {
            return respuesta.ListarEstadoCivil();
        }
        public List<CBaseDTO> ListarEstadoFuncionario()
        {
            return respuesta.ListarEstadoFuncionario();
        }

        public List<string[]> GenerarDatosReportes(List<CParametrosDTO> parametros)
        {
            return respuesta.GenerarDatosReportes(parametros);
        }


        /*  Plan Estratégico   */
        public CBaseDTO AgregarPlan(CPlanEstrategicoDTO plan)
        {
            CPlanEstrategicoL logica = new CPlanEstrategicoL();
            return logica.AgregarPlan(plan);
        }
        public CBaseDTO CargarPlanPorId(int idPlan)
        {
            CPlanEstrategicoL logica = new CPlanEstrategicoL();
            return logica.CargarPlanPorId(idPlan);
        }
        public CBaseDTO ModificarPlan(CPlanEstrategicoDTO plan)
        {
            CPlanEstrategicoL logica = new CPlanEstrategicoL();
            return logica.ActualizarPlan(plan);
        }
        public List<CBaseDTO> BuscarPlanEstrategico(CPlanEstrategicoDTO plan, CDireccionGeneralDTO direccion,
                                            List<DateTime> fechas)
        {
            CPlanEstrategicoL logica = new CPlanEstrategicoL();
            return logica.BuscarPlanEstrategico(plan, direccion, fechas);
        }
        public CBaseDTO RemitirPlanEstrategico(CPlanEstrategicoDTO plan, String De, String Para, String Mensaje)
        {
            CPlanEstrategicoL logica = new CPlanEstrategicoL();
            return logica.RemitirPlanEstrategico(plan, De, Para, Mensaje);
        }


        /*  EJES   */
        public CBaseDTO AgregarEje(CPlanEstrategicoEjeDTO eje)
        {
            CPlanEstrategicoEjeL logica = new CPlanEstrategicoEjeL();
            return logica.AgregarEje(eje);
        }
        public CBaseDTO ModificarEje(CPlanEstrategicoEjeDTO eje)
        {
            CPlanEstrategicoEjeL logica = new CPlanEstrategicoEjeL();
            return logica.ActulizarEje(eje);
        }
        public CBaseDTO AnularEje(CPlanEstrategicoEjeDTO eje)
        {
            CPlanEstrategicoEjeL logica = new CPlanEstrategicoEjeL();
            return logica.DeleteEje(eje);
        }
        public CBaseDTO CargarEjePorId(int idEje)
        {
            CPlanEstrategicoEjeL logica = new CPlanEstrategicoEjeL();
            return logica.CargarEjePorId(idEje);
        }
        public List<CBaseDTO> ListarEjesPlan(int idPlan)
        {
            CPlanEstrategicoEjeL logica = new CPlanEstrategicoEjeL();
            return logica.CargarEjesPlan(idPlan);
        }


        /*  Líneas   */
        public CBaseDTO AgregarLinea(CPlanEstrategicoLineaDTO linea)
        {
            CPlanEstrategicoLineaL logica = new CPlanEstrategicoLineaL();
            return logica.AgregarLinea(linea);
        }
        public CBaseDTO ModificarLinea(CPlanEstrategicoLineaDTO linea)
        {
            CPlanEstrategicoLineaL logica = new CPlanEstrategicoLineaL();
            return logica.ActualizarLinea(linea);
        }
        public CBaseDTO AnularLinea(CPlanEstrategicoLineaDTO linea)
        {
            CPlanEstrategicoLineaL logica = new CPlanEstrategicoLineaL();
            return logica.DeleteLinea(linea);
        }
        public List<CBaseDTO> ListarLineasEje(int idEje)
        {
            CPlanEstrategicoLineaL logica = new CPlanEstrategicoLineaL();
            return logica.CargarLineasEje(idEje);
        }
        public CBaseDTO CargarLineaPorId(int idLinea)
        {
            CPlanEstrategicoLineaL logica = new CPlanEstrategicoLineaL();
            return logica.CargarLineaPorId(idLinea);
        }


        /* Productos */
        public CBaseDTO AgregarProducto(CPlanEstrategicoProductoDTO producto)
        {
            CPlanEstrategicoProductoL logica = new CPlanEstrategicoProductoL();
            return logica.AgregarProducto(producto);
        }
        public CBaseDTO ModificarProducto(CPlanEstrategicoProductoDTO producto)
        {
            CPlanEstrategicoProductoL logica = new CPlanEstrategicoProductoL();
            return logica.UpdateProducto(producto);
        }
        public CBaseDTO AnularProducto(CPlanEstrategicoProductoDTO producto)
        {
            CPlanEstrategicoProductoL logica = new CPlanEstrategicoProductoL();
            return logica.DeleteProducto(producto);
        }
        public List<CBaseDTO> ListarProductosLinea(int idLinea)
        {
            CPlanEstrategicoProductoL logica = new CPlanEstrategicoProductoL();
            return logica.CargarProductosLinea(idLinea);
        }
        public CBaseDTO CargarProductoPorId(int idProducto)
        {
            CPlanEstrategicoProductoL logica = new CPlanEstrategicoProductoL();
            return logica.CargarProductoPorId(idProducto);
        }


        /* AccionesEstratégicas */
        public CBaseDTO AgregarAccion(CPlanEstrategicoAccionDTO accion)
        {
            CPlanEstrategicoAccionL logica = new CPlanEstrategicoAccionL();
            return logica.AgregarAccion(accion);
        }
        public CBaseDTO ModificarAccion(CPlanEstrategicoAccionDTO accion)
        {
            CPlanEstrategicoAccionL logica = new CPlanEstrategicoAccionL();
            return logica.UpdateAccionEstrategica(accion);
        }
        public CBaseDTO AnularAccion(CPlanEstrategicoAccionDTO accion)
        {
            CPlanEstrategicoAccionL logica = new CPlanEstrategicoAccionL();
            return logica.DeleteAccion(accion);
        }
        public List<CBaseDTO> ListarAccionesProducto(int idProducto)
        {
            CPlanEstrategicoAccionL logica = new CPlanEstrategicoAccionL();
            return logica.CargarAccionesProducto(idProducto);
        }
        public CBaseDTO CargarAccionPorId(int idAccion)
        {
            CPlanEstrategicoAccionL logica = new CPlanEstrategicoAccionL();
            return logica.CargarAccionPorId(idAccion);
        }


        /* Metas */
        public CBaseDTO AgregarMeta(CPlanAnualMetaDTO meta, CPlanAnualDTO plan)
        {
            CPlanAnualMetaL logica = new CPlanAnualMetaL();
            return logica.AgregarMeta(meta, plan);
        }
        public CBaseDTO ModificarMeta(CPlanAnualMetaDTO meta)
        {
            CPlanAnualMetaL logica = new CPlanAnualMetaL();
            return logica.UpdateMeta(meta);
        }
        public CBaseDTO AnularMeta(CPlanAnualMetaDTO meta)
        {
            CPlanAnualMetaL logica = new CPlanAnualMetaL();
            return logica.DeleteMeta(meta);
        }
        public CBaseDTO CargarMetaPorId(int idMeta)
        {
            CPlanAnualMetaL logica = new CPlanAnualMetaL();
            return logica.CargarMetaPorId(idMeta);
        }


        /* Plan Institucional */
        public CBaseDTO AgregarPlanAnual(CPlanAnualDTO plan)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.AgregarPlan(plan);
        }
        public CBaseDTO ModificarPlanAnual(CPlanAnualDTO plan)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.ActualizarPlan(plan);
        }
        public CBaseDTO CargarPlanAnualPorId(int idPlan)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.CargarPlanPorId(idPlan);
        }
        public List<CBaseDTO> BuscarPlanAnual(CPlanAnualDTO plan, CSeccionDTO seccion)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.BuscarPlanAnual(plan, seccion);
        }
        public CBaseDTO EnlazarProductoAlPlanAnual(CPlanEstrategicoProductoDTO producto, CPlanAnualDTO plan)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.EnlazarProductoAlPlanAnual(producto, plan);
        }
        public CBaseDTO DesenlazarProductoAlPlanAnual(CPlanAnualProductosDTO plan)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.DesenlazarProductoAlPlanAnual(plan);
        }
        public CBaseDTO ModificarEstadoPlanAnual(CPlanAnualDTO plan)
        {
            CPlanAnualL logica = new CPlanAnualL();
            return logica.ModificarEstadoPlan(plan);
        }




        /* Accion plan anual */
        public CBaseDTO ModificarActividad_AccionPlanAnual(CPlanAnualActividadDTO actividad)
        {
            CPlanAnualActividadL logica = new CPlanAnualActividadL();
            return logica.UpdateActividad_AccionPlanAnual(actividad);
        }



        /* Actividades del plan */

        public CBaseDTO AgregarPlanAnualActividad(CPlanAnualActividadDTO actividad)
        {
            CPlanAnualActividadL logica = new CPlanAnualActividadL();
            return logica.AgregarActividad(actividad);
        }

        public CBaseDTO ModificarPlanAnualActividad(CPlanAnualActividadDTO actividad)
        {
            CPlanAnualActividadL logica = new CPlanAnualActividadL();
            return logica.ModificarActividad(actividad);
        }
        public CBaseDTO AnularPlanAnualActividad(CPlanAnualActividadDTO actividad)
        {
            CPlanAnualActividadL logica = new CPlanAnualActividadL();
            return logica.DeleteActividad(actividad);
        }

        public CBaseDTO CargarPlanAnualActividadPorId(int idActividad)
        {
            CPlanAnualActividadL logica = new CPlanAnualActividadL();
            return logica.CargarActividadPorId(idActividad);
        }

        public CBaseDTO ModificarFuncionarioActividad(CPlanAnualActividadFuncionarioDTO actividad)
        {
            CPlanAnualActividadL logica = new CPlanAnualActividadL();
            return logica.ModificarFuncionario(actividad);
        }


        /* Avance */
        public CBaseDTO AgregarAvance(CPlanAnualActividadAvanceDTO avance)
        {
            CPlanAnualActividadAvanceL logica = new CPlanAnualActividadAvanceL();
            return logica.AgregarAvance(avance);
        }
        public CBaseDTO ModificarAvance(CPlanAnualActividadAvanceDTO avance)
        {
            CPlanAnualActividadAvanceL logica = new CPlanAnualActividadAvanceL();
            return logica.UpdateAvance(avance);
        }
        public CBaseDTO AnularAvance(CPlanAnualActividadAvanceDTO avance)
        {
            CPlanAnualActividadAvanceL logica = new CPlanAnualActividadAvanceL();
            return logica.DeleteAvance(avance);
        }
        public CBaseDTO CargarAvancePorId(int idAvance)
        {
            CPlanAnualActividadAvanceL logica = new CPlanAnualActividadAvanceL();
            return logica.CargarAvancePorId(idAvance);
        }
        public List<CBaseDTO> ListarAvancesActividad(int idActividad)
        {
            CPlanAnualActividadAvanceL logica = new CPlanAnualActividadAvanceL();
            return logica.CargarAvancesActividad(idActividad);
        }

    }
}