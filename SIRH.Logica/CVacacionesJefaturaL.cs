using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;


namespace SIRH.Logica
{
    public class CVacacionesJefaturaL
    {
        #region Variables

        SIRHEntities contexto;
        CCalificacionNombramientoD calificacionDescarga;

        #endregion

        #region constructor

        public CVacacionesJefaturaL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

         //**recisar con Orlando
        internal static CVacacionesJefaturaDTO ConvertirDatosCVacacionesJefaturaLADto(VacacionesJefatura item)
        {
            return new CVacacionesJefaturaDTO
            {
                Funcionario = new CFuncionarioDTO
                {
                    IdEntidad = Convert.ToInt32(item.FkFuncionario)
                },
                JefeInmediato = new CFuncionarioDTO
                {
                    IdEntidad = Convert.ToInt32(item.idJefeInmediato)
                },
                JefeSuperior = new CFuncionarioDTO
                {
                    IdEntidad = Convert.ToInt32(item.idJefeSuperior)
                }
            };
        }

        public CBaseDTO AsignarVacacionesJefatura(int codFuncionario, int codJefeInmediato)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CVacacionesJefaturaD intermedio = new CVacacionesJefaturaD(contexto);

                var datos = intermedio.AsignarVacacionesJefatura(codFuncionario, codJefeInmediato);

                if (datos.Codigo > 0)
                {
                    respuesta = new CBaseDTO { IdEntidad = datos.IdEntidad };
                }
                else
                {
                    respuesta = (CErrorDTO)datos.Contenido;
                }
            }
            catch (Exception error)
            {
                respuesta = new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                };
            }

            return respuesta;
        }


        public CBaseDTO ListarJefatura(string cedula)
        {
            CBaseDTO respuesta = new CBaseDTO();
            try
            {
                CVacacionesJefaturaD intermedio = new CVacacionesJefaturaD(contexto);
                CFuncionarioL intermedioFuncionario = new CFuncionarioL();

                CVacacionesJefaturaDTO jefatura = new CVacacionesJefaturaDTO();

                var datos = intermedio.ListarJefatura(cedula);

                if (datos.Codigo > 0)
                {
                    respuesta= (CVacacionesJefaturaDTO)datos.Contenido;
                    
                    return respuesta;
                }
                else
                {
                    throw new Exception("Ocurrió un error inesperado en la consulta");
                }
            }
            catch (Exception error)
            {
                respuesta=(new CErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }

        public List<CBaseDTO> ListarFuncionarios(string cedulaFuncionario, string cedulaJefe, string cedulaJefeSuperior, int idSeccion, int idDireccion, int idDivision)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                //CFuncionarioD intermedio = new CFuncionarioD(contexto);
                CVacacionesJefaturaD intermedio = new CVacacionesJefaturaD(contexto);
                //var datos = intermedio.ListarFuncionariosJefatura(idPeriodo, cedula);
                var datos = intermedio.ListarFuncionarios();
                if (datos.Codigo > 0)
                {
                    var listado = (List<CVacacionesJefaturaDTO>)datos.Contenido;

                    if (cedulaFuncionario != "")
                        listado = listado.Where(Q => Q.Funcionario.Cedula == cedulaFuncionario).ToList();

                    if (cedulaJefe != "")
                        listado = listado.Where(Q => Q.JefeInmediato.Cedula == cedulaJefe).ToList();

                    if (cedulaJefeSuperior != "")
                        listado = listado.Where(Q => Q.JefeSuperior.Cedula == cedulaJefeSuperior).ToList();

                    //if (idSeccion > 0)
                    //    listado = listado.Where(Q => Q.FK_Seccion == idSeccion).ToList();

                    //if (idDireccion > 0)
                    //    listado = listado.Where(Q => Q.FK_DireccionGeneral == idDireccion).ToList();

                    //if (idDivision > 0)
                    //    listado = listado.Where(Q => Q.FK_Division == idDivision).ToList();

                    foreach (var item in listado)
                    {
                        respuesta.Add(item);
                    }

                    return respuesta;
                }
                else
                {
                    throw new Exception("Ocurrió un error inesperado en la consulta");
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }

        #endregion
    }
}
