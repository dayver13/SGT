using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIRH.Datos;
using SIRH.DTO;

namespace SIRH.Logica
{
    public class CSolicitudTeletrabajoL
    {
        #region Variables

        SIRHEntities contexto;

        #endregion

        #region Constructor

        public CSolicitudTeletrabajoL()
        {
            contexto = new SIRHEntities();
        }

        #endregion

        #region Traductores

        internal static SolicitudTeletrabajoDTO ConvertirDatosSolicitudTeletrabajoADTO(SolicitudTeletrabajo datos)
        {
            return new SolicitudTeletrabajoDTO
            {
                AprobadoJefaturaInmediata = Convert.ToBoolean(datos.IndAprobadoJefatura),
                AprobadoJefaturaSuperior = Convert.ToBoolean(datos.IndAprobadoSuperior),
                CantidadDiasTeletrabajo = Convert.ToInt32(datos.CntDiasSolicita),
                CantidadPersonasDireccionPrimaria = Convert.ToInt32(datos.CntPersonasDirPrimario),
                CantidadPersonasDireccionSecundaria = Convert.ToInt32(datos.CntPersonasDirSecundario),
                DeclaracionJurada = Convert.ToBoolean(datos.IndDeclaracionJurada),
                DetalleDiasTeletrabajo = datos.DesDiasSolicita,
                DireccionExactaSecundaria = datos.DirExactaSecundario,
                DistritoSecundario = Convert.ToInt32(datos.IndDistritoSecundario),
                Escolaridad = Convert.ToInt32(datos.IndEscolaridad),
                Funciones = datos.DesFunciones,
                Horario = datos.IndHorario,
                Razones = datos.DesRazones,
                Sistemas = datos.DesSistemas,
                Teletrabajable = Convert.ToBoolean(datos.IndTeletrabajable),
                TiempoFunciones = Convert.ToInt32(datos.IndTiempoFunciones),
                TiempoLaborarDependencia = datos.DesTiempoLaboradoDependencia,
                TiempoLaborarMOPT = datos.DesTiempoLaborarMopt,
                FuncionarioTeletrabajo = CFuncionarioL.FuncionarioGeneral(datos.Funcionario)
            };
        }

        internal static SolicitudTeletrabajo SolicitudTeletrabajoDTOADtos(SolicitudTeletrabajoDTO solicitud)
        {
            return new SolicitudTeletrabajo
            {
                IndAprobadoJefatura = solicitud.AprobadoJefaturaInmediata,
                IndAprobadoSuperior = solicitud.AprobadoJefaturaSuperior,
                CntDiasSolicita = solicitud.CantidadDiasTeletrabajo,
                CntPersonasDirPrimario = solicitud.CantidadPersonasDireccionPrimaria,
                CntPersonasDirSecundario = solicitud.CantidadPersonasDireccionSecundaria,
                DesDiasSolicita = solicitud.DetalleDiasTeletrabajo,
                DesFunciones = solicitud.Funciones,
                DesRazones = solicitud.Razones,
                DesSistemas = solicitud.Sistemas,
                DesTiempoLaboradoDependencia = solicitud.TiempoLaborarDependencia,
                DesTiempoLaborarMopt = solicitud.TiempoLaborarMOPT,
                DirExactaSecundario = solicitud.DireccionExactaSecundaria,
                FK_Funcionario = solicitud.FuncionarioTeletrabajo.IdEntidad,
                IndDeclaracionJurada = solicitud.DeclaracionJurada,
                IndDistritoSecundario = solicitud.DistritoSecundario,
                IndEscolaridad = solicitud.Escolaridad,
                IndHorario = solicitud.Horario,
                IndTeletrabajable = solicitud.Teletrabajable,
                IndTiempoFunciones = solicitud.TiempoFunciones
            };
        }

        public CBaseDTO GuardarSolicitud(SolicitudTeletrabajoDTO solicitud)
        {
            try
            {
                var solicitudDatos = SolicitudTeletrabajoDTOADtos(solicitud);
                var intermedioDatos = new CSolicitudTeletrabajoD(contexto).GuardarSolicitud(solicitudDatos);

                if(intermedioDatos.Codigo > 0) {
                    return solicitud;
                }
                else
                {
                    throw new Exception(((CErrorDTO)intermedioDatos.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { Codigo = -1, MensajeError = error.Message };
            }
        }

        public CBaseDTO AprobacionInmediato(int solicitud)
        {
            try
            {
                var intermedioDatos = new CSolicitudTeletrabajoD(contexto).AprobacionInmediato(solicitud);

                if (intermedioDatos.IdEntidad > 0)
                {
                    return ConvertirDatosSolicitudTeletrabajoADTO(((SolicitudTeletrabajo)intermedioDatos.Contenido));
                }
                else
                {
                    throw new Exception(((CErrorDTO)intermedioDatos.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { Codigo = -1, MensajeError = error.Message };
            }
        }

        public CBaseDTO AprobacionSuperior(int solicitud)
        {
            try
            {
                var intermedioDatos = new CSolicitudTeletrabajoD(contexto).AprobacionSuperior(solicitud);

                if (intermedioDatos.IdEntidad > 0)
                {
                    return ConvertirDatosSolicitudTeletrabajoADTO(((SolicitudTeletrabajo)intermedioDatos.Contenido));
                }
                else
                {
                    throw new Exception(((CErrorDTO)intermedioDatos.Contenido).MensajeError);
                }
            }
            catch (Exception error)
            {
                return new CErrorDTO { Codigo = -1, MensajeError = error.Message };
            }
        }

        #endregion
    }
}
