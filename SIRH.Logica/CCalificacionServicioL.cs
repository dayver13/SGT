using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CCalificacionServicioL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CCalificacionServicioL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CCalificacionServicioDTO ConvertirDatoADto(CalificacionServicio item)
        {
            return new CCalificacionServicioDTO
            {
                IdEntidad = item.PK_CalificacionServicio,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                IndEstado = item.IndEstado,
                TipoCategoria = new CTipoCategoriaServicioDTO
                {
                    IdEntidad = item.TipoCategoriaServicio.PK_TipoCategoria,
                    DesCategoria = item.TipoCategoriaServicio.DesCategoria
                }
            };
        }

        internal static CalificacionServicio ConvertirDTOADatos(CCalificacionServicioDTO item)
        {
            return new CalificacionServicio
            {
                PK_CalificacionServicio  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                IndEstado = item.IndEstado
            };
        }

        public List<CBaseDTO> GuardarServicio(CCalificacionServicioDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCalificacionServicioD intermedio = new CCalificacionServicioD(contexto);
                CDireccionGeneralD intermedioDir = new CDireccionGeneralD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                CalificacionServicio datos = ConvertirDTOADatos(registro);

                // Periodo
                var entidadPer = intermedioCal.ObtenerPeriodoCalificacion(registro.Periodo.IdEntidad);
                if (entidadPer.Codigo > 0)
                    datos.PeriodoCalificacion = (PeriodoCalificacion)entidadPer.Contenido;
                else
                    throw new Exception("No se encontró la información del Período");

                // Dirección
                var entidadDir = intermedioDir.CargarDireccionGeneralPorID(registro.Direccion.IdEntidad);

                if (entidadDir != null)
                    datos.DireccionGeneral = entidadDir;
                else
                    throw new Exception("No se encontró la información de la Dirección");

                // Tipo Categoría
                CTipoCategoriaServicioD intermedioTipo = new CTipoCategoriaServicioD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.TipoCategoria.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoCategoriaServicio = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo de Categoría");

                datos.IndEstado = 1;
                var insertaCN = intermedio.AgregarServicio(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionServicio;
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
                    MensajeError = error.Message
                });
               // respuesta.Add(((CErrorDTO)((CRespuestaDTO)respuesta[0]).Contenido));
            }

            return respuesta;
        }

        public CBaseDTO AnularServicio(CCalificacionServicioDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CCalificacionServicioD intermedio = new CCalificacionServicioD(contexto);
                
                var modificar = intermedio.EditarServicio(registro.IdEntidad);

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

        public List<CBaseDTO> ObtenerCalificacionDireccion(CPeriodoCalificacionDTO periodo, CDireccionGeneralDTO direccion)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCalificacionServicioD intermedio = new CCalificacionServicioD(contexto);

                var dato = intermedio.ConsultarCalificacionDireccion(periodo.IdEntidad, direccion.IdEntidad);
                if (dato.Codigo != -1)
                {
                    foreach(var item in (List<CalificacionServicio>)dato.Contenido)
                    {
                        respuesta.Add(ConvertirDatoADto(item));
                    }
                }
                else
                {
                    respuesta.Add((CErrorDTO)dato.Contenido);
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

        public List<CBaseDTO> ConsultarCalificacionPeriodo(CPeriodoCalificacionDTO periodo)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCalificacionServicioD intermedio = new CCalificacionServicioD(contexto);

                var dato = intermedio.ConsultarCalificacionPeriodo(periodo.IdEntidad);
                if (dato.Codigo != -1)
                {
                    foreach (var item in (List<CalificacionServicio>)dato.Contenido)
                    {
                        respuesta.Add(ConvertirDatoADto(item));
                    }
                }
                else
                {
                    respuesta.Add((CErrorDTO)dato.Contenido);
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