using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;
using SIRH.Datos;

namespace SIRH.Logica
{
    public class CAprobacionVacacionesL
    {
        #region Variables

        SIRHEntities contexto;

        #endregion

        #region Constructor

        public CAprobacionVacacionesL()
        {
            contexto = new SIRHEntities();
        }

        #endregion


        #region Metodos
        internal static CAprobacionVacacionesDTO ConvertirDatosAprobacionVacacionesADTO(AprobacionVacaciones item)
        {
            return new CAprobacionVacacionesDTO
            {
                IdEntidad = item.PK_AprobacionVacaciones,
                Funcionario = CFuncionarioL.ConvertirDatosFuncionarioADTO(item.Funcionario),
                IdAprobar = item.IdAprobar          
            };
        }

        public List<CBaseDTO> ObtenerPermisosAprobacion(string cedulaConPermiso, string cedulaParaAprobar)
        {

            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CAprobacionVacacionesD intermedio = new CAprobacionVacacionesD(contexto);
                var reintegro = intermedio.ObtenerPermisosAprobacion( cedulaConPermiso,  cedulaParaAprobar);

                if (reintegro.Codigo != -1)
                {


                    var lista = ((List<AprobacionVacaciones>)reintegro.Contenido);

                    if (lista != null)
                    {
                        foreach (var item in lista)
                        {
                            var dato = ConvertirDatosAprobacionVacacionesADTO(item);
                            respuesta.Add(dato);
                        }

                    }

                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)reintegro.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                respuesta = new List<CBaseDTO>();
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message,
                    Mensaje = error.Message
                });
                return respuesta;
            }
        }

        public CBaseDTO AgregarPermisosAprobacion(string FK_funcionario, string idAprobar)
        {
            CBaseDTO respuesta = new CBaseDTO();
            CRespuestaDTO resultado = new CRespuestaDTO();
            int idAprobarN;
            try
            {
                CAprobacionVacacionesD intermedio = new CAprobacionVacacionesD(contexto);
                CDivisionL intermedioDivision = new CDivisionL();
                CFuncionarioL intermedioFuncionario = new CFuncionarioL();
         

             
                var datosFuncionario = intermedioFuncionario.DescargarFuncionario(FK_funcionario);

                var esNumero = int.TryParse(idAprobar, out idAprobarN);

                if (esNumero == true)
                {
                    resultado = intermedio.AgregarPermisosAprobacion(datosFuncionario.IdEntidad, idAprobar);
                   
                }
                else
                {
                    var idDivision = intermedioDivision.ObtenerDivisionPorNombre(idAprobar);
                    foreach (var item in idDivision)
                    {
                        resultado = intermedio.AgregarPermisosAprobacion(datosFuncionario.IdEntidad, Convert.ToString(item.IdEntidad));
                    }
                }
              



                if (resultado.Codigo > 0)
                {
                    respuesta = new CAprobacionVacacionesDTO { IdEntidad = Convert.ToInt32(resultado.Contenido) };
                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                respuesta = new CErrorDTO { MensajeError = error.Message };
                return respuesta;
            }
        }
        #endregion
    }
}
