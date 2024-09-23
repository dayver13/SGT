using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SIRH.DTO;
using SIRH.Logica;

namespace SIRH.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICManualCargosService" in both code and config file together.
    [ServiceContract]
    public interface ICManualCargosService
    {
        [OperationContract]
        CBaseDTO RegistrarCargo(CCargoDTO cargo);

        [OperationContract]
        CBaseDTO ObtenerCargo(int codigo);

        [OperationContract]
        CBaseDTO RegistrarResultadosCargo(List<CResultadoCargoDTO> resultados);

        [OperationContract]
        CBaseDTO ResgistrarFactorCargo(CFactorClasificacionCargoDTO factor);

        [OperationContract]
        CBaseDTO RegistrarRequerimientosEspecificos(CRequerimientoEspecificoCargoDTO requerimiento);

        [OperationContract]
        CBaseDTO RegistrarCompetenciasTransversales(List<CCompetenciaTransversalCargoDTO> competenciasTransversales);

        [OperationContract]
        CBaseDTO RegistrarCompetenciasGrupo(List<CCompetenciaGrupoOcupacionalDTO> competencias);

        [OperationContract]
        List<CBaseDTO> ObtenerResultadoCargo(int codigo);

        [OperationContract]
        CBaseDTO EliminarResultado(int codigo);

        [OperationContract]
        CBaseDTO EliminarActividad(int codigo);

        [OperationContract]
        CBaseDTO ObtenerFactoresCargo(int codigo);

        [OperationContract]
        CBaseDTO ObtenerRequerimientosEspecificos(int codigo);

        [OperationContract]
        CBaseDTO ActualizarRequerimientoEspecifico(CRequerimientoEspecificoCargoDTO requerimiento);

        [OperationContract]
        List<CBaseDTO> ObtenerCompetenciaTransversal(int codigo);

        [OperationContract]
        CBaseDTO EliminarCompetenciasTransversales(int codigo);

        [OperationContract]
        List<CBaseDTO> ObtenerCompetenciaGrupo(int codigo);

        [OperationContract]
        CBaseDTO EliminarCompetenciaGrupo(int codigo);

        [OperationContract]
        CBaseDTO EliminarComportamientoGrupo(int codigo);

        [OperationContract]
        CBaseDTO EliminarEvidenciaGrupo(int codigo);

        [OperationContract]
        List<CBaseDTO> BuscarDatosCargo(CCargoDTO cargo);

        [OperationContract]
        CBaseDTO RegistrarActividadAdicionalResultado(int idResultado, CActividadResultadoCargoDTO actividad);

        [OperationContract]
        CBaseDTO RegistrarComportamientoGrupoOcupacionalAdicional(int competencia, CComportamientoGrupoOcupacionalDTO comportamiento);

        [OperationContract]
        CBaseDTO RegistrarEvidenciaGrupoOcupacionalAdicional(int comportamiento, CEvidenciaGrupoOcupacionalDTO evidencia);

        [OperationContract]
        CBaseDTO ActualizarNivelCompetenciaTransversal(int competencia, int nivel);

        [OperationContract]
        CBaseDTO AgregarComportamientoTransversal(int competencia, CComportamientoTransversalDTO comportamiento);

        [OperationContract]
        CBaseDTO AgregarEvidenciaTransversal(int comportamiento, CEvidenciaComportamientoTransversalDTO evidencia);

        [OperationContract]

        CBaseDTO EliminarTransversal(int identificador, string descriptor);

        [OperationContract]
        CBaseDTO RegistrarEstadoCargo(CEstadoCargoDTO estado);

        [OperationContract]
        List<CBaseDTO> ListarEstadosCargo(int idCargo);
    }
}
