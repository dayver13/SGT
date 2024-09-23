using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;
using SIRH.Datos.Helpers;

namespace SIRH.Datos
{
    public class CIncidenciaD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CIncidenciaD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public CRespuestaDTO AgregarIncidencia(Funcionario funcionario, Incidencia incidencia)
        {
            CRespuestaDTO respuesta;
            try
            {
                funcionario = entidadBase.Funcionario.Where(F => F.IdCedulaFuncionario == funcionario.IdCedulaFuncionario).FirstOrDefault();

                if (funcionario != null)
                {
                    BitacoraIncidencia logBitacora = new BitacoraIncidencia
                    {
                        EstSolicitud = incidencia.EstIncidencia,
                        FecEjecucion = DateTime.Now,
                        Funcionario = funcionario,
                        Incidencia = incidencia
                    };

                    incidencia.FK_CatalogoIncidencia = incidencia.CatalogoIncidencia.PK_CatalogoIncidencia;
                    incidencia.FK_FuncionarioEmisor = funcionario.PK_Funcionario;
                    incidencia.Funcionario = funcionario;
                    incidencia.EstIncidencia = 1;
                    incidencia.IndImpacto = 4;
                    entidadBase.Incidencia.Add(incidencia);
                    entidadBase.BitacoraIncidencia.Add(logBitacora);
                    entidadBase.SaveChanges();

                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = incidencia.PK_Incidencia
                    };
                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontró el funcionario indicado");
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

        public CRespuestaDTO BuscarIncidencias(List<Incidencia> datosPrevios, object parametro, string elemento, int flag)
        {
            CRespuestaDTO respuesta;

            try
            {
                datosPrevios = CargarDatos(elemento, datosPrevios, parametro, flag);
                respuesta = new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = datosPrevios
                };
                return respuesta;
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

        public CRespuestaDTO CargarUsuarioEmisor(Funcionario funcionario)
        {
            CRespuestaDTO respuesta;
            try
            {
                var resultado = entidadBase.Usuario.Include("DetalleAcceso").
                                            Include("DetalleAcceso.Funcionario").
                                            Include("DetalleAcceso.Usuario").
                                            Where(U => U.DetalleAcceso.Where(D => D.Funcionario.PK_Funcionario == funcionario.PK_Funcionario).Count() > 0).FirstOrDefault();
                if (resultado != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontró el usuario del funcionario con el parámetro que se estableció.");
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
                return respuesta;
            }
        }

        public CRespuestaDTO CagarPerfilesCoordinacion(CatalogoIncidencia catalogo)
        {
            CRespuestaDTO respuesta;
            try
            {

                var resultado = entidadBase.Usuario.Where(U => U.DetalleAcceso.Where(D => D.PerfilAcceso.
                                                   Where(P => P.CatPermiso.Perfil.CatalogoIncidencia.
                                                   Where(CI => CI.PK_CatalogoIncidencia == catalogo.PK_CatalogoIncidencia).Count() > 0 && 
                                                   P.CatPermiso.NomPermiso == "Administrador").Count() > 0).Count() > 0).ToList();

                if (resultado != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontraron usuarios coordinadores del módulo con el parámetro que se estableció.");
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
                return respuesta;
            }
        }

        private List<Incidencia> CargarDatos(string elemento, List<Incidencia> datosPrevios, object parametro, int searchFlag)
        {
            string param = "";
            DateTime paramFechaInicio = new DateTime();
            DateTime paramFechaFinal = new DateTime();

            if (parametro.GetType().Name.Equals("String"))
            {
                param = parametro.ToString();
            }
            else
            {
                paramFechaInicio = ((List<DateTime>)parametro).ElementAt(0);
                paramFechaFinal = ((List<DateTime>)parametro).ElementAt(1).AddDays(1);
            }

            if (searchFlag > 0)
            {
                switch (elemento)
                {
                    case "NombreUsuario":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario.IdCedulaFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "FechaInicio":
                        datosPrevios = datosPrevios.Where(I => I.FecInicio >= paramFechaInicio && I.FecInicio <= paramFechaFinal).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "FechaFin":
                        datosPrevios = datosPrevios.Where(C => C.FecFin >= paramFechaInicio &&
                                                        C.FecFin <= paramFechaFinal).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "CedulaEmisor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario.IdCedulaFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "NombreEmisor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario.NomFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "PrimerApellidoEmisor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario.NomPrimerApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "SegundoApellidoEmisor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario.NomSegundoApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "CedulaReceptor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario1.IdCedulaFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "NombreReceptor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario1.NomFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "PrimerApellidoReceptor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario1.NomPrimerApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "SegundoApellidoReceptor":
                        datosPrevios = datosPrevios.Where(I => I.Funcionario1.NomSegundoApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "Prioridad":

                        int param2 = 0;
                        switch (param)
                        {
                            case "Alta":
                                param2 = 1;
                                break;
                            case "Media":
                                param2 = 2;
                                break;
                            case "Baja":
                                param2 = 3;
                                break;
                            default:
                                break;
                        }
                        datosPrevios = datosPrevios.Where(I => I.CatalogoIncidencia.Prioridad == param2).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "EstIncidencia":

                        int param1 = 0;
                        switch (param)
                        {
                            case "Registrada":
                                param1 = 1;
                                break;
                            case "En Revision":
                                param1 = 2;
                                break;
                            case "Resuelta":
                                param1 = 3;
                                break;
                            case "Re-abierta":
                                param1 = 4;
                                break;
                            case "Rechazada":
                                param1 = 5;
                                break;
                            default:
                                break;
                        }
                        datosPrevios = datosPrevios.Where(I => I.EstIncidencia == param1).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "Catalogo":
                        datosPrevios = datosPrevios.Where(I => I.CatalogoIncidencia.Nombre == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    default:
                        datosPrevios = new List<Incidencia>();
                        break;
                }
            }
            else
            {
                switch (elemento)
                {
                    case "NombreUsuario":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario.IdCedulaFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "FechaInicio":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.FecInicio >= paramFechaInicio && I.FecInicio <= paramFechaFinal).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "FechaFin":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.FecFin >= paramFechaInicio && I.FecFin <= paramFechaFinal).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "CedulaEmisor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario.IdCedulaFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "NombreEmisor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario.NomFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM=>IM.IndImpacto).ToList();
                        break;
                    case "PrimerApellidoEmisor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario.NomPrimerApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "SegundoApellidoEmisor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario.NomSegundoApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "CedulaReceptor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario1.IdCedulaFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "NombreReceptor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario1.NomFuncionario == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "PrimerApellidoReceptor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario1.NomPrimerApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "SegundoApellidoReceptor":
                        datosPrevios = entidadBase.Incidencia.Where(I => I.Funcionario1.NomSegundoApellido == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "Prioridad":

                        int param2 = 0;
                        switch (param)
                        {
                            case "Alta":
                                param2 = 1;
                                break;
                            case "Media":
                                param2 = 2;
                                break;
                            case "Baja":
                                param2 = 3;
                                break;
                            default:
                                break;
                        }
                        datosPrevios = entidadBase.Incidencia.Where(I => I.CatalogoIncidencia.Prioridad == param2).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;

                    case "EstIncidencia":

                        int param1 = 0;
                        switch (param)
                        {
                            case "Registrada":
                                param1 = 1;
                                break;
                            case "En revisión":
                                param1 = 2;
                                break;
                            case "Resuelta":
                                param1 = 3;
                                break;
                            case "Reabierta":
                                param1 = 4;
                                break;
                            case "Rechazada":
                                param1 = 5;
                                break;
                            default:
                                break;
                        }
                        datosPrevios = entidadBase.Incidencia.Where(I => I.EstIncidencia == param1).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    case "Catalogo":
                        datosPrevios = entidadBase.Incidencia.Include("CatalogoIncidencia").Where(I => I.CatalogoIncidencia.Nombre == param).OrderBy(J => J.EstIncidencia).ThenBy(I => I.CatalogoIncidencia.Prioridad).ThenBy(IM => IM.IndImpacto).ToList();
                        break;
                    default:
                        datosPrevios = new List<Incidencia>();
                        break;
                }
            }
            return datosPrevios;
        }

        public CRespuestaDTO ObtenerIncidencia(int codigo)
        {
            CRespuestaDTO respuesta;

            try
            {
                var incidencia = entidadBase.Incidencia.Include("Funcionario")
                                                         .Include("CatalogoIncidencia")
                                                         .Include("CatalogoIncidencia.Perfil").FirstOrDefault(I => I.PK_Incidencia == codigo);

                if (incidencia != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = incidencia
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ninguna incidencia." }
                    };
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
                return respuesta;
            }
        }

        public CRespuestaDTO ListarPerfiles()
        {
            CRespuestaDTO respuesta;

            try
            {
                var datosEntidad = entidadBase.Perfil.ToList();

                if (datosEntidad != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datosEntidad
                    };
                    return respuesta;
                }
                else
                {
                    throw new Exception("No se encontraron perfiles");
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO

                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };

                return respuesta;
            }
        }

        public CRespuestaDTO ActualizarEstado(Incidencia actual)
        {
            CRespuestaDTO respuesta;

            try
            {
                var incidenciaOld = entidadBase.Incidencia.Where(I => I.PK_Incidencia == actual.PK_Incidencia).FirstOrDefault();
                var funcionario = new Funcionario();


                if (actual.Funcionario1 != null)
                {
                   funcionario = entidadBase.Funcionario.Where(F => F.IdCedulaFuncionario == actual.Funcionario1.IdCedulaFuncionario).FirstOrDefault();

                    BitacoraIncidencia logBitacora = new BitacoraIncidencia
                    {
                        EstSolicitud = incidenciaOld.EstIncidencia,
                        FecEjecucion = DateTime.Now,
                        Funcionario = funcionario,
                        Incidencia = incidenciaOld
                    };
                    entidadBase.BitacoraIncidencia.Add(logBitacora);

                }
                
                if (incidenciaOld != null)
                {
                    incidenciaOld.EstIncidencia = actual.EstIncidencia;
                    incidenciaOld.FecFin = actual.FecFin;
                    incidenciaOld.DesJustificacion = actual.DesJustificacion;
                    incidenciaOld.FK_FuncionarioUIRH = funcionario.PK_Funcionario;

                    entidadBase.SaveChanges();

                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = incidenciaOld.PK_Incidencia
                    };

                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { Mensaje = "No se encontró ninguna incidencia con código especificado." }
                    };
                    return respuesta;
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

        public CRespuestaDTO ActualizarImpacto(Incidencia actual)
        {
            CRespuestaDTO respuesta;

            try
            {
                var incidenciaOld = entidadBase.Incidencia.Where(I => I.PK_Incidencia == actual.PK_Incidencia).FirstOrDefault();
                var funcionario = new Funcionario();


                if (actual.Funcionario1 != null)
                {
                    funcionario = entidadBase.Funcionario.Where(F => F.IdCedulaFuncionario == actual.Funcionario1.IdCedulaFuncionario).FirstOrDefault();

                }

                if (incidenciaOld != null)
                {
                    incidenciaOld.IndImpacto = actual.IndImpacto;
                    entidadBase.SaveChanges();

                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = incidenciaOld.PK_Incidencia
                    };

                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { Mensaje = "No se encontró ninguna incidencia con código especificado." }
                    };
                    return respuesta;
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

         public CRespuestaDTO ActualizarImpactoD()
        {
            CRespuestaDTO respuesta;
            try
            {

                List<Incidencia> datos = entidadBase.Incidencia.Where(I => I.EstIncidencia == 2).ToList();


                if (datos != null)
                {
                    foreach (var item in datos)
                    {

                        if (item.IndImpacto != 4)
                        {
                            switch (item.IndImpacto)
                            {

                                case 2:
                                    item.IndImpacto = 1;
                                    break;
                                case 3:
                                    item.IndImpacto = 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    entidadBase.SaveChanges();

                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = 1
                    };

                    return respuesta;

                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { Mensaje = "No se encontró ninguna incidencia con código especificado." }
                    };
                    return respuesta;
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

        public CRespuestaDTO AgregarAccion(BotAccionIncidencia accion)
        {
            CRespuestaDTO respuesta;
            try
            {
                accion.FK_CatalogoIncidencia = accion.CatalogoIncidencia.PK_CatalogoIncidencia;
                entidadBase.BotAccionIncidencia.Add(accion);
                entidadBase.SaveChanges();

                respuesta = new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = accion.PK_BotAccionIncidencia
                };
                return respuesta;
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

        public CRespuestaDTO ObtenerAccion(int codigo)
        {
            CRespuestaDTO respuesta;

            try
            {
                var accion = entidadBase.BotAccionIncidencia.Include("CatalogoIncidencia")
                                                         .Include("CatalogoIncidencia.Perfil").FirstOrDefault(B => B.PK_BotAccionIncidencia == codigo);

                if (accion != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = accion
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ninguna acción." }
                    };
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
                return respuesta;
            }
        }

        public CRespuestaDTO ListarAcciones(int modulo)
        {
            CRespuestaDTO respuesta;

            try
            {
                var accion = entidadBase.BotAccionIncidencia.Include("CatalogoIncidencia")
                                                         .Include("CatalogoIncidencia.Perfil").Where(B => B.CatalogoIncidencia.PK_CatalogoIncidencia == modulo).ToList();

                if (accion != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = accion
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { MensajeError = "No se encontró ninguna acción." }
                    };
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
                return respuesta;
            }
        }

        #endregion
    }
}