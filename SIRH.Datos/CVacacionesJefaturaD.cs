using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;
using SIRH.Datos.Helpers;


namespace SIRH.Datos
{
    public class CVacacionesJefaturaD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion
        
        #region Constructor

        public CVacacionesJefaturaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos
        
        //revisar con Orlando
        public CRespuestaDTO AsignarVacacionesJefatura(int codFuncionario, int codJefeInmediato)
        {
            CRespuestaDTO respuesta;
            int idJefeSuperior = 0;

            try
            {
                var datosVacacionesJefatura = entidadBase.VacacionesJefatura.FirstOrDefault(Q => Q.FkFuncionario == codFuncionario);

                if (datosVacacionesJefatura != null)
                {
                    if (codJefeInmediato > 0)
                    {
                        var datoJefeInmediato = entidadBase.VacacionesJefatura.FirstOrDefault(Q => Q.FkFuncionario == codJefeInmediato);

                        if (datoJefeInmediato != null)
                            idJefeSuperior = datoJefeInmediato.idJefeInmediato;
                    }

                    datosVacacionesJefatura.idJefeInmediato = codJefeInmediato;
                    datosVacacionesJefatura.idJefeSuperior = idJefeSuperior;
                    entidadBase.SaveChanges();

                    var listado = entidadBase.VacacionesJefatura.Where(Q => Q.FkFuncionario == codFuncionario).ToList();

                    if (listado != null && listado.Count > 0)
                    {
                        foreach (var funcionario in listado)
                        {
                            funcionario.idJefeInmediato = codJefeInmediato;
                        }
                        entidadBase.SaveChanges();
                    }

                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datosVacacionesJefatura
                    };

                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontraron datos del Funcionario.");
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { Mensaje = error.Message }
                };

                return respuesta;
            }
        }

        public CRespuestaDTO ListarJefatura(string cedula)
        {
            try
            {
                var datos = (from VJ in entidadBase.VacacionesJefatura
                             join F in entidadBase.Funcionario on VJ.FkFuncionario equals F.PK_Funcionario
                             join FJI in entidadBase.Funcionario on VJ.idJefeInmediato equals FJI.PK_Funcionario into gJI
                             join FJS in entidadBase.Funcionario on VJ.idJefeSuperior equals FJS.PK_Funcionario into gJS
                             from JI in gJI.DefaultIfEmpty()
                             from JS in gJS.DefaultIfEmpty()
                             where F.IdCedulaFuncionario.Contains(cedula)
                             select new CVacacionesJefaturaDTO
                             {
                                 Funcionario= new CFuncionarioDTO
                                 {
                                     IdEntidad = F.PK_Funcionario,
                                     Cedula = F.IdCedulaFuncionario,
                                     Nombre =  F.NomFuncionario.TrimEnd(),
                                     PrimerApellido = F.NomSegundoApellido.TrimEnd(),
                                     SegundoApellido = F.NomSegundoApellido.TrimEnd(),
                                     Mensaje = F.NomFuncionario.TrimEnd() + " " + F.NomPrimerApellido.TrimEnd() + " " + F.NomSegundoApellido.TrimEnd(),
                                     Sexo = GeneroEnum.Indefinido
                                 },
                                 JefeInmediato = new CFuncionarioDTO
                                 {
                                     IdEntidad = (JI == null ? 0 : JI.PK_Funcionario),
                                     Cedula = (JI == null ? "" : JI.IdCedulaFuncionario),
                                     Nombre = (JI == null ? "" : JI.NomFuncionario.TrimEnd()),
                                     PrimerApellido = (JI == null ? "" : JI.NomSegundoApellido.TrimEnd()),
                                     SegundoApellido = (JI == null ? "" : JI.NomSegundoApellido.TrimEnd()),
                                     Mensaje = (JI == null ? "-" : JI.NomFuncionario.TrimEnd() + " " + JI.NomPrimerApellido.TrimEnd() + " " + JI.NomSegundoApellido.TrimEnd()),
                                     Sexo = GeneroEnum.Indefinido
                                 },
                                 JefeSuperior = new CFuncionarioDTO
                                 {
                                     IdEntidad = (JS == null ? 0 : JS.PK_Funcionario),
                                     Cedula = (JS == null ? "" : JS.IdCedulaFuncionario),
                                     Nombre = (JS == null ? "" : JS.NomFuncionario.TrimEnd()),
                                     PrimerApellido = (JS == null ? "" : JS.NomSegundoApellido.TrimEnd()),
                                     SegundoApellido = (JS == null ? "" : JS.NomSegundoApellido.TrimEnd()),
                                     Mensaje = (JS == null ? "-" : JS.NomFuncionario.TrimEnd() + " " + JS.NomPrimerApellido.TrimEnd() + " " + JS.NomSegundoApellido.TrimEnd()),
                                     Sexo = GeneroEnum.Indefinido
                                 }
                             }).FirstOrDefault();

                if (datos != null)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datos
                    };
                }
                else
                {
                    throw new Exception("Ocurrió un error al descargar los datos de los funcionarios");
                }
            }
            catch (Exception error)
            {
                return new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
            }
        }

        public CRespuestaDTO ListarFuncionarios()
        {
            try
            {
                var datos = (from VJ in entidadBase.VacacionesJefatura
                             join F in entidadBase.Funcionario on VJ.FkFuncionario equals F.PK_Funcionario
                             join FJI in entidadBase.Funcionario on VJ.idJefeInmediato equals FJI.PK_Funcionario into gJI
                             join FJS in entidadBase.Funcionario on VJ.idJefeSuperior equals FJS.PK_Funcionario into gJS
                             from JI in gJI.DefaultIfEmpty()
                             from JS in gJS.DefaultIfEmpty()

                             select new CVacacionesJefaturaDTO
                             {
                                 Funcionario = new CFuncionarioDTO
                                 {
                                     IdEntidad = F.PK_Funcionario,
                                     Cedula = F.IdCedulaFuncionario,
                                     Nombre = F.NomFuncionario.TrimEnd(),
                                     PrimerApellido = F.NomSegundoApellido.TrimEnd(),
                                     SegundoApellido = F.NomSegundoApellido.TrimEnd(),
                                     Mensaje = F.NomFuncionario.TrimEnd() + " " + F.NomPrimerApellido.TrimEnd() + " " + F.NomSegundoApellido.TrimEnd(),
                                     Sexo = GeneroEnum.Indefinido
                                 },
                                 JefeInmediato = new CFuncionarioDTO
                                 {
                                     IdEntidad = (JI == null ? 0 : JI.PK_Funcionario),
                                     Cedula = (JI == null ? "" : JI.IdCedulaFuncionario),
                                     Nombre = (JI == null ? "" : JI.NomFuncionario.TrimEnd()),
                                     PrimerApellido = (JI == null ? "" : JI.NomSegundoApellido.TrimEnd()),
                                     SegundoApellido = (JI == null ? "" : JI.NomSegundoApellido.TrimEnd()),
                                     Mensaje = (JI == null ? "-" : JI.NomFuncionario.TrimEnd() + " " + JI.NomPrimerApellido.TrimEnd() + " " + JI.NomSegundoApellido.TrimEnd()),
                                     Sexo = GeneroEnum.Indefinido
                                 },
                                 JefeSuperior = new CFuncionarioDTO
                                 {
                                     IdEntidad = (JS == null ? 0 : JS.PK_Funcionario),
                                     Cedula = (JS == null ? "" : JS.IdCedulaFuncionario),
                                     Nombre = (JS == null ? "" : JS.NomFuncionario.TrimEnd()),
                                     PrimerApellido = (JS == null ? "" : JS.NomSegundoApellido.TrimEnd()),
                                     SegundoApellido = (JS == null ? "" : JS.NomSegundoApellido.TrimEnd()),
                                     Mensaje = (JS == null ? "-" : JS.NomFuncionario.TrimEnd() + " " + JS.NomPrimerApellido.TrimEnd() + " " + JS.NomSegundoApellido.TrimEnd()),
                                     Sexo = GeneroEnum.Indefinido
                                 }
                             }).ToList();
                if (datos != null)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datos
                    };
                }
                else
                {
                    throw new Exception("Ocurrió un error al descargar los datos de los funcionarios");
                }
            }
            catch (Exception error)
            {
                return new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
            }
        }

        #endregion
    }
}