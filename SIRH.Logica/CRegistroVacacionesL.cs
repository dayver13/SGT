using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.DTO;
using SIRH.Datos;

namespace SIRH.Logica
{
    public class CRegistroVacacionesL
    {
        #region Variables

        SIRHEntities contexto;

        #endregion

        #region Constructor

        public CRegistroVacacionesL()
        {
            contexto = new SIRHEntities();
        }


        internal static CRegistroVacacionesDTO ConvertirDatosRegistroVacacionesADTO(RegistroVacaciones item)
        {
            return new CRegistroVacacionesDTO
            {
                IdEntidad = item.PK_RegistroVacaciones,
                FechaRige = Convert.ToDateTime(item.FecInicio),
                FechaVence = Convert.ToDateTime(item.FecFin),
                Estado = Convert.ToInt16(item.IndEstado),
                NumeroTransaccion = item.NumTransaccion,
                Dias = Convert.ToDecimal(item.CntDias),
                TipoTransaccion = Convert.ToInt32(item.IndTipoTransaccion),
                MedioDia = Convert.ToInt32(item.IndMedioDia),
                Periodo = CPeriodoVacacionesL.ConvertirDatosPeriodoVacacionesADTO(item.PeriodoVacaciones)
            };
        }

        internal static CRegistroVacacionesDTO ConvertirDatosRegistrosVacacionesADTOS(RegistroVacaciones item)
        {
            return new CRegistroVacacionesDTO
            {
                IdEntidad = item.PK_RegistroVacaciones,
                FechaRige = Convert.ToDateTime(item.FecInicio),
                FechaVence = Convert.ToDateTime(item.FecFin),
                Estado = Convert.ToInt16(item.IndEstado),
                NumeroTransaccion = item.NumTransaccion,
                Dias = Convert.ToDecimal(item.CntDias),
                TipoTransaccion = Convert.ToInt32(item.IndTipoTransaccion),
                MedioDia = Convert.ToInt32(item.IndMedioDia),
                Periodo = CPeriodoVacacionesL.ConvertirDatosPeriodosVacacionesADTOS(item.PeriodoVacaciones)
            };
        }

        public List<CBaseDTO> ListarRegistroVacaciones(string cedula, string periodo, int codigo)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CRegistroVacacionesD intermedio = new CRegistroVacacionesD(contexto);
                
                var resultado = intermedio.ConsultaVacacionesPeriodo(cedula, periodo, codigo);
                var resultadoHistorial = intermedio.ConsultaVacacionesHistorialModulo(cedula);
                if (resultado.Codigo != -1)
                {
                    var listaPeriodos = ((List<RegistroVacaciones>)resultado.Contenido);

                    foreach (var item in listaPeriodos)
                    {
                        var dato = ConvertirDatosRegistroVacacionesADTO(item);
                        //dato.Fuente = "SIRH";
                        if (item.NumTransaccion.TrimEnd().EndsWith("0388") && item.FecInicio.Value.Month == 3)
                            dato.Fuente = "SEMANA SANTA";
                        else if (item.NumTransaccion.TrimEnd().EndsWith("0488") && item.FecInicio.Value.Month == 4)
                            dato.Fuente = "SEMANA SANTA";
                        else if (item.NumTransaccion.TrimEnd().EndsWith("1299") && item.FecInicio.Value.Month == 12)
                            dato.Fuente = "FIN DE AÑO";
                        else
                        {
                            if (item.FecInicio.Value.Year <= 2023 || item.FecInicio.HasValue && item.FecInicio.Value.Year <= 2023)
                                dato.Fuente = "SIGEVA";
                            else
                                dato.Fuente = "SIRH";
                        }
                        respuesta.Add(dato);
                    }
                }

                if (resultadoHistorial.Codigo != -1)
                {
                    var listaPeriodosHistorial = ((List<C_EMU_Vacaciones_Movimiento>)resultadoHistorial.Contenido).Where(Q => Q.PERI_TRAN == periodo).ToList();

                    foreach (var item in listaPeriodosHistorial)
                    {
                        var dato = ConvertirDatosHistorialVacacionesADTO(item);
                        dato.Fuente = "Emulación";
                        if (item.ESTADO == "Reintegro")
                        {
                            dato.Estado = -1;
                        }
                        respuesta.Add(dato);
                    }
                }

