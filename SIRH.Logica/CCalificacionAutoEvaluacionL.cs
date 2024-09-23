using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CCalificacionAutoEvaluacionL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CCalificacionAutoEvaluacionL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CCalificacionAutoEvaluacionDTO ConvertirDatoADto(CalificacionAutoEvaluacion item)
        {
            return new CCalificacionAutoEvaluacionDTO
            {
                IdEntidad = item.PK_CalificacionAutoEvaluacion,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                IndEstado = item.IndEstado,
                Tipo = new CTipoAutoEvaluacionDTO
                {
                    IdEntidad = item.TipoAutoevaluacion.PK_Tipo,
                    DesTipo = item.TipoAutoevaluacion.DesTipo,
                    DesDetalle = item.TipoAutoevaluacion.DesDetalle
                },
                Periodo = new CPeriodoCalificacionDTO {IdEntidad = item.PeriodoCalificacion.PK_PeriodoCalificacion },
                Funcionario = CFuncionarioL.ConvertirDatosFuncionarioADTO(item.Funcionario)
            };
        }

        internal static CalificacionAutoEvaluacion ConvertirDTOADatos(CCalificacionAutoEvaluacionDTO item)
        {
            return new CalificacionAutoEvaluacion
            {
                PK_CalificacionAutoEvaluacion  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                IndEstado = item.IndEstado
            };
        }


        internal static CCatCalificacionAutoevaluacionDTO ConvertirCatalogoDatoADto(CatCalificacionAutoevaluacion item)
        {
            return new CCatCalificacionAutoevaluacionDTO
            {
                IdEntidad = item.PK_Autoevaluacion,
                PorDesarrollar = item.PorDesarrollar,
                PorMejorar = item.PorMejorar,
                PorCumple = item.PorCumple,
                Tipo = new CTipoAutoEvaluacionDTO
                {
                    IdEntidad = item.TipoAutoevaluacion.PK_Tipo,
                    DesTipo = item.TipoAutoevaluacion.DesTipo,
                    DesDetalle = item.TipoAutoevaluacion.DesDetalle
                },
                Clase = new CClaseDTO
                {
                    IdEntidad = item.Clase.PK_Clase,
                    DesClase = item.Clase.DesClase.TrimEnd()
                }
            };
        }

        internal static CatCalificacionAutoevaluacion ConvertirCatalogoDTOADatos(CCatCalificacionAutoevaluacionDTO item)
        {
            return new CatCalificacionAutoevaluacion
            {
                PK_Autoevaluacion = item.IdEntidad,
                PorDesarrollar = item.PorDesarrollar,
                PorMejorar = item.PorMejorar,
                PorCumple = item.PorCumple
            };
        }

        public List<CBaseDTO> GuardarAutoEvaluacion(CCalificacionAutoEvaluacionDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            var mensaje = "Inicio";
            try
            {
                CCalificacionAutoEvaluacionD intermedio = new CCalificacionAutoEvaluacionD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                mensaje = "ConvertirDTO";
                CalificacionAutoEvaluacion datos = ConvertirDTOADatos(registro);

                mensaje = "Periodo " + registro.Periodo.IdEntidad.ToString();
                // Periodo
                var entidadPer = intermedioCal.ObtenerPeriodoCalificacion(registro.Periodo.IdEntidad);
                if (entidadPer.Codigo > 0)
                    datos.PeriodoCalificacion = (PeriodoCalificacion)entidadPer.Contenido;
                else
                    throw new Exception("No se encontró la información del Período");

                // Funcionarios
                mensaje = "Funcionario " + registro.Funcionario.Cedula;
                var entidadFun = intermedioFun.BuscarFuncionarioCedula(registro.Funcionario.Cedula);

                if (entidadFun != null)
                    datos.Funcionario = entidadFun;
                else
                    throw new Exception("No se encontró la información del Funcionario");

                // Tipo 
                mensaje = "TipoAutoEvaluacion " + registro.Tipo.IdEntidad.ToString();
                CTipoAutoEvaluacionD intermedioTipo = new CTipoAutoEvaluacionD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.Tipo.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoAutoevaluacion = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo");

                mensaje = "Insertar ";
                datos.IndEstado = 1;
                var insertaCN = intermedio.AgregarAutoEvaluacion(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionAutoEvaluacion;
                    mensaje = "Insertó " + registro.IdEntidad.ToString();
                    respuesta.Add(registro);
                }
                else
                {
                    throw new Exception(((CErrorDTO)respuesta[0]).MensajeError);
                }
            }
            catch (Exception error)
            {              
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message + " " + mensaje
                });
               // respuesta.Add(((CErrorDTO)((CRespuestaDTO)respuesta[0]).Contenido));
            }

            return respuesta;
        }

        public CBaseDTO AnularAutoEvaluacion(CCalificacionAutoEvaluacionDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CCalificacionAutoEvaluacionD intermedio = new CCalificacionAutoEvaluacionD(contexto);
                
                var modificar = intermedio.EditarAutoEvaluacion(registro.IdEntidad);

                //pregunto si da error
                if (modificar.Codigo > 0)
                    respuesta = new CBaseDTO { IdEntidad = registro.IdEntidad };
                else
                    throw new Exception(((CErrorDTO)modificar.Contenido).MensajeError);
            }
            catch (Exception error)
            {
                return new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                };
                // respuesta.Add(((CErrorDTO)((CRespuestaDTO)respuesta[0]).Contenido));
            }

            return respuesta;
        }

        public List<CBaseDTO> ObtenerAutoEvaluacionFuncionario(CPeriodoCalificacionDTO periodo, CFuncionarioDTO funcionario)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCalificacionAutoEvaluacionD intermedio = new CCalificacionAutoEvaluacionD(contexto);

                var datoCatalogo = new List<CatCalificacionAutoevaluacion>();

                var datosDetallePuestoF = new CCalificacionNombramientoL().DescargarFuncionarioCalificarDetallePuesto(funcionario.Cedula, periodo.IdEntidad);
                if (datosDetallePuestoF != null && datosDetallePuestoF.FirstOrDefault().GetType() != typeof(CErrorDTO))
                {
                    var detallePuesto = (CDetallePuestoDTO)datosDetallePuestoF.ElementAt(2);

                    // Cargar el Catálogo
                    CCatCalificacionAutoevaluacionD intermedioCat = new CCatCalificacionAutoevaluacionD(contexto);
                    datoCatalogo = intermedioCat.CargarPorClase(detallePuesto.Clase.IdEntidad);
                    if (datoCatalogo == null)
                        throw new Exception("No existe información de la Autoevaluación de la Clase " + detallePuesto.Clase.IdEntidad.ToString() + " - " + (detallePuesto.Clase.DesClase != null ? detallePuesto.Clase.DesClase.TrimEnd() : "") + ". Favor comunicarse con la Unidad de Gestión del Rendimiento");
                    if (datoCatalogo.Count == 0)
                        throw new Exception("No existe información de la Autoevaluación de la Clase " + detallePuesto.Clase.IdEntidad.ToString() + " - " + (detallePuesto.Clase.DesClase != null ? detallePuesto.Clase.DesClase.TrimEnd() : "") + ". Favor comunicarse con la Unidad de Gestión del Rendimiento");
                }
                else
                {
                    throw new Exception(((CErrorDTO)datosDetallePuestoF.ElementAt(0)).Mensaje);
                }


                var dato = intermedio.ConsultarAutoEvaluacion(periodo.IdEntidad, funcionario.IdEntidad);
                if (dato.Codigo != -1)
                {
                    foreach(var item in (List<CalificacionAutoEvaluacion>)dato.Contenido)
                    {
                        var datoCal = ConvertirDatoADto(item);
                        var registro = datoCatalogo.Where(Q => Q.FK_TipoAutoevaluacion == item.FK_Tipo).FirstOrDefault();
                        datoCal.PorDesarrollar = registro != null ? registro.PorDesarrollar : 0;
                        datoCal.PorMejorar = registro != null ? registro.PorMejorar : 0;
                        datoCal.PorCumple = registro != null ? registro.PorCumple : 0;
                        respuesta.Add(datoCal);
                    }
                }
                if(respuesta.Count == 0)
                {
                    foreach (var item in datoCatalogo)
                    {
                        respuesta.Add(ConvertirCatalogoDatoADto(item));
                    }

                    //var datosDetallePuestoF = new CCalificacionNombramientoL().DescargarFuncionarioCalificarDetallePuesto(funcionario.Cedula, periodo.IdEntidad);
                    //if (datosDetallePuestoF != null && datosDetallePuestoF.FirstOrDefault().GetType() != typeof(CErrorDTO))
                    //{
                    //    var detallePuesto = (CDetallePuestoDTO)datosDetallePuestoF.ElementAt(2);

                    //    // Cargar el Catálogo
                    //    CCatCalificacionAutoevaluacionD intermedioCat = new CCatCalificacionAutoevaluacionD(contexto);
                    //    var datoCatalogo = intermedioCat.CargarPorClase(detallePuesto.Clase.IdEntidad);
                    //    if (datoCatalogo != null)
                    //    {
                    //        foreach (var item in datoCatalogo)
                    //        {
                    //            respuesta.Add(ConvertirCatalogoDatoADto(item));
                    //        }
                    //    }
                    //    else
                    //    {
                    //        throw new Exception("No existe información de la Autoevaluación de la Clase " + detallePuesto.Clase.IdEntidad.ToString() + " - " + detallePuesto.Clase.DesClase != null ? detallePuesto.Clase.DesClase.TrimEnd() : "" + ". Favor comunicarse con la Unidad de Gestión del Rendimiento");
                    //    }
                    //}
                    //else
                    //{                   
                    //  throw new Exception(((CErrorDTO)datosDetallePuestoF.ElementAt(0)).Mensaje);
                    //}

                    //respuesta.Add((CErrorDTO)dato.Contenido);
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                });
            }

            return respuesta;
        }

        #endregion
    }
}