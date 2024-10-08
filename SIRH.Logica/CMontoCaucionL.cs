using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;
using SIRH.Datos;


namespace SIRH.Logica
{
    public class CMontoCaucionL
    {
        #region Variables

        SIRHEntities contexto;

        #endregion

        #region Constructor

        public CMontoCaucionL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        //Este es un método traductor
        //public: de acceso publico
        //private: acceso exclusivo de la clase que lo implemente
        //protected: acceso para la clase que lo implementa y las clases hijas (en caso de aplicar herencia)
        //internal: acceso publico dentro de la misma capa
        //stactic: permiten referenciar funciones sin declarar variables de clase, evitan que se realicen cambios en los parámetros que consumen
        internal static CMontoCaucionDTO ConvertirMontoCaucionADTO(MontoCaucion item)
        {
            return new CMontoCaucionDTO
            {
                IdEntidad = item.PK_MontoCaucion,
                Nivel = item.IndNivel,
                Descripcion = item.DesMontoCaucion,
                Justificacion = item.DesJustificacion,
                FechaRige = Convert.ToDateTime(item.FecRige),
                EstadoMonto = Convert.ToInt32(item.IndEstadoMonto),
                MontoColones = Convert.ToDecimal(item.MtoColones),
                DetalleEstadoMonto = Convert.ToInt32(item.IndEstadoMonto) == 1 ? "Activo" : "Inactivo",
                FechaInactiva = Convert.ToDateTime(item.FecVencimiento),
                JustificacionInactiva = item.DesJustificacionInactivo
            };
        }

        internal static MontoCaucion ConvertirMontoCaucionADatos(CMontoCaucionDTO item)
        {
            return new MontoCaucion
            {
                DesJustificacion = item.Justificacion,
                DesMontoCaucion = item.Descripcion,
                FecRige = item.FechaRige,
                IndEstadoMonto = item.EstadoMonto,
                IndNivel = item.Nivel,
                MtoColones = item.MontoColones,
                FecVencimiento = item.FechaInactiva.Year > 1 ? item.FechaInactiva : (DateTime?)null,
                DesJustificacionInactivo = item.JustificacionInactiva
            };
        }

