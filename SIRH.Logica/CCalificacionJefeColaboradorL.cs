using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CCalificacionJefeColaboradorL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CCalificacionJefeColaboradorL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CCalificacionJefeColaboradorDTO ConvertirDatoADto(CalificacionJefeColaborador item)
        {
            return new CCalificacionJefeColaboradorDTO
            {
                IdEntidad = item.PK_CalificacionColaborador,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                IndEstado = item.IndEstado,
                Tipo = new CTipoCalJefeColaboradorDTO
                {
                    IdEntidad = item.TipoCalJefeColaborador.PK_Tipo,
                    DesTipo = item.TipoCalJefeColaborador.DesTipo,
                    DesDetalle = item.TipoCalJefeColaborador.DesDetalle
                },
                Periodo = new CPeriodoCalificacionDTO { IdEntidad = item.PeriodoCalificacion.PK_PeriodoCalificacion },
                Jefatura = CFuncionarioL.ConvertirDatosFuncionarioADTO(item.Funcionario),
                Colaborador = CFuncionarioL.ConvertirDatosFuncionarioADTO(item.Funcionario1)
            };
        }

        internal static CalificacionJefeColaborador ConvertirDTOADatos(CCalificacionJefeColaboradorDTO item)
        {
            return new CalificacionJefeColaborador
            {
                PK_CalificacionColaborador  = item.IdEntidad,
                DesNota = item.DesNota,
                PorNota = item.PorNota,
                IndEstado = item.IndEstado,
                DesObservaciones = item.DesObservaciones
            };
        }

        public List<CBaseDTO> GuardarCalificacionColaborador(CCalificacionJefeColaboradorDTO registro)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCalificacionJefeColaboradorD intermedio = new CCalificacionJefeColaboradorD(contexto);
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

                CalificacionJefeColaborador datos = ConvertirDTOADatos(registro);

                // Periodo
                var entidadPer = intermedioCal.ObtenerPeriodoCalificacion(registro.Periodo.IdEntidad);
                if (entidadPer.Codigo > 0)
                    datos.PeriodoCalificacion = (PeriodoCalificacion)entidadPer.Contenido;
                else
                    throw new Exception("No se encontró la información del Período");

                // Jefatura
                var entidadFun = intermedioFun.BuscarFuncionarioCedula(registro.Jefatura.Cedula);

                if (entidadFun != null)
                    datos.Funcionario = entidadFun;
                else
                    throw new Exception("No se encontró la información de la Jefatura");

                // Colaborador
                var entidadCol = intermedioFun.BuscarFuncionarioCedula(registro.Colaborador.Cedula);

                if (entidadCol != null)
                    datos.Funcionario1 = entidadCol;
                else
                    throw new Exception("No se encontró la información del Colaborador");

                // Tipo 
                CTipoCalJefeColaboradorD intermedioTipo = new CTipoCalJefeColaboradorD(contexto);
                var entidadTipo = intermedioTipo.CargarTipoPorID(registro.Tipo.IdEntidad);
                if (entidadTipo != null)
                    datos.TipoCalJefeColaborador = entidadTipo;
                else
                    throw new Exception("No se encontró la información del Tipo");

                datos.IndEstado = 1;
                var insertaCN = intermedio.AgregarCalificacionColaborador(datos);
                
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    registro.IdEntidad = datos.PK_CalificacionColaborador;
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

        public CBaseDTO AnularCalificacionColaborador(CCalificacionJefeColaboradorDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CCalificacionJefeColaboradorD intermedio = new CCalificacionJefeColaboradorD(contexto);
                
                var modificar = intermedio.EditarCalificacioColaborador(registro.IdEntidad);

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

        public List<CBaseDTO> ObtenerCalificacionJefeColaborador(CPeriodoCalificacionDTO periodo, CFuncionarioDTO funcionario)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CCalificacionJefeColaboradorD intermedio = new CCalificacionJefeColaboradorD(contexto);

                var dato = intermedio.ConsultarCalificacionJefeColaborador(periodo.IdEntidad, funcionario.IdEntidad);
                if (dato.Codigo != -1)
                {
                    foreach(var item in (List<CalificacionJefeColaborador>)dato.Contenido)
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