using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CDetalleCalificacionObjetivoL
    {
        #region Variables

        SIRHEntities contexto;
        
        #endregion

        #region constructor

        public CDetalleCalificacionObjetivoL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

       

        //internal static DetalleCalificacionSeguimiento ConvertirDTOSeguimientoADatos(CDetalleCalificacionSeguimientoDTO item)
        //{
        //    return new DetalleCalificacionSeguimiento
        //    {
        //        PK_Detalle = item.IdEntidad,
        //        DesEvidencia = item.DesEvidencia,
        //        DesComentario = item.DesComentario,
        //        DesOportunidadMejora = item.DesOportunidadMejora,
        //        DesPlanAccion = item.DesPlanAccion,
        //        FecRegistro = item.FecRegistro,
        //        FecCierreAccion = item.FecCierreAccion,
        //        IdJefatura = item.JefeInmediato.IdEntidad,
        //        FK_Estado = item.Estado.IdEntidad,
        //        FK_CalificacionNombramientoFuncionario = item.Calificacion.IdEntidad
        //    };
        //}

        //public CBaseDTO GuardarSeguimiento(CDetalleCalificacionSeguimientoDTO detalle)
        //{
        //    CBaseDTO respuesta = new CBaseDTO();

        //    try
        //    {
        //        CDetalleCalificacionSeguimientoD intermedio = new CDetalleCalificacionSeguimientoD(contexto);
        //        CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);

        //        DetalleCalificacionSeguimiento datos = ConvertirDTOSeguimientoADatos(detalle);

        //        var calificacion = intermedioCal.ObtenerCalificacionFuncionario(detalle.Calificacion.IdEntidad);
        //        if (calificacion.Codigo != -1)
        //            datos.CalificacionNombramientoFuncionarios = (CalificacionNombramientoFuncionarios)calificacion.Contenido;
        //        else
        //            throw new Exception(((CErrorDTO)calificacion.Contenido).Mensaje);

        //        var insertaDetalle = intermedio.AgregarDetalleSeguimiento(datos);

        //        //pregunto si da error
        //        if (insertaDetalle.Codigo > 0)
        //            respuesta = insertaDetalle;
        //        else
        //            throw new Exception(((CErrorDTO)insertaDetalle.Contenido).Mensaje); 
        //    }
        //    catch (Exception error)
        //    {              
        //        respuesta = new CErrorDTO
        //        {
        //            Codigo = -1,
        //            MensajeError = error.Message
        //        };
        //    }

        //    return respuesta;
        //}

        //public CBaseDTO ModificarSeguimiento(CDetalleCalificacionSeguimientoDTO detalle)
        //{
        //    CBaseDTO respuesta = new CBaseDTO();

        //    try
        //    {
        //        CDetalleCalificacionSeguimientoD intermedio = new CDetalleCalificacionSeguimientoD(contexto);

        //        DetalleCalificacionSeguimiento seguimientoBD = new DetalleCalificacionSeguimiento
        //        {
        //            PK_Detalle = detalle.IdEntidad,
        //            FK_Estado = detalle.Estado.IdEntidad
        //        };

        //        var datosSeguimiento = intermedio.ModificarEstado(seguimientoBD);

        //        if (datosSeguimiento.Codigo > 0)
        //            respuesta = new CBaseDTO { IdEntidad = detalle.IdEntidad };
        //        else
        //            respuesta = ((CErrorDTO)datosSeguimiento.Contenido);
        //    }
        //    catch (Exception error)
        //    {
        //        respuesta = (new CErrorDTO
        //        {
        //            Codigo = -1,
        //            MensajeError = error.Message
        //        });
        //    }

        //    return respuesta;
        //}

        //public List<CBaseDTO> ObtenerDetalleSeguimiento(int codigo)
        //{
        //    List<CBaseDTO> respuesta = new List<CBaseDTO>();

        //    try
        //    {
        //        CDetalleCalificacionSeguimientoD intermedio = new CDetalleCalificacionSeguimientoD(contexto);

        //        var dato = intermedio.ObtenerDetalleSeguimiento(codigo);
        //        if (dato.Codigo != -1)
        //        {
        //            var datosSeguimiento = ConvertirDatosSeguimientoADto((DetalleCalificacionSeguimiento)dato.Contenido);

        //            // [0] DetalleSeguimiento
        //            respuesta.Add(datosSeguimiento);
        //        }
        //        else
        //        {
        //            respuesta.Add((CErrorDTO)dato.Contenido);
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        respuesta.Add(new CErrorDTO
        //        {
        //            Codigo = -1,
        //            MensajeError = error.Message
        //        });
        //    }

        //    return respuesta;
        //}

        //public List<CBaseDTO> ListarSeguimientos(CFuncionarioDTO funcionario, CPeriodoCalificacionDTO periodo)
        //{
        //    List<CBaseDTO> respuesta = new List<CBaseDTO>();

        //    CDetalleCalificacionSeguimientoD intermedio = new CDetalleCalificacionSeguimientoD(contexto);
        //    CFuncionarioD intermedioFuncionario = new CFuncionarioD(contexto);

        //    List<DetalleCalificacionSeguimiento> datosSeguimiento = new List<DetalleCalificacionSeguimiento>();

        //    if (funcionario.Cedula != "" && periodo.IdEntidad > 0)
        //    {
        //        var datoFuncionario = intermedioFuncionario.BuscarFuncionarioNombramiento(funcionario.Cedula);
        //        datosSeguimiento = intermedio.CargarDatos(datoFuncionario.PK_Funcionario, periodo.IdEntidad);
        //    }

        //    if (datosSeguimiento.Count > 0)
        //    {
        //        foreach (var item in datosSeguimiento)
        //        {
        //            if(item.FK_Estado != 5)
        //                respuesta.Add(ConvertirDatosSeguimientoADto(item));
        //        }
        //    }
        //    else
        //    {
        //        respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontraron resultados para los parámetros especificados." });
        //    }

        //    return respuesta;
        //}


        public List<List<CBaseDTO>> BuscarCalificacionFuncionario(CFuncionarioDTO funcionario, CPeriodoCalificacionDTO periodo)
        {
            List<CBaseDTO> lista = new List<CBaseDTO>();
            List<CBaseDTO> listaSeguimiento = new List<CBaseDTO>();
                                  
            List<List<CBaseDTO>> respuesta = new List<List<CBaseDTO>>();

            CCalificacionNombramientoL intermedioCal = new CCalificacionNombramientoL();
            CCalificacionAutoEvaluacionL intermedioAuto = new CCalificacionAutoEvaluacionL();
            CCalificacionServicioL intermedioServicio = new CCalificacionServicioL();
            CDetalleCalificacionCompetenciaL intermedioCompetencia = new CDetalleCalificacionCompetenciaL();
            CCatCalificacionCompetenciasL intermedioCatalogComp = new CCatCalificacionCompetenciasL();

            CCalificacionJefeColaboradorL intermedioCol = new CCalificacionJefeColaboradorL();

            CMetaIndividualCalificacionD intermedio = new CMetaIndividualCalificacionD(contexto);
            CCalificacionNombramientoD intermedioCalDatos = new CCalificacionNombramientoD(contexto);

            CDetalleCalificacionNombramientoD intermedioDCN = new CDetalleCalificacionNombramientoD(contexto);
            CDetalleCalificacionSeguimientoD intermedioSeg = new CDetalleCalificacionSeguimientoD(contexto);

            CDetallePuestoD intermedioDP = new CDetallePuestoD(contexto);

            List<MetaIndividualCalificacion> datosMeta = new List<MetaIndividualCalificacion>();

            bool buscar = true;
            var idFuncionario = 0;
            decimal notaServicio = 0;

            var calificacionDTO = new CCalificacionNombramientoDTO();
            var funcionarioDTO = new CFuncionarioDTO();
            var claseDTO = new CClaseDTO();
            var direccionDTO = new CDireccionGeneralDTO();
            var puestoDTO = new CPuestoDTO();

            try
            {
                var datoCalificacion = intermedioCalDatos.ListarCalificacionNombramientoCedula(funcionario.Cedula)
                                                     .Where(Q => Q.IndEstado == 1 && Q.FK_PeriodoCalificacion == periodo.IdEntidad)
                                                     .FirstOrDefault();

                // Verificar si existe la evaluación
                if (datoCalificacion != null)
                {
                    calificacionDTO = CCalificacionNombramientoL.ConvertirDatosCCalificacionNombramientoLADto(datoCalificacion);

                    // Detalle Puesto
                    calificacionDTO.DetallePuesto = CDetallePuestoL.ConstruirDetallePuesto(intermedioDP.CargarDetallePuesto(datoCalificacion.IdDetallePuesto));

                    // Jefe Inmediato
                    if (calificacionDTO.JefeInmediato.IdEntidad != 0)
                    {
                        var dJefatura = intermedioDCN.BuscarFuncionarioId(Convert.ToInt32(calificacionDTO.JefeInmediato.IdEntidad));
                        calificacionDTO.JefeInmediato = (CFuncionarioL.FuncionarioGeneral((Funcionario)dJefatura.Contenido));
                    }
                    else
                    {
                        calificacionDTO.JefeInmediato = new CFuncionarioDTO { IdEntidad = 0, Nombre = "", Sexo = GeneroEnum.Indefinido };
                    }


                    // Jefe Superior
                    if (calificacionDTO.JefeSuperior.IdEntidad != 0)
                    {
                        var dJefaturaSup = intermedioDCN.BuscarFuncionarioId(Convert.ToInt32(calificacionDTO.JefeSuperior.IdEntidad));
                        calificacionDTO.JefeSuperior = (CFuncionarioL.FuncionarioGeneral((Funcionario)dJefaturaSup.Contenido));
                    }
                    else
                    {
                        calificacionDTO.JefeSuperior = new CFuncionarioDTO { IdEntidad = 0, Nombre = "", Sexo = GeneroEnum.Indefinido };
                    }

                    // Metas
                    calificacionDTO.DetalleMeta = new List<CDetalleCalificacionMetaDTO>();
                    foreach(var item in datoCalificacion.DetalleCalificacionMeta)
                    {
                        var detalle = CDetalleCalificacionMetaL.ConvertirDatoADto(item);

                        // Jefe Inmediato
                        if (detalle.Meta.JefeInmediato.IdEntidad != 0)
                        {
                            var dJefatura = intermedioDCN.BuscarFuncionarioId(Convert.ToInt32(detalle.Meta.JefeInmediato.IdEntidad));
                            detalle.Meta.JefeInmediato = (CFuncionarioL.FuncionarioGeneral((Funcionario)dJefatura.Contenido));
                        }
                        calificacionDTO.DetalleMeta.Add(detalle);
                    }

                    // Competencias
                    calificacionDTO.DetalleCompetencia = new List<CDetalleCalificacionCompetenciaDTO>();
                                        
                    CCatCalificacionCompetenciasD intermedioCatCompetencia = new CCatCalificacionCompetenciasD(contexto);
                    //claseDTO.IdEntidad = 2210;
                    var dato = intermedioCatCompetencia.CargarPorClase(calificacionDTO.DetallePuesto.Clase.IdEntidad);//(claseDTO.IdEntidad);
                    
                    if (dato != null)
                    {
                        foreach (var item in datoCalificacion.DetalleCalificacionCompetencia)
                        {
                            var detalleCompDTO = CDetalleCalificacionCompetenciaL.ConvertirDatoADto(item);
                            
                            var CatComp = dato.Where(Q=>Q.TipoCalificacionCompetencia.PK_TipoCompetencia == item.TipoCalificacionCompetencia.PK_TipoCompetencia).FirstOrDefault();

                            detalleCompDTO.PorDesarrollar = CatComp.PorDesarrollar;
                            detalleCompDTO.PorMejorar = CatComp.PorMejorar;
                            detalleCompDTO.PorCumple = CatComp.PorCumple;

                            calificacionDTO.DetalleCompetencia.Add(detalleCompDTO);
                        }
                    }
                    else
                    {                       
                        lista.Add(new CErrorDTO { MensajeError = "No existe información de Competencias de la Clase " + claseDTO.IdEntidad.ToString() + " - " + claseDTO.DesClase != null ? claseDTO.DesClase.TrimEnd() : "" + ".Favor comunicarse con Recursos Humanos" });
                    }
                    

                    // AutoEvaluación
                    calificacionDTO.DetalleAutoEvaluacion = new List<CDetalleCalificacionAutoEvaluacionDTO>();
                    foreach (var item in datoCalificacion.DetalleCalificacionAutoEvaluacion)
                    {
                        calificacionDTO.DetalleAutoEvaluacion.Add(CDetalleCalificacionAutoEvaluacionL.ConvertirDatoADto(item));
                    }

                    // Servicio
                    calificacionDTO.DetalleServicio = new List<CDetalleCalificacionServicioDTO>();
                    foreach (var item in datoCalificacion.DetalleCalificacionServicio)
                    {
                        calificacionDTO.DetalleServicio.Add(CDetalleCalificacionServicioL.ConvertirDatoADto(item));
                    }

                    // JefeColaborador
                    calificacionDTO.DetalleJefeColaborador = new List<CDetalleCalificacionJefeColaboradorDTO>();
                    foreach (var item in datoCalificacion.DetalleCalificacionJefeColaborador)
                    {
                        calificacionDTO.DetalleJefeColaborador.Add(CDetalleCalificacionJefeColaboradorL.ConvertirDatoADto(item));
                    }

                 
                    // [0][0] Calificación Funcionario
                    var datosDetalle = intermedioCal.DescargarNombramientoFuncionarioCalificar(funcionario.Cedula, periodo.IdEntidad);
                    var datoCalFunc = (CCalificacionNombramientoFuncionarioDTO)datosDetalle[0];
                    lista.Add(datoCalFunc);
                    lista.Add((CDetallePuestoDTO)datosDetalle[1]);
                    lista.Add((CSeccionDTO)datosDetalle[2]);
                    lista.Add((CDepartamentoDTO)datosDetalle[3]);
                    lista.Add((CDireccionGeneralDTO)datosDetalle[4]);
                    lista.Add((CDivisionDTO)datosDetalle[5]);
                    lista.Add((CExpedienteFuncionarioDTO)datosDetalle[6]);

                    // [0][7]
                    calificacionDTO.Funcionario = datoCalFunc.Funcionario;
                    calificacionDTO.Puesto = datoCalFunc.Puesto;
                    lista.Add(calificacionDTO);

                    respuesta.Add(lista);                   
                }
                else
                {  // Si no existe la Evaluación, cargar los datos principales
                   // Información del Funcionario
                    var datosDetalle = intermedioCal.DescargarNombramientoFuncionarioCalificar(funcionario.Cedula, periodo.IdEntidad);
                    if (datosDetalle.FirstOrDefault().GetType() == typeof(CErrorDTO))
                        //throw new Exception(((CErrorDTO)datosDetalle.FirstOrDefault()).MensajeError);
                        lista.Add((CErrorDTO)datosDetalle.FirstOrDefault());
                    else
                    {
                        funcionarioDTO = ((CCalificacionNombramientoFuncionarioDTO)datosDetalle[0]).Funcionario;
                        puestoDTO = ((CCalificacionNombramientoFuncionarioDTO)datosDetalle[0]).Puesto;
                        claseDTO = ((CDetallePuestoDTO)datosDetalle[1]).Clase;
                        direccionDTO = (CDireccionGeneralDTO)datosDetalle[4];
                        

                        lista.Add((CCalificacionNombramientoFuncionarioDTO)datosDetalle[0]);
                        lista.Add((CDetallePuestoDTO)datosDetalle[1]);
                        lista.Add((CSeccionDTO)datosDetalle[2]);
                        lista.Add((CDepartamentoDTO)datosDetalle[3]);
                        lista.Add((CDireccionGeneralDTO)datosDetalle[4]);
                        lista.Add((CDivisionDTO)datosDetalle[5]);
                        lista.Add((CExpedienteFuncionarioDTO)datosDetalle[6]);
                    }

                    //[0][0]  Datos Funcionario
                    respuesta.Add(lista);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[1][0]  Seguimiento
                    var datosSeguimiento = intermedioSeg.CargarDatos(funcionarioDTO.IdEntidad, periodo.IdEntidad);

                    if (datosSeguimiento.Count > 0)
                    {
                        foreach (var item in datosSeguimiento)
                        {
                            if (item.FK_Estado != 5)
                                listaSeguimiento.Add(CDetalleCalificacionSeguimientoL.ConvertirDatosSeguimientoADto(item));
                        }
                    }
                    else
                    {
                        listaSeguimiento.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontraron resultados del Seguimiento." });
                    }

                    //[1][0]  Seguimiento
                    respuesta.Add(listaSeguimiento);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[2][0]  Metas Individuales
                    lista = new List<CBaseDTO>();

                    datosMeta = intermedio.CargarMetaFuncionario(funcionario.Cedula, periodo.IdEntidad);
                    if (datosMeta.Count > 0 && buscar)
                    {
                        foreach (var item in datosMeta.Where(Q => Q.CatMetaEstado.PK_Estado != 5).ToList()) // 5 -Anulado
                        {
                            // [0] Meta
                            var metaDTO = CMetaIndividualCalificacionL.ConvertirDatosMetaADtoBasico(item);
                            metaDTO.Funcionario = CFuncionarioL.FuncionarioGeneral(item.Funcionario);
                            idFuncionario = metaDTO.Funcionario.IdEntidad;

                            // Jefe Inmediato
                            if (item.IdJefeInmediato != 0)
                            {
                                var dJefatura = intermedioDCN.BuscarFuncionarioId(item.IdJefeInmediato);
                                metaDTO.JefeInmediato = (CFuncionarioL.FuncionarioGeneral((Funcionario)dJefatura.Contenido));
                            }

                            lista.Add(metaDTO);
                        }

                        //[0][0]   Meta Individual
                        respuesta.Add(lista);
                    }
                    else
                    {
                        lista.Add(new CErrorDTO { MensajeError = "No tiene Metas asignadas para el periodo " + periodo.IdEntidad.ToString() + ". Favor registrar las Metas correspondientes" });
                        respuesta.Add(lista);
                        //throw new Exception("No se encontraron resultados para los parámetros especificados.");
                    }


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[3][0]  COMPETENCIAS  (Catálogo por Clase)
                    lista = new List<CBaseDTO>();
                    //claseDTO.IdEntidad = 2210;
                    var resultadoCompetencia = intermedioCatalogComp.ObtenerCatalagoCompetenciasClase(claseDTO);
                    
                    if (resultadoCompetencia.Count() > 0)
                    {
                        if (resultadoCompetencia[0].GetType() != typeof(CErrorDTO))
                        {
                            foreach (var item in resultadoCompetencia)
                            {
                                lista.Add((CCatCalificacionCompetenciaDTO)item);
                            }
                        }
                        else
                        {
                            lista.Add((CErrorDTO)resultadoCompetencia[0]);
                        }
                    }
                    else
                    {
                        //throw new Exception("No hay registros de la Evaluación de la Contraloría de Servicios");
                        lista.Add(new CErrorDTO { MensajeError = "No existe información de Competencias de la Clase " + claseDTO.IdEntidad.ToString() + " - " + claseDTO.DesClase != null ? claseDTO.DesClase.TrimEnd() : "" + ".Favor comunicarse con Recursos Humanos" });
                    }

                    respuesta.Add(lista);


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[4][0]  AUTOEVALUACIÓN
                    lista = new List<CBaseDTO>();

                    var resultadoAuto = intermedioAuto.ObtenerAutoEvaluacionFuncionario(periodo, funcionarioDTO);
                    if (resultadoAuto.Count() > 0)
                    {
                        if (resultadoAuto[0].GetType() == typeof(CCalificacionAutoEvaluacionDTO))
                        {
                            foreach (var item in resultadoAuto)
                            {
                                lista.Add((CCalificacionAutoEvaluacionDTO)item);
                            }
                        }
                        else
                        {
                            lista.Add(new CErrorDTO { MensajeError = "No hay registros de la AutoEvaluación del Funcionario. Se debe registrar antes de seguir con la Evaluación" });
                        }
                    }
                    else
                    {
                        lista.Add(new CErrorDTO { MensajeError = "No hay registros de la AutoEvaluación del Funcionario. Se debe registrar antes de seguir con la Evaluación" });
                    }

                    //[4][0]  AUTOEVALUACIÓN
                    respuesta.Add(lista);


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[5][0]  EVALUACIÓN DEL COLABORADOR
                    lista = new List<CBaseDTO>();

                    // Alta Dirección pública
                    if (puestoDTO.FamiliaPuesto.IdEntidad == 3)
                    {
                        decimal numNota1 = 0, porNota1 = 0;
                        decimal numNota2 = 0, porNota2 = 0;
                        decimal numNota3 = 0, porNota3 = 0;
                        decimal numNota4 = 0, porNota4 = 0;
                        decimal numNota5 = 0, porNota5 = 0;

                        var resultadoCol = intermedioCol.ObtenerCalificacionJefeColaborador(periodo, funcionarioDTO);
                        if (resultadoCol.Count() > 0)
                        {
                            foreach (var item in resultadoCol)
                            {
                                var dato = (CCalificacionJefeColaboradorDTO)item;

                                switch (dato.Tipo.IdEntidad)
                                {
                                    case 1:
                                        numNota1++;
                                        porNota1 += dato.PorNota;
                                        break;

                                    case 2:
                                        numNota2++;
                                        porNota2 += dato.PorNota;
                                        break;

                                    case 3:
                                        numNota3++;
                                        porNota3 += dato.PorNota;
                                        break;

                                    case 4:
                                        numNota4++;
                                        porNota4 += dato.PorNota;
                                        break;

                                    case 5:
                                        numNota5++;
                                        porNota5 += dato.PorNota;
                                        break;

                                    default: break;
                                }
                            }

                            lista.Add(new CCalificacionJefeColaboradorDTO
                            {
                                Periodo = periodo,
                                Jefatura = funcionarioDTO,
                                Colaborador = funcionarioDTO,
                                PorNota = Decimal.Round((porNota1 / numNota1), 2),
                                Tipo = new CTipoCalJefeColaboradorDTO
                                {
                                    IdEntidad = 1,
                                    DesTipo = "5.1 Clima y ambiente colaborativo"
                                }
                            });


                            lista.Add(new CCalificacionJefeColaboradorDTO
                            {
                                Periodo = periodo,
                                Jefatura = funcionarioDTO,
                                Colaborador = funcionarioDTO,
                                PorNota = Decimal.Round((porNota2 / numNota2), 2),
                                Tipo = new CTipoCalJefeColaboradorDTO
                                {
                                    IdEntidad = 2,
                                    DesTipo = "5.2 Ser capaz de incorporar los cambios en la gestión"
                                }
                            });


                            lista.Add(new CCalificacionJefeColaboradorDTO
                            {
                                Periodo = periodo,
                                Jefatura = funcionarioDTO,
                                Colaborador = funcionarioDTO,
                                PorNota = Decimal.Round((porNota3 / numNota3), 2),
                                Tipo = new CTipoCalJefeColaboradorDTO
                                {
                                    IdEntidad = 3,
                                    DesTipo = "5.3 Proactividad estratégica"
                                }
                            });


                            lista.Add(new CCalificacionJefeColaboradorDTO
                            {
                                Periodo = periodo,
                                Jefatura = funcionarioDTO,
                                Colaborador = funcionarioDTO,
                                PorNota = Decimal.Round((porNota4 / numNota4), 2),
                                Tipo = new CTipoCalJefeColaboradorDTO
                                {
                                    IdEntidad = 4,
                                    DesTipo = "5.4 Estrategias de empatía y claridad comunicativa"
                                }
                            });

                            lista.Add(new CCalificacionJefeColaboradorDTO
                            {
                                Periodo = periodo,
                                Jefatura = funcionarioDTO,
                                Colaborador = funcionarioDTO,
                                PorNota = Decimal.Round((porNota5 / numNota5), 2),
                                Tipo = new CTipoCalJefeColaboradorDTO
                                {
                                    IdEntidad = 5,
                                    DesTipo = "5.5 Promover ambiente de respeto ante situaciones de conflicto"
                                }
                            });
                        }
                        else
                        {
                            //throw new Exception("No hay registros de la Evaluación de la Contraloría de Servicios");
                            lista.Add(new CErrorDTO { MensajeError = "No hay registros de la Evaluación de los Colaboradores. Favor comunicarse con Recursos Humanos" });
                        }
                    }
                       
                    respuesta.Add(lista);


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[6][0]  Evaluación de la Contraloría de Servicios
                    lista = new List<CBaseDTO>();

                    //Prestación de servicios públicos
                    if (puestoDTO.FamiliaPuesto.IdEntidad == 5)
                    {
                        var resultadoBuscar = intermedioServicio.ObtenerCalificacionDireccion(periodo, direccionDTO);
                        if (resultadoBuscar.Count() > 0)
                        {
                            foreach (var item in resultadoBuscar)
                            {
                                lista.Add((CCalificacionServicioDTO)item);
                                notaServicio += ((CCalificacionServicioDTO)item).PorNota;
                            }
                        }
                        else
                        {
                            //throw new Exception("No hay registros de la Evaluación de la Contraloría de Servicios");
                            lista.Add(new CErrorDTO { MensajeError = "No hay registros de la Evaluación de la Contraloría de Servicio. Favor comunicarse con Recursos Humanos" });
                        }
                    }
                    respuesta.Add(lista);


                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //[7][0]  CAPACITACIÓN Y OTRAS MEDIDAS DE MEJORAMIENTO
                    lista = new List<CBaseDTO>();
                    var calificacion = intermedioCalDatos.DescargarFuncionarioCalificar(funcionario.Cedula, periodo.IdEntidad);
                    var datoCalifica = (CalificacionNombramientoFuncionarios)calificacion.Contenido;

                    if (datoCalifica.CalificacionCapacitacion != null)
                    {
                        foreach (var capacitacion in datoCalifica.CalificacionCapacitacion.Where(Q => Q.IndEstado == 1).ToList())
                        {
                            lista.Add(CCalificacionCapacitacionL.ConvertirDatosCapacitacionADto(capacitacion));
                        }
                    }

                    if (lista.Count == 0)
                        lista.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontró información de Capacitación." });

                    //[7][0]  Capacitacion
                    respuesta.Add(lista);
                }
            }
            catch (Exception error)
            {
                respuesta.Clear();
                lista.Add(new CErrorDTO
                {
                    IdEntidad = -1,
                    Mensaje = error.Message,
                    MensajeError = error.InnerException != null ? error.InnerException.Message : ""
                });
                respuesta.Add(lista);
            }

            return respuesta;
        }


        public CBaseDTO GuardarCalificacion(CCalificacionNombramientoDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();
            var mensaje = "Inicio";
            try
            {
                CFuncionarioD intermedioFun = new CFuncionarioD(contexto);
                CCalificacionNombramientoD intermedio = new CCalificacionNombramientoD(contexto);

                CDetalleCalificacionMetaD intermedioMeta = new CDetalleCalificacionMetaD(contexto);
                CDetalleCalificacionCompetenciaD intermedioCompetencia = new CDetalleCalificacionCompetenciaD(contexto);
                CDetalleCalificacionAutoEvaluacionD intermedioAutoEvaluacion = new CDetalleCalificacionAutoEvaluacionD(contexto);
                CDetalleCalificacionJefeColaboradorD intermedioJefeColaborador = new CDetalleCalificacionJefeColaboradorD(contexto);
                CDetalleCalificacionServicioD intermedioServicio = new CDetalleCalificacionServicioD(contexto);

                CMetaIndividualCalificacionD intermedioMetaCal = new CMetaIndividualCalificacionD(contexto);
                CTipoCalificacionCompetenciaD intermedioTipoComp = new CTipoCalificacionCompetenciaD(contexto);
                CTipoAutoEvaluacionD intermedioTipoAutoEv = new CTipoAutoEvaluacionD(contexto);
                CTipoCalJefeColaboradorD intermedioTipoJC = new CTipoCalJefeColaboradorD(contexto);
                CTipoCategoriaServicioD intermedioTipoServicio = new CTipoCategoriaServicioD(contexto);

                var datosCalificacion = CCalificacionNombramientoL.ConvertirDTOCalificacionNombramientoADatos(registro);
                datosCalificacion.FecRatificacion = null;
                mensaje = "Convertir Datos";
                datosCalificacion.Calificacion = contexto.Calificacion.FirstOrDefault(Q => Q.PK_Calificacion == registro.CalificacionDTO.IdEntidad);
                mensaje = datosCalificacion.Calificacion.PK_Calificacion.ToString();
                // Periodo Evaluación
                var entidadPeriodo = intermedio.ObtenerPeriodoCalificacion(registro.Periodo.IdEntidad);
                mensaje = "Periodo";
                if (entidadPeriodo.Codigo != -1)
                {
                    datosCalificacion.PeriodoCalificacion = (PeriodoCalificacion)entidadPeriodo.Contenido;
                }
                else
                {
                    mensaje = "Error Periodo";
                    throw new Exception(((CErrorDTO)((CRespuestaDTO)entidadPeriodo).Contenido).MensajeError);
                }              

                var insertaCN = intermedio.AgregarCalificacionNombramiento(datosCalificacion);
                mensaje = "Agregado";
                //pregunto si da error
                if (insertaCN.Codigo > 0)
                {
                    var calificacionBD = ((CalificacionNombramiento)insertaCN.Contenido);
                    registro.IdEntidad = calificacionBD.PK_CalificacionNombramiento;

                    // Metas 
                    foreach (var item in registro.DetalleMeta)
                    {
                        var metaBD = CDetalleCalificacionMetaL.ConvertirDTOADatos(item);
                        metaBD.CalificacionNombramiento = calificacionBD;
                        var datoMeta = intermedioMetaCal.ConsultarMetaIndividual(item.Meta.IdEntidad);
                        if (datoMeta.Codigo == -1)
                            throw new Exception(((CErrorDTO)datoMeta.Contenido).MensajeError);

                        metaBD.MetaIndividualCalificacion = (MetaIndividualCalificacion)datoMeta.Contenido;
                        var insertar = intermedioMeta.AgregarMeta(metaBD);
                        if (insertar.Codigo < 0)
                            throw new Exception(((CErrorDTO)insertar.Contenido).MensajeError);
                    }

                    // Competencias 
                    foreach (var item in registro.DetalleCompetencia)
                    {
                        var competenciaBD = CDetalleCalificacionCompetenciaL.ConvertirDTOADatos(item);
                        competenciaBD.CalificacionNombramiento = calificacionBD;
                        var datoComp = intermedioTipoComp.CargarTipoPorID(item.Tipo.IdEntidad);
                        if (datoComp == null)
                            throw new Exception("No existe el Tipo de Competencia " + item.Tipo.IdEntidad.ToString());

                        competenciaBD.TipoCalificacionCompetencia = datoComp;

                        var insertar = intermedioCompetencia.AgregarCompetencia(competenciaBD);
                        if (insertar.Codigo < 0)
                            throw new Exception(((CErrorDTO)insertar.Contenido).MensajeError);
                    }

                    // AutoEvaluación 
                    foreach (var item in registro.DetalleAutoEvaluacion)
                    {
                        var autoEvaluacionBD = CDetalleCalificacionAutoEvaluacionL.ConvertirDTOADatos(item);
                        autoEvaluacionBD.CalificacionNombramiento = calificacionBD;
                        var datoAutoEv = intermedioTipoAutoEv.CargarTipoPorID(item.Tipo.IdEntidad);
                        if (datoAutoEv == null)
                            throw new Exception("No existe el Tipo de Auto Evaluación " + item.Tipo.IdEntidad.ToString());

                        autoEvaluacionBD.TipoAutoevaluacion = datoAutoEv;

                        var insertar = intermedioAutoEvaluacion.AgregarAutoEvaluacion(autoEvaluacionBD);
                        if (insertar.Codigo < 0)
                            throw new Exception(((CErrorDTO)insertar.Contenido).MensajeError);
                    }

                    // Evaluación Colaboradores 
                    if(registro.DetalleJefeColaborador != null)
                    {
                        foreach (var item in registro.DetalleJefeColaborador)
                        {
                            var jefeColaboradorBD = CDetalleCalificacionJefeColaboradorL.ConvertirDTOADatos(item);
                            jefeColaboradorBD.CalificacionNombramiento = calificacionBD;
                            var datoJC = intermedioTipoJC.CargarTipoPorID(item.Tipo.IdEntidad);
                            if (datoJC == null)
                                throw new Exception("No existe el Tipo de Categoría para el Jefe-Colaborador " + item.Tipo.IdEntidad.ToString());

                            jefeColaboradorBD.TipoCalJefeColaborador = datoJC;

                            var insertar = intermedioJefeColaborador.AgregarJefeColaborador(jefeColaboradorBD);
                            if (insertar.Codigo < 0)
                                throw new Exception(((CErrorDTO)insertar.Contenido).MensajeError);
                        }
                    }


                    // Evaluación Servicios 
                    if (registro.DetalleJefeColaborador != null)
                    {
                        foreach (var item in registro.DetalleServicio)
                        {
                            var servicioBD = CDetalleCalificacionServicioL.ConvertirDTOADatos(item);
                            servicioBD.CalificacionNombramiento = calificacionBD;
                            var datoServicio = intermedioTipoServicio.CargarTipoPorID(item.Tipo.IdEntidad);
                            if (datoServicio == null)
                                throw new Exception("No existe el Tipo de Categoría de Servicio " + item.Tipo.IdEntidad.ToString());

                            servicioBD.TipoCategoriaServicio = datoServicio;

                            var insertar = intermedioServicio.AgregarServicio(servicioBD);
                            if (insertar.Codigo < 0)
                                throw new Exception(((CErrorDTO)insertar.Contenido).MensajeError);
                        }
                    }

                    respuesta = registro ;
                }
                else
                {
                    throw new Exception(((CErrorDTO)insertaCN.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                respuesta = new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message + " " + mensaje
                };
            }

            return respuesta;
        }


        public CBaseDTO ModificarCalificacion(CCalificacionNombramientoDTO registro)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CCalificacionNombramientoD intermedioCal = new CCalificacionNombramientoD(contexto);
                CDetalleCalificacionMetaD intermedioMeta = new CDetalleCalificacionMetaD(contexto);
                CDetalleCalificacionCompetenciaD intermedioCompetencia = new CDetalleCalificacionCompetenciaD(contexto);

                decimal porNota = registro.DetalleMeta.Sum(Q => Q.PorNota) +
                    registro.DetalleCompetencia.Sum(Q => Q.PorNota) + 
                    registro.DetalleAutoEvaluacion.Sum(Q => Q.PorNota) +
                    (registro.DetalleJefeColaborador != null ? registro.DetalleJefeColaborador.Sum(Q => Q.PorNota) : 0) +
                    (registro.DetalleServicio != null ? registro.DetalleServicio.Sum(Q => Q.PorNota) : 0);

                // Metas 
                if (registro.DetalleMeta != null)
                {
                    foreach (var item in registro.DetalleMeta)
                    {
                        var metaBD = CDetalleCalificacionMetaL.ConvertirDTOADatos(item);
                        var modificar = intermedioMeta.EditarMeta(metaBD);
                        if (modificar.Codigo < 0)
                            throw new Exception(((CErrorDTO)modificar.Contenido).MensajeError + ". " + item.IdEntidad);
                    }
                }


                // Competencias 
                if (registro.DetalleCompetencia != null)
                {
                    foreach (var item in registro.DetalleCompetencia)
                    {
                        var competenciaBD = CDetalleCalificacionCompetenciaL.ConvertirDTOADatos(item);
                        
                        var modificar = intermedioCompetencia.EditarCompetencia(competenciaBD);
                        if (modificar.Codigo < 0)
                            throw new Exception(((CErrorDTO)modificar.Contenido).MensajeError + ". " + item.IdEntidad);
                    }
                }


                // Modificar la Calificación
                var codNota = CalcularNota(porNota);
                var modificarCal = intermedioCal.ModificarCalificacion(registro.IdEntidad, codNota);
                if (modificarCal.Codigo < 0)
                    throw new Exception(((CErrorDTO)modificarCal.Contenido).MensajeError);

                respuesta = registro;
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

        private int CalcularNota(decimal nota)
        {
            if (nota >= 100)
                return 6; // Sobresaliente
            else if (nota >= 90 && nota < 100)
                return 1; // Excelente
            else if (nota >= 80 && nota < 90)
                return 2; // Muy Bueno
            else if (nota >= 70 && nota < 80)
                return 3; // Bueno
            else if (nota >= 1 && nota < 70)
                return 7; // Insuficiente
            else if (nota < 1)
                return 5; // Deficiente

            return 0;
        }
        #endregion
    }
}