        //Se insertó en ICCaucionService y CCaucionService(DEIVERT)
        public CBaseDTO AgregarMontoCaucion(CMontoCaucionDTO monto)
        {
            CBaseDTO respuesta;

            try
            {
                CMontoCaucionD intermedio = new CMontoCaucionD(contexto);

                var montoBD = ConvertirMontoCaucionADatos(monto);

                var resultado = intermedio.AgregarMontoCaucion(montoBD);

                if (resultado.Codigo > 0)
                {
                    respuesta = new CMontoCaucionDTO { IdEntidad = Convert.ToInt32(resultado.Contenido) };
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
        //Se insertó en ICCaucionService y CCaucionService(DEIVERT)
        public CBaseDTO EditarMontoCaucion(CMontoCaucionDTO monto)
        {
            CBaseDTO respuesta;

            try
            {
                CMontoCaucionD intermedio = new CMontoCaucionD(contexto);

                MontoCaucion montoBD = new MontoCaucion
                {
                    PK_MontoCaucion = monto.IdEntidad,
                    FecVencimiento = monto.FechaInactiva,
                    DesJustificacionInactivo = monto.JustificacionInactiva
                };

                var resultado = intermedio.EditarMontoCaucion(montoBD);

                if (resultado.Codigo > 0)
                {
                    respuesta = new CMontoCaucionDTO { IdEntidad = Convert.ToInt32(resultado.Contenido) };
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
        //Se insertó en ICCaucionService y CCaucionService(DEIVERT)
        public List<CBaseDTO> ListarMontosCaucion()
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();

            try
            {
                CMontoCaucionD intermedio = new CMontoCaucionD(contexto);

                var entidadMontos = intermedio.ListarMontoCaucion();

                if (entidadMontos.Codigo > 0)
                {
                    foreach (var item in (List<MontoCaucion>)entidadMontos.Contenido)
                    {
                        respuesta.Add(ConvertirMontoCaucionADTO(item));
                    }

                    return respuesta;
                }
                else
                {
                    throw new Exception(((CErrorDTO)entidadMontos.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                respuesta.Clear();
                respuesta.Add(new CErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }

        //Se insertó en ICCaucionService y CCaucionService(DEIVERT)
        public List<CBaseDTO> BuscarMontosCaucion(CMontoCaucionDTO caucion, List<DateTime> fechas, 
                                                    List<decimal> montos)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            try
            {

                CMontoCaucionD intermedio = new CMontoCaucionD(contexto);

                List<MontoCaucion> datos = new List<MontoCaucion>();

                if (caucion.DetalleEstadoMonto != null)
                {
                    caucion.EstadoMonto = DeterminarEstado(caucion.DetalleEstadoMonto);

                    var datosBD = ((CRespuestaDTO)intermedio.BuscarMontosCaucion(datos, caucion.EstadoMonto, "Estado"));

                    if (datosBD.Codigo > 0)
                    {
                        datos = (List<MontoCaucion>)datosBD.Contenido;
                    }
                    else
                    {
                        throw new Exception(((CErrorDTO)datosBD.Contenido).MensajeError);
                    }
                }

                if (caucion.Descripcion != null)
                {
                    var datosBD = ((CRespuestaDTO)intermedio.BuscarMontosCaucion(datos, caucion.Descripcion, "Puesto"));

                    if (datosBD.Codigo > 0)
                    {
                        datos = (List<MontoCaucion>)datosBD.Contenido;
                    }
                    else
                    {
                        throw new Exception(((CErrorDTO)datosBD.Contenido).MensajeError);
                    }
                }

                if (fechas.Count > 0)
                {
                    var datosBD = ((CRespuestaDTO)intermedio.BuscarMontosCaucion(datos, fechas, "Fecha"));

                    if (datosBD.Codigo > 0)
                    {
                        datos = (List<MontoCaucion>)datosBD.Contenido;
                    }
                    else
                    {
                        throw new Exception(((CErrorDTO)datosBD.Contenido).MensajeError);
                    }
                }

                if (montos.Count > 0)
                {
                    var datosBD = ((CRespuestaDTO)intermedio.BuscarMontosCaucion(datos, montos, "Monto"));

                    if (datosBD.Codigo > 0)
                    {
                        datos = (List<MontoCaucion>)datosBD.Contenido;
                    }
                    else
                    {
                        throw new Exception(((CErrorDTO)datosBD.Contenido).MensajeError);
                    }
                }

                if(datos.Count < 1)
                {
                    throw new Exception("No se encontraron datos asociados a la búsqueda determinada.");
                }

                foreach (var item in datos)
                {
                    respuesta.Add(ConvertirMontoCaucionADTO(item));
                }

                return respuesta;
            }
            catch (Exception error)
            {
                respuesta.Add(new CErrorDTO { MensajeError = error.Message });
                return respuesta;
            }
        }
        //Se insertó en ICCaucionService y CCaucionService(DEIVERT)
        public CBaseDTO ObtenerMontoCaucion(int codMontoCaucion)
        {
            CBaseDTO respuesta = new CBaseDTO();

            try
            {
                CMontoCaucionD intermedio = new CMontoCaucionD(contexto);

                var resultado = intermedio.ObtenerMontoCaucion(codMontoCaucion);

                if (resultado.Codigo > 0)
                {
                    //respuesta positiva (sin errores)
                    //var contenidoRespuesta = resultado.Contenido;
                    //var datoBD = (MontoCaucion)resultado.Contenido;
                    //var datoTraducido = ConvertirMontoCaucionADTO(((MontoCaucion)resultado.Contenido));
                    respuesta = ConvertirMontoCaucionADTO(((MontoCaucion)resultado.Contenido));
                    return respuesta;
                }
                else
                {
                    //respuesta negativa (con errores)
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError);
                }

            }
            catch (Exception error)
            {
                respuesta = new CErrorDTO { MensajeError = error.Message };
                return respuesta;
            }
        }

        private int DeterminarEstado(string estado)
        {
            int respuesta = 1;

            if (estado == "Inactivo")
            {
                respuesta = 2;
            }

            return respuesta;
        }

        #endregion
    }
}