                if (respuesta.Count > 0)
                {
                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
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

        internal static CRegistroVacacionesDTO ConvertirDatosHistorialVacacionesADTO(C_EMU_Vacaciones_Movimiento item)
        {
            return new CRegistroVacacionesDTO
            {
                Dias = Convert.ToDecimal(item.DIAS.Replace('.', ',')),
                Estado = item.ESTADO != null && item.ESTADO.TrimEnd() != "" && item.ESTADO != "Reintegro" ? Convert.ToInt32(item.ESTADO) : 0,
                FechaActualizacion = Convert.ToDateTime(item.FEC_ACT),
                FechaRige = Convert.ToDateTime(item.FECHA_RIGE),
                FechaVence = Convert.ToDateTime(item.FECHA_VENCE),
                IdEntidad = item.ID,
                Mensaje = "Historico",
                NumeroTransaccion = item.DOCUMENTO,
                Periodo = new CPeriodoVacacionesDTO { Periodo = item.PERI_TRAN },
                TipoTransaccion = item.TIPO_REG != null ? Convert.ToInt32(item.TIPO_REG) : 0
            };
        }

        public List<CBaseDTO> ObtenerRegistro(string cedFuncionario, string numeroDocumento)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CRegistroVacacionesD intermedioVacaciones = new CRegistroVacacionesD(contexto);
                CFuncionarioD intermediofuncionario = new CFuncionarioD(contexto);
                CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();

                var funcionario = intermediofuncionario.BuscarFuncionarioCedula(cedFuncionario);
                if (funcionario != null)
                {
                    var registro = intermedioVacaciones.ConsultaVacacionesPorDocumento(cedFuncionario, numeroDocumento);
                    if (registro.Codigo > 0)
                    {
                        if (registro.Codigo == 1)
                        {
                            var datoRegistro = ConvertirDatosRegistroVacacionesADTO((RegistroVacaciones)registro.Contenido);
                            respuesta.Add(datoRegistro);
                            var periodo = intermedioPeriodo.ObtenerPeriodo(cedFuncionario, ((RegistroVacaciones)registro.Contenido).PeriodoVacaciones.IndPeriodo, ((RegistroVacaciones)registro.Contenido).PeriodoVacaciones.PK_PeriodoVacaciones);
                            respuesta.Add(periodo);
                        }
                        else
                        {
                            var registroHistorico = new CRegistroVacacionesDTO
                            {
                                Dias = Convert.ToDecimal(((C_EMU_Vacaciones_Movimiento)registro.Contenido).DIAS.Replace('.',',')),
                                FechaRige = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FECHA_RIGE),
                                FechaVence = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FECHA_VENCE),
                                NumeroTransaccion = ((C_EMU_Vacaciones_Movimiento)registro.Contenido).DOCUMENTO
                            };
                            respuesta.Add(registroHistorico);
                            var periodoHistorico = new CPeriodoVacacionesDTO
                            {
                                DiasDerecho = 0,
                                FechaCarga = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FEC_SOLICITUD),
                                Periodo = ((C_EMU_Vacaciones_Movimiento)registro.Contenido).PERI_TRAN,
                                Saldo = 0
                            };
                            respuesta.Add(periodoHistorico);
                        }
                    }
                    else
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontró el registro de vacaciones con el documento indicado."
                        });
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontró el funcionario digitado."
                    });
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = error.Message });
            }
            return respuesta;
        }

        public List<CBaseDTO> ObtenerVacaciones(string cedFuncionario)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CRegistroVacacionesD intermedioVacaciones = new CRegistroVacacionesD(contexto);
                CFuncionarioD intermediofuncionario = new CFuncionarioD(contexto);
                CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
                var funcionario = intermediofuncionario.BuscarFuncionarioCedula(cedFuncionario);
                if (funcionario != null)
                {
                    var registrosVacaciones = intermedioVacaciones.ConsultaVacaciones(cedFuncionario);
                    if (registrosVacaciones.Codigo > 0)
                    {
                        if (registrosVacaciones.Codigo == 1)
                        {
                            var lista = ((List<RegistroVacaciones>)registrosVacaciones.Contenido);
                            if (lista != null)
                            {
                                foreach (var item in lista)
                                {
                                    var dato = ConvertirDatosRegistrosVacacionesADTOS(item);
                                    respuesta.Add(dato);
                                }
                            }
                            //var datoRegistro = ConvertirDatosRegistroVacacionesADTO((RegistroVacaciones)registro.Contenido);
                            //respuesta.Add(datoRegistro);
                            //var periodo = intermedioPeriodo.ObtenerPeriodo(cedFuncionario, ((RegistroVacaciones)registro.Contenido).PeriodoVacaciones.IndPeriodo, ((RegistroVacaciones)registro.Contenido).PeriodoVacaciones.PK_PeriodoVacaciones);
                            //respuesta.Add(periodo);
                            return respuesta;


                        }
                        else
                        {
                            var registroHistorico = new CRegistroVacacionesDTO
                            {
                                Dias = Convert.ToDecimal(((C_EMU_Vacaciones_Movimiento)registrosVacaciones.Contenido).DIAS.Replace('.', ',')),
                                FechaRige = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registrosVacaciones.Contenido).FECHA_RIGE),
                                FechaVence = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registrosVacaciones.Contenido).FECHA_VENCE),
                                NumeroTransaccion = ((C_EMU_Vacaciones_Movimiento)registrosVacaciones.Contenido).DOCUMENTO
                            };
                            respuesta.Add(registroHistorico);
                            var periodoHistorico = new CPeriodoVacacionesDTO
                            {
                                DiasDerecho = 0,
                                FechaCarga = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registrosVacaciones.Contenido).FEC_SOLICITUD),
                                Periodo = ((C_EMU_Vacaciones_Movimiento)registrosVacaciones.Contenido).PERI_TRAN,
                                Saldo = 0
                            };
                            respuesta.Add(periodoHistorico);
                            return respuesta;
                        }
                    }
                    else
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontró el registro de vacaciones con el documento indicado."
                        });
                        return respuesta;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontró el funcionario digitado."
                    });
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = error.Message });
            }
            return respuesta;
        }

        public List<CBaseDTO> ObtenerVacacionesPorSeccion(string NombreSeccion)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CRegistroVacacionesD intermedioVacaciones = new CRegistroVacacionesD(contexto);
                CSeccionD intermedioSeccion = new CSeccionD(contexto);
                CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
                var seccion = intermedioSeccion.CargarSeccionParam(NombreSeccion);
                if (seccion != null)
                {
                    var registro = intermedioVacaciones.ConsultarVacacionesPorSeccion(NombreSeccion);
                    if (registro.Codigo > 0)
                    {
                        if (registro.Codigo == 1)
                        {
                            var lista = ((List<RegistroVacaciones>)registro.Contenido);
                            if (lista != null)
                            {
                                foreach (var item in lista)
                                {
                                    var dato = ConvertirDatosRegistrosVacacionesADTOS(item);
                                    respuesta.Add(dato);
                                }
                            }
                            return respuesta;
                        }
                        else
                        {
                            var registroHistorico = new CRegistroVacacionesDTO
                            {
                                Dias = Convert.ToDecimal(((C_EMU_Vacaciones_Movimiento)registro.Contenido).DIAS.Replace('.', ',')),
                                FechaRige = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FECHA_RIGE),
                                FechaVence = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FECHA_VENCE),
                                NumeroTransaccion = ((C_EMU_Vacaciones_Movimiento)registro.Contenido).DOCUMENTO
                            };
                            respuesta.Add(registroHistorico);
                            var periodoHistorico = new CPeriodoVacacionesDTO
                            {
                                DiasDerecho = 0,
                                FechaCarga = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FEC_SOLICITUD),
                                Periodo = ((C_EMU_Vacaciones_Movimiento)registro.Contenido).PERI_TRAN,
                                Saldo = 0
                            };
                            respuesta.Add(periodoHistorico);
                            return respuesta;
                        }
                    }
                    else
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontró el registro de vacaciones con el documento indicado."
                        });
                        return respuesta;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontró la sección solicitada."
                    });
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = error.Message });
            }
            return respuesta;
        }
        public List<CBaseDTO> ObtenerVacacionesPorDivision(string NombreDivision)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CRegistroVacacionesD intermedioVacaciones = new CRegistroVacacionesD(contexto);
                CDivisionD intermedioDivision = new CDivisionD(contexto);
                CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
                var division = intermedioDivision.CargarDivisionParam(NombreDivision);
                if (division != null)
                {
                    var registro = intermedioVacaciones.ConsultaVacacionesPorDivision(NombreDivision);
                    if (registro.Codigo > 0)
                    {
                        if (registro.Codigo == 1)
                        {
                            var lista = ((List<RegistroVacaciones>)registro.Contenido);
                            if (lista != null)
                            {
                                foreach (var item in lista)
                                {
                                    var dato = ConvertirDatosRegistrosVacacionesADTOS(item);
                                    respuesta.Add(dato);
                                }
                            }
                            return respuesta;
                        }
                        else
                        {
                            var registroHistorico = new CRegistroVacacionesDTO
                            {
                                Dias = Convert.ToDecimal(((C_EMU_Vacaciones_Movimiento)registro.Contenido).DIAS.Replace('.', ',')),
                                FechaRige = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FECHA_RIGE),
                                FechaVence = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FECHA_VENCE),
                                NumeroTransaccion = ((C_EMU_Vacaciones_Movimiento)registro.Contenido).DOCUMENTO
                            };
                            respuesta.Add(registroHistorico);
                            var periodoHistorico = new CPeriodoVacacionesDTO
                            {
                                DiasDerecho = 0,
                                FechaCarga = Convert.ToDateTime(((C_EMU_Vacaciones_Movimiento)registro.Contenido).FEC_SOLICITUD),
                                Periodo = ((C_EMU_Vacaciones_Movimiento)registro.Contenido).PERI_TRAN,
                                Saldo = 0
                            };
                            respuesta.Add(periodoHistorico);
                            return respuesta;
                        }
                    }
                    else
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontró el registro de vacaciones con el documento indicado."
                        });
                        return respuesta;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontró la división solicitada."
                    });
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = error.Message });
            }
            return respuesta;
        }

        public CBaseDTO GuardaRegistroVacaciones(CRegistroVacacionesDTO registroVacaciones, string cedulaFuncionario, string periodo, int documento)
        {
            CBaseDTO respuesta = new CBaseDTO();
            CFuncionarioD intermediofuncionario = new CFuncionarioD(contexto);
            try
            {

                CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
                RegistroVacaciones datosRegistroVacaciones = new RegistroVacaciones
                {
                    CntDias = registroVacaciones.Dias,
                    FecFin = registroVacaciones.FechaVence,
                    FecInicio = registroVacaciones.FechaRige,
                    IndTipoTransaccion = documento,
                    NumTransaccion = registroVacaciones.NumeroTransaccion,
                    IndEstado = 1,
                    FecActualizacion = DateTime.Now
                };
                respuesta = intermedioRegistroVacaciones.GuardarRegistroVacacionesModulo(datosRegistroVacaciones, cedulaFuncionario, periodo);
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

        public CBaseDTO GuardaRegistroVacaciones(CRegistroVacacionesDTO registroVacaciones, string cedulaFuncionario, string periodo, int documento, int medioDia, string tipoUsuario)
        {
            CBaseDTO respuesta = new CBaseDTO();
            CFuncionarioD intermediofuncionario = new CFuncionarioD(contexto);
            CBitacoraL intermedioBitacora = new CBitacoraL();
            try
            {
                CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
                RegistroVacaciones datosRegistroVacaciones = new RegistroVacaciones
                {
                    CntDias = registroVacaciones.Dias,
                    FecFin = registroVacaciones.FechaVence,
                    FecInicio = registroVacaciones.FechaRige,
                    IndTipoTransaccion = documento,
                    NumTransaccion = DateTime.Now.Year.ToString() + "-" + (contexto.RegistroVacaciones.Where(Q=>Q.FecInicio.Value.Year == DateTime.Now.Year).Count() + 1).ToString("00000"),
                    FecActualizacion = DateTime.Now,
                    IndMedioDia = medioDia,
                    SolicitadoPor = registroVacaciones.SolicitadoPor
                };

                if (tipoUsuario == "RH")
                {
                    datosRegistroVacaciones.IndEstado = 1;
                    respuesta = intermedioRegistroVacaciones.GuardarRegistroVacacionesAdministrador(datosRegistroVacaciones, cedulaFuncionario, periodo, CBitacoraL.ConvertirDTOBitacoraADatos(registroVacaciones.Bitacora));
                    if (((CRespuestaDTO)respuesta).Codigo > 0)
                    {
                        // Guardar bitácora Registar Vacaciones                     
                        registroVacaciones.Bitacora.TipoMovimiento = "Registrar Vacaciones RRHH";
                        registroVacaciones.Bitacora.NumMovimiento = datosRegistroVacaciones.NumTransaccion;//cedulaFuncionario + "|" + ((CRespuestaDTO)respuesta).Codigo.ToString();
                        registroVacaciones.Bitacora.NombreCampo = "";//"CntDias";
                        registroVacaciones.Bitacora.ValorInicial = "Inclusión Solicitud Vacaciones";// registroVacaciones.Dias.ToString();
                        registroVacaciones.Bitacora.ValorFinal = "";//registroVacaciones.Dias.ToString();
                        registroVacaciones.Bitacora.TipoTransaccion = "I";
                        registroVacaciones.Bitacora.Estructura = "RegistroVacaciones";

                        intermedioBitacora.GuardarBitacora(registroVacaciones.Bitacora);
                    }
                }
                else
                {
                    datosRegistroVacaciones.IndEstado = 2;

                    respuesta = intermedioRegistroVacaciones.GuardarRegistroVacacionesModulo(datosRegistroVacaciones, cedulaFuncionario, periodo);

                    if (((CRespuestaDTO)respuesta).Codigo > 0)
                    {
                        // Guardar bitácora Registar Vacaciones                  
                        registroVacaciones.Bitacora.TipoMovimiento = "Registrar Vacaciones Funcionario";
                        registroVacaciones.Bitacora.NumMovimiento = datosRegistroVacaciones.NumTransaccion;//cedulaFuncionario + "|" + ((CRespuestaDTO)respuesta).Codigo.ToString();
                        registroVacaciones.Bitacora.NombreCampo = "";//"CntDias";
                        registroVacaciones.Bitacora.ValorInicial = "Inclusión Solicitud Vacaciones";// registroVacaciones.Dias.ToString();
                        registroVacaciones.Bitacora.ValorFinal = "";//registroVacaciones.Dias.ToString();
                        registroVacaciones.Bitacora.TipoTransaccion = "I";
                        registroVacaciones.Bitacora.Estructura = "RegistroVacaciones";

                        intermedioBitacora.GuardarBitacora(registroVacaciones.Bitacora);
                    }
                }

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

        public List<List<CBaseDTO>> BuscarVacaciones(CFuncionarioDTO funcionario, CPeriodoVacacionesDTO periodoVacaciones, CRegistroVacacionesDTO registroVacaciones,
                                    List<DateTime> fechas, string direccion, string seccion, string division, string departamento, string estadoSeleccion, string tipoVacaciones)
        {
            List<List<CBaseDTO>> res = new List<List<CBaseDTO>>();
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            List<CBaseDTO> respuestaFuncionario = new List<CBaseDTO>();
            List<CBaseDTO> respuestaPeriodo = new List<CBaseDTO>();

            CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
            CFuncionarioL intermedioFuncionario = new CFuncionarioL();
            CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
            try
            {
                List<object> parametros = new List<object>();

                if (funcionario.Cedula != null)
                {
                    parametros.Add("Cedula");
                    parametros.Add(funcionario.Cedula);
                }
                if (periodoVacaciones.Periodo != null)
                {
                    parametros.Add("PeriodoVacaciones");
                    parametros.Add(periodoVacaciones.Periodo);
                }
                if (registroVacaciones.NumeroTransaccion != null)
                {
                    parametros.Add("NumeroTransaccion");
                    parametros.Add(registroVacaciones.NumeroTransaccion);
                }
                if (seccion != "null")
                {
                    parametros.Add("Seccion");
                    parametros.Add(seccion);
                }
                if (division != "null")
                {
                    parametros.Add("Division");
                    parametros.Add(division);
                }
                if (departamento != "null")
                {
                    parametros.Add("Departamento");
                    parametros.Add(departamento);
                }
                if (direccion != "null")
                {
                    parametros.Add("Direccion");
                    parametros.Add(direccion);
                }
                if (fechas.Count == 2)
                {
                    parametros.Add("Fecha");
                    parametros.Add(fechas);
                }
                if (tipoVacaciones != "null")
                {
                    parametros.Add("TipoVacaciones");
                    parametros.Add(tipoVacaciones);
                }
                var listaVacaciones = intermedioRegistroVacaciones.Filtrar(parametros.ToArray(), estadoSeleccion);
                var lista = ((List<RegistroVacaciones>)listaVacaciones.Contenido);
                if (lista != null)
                {
                    foreach (var item in lista)
                    {
                        var dato = ConvertirDatosRegistroVacacionesADTO(item);
                        var datoCed = new Funcionario { IdCedulaFuncionario = item.PeriodoVacaciones.Nombramiento.Funcionario.IdCedulaFuncionario };
                        respuesta.Add(dato);
                        respuestaPeriodo.Add(intermedioPeriodo.DescargarPeriodo(item.PeriodoVacaciones.Nombramiento.Funcionario.IdCedulaFuncionario, item.PeriodoVacaciones.IndPeriodo));

                        respuestaFuncionario.Add(intermedioFuncionario.DescargarFuncionario(datoCed.IdCedulaFuncionario));
                    }
                    if (respuesta.Count() == 0 || respuestaFuncionario.Count() == 0 || respuestaPeriodo.Count() == 0)
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontraron registros para los parametros ingresados!"
                        });
                        res.Add(respuesta);
                        return res;
                    }
                    else
                    {
                        res.Add(respuesta);
                        res.Add(respuestaFuncionario);
                        res.Add(respuestaPeriodo);
                        return res;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontraron registros para los parametros ingresados!"
                    });
                    res.Add(respuesta);
                    return res;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message,
                    Mensaje = error.Message
                });
                res.Add(respuesta);
                return res;
            }
        }
        public CBaseDTO GuardarRebajoColectivo(CFuncionarioDTO funcionario, CRegistroVacacionesDTO rebajoColectivo)
        {
            CBaseDTO respuesta = new CBaseDTO();
            try
            {

                CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
                RegistroVacaciones datosReintegro = new RegistroVacaciones
                {
                    CntDias = rebajoColectivo.Dias,
                    FecFin = rebajoColectivo.FechaVence,
                    FecInicio = rebajoColectivo.FechaRige,
                    IndTipoTransaccion = 88,
                    NumTransaccion = rebajoColectivo.NumeroTransaccion,
                    IndEstado = 1
                };
                respuesta = intermedioRegistroVacaciones.GuardarRebajoColectivo(funcionario, datosReintegro);
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
        public CBaseDTO AnularRebajoColectivo(CFuncionarioDTO funcionario, string numTransaccion)
        {
            CBaseDTO respuesta = new CBaseDTO();
            try
            {

                CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
                RegistroVacaciones datosReintegro = new RegistroVacaciones
                {
                    NumTransaccion = numTransaccion

                };
                respuesta = intermedioRegistroVacaciones.AnularRebajoColectivo(funcionario, numTransaccion);
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
        public CBaseDTO ValidarNumeroDocumento(string numTransaccion)
        {
            CBaseDTO respuesta = new CBaseDTO();
            try
            {

                CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
                respuesta = intermedioRegistroVacaciones.ValidarNumeroDocumento(numTransaccion);
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
        public List<List<CBaseDTO>> ObtenerInconsistencias(DateTime fechaInicio, DateTime fechaFin, string cedula)
        {
            List<CBaseDTO> respuestaFuncionario = new List<CBaseDTO>();
            CFuncionarioL intermedioFuncionario = new CFuncionarioL();
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            List<List<CBaseDTO>> res = new List<List<CBaseDTO>>();
            try
            {
                CRegistroVacacionesD intermedioVacaciones = new CRegistroVacacionesD(contexto);

                var registro = intermedioVacaciones.ConsultaInconsistencias(fechaInicio, fechaFin, cedula);
                var lista = ((List<RegistroVacaciones>)registro.Contenido);
                if (lista != null)
                {
                    foreach (var item in lista)
                    {
                        var dato = ConvertirDatosRegistroVacacionesADTO(item);
                        respuesta.Add(dato);
                        respuestaFuncionario.Add(intermedioFuncionario.DescargarFuncionario(cedula));
                    }
                    res.Add(respuesta);
                    res.Add(respuestaFuncionario);
                    return res;
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontraron inconsistencias."
                    });
                    res.Add(respuesta);
                    return res;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message,
                    Mensaje = error.Message
                });
                res.Add(respuesta);
                return res;
            }
        }

        public CBaseDTO TrasladarRegistroVacaciones(int idRegistro, decimal dias, int periodoDestino)
        {
            try
            {
                CRegistroVacacionesD intermedio = new CRegistroVacacionesD(contexto);

                var respuesta = intermedio.TrasladarRegistroVacaciones(idRegistro, dias, periodoDestino);

                if (respuesta.Codigo > 0)
                {
                    return CPeriodoVacacionesL.ConvertirDatosPeriodoVacacionesADTO(((PeriodoVacaciones)respuesta.Contenido));
                }
                else
                {
                    throw new Exception(((CErrorDTO)respuesta.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO
                {
                    MensajeError = error.Message
            };
        }
    }

        public List<List<CBaseDTO>> BuscarVacacionesFuncionario(CFuncionarioDTO funcionario, string periodoVacaciones,
                                    List<DateTime> fechas, string estadoSeleccion, string tipoVacaciones)
        {
            List<List<CBaseDTO>> res = new List<List<CBaseDTO>>();
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            List<CBaseDTO> respuestaFuncionario = new List<CBaseDTO>();
            List<CBaseDTO> respuestaPeriodo = new List<CBaseDTO>();
            CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
            CFuncionarioL intermedioFuncionario = new CFuncionarioL();
            CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
            try
            {
                List<object> parametros = new List<object>();
                if (funcionario.Cedula != null)
                {
                    parametros.Add("Cedula");
                    parametros.Add(funcionario.Cedula);
                }
                if (periodoVacaciones != null)
                {
                    parametros.Add("PeriodoVacaciones");
                    parametros.Add(periodoVacaciones);
                }
                if (fechas.Count == 2)
                {
                    parametros.Add("Fecha");
                    parametros.Add(fechas);
                }
                if (tipoVacaciones != "null")
                {
                    parametros.Add("TipoVacaciones");
                    parametros.Add(tipoVacaciones);
                }
                var listaVacaciones = intermedioRegistroVacaciones.Filtrar(parametros.ToArray(), estadoSeleccion);
                var lista = ((List<RegistroVacaciones>)listaVacaciones.Contenido);
                if (lista != null)
                {
                    foreach (var item in lista)
                    {
                        var dato = ConvertirDatosRegistroVacacionesADTO(item);
                        var datoCed = new Funcionario { IdCedulaFuncionario = item.PeriodoVacaciones.Nombramiento.Funcionario.IdCedulaFuncionario };
                        respuesta.Add(dato);
                        respuestaPeriodo.Add(intermedioPeriodo.DescargarPeriodo(item.PeriodoVacaciones.Nombramiento.Funcionario.IdCedulaFuncionario, item.PeriodoVacaciones.IndPeriodo));
                        respuestaFuncionario.Add(intermedioFuncionario.DescargarFuncionario(datoCed.IdCedulaFuncionario));
                    }
                    if (respuesta.Count() == 0 || respuestaFuncionario.Count() == 0 || respuestaPeriodo.Count() == 0)
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontraron registros para los parametros ingresados!"
                        });
                        res.Add(respuesta);
                        return res;
                    }
                    else
                    {
                        res.Add(respuesta);
                        res.Add(respuestaFuncionario);
                        res.Add(respuestaPeriodo);
                        return res;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontraron registros para los parametros ingresados!"
                    });
                    res.Add(respuesta);
                    return res;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message,
                    Mensaje = error.Message
                });
                res.Add(respuesta);
                return res;
            }
        }
        public List<List<CBaseDTO>> BuscarVacacionesDivision(string division, CPeriodoVacacionesDTO periodoVacaciones,
                                    List<DateTime> fechas, string estadoSeleccion, string tipoVacaciones)
        {
            List<List<CBaseDTO>> res = new List<List<CBaseDTO>>();
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            List<CBaseDTO> respuestaFuncionario = new List<CBaseDTO>();
            List<CBaseDTO> respuestaPeriodo = new List<CBaseDTO>();
            CRegistroVacacionesD intermedioRegistroVacaciones = new CRegistroVacacionesD(contexto);
            CFuncionarioL intermedioFuncionario = new CFuncionarioL();
            CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
            try
            {
                List<object> parametros = new List<object>();
                if (division != "null")
                {
                    parametros.Add("Division");
                    parametros.Add(division);
                }
                if (periodoVacaciones.Periodo != null)
                {
                    parametros.Add("PeriodoVacaciones");
                    parametros.Add(periodoVacaciones.Periodo);
                }
                if (fechas.Count == 2)
                {
                    parametros.Add("Fecha");
                    parametros.Add(fechas);
                }
                if (tipoVacaciones != "null")
                {
                    parametros.Add("TipoVacaciones");
                    parametros.Add(tipoVacaciones);
                }
                var listaVacaciones = intermedioRegistroVacaciones.Filtrar(parametros.ToArray(), estadoSeleccion);
                var lista = ((List<RegistroVacaciones>)listaVacaciones.Contenido);
                if (lista != null)
                {
                    foreach (var item in lista)
                    {
                        var dato = ConvertirDatosRegistroVacacionesADTO(item);
                        var datoCed = new Funcionario { IdCedulaFuncionario = item.PeriodoVacaciones.Nombramiento.Funcionario.IdCedulaFuncionario };
                        respuesta.Add(dato);
                        respuestaPeriodo.Add(intermedioPeriodo.DescargarPeriodo(item.PeriodoVacaciones.Nombramiento.Funcionario.IdCedulaFuncionario, item.PeriodoVacaciones.IndPeriodo));
                        respuestaFuncionario.Add(intermedioFuncionario.DescargarFuncionario(datoCed.IdCedulaFuncionario));
                    }
                    if (respuesta.Count() == 0 || respuestaFuncionario.Count() == 0 || respuestaPeriodo.Count() == 0)
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontraron registros para los parametros ingresados!"
                        });
                        res.Add(respuesta);
                        return res;
                    }
                    else
                    {
                        res.Add(respuesta);
                        res.Add(respuestaFuncionario);
                        res.Add(respuestaPeriodo);
                        return res;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontraron registros para los parametros ingresados!"
                    });
                    res.Add(respuesta);
                    return res;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message,
                    Mensaje = error.Message
                });
                res.Add(respuesta);
                return res;
            }
        }


        public List<CBaseDTO> ObtenerVacacionesTipoSolicitud(string cedFuncionario, int idEstado)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {
                CRegistroVacacionesD intermedioVacaciones = new CRegistroVacacionesD(contexto);
                CFuncionarioD intermediofuncionario = new CFuncionarioD(contexto);
                CPeriodoVacacionesL intermedioPeriodo = new CPeriodoVacacionesL();
                var funcionario = intermediofuncionario.BuscarFuncionarioCedula(cedFuncionario);
                if (funcionario != null)
                {
                    var registro = intermedioVacaciones.ConsultaVacacionesTipoSolicitud(cedFuncionario, idEstado);
                    if (registro.Codigo > 0)
                    {
                        if (registro.Codigo == 1)
                        {
                            var lista = ((List<RegistroVacaciones>)registro.Contenido);
                            if (lista != null)
                            {
                                foreach (var item in lista)
                                {
                                    var dato = ConvertirDatosRegistroVacacionesADTO(item);
                                    respuesta.Add(dato);
                                }
                            }
                            //var datoRegistro = ConvertirDatosRegistroVacacionesADTO((RegistroVacaciones)registro.Contenido);
                            //respuesta.Add(datoRegistro);
                            //var periodo = intermedioPeriodo.ObtenerPeriodo(cedFuncionario, ((RegistroVacaciones)registro.Contenido).PeriodoVacaciones.IndPeriodo, ((RegistroVacaciones)registro.Contenido).PeriodoVacaciones.PK_PeriodoVacaciones);
                            //respuesta.Add(periodo);
                            return respuesta;
                        }
                    }
                    else
                    {
                        respuesta.Add(new CErrorDTO
                        {
                            Codigo = -1,
                            MensajeError = "No se encontró el registro de vacaciones con el documento indicado."
                        });
                        return respuesta;
                    }
                }
                else
                {
                    respuesta.Add(new CErrorDTO
                    {
                        Codigo = -1,
                        MensajeError = "No se encontró el funcionario digitado."
                    });
                    return respuesta;
                }
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = error.Message });
            }
            return respuesta;
        }
        public CBaseDTO AnularSolicitudVacaciones(int idSolicitud)
        {
            try
            {

                CRegistroVacacionesD intermedio = new CRegistroVacacionesD(contexto);
                var resultado = intermedio.AnularSolicitudVacaciones(idSolicitud);
                if (resultado.Codigo > 0)
                {
                    return ConvertirDatosRegistroVacacionesADTO((RegistroVacaciones)resultado.Contenido);
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
        public CBaseDTO ActualizarSolicitudVacaciones(string numDocumento, string estado, string comentario,
            string cedulaFunc, string funcAprobar)
        {
            try
            {
                CRegistroVacacionesD intermedio = new CRegistroVacacionesD(contexto);
                var resultado = intermedio.ActualizarSolicitudVacaciones(numDocumento, estado, comentario,
                    cedulaFunc, funcAprobar);
                if (resultado.Codigo > 0)
                {
                    return new CBaseDTO { Mensaje = "Solicitud actualizada correctamente" };
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


        public List<CBaseDTO> ListarDiasPorTipo(int tipo, string cedula)
        {
            List<CBaseDTO> resultado = new List<CBaseDTO>();
        
            try
            {
                CTipoDiaD intermedio = new CTipoDiaD(contexto);
                CCatalogoDiaD intermedioCatalogo = new CCatalogoDiaD(contexto);

                var tipoDia = intermedio.BuscarTipoDia(tipo);
                var catalogo = intermedioCatalogo.ListarCatalogoDiaPorTipo(((TipoDia)tipoDia.Contenido).PK_TipoDia);

                if (catalogo.Codigo > 0)
                {
                    foreach (var dia in (List<CatalogoDia>)catalogo.Contenido)
                    {
                        resultado.Add(new CCatalogoDiaDTO 
                        {
                            IdEntidad = dia.PK_CatalogoDia,
                            DescripcionDia = dia.DesDia,
                            Mes = dia.FecDia.Substring(3, 2),
                            Dia = dia.FecDia.Substring(0, 2)
                        });
                    }
                }
                else
                {
                    resultado.Add((CErrorDTO)catalogo.Contenido);
                }

            }
            catch (Exception error)
            {
                resultado.Add(new CErrorDTO
                {
                    Codigo = -1,
                    MensajeError = error.Message
                });
            }
            return resultado;
        }

        #endregion
    }
}
