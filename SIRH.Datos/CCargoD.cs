using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;

namespace SIRH.Datos
{
    public class CCargoD
    {
        #region Variables

        SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CCargoD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Metodos

        public CRespuestaDTO RegistrarCargo(Cargo cargo)
        {
            try
            {
                entidadBase.Cargo.Add(cargo);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = cargo
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ActualizarDescripcionCargo(CCargoDTO cargo)
        {
            try
            {
                var resultado = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == cargo.IdEntidad);

                if (resultado != null)
                {
                    resultado.NomCargo = cargo.NombreCargo;
                    resultado.DesProcesoTrabajo = cargo.ProcesoTrabajo;
                    resultado.DesProposito = cargo.Proposito;
                    if (cargo.ClaseCargo.IdEntidad != 0)
                    {
                        resultado.IndClase = cargo.ClaseCargo.IdEntidad;
                    }
                    if (cargo.EspecialidadCargo.IdEntidad != 0)
                    {
                        resultado.IndEspecialidad = cargo.EspecialidadCargo.IdEntidad;
                    }
                    resultado.IndJefaturaInmediata = cargo.JefaturaInmediata;
                    resultado.IndJefaturaSuperiorInmediata = cargo.JefaturaSuperiorInmediata;
                    if (cargo.SeccionCargo.IdEntidad != 0)
                    {
                        resultado.IndSeccion = cargo.SeccionCargo.IdEntidad;
                    }
                    if (cargo.SubespecialidadCargo.IdEntidad != 0)
                    {
                        resultado.IndSubespecialidad = cargo.SubespecialidadCargo.IdEntidad;
                    }

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("El cargo indicado no existe o no se pudo encontrar");
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

        public CRespuestaDTO ObtenerCargoPorCodigo(int codigo)
        {
            try
            {
                var resultado = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == codigo);

                if (resultado != null)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO RegistrarResultados(ResultadoCargo resultado)
        {
            try
            {
                entidadBase.ResultadoCargo.Add(resultado);
                if(entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO RegistrarActividadAdicionalResultado(int idResultado, ActividadResultadoCargo actividad)
        {
            try
            {
                var resultado = entidadBase.ResultadoCargo.FirstOrDefault(Q => Q.PK_ResultadoCargo == idResultado);
                resultado.ActividadResultadoCargo.Add(actividad);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ObtenerResultadosCargo(int codigo)
        {
            try
            {
                var resultado = entidadBase.ResultadoCargo.Include("ActividadResultadoCargo").Include("Cargo").Where(C => C.FK_Cargo == codigo).ToList();

                if (resultado.Count > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún resultado relacionado");
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

        public CRespuestaDTO EliminarResultadoCargo(int codigo)
        {
            try
            {
                var resultado = entidadBase.ResultadoCargo.FirstOrDefault(C => C.PK_ResultadoCargo == codigo);
                int cargo = Convert.ToInt32(resultado.FK_Cargo);

                if (resultado != null)
                {
                    foreach (var item in entidadBase.ActividadResultadoCargo.Where(C => C.FK_ResultadoCargo == codigo))
                    {
                        entidadBase.ActividadResultadoCargo.Remove(item);
                    }

                    entidadBase.ResultadoCargo.Remove(resultado);

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = ObtenerResultadosCargo(cargo)
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO EliminarActividadResultadoCargo(int codigo)
        {
            try
            {
                var resultado = entidadBase.ActividadResultadoCargo.FirstOrDefault(C => C.PK_ActividadResultadoCargo == codigo);
                int cargo = Convert.ToInt32(resultado.ResultadoCargo.Cargo.PK_Cargo);

                if (resultado != null)
                {
                    entidadBase.ActividadResultadoCargo.Remove(resultado);

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = ObtenerResultadosCargo(cargo)
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO RegistrarFactorCargo(FactorClasificacionCargo factor)
        {
            try
            {
                entidadBase.FactorClasificacionCargo.Add(factor);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == factor.FK_Cargo)
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ActualizarFactoresCargo(CFactorClasificacionCargoDTO factor)
        {
            try
            {
                var resultado = entidadBase.FactorClasificacionCargo.Include("Cargo").FirstOrDefault(C => C.PK_FactorClasificacion == factor.IdEntidad);

                if (resultado != null)
                {
                    resultado.DesActivosEquiposInsumos = factor.ActivosEquiposInsumos;
                    resultado.DesAmbiente = factor.Ambiente;
                    resultado.DesCondiciones = factor.Condiciones;
                    resultado.DesImpactoGestion = factor.ImpactoGestion;
                    resultado.DesIndependencia = factor.Independencia;
                    resultado.DesLugares = factor.Lugares;
                    resultado.DesModalidadTrabajo = factor.ModalidadTrabajo;
                    resultado.DesRelacionesTrabajo = factor.RelacionesTrabajo;
                    resultado.DesSupervisionEjercida = factor.SupervisionEjercida;

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado.Cargo
                    };
                }
                else
                {
                    throw new Exception("El factor indicado no existe o no se pudo encontrar");
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

        public CRespuestaDTO ObtenerFactoresCargo(int codigo)
        {
            try
            {
                var resultado = entidadBase.FactorClasificacionCargo.Include("Cargo").FirstOrDefault(C => C.FK_Cargo == codigo);

                if (resultado != null)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún factor relacionado");
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

        public CRespuestaDTO RegistrarRequerimientosEspecificos(RequerimientoEspecificoCargo requerimiento)
        {
            try
            {
                entidadBase.RequerimientoEspecificoCargo.Add(requerimiento);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == requerimiento.FK_Cargo)
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ObtenerRequerimientosEspecificos(int codigo)
        {
            try
            {
                var resultado = entidadBase.RequerimientoEspecificoCargo.Include("Cargo").FirstOrDefault(C => C.FK_Cargo == codigo);

                if (resultado != null)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún requerimiento específico relacionado");
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

        public CRespuestaDTO ActualizarRequerimientoEspecifico(CRequerimientoEspecificoCargoDTO requerimiento)
        {
            try
            {
                var resultado = entidadBase.RequerimientoEspecificoCargo.Include("Cargo").FirstOrDefault(C => C.PK_RequerimientoEspecificoCargo == requerimiento.IdEntidad);

                if (resultado != null)
                {
                    resultado.DesConocimientos = requerimiento.Conocimientos;
                    resultado.DesRequisitosEspecificos = requerimiento.RequisitosEspecificos;
                    resultado.DesHabilidades = requerimiento.Habilidades;
                    resultado.DesConocimientosDeseables = requerimiento.ConocimientosDeseables;

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado.Cargo
                    };
                }
                else
                {
                    throw new Exception("El requerimiento indicado no existe o no se pudo encontrar");
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

        public CRespuestaDTO RegistrarCompetenciaTransversal(CompetenciaTransversalCargo competenciaTransversal)
        {
            try
            {
                entidadBase.CompetenciaTransversalCargo.Add(competenciaTransversal);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == competenciaTransversal.FK_Cargo)
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ObtenerCompetenciaTransversal(int codigo)
        {
            try
            {
                var resultado = entidadBase.CompetenciaTransversalCargo.Include("ComportamientoTransversal")
                                                                       .Include("ComportamientoTransversal.EvidenciaComportamientoTransversal")
                                                                       .Include("Cargo").Where(C => C.FK_Cargo == codigo).ToList();

                if (resultado.Count > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("No se encontró ninguna competencia relacionada");
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

        public CRespuestaDTO EliminarCompetenciaTransversal(int codigo)
        {
            try
            {
                var resultado = entidadBase.CompetenciaTransversalCargo.Where(C => C.FK_Cargo == codigo);
                int cargo = Convert.ToInt32(resultado.FirstOrDefault().FK_Cargo);

                if (resultado.Count() > 0)
                {
                    foreach (var dato in entidadBase.CompetenciaTransversalCargo.Where(C => C.FK_Cargo == codigo))
                    {
                        foreach (var item in entidadBase.ComportamientoTransversal.Where(C => C.FK_CompetenciaTransversalCargo == dato.PK_CompetenciaTransversalCargo))
                        {
                            foreach (var evidencia in entidadBase.EvidenciaComportamientoTransversal.Where(C => C.FK_ComportamientoTransversal == item.PK_ComportamientoTransversal))
                            {
                                entidadBase.EvidenciaComportamientoTransversal.Remove(evidencia);
                            }
                            entidadBase.ComportamientoTransversal.Remove(item);
                        }

                        entidadBase.CompetenciaTransversalCargo.Remove(dato);
                    }

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = ObtenerResultadosCargo(cargo)
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO RegistrarCompetenciaGrupoOcupacional(CompetenciaGrupoOcupacional competenciaGrupoOcupacional)
        {
            try
            {
                entidadBase.CompetenciaGrupoOcupacional.Add(competenciaGrupoOcupacional);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == competenciaGrupoOcupacional.FK_Cargo)
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ObtenerCompetenciaGrupo(int codigo)
        {
            try
            {
                var resultado = entidadBase.CompetenciaGrupoOcupacional.Include("ComportamientoGrupoOcupacional")
                                                                       .Include("ComportamientoGrupoOcupacional.EvidenciaGrupoOcupacional")
                                                                       .Include("Cargo").Where(C => C.FK_Cargo == codigo).ToList();

                if (resultado.Count > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    throw new Exception("No se encontró ninguna competencia relacionada");
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

        public CRespuestaDTO EliminarCompetenciaGrupo(int codigo)
        {
            try
            {
                var resultado = entidadBase.CompetenciaGrupoOcupacional.Where(C => C.PK_CompetenciaGrupoOcupacional == codigo);
                int cargo = Convert.ToInt32(resultado.FirstOrDefault().FK_Cargo);

                if (resultado.Count() > 0)
                {
                    foreach (var dato in entidadBase.CompetenciaGrupoOcupacional.Where(C => C.PK_CompetenciaGrupoOcupacional == codigo))
                    {
                        foreach (var item in entidadBase.ComportamientoGrupoOcupacional.Where(C => C.FK_CompetenciaGrupoOcupacional == dato.PK_CompetenciaGrupoOcupacional))
                        {
                            foreach (var evidencia in entidadBase.EvidenciaGrupoOcupacional.Where(C => C.FK_ComportamientoGrupoOcupacional == item.PK_ComportamientoGrupoOcupacional))
                            {
                                entidadBase.EvidenciaGrupoOcupacional.Remove(evidencia);
                            }
                            entidadBase.ComportamientoGrupoOcupacional.Remove(item);
                        }

                        entidadBase.CompetenciaGrupoOcupacional.Remove(dato);
                    }

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = ObtenerResultadosCargo(cargo)
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO EliminarComportamientoGrupo(int codigo)
        {
            try
            {
                var resultado = entidadBase.ComportamientoGrupoOcupacional.Where(C => C.PK_ComportamientoGrupoOcupacional == codigo);
                int cargo = Convert.ToInt32(resultado.FirstOrDefault().CompetenciaGrupoOcupacional.Cargo.PK_Cargo);

                if (resultado.Count() > 0)
                {
                    foreach (var dato in entidadBase.ComportamientoGrupoOcupacional.Where(C => C.PK_ComportamientoGrupoOcupacional == codigo))
                    {
                        foreach (var item in entidadBase.EvidenciaGrupoOcupacional.Where(C => C.FK_ComportamientoGrupoOcupacional == dato.PK_ComportamientoGrupoOcupacional))
                        {
                            entidadBase.EvidenciaGrupoOcupacional.Remove(item);
                        }

                        entidadBase.ComportamientoGrupoOcupacional.Remove(dato);
                    }

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = ObtenerResultadosCargo(cargo)
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO EliminarEvidenciaGrupo(int codigo)
        {
            try
            {
                var resultado = entidadBase.EvidenciaGrupoOcupacional.FirstOrDefault(C => C.PK_EvidenciaGrupoOcupacional == codigo);
                int cargo = Convert.ToInt32(resultado.ComportamientoGrupoOcupacional.CompetenciaGrupoOcupacional.Cargo.PK_Cargo);

                if (resultado != null)
                {

                    entidadBase.EvidenciaGrupoOcupacional.Remove(resultado);

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = ObtenerResultadosCargo(cargo)
                    };
                }
                else
                {
                    throw new Exception("No se encontró ningún cargo relacionado");
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

        public CRespuestaDTO BuscarDatosCargo(List<Cargo> datosPrevios, object parametro, string elemento)
        {
            CRespuestaDTO respuesta;

            try
            {
                datosPrevios = CargarDatos(elemento, datosPrevios, parametro);
                if (datosPrevios.Count > 0)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = datosPrevios
                    };
                    return respuesta;
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = new CErrorDTO { Mensaje = "No se encontraron resultados para los parámetros de búsqueda establecidos" }
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

        private List<Cargo> CargarDatos(string elemento, List<Cargo> datosPrevios, object parametro)
        {
            string param = "";
            int iparam = 0;

            if (parametro.GetType().Name.Equals("String"))
            {
                param = parametro.ToString();
            }
            else
            {
                iparam = Convert.ToInt32(parametro);
            }

            if (datosPrevios.Count < 1)
            {
                switch (elemento)
                {
                    case "Nombre":
                        datosPrevios = entidadBase.Cargo.Where(C => C.NomCargo.Contains(param)).ToList();
                        break;
                    case "Ubicacion":
                        datosPrevios = entidadBase.Cargo.Where(C => C.DesUbicacionOrganizacional.Contains(param)).ToList();
                        break;
                    case "Proceso":
                        datosPrevios = entidadBase.Cargo.Where(C => C.DesProcesoTrabajo.Contains(param)).ToList();
                        break;
                    case "Estrato":
                        datosPrevios = entidadBase.Cargo.Where(C => C.DesEstrato.Contains(param)).ToList();
                        break;
                    case "Clase":
                        datosPrevios = entidadBase.Cargo.Where(C => C.IndClase == iparam).ToList();
                        break;
                    case "Especialidad":
                        datosPrevios = entidadBase.Cargo.Where(C => C.IndEspecialidad == iparam).ToList();
                        break;
                    case "Subespecialidad":
                        datosPrevios = entidadBase.Cargo.Where(C => C.IndSubespecialidad == iparam).ToList();
                        break;
                    case "Seccion":
                        datosPrevios = entidadBase.Cargo.Where(C => C.IndSeccion == iparam).ToList();
                        break;
                    case "Inmediata":
                        datosPrevios = entidadBase.Cargo.Where(C => C.IndJefaturaInmediata.Contains(param)).ToList();
                        break;
                    case "Superior":
                        datosPrevios = entidadBase.Cargo.Where(C => C.IndJefaturaSuperiorInmediata.Contains(param)).ToList();
                        break;
                    default:
                        datosPrevios = new List<Cargo>();
                        break;
                }
            }
            else
            {
                switch (elemento)
                {
                    case "Nombre":
                        datosPrevios = datosPrevios.Where(C => C.NomCargo.Contains(param)).ToList();
                        break;
                    case "Ubicacion":
                        datosPrevios = datosPrevios.Where(C => C.DesUbicacionOrganizacional.Contains(param)).ToList();
                        break;
                    case "Proceso":
                        datosPrevios = datosPrevios.Where(C => C.DesProcesoTrabajo.Contains(param)).ToList();
                        break;
                    case "Estrato":
                        datosPrevios = datosPrevios.Where(C => C.DesEstrato.Contains(param)).ToList();
                        break;
                    case "Clase":
                        datosPrevios = datosPrevios.Where(C => C.IndClase == iparam).ToList();
                        break;
                    case "Especialidad":
                        datosPrevios = datosPrevios.Where(C => C.IndEspecialidad == iparam).ToList();
                        break;
                    case "Subespecialidad":
                        datosPrevios = datosPrevios.Where(C => C.IndSubespecialidad == iparam).ToList();
                        break;
                    case "Seccion":
                        datosPrevios = datosPrevios.Where(C => C.IndSeccion == iparam).ToList();
                        break;
                    case "Inmediata":
                        datosPrevios = datosPrevios.Where(C => C.IndJefaturaInmediata.Contains(param)).ToList();
                        break;
                    case "Superior":
                        datosPrevios = datosPrevios.Where(C => C.IndJefaturaSuperiorInmediata.Contains(param)).ToList();
                        break;
                    default:
                        datosPrevios = new List<Cargo>();
                        break;
                }
            }

            return datosPrevios;
        }

        public CRespuestaDTO RegistrarComportamientoGrupoOcupacionalAdicional(int competencia, ComportamientoGrupoOcupacional comportamiento)
        {
            try
            {
                var competenciaGrupo = entidadBase.CompetenciaGrupoOcupacional.FirstOrDefault(Q => Q.PK_CompetenciaGrupoOcupacional == competencia);
                competenciaGrupo.ComportamientoGrupoOcupacional.Add(comportamiento);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = competenciaGrupo
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO RegistrarEvidenciaGrupoOcupacionalAdicional(int comportamiento, EvidenciaGrupoOcupacional evidencia)
        {
            try
            {
                var comportamientoGrupo = entidadBase.ComportamientoGrupoOcupacional.FirstOrDefault(Q => Q.PK_ComportamientoGrupoOcupacional == comportamiento);
                comportamientoGrupo.EvidenciaGrupoOcupacional.Add(evidencia);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = comportamientoGrupo
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ActualizarNivelCompetenciaTransversal(int competencia, int nivel)
        {
            try
            {
                var competenciaTransversal = entidadBase.CompetenciaTransversalCargo.FirstOrDefault(Q => Q.PK_CompetenciaTransversalCargo == competencia);
                competenciaTransversal.IntNivelDominio = nivel;
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = competenciaTransversal
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO AgregarComportamientoTransversal(int competencia, ComportamientoTransversal comportamiento)
        {
            try
            {
                var competenciaTransversal = entidadBase.CompetenciaTransversalCargo.FirstOrDefault(Q => Q.PK_CompetenciaTransversalCargo == competencia);
                competenciaTransversal.ComportamientoTransversal.Add(comportamiento);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = competenciaTransversal
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO AgregarEvidenciaTransversal(int comportamiento, EvidenciaComportamientoTransversal evidencia)
        {
            try
            {
                var comportamientoTransversal = entidadBase.ComportamientoTransversal.FirstOrDefault(Q => Q.PK_ComportamientoTransversal == comportamiento);
                comportamientoTransversal.EvidenciaComportamientoTransversal.Add(evidencia);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = comportamientoTransversal
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO EliminarComportamientoTransversal(int codigo)
        {
            try
            {
                var resultado = entidadBase.ComportamientoTransversal.FirstOrDefault(C => C.PK_ComportamientoTransversal == codigo);
                int cargo = Convert.ToInt32(resultado.CompetenciaTransversalCargo.Cargo.PK_Cargo);

                if (resultado != null)
                {
                    foreach (var item in entidadBase.EvidenciaComportamientoTransversal.Where(C => C.FK_ComportamientoTransversal == resultado.PK_ComportamientoTransversal))
                    {
                        entidadBase.EvidenciaComportamientoTransversal.Remove(item);
                    }

                    entidadBase.ComportamientoTransversal.Remove(resultado);

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = cargo
                    };
                }
                else
                {
                    throw new Exception("No se encontró el dato a eliminar");
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

        public CRespuestaDTO EliminarEvidenciaTransversal(int codigo)
        {
            try
            {
                var resultado = entidadBase.EvidenciaComportamientoTransversal.FirstOrDefault(C => C.PK_EvidenciaComportamientoTransversal == codigo);
                int cargo = Convert.ToInt32(resultado.ComportamientoTransversal.CompetenciaTransversalCargo.Cargo.PK_Cargo);

                if (resultado != null)
                {
                    entidadBase.EvidenciaComportamientoTransversal.Remove(resultado);

                    entidadBase.SaveChanges();

                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = cargo
                    };
                }
                else
                {
                    throw new Exception("No se encontró el dato a eliminar");
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

        public CRespuestaDTO RegistrarEstadoCargo(EstadoCargo estado)
        {
            try
            {
                entidadBase.EstadoCargo.Add(estado);
                if (entidadBase.SaveChanges() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = entidadBase.Cargo.FirstOrDefault(C => C.PK_Cargo == estado.FK_Cargo)
                    };
                }
                else
                {
                    throw new Exception("Los cambios no pudieron ser almacenados en la base de datos, por favor, revise la información e inténtelo de nuevo");
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

        public CRespuestaDTO ListarEstadosCargo(int idCargo)
        {
            try
            {
                var estadosCargo = entidadBase.EstadoCargo.Where(Q => Q.FK_Cargo == idCargo).ToList();
                if (estadosCargo.Count() > 0)
                {
                    return new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = estadosCargo
                    };
                }
                else
                {
                    throw new Exception("No se tienen registros de estados para el cargo.");
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
