using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIRH.Datos;
using SIRH.DTO;
using System.Data.Objects;
using System.Data.EntityClient;

namespace SIRH.Logica
{
    public class CBitacoraL
    {
        #region Variables

        SIRHEntities contexto;

        #endregion

        #region Constructor

        public CBitacoraL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Métodos

        internal static CBitacoraDTO ConvertirDatosBitacoraADTO(Bitacora item)
        {
            return new CBitacoraDTO
            {
                IdEntidad = item.ID,
                Usuario = item.USUARIO,
                TipoMovimiento = item.TIPO_MOVIMIENTO,
                NumMovimiento = item.NUM_MOVIMIENTO,
                NombreCampo = item.NOMBRE_CAMPO,
                ValorInicial = item.VALOR_INICIAL,
                ValorFinal = item.VALOR_FINAL,
                FechaMovimiento = Convert.ToDateTime(item.FECHA_MOVIMIENTO),
                HoraMovimiento = TimeSpan.Parse(item.HORA_MOVIMIENTO.ToString()),
                TipoTransaccion = item.TIPO_TRANSACCION,
                Estructura = item.ESTRUCTURA

            };
        }

        internal static Bitacora ConvertirDTOBitacoraADatos(CBitacoraDTO item)
        {
            return new Bitacora
            {
                USUARIO =item.Usuario,
                TIPO_MOVIMIENTO = item.TipoMovimiento,
                NUM_MOVIMIENTO = item.NumMovimiento,
                NOMBRE_CAMPO = item.NombreCampo,
                VALOR_INICIAL = item.ValorInicial,
                VALOR_FINAL = item.ValorFinal,
                FECHA_MOVIMIENTO= DateTime.Now,
                HORA_MOVIMIENTO= TimeSpan.Parse(DateTime.Now.ToShortTimeString()),
                TIPO_TRANSACCION = item.TipoTransaccion,
                ESTRUCTURA = item.Estructura
            };
        }

      
        public CBaseDTO GuardarBitacora(CBitacoraDTO bitacora)
        {
            try
            {
                var bitacoraDatos = ConvertirDTOBitacoraADatos(bitacora);
                var resultado = new CBitacoraD(contexto).GuardarBitacora(bitacoraDatos);
                if (resultado.Contenido.GetType() == typeof(CErrorDTO))
                {
                    throw new Exception(((CErrorDTO)resultado.Contenido).MensajeError
                        //+ "," + bitacoraDatos.CodAccion
                        //+ "," + bitacoraDatos.CodModulo
                        //+ "," + bitacoraDatos.CodObjetoEntidad
                        //+ "," + bitacoraDatos.Usuario.NomUsuario
                        //+ "," + bitacoraDatos.FecEjecucion
                        //+ "," + item
                        //+ "," + a
                        );
                }

                return bitacora;
            }
            catch (Exception error)
            {
                return new CErrorDTO { MensajeError = error.Message };
            }
        }


        public List<CBaseDTO> ListarBitacora(CBitacoraDTO bitacora, List<DateTime> fechas)
        {
            List<CBaseDTO> respuesta = new List<CBaseDTO>();
            CBitacoraD intermedio = new CBitacoraD(contexto);

            var resultado = intermedio.ListarBitacora(bitacora, fechas);

            if (resultado.Codigo > 0)
            {
                foreach (var item in (List<Bitacora>)resultado.Contenido)
                {
                    respuesta.Add(ConvertirDatosBitacoraADTO(item));
                }
            }
            else
            {
                respuesta.Add(new CErrorDTO { Codigo = -1, MensajeError = "No se encontraron resultados para los parámetros especificados." });
            }

            return respuesta;
        }
        #endregion
    }
}
