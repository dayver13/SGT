using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CCargoL
    {
        #region Variables

        SIRHEntities contexto;

        #endregion

        #region Constructor

        public CCargoL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Metodos

        internal static CCargoDTO ConvertirCargoDTOADatos(Cargo input)
        {
            return new CCargoDTO
            {
                IdEntidad = input.PK_Cargo,
                JefaturaInmediata = input.IndJefaturaInmediata,
                JefaturaSuperiorInmediata = input.IndJefaturaSuperiorInmediata,
                NombreCargo = input.NomCargo,
                ProcesoTrabajo = input.DesProcesoTrabajo,
                Proposito = input.DesProposito,
                ClaseCargo = input.IndClase != 0 ? new CClaseDTO { IdEntidad = Convert.ToInt32(input.IndClase) } : null,
                EspecialidadCargo = input.IndEspecialidad != 0 ? new CEspecialidadDTO { IdEntidad = Convert.ToInt32(input.IndEspecialidad) } : null,
                SubespecialidadCargo = input.IndSubespecialidad != 0 ? new CSubEspecialidadDTO { IdEntidad = Convert.ToInt32(input.IndSubespecialidad) } : null,
                SeccionCargo = input.IndSeccion != 0 ? new CSeccionDTO { IdEntidad = Convert.ToInt32(input.IndSeccion) } : null,
                UbicacionOrganizacional = input.DesUbicacionOrganizacional,
                Estrato = input.DesEstrato,
                Poliza = Convert.ToBoolean(input.IndPoliza),
                DeclaracionJurada = Convert.ToBoolean(input.IndDeclaracion)
            };
        }

        internal static CResultadoCargoDTO ConvertirResultadoCargoADTO(ResultadoCargo input)
        {
            return new CResultadoCargoDTO
            {
                IdEntidad = input.PK_ResultadoCargo,
                Cargo = new CCargoDTO { IdEntidad = input.Cargo.PK_Cargo, NombreCargo = input.Cargo.NomCargo },
                ResultadoCargo = input.DesResultadoCargo,
                ActividadesResultado = ConvertirListaActividadesResultado(input.ActividadResultadoCargo.ToList())
            };
        }

        internal static List<CActividadResultadoCargoDTO> ConvertirListaActividadesResultado(List<ActividadResultadoCargo> actividades)
        {
            List<CActividadResultadoCargoDTO> resultado = new List<CActividadResultadoCargoDTO>();

            foreach (var item in actividades)
            {
                resultado.Add(ConvertirActividadResultadoCargoADTO(item));
            }

            return resultado;
        }

        internal static CActividadResultadoCargoDTO ConvertirActividadResultadoCargoADTO(ActividadResultadoCargo input)
        {
            return new CActividadResultadoCargoDTO
            {
                IdEntidad = input.PK_ActividadResultadoCargo,
                ActividadResultadoCargo = input.DesActividadResultadoCargo,
            };
        }

        internal static ActividadResultadoCargo ConvertirActividadResultadoCargoADatos(CActividadResultadoCargoDTO input)
        {
            return new ActividadResultadoCargo
            {
                DesActividadResultadoCargo = input.ActividadResultadoCargo,
            };
        }

        internal static CFactorClasificacionCargoDTO ConvertirFactoresADTO(FactorClasificacionCargo input)
        {
            return new CFactorClasificacionCargoDTO
            {
                IdEntidad = input.PK_FactorClasificacion,
                ActivosEquiposInsumos = input.DesActivosEquiposInsumos,
                Ambiente = input.DesAmbiente,
                Condiciones = input.DesCondiciones,
                Cargo = new CCargoDTO { IdEntidad = input.Cargo.PK_Cargo, NombreCargo = input.Cargo.NomCargo },
                ImpactoGestion = input.DesImpactoGestion,
                Independencia = input.DesIndependencia,
                Lugares = input.DesLugares,
                ModalidadTrabajo = input.DesModalidadTrabajo,
                RelacionesTrabajo = input.DesRelacionesTrabajo,
                SupervisionEjercida = input.DesSupervisionEjercida
            };
        }

        internal static CRequerimientoEspecificoCargoDTO ConvertirRequerimientosEspecificos(RequerimientoEspecificoCargo input)
        {
            return new CRequerimientoEspecificoCargoDTO
            {
                IdEntidad = input.PK_RequerimientoEspecificoCargo,
                Cargo = new CCargoDTO { IdEntidad = input.Cargo.PK_Cargo, NombreCargo = input.Cargo.NomCargo },
                Conocimientos = input.DesConocimientos,
                ConocimientosDeseables = input.DesConocimientosDeseables,
                RequisitosEspecificos = input.DesRequisitosEspecificos,
                Habilidades = input.DesHabilidades
            };
        }

        internal static CCompetenciaTransversalCargoDTO ConvertirCompetenciaTransversal(CompetenciaTransversalCargo input)
        {
            return new CCompetenciaTransversalCargoDTO
            {
                IdEntidad = input.PK_CompetenciaTransversalCargo,
                Cargo = new CCargoDTO { IdEntidad = input.Cargo.PK_Cargo, NombreCargo = input.Cargo.NomCargo },
                NivelDominio = Convert.ToInt32(input.IntNivelDominio),
                TipoCompetencia = Convert.ToInt32(input.IndTipoCompetencia),
                ComportamientosTransversales = ConvertirListaComportamientoTransversal(input.ComportamientoTransversal.ToList())
            };
        }

        internal static List<CComportamientoTransversalDTO> ConvertirListaComportamientoTransversal(List<ComportamientoTransversal> comportamientos)
        {
            List<CComportamientoTransversalDTO> resultado = new List<CComportamientoTransversalDTO>();

            foreach (var item in comportamientos)
            {
                resultado.Add(ConvertirComportamientoTransversal(item));
            }

            return resultado;
        }

        internal static CComportamientoTransversalDTO ConvertirComportamientoTransversal(ComportamientoTransversal input)
        {
            return new CComportamientoTransversalDTO
            {
                IdEntidad = input.PK_ComportamientoTransversal,
                ComportamientoTransversal = input.DesComportamientoTransversal,
                EvidenciasComportamientoTransversal = ConvertirListaEvidenciaComportamientoTransversal(input.EvidenciaComportamientoTransversal.ToList())
            };
        }

        internal static List<CEvidenciaComportamientoTransversalDTO> ConvertirListaEvidenciaComportamientoTransversal(List<EvidenciaComportamientoTransversal> evidencias)
        {
            List<CEvidenciaComportamientoTransversalDTO> resultado = new List<CEvidenciaComportamientoTransversalDTO>();

            foreach (var item in evidencias)
            {
                resultado.Add(ConvertirEvidenciaComportamientoTransversal(item));
            }

            return resultado;
        }

        internal static CEvidenciaComportamientoTransversalDTO ConvertirEvidenciaComportamientoTransversal(EvidenciaComportamientoTransversal input)
        {
            return new CEvidenciaComportamientoTransversalDTO
            {
                IdEntidad = input.PK_EvidenciaComportamientoTransversal,
                Evidencia = input.DesEvidencia,

            };
        }

        internal static CCompetenciaGrupoOcupacionalDTO ConvertirCompetenciaGrupo(CompetenciaGrupoOcupacional input)
        {
            return new CCompetenciaGrupoOcupacionalDTO
            {
                IdEntidad = input.PK_CompetenciaGrupoOcupacional,
                TipoGrupoOcupacional = input.NomCompetencia,
                Nivel = input.IndNivel,
                ComportamientosGrupo = ConvertirListaComportamientosGrupo(input.ComportamientoGrupoOcupacional.ToList()),
                Cargo = new CCargoDTO { IdEntidad = input.Cargo.PK_Cargo, NombreCargo = input.Cargo.NomCargo }
            };
        }

        internal static List<CComportamientoGrupoOcupacionalDTO> ConvertirListaComportamientosGrupo(List<ComportamientoGrupoOcupacional> input)
        {
            List<CComportamientoGrupoOcupacionalDTO> resultado = new List<CComportamientoGrupoOcupacionalDTO>();

            foreach (var item in input)
            {
                resultado.Add(ConvertirComportamientoGrupo(item));
            }

            return resultado;
        }

        internal static CComportamientoGrupoOcupacionalDTO ConvertirComportamientoGrupo(ComportamientoGrupoOcupacional input)
        {
            return new CComportamientoGrupoOcupacionalDTO
            {
                IdEntidad = input.PK_ComportamientoGrupoOcupacional,
                Comportamiento = input.DesComportamiento,
                EvidenciasGrupo = ConvertirListaEvidenciasGrupo(input.EvidenciaGrupoOcupacional.ToList())
            };
        }

        internal static List<CEvidenciaGrupoOcupacionalDTO> ConvertirListaEvidenciasGrupo(List<EvidenciaGrupoOcupacional> input)
        {
            List<CEvidenciaGrupoOcupacionalDTO> resultado = new List<CEvidenciaGrupoOcupacionalDTO>();

            foreach (var item in input)
            {
                resultado.Add(ConvertirEvidenciaGrupo(item));
            }

            return resultado;
        }

        internal static CEvidenciaGrupoOcupacionalDTO ConvertirEvidenciaGrupo(EvidenciaGrupoOcupacional input)
        {
            return new CEvidenciaGrupoOcupacionalDTO
            {
                IdEntidad = input.PK_EvidenciaGrupoOcupacional,
                Evidencia = input.DesEvidencia
            };
        }

        public CBaseDTO RegistrarCargo(CCargoDTO cargo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                CRespuestaDTO resultado = new CRespuestaDTO();

                if (cargo.IdEntidad == 0)
                {
                    Cargo cargoRegistro = new Cargo
                    {
                        DesProcesoTrabajo = cargo.ProcesoTrabajo,
                        DesProposito = cargo.Proposito,
                        IndClase = cargo.ClaseCargo.IdEntidad,
                        IndEspecialidad = cargo.EspecialidadCargo.IdEntidad,
                        IndJefaturaInmediata = cargo.JefaturaInmediata,
                        IndJefaturaSuperiorInmediata = cargo.JefaturaSuperiorInmediata,
                        IndSeccion = cargo.SeccionCargo.IdEntidad,
                        IndSubespecialidad = cargo.SubespecialidadCargo.IdEntidad,
                        NomCargo = cargo.NombreCargo,
                        DesUbicacionOrganizacional = cargo.UbicacionOrganizacional,
                        DesEstrato = cargo.Estrato,
                        IndDeclaracion = cargo.DeclaracionJurada,
                        IndPoliza = cargo.Poliza
                    };

                    resultado = intermedio.RegistrarCargo(cargoRegistro);
                }
                else
                {
                    resultado = intermedio.ActualizarDescripcionCargo(cargo);
                }

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO ObtenerCargoPorCodigo(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ObtenerCargoPorCodigo(codigo);

                if (resultado.Codigo > 0)
                {
                    var datos = ConvertirCargoDTOADatos((Cargo)resultado.Contenido);

                    datos.ClaseCargo = (datos.ClaseCargo != null && datos.ClaseCargo.IdEntidad > 0) ? CClaseL.ConstruirClase(contexto.Clase.FirstOrDefault(C => C.PK_Clase == datos.ClaseCargo.IdEntidad)) : null;
                    datos.EspecialidadCargo = (datos.EspecialidadCargo != null && datos.EspecialidadCargo.IdEntidad > 0) ? CEspecialidadL.ConstruirEspecialidad(contexto.Especialidad.FirstOrDefault(C => C.PK_Especialidad == datos.EspecialidadCargo.IdEntidad)) : null;
                    datos.SubespecialidadCargo = (datos.SubespecialidadCargo != null && datos.SubespecialidadCargo.IdEntidad > 0) ? CSubEspecialidadL.ConvertirSubEspecialidadADTO(contexto.SubEspecialidad.FirstOrDefault(C => C.PK_SubEspecialidad == datos.SubespecialidadCargo.IdEntidad)) : null;
                    datos.SeccionCargo = (datos.SeccionCargo != null && datos.SeccionCargo.IdEntidad > 0) ? CSeccionL.ConvertirSeccionADTO(contexto.Seccion.FirstOrDefault(C => C.PK_Seccion == datos.SeccionCargo.IdEntidad)) : null;

                    return datos;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistroResultadosActividades(List<CResultadoCargoDTO> resultados)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);
                foreach (var resultado in resultados)
                {
                    var resultadoTemp = new ResultadoCargo
                    {
                        FK_Cargo = resultado.Cargo.IdEntidad,
                        DesResultadoCargo = resultado.ResultadoCargo
                    };

                    foreach (var actividad in resultado.ActividadesResultado)
                    {
                        resultadoTemp.ActividadResultadoCargo.Add(new ActividadResultadoCargo
                        {
                            DesActividadResultadoCargo = actividad.ActividadResultadoCargo,
                        });
                    }

                    var respuesta = intermedio.RegistrarResultados(resultadoTemp);

                    if (respuesta.Codigo < 0)
                    {
                        throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                    }
                }

                return resultados.ElementAt(0).Cargo;
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistrarActividadAdicionalResultado(int idResultado, CActividadResultadoCargoDTO actividad)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var respuesta = intermedio.RegistrarActividadAdicionalResultado(idResultado, ConvertirActividadResultadoCargoADatos(actividad));

                if (respuesta.Codigo < 0)
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
                else
                {
                    return ConvertirResultadoCargoADTO(((ResultadoCargo)respuesta.Contenido));
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> ObtenerResultadosCargo(int codigo)
        {
            try
            {
                List<CBaseDTO> resultados = new List<CBaseDTO>();

                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ObtenerResultadosCargo(codigo);

                if (resultado.Codigo > 0)
                {

                    foreach (var item in ((List<ResultadoCargo>)resultado.Contenido))
                    {
                        resultados.Add(ConvertirResultadoCargoADTO(item));
                    }

                    return resultados;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new List<CBaseDTO> { new CErrorDTO { MensajeError = error.Message } };
            }
        }

        public CBaseDTO EliminarResultado(int codigo)
        {
            try
            { 
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.EliminarResultadoCargo(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message};
            }
        }

        public CBaseDTO EliminarActividad(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.EliminarActividadResultadoCargo(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistrarFactorCargo(CFactorClasificacionCargoDTO factor)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);
                CRespuestaDTO resultado = new CRespuestaDTO();

                if (factor.IdEntidad == 0)
                {
                    var factorDatos = new FactorClasificacionCargo
                    {
                        FK_Cargo = factor.Cargo.IdEntidad,
                        DesActivosEquiposInsumos = factor.ActivosEquiposInsumos,
                        DesAmbiente = factor.Ambiente,
                        DesCondiciones = factor.Condiciones,
                        DesImpactoGestion = factor.ImpactoGestion,
                        DesIndependencia = factor.Independencia,
                        DesLugares = factor.Lugares,
                        DesModalidadTrabajo = factor.ModalidadTrabajo,
                        DesRelacionesTrabajo = factor.RelacionesTrabajo,
                        DesSupervisionEjercida = factor.SupervisionEjercida
                    };

                    resultado = intermedio.RegistrarFactorCargo(factorDatos);
                }
                else
                {
                    resultado = intermedio.ActualizarFactoresCargo(factor);
                }

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO ObtenerFactoresCargo(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ObtenerFactoresCargo(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirFactoresADTO((FactorClasificacionCargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistrarRequerimientosEspecificos(CRequerimientoEspecificoCargoDTO requerimiento)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);
                CRespuestaDTO resultado = new CRespuestaDTO();

                if (requerimiento.IdEntidad == 0)
                {
                    var requerimientoDatos = new RequerimientoEspecificoCargo
                    {
                        DesConocimientos = requerimiento.Conocimientos,
                        DesConocimientosDeseables = requerimiento.ConocimientosDeseables,
                        DesRequisitosEspecificos = requerimiento.RequisitosEspecificos,
                        DesHabilidades = requerimiento.Habilidades,
                        FK_Cargo = requerimiento.Cargo.IdEntidad
                    };

                    resultado = intermedio.RegistrarRequerimientosEspecificos(requerimientoDatos);
                }
                else
                {
                    resultado = intermedio.ActualizarRequerimientoEspecifico(requerimiento);
                }


                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO ObtenerRequerimientosEspecificos(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ObtenerRequerimientosEspecificos(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirRequerimientosEspecificos((RequerimientoEspecificoCargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistrarCompetenciasTransversales(List<CCompetenciaTransversalCargoDTO> competenciasTransversales)
        {
            try
            {
                CBaseDTO respuesta = new CBaseDTO();
                CCargoD intermedio = new CCargoD(contexto);

                foreach (var item in competenciasTransversales)
                {
                    var competenciaTransversalDatos = new CompetenciaTransversalCargo
                    {
                        FK_Cargo = item.Cargo.IdEntidad,
                        IndTipoCompetencia = item.TipoCompetencia,
                        IntNivelDominio = item.NivelDominio
                    };

                    var listaComportamientos = new List<ComportamientoTransversal>();

                    foreach (var comportamiento in item.ComportamientosTransversales)
                    {
                        var comportamientoDatos = new ComportamientoTransversal
                        {
                            DesComportamientoTransversal = comportamiento.ComportamientoTransversal
                        };

                        var listaEvidencias = new List<EvidenciaComportamientoTransversal>();

                        foreach (var evidencia in comportamiento.EvidenciasComportamientoTransversal)
                        {
                            var evidenciaDatos = new EvidenciaComportamientoTransversal
                            {
                                DesEvidencia = evidencia.Evidencia
                            };

                            listaEvidencias.Add(evidenciaDatos);
                        }

                        comportamientoDatos.EvidenciaComportamientoTransversal = listaEvidencias;

                        listaComportamientos.Add(comportamientoDatos);
                    }

                    competenciaTransversalDatos.ComportamientoTransversal = listaComportamientos;

                    var resultado = intermedio.RegistrarCompetenciaTransversal(competenciaTransversalDatos);

                    if (resultado.Codigo > 0)
                    {
                        respuesta = ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                    }
                    else
                    {
                        throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                    }
                }

                return respuesta;
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> ObtenerCompetenciasTransversales(int codigo)
        {
            try
            {
                List<CBaseDTO> respuesta = new List<CBaseDTO>();
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ObtenerCompetenciaTransversal(codigo);

                if (resultado.Codigo > 0)
                {
                    foreach (var item in ((List<CompetenciaTransversalCargo>)resultado.Contenido))
                    {
                        respuesta.Add(ConvertirCompetenciaTransversal(item));
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new List<CBaseDTO> { new CErrorDTO { MensajeError = error.Message } };
            }
        }

        public CBaseDTO EliminarCompetenciasTransversales(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.EliminarCompetenciaTransversal(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistrarCompetenciasGrupo(List<CCompetenciaGrupoOcupacionalDTO> competenciasGrupo)
        {
            try
            {
                CBaseDTO respuesta = new CBaseDTO();
                CCargoD intermedio = new CCargoD(contexto);

                foreach (var item in competenciasGrupo)
                {
                    var competenciaGrupo = new CompetenciaGrupoOcupacional
                    {
                        FK_Cargo = item.Cargo.IdEntidad,
                        NomCompetencia = item.TipoGrupoOcupacional,
                        IndNivel = item.Nivel
                    };

                    var listaComportamientos = new List<ComportamientoGrupoOcupacional>();

                    foreach (var comportamiento in item.ComportamientosGrupo)
                    {
                        var comportamientoDatos = new ComportamientoGrupoOcupacional
                        {
                            DesComportamiento = comportamiento.Comportamiento
                        };

                        var listaEvidencias = new List<EvidenciaGrupoOcupacional>();

                        foreach (var evidencia in comportamiento.EvidenciasGrupo)
                        {
                            var evidenciaDatos = new EvidenciaGrupoOcupacional
                            {
                                DesEvidencia = evidencia.Evidencia
                            };

                            listaEvidencias.Add(evidenciaDatos);
                        }

                        comportamientoDatos.EvidenciaGrupoOcupacional = listaEvidencias;

                        listaComportamientos.Add(comportamientoDatos);
                    }

                    competenciaGrupo.ComportamientoGrupoOcupacional = listaComportamientos;

                    var resultado = intermedio.RegistrarCompetenciaGrupoOcupacional(competenciaGrupo);

                    if (resultado.Codigo > 0)
                    {
                        respuesta = ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                    }
                    else
                    {
                        throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                    }
                }

                return respuesta;
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> ObtenerCompetenciaGrupo(int codigo)
        {
            try
            {
                List<CBaseDTO> respuesta = new List<CBaseDTO>();
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ObtenerCompetenciaGrupo(codigo);

                if (resultado.Codigo > 0)
                {
                    foreach (var item in ((List<CompetenciaGrupoOcupacional>)resultado.Contenido))
                    {
                        respuesta.Add(ConvertirCompetenciaGrupo(item));
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new List<CBaseDTO> { new CErrorDTO { MensajeError = error.Message } };
            }
        }

        public CBaseDTO EliminarCompetenciaGrupo(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.EliminarCompetenciaGrupo(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO EliminarComportamientoGrupo(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.EliminarComportamientoGrupo(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO EliminarEvidenciaGrupo(int codigo)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.EliminarEvidenciaGrupo(codigo);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> BuscarDatosCargo(CCargoDTO cargo)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            CCargoD intermedio = new CCargoD(contexto);

            List<Cargo> datosCargo = new List<Cargo>();

            if (cargo.NombreCargo != null)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.NombreCargo, "Nombre"));

                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.UbicacionOrganizacional != null)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.UbicacionOrganizacional, "Ubicacion"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.ProcesoTrabajo != null)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.ProcesoTrabajo, "Proceso"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.Estrato != null)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.Estrato, "Estrato"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.ClaseCargo != null && cargo.ClaseCargo.IdEntidad > 0)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.ClaseCargo.IdEntidad, "Clase"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.EspecialidadCargo != null && cargo.EspecialidadCargo.IdEntidad > 0)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.EspecialidadCargo.IdEntidad, "Especialidad"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.SubespecialidadCargo != null && cargo.SubespecialidadCargo.IdEntidad > 0)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.SubespecialidadCargo.IdEntidad, "Subespecialidad"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.SeccionCargo != null && cargo.SeccionCargo.IdEntidad > 0)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.SeccionCargo.IdEntidad, "Seccion"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.JefaturaInmediata != null)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.JefaturaInmediata, "Inmediata"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (cargo.JefaturaSuperiorInmediata != null)
            {
                var resultado = ((CRespuestaDTO)intermedio.
                    BuscarDatosCargo(datosCargo, cargo.JefaturaSuperiorInmediata, "Superior"));
                if (resultado.Codigo > 0)
                {
                    datosCargo = (List<Cargo>)resultado.Contenido;
                }
            }

            if (datosCargo.Count > 0)
            {
                foreach (var item in datosCargo)
                { 
                    var datoCargo = ConvertirCargoDatosADTO(item);

                    respuesta.Add(datoCargo);
                }
            }
            else
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontraron resultados para los parámetros especificados." });
            }

            return respuesta;
        }

        private CCargoDTO ConvertirCargoDatosADTO(Cargo item)
        {
            return new CCargoDTO
            {
                ClaseCargo = (item.IndClase != null && item.IndClase > 0) ? CClaseL.ConstruirClase(contexto.Clase.FirstOrDefault(C => C.PK_Clase == item.IndClase)) : null,
                EspecialidadCargo = (item.IndEspecialidad != null && item.IndEspecialidad > 0) ? CEspecialidadL.ConstruirEspecialidad(contexto.Especialidad.FirstOrDefault(C => C.PK_Especialidad == item.IndEspecialidad)) : null,
                SubespecialidadCargo = (item.IndSubespecialidad != null && item.IndSubespecialidad > 0) ? CSubEspecialidadL.ConvertirSubEspecialidadADTO(contexto.SubEspecialidad.FirstOrDefault(C => C.PK_SubEspecialidad == item.IndSubespecialidad)) : null,
                SeccionCargo = (item.IndSeccion != null && item.IndSeccion > 0) ? CSeccionL.ConvertirSeccionADTO(contexto.Seccion.FirstOrDefault(C => C.PK_Seccion == item.IndSeccion)) : null,
                DeclaracionJurada = Convert.ToBoolean(item.IndDeclaracion),
                Estrato = item.DesEstrato,
                IdEntidad = item.PK_Cargo,
                JefaturaInmediata = item.IndJefaturaInmediata,
                JefaturaSuperiorInmediata = item.IndJefaturaSuperiorInmediata,
                NombreCargo = item.NomCargo,
                Poliza = Convert.ToBoolean(item.IndPoliza),
                ProcesoTrabajo = item.DesProcesoTrabajo,
                UbicacionOrganizacional = item.DesUbicacionOrganizacional
            };
        }

        public CBaseDTO RegistrarComportamientoGrupoOcupacionalAdicional(int competencia, CComportamientoGrupoOcupacionalDTO comportamiento)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var respuesta = intermedio.RegistrarComportamientoGrupoOcupacionalAdicional(competencia, ConvertirComportamientoGrupoADatos(comportamiento));

                if (respuesta.Codigo < 0)
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
                else
                {
                    return ConvertirCompetenciaGrupo(((CompetenciaGrupoOcupacional)respuesta.Contenido));
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        private ComportamientoGrupoOcupacional ConvertirComportamientoGrupoADatos(CComportamientoGrupoOcupacionalDTO comportamiento)
        {
            return new ComportamientoGrupoOcupacional
            {
                DesComportamiento = comportamiento.Comportamiento
            };
        }

        public CBaseDTO RegistrarEvidenciaGrupoOcupacionalAdicional(int comportamiento, CEvidenciaGrupoOcupacionalDTO evidencia)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var respuesta = intermedio.RegistrarEvidenciaGrupoOcupacionalAdicional(comportamiento, ConvertirEvidenciaGrupoADatos(evidencia));

                if (respuesta.Codigo < 0)
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
                else
                {
                    return ConvertirComportamientoGrupo(((ComportamientoGrupoOcupacional)respuesta.Contenido));
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        private EvidenciaGrupoOcupacional ConvertirEvidenciaGrupoADatos(CEvidenciaGrupoOcupacionalDTO evidencia)
        {
            return new EvidenciaGrupoOcupacional
            {
                DesEvidencia = evidencia.Evidencia
            };
        }

        public CBaseDTO ActualizarNivelCompetenciaTransversal(int competencia, int nivel)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var respuesta = intermedio.ActualizarNivelCompetenciaTransversal(competencia, nivel);

                if (respuesta.Codigo < 0)
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
                else
                {
                    return ConvertirCompetenciaTransversal(((CompetenciaTransversalCargo)respuesta.Contenido));
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO AgregarComportamientoTransversal(int competencia, CComportamientoTransversalDTO comportamiento)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var respuesta = intermedio.AgregarComportamientoTransversal(competencia, ConvertirComportamientoTransversalADatos(comportamiento));

                if (respuesta.Codigo < 0)
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
                else
                {
                    return ConvertirCompetenciaTransversal(((CompetenciaTransversalCargo)respuesta.Contenido));
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        private ComportamientoTransversal ConvertirComportamientoTransversalADatos(CComportamientoTransversalDTO comportamiento)
        {
            return new ComportamientoTransversal
            {
                DesComportamientoTransversal = comportamiento.ComportamientoTransversal
            };
        }

        public CBaseDTO AgregarEvidenciaTransversal(int comportamiento, CEvidenciaComportamientoTransversalDTO evidencia)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var respuesta = intermedio.AgregarEvidenciaTransversal(comportamiento, ConvertirEvidenciaTransversalADatos(evidencia));

                if (respuesta.Codigo < 0)
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
                else
                {
                    return ConvertirComportamientoTransversal(((ComportamientoTransversal)respuesta.Contenido));
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        private EvidenciaComportamientoTransversal ConvertirEvidenciaTransversalADatos(CEvidenciaComportamientoTransversalDTO evidencia)
        {
            return new EvidenciaComportamientoTransversal
            {
                DesEvidencia = evidencia.Evidencia
            };
        }

        public CBaseDTO EliminarTransversal(int codigo, string descriptor)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = new CRespuestaDTO();

                if (descriptor == "comportamiento")
                {
                    resultado = intermedio.EliminarComportamientoTransversal(codigo);
                }
                else
                {
                    resultado = intermedio.EliminarEvidenciaTransversal(codigo);
                }

                if (resultado.Codigo > 0)
                {
                    return new CBaseDTO { IdEntidad = Convert.ToInt32(resultado.Contenido) };
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public CBaseDTO RegistrarEstadoCargo(CEstadoCargoDTO estado)
        {
            try
            {
                CCargoD intermedio = new CCargoD(contexto);
                CRespuestaDTO resultado = new CRespuestaDTO();

                var estadoDatos = new EstadoCargo
                {
                    FK_Cargo = estado.CargoAsociado.IdEntidad,
                    DesEstadoCargo = estado.ObservacionesEstado,
                    FecEstadoCargo = estado.FechaActualizacion,
                    IndEstadoCargo = estado.IndicadorEstado,
                    UsrRegistro = contexto.Usuario.FirstOrDefault(U => U.NomUsuario.Contains(estado.UsuarioActualizacion)).PK_Usuario
                };

                resultado = intermedio.RegistrarEstadoCargo(estadoDatos);

                if (resultado.Codigo > 0)
                {
                    return ConvertirCargoDTOADatos((Cargo)resultado.Contenido);
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }

        public List<CBaseDTO> ListarEstadosCargo(int idCargo)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CCargoD intermedio = new CCargoD(contexto);

                var resultado = intermedio.ListarEstadosCargo(idCargo);

                if (resultado.Contenido.GetType() != typeof(CErrorDTO))
                {
                    var datosEstados = ((List<EstadoCargo>)resultado.Contenido);

                    foreach (var item in datosEstados)
                    {
                        respuesta.Add(ConvertirEstadoCargoDatosADTO(item));
                    }

                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                respuesta.Clear();
                respuesta.Add(new CErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }

        private CEstadoCargoDTO ConvertirEstadoCargoDatosADTO(EstadoCargo item)
        {
            return new CEstadoCargoDTO
            {
                Estado = DefinirEstadoCargo(Convert.ToInt32(item.IndEstadoCargo)),
                FechaActualizacion = Convert.ToDateTime(item.FecEstadoCargo),
                IdEntidad = item.PK_EstadoCargo,
                UsuarioActualizacion = contexto.Usuario.FirstOrDefault(U => U.PK_Usuario == item.UsrRegistro).NomUsuario,
                IndicadorEstado = Convert.ToInt32(item.IndEstadoCargo),
                ObservacionesEstado = item.DesEstadoCargo,
                IdUsuario = Convert.ToInt32(item.UsrRegistro),
                PerfilUsuario = contexto.PerfilAcceso.FirstOrDefault(P => P.CatPermiso.Perfil.PK_Perfil == 23 && P.DetalleAcceso.Usuario.PK_Usuario == item.UsrRegistro).CatPermiso.NomPermiso,
                NombreCompletoUsuario = contexto.DetalleAcceso.FirstOrDefault(D => D.Usuario.PK_Usuario == item.UsrRegistro).Funcionario.NomFuncionario + " " + contexto.DetalleAcceso.FirstOrDefault(D => D.Usuario.PK_Usuario == item.UsrRegistro).Funcionario.NomPrimerApellido + " " + contexto.DetalleAcceso.FirstOrDefault(D => D.Usuario.PK_Usuario == item.UsrRegistro).Funcionario.NomSegundoApellido
            };
        }

        private string DefinirEstadoCargo(int indEstadoCargo)
        {
            switch (indEstadoCargo)
            {
                case 1:
                    return "En Construcción";
                case 2:
                    return "En revisión - Coordinador";
                case 3:
                    return "Aprobado - Coordinador";
                case 4:
                    return "Rechazado - Coordinador";
                case 5:
                    return "Aprobado - Administrador";
                case 6:
                    return "Rechazado - Administrador";
                case 7:
                    return "Firma solicitante / jefatura";
                case 8:
                    return "Firma director DGIRH";
                default:
                    throw new Exception("Estado no definido");
            }
        }

        #endregion
    }
}
