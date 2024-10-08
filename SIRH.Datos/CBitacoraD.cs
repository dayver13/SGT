using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.DTO;
using System.Data.SqlClient;
using System.Data;

namespace SIRH.Datos
{
    public class CBitacoraD
    {
        #region Variables

        private SIRHEntities entidadBase = new SIRHEntities();

        #endregion

        #region Constructor

        public CBitacoraD(SIRHEntities entidadGlobal)
        {
            entidadBase = entidadGlobal;
        }

        #endregion

        #region Métodos

        public CRespuestaDTO GuardarBitacora(Bitacora bitacora)
        {
            try
            {
                //bitacora.CodEntidad = ObtenerIDEntidad(entidad);
                entidadBase.Bitacora.Add(bitacora);

                entidadBase.SaveChanges();
                return new CRespuestaDTO
                {
                    Codigo = 1,
                    Contenido = bitacora.ID
                };
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

        public CRespuestaDTO ListarBitacora(CBitacoraDTO bitacora, List<DateTime> fechas)
        {
            CRespuestaDTO respuesta;

            try
            {
                DateTime paramFechaInicio = new DateTime();
                DateTime paramFechaFinal = new DateTime();

                var resultado = new List<Bitacora>();
                bool condicionFecha = false;

                if (fechas.Count > 0)
                {
                    paramFechaInicio = fechas.ElementAt(0);
                    paramFechaFinal = fechas.ElementAt(1).AddDays(1);
                    condicionFecha = true;
                }

                if (bitacora.IdEntidad > 0)
                    resultado = entidadBase.Bitacora.Where(q => q.ID == bitacora.IdEntidad).ToList();
                else 
                    resultado = entidadBase.Bitacora.ToList();

                if (bitacora.Usuario != null)
                    resultado = resultado.Where(q => q.USUARIO == bitacora.Usuario).ToList();

                if (bitacora.TipoMovimiento != null)
                    resultado = resultado.Where(q => q.TIPO_MOVIMIENTO == bitacora.TipoTransaccion).ToList();

                if (bitacora.TipoTransaccion != null)
                    resultado = resultado.Where(q => q.TIPO_TRANSACCION == bitacora.TipoTransaccion).ToList();

                if (condicionFecha)
                    resultado = resultado.Where(q => q.FECHA_MOVIMIENTO >= paramFechaInicio && q.FECHA_MOVIMIENTO < paramFechaFinal).ToList();

                if (resultado != null)
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = 1,
                        Contenido = resultado
                    };
                }
                else
                {
                    respuesta = new CRespuestaDTO
                    {
                        Codigo = -1,
                        Contenido = "Ocurrió un error al leer los datos de la Bitácora"
                    };
                }
            }
            catch (Exception error)
            {
                respuesta = new CRespuestaDTO
                {
                    Codigo = -1,
                    Contenido = new CErrorDTO { MensajeError = error.Message }
                };
            }

            return respuesta;
        }

        private int ObtenerIDEntidad(string entidad)
        {
            int resultado = 0;

            try
            {
                var dato = entidadBase.SeleccionarObjectID(entidad).ToList();
                resultado = Convert.ToInt32(dato[0]);
            }
            catch (Exception error)
            {
                resultado = -1;
            }   

            //DatosConexion str = new DatosConexion();
            //int resultado = 0;
            //SqlConnection conn = new SqlConnection(str.ConSIRH);
            ////SqlConnection conn = new SqlConnection(str.ConADABAS);
            //conn.Open();
            //SqlCommand commandSP = new SqlCommand("dbo.SeleccionarObjectID", conn);
            //commandSP.CommandType = CommandType.StoredProcedure;
            //commandSP.Parameters.Add("@entidad", SqlDbType.VarChar).Value = entidad;

            //var a = commandSP.ExecuteReader();
            //if (a.Read())
            //{
            //    resultado = Convert.ToInt32(a.GetValue(0));
            //}
            //conn.Close();
            return resultado;
        }


        #endregion
    }
}
