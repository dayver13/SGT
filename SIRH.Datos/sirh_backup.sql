
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/26/2023 21:05:41
-- Generated from EDMX file: C:\RESPALDO\Visual Studio 2015\Projects\SIRH\SIRH.Datos\ModelSIRH.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SIRH];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FacturaDesarraigoV_Viatico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaDesarraigo] DROP CONSTRAINT [FK_FacturaDesarraigoV_Viatico];
GO
IF OBJECT_ID(N'[dbo].[FK__Canton__Provinci__597B3B93]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Canton] DROP CONSTRAINT [FK__Canton__Provinci__597B3B93];
GO
IF OBJECT_ID(N'[dbo].[FK__CatPermis__Perfi__024846FC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatPermiso] DROP CONSTRAINT [FK__CatPermis__Perfi__024846FC];
GO
IF OBJECT_ID(N'[dbo].[FK__DetalleAc__Funci__78BEDCC2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAcceso] DROP CONSTRAINT [FK__DetalleAc__Funci__78BEDCC2];
GO
IF OBJECT_ID(N'[dbo].[FK__DetalleAc__Usuar__79B300FB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAcceso] DROP CONSTRAINT [FK__DetalleAc__Usuar__79B300FB];
GO
IF OBJECT_ID(N'[dbo].[FK__DetallePu__FK_Fo__2EA782D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuntosAdicional] DROP CONSTRAINT [FK__DetallePu__FK_Fo__2EA782D5];
GO
IF OBJECT_ID(N'[dbo].[FK__Direccion__Distr__7ADC2F5E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direccion] DROP CONSTRAINT [FK__Direccion__Distr__7ADC2F5E];
GO
IF OBJECT_ID(N'[dbo].[FK__Direccion__Funci__79E80B25]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direccion] DROP CONSTRAINT [FK__Direccion__Funci__79E80B25];
GO
IF OBJECT_ID(N'[dbo].[FK__Distrito__Canton__733B0D96]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Distrito] DROP CONSTRAINT [FK__Distrito__Canton__733B0D96];
GO
IF OBJECT_ID(N'[dbo].[FK__Funcionar__Estad__5C57A83E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Funcionario] DROP CONSTRAINT [FK__Funcionar__Estad__5C57A83E];
GO
IF OBJECT_ID(N'[dbo].[FK__Historial__CatEs__65E11278]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HistorialEstadoCivil] DROP CONSTRAINT [FK__Historial__CatEs__65E11278];
GO
IF OBJECT_ID(N'[dbo].[FK__Historial__Funci__64ECEE3F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HistorialEstadoCivil] DROP CONSTRAINT [FK__Historial__Funci__64ECEE3F];
GO
IF OBJECT_ID(N'[dbo].[FK__Informaci__Funci__68BD7F23]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InformacionContacto] DROP CONSTRAINT [FK__Informaci__Funci__68BD7F23];
GO
IF OBJECT_ID(N'[dbo].[FK__Informaci__TipoC__69B1A35C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InformacionContacto] DROP CONSTRAINT [FK__Informaci__TipoC__69B1A35C];
GO
IF OBJECT_ID(N'[dbo].[FK__PerfilAcc__CatPe__033C6B35]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilAcceso] DROP CONSTRAINT [FK__PerfilAcc__CatPe__033C6B35];
GO
IF OBJECT_ID(N'[dbo].[FK__PerfilAcc__Detal__7C8F6DA6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilAcceso] DROP CONSTRAINT [FK__PerfilAcc__Detal__7C8F6DA6];
GO
IF OBJECT_ID(N'[dbo].[FK__RelPuesto__Ubica__1590259A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelPuestoUbicacion] DROP CONSTRAINT [FK__RelPuesto__Ubica__1590259A];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__37F0F5ED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__37F0F5ED];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__38E51A26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__38E51A26];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__39D93E5F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__39D93E5F];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__3ACD6298]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__3ACD6298];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__5BA4467E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__5BA4467E];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__5C986AB7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__5C986AB7];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__5D8C8EF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__5D8C8EF0];
GO
IF OBJECT_ID(N'[dbo].[FK__TipoJorna__FK_Es__5E80B329]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoJornada] DROP CONSTRAINT [FK__TipoJorna__FK_Es__5E80B329];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubicacion__Depar__6E765879]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAdministrativa] DROP CONSTRAINT [FK__Ubicacion__Depar__6E765879];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubicacion__Direc__6D823440]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAdministrativa] DROP CONSTRAINT [FK__Ubicacion__Direc__6D823440];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubicacion__Distr__76177A41]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionPuesto] DROP CONSTRAINT [FK__Ubicacion__Distr__76177A41];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubicacion__Divis__6C8E1007]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAdministrativa] DROP CONSTRAINT [FK__Ubicacion__Divis__6C8E1007];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubicacion__Secci__6F6A7CB2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAdministrativa] DROP CONSTRAINT [FK__Ubicacion__Secci__6F6A7CB2];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubicacion__TipoU__770B9E7A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionPuesto] DROP CONSTRAINT [FK__Ubicacion__TipoU__770B9E7A];
GO
IF OBJECT_ID(N'[dbo].[FK_AccionEstrategica_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategicoAccion] DROP CONSTRAINT [FK_AccionEstrategica_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_AccionPersonal_CatAnioAccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccionPersonal] DROP CONSTRAINT [FK_AccionPersonal_CatAnioAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_AccionPersonal_EstadoBorrador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccionPersonal] DROP CONSTRAINT [FK_AccionPersonal_EstadoBorrador];
GO
IF OBJECT_ID(N'[dbo].[FK_AccionPersonal_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccionPersonal] DROP CONSTRAINT [FK_AccionPersonal_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_AccionPersonal_TipoAccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccionPersonal] DROP CONSTRAINT [FK_AccionPersonal_TipoAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_Actividad_Meta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualActividad] DROP CONSTRAINT [FK_Actividad_Meta];
GO
IF OBJECT_ID(N'[dbo].[FK_ActividadAvance_ActividadPlanAnual]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualActividadAvance] DROP CONSTRAINT [FK_ActividadAvance_ActividadPlanAnual];
GO
IF OBJECT_ID(N'[dbo].[FK_ActividadFuncionario_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActividadFuncionario] DROP CONSTRAINT [FK_ActividadFuncionario_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_ActividadPlanFuncionario_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualActividadFuncionario] DROP CONSTRAINT [FK_ActividadPlanFuncionario_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_ActividadResultadoCargo_ResultadoCargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActividadResultadoCargo] DROP CONSTRAINT [FK_ActividadResultadoCargo_ResultadoCargo];
GO
IF OBJECT_ID(N'[dbo].[FK_AddendumPrestamoPuesto_PrestamoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AddendumPrestamoPuesto] DROP CONSTRAINT [FK_AddendumPrestamoPuesto_PrestamoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_BitacoraIncidencia_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BitacoraIncidencia] DROP CONSTRAINT [FK_BitacoraIncidencia_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_BitacoraIncidencia_Incidencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BitacoraIncidencia] DROP CONSTRAINT [FK_BitacoraIncidencia_Incidencia];
GO
IF OBJECT_ID(N'[dbo].[FK_BitacoraUsuario_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BitacoraUsuario] DROP CONSTRAINT [FK_BitacoraUsuario_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_BoletaPrestamo_ExpedienteFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoletaPrestamo] DROP CONSTRAINT [FK_BoletaPrestamo_ExpedienteFuncionario];
GO
IF OBJECT_ID(N'[dbo].[FK_BoletaPrestamo_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BoletaPrestamo] DROP CONSTRAINT [FK_BoletaPrestamo_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_Borrador_Borrador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoBorradorAccionPersonal] DROP CONSTRAINT [FK_Borrador_Borrador];
GO
IF OBJECT_ID(N'[dbo].[FK_BorradorAccionPersonal_EstadoBorrador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BorradorAccionPersonal] DROP CONSTRAINT [FK_BorradorAccionPersonal_EstadoBorrador];
GO
IF OBJECT_ID(N'[dbo].[FK_BotAccionIncidencia_CatalogoIncidencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BotAccionIncidencia] DROP CONSTRAINT [FK_BotAccionIncidencia_CatalogoIncidencia];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionAutoEvaluacion_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionAutoEvaluacion] DROP CONSTRAINT [FK_CalificacionAutoEvaluacion_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionAutoEvaluacion_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionAutoEvaluacion] DROP CONSTRAINT [FK_CalificacionAutoEvaluacion_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionAutoEvaluacion_TipoAutoevaluacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionAutoEvaluacion] DROP CONSTRAINT [FK_CalificacionAutoEvaluacion_TipoAutoevaluacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCapacitacion_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionCapacitacion] DROP CONSTRAINT [FK_CalificacionCapacitacion_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCapacitacion_TipoPoliticaPublica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionCapacitacion] DROP CONSTRAINT [FK_CalificacionCapacitacion_TipoPoliticaPublica];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCompetencia_TipoCalificacionCompetencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionCompetencia] DROP CONSTRAINT [FK_CalificacionCompetencia_TipoCalificacionCompetencia];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCompromiso_CatMetaEstado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionCompromiso] DROP CONSTRAINT [FK_CalificacionCompromiso_CatMetaEstado];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCompromiso_CatMetaPrioridad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionCompromiso] DROP CONSTRAINT [FK_CalificacionCompromiso_CatMetaPrioridad];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCompromiso_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionCompromiso] DROP CONSTRAINT [FK_CalificacionCompromiso_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionCompromiso_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionCompromiso] DROP CONSTRAINT [FK_CalificacionCompromiso_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionEncargado_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionEncargado] DROP CONSTRAINT [FK_CalificacionEncargado_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionEncargado_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionEncargado] DROP CONSTRAINT [FK_CalificacionEncargado_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionJefeColaborador_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionJefeColaborador] DROP CONSTRAINT [FK_CalificacionJefeColaborador_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionJefeColaborador_Funcionario1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionJefeColaborador] DROP CONSTRAINT [FK_CalificacionJefeColaborador_Funcionario1];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionJefeColaborador_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionJefeColaborador] DROP CONSTRAINT [FK_CalificacionJefeColaborador_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionJefeColaborador_TipoCalJefeColaborador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionJefeColaborador] DROP CONSTRAINT [FK_CalificacionJefeColaborador_TipoCalJefeColaborador];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionNombramiento_Calificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionNombramiento] DROP CONSTRAINT [FK_CalificacionNombramiento_Calificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionNombramiento_CatCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionNombramiento] DROP CONSTRAINT [FK_CalificacionNombramiento_CatCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionNombramiento_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionNombramiento] DROP CONSTRAINT [FK_CalificacionNombramiento_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionNombramientoFuncionarios_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionNombramientoFuncionarios] DROP CONSTRAINT [FK_CalificacionNombramientoFuncionarios_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionObservaciones_CalificacionNombramientoFuncionarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionObservaciones] DROP CONSTRAINT [FK_CalificacionObservaciones_CalificacionNombramientoFuncionarios];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionReglaTecnica_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionReglaTecnica] DROP CONSTRAINT [FK_CalificacionReglaTecnica_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionServicio_Direccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionServicio] DROP CONSTRAINT [FK_CalificacionServicio_Direccion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionServicio_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionServicio] DROP CONSTRAINT [FK_CalificacionServicio_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CalificacionServicio_TipoCategoriaServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalificacionServicio] DROP CONSTRAINT [FK_CalificacionServicio_TipoCategoriaServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_CambioPorAccionPersonal_AccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CambioPorAccionPersonal] DROP CONSTRAINT [FK_CambioPorAccionPersonal_AccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_CambioPorAccionPersonal_ComponenteSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CambioPorAccionPersonal] DROP CONSTRAINT [FK_CambioPorAccionPersonal_ComponenteSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_CambioPorAccionPersonal_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CambioPorAccionPersonal] DROP CONSTRAINT [FK_CambioPorAccionPersonal_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_CambioPorAccionPersonal_TipoCambioPorAccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CambioPorAccionPersonal] DROP CONSTRAINT [FK_CambioPorAccionPersonal_TipoCambioPorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_CaracteristicasPuesto_Factor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaracteristicasPuesto] DROP CONSTRAINT [FK_CaracteristicasPuesto_Factor];
GO
IF OBJECT_ID(N'[dbo].[FK_CaracteristicasPuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaracteristicasPuesto] DROP CONSTRAINT [FK_CaracteristicasPuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Catalogo_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatalogoIncidencia] DROP CONSTRAINT [FK_Catalogo_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_CatCalificacionCompetencias_Clase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatCalificacionCompetencias] DROP CONSTRAINT [FK_CatCalificacionCompetencias_Clase];
GO
IF OBJECT_ID(N'[dbo].[FK_CatCalificacionCompetencias_TipoCalificacionCompetencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatCalificacionCompetencias] DROP CONSTRAINT [FK_CatCalificacionCompetencias_TipoCalificacionCompetencia];
GO
IF OBJECT_ID(N'[dbo].[FK_CatDiaViaticoGasto_CatDiaViaticoGasto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatDiaViaticoGasto] DROP CONSTRAINT [FK_CatDiaViaticoGasto_CatDiaViaticoGasto];
GO
IF OBJECT_ID(N'[dbo].[FK_CatPermisoEvidencia_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatPermisoEvidencia] DROP CONSTRAINT [FK_CatPermisoEvidencia_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_Caucion_EntidadSeguros]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caucion] DROP CONSTRAINT [FK_Caucion_EntidadSeguros];
GO
IF OBJECT_ID(N'[dbo].[FK_Caucion_MontoCaucion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caucion] DROP CONSTRAINT [FK_Caucion_MontoCaucion];
GO
IF OBJECT_ID(N'[dbo].[FK_Caucion_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caucion] DROP CONSTRAINT [FK_Caucion_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenciaGrupoOcupacional_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetenciaGrupoOcupacional] DROP CONSTRAINT [FK_CompetenciaGrupoOcupacional_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetenciaTransversalCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetenciaTransversalCargo] DROP CONSTRAINT [FK_CompetenciaTransversalCargo_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_ComponentePresupuestario_CatMovimientoPresupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComponentePresupuestario] DROP CONSTRAINT [FK_ComponentePresupuestario_CatMovimientoPresupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_ComponentePresupuestario_ObjetoGasto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComponentePresupuestario] DROP CONSTRAINT [FK_ComponentePresupuestario_ObjetoGasto];
GO
IF OBJECT_ID(N'[dbo].[FK_ComponentePresupuestario_Programa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComponentePresupuestario] DROP CONSTRAINT [FK_ComponentePresupuestario_Programa];
GO
IF OBJECT_ID(N'[dbo].[FK_ComponenteSalarial_ObjetoGasto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComponenteSalarial] DROP CONSTRAINT [FK_ComponenteSalarial_ObjetoGasto];
GO
IF OBJECT_ID(N'[dbo].[FK_ComportamientoGrupoOcupacional_CompetenciaGrupoOcupacional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComportamientoGrupoOcupacional] DROP CONSTRAINT [FK_ComportamientoGrupoOcupacional_CompetenciaGrupoOcupacional];
GO
IF OBJECT_ID(N'[dbo].[FK_ComportamientoTransversal_CompetenciaTransversalCargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComportamientoTransversal] DROP CONSTRAINT [FK_ComportamientoTransversal_CompetenciaTransversalCargo];
GO
IF OBJECT_ID(N'[dbo].[FK_ContratoArrendamiento_Desarraigo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContratoArrendamiento] DROP CONSTRAINT [FK_ContratoArrendamiento_Desarraigo];
GO
IF OBJECT_ID(N'[dbo].[FK_CuentaBancaria_DetalleContratacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaBancaria] DROP CONSTRAINT [FK_CuentaBancaria_DetalleContratacion];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoCapacitacion_EntidadEducativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoCapacitacion] DROP CONSTRAINT [FK_CursoCapacitacion_EntidadEducativa];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoCapacitacion_FormacionAcademica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoCapacitacion] DROP CONSTRAINT [FK_CursoCapacitacion_FormacionAcademica];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoCapacitacion_Modalidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoCapacitacion] DROP CONSTRAINT [FK_CursoCapacitacion_Modalidad];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoGrado_EntidadEducativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoGrado] DROP CONSTRAINT [FK_CursoGrado_EntidadEducativa];
GO
IF OBJECT_ID(N'[dbo].[FK_CursoGrado_FormacionAcademica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CursoGrado] DROP CONSTRAINT [FK_CursoGrado_FormacionAcademica];
GO
IF OBJECT_ID(N'[dbo].[FK_DatosBoleta_BoletaPrestamo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleBoleta] DROP CONSTRAINT [FK_DatosBoleta_BoletaPrestamo];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CatalogoDeduccion_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatalogoDeduccion] DROP CONSTRAINT [FK_dbo_CatalogoDeduccion_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CatalogoDia_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CatalogoDia] DROP CONSTRAINT [FK_dbo_CatalogoDia_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_DeduccionEfectuada_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeduccionEfectuada] DROP CONSTRAINT [FK_dbo_DeduccionEfectuada_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_DeduccionEfectuada_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeduccionEfectuada] DROP CONSTRAINT [FK_dbo_DeduccionEfectuada_3];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_DiaPagado_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiaPagado] DROP CONSTRAINT [FK_dbo_DiaPagado_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_DiaPagado_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiaPagado] DROP CONSTRAINT [FK_dbo_DiaPagado_3];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_PagoExtraordinario_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagoExtraordinario] DROP CONSTRAINT [FK_dbo_PagoExtraordinario_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_PagoFeriado_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagoFeriado] DROP CONSTRAINT [FK_dbo_PagoFeriado_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_PagoFeriado_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagoFeriado] DROP CONSTRAINT [FK_dbo_PagoFeriado_3];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_RemuneracionEfectuadaPF_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RemuneracionEfectuadaPF] DROP CONSTRAINT [FK_dbo_RemuneracionEfectuadaPF_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_RemuneracionEfectuadaPF_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RemuneracionEfectuadaPF] DROP CONSTRAINT [FK_dbo_RemuneracionEfectuadaPF_3];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UbicacionAsueto_2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAsueto] DROP CONSTRAINT [FK_dbo_UbicacionAsueto_2];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_UbicacionAsueto_3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAsueto] DROP CONSTRAINT [FK_dbo_UbicacionAsueto_3];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_DecretoComponentePresupuestario_ComponentePresupuestario]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[DecretoComponentePresupuestario] DROP CONSTRAINT [FK_DecretoComponentePresupuestario_ComponentePresupuestario];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_DecretoComponentePresupuestario_Decreto]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[DecretoComponentePresupuestario] DROP CONSTRAINT [FK_DecretoComponentePresupuestario_Decreto];
GO
IF OBJECT_ID(N'[dbo].[FK_DeduccionTemporal_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeduccionTemporal] DROP CONSTRAINT [FK_DeduccionTemporal_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DeduccionTemporal_TipoDeduccionTemporal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeduccionTemporal] DROP CONSTRAINT [FK_DeduccionTemporal_TipoDeduccionTemporal];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_Departamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_Departamento];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_DistritoContrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_DistritoContrato];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_DistritoPernocte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_DistritoPernocte];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_DistritoTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_DistritoTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_EstadoDesarraigo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_EstadoDesarraigo];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Desarraigo_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Desarraigo_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleAccionPersonal_AccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAccionPersonal] DROP CONSTRAINT [FK_DetalleAccionPersonal_AccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleAccionPersonal_DetallePuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAccionPersonal] DROP CONSTRAINT [FK_DetalleAccionPersonal_DetallePuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleAccionPersonalAnterior_AccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAccionPersonalAnterior] DROP CONSTRAINT [FK_DetalleAccionPersonalAnterior_AccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleAsignacionGastoTransporte_GastoTransporteRutas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAsignacionGastoTransporte] DROP CONSTRAINT [FK_DetalleAsignacionGastoTransporte_GastoTransporteRutas];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleAsignacionGastoTransporteModificada_GastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleAsignacionGastoTransporteModificada] DROP CONSTRAINT [FK_DetalleAsignacionGastoTransporteModificada_GastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleBorradorAccionPersonal_BorradorAccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleBorradorAccionPersonal] DROP CONSTRAINT [FK_DetalleBorradorAccionPersonal_BorradorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleBorradorAccionPersonal_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleBorradorAccionPersonal] DROP CONSTRAINT [FK_DetalleBorradorAccionPersonal_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleBorradorAccionPersonal_Programa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleBorradorAccionPersonal] DROP CONSTRAINT [FK_DetalleBorradorAccionPersonal_Programa];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleBorradorAccionPersonal_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleBorradorAccionPersonal] DROP CONSTRAINT [FK_DetalleBorradorAccionPersonal_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleBorradorAccionPersonal_TipoAccionPersonal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleBorradorAccionPersonal] DROP CONSTRAINT [FK_DetalleBorradorAccionPersonal_TipoAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionAutoEvaluacion_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionAutoEvaluacion] DROP CONSTRAINT [FK_DetalleCalificacionAutoEvaluacion_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionAutoEvaluacion_TipoAutoevaluacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionAutoEvaluacion] DROP CONSTRAINT [FK_DetalleCalificacionAutoEvaluacion_TipoAutoevaluacion];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionCompetencia_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionCompetencia] DROP CONSTRAINT [FK_DetalleCalificacionCompetencia_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionJefeColaborador_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionJefeColaborador] DROP CONSTRAINT [FK_DetalleCalificacionJefeColaborador_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionJefeColaborador_TipoCalJefeColaborador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionJefeColaborador] DROP CONSTRAINT [FK_DetalleCalificacionJefeColaborador_TipoCalJefeColaborador];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionMeta_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionMeta] DROP CONSTRAINT [FK_DetalleCalificacionMeta_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionMeta_MetaIndividualCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionMeta] DROP CONSTRAINT [FK_DetalleCalificacionMeta_MetaIndividualCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionModificada_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionModificada] DROP CONSTRAINT [FK_DetalleCalificacionModificada_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionModificada_CatalogoPregunta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionModificada] DROP CONSTRAINT [FK_DetalleCalificacionModificada_CatalogoPregunta];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionSeguimiento_CalificacionNombramientoFuncionarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionSeguimiento] DROP CONSTRAINT [FK_DetalleCalificacionSeguimiento_CalificacionNombramientoFuncionarios];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionSeguimiento_CatMetaEstado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionSeguimiento] DROP CONSTRAINT [FK_DetalleCalificacionSeguimiento_CatMetaEstado];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionSeguimiento_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionSeguimiento] DROP CONSTRAINT [FK_DetalleCalificacionSeguimiento_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionServicio_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionServicio] DROP CONSTRAINT [FK_DetalleCalificacionServicio_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCalificacionServicio_TipoCategoriaServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacionServicio] DROP CONSTRAINT [FK_DetalleCalificacionServicio_TipoCategoriaServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCambioPedimento_EstadoPedimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCambioPedimento] DROP CONSTRAINT [FK_DetalleCambioPedimento_EstadoPedimento];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleCambioPedimento_PedimentoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCambioPedimento] DROP CONSTRAINT [FK_DetalleCambioPedimento_PedimentoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleContratacion_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleContratacion] DROP CONSTRAINT [FK_DetalleContratacion_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleContratacion_TipoJornada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleContratacion] DROP CONSTRAINT [FK_DetalleContratacion_TipoJornada];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleDeduccionGastoTransporte_MovimientoGastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDeduccionGastoTransporte] DROP CONSTRAINT [FK_DetalleDeduccionGastoTransporte_MovimientoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleDeduccionViaticoCorrido_MovimientoViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDeduccionViaticoCorrido] DROP CONSTRAINT [FK_DetalleDeduccionViaticoCorrido_MovimientoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleDesarraigoEliminacion_Desarraigo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDesarraigoEliminacion] DROP CONSTRAINT [FK_DetalleDesarraigoEliminacion_Desarraigo];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleDesarraigoEliminacion_EstadoDesarraigo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDesarraigoEliminacion] DROP CONSTRAINT [FK_DetalleDesarraigoEliminacion_EstadoDesarraigo];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleDesgloseSalarial_ComponenteSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDesgloseSalarial] DROP CONSTRAINT [FK_DetalleDesgloseSalarial_ComponenteSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleDesgloseSalarial_DesgloseSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDesgloseSalarial] DROP CONSTRAINT [FK_DetalleDesgloseSalarial_DesgloseSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleEvaluacion_CalificacionNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacion] DROP CONSTRAINT [FK_DetalleEvaluacion_CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_detalleEvaluacion_CatalogoPreguntas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCalificacion] DROP CONSTRAINT [FK_detalleEvaluacion_CatalogoPreguntas];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleIncapacidad_RegistroIncapacidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleIncapacidad] DROP CONSTRAINT [FK_DetalleIncapacidad_RegistroIncapacidad];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePagoGastoTransporte_PagoGastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePagoGastoTransporte] DROP CONSTRAINT [FK_DetallePagoGastoTransporte_PagoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePagoGastoTransporte_TipoDetalleGastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePagoGastoTransporte] DROP CONSTRAINT [FK_DetallePagoGastoTransporte_TipoDetalleGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePagoViaticoCorrido_PagoViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePagoViaticoCorrido] DROP CONSTRAINT [FK_DetallePagoViaticoCorrido_PagoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePagoViaticoCorrido_TipoDetallePagoViatico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePagoViaticoCorrido] DROP CONSTRAINT [FK_DetallePagoViaticoCorrido_TipoDetallePagoViatico];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePagoViaticoRetroactivo_PagoViaticoRetroactivo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePagoViaticoRetroactivo] DROP CONSTRAINT [FK_DetallePagoViaticoRetroactivo_PagoViaticoRetroactivo];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePagoViaticoRetroactivo_TipoDetallePagoViatico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePagoViaticoRetroactivo] DROP CONSTRAINT [FK_DetallePagoViaticoRetroactivo_TipoDetallePagoViatico];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePrestacion_PrestacionLegal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePrestacion] DROP CONSTRAINT [FK_DetallePrestacion_PrestacionLegal];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePrestacionAfiliacion_PrestacionLegal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePrestacionAfiliacion] DROP CONSTRAINT [FK_DetallePrestacionAfiliacion_PrestacionLegal];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePrestacionCuadro_PrestacionLegal1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePrestacionCuadro] DROP CONSTRAINT [FK_DetallePrestacionCuadro_PrestacionLegal1];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePrestacionCuadro_TipoPrestacionCuadro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePrestacionCuadro] DROP CONSTRAINT [FK_DetallePrestacionCuadro_TipoPrestacionCuadro];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_Clase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_Clase];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_ContenidoPresupuestario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_ContenidoPresupuestario];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_Escala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_Escala];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_Especialidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_Especialidad];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_OcupacionReal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_OcupacionReal];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_Subespecialidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_Subespecialidad];
GO
IF OBJECT_ID(N'[dbo].[FK_detallePuesto_TipoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuesto] DROP CONSTRAINT [FK_detallePuesto_TipoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePuestoRubro_ComponenteSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuestoRubro] DROP CONSTRAINT [FK_DetallePuestoRubro_ComponenteSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePuestoRubro_DetallePuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePuestoRubro] DROP CONSTRAINT [FK_DetallePuestoRubro_DetallePuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleTiempoExtra_RegistroTiempoExtra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleTiempoExtra] DROP CONSTRAINT [FK_DetalleTiempoExtra_RegistroTiempoExtra];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleTiempoExtra_Tipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleTiempoExtra] DROP CONSTRAINT [FK_DetalleTiempoExtra_Tipo];
GO
IF OBJECT_ID(N'[dbo].[FK_Eje_Departamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategicoEje] DROP CONSTRAINT [FK_Eje_Departamento];
GO
IF OBJECT_ID(N'[dbo].[FK_Eje_PlanEstrategico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategicoEje] DROP CONSTRAINT [FK_Eje_PlanEstrategico];
GO
IF OBJECT_ID(N'[dbo].[FK_Eje_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategicoEje] DROP CONSTRAINT [FK_Eje_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_EliminacionGastoTransporte_MovimientoGastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte] DROP CONSTRAINT [FK_EliminacionGastoTransporte_MovimientoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_EliminacionViaticoCorrido_MovimientoViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte] DROP CONSTRAINT [FK_EliminacionViaticoCorrido_MovimientoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_EstadoCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EstadoCargo] DROP CONSTRAINT [FK_EstadoCargo_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_EstudidoPuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EstudioPuesto] DROP CONSTRAINT [FK_EstudidoPuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_EvidenciaComportamientoTransversal_ComportamientoTransversal]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EvidenciaComportamientoTransversal] DROP CONSTRAINT [FK_EvidenciaComportamientoTransversal_ComportamientoTransversal];
GO
IF OBJECT_ID(N'[dbo].[FK_EvidenciaGrupoOcupacional_ComportamientoGrupoOcupacional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EvidenciaGrupoOcupacional] DROP CONSTRAINT [FK_EvidenciaGrupoOcupacional_ComportamientoGrupoOcupacional];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpedienteFuncionario_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExpedienteFuncionario] DROP CONSTRAINT [FK_ExpedienteFuncionario_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_ExperienciaProfesional_FormacionAcademica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExperienciaProfesional] DROP CONSTRAINT [FK_ExperienciaProfesional_FormacionAcademica];
GO
IF OBJECT_ID(N'[dbo].[FK_Factor_TituloFactor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Factor] DROP CONSTRAINT [FK_Factor_TituloFactor];
GO
IF OBJECT_ID(N'[dbo].[FK_FactorClasificacionCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactorClasificacionCargo] DROP CONSTRAINT [FK_FactorClasificacionCargo_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaDesarraigo_Desarraigo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaDesarraigo] DROP CONSTRAINT [FK_FacturaDesarraigo_Desarraigo];
GO
IF OBJECT_ID(N'[dbo].[FK_Folio_Tomo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Folio] DROP CONSTRAINT [FK_Folio_Tomo];
GO
IF OBJECT_ID(N'[dbo].[FK_FormacionAcademica_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormacionAcademica] DROP CONSTRAINT [FK_FormacionAcademica_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_GastosTransporte_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporte] DROP CONSTRAINT [FK_GastosTransporte_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_GastosTransporteo_EstadosGastosTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporte] DROP CONSTRAINT [FK_GastosTransporteo_EstadosGastosTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTransporte_DistritoC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporte] DROP CONSTRAINT [FK_GastoTransporte_DistritoC];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTransporte_DistritoT]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporte] DROP CONSTRAINT [FK_GastoTransporte_DistritoT];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTransporte_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporte] DROP CONSTRAINT [FK_GastoTransporte_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTransporteReintegroDias_GastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporteReintegroDias] DROP CONSTRAINT [FK_GastoTransporteReintegroDias_GastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTransporteRutas_EstadoGastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporteRutas] DROP CONSTRAINT [FK_GastoTransporteRutas_EstadoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTransporteRutas_GastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GastoTransporteRutas] DROP CONSTRAINT [FK_GastoTransporteRutas_GastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_Incidencia_CatalogoIncidencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incidencia] DROP CONSTRAINT [FK_Incidencia_CatalogoIncidencia];
GO
IF OBJECT_ID(N'[dbo].[FK_Incidencia_FuncionarioEmisor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incidencia] DROP CONSTRAINT [FK_Incidencia_FuncionarioEmisor];
GO
IF OBJECT_ID(N'[dbo].[FK_Incidencia_FuncionarioUIRH]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incidencia] DROP CONSTRAINT [FK_Incidencia_FuncionarioUIRH];
GO
IF OBJECT_ID(N'[dbo].[FK_Linea_Eje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategicoLinea] DROP CONSTRAINT [FK_Linea_Eje];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_Departamento]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_Departamento];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_DetallePuesto]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_DetallePuesto];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_DireccionGeneral]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_DireccionGeneral];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_Division]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_Division];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_Funcionario];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_Nombramiento];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_Puesto];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[FK_ListaNombramientosActivos_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos] DROP CONSTRAINT [FK_ListaNombramientosActivos_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_CatMetaEstado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_CatMetaEstado];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_CatMetaNivel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_CatMetaNivel];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_CatMetaPrioridad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_CatMetaPrioridad];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_MetaIndividualCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_MetaIndividualCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_MetaObjetivoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_MetaObjetivoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualCalificacion_TipoIndicadorMeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualCalificacion] DROP CONSTRAINT [FK_MetaIndividualCalificacion_TipoIndicadorMeta];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualEvidencia_MetaIndividualCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualEvidencia] DROP CONSTRAINT [FK_MetaIndividualEvidencia_MetaIndividualCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaIndividualInforme_MetaIndividualCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaIndividualInforme] DROP CONSTRAINT [FK_MetaIndividualInforme_MetaIndividualCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaObjetivoCalificacion_ObjetivoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MetaObjetivoCalificacion] DROP CONSTRAINT [FK_MetaObjetivoCalificacion_ObjetivoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_MetaPlanInstitucional_ProductosPlanInstitucional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualMeta] DROP CONSTRAINT [FK_MetaPlanInstitucional_ProductosPlanInstitucional];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimientoGastosTransporte_GastosTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoGastoTransporte] DROP CONSTRAINT [FK_MovimientoGastosTransporte_GastosTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimientoPuesto_EstadoMovimientoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoPuesto] DROP CONSTRAINT [FK_MovimientoPuesto_EstadoMovimientoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimientoPuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoPuesto] DROP CONSTRAINT [FK_MovimientoPuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_MovimientosViaticoCorrido_ViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoViaticoCorrido] DROP CONSTRAINT [FK_MovimientosViaticoCorrido_ViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_Nombramiento_CartasPresentacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartasPresentacion] DROP CONSTRAINT [FK_Nombramiento_CartasPresentacion];
GO
IF OBJECT_ID(N'[dbo].[FK_Nombramiento_Desarraigo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Desarraigo] DROP CONSTRAINT [FK_Nombramiento_Desarraigo];
GO
IF OBJECT_ID(N'[dbo].[FK_Nombramiento_DesgloseSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DesgloseSalarial] DROP CONSTRAINT [FK_Nombramiento_DesgloseSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_Nombramiento_EstadoNombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nombramiento] DROP CONSTRAINT [FK_Nombramiento_EstadoNombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_Nombramiento_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nombramiento] DROP CONSTRAINT [FK_Nombramiento_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_Nombramiento_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nombramiento] DROP CONSTRAINT [FK_Nombramiento_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificacionUsuario_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotificacionUsuario] DROP CONSTRAINT [FK_NotificacionUsuario_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificacionUsuario_Usuario_Destino]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotificacionUsuario] DROP CONSTRAINT [FK_NotificacionUsuario_Usuario_Destino];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjetivoCalificacion_PeriodoCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjetivoCalificacion] DROP CONSTRAINT [FK_ObjetivoCalificacion_PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjetivoCalificacion_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjetivoCalificacion] DROP CONSTRAINT [FK_ObjetivoCalificacion_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjetoGasto_Partida]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjetoGasto] DROP CONSTRAINT [FK_ObjetoGasto_Partida];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjetoGasto_SubPartida]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ObjetoGasto] DROP CONSTRAINT [FK_ObjetoGasto_SubPartida];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenMovimiento_DetallePuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenMovimiento] DROP CONSTRAINT [FK_OrdenMovimiento_DetallePuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenMovimiento_EstadoOrdenMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenMovimiento] DROP CONSTRAINT [FK_OrdenMovimiento_EstadoOrdenMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenMovimiento_Funcionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenMovimiento] DROP CONSTRAINT [FK_OrdenMovimiento_Funcionario];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenMovimiento_PedimentoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenMovimiento] DROP CONSTRAINT [FK_OrdenMovimiento_PedimentoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenMovimiento_TipoMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenMovimiento] DROP CONSTRAINT [FK_OrdenMovimiento_TipoMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenMovimientoDeclaracion_OrdenMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenMovimientoDeclaracion] DROP CONSTRAINT [FK_OrdenMovimientoDeclaracion_OrdenMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_PagoGastosTransporte_GastoTransporte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagoGastoTransporte] DROP CONSTRAINT [FK_PagoGastosTransporte_GastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[FK_PagoViaticoCorrido_ViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagoViaticoCorrido] DROP CONSTRAINT [FK_PagoViaticoCorrido_ViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_PagoViaticoRetroactivo_PagoViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PagoViaticoRetroactivo] DROP CONSTRAINT [FK_PagoViaticoRetroactivo_PagoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_PedimentoPuesto_MotivoPedimento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedimentoPuesto] DROP CONSTRAINT [FK_PedimentoPuesto_MotivoPedimento];
GO
IF OBJECT_ID(N'[dbo].[FK_PedimentoPuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PedimentoPuesto] DROP CONSTRAINT [FK_PedimentoPuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Periodo_EscalaSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EscalaSalarial] DROP CONSTRAINT [FK_Periodo_EscalaSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodoVacaciones_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PeriodoVacaciones] DROP CONSTRAINT [FK_PeriodoVacaciones_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanAnualActividad_EstadoActividadPlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualActividad] DROP CONSTRAINT [FK_PlanAnualActividad_EstadoActividadPlan];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanAnualActividadFuncionario_PlanAnualActividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualActividadFuncionario] DROP CONSTRAINT [FK_PlanAnualActividadFuncionario_PlanAnualActividad];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanEstrategico_DireccionGeneral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategico] DROP CONSTRAINT [FK_PlanEstrategico_DireccionGeneral];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanEstrategico_EstadoPlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategico] DROP CONSTRAINT [FK_PlanEstrategico_EstadoPlan];
GO
IF OBJECT_ID(N'[dbo].[FK_Planilla_CatalogoDeduccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDeduccion] DROP CONSTRAINT [FK_Planilla_CatalogoDeduccion];
GO
IF OBJECT_ID(N'[dbo].[FK_Planilla_DesgloseSalarial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleDeduccion] DROP CONSTRAINT [FK_Planilla_DesgloseSalarial];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanInstitucional_EstadoPlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnual] DROP CONSTRAINT [FK_PlanInstitucional_EstadoPlan];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanInstitucional_PlanEstrategico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnual] DROP CONSTRAINT [FK_PlanInstitucional_PlanEstrategico];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanInstitucional_Seccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnual] DROP CONSTRAINT [FK_PlanInstitucional_Seccion];
GO
IF OBJECT_ID(N'[dbo].[FK_PrestacionLegal_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrestacionLegal] DROP CONSTRAINT [FK_PrestacionLegal_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_PrestacionLegal_TipoPrestacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrestacionLegal] DROP CONSTRAINT [FK_PrestacionLegal_TipoPrestacion];
GO
IF OBJECT_ID(N'[dbo].[FK_PrestamoPuesto_EntidadAdscrita]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrestamoPuesto] DROP CONSTRAINT [FK_PrestamoPuesto_EntidadAdscrita];
GO
IF OBJECT_ID(N'[dbo].[FK_PrestamoPuesto_EntidadGubernamental]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrestamoPuesto] DROP CONSTRAINT [FK_PrestamoPuesto_EntidadGubernamental];
GO
IF OBJECT_ID(N'[dbo].[FK_PrestamoPuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrestamoPuesto] DROP CONSTRAINT [FK_PrestamoPuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_PrestamoPuesto_UbicacionAdministrativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrestamoPuesto] DROP CONSTRAINT [FK_PrestamoPuesto_UbicacionAdministrativa];
GO
IF OBJECT_ID(N'[dbo].[FK_presupuesto_Programa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Presupuesto] DROP CONSTRAINT [FK_presupuesto_Programa];
GO
IF OBJECT_ID(N'[dbo].[FK_Producto_Linea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanEstrategicoProducto] DROP CONSTRAINT [FK_Producto_Linea];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductosPlanInstitucional_PlanInstitucional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualProductos] DROP CONSTRAINT [FK_ProductosPlanInstitucional_PlanInstitucional];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductosPlanInstitucional_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanAnualProductos] DROP CONSTRAINT [FK_ProductosPlanInstitucional_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_Puesto_EstadoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Puesto] DROP CONSTRAINT [FK_Puesto_EstadoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Puesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Puesto] DROP CONSTRAINT [FK_Puesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Puesto_UbicacionAdministrativa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Puesto] DROP CONSTRAINT [FK_Puesto_UbicacionAdministrativa];
GO
IF OBJECT_ID(N'[dbo].[FK_RegistroIncapacidad_TipoIncapacidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroIncapacidad] DROP CONSTRAINT [FK_RegistroIncapacidad_TipoIncapacidad];
GO
IF OBJECT_ID(N'[dbo].[FK_RegistroTiempoExtra_Clase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroTiempoExtra] DROP CONSTRAINT [FK_RegistroTiempoExtra_Clase];
GO
IF OBJECT_ID(N'[dbo].[FK_RegistroTiempoExtra_DesgloseSalarialQ1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroTiempoExtra] DROP CONSTRAINT [FK_RegistroTiempoExtra_DesgloseSalarialQ1];
GO
IF OBJECT_ID(N'[dbo].[FK_RegistroTiempoExtra_DesgloseSalarialQ2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroTiempoExtra] DROP CONSTRAINT [FK_RegistroTiempoExtra_DesgloseSalarialQ2];
GO
IF OBJECT_ID(N'[dbo].[FK_RegistroTiempoExtra_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroTiempoExtra] DROP CONSTRAINT [FK_RegistroTiempoExtra_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_RegistroVacaciones_PeriodoVacaciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroVacaciones] DROP CONSTRAINT [FK_RegistroVacaciones_PeriodoVacaciones];
GO
IF OBJECT_ID(N'[dbo].[FK_ReintegroVacaciones_RegistroVacaciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReintegroVacaciones] DROP CONSTRAINT [FK_ReintegroVacaciones_RegistroVacaciones];
GO
IF OBJECT_ID(N'[dbo].[FK_RelPuestoUbicacion_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelPuestoUbicacion] DROP CONSTRAINT [FK_RelPuestoUbicacion_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_RequerimientoEspecificoCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequerimientoEspecificoCargo] DROP CONSTRAINT [FK_RequerimientoEspecificoCargo_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_Rescision_PrestamoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rescision] DROP CONSTRAINT [FK_Rescision_PrestamoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Resolucion_PedimentoPuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResolucionPedimento] DROP CONSTRAINT [FK_Resolucion_PedimentoPuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_Resolucion_TipoResolucion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResolucionPedimento] DROP CONSTRAINT [FK_Resolucion_TipoResolucion];
GO
IF OBJECT_ID(N'[dbo].[FK_ResultadoCargo_Cargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResultadoCargo] DROP CONSTRAINT [FK_ResultadoCargo_Cargo];
GO
IF OBJECT_ID(N'[dbo].[FK_SubPartida_Partida]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubPartida] DROP CONSTRAINT [FK_SubPartida_Partida];
GO
IF OBJECT_ID(N'[dbo].[FK_TareasPuesto_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TareasPuesto] DROP CONSTRAINT [FK_TareasPuesto_Puesto];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoIncapacidad_EntidadMedica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoIncapacidad] DROP CONSTRAINT [FK_TipoIncapacidad_EntidadMedica];
GO
IF OBJECT_ID(N'[dbo].[FK_Tomo_ExpedienteFuncionario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tomo] DROP CONSTRAINT [FK_Tomo_ExpedienteFuncionario];
GO
IF OBJECT_ID(N'[dbo].[FK_Ubicacion_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UbicacionAdministrativa] DROP CONSTRAINT [FK_Ubicacion_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_Contrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorrido] DROP CONSTRAINT [FK_ViaticoCorrido_Contrato];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_Ditrito]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorrido] DROP CONSTRAINT [FK_ViaticoCorrido_Ditrito];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_EstadoViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorrido] DROP CONSTRAINT [FK_ViaticoCorrido_EstadoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorrido] DROP CONSTRAINT [FK_ViaticoCorrido_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_Presupuesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorrido] DROP CONSTRAINT [FK_ViaticoCorrido_Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_Trabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorrido] DROP CONSTRAINT [FK_ViaticoCorrido_Trabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorrido_ViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContratoArrendamiento] DROP CONSTRAINT [FK_ViaticoCorrido_ViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_ViaticoCorridoReintegroDias_ViaticoCorrido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViaticoCorridoReintegroDias] DROP CONSTRAINT [FK_ViaticoCorridoReintegroDias_ViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[FK_PK_RegistroIncapacidad_Nombramiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroIncapacidad] DROP CONSTRAINT [FK_PK_RegistroIncapacidad_Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[FK_Rel_CuentaBancaria_EntidadFinanciera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaBancaria] DROP CONSTRAINT [FK_Rel_CuentaBancaria_EntidadFinanciera];
GO
IF OBJECT_ID(N'[dbo].[FK_Rel_MovimientoPuesto_MotivoMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoPuesto] DROP CONSTRAINT [FK_Rel_MovimientoPuesto_MotivoMovimiento];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[_EMU_AccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_AccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[_EMU_Calificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_Calificacion];
GO
IF OBJECT_ID(N'[dbo].[_EMU_CarreraProfesional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_CarreraProfesional];
GO
IF OBJECT_ID(N'[dbo].[_EMU_Cursos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_Cursos];
GO
IF OBJECT_ID(N'[dbo].[_EMU_HistoricoPlanilla_oldie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_HistoricoPlanilla_oldie];
GO
IF OBJECT_ID(N'[dbo].[_EMU_Puntos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_Puntos];
GO
IF OBJECT_ID(N'[dbo].[_EMU_Vacaciones_Movimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_Vacaciones_Movimiento];
GO
IF OBJECT_ID(N'[dbo].[_EMU_Vacaciones_Saldo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_EMU_Vacaciones_Saldo];
GO
IF OBJECT_ID(N'[dbo].[_ViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[_ViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[AccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[ActividadFuncionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActividadFuncionario];
GO
IF OBJECT_ID(N'[dbo].[ActividadResultadoCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActividadResultadoCargo];
GO
IF OBJECT_ID(N'[dbo].[AddendumPrestamoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddendumPrestamoPuesto];
GO
IF OBJECT_ID(N'[dbo].[BitacoraIncidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BitacoraIncidencia];
GO
IF OBJECT_ID(N'[dbo].[BitacoraUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BitacoraUsuario];
GO
IF OBJECT_ID(N'[dbo].[BoletaPrestamo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BoletaPrestamo];
GO
IF OBJECT_ID(N'[dbo].[BorradorAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BorradorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[BotAccionIncidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BotAccionIncidencia];
GO
IF OBJECT_ID(N'[dbo].[Calificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Calificacion];
GO
IF OBJECT_ID(N'[dbo].[CalificacionAutoEvaluacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionAutoEvaluacion];
GO
IF OBJECT_ID(N'[dbo].[CalificacionCapacitacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionCapacitacion];
GO
IF OBJECT_ID(N'[dbo].[CalificacionCompromiso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionCompromiso];
GO
IF OBJECT_ID(N'[dbo].[CalificacionEncargado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionEncargado];
GO
IF OBJECT_ID(N'[dbo].[CalificacionJefeColaborador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionJefeColaborador];
GO
IF OBJECT_ID(N'[dbo].[CalificacionNombramiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionNombramiento];
GO
IF OBJECT_ID(N'[dbo].[CalificacionNombramientoFuncionarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionNombramientoFuncionarios];
GO
IF OBJECT_ID(N'[dbo].[CalificacionObservaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionObservaciones];
GO
IF OBJECT_ID(N'[dbo].[CalificacionReglaTecnica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionReglaTecnica];
GO
IF OBJECT_ID(N'[dbo].[CalificacionServicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionServicio];
GO
IF OBJECT_ID(N'[dbo].[CambioPorAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CambioPorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[Canton]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Canton];
GO
IF OBJECT_ID(N'[dbo].[CaracteristicasPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CaracteristicasPuesto];
GO
IF OBJECT_ID(N'[dbo].[Cargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cargo];
GO
IF OBJECT_ID(N'[dbo].[CartasPresentacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CartasPresentacion];
GO
IF OBJECT_ID(N'[dbo].[CatalogoDeduccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatalogoDeduccion];
GO
IF OBJECT_ID(N'[dbo].[CatalogoDia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatalogoDia];
GO
IF OBJECT_ID(N'[dbo].[CatalogoIncidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatalogoIncidencia];
GO
IF OBJECT_ID(N'[dbo].[CatalogoPregunta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatalogoPregunta];
GO
IF OBJECT_ID(N'[dbo].[CatalogoRemuneracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatalogoRemuneracion];
GO
IF OBJECT_ID(N'[dbo].[CatAnioAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatAnioAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[CatAnioBoletaPrestamo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatAnioBoletaPrestamo];
GO
IF OBJECT_ID(N'[dbo].[CatCalificacionCompetencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatCalificacionCompetencias];
GO
IF OBJECT_ID(N'[dbo].[CatCampo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatCampo];
GO
IF OBJECT_ID(N'[dbo].[CatDiaViaticoGasto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatDiaViaticoGasto];
GO
IF OBJECT_ID(N'[dbo].[CatEstadoCivil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatEstadoCivil];
GO
IF OBJECT_ID(N'[dbo].[CatMetaEstado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatMetaEstado];
GO
IF OBJECT_ID(N'[dbo].[CatMetaNivel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatMetaNivel];
GO
IF OBJECT_ID(N'[dbo].[CatMetaPrioridad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatMetaPrioridad];
GO
IF OBJECT_ID(N'[dbo].[CatMovimientoPresupuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatMovimientoPresupuesto];
GO
IF OBJECT_ID(N'[dbo].[CatOrdenMovimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatOrdenMovimiento];
GO
IF OBJECT_ID(N'[dbo].[CatPermiso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatPermiso];
GO
IF OBJECT_ID(N'[dbo].[CatPermisoEvidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CatPermisoEvidencia];
GO
IF OBJECT_ID(N'[dbo].[Caucion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Caucion];
GO
IF OBJECT_ID(N'[dbo].[Clase]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clase];
GO
IF OBJECT_ID(N'[dbo].[CompetenciaGrupoOcupacional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetenciaGrupoOcupacional];
GO
IF OBJECT_ID(N'[dbo].[CompetenciaTransversalCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetenciaTransversalCargo];
GO
IF OBJECT_ID(N'[dbo].[ComponentePresupuestario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComponentePresupuestario];
GO
IF OBJECT_ID(N'[dbo].[ComponenteSalarial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComponenteSalarial];
GO
IF OBJECT_ID(N'[dbo].[ComportamientoGrupoOcupacional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComportamientoGrupoOcupacional];
GO
IF OBJECT_ID(N'[dbo].[ComportamientoTransversal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComportamientoTransversal];
GO
IF OBJECT_ID(N'[dbo].[ContenidoPresupuestario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContenidoPresupuestario];
GO
IF OBJECT_ID(N'[dbo].[ContratoArrendamiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContratoArrendamiento];
GO
IF OBJECT_ID(N'[dbo].[CuentaBancaria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaBancaria];
GO
IF OBJECT_ID(N'[dbo].[CursoCapacitacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursoCapacitacion];
GO
IF OBJECT_ID(N'[dbo].[CursoGrado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursoGrado];
GO
IF OBJECT_ID(N'[dbo].[Decreto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Decreto];
GO
IF OBJECT_ID(N'[dbo].[DeduccionEfectuada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeduccionEfectuada];
GO
IF OBJECT_ID(N'[dbo].[DeduccionTemporal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeduccionTemporal];
GO
IF OBJECT_ID(N'[dbo].[Departamento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamento];
GO
IF OBJECT_ID(N'[dbo].[Desarraigo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Desarraigo];
GO
IF OBJECT_ID(N'[dbo].[DesgloseSalarial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DesgloseSalarial];
GO
IF OBJECT_ID(N'[dbo].[DetalleAcceso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleAcceso];
GO
IF OBJECT_ID(N'[dbo].[DetalleAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[DetalleAccionPersonalAnterior]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleAccionPersonalAnterior];
GO
IF OBJECT_ID(N'[dbo].[DetalleAsignacionGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleAsignacionGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[DetalleAsignacionGastoTransporteModificada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleAsignacionGastoTransporteModificada];
GO
IF OBJECT_ID(N'[dbo].[DetalleBoleta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleBoleta];
GO
IF OBJECT_ID(N'[dbo].[DetalleBorradorAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleBorradorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacion];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionAutoEvaluacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionAutoEvaluacion];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionCompetencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionCompetencia];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionJefeColaborador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionJefeColaborador];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionMeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionMeta];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionModificada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionModificada];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionSeguimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionSeguimiento];
GO
IF OBJECT_ID(N'[dbo].[DetalleCalificacionServicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCalificacionServicio];
GO
IF OBJECT_ID(N'[dbo].[DetalleCambioPedimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCambioPedimento];
GO
IF OBJECT_ID(N'[dbo].[DetalleContratacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleContratacion];
GO
IF OBJECT_ID(N'[dbo].[DetalleDeduccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleDeduccion];
GO
IF OBJECT_ID(N'[dbo].[DetalleDeduccionGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleDeduccionGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[DetalleDeduccionViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleDeduccionViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[DetalleDesarraigoEliminacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleDesarraigoEliminacion];
GO
IF OBJECT_ID(N'[dbo].[DetalleDesgloseSalarial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleDesgloseSalarial];
GO
IF OBJECT_ID(N'[dbo].[DetalleEliminacionViaticoCorridoGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[DetalleIncapacidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleIncapacidad];
GO
IF OBJECT_ID(N'[dbo].[DetallePagoGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePagoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[DetallePagoViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePagoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[DetallePagoViaticoRetroactivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePagoViaticoRetroactivo];
GO
IF OBJECT_ID(N'[dbo].[DetallePrestacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePrestacion];
GO
IF OBJECT_ID(N'[dbo].[DetallePrestacionAfiliacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePrestacionAfiliacion];
GO
IF OBJECT_ID(N'[dbo].[DetallePrestacionCuadro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePrestacionCuadro];
GO
IF OBJECT_ID(N'[dbo].[DetallePuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePuesto];
GO
IF OBJECT_ID(N'[dbo].[DetallePuestoRubro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePuestoRubro];
GO
IF OBJECT_ID(N'[dbo].[DetallePuntosAdicional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePuntosAdicional];
GO
IF OBJECT_ID(N'[dbo].[DetalleTiempoExtra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleTiempoExtra];
GO
IF OBJECT_ID(N'[dbo].[DiaPagado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiaPagado];
GO
IF OBJECT_ID(N'[dbo].[Direccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Direccion];
GO
IF OBJECT_ID(N'[dbo].[DireccionGeneral]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DireccionGeneral];
GO
IF OBJECT_ID(N'[dbo].[Distrito]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Distrito];
GO
IF OBJECT_ID(N'[dbo].[Division]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Division];
GO
IF OBJECT_ID(N'[dbo].[EntidadAdscrita]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntidadAdscrita];
GO
IF OBJECT_ID(N'[dbo].[EntidadEducativa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntidadEducativa];
GO
IF OBJECT_ID(N'[dbo].[EntidadFinanciera]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntidadFinanciera];
GO
IF OBJECT_ID(N'[dbo].[EntidadGubernamental]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntidadGubernamental];
GO
IF OBJECT_ID(N'[dbo].[EntidadMedica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntidadMedica];
GO
IF OBJECT_ID(N'[dbo].[EntidadSeguros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntidadSeguros];
GO
IF OBJECT_ID(N'[dbo].[EscalaSalarial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EscalaSalarial];
GO
IF OBJECT_ID(N'[dbo].[Especialidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Especialidad];
GO
IF OBJECT_ID(N'[dbo].[EstadoActividadPlan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoActividadPlan];
GO
IF OBJECT_ID(N'[dbo].[EstadoBorrador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoBorrador];
GO
IF OBJECT_ID(N'[dbo].[EstadoCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoCargo];
GO
IF OBJECT_ID(N'[dbo].[EstadoDesarraigo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoDesarraigo];
GO
IF OBJECT_ID(N'[dbo].[EstadoFuncionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoFuncionario];
GO
IF OBJECT_ID(N'[dbo].[EstadoGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[EstadoMovimientoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoMovimientoPuesto];
GO
IF OBJECT_ID(N'[dbo].[EstadoNombramiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoNombramiento];
GO
IF OBJECT_ID(N'[dbo].[EstadoOrdenMovimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoOrdenMovimiento];
GO
IF OBJECT_ID(N'[dbo].[EstadoPedimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoPedimento];
GO
IF OBJECT_ID(N'[dbo].[EstadoPlan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoPlan];
GO
IF OBJECT_ID(N'[dbo].[EstadoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoPuesto];
GO
IF OBJECT_ID(N'[dbo].[EstadoTipoJornada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoTipoJornada];
GO
IF OBJECT_ID(N'[dbo].[EstadoTramite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoTramite];
GO
IF OBJECT_ID(N'[dbo].[EstadoViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[EstudioPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstudioPuesto];
GO
IF OBJECT_ID(N'[dbo].[EvidenciaComportamientoTransversal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EvidenciaComportamientoTransversal];
GO
IF OBJECT_ID(N'[dbo].[EvidenciaGrupoOcupacional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EvidenciaGrupoOcupacional];
GO
IF OBJECT_ID(N'[dbo].[ExpedienteFuncionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpedienteFuncionario];
GO
IF OBJECT_ID(N'[dbo].[ExperienciaProfesional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExperienciaProfesional];
GO
IF OBJECT_ID(N'[dbo].[Factor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Factor];
GO
IF OBJECT_ID(N'[dbo].[FactorClasificacionCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactorClasificacionCargo];
GO
IF OBJECT_ID(N'[dbo].[FacturaDesarraigo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacturaDesarraigo];
GO
IF OBJECT_ID(N'[dbo].[FamiliaPuestos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FamiliaPuestos];
GO
IF OBJECT_ID(N'[dbo].[Folio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Folio];
GO
IF OBJECT_ID(N'[dbo].[FormacionAcademica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormacionAcademica];
GO
IF OBJECT_ID(N'[dbo].[Funcionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Funcionario];
GO
IF OBJECT_ID(N'[dbo].[GastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[GastoTransporteReintegroDias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GastoTransporteReintegroDias];
GO
IF OBJECT_ID(N'[dbo].[GastoTransporteRutas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GastoTransporteRutas];
GO
IF OBJECT_ID(N'[dbo].[HistorialEstadoCivil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HistorialEstadoCivil];
GO
IF OBJECT_ID(N'[dbo].[Incidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Incidencia];
GO
IF OBJECT_ID(N'[dbo].[InformacionContacto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InformacionContacto];
GO
IF OBJECT_ID(N'[dbo].[MetaIndividualCalificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MetaIndividualCalificacion];
GO
IF OBJECT_ID(N'[dbo].[MetaIndividualEvidencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MetaIndividualEvidencia];
GO
IF OBJECT_ID(N'[dbo].[MetaIndividualInforme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MetaIndividualInforme];
GO
IF OBJECT_ID(N'[dbo].[MetaObjetivoCalificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MetaObjetivoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[Modalidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modalidad];
GO
IF OBJECT_ID(N'[dbo].[MontoCaucion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MontoCaucion];
GO
IF OBJECT_ID(N'[dbo].[MotivoMovimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MotivoMovimiento];
GO
IF OBJECT_ID(N'[dbo].[MotivoPedimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MotivoPedimento];
GO
IF OBJECT_ID(N'[dbo].[MovimientoBorradorAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovimientoBorradorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[MovimientoGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovimientoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[MovimientoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovimientoPuesto];
GO
IF OBJECT_ID(N'[dbo].[MovimientoViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovimientoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[Nombramiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nombramiento];
GO
IF OBJECT_ID(N'[dbo].[NotificacionUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NotificacionUsuario];
GO
IF OBJECT_ID(N'[dbo].[ObjetivoCalificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjetivoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[ObjetoGasto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ObjetoGasto];
GO
IF OBJECT_ID(N'[dbo].[OcupacionReal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OcupacionReal];
GO
IF OBJECT_ID(N'[dbo].[OrdenMovimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdenMovimiento];
GO
IF OBJECT_ID(N'[dbo].[OrdenMovimientoDeclaracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdenMovimientoDeclaracion];
GO
IF OBJECT_ID(N'[dbo].[PagoExtraordinario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagoExtraordinario];
GO
IF OBJECT_ID(N'[dbo].[PagoFeriado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagoFeriado];
GO
IF OBJECT_ID(N'[dbo].[PagoGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagoGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[PagoPrestacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagoPrestacion];
GO
IF OBJECT_ID(N'[dbo].[PagoViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagoViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[PagoViaticoRetroactivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PagoViaticoRetroactivo];
GO
IF OBJECT_ID(N'[dbo].[Partida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Partida];
GO
IF OBJECT_ID(N'[dbo].[PedimentoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PedimentoPuesto];
GO
IF OBJECT_ID(N'[dbo].[Perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfil];
GO
IF OBJECT_ID(N'[dbo].[PerfilAcceso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilAcceso];
GO
IF OBJECT_ID(N'[dbo].[PeriodoCalificacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodoCalificacion];
GO
IF OBJECT_ID(N'[dbo].[PeriodoEscalaSalarial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodoEscalaSalarial];
GO
IF OBJECT_ID(N'[dbo].[PeriodoVacaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodoVacaciones];
GO
IF OBJECT_ID(N'[dbo].[PlanAnual]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanAnual];
GO
IF OBJECT_ID(N'[dbo].[PlanAnualActividad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanAnualActividad];
GO
IF OBJECT_ID(N'[dbo].[PlanAnualActividadAvance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanAnualActividadAvance];
GO
IF OBJECT_ID(N'[dbo].[PlanAnualActividadFuncionario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanAnualActividadFuncionario];
GO
IF OBJECT_ID(N'[dbo].[PlanAnualMeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanAnualMeta];
GO
IF OBJECT_ID(N'[dbo].[PlanAnualProductos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanAnualProductos];
GO
IF OBJECT_ID(N'[dbo].[PlanEstrategico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEstrategico];
GO
IF OBJECT_ID(N'[dbo].[PlanEstrategicoAccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEstrategicoAccion];
GO
IF OBJECT_ID(N'[dbo].[PlanEstrategicoEje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEstrategicoEje];
GO
IF OBJECT_ID(N'[dbo].[PlanEstrategicoLinea]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEstrategicoLinea];
GO
IF OBJECT_ID(N'[dbo].[PlanEstrategicoProducto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanEstrategicoProducto];
GO
IF OBJECT_ID(N'[dbo].[PrestacionLegal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrestacionLegal];
GO
IF OBJECT_ID(N'[dbo].[PrestamoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrestamoPuesto];
GO
IF OBJECT_ID(N'[dbo].[Presupuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Presupuesto];
GO
IF OBJECT_ID(N'[dbo].[Programa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Programa];
GO
IF OBJECT_ID(N'[dbo].[Provincia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provincia];
GO
IF OBJECT_ID(N'[dbo].[Puesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Puesto];
GO
IF OBJECT_ID(N'[dbo].[RegistroIncapacidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroIncapacidad];
GO
IF OBJECT_ID(N'[dbo].[RegistroPrestacionReal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroPrestacionReal];
GO
IF OBJECT_ID(N'[dbo].[RegistroTiempoExtra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroTiempoExtra];
GO
IF OBJECT_ID(N'[dbo].[RegistroVacaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroVacaciones];
GO
IF OBJECT_ID(N'[dbo].[ReintegroVacaciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReintegroVacaciones];
GO
IF OBJECT_ID(N'[dbo].[RelPuestoUbicacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelPuestoUbicacion];
GO
IF OBJECT_ID(N'[dbo].[RemuneracionEfectuadaPF]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RemuneracionEfectuadaPF];
GO
IF OBJECT_ID(N'[dbo].[RequerimientoEspecificoCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequerimientoEspecificoCargo];
GO
IF OBJECT_ID(N'[dbo].[Rescision]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rescision];
GO
IF OBJECT_ID(N'[dbo].[ResolucionPedimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResolucionPedimento];
GO
IF OBJECT_ID(N'[dbo].[ResultadoCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResultadoCargo];
GO
IF OBJECT_ID(N'[dbo].[Seccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Seccion];
GO
IF OBJECT_ID(N'[dbo].[SubEspecialidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubEspecialidad];
GO
IF OBJECT_ID(N'[dbo].[SubPartida]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubPartida];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TareasPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TareasPuesto];
GO
IF OBJECT_ID(N'[dbo].[TEMP_EnviarCorreo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TEMP_EnviarCorreo];
GO
IF OBJECT_ID(N'[dbo].[TipoAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[TipoAutoevaluacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoAutoevaluacion];
GO
IF OBJECT_ID(N'[dbo].[TipoCalificacionCompetencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCalificacionCompetencia];
GO
IF OBJECT_ID(N'[dbo].[TipoCalJefeColaborador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCalJefeColaborador];
GO
IF OBJECT_ID(N'[dbo].[TipoCambioPorAccionPersonal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCambioPorAccionPersonal];
GO
IF OBJECT_ID(N'[dbo].[TipoCategoriaServicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoCategoriaServicio];
GO
IF OBJECT_ID(N'[dbo].[TipoContacto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoContacto];
GO
IF OBJECT_ID(N'[dbo].[TipoDeduccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDeduccion];
GO
IF OBJECT_ID(N'[dbo].[TipoDeduccionTemporal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDeduccionTemporal];
GO
IF OBJECT_ID(N'[dbo].[TipoDetalleGastoTransporte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDetalleGastoTransporte];
GO
IF OBJECT_ID(N'[dbo].[TipoDetallePagoViatico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDetallePagoViatico];
GO
IF OBJECT_ID(N'[dbo].[TipoDia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDia];
GO
IF OBJECT_ID(N'[dbo].[TipoExtra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoExtra];
GO
IF OBJECT_ID(N'[dbo].[TipoIncapacidad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoIncapacidad];
GO
IF OBJECT_ID(N'[dbo].[TipoIndicadorMeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoIndicadorMeta];
GO
IF OBJECT_ID(N'[dbo].[TipoJornada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoJornada];
GO
IF OBJECT_ID(N'[dbo].[TipoPoliticaPublica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPoliticaPublica];
GO
IF OBJECT_ID(N'[dbo].[TipoPrestacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPrestacion];
GO
IF OBJECT_ID(N'[dbo].[TipoPrestacionCuadro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPrestacionCuadro];
GO
IF OBJECT_ID(N'[dbo].[TipoPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPuesto];
GO
IF OBJECT_ID(N'[dbo].[TipoResolucionPedimento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoResolucionPedimento];
GO
IF OBJECT_ID(N'[dbo].[TipoUbicacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoUbicacion];
GO
IF OBJECT_ID(N'[dbo].[TituloFactor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TituloFactor];
GO
IF OBJECT_ID(N'[dbo].[Tomo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tomo];
GO
IF OBJECT_ID(N'[dbo].[UbicacionAdministrativa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UbicacionAdministrativa];
GO
IF OBJECT_ID(N'[dbo].[UbicacionAsueto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UbicacionAsueto];
GO
IF OBJECT_ID(N'[dbo].[UbicacionPuesto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UbicacionPuesto];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[ViaticoCorrido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ViaticoCorrido];
GO
IF OBJECT_ID(N'[dbo].[ViaticoCorridoReintegroDias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ViaticoCorridoReintegroDias];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[_Componentes]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[_Componentes];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[_EMU_EXFUNCIONARIOS]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[_EMU_EXFUNCIONARIOS];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[_EMU_HistoricoPlanilla]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[_EMU_HistoricoPlanilla];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[_InicioPlanilla]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[_InicioPlanilla];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[_Planilla_Anterior]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[_Planilla_Anterior];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[_planillacargar]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[_planillacargar];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[DecretoComponentePresupuestario]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[DecretoComponentePresupuestario];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[ListaNombramientosActivos]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[ListaNombramientosActivos];
GO
IF OBJECT_ID(N'[SIRHModelStoreContainer].[Mes]', 'U') IS NOT NULL
    DROP TABLE [SIRHModelStoreContainer].[Mes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C_EMU_AccionPersonal'
CREATE TABLE [dbo].[C_EMU_AccionPersonal] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [NumAccion] varchar(10)  NOT NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [CodAccion] int  NULL,
    [Explicacion] varchar(300)  NULL,
    [Cedula] varchar(10)  NULL,
    [NumPuesto1] varchar(10)  NULL,
    [NumPuesto2] varchar(10)  NULL,
    [Categoria1] varchar(10)  NULL,
    [Categoria2] varchar(10)  NULL,
    [Clase1] varchar(10)  NULL,
    [Clase2] varchar(10)  NULL,
    [Salario1] decimal(18,2)  NULL,
    [Aumentos1] decimal(18,2)  NULL,
    [Recargo1] decimal(18,2)  NULL,
    [Grupo1] decimal(18,2)  NULL,
    [Prohibicion1] decimal(18,2)  NULL,
    [Otros1] decimal(18,2)  NULL,
    [Salario2] decimal(18,2)  NULL,
    [Aumentos2] decimal(18,2)  NULL,
    [Recargo2] decimal(18,2)  NULL,
    [Grupo2] decimal(18,2)  NULL,
    [Prohibicion2] decimal(18,2)  NULL,
    [Otros2] decimal(18,2)  NULL,
    [Disfrutado1] int  NULL,
    [Autorizado1] int  NULL,
    [Disfrutado2] int  NULL,
    [Autorizado2] int  NULL,
    [FK_Nombramiento] int  NULL,
    [CodAdministrativo] varchar(20)  NULL,
    [CodTitulo1] varchar(10)  NULL,
    [CodSeccion1] varchar(10)  NULL,
    [CodClase1] varchar(10)  NULL,
    [CodTitulo2] varchar(10)  NULL,
    [CodSeccion2] varchar(10)  NULL,
    [CodClase2] varchar(10)  NULL,
    [Explicacion1] varchar(500)  NULL
);
GO

-- Creating table 'C_EMU_Calificacion'
CREATE TABLE [dbo].[C_EMU_Calificacion] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Cedula] varchar(10)  NULL,
    [Periodo] varchar(10)  NULL,
    [Calificacion] smallint  NULL,
    [DesCalificacion] varchar(20)  NULL,
    [Nota] decimal(18,2)  NULL,
    [DesJustificacion] varchar(1000)  NULL,
    [IndPolicia] bit  NOT NULL,
    [IndFormulario] int  NOT NULL
);
GO

-- Creating table 'C_EMU_HistoricoPlanilla_oldie'
CREATE TABLE [dbo].[C_EMU_HistoricoPlanilla_oldie] (
    [ID] int  NOT NULL,
    [CEDULA] nvarchar(max)  NULL,
    [CODIGO_PRESUPUESTARIO] nvarchar(max)  NULL,
    [CATEGORIA] nvarchar(max)  NULL,
    [NUMERO_PUESTO] nvarchar(max)  NULL,
    [CLASE_PUESTO] nvarchar(max)  NULL,
    [BASE] decimal(18,2)  NULL,
    [AUMENTOS] decimal(18,2)  NULL,
    [GRUPO] decimal(18,2)  NULL,
    [SOBRESUELDOS] decimal(18,2)  NULL,
    [PROHIBICION] decimal(18,2)  NULL,
    [RECARGO] decimal(18,2)  NULL,
    [EMBARGO] decimal(18,2)  NULL,
    [OTROS] decimal(18,2)  NULL,
    [PSS_SUS] decimal(18,2)  NULL,
    [SAL_MENSUAL] decimal(18,2)  NULL,
    [TOT_SALARIO] decimal(18,2)  NULL,
    [RUTA] nvarchar(max)  NULL,
    [FECHA_CORRIDA] nvarchar(max)  NULL,
    [FECHA_PERIODO] nvarchar(max)  NULL,
    [NUMERO_GIRO] nvarchar(max)  NULL,
    [ZONAJE] decimal(18,2)  NULL,
    [CANT_PUNTOS] decimal(18,2)  NULL,
    [PORC_DEDICACION] decimal(18,2)  NULL,
    [PORC_PELIGROSIDAD] decimal(18,2)  NULL,
    [PORC_PROHIBICION] decimal(18,2)  NULL,
    [PORC_QUINQUENIO] decimal(18,2)  NULL,
    [PORC_DISPONIBILIDAD] decimal(18,2)  NULL,
    [PORC_GRADO_ACADEMICO] decimal(18,2)  NULL,
    [PORC_RIESGO_POLICIAL] decimal(18,2)  NULL,
    [PORC_CURSO_BASICO] decimal(18,2)  NULL,
    [PORC_INSTRUCCION] decimal(18,2)  NULL,
    [PORC_BONIFICACION] decimal(18,2)  NULL,
    [PORC_CONSULTA_EXTERNA] decimal(18,2)  NULL,
    [DEDICACION_EXCLUSIVA] decimal(18,2)  NULL,
    [PELIGROSIDAD] decimal(18,2)  NULL,
    [GRADO_ACADEMICO] decimal(18,2)  NULL,
    [DISPONIBILIDAD] decimal(18,2)  NULL,
    [QUINQUENIO] decimal(18,2)  NULL,
    [RIESGO_POLICIAL] decimal(18,2)  NULL,
    [CURSO_BASICO] decimal(18,2)  NULL,
    [INSTRUCCION] decimal(18,2)  NULL,
    [CONSULTA_EXTERNA] decimal(18,2)  NULL,
    [DESARRAIGO] decimal(18,2)  NULL,
    [BONIFICACION] decimal(18,2)  NULL,
    [OTROS_INCENTIVOS] decimal(18,2)  NULL,
    [DIVISION] nvarchar(50)  NULL,
    [DIRECCION] nvarchar(50)  NULL,
    [DEPARTAMENTO] nvarchar(50)  NULL,
    [SECCION] nvarchar(50)  NULL
);
GO

-- Creating table 'C_EMU_Vacaciones_Movimiento'
CREATE TABLE [dbo].[C_EMU_Vacaciones_Movimiento] (
    [ID] int  NOT NULL,
    [TIPO_REG] varchar(10)  NULL,
    [CEDULA] varchar(10)  NOT NULL,
    [TRANSACCION] varchar(10)  NULL,
    [PERI_TRAN] varchar(20)  NULL,
    [DIAS] varchar(10)  NOT NULL,
    [DOCUMENTO] varchar(20)  NULL,
    [FECHA_RIGE] datetime  NULL,
    [FECHA_VENCE] datetime  NULL,
    [FEC_ACT] datetime  NULL,
    [ESTADO] varchar(10)  NULL,
    [CEDULA_SOLICITANTE] varchar(10)  NULL,
    [CEDULA_JEFATURA] varchar(10)  NULL,
    [CEDULA_REC_HUMANOS] varchar(10)  NULL,
    [FEC_SOLICITUD] datetime  NULL,
    [TIPO_SOLICITUD] varchar(10)  NULL,
    [FECHA_ACT_K] datetime  NULL
);
GO

-- Creating table 'C_EMU_Vacaciones_Saldo'
CREATE TABLE [dbo].[C_EMU_Vacaciones_Saldo] (
    [ID] int  NOT NULL,
    [CEDULA] varchar(10)  NOT NULL,
    [PERI_VACA] varchar(10)  NULL,
    [SALDO] varchar(10)  NULL,
    [FRAC_VACA] varchar(10)  NULL,
    [DOCU_VACA] varchar(10)  NULL
);
GO

-- Creating table 'C_ViaticoCorrido'
CREATE TABLE [dbo].[C_ViaticoCorrido] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Cedula] varchar(10)  NULL,
    [TipoMov] int  NOT NULL,
    [Gasto] int  NULL,
    [Codigo] int  NULL,
    [MesProceso] int  NULL,
    [FecVence] datetime  NOT NULL,
    [MonActual] decimal(18,2)  NULL,
    [Documento] varchar(20)  NULL,
    [DetalleViatico] varchar(20)  NULL,
    [Programa] int  NULL,
    [NumFactura] varchar(20)  NULL,
    [Nombramiento] varchar(10)  NULL
);
GO

-- Creating table 'AddendumPrestamoPuesto'
CREATE TABLE [dbo].[AddendumPrestamoPuesto] (
    [PK_AddendumPrestamoPuesto] int IDENTITY(1,1) NOT NULL,
    [FK_PrestamoPuesto] int  NULL,
    [NumAddendum] varchar(15)  NULL,
    [FecRige] datetime  NULL,
    [FecFin] datetime  NULL
);
GO

-- Creating table 'BitacoraIncidencia'
CREATE TABLE [dbo].[BitacoraIncidencia] (
    [PK_BitacoraIncidencia] int IDENTITY(1,1) NOT NULL,
    [FK_Incidencia] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [EstSolicitud] int  NULL,
    [FecEjecucion] datetime  NOT NULL
);
GO

-- Creating table 'BitacoraUsuario'
CREATE TABLE [dbo].[BitacoraUsuario] (
    [PK_BitacoraUsuario] int IDENTITY(1,1) NOT NULL,
    [FK_Usuario] int  NULL,
    [CodAccion] int  NULL,
    [CodEntidad] int  NULL,
    [FecEjecucion] datetime  NULL,
    [CodModulo] int  NULL,
    [CodObjetoEntidad] int  NULL
);
GO

-- Creating table 'BoletaPrestamo'
CREATE TABLE [dbo].[BoletaPrestamo] (
    [PK_IdBoletaPrestamo] int IDENTITY(1,1) NOT NULL,
    [FK_Usuario] int  NOT NULL,
    [FK_ExpedienteFuncionario] int  NOT NULL,
    [IndTipoUsuario] int  NOT NULL,
    [NumBoleta] varchar(15)  NOT NULL,
    [IdCedulaSolicitante] varchar(15)  NULL,
    [LugarProcedencia] varchar(300)  NULL
);
GO

-- Creating table 'BorradorAccionPersonal'
CREATE TABLE [dbo].[BorradorAccionPersonal] (
    [PK_Borrador] int IDENTITY(1,1) NOT NULL,
    [FK_EstadoBorrador] int  NOT NULL,
    [NumOficio] varchar(15)  NOT NULL,
    [UsuarioAsignado] varchar(50)  NOT NULL,
    [ObsJustificacion] varchar(250)  NOT NULL
);
GO

-- Creating table 'BotAccionIncidencia'
CREATE TABLE [dbo].[BotAccionIncidencia] (
    [PK_BotAccionIncidencia] int IDENTITY(1,1) NOT NULL,
    [FK_CatalogoIncidencia] int  NOT NULL,
    [urlVideo] varchar(200)  NOT NULL,
    [DesAccion] varchar(200)  NOT NULL
);
GO

-- Creating table 'Calificacion'
CREATE TABLE [dbo].[Calificacion] (
    [PK_Calificacion] int IDENTITY(1,1) NOT NULL,
    [DesCalificacion] varchar(15)  NULL
);
GO

-- Creating table 'CalificacionReglaTecnica'
CREATE TABLE [dbo].[CalificacionReglaTecnica] (
    [PK_CalificacionReglaTecnica] int IDENTITY(1,1) NOT NULL,
    [FK_PeriodoCalificacion] int  NOT NULL,
    [IndDireccionGeneral] int  NOT NULL,
    [IndDirector] int  NOT NULL,
    [DesCorreo] varchar(200)  NOT NULL,
    [NumFuncionarios] int  NOT NULL,
    [NumFuncionariosExcelentes] int  NOT NULL,
    [IndEstado] int  NOT NULL,
    [ImgDocumento] varbinary(max)  NULL
);
GO

-- Creating table 'CambioPorAccionPersonal'
CREATE TABLE [dbo].[CambioPorAccionPersonal] (
    [PK_CambioPorAccionPersonal] int IDENTITY(1,1) NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [FK_ComponenteSalarial] int  NOT NULL,
    [FK_AccionPersonal] int  NOT NULL,
    [ValorCambio] decimal(10,2)  NULL,
    [FK_TipoCambioPorAccionPersonal] int  NULL,
    [Estado] int  NULL
);
GO

-- Creating table 'Canton'
CREATE TABLE [dbo].[Canton] (
    [PK_Canton] int IDENTITY(1,1) NOT NULL,
    [FK_Provincia] int  NOT NULL,
    [NomCanton] varchar(20)  NULL,
    [CodPostalCanton] char(2)  NULL
);
GO

-- Creating table 'CaracteristicasPuesto'
CREATE TABLE [dbo].[CaracteristicasPuesto] (
    [PK_CaracteristicasPuesto] int IDENTITY(1,1) NOT NULL,
    [IndEscala] int  NULL,
    [DesCaracteristica] varchar(50)  NULL,
    [FK_Puesto] int  NULL,
    [FK_Factor] int  NULL
);
GO

-- Creating table 'CartasPresentacion'
CREATE TABLE [dbo].[CartasPresentacion] (
    [PK_CartasPresentacion] int IDENTITY(1,1) NOT NULL,
    [NumCarta] varchar(10)  NULL,
    [FecCarta] datetime  NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [FK_Nombramiento] int  NOT NULL
);
GO

-- Creating table 'CatalogoDeduccion'
CREATE TABLE [dbo].[CatalogoDeduccion] (
    [PK_CatalogoDeduccion] int IDENTITY(1,1) NOT NULL,
    [FK_TipoDeduccion] int  NOT NULL,
    [CodDeduccion] int  NULL,
    [DesDeduccion] varchar(50)  NOT NULL,
    [PorDeduccion] decimal(6,4)  NOT NULL
);
GO

-- Creating table 'CatalogoDia'
CREATE TABLE [dbo].[CatalogoDia] (
    [PK_CatalogoDia] int IDENTITY(1,1) NOT NULL,
    [FK_TipoDia] int  NOT NULL,
    [DesDia] varchar(50)  NOT NULL,
    [FecDia] varchar(7)  NOT NULL
);
GO

-- Creating table 'CatalogoIncidencia'
CREATE TABLE [dbo].[CatalogoIncidencia] (
    [PK_CatalogoIncidencia] int IDENTITY(1,1) NOT NULL,
    [FK_Perfil] int  NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Prioridad] int  NULL
);
GO

-- Creating table 'CatalogoPregunta'
CREATE TABLE [dbo].[CatalogoPregunta] (
    [PK_CatalogoPregunta] int IDENTITY(1,1) NOT NULL,
    [DesPregunta] varchar(1000)  NULL,
    [IndTipoFormulario] int  NULL,
    [IndEstado] int  NULL,
    [DesTituloP] varchar(150)  NULL
);
GO

-- Creating table 'CatalogoRemuneracion'
CREATE TABLE [dbo].[CatalogoRemuneracion] (
    [PK_CatalogoRemuneracion] int IDENTITY(1,1) NOT NULL,
    [PorRemuneracion] decimal(6,4)  NOT NULL,
    [DesRemuneracion] varchar(75)  NOT NULL
);
GO

-- Creating table 'CatAnioAccionPersonal'
CREATE TABLE [dbo].[CatAnioAccionPersonal] (
    [AnioRige] varchar(5)  NOT NULL,
    [NumConsecutivo] bigint  NOT NULL
);
GO

-- Creating table 'CatAnioBoletaPrestamo'
CREATE TABLE [dbo].[CatAnioBoletaPrestamo] (
    [AnioRige] varchar(5)  NOT NULL,
    [NumConsecutivo] bigint  NOT NULL
);
GO

-- Creating table 'CatEstadoCivil'
CREATE TABLE [dbo].[CatEstadoCivil] (
    [PK_CatEstadoCivil] int IDENTITY(1,1) NOT NULL,
    [DesEstadoCivil] varchar(15)  NULL
);
GO

-- Creating table 'CatMovimientoPresupuesto'
CREATE TABLE [dbo].[CatMovimientoPresupuesto] (
    [PK_CatMovimientoPresupuesto] int  NOT NULL,
    [DesMovimientoPresupuesto] varchar(50)  NULL
);
GO

-- Creating table 'CatPermiso'
CREATE TABLE [dbo].[CatPermiso] (
    [PK_CatPermiso] int IDENTITY(1,1) NOT NULL,
    [FK_Perfil] int  NOT NULL,
    [NomPermiso] varchar(150)  NULL,
    [DesPermiso] varchar(250)  NULL,
    [IndEstadoCatPermiso] int  NULL
);
GO

-- Creating table 'Caucion'
CREATE TABLE [dbo].[Caucion] (
    [PK_Caucion] int IDENTITY(1,1) NOT NULL,
    [FK_Nombramiento] int  NULL,
    [FK_EntidadSeguros] int  NULL,
    [FK_MontoCaucion] int  NULL,
    [FecEmision] datetime  NULL,
    [FecVence] datetime  NULL,
    [IndEstadoPoliza] int  NULL,
    [ImgCopiaRecibo] varbinary(max)  NULL,
    [ObsPoliza] varchar(150)  NULL,
    [NumPoliza] varchar(50)  NULL,
    [IndCopiaCertificada] bit  NULL,
    [NumOficioEntrega] varchar(50)  NULL
);
GO

-- Creating table 'Clase'
CREATE TABLE [dbo].[Clase] (
    [PK_Clase] int  NOT NULL,
    [DesClase] varchar(150)  NULL,
    [IndEstadoClase] int  NULL,
    [IndCategoria] int  NULL
);
GO

-- Creating table 'ComponentePresupuestario'
CREATE TABLE [dbo].[ComponentePresupuestario] (
    [PK_ComponentePresupuestario] int IDENTITY(1,1) NOT NULL,
    [FK_ObjetoGasto] int  NOT NULL,
    [FK_Programa] int  NOT NULL,
    [AnioPresupuesto] varchar(5)  NOT NULL,
    [MtoComponentePresupuestario] decimal(20,2)  NULL,
    [FK_CatMovimientoPresupuesto] int  NULL,
    [Detalle] varchar(250)  NULL
);
GO

-- Creating table 'ComponenteSalarial'
CREATE TABLE [dbo].[ComponenteSalarial] (
    [PK_ComponenteSalarial] int IDENTITY(1,1) NOT NULL,
    [DesComponenteSalarial] varchar(250)  NULL,
    [TipComponenteSalarial] int  NULL,
    [FK_ObjetoGasto] int  NULL
);
GO

-- Creating table 'ContenidoPresupuestario'
CREATE TABLE [dbo].[ContenidoPresupuestario] (
    [PK_ContenidoPresupuestario] int IDENTITY(1,1) NOT NULL,
    [NumResolucion] varchar(15)  NULL,
    [FecPago] datetime  NULL,
    [FecRige] datetime  NULL
);
GO

-- Creating table 'CuentaBancaria'
CREATE TABLE [dbo].[CuentaBancaria] (
    [PK_CuentaBancaria] int IDENTITY(1,1) NOT NULL,
    [CtaCliente] varchar(17)  NOT NULL,
    [FK_EntidadFinanciera] int  NULL,
    [FK_DetalleContratacion] int  NULL,
    [IndEstadoCtaBancaria] int  NULL
);
GO

-- Creating table 'CursoGrado'
CREATE TABLE [dbo].[CursoGrado] (
    [PK_CursoGrado] int IDENTITY(1,1) NOT NULL,
    [DesCursoGrado] varchar(150)  NULL,
    [PorIncentivo] int  NULL,
    [FK_FormacionAcademica] int  NULL,
    [TipCursoGrado] int  NULL,
    [FK_EntidadEducativa] int  NULL,
    [FecEmision] datetime  NULL,
    [NumResolucion] varchar(10)  NULL,
    [ImgTitulo] varbinary(max)  NULL,
    [Estado] int  NULL,
    [Observaciones] varchar(300)  NULL
);
GO

-- Creating table 'Decreto'
CREATE TABLE [dbo].[Decreto] (
    [PK_Decreto] int  NOT NULL,
    [NumDecreto] varchar(50)  NULL,
    [TituloDecreto] varchar(250)  NULL,
    [FecDecreto] datetime  NULL,
    [ObsDecreto] varchar(250)  NULL
);
GO

-- Creating table 'DeduccionEfectuada'
CREATE TABLE [dbo].[DeduccionEfectuada] (
    [PK_DeduccionEfectuada] int IDENTITY(1,1) NOT NULL,
    [FK_CatalogoDeduccion] int  NOT NULL,
    [FK_PagoFeriado] int  NOT NULL,
    [PorEfectuado] decimal(6,4)  NOT NULL,
    [MtoDeduccion] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'DeduccionTemporal'
CREATE TABLE [dbo].[DeduccionTemporal] (
    [PK_DeduccionTemporal] int IDENTITY(1,1) NOT NULL,
    [IndDias] decimal(6,2)  NULL,
    [IndHoras] decimal(4,2)  NULL,
    [NumDocumento] varchar(50)  NULL,
    [IndExplicacion] varchar(300)  NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [MtoDeduccion] decimal(9,2)  NULL,
    [IndMesProceso] int  NULL,
    [IndPeriodo] varchar(8)  NULL,
    [FecActualizacion] datetime  NULL,
    [FK_TipoDeduccionTemporal] int  NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'Departamento'
CREATE TABLE [dbo].[Departamento] (
    [PK_Departamento] int  NOT NULL,
    [NomDepartamento] varchar(150)  NULL,
    [IndEstadoDepartamento] int  NULL
);
GO

-- Creating table 'DesgloseSalarial'
CREATE TABLE [dbo].[DesgloseSalarial] (
    [PK_DesgloseSalarial] int IDENTITY(1,1) NOT NULL,
    [IndPeriodo] datetime  NOT NULL,
    [FK_Nombramiento] int  NULL,
    [FecCarga] datetime  NULL
);
GO

-- Creating table 'DetalleAcceso'
CREATE TABLE [dbo].[DetalleAcceso] (
    [PK_DetalleAcceso] int IDENTITY(1,1) NOT NULL,
    [FK_Usuario] int  NOT NULL,
    [FK_Funcionario] int  NULL,
    [FecCreacion] datetime  NULL,
    [IndEstadoDetalleAcceso] int  NULL
);
GO

-- Creating table 'DetalleAccionPersonal'
CREATE TABLE [dbo].[DetalleAccionPersonal] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_AccionPersonal] int  NOT NULL,
    [FK_DetallePuesto] int  NOT NULL,
    [CodNombramiento] int  NOT NULL,
    [CodPrograma] int  NOT NULL,
    [CodSeccion] int  NOT NULL,
    [CodEspecialidad] int  NULL,
    [CodSubespecialidad] int  NULL,
    [CodDetallePuesto] int  NOT NULL,
    [NumHoras] int  NOT NULL,
    [NumAnualidad] int  NOT NULL,
    [MtoRecargo] decimal(10,2)  NOT NULL,
    [MtoGradoGrupo] decimal(10,2)  NOT NULL,
    [PorProhibicion] decimal(6,2)  NOT NULL,
    [MtoOtros] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'DetalleAsignacionGastoTransporteModificada'
CREATE TABLE [dbo].[DetalleAsignacionGastoTransporteModificada] (
    [PK_DetalleAsignacionGastoModificada] int IDENTITY(1,1) NOT NULL,
    [NomRuta] varchar(255)  NOT NULL,
    [NomFraccionamiento] varchar(255)  NOT NULL,
    [MontTarifa] varchar(255)  NOT NULL,
    [FK_GastoTransporte] int  NOT NULL,
    [NumGaceta] varchar(10)  NULL
);
GO

-- Creating table 'DetalleBoleta'
CREATE TABLE [dbo].[DetalleBoleta] (
    [PK_IdDetalleBoleta] int IDENTITY(1,1) NOT NULL,
    [FK_IdBoletaPrestamo] int  NOT NULL,
    [FecPrestamo] datetime  NULL,
    [FecCaducidad] datetime  NULL,
    [MotivoPrestamo] varchar(300)  NULL,
    [Correo] varchar(50)  NOT NULL,
    [Telefono] varchar(50)  NOT NULL
);
GO

-- Creating table 'DetalleBorradorAccionPersonal'
CREATE TABLE [dbo].[DetalleBorradorAccionPersonal] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_Borrador] int  NOT NULL,
    [FK_TipoAccionPersonal] int  NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [FK_Programa] int  NULL,
    [FK_Seccion] int  NULL,
    [FecRige] datetime  NOT NULL,
    [FecVence] datetime  NOT NULL,
    [FecRigeIntegra] datetime  NOT NULL,
    [FecVenceIntegra] datetime  NOT NULL,
    [CodClase] int  NOT NULL,
    [CodPuesto] char(10)  NOT NULL,
    [NumHoras] int  NOT NULL,
    [Disfrutado] varchar(50)  NOT NULL,
    [Autorizado] varchar(50)  NOT NULL,
    [IndCategoria] int  NOT NULL,
    [Categoria] varchar(50)  NOT NULL,
    [MtoSalarioBase] decimal(10,2)  NOT NULL,
    [MtoAumentosAnuales] decimal(10,2)  NOT NULL,
    [MtoRecargo] decimal(10,2)  NOT NULL,
    [MtoGradoGrupo] decimal(10,2)  NOT NULL,
    [PorProhibicion] decimal(6,2)  NOT NULL,
    [MtoOtros] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacion'
CREATE TABLE [dbo].[DetalleCalificacion] (
    [PK_DetalleCalificacion] int IDENTITY(1,1) NOT NULL,
    [FK_CatalogoPregunta] int  NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [NumNotasPregunta] varchar(50)  NULL
);
GO

-- Creating table 'DetalleCalificacionModificada'
CREATE TABLE [dbo].[DetalleCalificacionModificada] (
    [PK_DetalleCalificacion] int IDENTITY(1,1) NOT NULL,
    [FK_CatalogoPregunta] int  NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [NumNotasPregunta] varchar(50)  NOT NULL
);
GO

-- Creating table 'DetalleCambioPedimento'
CREATE TABLE [dbo].[DetalleCambioPedimento] (
    [PK_DetalleCambioPedimento] int IDENTITY(1,1) NOT NULL,
    [NumResolucion] varchar(50)  NULL,
    [FK_PedimentoPuesto] int  NOT NULL,
    [FecResolucion] datetime  NULL,
    [ObsDetalleCambio] varchar(300)  NULL,
    [FK_EstadoPedimento] int  NOT NULL
);
GO

-- Creating table 'DetalleContratacion'
CREATE TABLE [dbo].[DetalleContratacion] (
    [PK_DetalleContratacion] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FecIngreso] datetime  NULL,
    [FecCese] datetime  NULL,
    [NumAnualidades] int  NULL,
    [NumAnniosServicioPublico] int  NULL,
    [FecMesAumento] varchar(2)  NULL,
    [CodPolicial] decimal(6,0)  NULL,
    [MarcaAsistencia] bit  NULL,
    [IndUbicacionReal] varchar(250)  NULL,
    [FK_TipoJornada] int  NULL,
    [FecRegimenPolicial] datetime  NULL,
    [FecVacaciones] datetime  NULL
);
GO

-- Creating table 'DetalleDeduccion'
CREATE TABLE [dbo].[DetalleDeduccion] (
    [PK_DetalleDeduccion] int IDENTITY(1,1) NOT NULL,
    [FK_DesgloseSalarial] int  NULL,
    [FK_CatalogoDeduccion] int  NULL,
    [MtoDeduccion] decimal(10,2)  NULL
);
GO

-- Creating table 'DetalleDeduccionGastoTransporte'
CREATE TABLE [dbo].[DetalleDeduccionGastoTransporte] (
    [PK_DetalleDeduccionGastoTransporte] int IDENTITY(1,1) NOT NULL,
    [FK_MovimientoGastoTransporte] int  NULL,
    [DesMotivo] varchar(255)  NULL,
    [FecRige] varchar(255)  NULL,
    [FecVence] varchar(255)  NULL,
    [NumNoDias] int  NULL,
    [MontMontoBajar] varchar(255)  NULL,
    [MontMontoRebajarConp] varchar(255)  NULL,
    [TotRebajar] varchar(255)  NULL,
    [NumAccionPersonal] varchar(255)  NULL
);
GO

-- Creating table 'DetalleDeduccionViaticoCorrido'
CREATE TABLE [dbo].[DetalleDeduccionViaticoCorrido] (
    [PK_DetalleDeduccionViaticoCorrido] int IDENTITY(1,1) NOT NULL,
    [FK_MovimientoViaticoCorrido] int  NULL,
    [DesMotivo] varchar(255)  NULL,
    [FecRige] varchar(255)  NULL,
    [FecVence] varchar(255)  NULL,
    [NumNoDias] int  NULL,
    [MontMontoBajar] varchar(255)  NULL,
    [MontMontoRebajarConp] varchar(255)  NULL,
    [TotRebajar] varchar(255)  NULL,
    [NumAccionPersonal] varchar(255)  NULL
);
GO

-- Creating table 'DetalleDesgloseSalarial'
CREATE TABLE [dbo].[DetalleDesgloseSalarial] (
    [PK_DetalleDesgloceSalarial] int IDENTITY(1,1) NOT NULL,
    [FK_DesgloseSalarial] int  NOT NULL,
    [FK_ComponenteSalarial] int  NULL,
    [MtoComponenteSalarial] decimal(10,2)  NULL,
    [MtoPagocomponenteSalarial] decimal(10,2)  NULL
);
GO

-- Creating table 'DetalleEliminacionViaticoCorridoGastoTransporte'
CREATE TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte] (
    [PK_DetalleEliminacionViaticoCorrido] int IDENTITY(1,1) NOT NULL,
    [FK_MovimientoViaticoCorrido] int  NULL,
    [ObsJustificacion] varchar(250)  NULL,
    [FecInicio] datetime  NULL,
    [FecFinal] datetime  NULL,
    [FK_MovimientoGastoTransporte] int  NULL
);
GO

-- Creating table 'DetalleIncapacidad'
CREATE TABLE [dbo].[DetalleIncapacidad] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_RegistroIncapacidad] int  NOT NULL,
    [FecDia] datetime  NOT NULL,
    [PorSubsidio] decimal(6,2)  NOT NULL,
    [MtoSubsidio] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'DetallePagoGastoTransporte'
CREATE TABLE [dbo].[DetallePagoGastoTransporte] (
    [PK_DetallePago] int IDENTITY(1,1) NOT NULL,
    [FK_PagoGastoTransporte] int  NOT NULL,
    [FK_TipoDetallePagoGasto] int  NOT NULL,
    [FecDiaPago] datetime  NOT NULL,
    [MonPago] decimal(18,2)  NOT NULL,
    [CodEntidad] int  NOT NULL
);
GO

-- Creating table 'DetallePagoViaticoCorrido'
CREATE TABLE [dbo].[DetallePagoViaticoCorrido] (
    [PK_DetallePago] int IDENTITY(1,1) NOT NULL,
    [FK_PagoViaticoCorrido] int  NOT NULL,
    [FK_TipoDetallePagoViatico] int  NOT NULL,
    [FecDiaPago] datetime  NOT NULL,
    [MonPago] decimal(18,2)  NOT NULL,
    [CodEntidad] int  NOT NULL
);
GO

-- Creating table 'DetallePagoViaticoRetroactivo'
CREATE TABLE [dbo].[DetallePagoViaticoRetroactivo] (
    [PK_DetallePago] int IDENTITY(1,1) NOT NULL,
    [FK_PagoViaticoRetroactivo] int  NOT NULL,
    [FK_TipoDetallePagoViatico] int  NOT NULL,
    [FecDiaPago] datetime  NOT NULL,
    [MonPago] decimal(18,2)  NOT NULL,
    [CodEntidad] int  NOT NULL
);
GO

-- Creating table 'DetallePuesto'
CREATE TABLE [dbo].[DetallePuesto] (
    [PK_DetallePuesto] int IDENTITY(1,1) NOT NULL,
    [FK_SubEspecialidad] int  NULL,
    [FK_OcupacionReal] int  NULL,
    [FK_Puesto] int  NULL,
    [FK_Especialidad] int  NULL,
    [FK_Clase] int  NULL,
    [FK_TipoPuesto] int  NULL,
    [FK_ContenidoPresupuestario] int  NULL,
    [IndEstadoDetallePuesto] int  NULL,
    [FecRige] datetime  NULL,
    [FK_Escala] int  NULL,
    [PorProhibicion] decimal(18,2)  NULL,
    [PorDedicacion] decimal(18,2)  NULL,
    [FK_Nombramiento] int  NULL
);
GO

-- Creating table 'DetalleTiempoExtra'
CREATE TABLE [dbo].[DetalleTiempoExtra] (
    [PK_DetalleTiempoExtra] int IDENTITY(1,1) NOT NULL,
    [FecRegistro] datetime  NULL,
    [FecInicio] datetime  NULL,
    [FecFin] datetime  NULL,
    [IndHoraInicio] varchar(5)  NULL,
    [IndHoraFin] varchar(5)  NULL,
    [FK_TipoExtra] int  NULL,
    [FK_RegistroTiempoExtra] int  NULL,
    [IndEstado] int  NULL,
    [MtoH0] varchar(5)  NULL,
    [MtoH1] varchar(5)  NULL,
    [MtoH2] varchar(5)  NULL
);
GO

-- Creating table 'DiaPagado'
CREATE TABLE [dbo].[DiaPagado] (
    [PK_DiaPagado] int IDENTITY(1,1) NOT NULL,
    [FK_PagoFeriado] int  NOT NULL,
    [FK_CatalogoDia] int  NOT NULL,
    [CntHora] int  NOT NULL,
    [MtoSalarioHora] decimal(10,2)  NOT NULL,
    [MtoTotal] decimal(10,2)  NOT NULL,
    [AnioPago] varchar(5)  NOT NULL
);
GO

-- Creating table 'Direccion'
CREATE TABLE [dbo].[Direccion] (
    [PK_Direccion] int IDENTITY(1,1) NOT NULL,
    [FK_Distrito] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [DirExacta] varchar(150)  NULL,
    [IndEstadoDireccion] int  NULL
);
GO

-- Creating table 'DireccionGeneral'
CREATE TABLE [dbo].[DireccionGeneral] (
    [PK_DireccionGeneral] int  NOT NULL,
    [NomDireccion] varchar(150)  NULL
);
GO

-- Creating table 'Distrito'
CREATE TABLE [dbo].[Distrito] (
    [PK_Distrito] int IDENTITY(1,1) NOT NULL,
    [FK_Canton] int  NOT NULL,
    [NomDistrito] varchar(50)  NULL,
    [CodPostalDistrito] char(2)  NULL
);
GO

-- Creating table 'Division'
CREATE TABLE [dbo].[Division] (
    [PK_Division] int  NOT NULL,
    [NomDivision] varchar(150)  NULL
);
GO

-- Creating table 'EntidadAdscrita'
CREATE TABLE [dbo].[EntidadAdscrita] (
    [PK_EntidadAdscrita] int IDENTITY(1,1) NOT NULL,
    [NomEntidad] varchar(50)  NULL,
    [TipEntidad] int  NULL
);
GO

-- Creating table 'EntidadFinanciera'
CREATE TABLE [dbo].[EntidadFinanciera] (
    [PK_EntidadFinanciera] int IDENTITY(1,1) NOT NULL,
    [NomEntidad] varchar(100)  NOT NULL,
    [CodEntidad] varchar(10)  NOT NULL
);
GO

-- Creating table 'EntidadGubernamental'
CREATE TABLE [dbo].[EntidadGubernamental] (
    [PK_EntidadGubernamental] int IDENTITY(1,1) NOT NULL,
    [NomEntidad] varchar(50)  NULL,
    [TipEntidad] int  NULL
);
GO

-- Creating table 'EntidadMedica'
CREATE TABLE [dbo].[EntidadMedica] (
    [PK_EntidadMedica] int IDENTITY(1,1) NOT NULL,
    [DesEntidad] varchar(50)  NULL
);
GO

-- Creating table 'EntidadSeguros'
CREATE TABLE [dbo].[EntidadSeguros] (
    [PK_EntidadSeguros] int IDENTITY(1,1) NOT NULL,
    [NomEntidadSeguros] varchar(50)  NULL
);
GO

-- Creating table 'EscalaSalarial'
CREATE TABLE [dbo].[EscalaSalarial] (
    [PK_Escala] int IDENTITY(1,1) NOT NULL,
    [IndCategoria] int  NULL,
    [MtoSalarioBase] decimal(10,2)  NULL,
    [MtoAumento] decimal(10,2)  NULL,
    [FK_Periodo] int  NULL
);
GO

-- Creating table 'Especialidad'
CREATE TABLE [dbo].[Especialidad] (
    [PK_Especialidad] int  NOT NULL,
    [DesEspecialidad] varchar(150)  NULL,
    [IndEstadoEspecialidad] int  NULL
);
GO

-- Creating table 'EstadoBorrador'
CREATE TABLE [dbo].[EstadoBorrador] (
    [PK_EstadoBorrador] int  NOT NULL,
    [DesEstadoBorrador] varchar(150)  NOT NULL
);
GO

-- Creating table 'EstadoDesarraigo'
CREATE TABLE [dbo].[EstadoDesarraigo] (
    [PK_EstadoDesarraigo] int IDENTITY(1,1) NOT NULL,
    [NomEstadoDesarraigo] varchar(15)  NOT NULL
);
GO

-- Creating table 'EstadoFuncionario'
CREATE TABLE [dbo].[EstadoFuncionario] (
    [PK_EstadoFuncionario] int IDENTITY(1,1) NOT NULL,
    [DesEstadoFuncionario] varchar(50)  NULL
);
GO

-- Creating table 'EstadoGastoTransporte'
CREATE TABLE [dbo].[EstadoGastoTransporte] (
    [PK_EstadoGastosTransporte] int IDENTITY(1,1) NOT NULL,
    [NomEstado] varchar(100)  NULL
);
GO

-- Creating table 'EstadoMovimientoPuesto'
CREATE TABLE [dbo].[EstadoMovimientoPuesto] (
    [PK_EstadoMovimientoPuesto] int IDENTITY(1,1) NOT NULL,
    [NomEstado] varchar(25)  NULL
);
GO

-- Creating table 'EstadoNombramiento'
CREATE TABLE [dbo].[EstadoNombramiento] (
    [PK_EstadoNombramiento] int IDENTITY(1,1) NOT NULL,
    [DesEstado] varchar(50)  NULL
);
GO

-- Creating table 'EstadoPedimento'
CREATE TABLE [dbo].[EstadoPedimento] (
    [PK_EstadoPedimento] int IDENTITY(1,1) NOT NULL,
    [DesEstadoPedimento] varchar(100)  NULL
);
GO

-- Creating table 'EstadoPuesto'
CREATE TABLE [dbo].[EstadoPuesto] (
    [PK_EstadoPuesto] int IDENTITY(1,1) NOT NULL,
    [DesEstadoPuesto] varchar(50)  NULL
);
GO

-- Creating table 'EstadoTipoJornada'
CREATE TABLE [dbo].[EstadoTipoJornada] (
    [PK_EstadoTipoJornada] int IDENTITY(1,1) NOT NULL,
    [NomEstadoTipoJornada] varchar(15)  NULL
);
GO

-- Creating table 'EstadoTramite'
CREATE TABLE [dbo].[EstadoTramite] (
    [PK_EstadoTramite] int IDENTITY(1,1) NOT NULL,
    [DesEstado] varchar(20)  NOT NULL
);
GO

-- Creating table 'EstadoViaticoCorrido'
CREATE TABLE [dbo].[EstadoViaticoCorrido] (
    [PK_EstadoViaticoCorrido] int IDENTITY(1,1) NOT NULL,
    [NomEstado] varchar(100)  NULL
);
GO

-- Creating table 'EstudioPuesto'
CREATE TABLE [dbo].[EstudioPuesto] (
    [PK_EstudioPuesto] int IDENTITY(1,1) NOT NULL,
    [NumOficio] varchar(15)  NULL,
    [NumResolucion] varchar(15)  NULL,
    [FecResolucion] datetime  NULL,
    [FK_Puesto] int  NULL,
    [ObsEstudioPuesto] varchar(300)  NULL
);
GO

-- Creating table 'ExpedienteFuncionario'
CREATE TABLE [dbo].[ExpedienteFuncionario] (
    [PK_IdExpedienteFuncionario] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FecCreacion] datetime  NULL,
    [Estado] int  NOT NULL,
    [FecTrasladoArchivoCentral] datetime  NULL,
    [numExpediente] int  NOT NULL,
    [numExpedienteEnArchivo] varchar(50)  NULL,
    [numCaja] varchar(50)  NULL
);
GO

-- Creating table 'ExperienciaProfesional'
CREATE TABLE [dbo].[ExperienciaProfesional] (
    [PK_ExperienciaProfesional] int IDENTITY(1,1) NOT NULL,
    [FecRegistro] datetime  NULL,
    [IndPuntosAsignados] decimal(6,2)  NULL,
    [TipExperiencia] int  NULL,
    [ObsExperienciaProfesional] varchar(300)  NULL,
    [FK_FormacionAcademica] int  NULL,
    [NumResolucion] varchar(10)  NULL
);
GO

-- Creating table 'Factor'
CREATE TABLE [dbo].[Factor] (
    [PK_Factor] int IDENTITY(1,1) NOT NULL,
    [FK_TituloFactor] int  NULL,
    [DesFactor] varchar(50)  NULL
);
GO

-- Creating table 'Folio'
CREATE TABLE [dbo].[Folio] (
    [PK_IdFolio] int IDENTITY(1,1) NOT NULL,
    [FK_IdTomo] int  NULL,
    [Descripcion] varchar(300)  NULL,
    [FecCreacion] datetime  NULL,
    [NumFolio] int  NOT NULL
);
GO

-- Creating table 'FormacionAcademica'
CREATE TABLE [dbo].[FormacionAcademica] (
    [PK_FormacionAcademica] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NULL,
    [FecRegistro] datetime  NULL
);
GO

-- Creating table 'Funcionario'
CREATE TABLE [dbo].[Funcionario] (
    [PK_Funcionario] int IDENTITY(1,1) NOT NULL,
    [FK_EstadoFuncionario] int  NOT NULL,
    [IdCedulaFuncionario] varchar(15)  NOT NULL,
    [NomFuncionario] varchar(25)  NULL,
    [NomPrimerApellido] varchar(15)  NULL,
    [NomSegundoApellido] varchar(15)  NULL,
    [FecNacimiento] datetime  NULL,
    [IndSexo] char(1)  NULL
);
GO

-- Creating table 'GastoTransporteReintegroDias'
CREATE TABLE [dbo].[GastoTransporteReintegroDias] (
    [PK_Reintegro] int IDENTITY(1,1) NOT NULL,
    [FK_GastoTransporte] int  NOT NULL,
    [FecDia] datetime  NOT NULL,
    [MonReintegro] decimal(18,2)  NOT NULL,
    [ObsMotivo] varchar(500)  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'HistorialEstadoCivil'
CREATE TABLE [dbo].[HistorialEstadoCivil] (
    [PK_HistorialEstadoCivil] int IDENTITY(1,1) NOT NULL,
    [FK_CatEstadoCivil] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FecInicio] datetime  NOT NULL,
    [FecFin] datetime  NULL
);
GO

-- Creating table 'Incidencia'
CREATE TABLE [dbo].[Incidencia] (
    [PK_Incidencia] int IDENTITY(1,1) NOT NULL,
    [FK_FuncionarioEmisor] int  NOT NULL,
    [FK_FuncionarioUIRH] int  NULL,
    [FK_CatalogoIncidencia] int  NOT NULL,
    [EstIncidencia] int  NOT NULL,
    [IndIPOrigen] varchar(50)  NOT NULL,
    [DesError] varchar(300)  NULL,
    [DesJustificacion] varchar(300)  NULL,
    [ImgError] varbinary(max)  NOT NULL,
    [FecInicio] datetime  NOT NULL,
    [FecFin] datetime  NULL,
    [IndImpacto] int  NULL
);
GO

-- Creating table 'InformacionContacto'
CREATE TABLE [dbo].[InformacionContacto] (
    [PK_InformacionContacto] int IDENTITY(1,1) NOT NULL,
    [FK_TipoContacto] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [DesContenido] varchar(100)  NULL,
    [DesAdicional] varchar(100)  NULL
);
GO

-- Creating table 'Modalidad'
CREATE TABLE [dbo].[Modalidad] (
    [PK_Modalidad] int IDENTITY(1,1) NOT NULL,
    [DesModalidad] varchar(50)  NULL,
    [IndTopePuntos] int  NULL
);
GO

-- Creating table 'MontoCaucion'
CREATE TABLE [dbo].[MontoCaucion] (
    [PK_MontoCaucion] int IDENTITY(1,1) NOT NULL,
    [IndNivel] varchar(3)  NULL,
    [MtoColones] decimal(10,2)  NULL,
    [DesMontoCaucion] varchar(300)  NULL,
    [FecRige] datetime  NULL,
    [DesJustificacion] varchar(150)  NULL,
    [IndEstadoMonto] int  NULL,
    [DesJustificacionInactivo] varchar(150)  NULL,
    [FecVencimiento] datetime  NULL
);
GO

-- Creating table 'MotivoMovimiento'
CREATE TABLE [dbo].[MotivoMovimiento] (
    [PK_MotivoMovimiento] int IDENTITY(1,1) NOT NULL,
    [DesMotivo] varchar(60)  NULL,
    [IndEstadoMotivoMovimiento] int  NULL
);
GO

-- Creating table 'MotivoPedimento'
CREATE TABLE [dbo].[MotivoPedimento] (
    [PK_MotivoPedimento] int IDENTITY(1,1) NOT NULL,
    [DesMotivoPedimento] varchar(300)  NULL
);
GO

-- Creating table 'MovimientoBorradorAccionPersonal'
CREATE TABLE [dbo].[MovimientoBorradorAccionPersonal] (
    [PK_MovimientoBorrador] int IDENTITY(1,1) NOT NULL,
    [FK_Borrador] int  NOT NULL,
    [FecMovimiento] datetime  NOT NULL,
    [CodMovimiento] int  NOT NULL,
    [UsuarioEnvia] varchar(50)  NOT NULL,
    [UsuarioRecibe] varchar(50)  NOT NULL,
    [ObsMovimiento] varchar(150)  NOT NULL
);
GO

-- Creating table 'MovimientoGastoTransporte'
CREATE TABLE [dbo].[MovimientoGastoTransporte] (
    [PK_MovimientoGastosTransporte] int IDENTITY(1,1) NOT NULL,
    [FK_GastosTransporte] int  NOT NULL,
    [FecMovimiento] datetime  NOT NULL,
    [ObsObservacion] varchar(500)  NULL,
    [NumTipo] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'MovimientoPuesto'
CREATE TABLE [dbo].[MovimientoPuesto] (
    [PK_MovimientoPuesto] int IDENTITY(1,1) NOT NULL,
    [CodOficio] varchar(100)  NULL,
    [FecMovimiento] datetime  NULL,
    [FK_MotivoMovimiento] int  NULL,
    [FK_Puesto] int  NULL,
    [FK_EstadoMovimientoPuesto] int  NULL,
    [FecVence] datetime  NULL,
    [ObsMovimientoPuesto] varchar(500)  NULL
);
GO

-- Creating table 'MovimientoViaticoCorrido'
CREATE TABLE [dbo].[MovimientoViaticoCorrido] (
    [PK_MovimientoViaticoCorrido] int IDENTITY(1,1) NOT NULL,
    [FK_ViaticoCorrido] int  NOT NULL,
    [FecMovimiento] datetime  NOT NULL,
    [ObsObservacion] varchar(500)  NULL,
    [NumTipo] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'Nombramiento'
CREATE TABLE [dbo].[Nombramiento] (
    [PK_Nombramiento] int IDENTITY(1,1) NOT NULL,
    [FK_EstadoNombramiento] int  NOT NULL,
    [FK_Puesto] int  NOT NULL,
    [FK_Funcionario] int  NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [FecNombramiento] datetime  NULL
);
GO

-- Creating table 'ObjetoGasto'
CREATE TABLE [dbo].[ObjetoGasto] (
    [PK_ObjetoGasto] int IDENTITY(1,1) NOT NULL,
    [FK_Partida] int  NULL,
    [FK_SubPartida] int  NULL,
    [CodObjetoGasto] varchar(7)  NULL,
    [DesObjetoGasto] varchar(250)  NULL
);
GO

-- Creating table 'OcupacionReal'
CREATE TABLE [dbo].[OcupacionReal] (
    [PK_OcupacionReal] int  NOT NULL,
    [DesOcupacionReal] varchar(250)  NULL,
    [IndEstadoOcupacionReal] int  NULL
);
GO

-- Creating table 'PagoExtraordinario'
CREATE TABLE [dbo].[PagoExtraordinario] (
    [PK_PagoExtraordinario] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FecTramite] datetime  NOT NULL
);
GO

-- Creating table 'PagoFeriado'
CREATE TABLE [dbo].[PagoFeriado] (
    [PK_PagoFeriado] int IDENTITY(1,1) NOT NULL,
    [FK_PagoExtraordinario] int  NOT NULL,
    [MtoSalarioBruto] decimal(10,2)  NOT NULL,
    [MtoSubtotalDia] decimal(10,2)  NOT NULL,
    [MtoSalarioEscolar] decimal(10,2)  NOT NULL,
    [MtoDiferenciaLiquida] decimal(10,2)  NOT NULL,
    [MtoAguinaldoProporcional] decimal(10,2)  NOT NULL,
    [MtoDeduccionPatronal] decimal(10,2)  NOT NULL,
    [MtoDeduccionObrero] decimal(10,2)  NOT NULL,
    [MtoTotal] decimal(10,2)  NOT NULL,
    [ObsTramite] varchar(200)  NOT NULL,
    [FK_EstadoTramite] int  NOT NULL
);
GO

-- Creating table 'PagoPrestacion'
CREATE TABLE [dbo].[PagoPrestacion] (
    [PK_PagoPrestacion] int IDENTITY(1,1) NOT NULL,
    [MtoTotal] decimal(10,2)  NULL,
    [MtoCesantia] decimal(10,2)  NULL,
    [MtoVacaciones] decimal(10,2)  NULL,
    [MtoQuincenal] decimal(10,2)  NULL,
    [MtoDiario] decimal(10,2)  NULL,
    [MtoEscolar] decimal(10,2)  NULL,
    [MtoExtras] decimal(10,2)  NULL,
    [FecPago] datetime  NULL,
    [IndEstado] int  NULL
);
GO

-- Creating table 'PagoViaticoCorrido'
CREATE TABLE [dbo].[PagoViaticoCorrido] (
    [PK_PagoViaticoCorrido] int IDENTITY(1,1) NOT NULL,
    [FK_ViaticoCorrido] int  NOT NULL,
    [IndEstado] smallint  NOT NULL,
    [FecPago] datetime  NOT NULL,
    [MonPago] decimal(18,2)  NOT NULL,
    [HojaIndividualizada] varchar(50)  NULL,
    [NumBoleta] varchar(50)  NULL,
    [ReservaRecurso] varchar(50)  NULL,
    [FecRegistro] datetime  NOT NULL
);
GO

-- Creating table 'PagoViaticoRetroactivo'
CREATE TABLE [dbo].[PagoViaticoRetroactivo] (
    [PK_PagoViaticoRetroactivo] int IDENTITY(1,1) NOT NULL,
    [FK_PagoViaticoCorrido] int  NOT NULL,
    [FecPago] datetime  NOT NULL,
    [MonPago] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Partida'
CREATE TABLE [dbo].[Partida] (
    [PK_Partida] int IDENTITY(1,1) NOT NULL,
    [CodPartida] varchar(5)  NULL,
    [DesPartida] varchar(250)  NULL
);
GO

-- Creating table 'Perfil'
CREATE TABLE [dbo].[Perfil] (
    [PK_Perfil] int IDENTITY(1,1) NOT NULL,
    [NomPerfil] varchar(150)  NULL,
    [DesPerfil] varchar(250)  NULL,
    [IndEstadoPerfil] int  NULL
);
GO

-- Creating table 'PerfilAcceso'
CREATE TABLE [dbo].[PerfilAcceso] (
    [PK_PerfilAcceso] int IDENTITY(1,1) NOT NULL,
    [FK_DetalleAcceso] int  NOT NULL,
    [FecAsignacion] datetime  NULL,
    [FK_CatPermiso] int  NULL
);
GO

-- Creating table 'PeriodoCalificacion'
CREATE TABLE [dbo].[PeriodoCalificacion] (
    [PK_PeriodoCalificacion] int  NOT NULL,
    [FecRige] datetime  NOT NULL,
    [FecVence] datetime  NOT NULL,
    [FecRigeReglaTecnica] datetime  NOT NULL,
    [FecVenceReglaTecnica] datetime  NOT NULL
);
GO

-- Creating table 'PeriodoEscalaSalarial'
CREATE TABLE [dbo].[PeriodoEscalaSalarial] (
    [PK_Periodo] int IDENTITY(1,1) NOT NULL,
    [FecInicial] datetime  NULL,
    [FecCierre] datetime  NULL,
    [NumResolucion] varchar(50)  NULL,
    [MtoPuntoCarrera] decimal(9,2)  NULL
);
GO

-- Creating table 'PeriodoVacaciones'
CREATE TABLE [dbo].[PeriodoVacaciones] (
    [PK_PeriodoVacaciones] int IDENTITY(1,1) NOT NULL,
    [IndDiasDerecho] decimal(3,1)  NULL,
    [FecCarga] datetime  NOT NULL,
    [IndPeriodo] varchar(8)  NOT NULL,
    [IndEstado] int  NOT NULL,
    [FK_Nombramiento] int  NULL,
    [IndSaldo] float  NULL
);
GO

-- Creating table 'PrestacionLegal'
CREATE TABLE [dbo].[PrestacionLegal] (
    [PK_PrestacionLegal] int IDENTITY(1,1) NOT NULL,
    [FK_Nombramiento] int  NULL,
    [FK_TipoPrestacion] int  NULL,
    [FecCreacion] datetime  NULL,
    [IndEstado] int  NULL,
    [NumPrestacion] varchar(50)  NOT NULL
);
GO

-- Creating table 'PrestamoPuesto'
CREATE TABLE [dbo].[PrestamoPuesto] (
    [PK_PrestamoPuesto] int IDENTITY(1,1) NOT NULL,
    [FK_EntidadAdscrita] int  NULL,
    [FK_EntidadGubernamental] int  NULL,
    [FK_UbicacionAdministrativa] int  NULL,
    [FecTraslado] datetime  NULL,
    [NumResolucion] varchar(15)  NULL,
    [FK_Puesto] int  NULL,
    [NumOficioRescision] varchar(15)  NULL,
    [FecFinConvenio] datetime  NULL,
    [NumRescision] varchar(15)  NULL
);
GO

-- Creating table 'Presupuesto'
CREATE TABLE [dbo].[Presupuesto] (
    [PK_Presupuesto] int IDENTITY(1,1) NOT NULL,
    [FK_Programa] int  NULL,
    [IdPresupuesto] varchar(20)  NULL,
    [CodArea] char(2)  NULL,
    [CodActividad] char(2)  NULL,
    [IdUnidadPresupuestaria] varchar(20)  NULL,
    [IdDireccionPresupuestaria] varchar(20)  NULL
);
GO

-- Creating table 'Programa'
CREATE TABLE [dbo].[Programa] (
    [PK_Programa] int  NOT NULL,
    [DesPrograma] varchar(100)  NULL,
    [IndEstadoPrograma] int  NULL
);
GO

-- Creating table 'Provincia'
CREATE TABLE [dbo].[Provincia] (
    [PK_Provincia] int IDENTITY(1,1) NOT NULL,
    [NomProvincia] varchar(15)  NULL
);
GO

-- Creating table 'Puesto'
CREATE TABLE [dbo].[Puesto] (
    [PK_Puesto] int IDENTITY(1,1) NOT NULL,
    [FK_UbicacionAdministrativa] int  NOT NULL,
    [FK_EstadoPuesto] int  NOT NULL,
    [CodPuesto] char(10)  NOT NULL,
    [IndPuestoConfianza] bit  NULL,
    [ObsPuesto] varchar(300)  NULL,
    [IndNivelOcupacional] int  NULL,
    [FK_FamiliaPuesto] int  NOT NULL
);
GO

-- Creating table 'RegistroIncapacidad'
CREATE TABLE [dbo].[RegistroIncapacidad] (
    [PK_RegistroIncapacidad] int IDENTITY(1,1) NOT NULL,
    [FK_TipoIncapacidad] int  NULL,
    [FK_Nombramiento] int  NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [ObsIncapacidad] varchar(300)  NULL,
    [CodIncapacidad] varchar(50)  NULL,
    [IndEstadoIncapacidad] int  NULL,
    [MtoSalario] decimal(10,2)  NULL,
    [IndProrroga] int  NOT NULL
);
GO

-- Creating table 'RegistroPrestacionReal'
CREATE TABLE [dbo].[RegistroPrestacionReal] (
    [PK_RegistroPagoReal] int IDENTITY(1,1) NOT NULL,
    [MtoTotalReal] decimal(10,2)  NULL,
    [MtoVacaciones] decimal(10,2)  NULL,
    [MtoCesantiaReal] decimal(10,2)  NULL,
    [MtoQuincenalReal] decimal(10,2)  NULL,
    [MtoEscolarReal] decimal(10,2)  NULL,
    [MtoExtrasReal] decimal(10,2)  NULL,
    [ObsRegistroPagoReal] varchar(150)  NULL
);
GO

-- Creating table 'RegistroVacaciones'
CREATE TABLE [dbo].[RegistroVacaciones] (
    [PK_RegistroVacaciones] int IDENTITY(1,1) NOT NULL,
    [FecInicio] datetime  NULL,
    [FecFin] datetime  NULL,
    [IndEstado] int  NULL,
    [FK_PeriodoVacaciones] int  NULL,
    [IndTipoTransaccion] int  NULL,
    [CntDias] decimal(3,1)  NULL,
    [NumTransaccion] varchar(50)  NULL,
    [FecActualizacion] datetime  NULL
);
GO

-- Creating table 'ReintegroVacaciones'
CREATE TABLE [dbo].[ReintegroVacaciones] (
    [PK_ReintegroVacaciones] int IDENTITY(1,1) NOT NULL,
    [FK_RegistroVacaciones] int  NULL,
    [FecInicio] datetime  NULL,
    [FecFin] datetime  NULL,
    [IndMotivo] int  NULL,
    [ObsReintegro] varchar(500)  NULL,
    [NumSolicitudReintegro] varchar(25)  NULL,
    [CntDias] decimal(3,1)  NULL,
    [FecActualizacion] datetime  NULL
);
GO

-- Creating table 'RelPuestoUbicacion'
CREATE TABLE [dbo].[RelPuestoUbicacion] (
    [PK_RelPuestoUbicacion] int IDENTITY(1,1) NOT NULL,
    [FK_UbicacionPuesto] int  NULL,
    [FK_Puesto] int  NULL,
    [FecCreacion] datetime  NULL
);
GO

-- Creating table 'RemuneracionEfectuadaPF'
CREATE TABLE [dbo].[RemuneracionEfectuadaPF] (
    [PK_RemuneracionEfectuadaPF] int IDENTITY(1,1) NOT NULL,
    [FK_PagoFeriado] int  NOT NULL,
    [FK_CatalogoRemuneracion] int  NOT NULL,
    [PorEfectuado] decimal(6,4)  NOT NULL
);
GO

-- Creating table 'Rescision'
CREATE TABLE [dbo].[Rescision] (
    [PK_Rescision] int IDENTITY(1,1) NOT NULL,
    [NumRescision] varchar(15)  NULL,
    [FecRescision] datetime  NULL,
    [NumOficio] varchar(15)  NULL,
    [FecOficio] datetime  NULL,
    [FK_PrestamoPuesto] int  NULL
);
GO

-- Creating table 'ResolucionPedimento'
CREATE TABLE [dbo].[ResolucionPedimento] (
    [PK_ResolucionPedimento] int IDENTITY(1,1) NOT NULL,
    [NumResolucion] varchar(50)  NULL,
    [FecResolucion] datetime  NULL,
    [ObsResolucion] varchar(300)  NULL,
    [FK_PedimentoPuesto] int  NOT NULL,
    [FK_TipoResolucionPedimento] int  NOT NULL
);
GO

-- Creating table 'Seccion'
CREATE TABLE [dbo].[Seccion] (
    [PK_Seccion] int  NOT NULL,
    [NomSeccion] varchar(150)  NULL,
    [IndEstadoSeccion] int  NULL
);
GO

-- Creating table 'SubEspecialidad'
CREATE TABLE [dbo].[SubEspecialidad] (
    [PK_SubEspecialidad] int  NOT NULL,
    [DesSubEspecialidad] varchar(250)  NULL,
    [IndEstadoSubEspecialidad] int  NULL
);
GO

-- Creating table 'SubPartida'
CREATE TABLE [dbo].[SubPartida] (
    [PK_SubPartida] int IDENTITY(1,1) NOT NULL,
    [FK_Partida] int  NULL,
    [CodSubPartida] varchar(5)  NULL,
    [DesSubPartida] varchar(250)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TareasPuesto'
CREATE TABLE [dbo].[TareasPuesto] (
    [PK_TareasPuesto] int IDENTITY(1,1) NOT NULL,
    [DesQueHace] varchar(500)  NULL,
    [DesComoLoHace] varchar(500)  NULL,
    [IndFrecuencia] int  NULL,
    [FK_Puesto] int  NULL
);
GO

-- Creating table 'TipoAccionPersonal'
CREATE TABLE [dbo].[TipoAccionPersonal] (
    [PK_TipoAccionPersonal] int  NOT NULL,
    [DesTipoAccion] varchar(150)  NOT NULL,
    [CodMotivoMovimientoPuesto] int  NOT NULL,
    [IndCategoria] tinyint  NOT NULL
);
GO

-- Creating table 'TipoCambioPorAccionPersonal'
CREATE TABLE [dbo].[TipoCambioPorAccionPersonal] (
    [PK_TipoCambioPorAccionPersonal] int IDENTITY(1,1) NOT NULL,
    [DesTipoCambioPorAccionPersonal] varchar(50)  NULL
);
GO

-- Creating table 'TipoContacto'
CREATE TABLE [dbo].[TipoContacto] (
    [PK_TipoContacto] int IDENTITY(1,1) NOT NULL,
    [DesTipoContacto] varchar(50)  NULL
);
GO

-- Creating table 'TipoDeduccion'
CREATE TABLE [dbo].[TipoDeduccion] (
    [PK_TipoDeduccion] int IDENTITY(1,1) NOT NULL,
    [DesTipDeduccion] varchar(50)  NOT NULL
);
GO

-- Creating table 'TipoDetalleGastoTransporte'
CREATE TABLE [dbo].[TipoDetalleGastoTransporte] (
    [PK_TipoDetallePagoGasto] int IDENTITY(1,1) NOT NULL,
    [DesTipoDetalle] varchar(50)  NOT NULL
);
GO

-- Creating table 'TipoDetallePagoViatico'
CREATE TABLE [dbo].[TipoDetallePagoViatico] (
    [PK_TipoDetallePagoViatico] int  NOT NULL,
    [DesTipoDetalle] varchar(50)  NOT NULL
);
GO

-- Creating table 'TipoDia'
CREATE TABLE [dbo].[TipoDia] (
    [PK_TipoDia] int IDENTITY(1,1) NOT NULL,
    [DesTipoDia] varchar(25)  NOT NULL
);
GO

-- Creating table 'TipoExtra'
CREATE TABLE [dbo].[TipoExtra] (
    [PK_TipoExtra] int IDENTITY(1,1) NOT NULL,
    [DesTipExtra] varchar(50)  NULL
);
GO

-- Creating table 'TipoIncapacidad'
CREATE TABLE [dbo].[TipoIncapacidad] (
    [PK_TipoIncapacidad] int IDENTITY(1,1) NOT NULL,
    [DesIncapacidad] varchar(50)  NULL,
    [FK_EntidadMedica] int  NULL
);
GO

-- Creating table 'TipoJornada'
CREATE TABLE [dbo].[TipoJornada] (
    [PK_TipoJornada] int IDENTITY(1,1) NOT NULL,
    [DesTipoJornada] varchar(150)  NULL,
    [IndInicio] varchar(5)  NULL,
    [IndFin] varchar(5)  NULL,
    [IndAcumulativa] bit  NULL,
    [IndDiaLibre] char(1)  NULL,
    [FK_EstadoTipoJornada] int  NULL
);
GO

-- Creating table 'TipoPrestacion'
CREATE TABLE [dbo].[TipoPrestacion] (
    [PK_TipoPrestacion] int IDENTITY(1,1) NOT NULL,
    [DesPrestacion] varchar(50)  NULL
);
GO

-- Creating table 'TipoPuesto'
CREATE TABLE [dbo].[TipoPuesto] (
    [PK_TipoPuesto] int IDENTITY(1,1) NOT NULL,
    [DesTipoPuesto] varchar(50)  NULL
);
GO

-- Creating table 'TipoResolucionPedimento'
CREATE TABLE [dbo].[TipoResolucionPedimento] (
    [PK_TipoResolucionPedimento] int IDENTITY(1,1) NOT NULL,
    [DesTipoResolucionPedimento] varchar(300)  NULL
);
GO

-- Creating table 'TipoUbicacion'
CREATE TABLE [dbo].[TipoUbicacion] (
    [PK_TipoUbicacion] int IDENTITY(1,1) NOT NULL,
    [DesTipoUbicacion] varchar(50)  NULL
);
GO

-- Creating table 'TituloFactor'
CREATE TABLE [dbo].[TituloFactor] (
    [PK_TituloFactor] int IDENTITY(1,1) NOT NULL,
    [DesTitulo] varchar(50)  NULL
);
GO

-- Creating table 'Tomo'
CREATE TABLE [dbo].[Tomo] (
    [PK_IdTomo] int IDENTITY(1,1) NOT NULL,
    [FK_ExpedienteFuncionario] int  NOT NULL,
    [Descripcion] varchar(300)  NULL,
    [FecCreacion] datetime  NULL,
    [NumTomo] int  NOT NULL
);
GO

-- Creating table 'UbicacionAdministrativa'
CREATE TABLE [dbo].[UbicacionAdministrativa] (
    [PK_UbicacionAdministrativa] int IDENTITY(1,1) NOT NULL,
    [FK_Presupuesto] int  NULL,
    [FK_Seccion] int  NULL,
    [FK_Departamento] int  NULL,
    [FK_DireccionGeneral] int  NULL,
    [FK_Division] int  NULL,
    [DesObservaciones] varchar(250)  NULL
);
GO

-- Creating table 'UbicacionAsueto'
CREATE TABLE [dbo].[UbicacionAsueto] (
    [PK_UbicacionAsueto] int IDENTITY(1,1) NOT NULL,
    [FK_CatalogoDia] int  NOT NULL,
    [FK_Canton] int  NOT NULL
);
GO

-- Creating table 'UbicacionPuesto'
CREATE TABLE [dbo].[UbicacionPuesto] (
    [PK_UbicacionPuesto] int IDENTITY(1,1) NOT NULL,
    [FK_TipoUbicacion] int  NOT NULL,
    [FK_Distrito] int  NOT NULL,
    [ObsUbicacionPuesto] varchar(150)  NULL,
    [IndEstadoUbicacionPuesto] int  NULL,
    [FecCambioUbicacion] datetime  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [PK_Usuario] int IDENTITY(1,1) NOT NULL,
    [NomUsuario] varchar(50)  NULL,
    [TelOficial] varchar(10)  NULL,
    [EmlOficial] varchar(50)  NULL,
    [IndEstadoUsuario] int  NULL,
    [Observacion] varchar(100)  NULL
);
GO

-- Creating table 'ViaticoCorridoReintegroDias'
CREATE TABLE [dbo].[ViaticoCorridoReintegroDias] (
    [PK_Reintegro] int IDENTITY(1,1) NOT NULL,
    [FK_ViaticoCorrido] int  NOT NULL,
    [FecDia] datetime  NOT NULL,
    [MonReintegro] decimal(18,2)  NOT NULL,
    [ObsMotivo] varchar(500)  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'C_Componentes'
CREATE TABLE [dbo].[C_Componentes] (
    [rubro] nvarchar(255)  NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'C_EMU_EXFUNCIONARIOS'
CREATE TABLE [dbo].[C_EMU_EXFUNCIONARIOS] (
    [ISN_ADPEF03M] int  NOT NULL,
    [ULTIMO_PERIODO] char(8)  NULL,
    [ESTADO_FUNC] int  NULL,
    [ESTADO] char(1)  NULL,
    [CEDULA] char(10)  NULL,
    [PRIMER_APELLIDO] char(15)  NULL,
    [SEGUNDO_APELLIDO] char(15)  NULL,
    [NOMBRE] char(15)  NULL,
    [PUESTO_PROPIEDAD] char(7)  NULL,
    [PROGRAMA] char(5)  NULL,
    [PROVINCIA_D] char(1)  NULL,
    [CANTON_D] char(2)  NULL,
    [DISTRITO] char(2)  NULL,
    [PROVINCIA_C] char(1)  NULL,
    [CANTON_C] char(2)  NULL,
    [DISTRITO_C] char(2)  NULL,
    [SENAS] char(70)  NULL,
    [PROVINCIA_T] char(1)  NULL,
    [CANTON_T] char(2)  NULL,
    [DISTRITO_T] char(2)  NULL,
    [TITULO_P] char(5)  NULL,
    [FILLER_P] char(2)  NULL,
    [DIRECCION_P] char(4)  NULL,
    [CLASE_PUESTO] char(5)  NULL,
    [UBIC_REAL] char(20)  NULL,
    [FECHA_INGRESO] datetime  NULL,
    [FECHA_CESE] datetime  NULL,
    [FECHA_CUMPLE] datetime  NULL,
    [SEXO] char(1)  NULL,
    [ESTADO_CIVIL] char(1)  NULL,
    [DIVISION] char(2)  NULL,
    [SUBDIVISION] char(2)  NULL,
    [DIRECCION] char(3)  NULL,
    [DEPARTAMENTO] char(3)  NULL,
    [SECCION] char(3)  NULL,
    [MES_AUMENTO] int  NULL,
    [OCUP_REAL] char(6)  NULL,
    [CATEGORIA] char(4)  NULL,
    [SAL_MENSUAL] decimal(9,2)  NULL,
    [PORC_PROH] int  NULL,
    [PUNTOS] decimal(6,2)  NULL,
    [NUMERO_EXPEDIENTE] char(8)  NULL,
    [NIVEL_OCUPACIONAL] char(2)  NULL,
    [DESARRAIGO] char(2)  NULL,
    [ANO_VACA] int  NULL,
    [MES_VACA] int  NULL,
    [DIA_VACA] int  NULL,
    [CODIGO_INSPECTORES] char(5)  NULL,
    [PASOS_DISF] int  NULL,
    [FECHA_POLICIAL] datetime  NULL
);
GO

-- Creating table 'C_EMU_HistoricoPlanilla'
CREATE TABLE [dbo].[C_EMU_HistoricoPlanilla] (
    [cedula] varchar(15)  NULL,
    [codigo_presupuestario] varchar(25)  NULL,
    [categoria] varchar(10)  NULL,
    [numero_puesto] varchar(10)  NULL,
    [clase_puesto] varchar(10)  NULL,
    [disfrutado] varchar(15)  NULL,
    [codigo_pension] varchar(10)  NULL,
    [base] varchar(30)  NULL,
    [aumentos] varchar(30)  NULL,
    [grupo] varchar(30)  NULL,
    [sobresueldos] varchar(10)  NULL,
    [prohibicion] varchar(30)  NULL,
    [sal_mensual] varchar(30)  NULL,
    [tot_salario] varchar(30)  NULL,
    [ruta] varchar(15)  NULL,
    [fecha_corrida] varchar(15)  NULL,
    [fecha_periodo] varchar(15)  NULL,
    [cedula_nueva] varchar(15)  NULL,
    [cant_puntos] varchar(10)  NULL,
    [porc_dedicacion_exclusiva] varchar(10)  NULL,
    [porc_peligrosidad] varchar(10)  NULL,
    [porc_prohibicion] varchar(10)  NULL,
    [porc_quinquenio] varchar(10)  NULL,
    [porc_disponibilidad] varchar(10)  NULL,
    [porc_grado_academico] varchar(10)  NULL,
    [porc_riesgo_policial] varchar(10)  NULL,
    [porc_curso_basico] varchar(10)  NULL,
    [porc_instruccion_policial] varchar(10)  NULL,
    [porc_bonificacion] varchar(10)  NULL,
    [porc_consulta_externa] varchar(10)  NULL,
    [dedicacion_exclusiva] varchar(30)  NULL,
    [peligrosidad] varchar(30)  NULL,
    [quinquenio] varchar(30)  NULL,
    [disponibilidad] varchar(30)  NULL,
    [grado_academico] varchar(30)  NULL,
    [riesgo_policial] varchar(30)  NULL,
    [curso_basico] varchar(30)  NULL,
    [instruccion_policial] varchar(30)  NULL,
    [bonificacion] varchar(30)  NULL,
    [consulta_externa] varchar(30)  NULL,
    [desarraigo] varchar(30)  NULL,
    [otros_incentivos] varchar(30)  NULL,
    [division] varchar(10)  NULL,
    [direccion] varchar(10)  NULL,
    [departamento] varchar(10)  NULL,
    [seccion] varchar(10)  NULL,
    [programa] varchar(10)  NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'C_InicioPlanilla'
CREATE TABLE [dbo].[C_InicioPlanilla] (
    [cedula] varchar(15)  NULL,
    [codigo_presupuestario] varchar(25)  NULL,
    [categoria] varchar(10)  NULL,
    [numero_puesto] varchar(10)  NULL,
    [clase_puesto] varchar(10)  NULL,
    [disfrutado] varchar(15)  NULL,
    [codigo_pension] varchar(10)  NULL,
    [base] varchar(30)  NULL,
    [aumentos] varchar(30)  NULL,
    [grupo] varchar(30)  NULL,
    [sobresueldos] varchar(10)  NULL,
    [prohibicion] varchar(30)  NULL,
    [sal_mensual] varchar(30)  NULL,
    [tot_salario] varchar(30)  NULL,
    [ruta] varchar(15)  NULL,
    [fecha_corrida] varchar(15)  NULL,
    [fecha_periodo] varchar(15)  NULL,
    [cedula_nueva] varchar(15)  NULL,
    [cant_puntos] varchar(10)  NULL,
    [porc_dedicacion_exclusiva] varchar(10)  NULL,
    [porc_peligrosidad] varchar(10)  NULL,
    [porc_prohibicion] varchar(10)  NULL,
    [porc_quinquenio] varchar(10)  NULL,
    [porc_disponibilidad] varchar(10)  NULL,
    [porc_grado_academico] varchar(10)  NULL,
    [porc_riesgo_policial] varchar(10)  NULL,
    [porc_curso_basico] varchar(10)  NULL,
    [porc_instruccion_policial] varchar(10)  NULL,
    [porc_bonificacion] varchar(10)  NULL,
    [porc_consulta_externa] varchar(10)  NULL,
    [dedicacion_exclusiva] varchar(30)  NULL,
    [peligrosidad] varchar(30)  NULL,
    [quinquenio] varchar(30)  NULL,
    [disponibilidad] varchar(30)  NULL,
    [grado_academico] varchar(30)  NULL,
    [riesgo_policial] varchar(30)  NULL,
    [curso_basico] varchar(30)  NULL,
    [instruccion_policial] varchar(30)  NULL,
    [bonificacion] varchar(30)  NULL,
    [consulta_externa] varchar(30)  NULL,
    [desarraigo] varchar(30)  NULL,
    [otros_incentivos] varchar(30)  NULL,
    [division] varchar(10)  NULL,
    [direccion] varchar(10)  NULL,
    [departamento] varchar(10)  NULL,
    [seccion] varchar(10)  NULL,
    [programa] varchar(10)  NULL,
    [ID] int  NOT NULL,
    [PK_Funcionario] int  NOT NULL
);
GO

-- Creating table 'C_Planilla_Anterior'
CREATE TABLE [dbo].[C_Planilla_Anterior] (
    [cedula] varchar(15)  NULL,
    [codigo_presupuestario] varchar(25)  NULL,
    [categoria] varchar(10)  NULL,
    [numero_puesto] varchar(10)  NULL,
    [clase_puesto] varchar(10)  NULL,
    [disfrutado] varchar(15)  NULL,
    [codigo_pension] varchar(10)  NULL,
    [base] varchar(30)  NULL,
    [aumentos] varchar(30)  NULL,
    [grupo] varchar(30)  NULL,
    [sobresueldos] varchar(10)  NULL,
    [prohibicion] varchar(30)  NULL,
    [sal_mensual] varchar(30)  NULL,
    [tot_salario] varchar(30)  NULL,
    [ruta] varchar(15)  NULL,
    [fecha_corrida] varchar(15)  NULL,
    [fecha_periodo] varchar(15)  NULL,
    [cedula_nueva] varchar(15)  NULL,
    [cant_puntos] varchar(10)  NULL,
    [porc_dedicacion_exclusiva] varchar(10)  NULL,
    [porc_peligrosidad] varchar(10)  NULL,
    [porc_prohibicion] varchar(10)  NULL,
    [porc_quinquenio] varchar(10)  NULL,
    [porc_disponibilidad] varchar(10)  NULL,
    [porc_grado_academico] varchar(10)  NULL,
    [porc_riesgo_policial] varchar(10)  NULL,
    [porc_curso_basico] varchar(10)  NULL,
    [porc_instruccion_policial] varchar(10)  NULL,
    [porc_bonificacion] varchar(10)  NULL,
    [porc_consulta_externa] varchar(10)  NULL,
    [dedicacion_exclusiva] varchar(30)  NULL,
    [peligrosidad] varchar(30)  NULL,
    [quinquenio] varchar(30)  NULL,
    [disponibilidad] varchar(30)  NULL,
    [grado_academico] varchar(30)  NULL,
    [riesgo_policial] varchar(30)  NULL,
    [curso_basico] varchar(30)  NULL,
    [instruccion_policial] varchar(30)  NULL,
    [bonificacion] varchar(30)  NULL,
    [consulta_externa] varchar(30)  NULL,
    [desarraigo] varchar(30)  NULL,
    [otros_incentivos] varchar(30)  NULL,
    [division] varchar(10)  NULL,
    [direccion] varchar(10)  NULL,
    [departamento] varchar(10)  NULL,
    [seccion] varchar(10)  NULL,
    [programa] varchar(10)  NULL,
    [ID] int  NOT NULL
);
GO

-- Creating table 'C_planillacargar'
CREATE TABLE [dbo].[C_planillacargar] (
    [idnuevo] int IDENTITY(1,1) NOT NULL,
    [cedula] varchar(15)  NULL,
    [codigo_presupuestario] varchar(25)  NULL,
    [categoria] varchar(10)  NULL,
    [numero_puesto] varchar(10)  NULL,
    [clase_puesto] varchar(10)  NULL,
    [disfrutado] varchar(15)  NULL,
    [codigo_pension] varchar(10)  NULL,
    [base] varchar(30)  NULL,
    [aumentos] varchar(30)  NULL,
    [grupo] varchar(30)  NULL,
    [sobresueldos] varchar(10)  NULL,
    [prohibicion] varchar(30)  NULL,
    [sal_mensual] varchar(30)  NULL,
    [tot_salario] varchar(30)  NULL,
    [ruta] varchar(15)  NULL,
    [fecha_corrida] varchar(15)  NULL,
    [fecha_periodo] varchar(15)  NULL,
    [cedula_nueva] varchar(15)  NULL,
    [cant_puntos] varchar(10)  NULL,
    [porc_dedicacion_exclusiva] varchar(10)  NULL,
    [porc_peligrosidad] varchar(10)  NULL,
    [porc_prohibicion] varchar(10)  NULL,
    [porc_quinquenio] varchar(10)  NULL,
    [porc_disponibilidad] varchar(10)  NULL,
    [porc_grado_academico] varchar(10)  NULL,
    [porc_riesgo_policial] varchar(10)  NULL,
    [porc_curso_basico] varchar(10)  NULL,
    [porc_instruccion_policial] varchar(10)  NULL,
    [porc_bonificacion] varchar(10)  NULL,
    [porc_consulta_externa] varchar(10)  NULL,
    [dedicacion_exclusiva] varchar(30)  NULL,
    [peligrosidad] varchar(30)  NULL,
    [quinquenio] varchar(30)  NULL,
    [disponibilidad] varchar(30)  NULL,
    [grado_academico] varchar(30)  NULL,
    [riesgo_policial] varchar(30)  NULL,
    [curso_basico] varchar(30)  NULL,
    [instruccion_policial] varchar(30)  NULL,
    [bonificacion] varchar(30)  NULL,
    [consulta_externa] varchar(30)  NULL,
    [desarraigo] varchar(30)  NULL,
    [otros_incentivos] varchar(30)  NULL,
    [division] varchar(10)  NULL,
    [direccion] varchar(10)  NULL,
    [departamento] varchar(10)  NULL,
    [seccion] varchar(10)  NULL,
    [programa] varchar(10)  NULL,
    [ID] int  NOT NULL,
    [PK_Funcionario] int  NOT NULL,
    [PK_Nombramiento] int  NOT NULL
);
GO

-- Creating table 'DecretoComponentePresupuestario'
CREATE TABLE [dbo].[DecretoComponentePresupuestario] (
    [FK_Decreto] int  NOT NULL,
    [FK_ComponentePresupuestario] int  NOT NULL,
    [TipCambio] int  NULL
);
GO

-- Creating table 'Mes'
CREATE TABLE [dbo].[Mes] (
    [PK_Mes] int IDENTITY(1,1) NOT NULL,
    [NomMes] varchar(10)  NULL
);
GO

-- Creating table 'CatDiaViaticoGasto'
CREATE TABLE [dbo].[CatDiaViaticoGasto] (
    [PK_CatalogoDia] int IDENTITY(1,1) NOT NULL,
    [FK_TipoDia] int  NOT NULL,
    [DesDia] varchar(50)  NOT NULL,
    [FecDia] datetime  NOT NULL,
    [IndRebajo] bit  NOT NULL,
    [IndViatico] bit  NOT NULL,
    [IndGasto] bit  NOT NULL
);
GO

-- Creating table 'TipoDeduccionTemporal'
CREATE TABLE [dbo].[TipoDeduccionTemporal] (
    [PK_TipoDeduccionTemporal] int IDENTITY(1,1) NOT NULL,
    [DesTipoDeduccionTemporal] varchar(200)  NULL,
    [IndEstado] int  NOT NULL,
    [IndConSalario] int  NOT NULL
);
GO

-- Creating table 'NotificacionUsuario'
CREATE TABLE [dbo].[NotificacionUsuario] (
    [PK_NotificacionUsuario] int IDENTITY(1,1) NOT NULL,
    [FK_Usuario] int  NULL,
    [FecEnvio] datetime  NULL,
    [DesContenido] varchar(2000)  NULL,
    [EmlDestino] varchar(200)  NULL,
    [CodModulo] int  NULL,
    [IndFuncionario] varchar(10)  NULL,
    [FK_UsuarioDestino] int  NULL,
    [IndAsunto] varchar(50)  NULL
);
GO

-- Creating table 'DetalleAccionPersonalAnterior'
CREATE TABLE [dbo].[DetalleAccionPersonalAnterior] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_AccionPersonal] int  NOT NULL,
    [CodNombramiento] int  NOT NULL,
    [CodNombramientoAnt] int  NOT NULL,
    [CodDetallePuesto] int  NOT NULL,
    [CodDetallePuestoAnt] int  NOT NULL,
    [CodUbicacionAdminitrativa] int  NOT NULL,
    [CodUbicacionAdminitrativaAnt] int  NOT NULL,
    [NumAnualidad] int  NOT NULL,
    [NumAnualidadAnt] int  NOT NULL,
    [NumAnualidadAcumulada] int  NOT NULL,
    [NumAnualidadAcumuladaAnt] int  NOT NULL,
    [CodComponente] int  NOT NULL,
    [MtoComponente] decimal(10,2)  NOT NULL,
    [MtoComponenteAnt] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'DetallePrestacion'
CREATE TABLE [dbo].[DetallePrestacion] (
    [PK_DetallePrestacion] int IDENTITY(1,1) NOT NULL,
    [FK_Presupuesto] int  NOT NULL,
    [FK_Division] int  NULL,
    [FK_DireccionGeneral] int  NULL,
    [FK_Departamento] int  NULL,
    [FK_Seccion] int  NULL,
    [FK_PrestacionLegal] int  NULL,
    [FK_AccionIngreso] int  NULL,
    [FK_AccionCese] int  NULL,
    [NomJefe] varchar(200)  NOT NULL,
    [DesPuestoJefatura] varchar(200)  NOT NULL,
    [FK_Usuario] int  NOT NULL,
    [CntDiasProporcionales] decimal(5,2)  NULL,
    [CntDiasVacaciones] decimal(5,2)  NULL
);
GO

-- Creating table 'ActividadResultadoCargo'
CREATE TABLE [dbo].[ActividadResultadoCargo] (
    [PK_ActividadResultadoCargo] int IDENTITY(1,1) NOT NULL,
    [DesActividadResultadoCargo] varchar(2500)  NULL,
    [FK_ResultadoCargo] int  NULL
);
GO

-- Creating table 'CalificacionObservaciones'
CREATE TABLE [dbo].[CalificacionObservaciones] (
    [PK_Observacion] int  NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [DesObservacion] varchar(300)  NOT NULL,
    [IndEstado] int  NOT NULL,
    [FecRegistro] datetime  NOT NULL
);
GO

-- Creating table 'CatOrdenMovimiento'
CREATE TABLE [dbo].[CatOrdenMovimiento] (
    [AnioRige] varchar(5)  NOT NULL,
    [NumConsecutivo] bigint  NOT NULL
);
GO

-- Creating table 'CompetenciaTransversalCargo'
CREATE TABLE [dbo].[CompetenciaTransversalCargo] (
    [PK_CompetenciaTransversalCargo] int IDENTITY(1,1) NOT NULL,
    [IndTipoCompetencia] int  NULL,
    [IntNivelDominio] int  NULL,
    [FK_Cargo] int  NULL
);
GO

-- Creating table 'ComportamientoGrupoOcupacional'
CREATE TABLE [dbo].[ComportamientoGrupoOcupacional] (
    [PK_ComportamientoGrupoOcupacional] int IDENTITY(1,1) NOT NULL,
    [DesComportamiento] varchar(2500)  NULL,
    [FK_CompetenciaGrupoOcupacional] int  NULL
);
GO

-- Creating table 'ComportamientoTransversal'
CREATE TABLE [dbo].[ComportamientoTransversal] (
    [PK_ComportamientoTransversal] int IDENTITY(1,1) NOT NULL,
    [DesComportamientoTransversal] varchar(2500)  NULL,
    [FK_CompetenciaTransversalCargo] int  NULL
);
GO

-- Creating table 'DetallePrestacionAfiliacion'
CREATE TABLE [dbo].[DetallePrestacionAfiliacion] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_Prestacion] int  NOT NULL,
    [DesAfiliacion] varchar(100)  NOT NULL,
    [MtoAfiliacion] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'DetallePrestacionCuadro'
CREATE TABLE [dbo].[DetallePrestacionCuadro] (
    [PK_DetalleCuadro] int IDENTITY(1,1) NOT NULL,
    [FK_Prestacion] int  NOT NULL,
    [FK_Tipo] int  NOT NULL,
    [FecPeriodo] datetime  NOT NULL,
    [MtoSalario] decimal(18,2)  NOT NULL,
    [MtoVacaciones] decimal(18,2)  NOT NULL,
    [MtoExtras] decimal(18,2)  NOT NULL,
    [MtoFeriados] decimal(18,2)  NOT NULL,
    [MtoTotal] decimal(18,2)  NOT NULL,
    [MtoEscolar] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'EstadoOrdenMovimiento'
CREATE TABLE [dbo].[EstadoOrdenMovimiento] (
    [PK_Estado] int  NOT NULL,
    [DesEstado] varchar(50)  NOT NULL
);
GO

-- Creating table 'EvidenciaComportamientoTransversal'
CREATE TABLE [dbo].[EvidenciaComportamientoTransversal] (
    [PK_EvidenciaComportamientoTransversal] int IDENTITY(1,1) NOT NULL,
    [DesEvidencia] varchar(1500)  NULL,
    [FK_ComportamientoTransversal] int  NULL
);
GO

-- Creating table 'EvidenciaGrupoOcupacional'
CREATE TABLE [dbo].[EvidenciaGrupoOcupacional] (
    [PK_EvidenciaGrupoOcupacional] int IDENTITY(1,1) NOT NULL,
    [DesEvidencia] varchar(1500)  NULL,
    [FK_ComportamientoGrupoOcupacional] int  NULL
);
GO

-- Creating table 'FactorClasificacionCargo'
CREATE TABLE [dbo].[FactorClasificacionCargo] (
    [PK_FactorClasificacion] int IDENTITY(1,1) NOT NULL,
    [DesIndependencia] varchar(800)  NULL,
    [DesSupervisionEjercida] varchar(1000)  NULL,
    [DesLugares] varchar(1200)  NULL,
    [DesAmbiente] varchar(1000)  NULL,
    [DesCondiciones] varchar(1500)  NULL,
    [DesModalidadTrabajo] varchar(1000)  NULL,
    [DesImpactoGestion] varchar(3300)  NULL,
    [DesRelacionesTrabajo] varchar(2500)  NULL,
    [DesActivosEquiposInsumos] varchar(2500)  NULL,
    [FK_Cargo] int  NULL
);
GO

-- Creating table 'OrdenMovimientoDeclaracion'
CREATE TABLE [dbo].[OrdenMovimientoDeclaracion] (
    [PK_Declaracion] int IDENTITY(1,1) NOT NULL,
    [FK_OrdenMovimiento] int  NOT NULL,
    [FecDeclaracion] datetime  NOT NULL,
    [DesCondicionAcademica] varchar(500)  NOT NULL,
    [DesExperiencia] varchar(500)  NOT NULL,
    [DesCapacitacion] varchar(500)  NOT NULL,
    [DesLicencia] varchar(500)  NOT NULL,
    [DesColegiatura] varchar(500)  NOT NULL
);
GO

-- Creating table 'RequerimientoEspecificoCargo'
CREATE TABLE [dbo].[RequerimientoEspecificoCargo] (
    [PK_RequerimientoEspecificoCargo] int IDENTITY(1,1) NOT NULL,
    [DesRequisitosEspecificos] varchar(2500)  NULL,
    [DesConocimientos] varchar(2000)  NULL,
    [FK_Cargo] int  NULL,
    [DesConocimientosDeseables] varchar(2000)  NULL,
    [DesHabilidades] varchar(1500)  NULL
);
GO

-- Creating table 'ResultadoCargo'
CREATE TABLE [dbo].[ResultadoCargo] (
    [PK_ResultadoCargo] int IDENTITY(1,1) NOT NULL,
    [DesResultadoCargo] varchar(1500)  NULL,
    [FK_Cargo] int  NULL
);
GO

-- Creating table 'TipoPoliticaPublica'
CREATE TABLE [dbo].[TipoPoliticaPublica] (
    [PK_TipoPP] int IDENTITY(1,1) NOT NULL,
    [DesTipoPP] varchar(200)  NOT NULL,
    [DesSiglas] varchar(20)  NOT NULL
);
GO

-- Creating table 'TipoPrestacionCuadro'
CREATE TABLE [dbo].[TipoPrestacionCuadro] (
    [PK_TipoCuadro] int  NOT NULL,
    [DesPrestacion] varchar(50)  NOT NULL
);
GO

-- Creating table 'CompetenciaGrupoOcupacional'
CREATE TABLE [dbo].[CompetenciaGrupoOcupacional] (
    [PK_CompetenciaGrupoOcupacional] int IDENTITY(1,1) NOT NULL,
    [IndNivel] int  NULL,
    [NomCompetencia] varchar(300)  NULL,
    [FK_Cargo] int  NULL
);
GO

-- Creating table 'ListaNombramientosActivos'
CREATE TABLE [dbo].[ListaNombramientosActivos] (
    [PK_Nombramiento] int  NOT NULL,
    [PK_Puesto] int  NOT NULL,
    [PK_Funcionario] int  NOT NULL,
    [PK_Seccion] int  NULL,
    [PK_Departamento] int  NULL,
    [PK_Direccion] int  NULL,
    [PK_Division] int  NULL,
    [PK_DetallePuesto] int  NOT NULL,
    [IndPropiedad] int  NOT NULL
);
GO

-- Creating table 'CalificacionEncargado'
CREATE TABLE [dbo].[CalificacionEncargado] (
    [PK_CalificacionEncargado] int IDENTITY(1,1) NOT NULL,
    [FK_Seccion] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'CatMetaEstado'
CREATE TABLE [dbo].[CatMetaEstado] (
    [PK_Estado] int IDENTITY(1,1) NOT NULL,
    [DesEstado] varchar(20)  NOT NULL
);
GO

-- Creating table 'CatMetaPrioridad'
CREATE TABLE [dbo].[CatMetaPrioridad] (
    [PK_Prioridad] int  NOT NULL,
    [DesPrioridad] varchar(20)  NOT NULL
);
GO

-- Creating table 'ObjetivoCalificacion'
CREATE TABLE [dbo].[ObjetivoCalificacion] (
    [PK_ObjetivoCalificacion] int IDENTITY(1,1) NOT NULL,
    [DesObjetivo] varchar(500)  NOT NULL,
    [FK_PeriodoCalificacion] int  NOT NULL,
    [FK_Seccion] int  NOT NULL,
    [DesActividadPresupuestaria] varchar(500)  NOT NULL,
    [DesProductoPrograma] varchar(500)  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'ActividadFuncionario'
CREATE TABLE [dbo].[ActividadFuncionario] (
    [PK_Actividad] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [DesActividad] varchar(300)  NOT NULL,
    [IndEstado] int  NOT NULL,
    [FecDesde] datetime  NOT NULL,
    [FecHasta] datetime  NOT NULL,
    [FecRegistro] datetime  NOT NULL,
    [DesEvidencia] varchar(300)  NOT NULL,
    [DesObservacion] varchar(300)  NOT NULL,
    [IndTeletrabajo] int  NOT NULL
);
GO

-- Creating table 'ContratoArrendamiento'
CREATE TABLE [dbo].[ContratoArrendamiento] (
    [PK_ContratoArrendamiento] int IDENTITY(1,1) NOT NULL,
    [FK_ViaticoCorrido] int  NULL,
    [FK_Desarraigo] int  NULL,
    [FecInicial] datetime  NOT NULL,
    [FecFinal] datetime  NOT NULL,
    [EmisorContrato] varchar(50)  NOT NULL,
    [MonContrato] decimal(10,2)  NOT NULL,
    [CodContrato] varchar(50)  NOT NULL
);
GO

-- Creating table 'DetalleDesarraigoEliminacion'
CREATE TABLE [dbo].[DetalleDesarraigoEliminacion] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_Desarraigo] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [FecEliminacion] datetime  NOT NULL,
    [ObsEliminacion] varchar(250)  NOT NULL,
    [FecRegistro] datetime  NOT NULL
);
GO

-- Creating table 'FacturaDesarraigo'
CREATE TABLE [dbo].[FacturaDesarraigo] (
    [PK_FacturaDesarraigo] int IDENTITY(1,1) NOT NULL,
    [FK_Desarraigo] int  NULL,
    [FK_ViaticoCorrido] int  NULL,
    [FecFacturacion] datetime  NOT NULL,
    [EmisorFactura] varchar(50)  NOT NULL,
    [MonFactura] decimal(10,2)  NOT NULL,
    [CodFactura] varchar(50)  NOT NULL,
    [ObsConcepto] varchar(250)  NULL
);
GO

-- Creating table 'TipoIndicadorMeta'
CREATE TABLE [dbo].[TipoIndicadorMeta] (
    [PK_TipoIndicador] int IDENTITY(1,1) NOT NULL,
    [DesTipoIndicador] varchar(20)  NOT NULL
);
GO

-- Creating table 'Desarraigo'
CREATE TABLE [dbo].[Desarraigo] (
    [PK_Desarraigo] int IDENTITY(1,1) NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [FK_EstadoDesarraigo] int  NOT NULL,
    [FK_DistritoContrato] int  NULL,
    [FK_DistritoTrabajo] int  NULL,
    [FK_Seccion] int  NULL,
    [FK_Departamento] int  NULL,
    [FK_Presupuesto] int  NULL,
    [NumContrato] varchar(50)  NULL,
    [FecInicDesarraigo] datetime  NOT NULL,
    [FecFinDesarraigo] datetime  NOT NULL,
    [FecRegistro] datetime  NOT NULL,
    [MonDesarraigo] decimal(18,2)  NOT NULL,
    [MonSalario] decimal(18,2)  NOT NULL,
    [ObsDesarraigo] varchar(150)  NULL,
    [ObsEstado] varchar(300)  NOT NULL,
    [ImgDocumento] varbinary(max)  NULL,
    [IdJefe] int  NOT NULL,
    [DesNomProyecto] varchar(250)  NOT NULL,
    [FK_DistritoPernocte] int  NOT NULL,
    [DesPernocte] varchar(250)  NOT NULL,
    [IdRegistradoPor] int  NOT NULL,
    [IdAnalizadoPor] int  NOT NULL,
    [IdRevisadoPor] int  NOT NULL,
    [IdAprobadoPor] int  NOT NULL,
    [NumAccionAprobado] varchar(20)  NULL,
    [NumAccionEliminado] varchar(20)  NULL
);
GO

-- Creating table 'DetallePuestoRubro'
CREATE TABLE [dbo].[DetallePuestoRubro] (
    [PK_DetallePuestoRubro] int IDENTITY(1,1) NOT NULL,
    [FK_DetallePuesto] int  NOT NULL,
    [FK_ComponenteSalarial] int  NOT NULL,
    [PorValor] decimal(10,4)  NOT NULL,
    [FecRige] datetime  NOT NULL,
    [FecVence] datetime  NULL
);
GO

-- Creating table 'GastoTransporteRutas'
CREATE TABLE [dbo].[GastoTransporteRutas] (
    [PK_Ruta] int IDENTITY(1,1) NOT NULL,
    [FK_GastoTransporte] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [FecRige] datetime  NOT NULL,
    [FecVence] datetime  NOT NULL,
    [MonGasto] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'MetaIndividualInforme'
CREATE TABLE [dbo].[MetaIndividualInforme] (
    [PK_Informe] int IDENTITY(1,1) NOT NULL,
    [FK_Meta] int  NOT NULL,
    [FecMes] datetime  NOT NULL,
    [NumIndicador] decimal(18,2)  NOT NULL,
    [NumResultadoProduccion] decimal(18,2)  NOT NULL,
    [DesInforme] varchar(300)  NOT NULL,
    [IndCompleto] int  NOT NULL,
    [IndEstado] int  NOT NULL,
    [DesObservaciones] varchar(300)  NULL
);
GO

-- Creating table 'PagoGastoTransporte'
CREATE TABLE [dbo].[PagoGastoTransporte] (
    [PK_PagoGastoTransporte] int IDENTITY(1,1) NOT NULL,
    [FK_GastosTransporte] int  NOT NULL,
    [IndEstado] smallint  NOT NULL,
    [FecPago] datetime  NOT NULL,
    [MonPago] decimal(18,2)  NOT NULL,
    [HojaIndividualizada] varchar(50)  NULL,
    [NumBoleta] varchar(50)  NULL,
    [ReservaRecurso] varchar(50)  NULL,
    [FecRegistro] datetime  NOT NULL,
    [MonContrato] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'DetalleAsignacionGastoTransporte'
CREATE TABLE [dbo].[DetalleAsignacionGastoTransporte] (
    [PK_DetalleAsignacionGastoTransporte] int IDENTITY(1,1) NOT NULL,
    [FK_Ruta] int  NOT NULL,
    [NomRuta] varchar(255)  NOT NULL,
    [NomFraccionamiento] varchar(255)  NOT NULL,
    [MontTarifa] decimal(18,2)  NOT NULL,
    [NumGaceta] varchar(50)  NOT NULL
);
GO

-- Creating table 'PedimentoPuesto'
CREATE TABLE [dbo].[PedimentoPuesto] (
    [PK_PedimentoPuesto] int IDENTITY(1,1) NOT NULL,
    [NumPedimento] varchar(15)  NULL,
    [FK_Puesto] int  NOT NULL,
    [FK_Motivo] int  NOT NULL,
    [FecPedimento] datetime  NULL,
    [IndResolucionPermanente] bit  NULL,
    [ObsPedimento] varchar(500)  NULL
);
GO

-- Creating table 'OrdenMovimiento'
CREATE TABLE [dbo].[OrdenMovimiento] (
    [PK_OrdenMovimiento] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FK_DetallePuesto] int  NOT NULL,
    [FK_Pedimento] int  NULL,
    [FK_TipoMovimiento] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [NumOrden] varchar(50)  NOT NULL,
    [CuentaCliente] varchar(50)  NOT NULL,
    [IdFuncionarioSustituido] int  NOT NULL,
    [FecRige] datetime  NOT NULL,
    [FecVence] datetime  NULL,
    [IdMotivoMovimiento] int  NOT NULL,
    [DesObservaciones] varchar(500)  NOT NULL,
    [DesObservacionesEstado] varchar(500)  NOT NULL,
    [DesPartidaPresupuestaria] varchar(50)  NOT NULL,
    [IdFuncionarioResponsable] int  NOT NULL,
    [IdFuncionarioRevision] int  NOT NULL,
    [IdFuncionarioJefatura] int  NOT NULL
);
GO

-- Creating table 'TEMP_EnviarCorreo'
CREATE TABLE [dbo].[TEMP_EnviarCorreo] (
    [PK_Correo] int IDENTITY(1,1) NOT NULL,
    [Cedula] varchar(20)  NOT NULL,
    [Nombre] varchar(150)  NOT NULL,
    [Correo] varchar(150)  NOT NULL,
    [IdMotivo] int  NOT NULL,
    [FechaEnvio] datetime  NOT NULL
);
GO

-- Creating table 'AccionPersonal'
CREATE TABLE [dbo].[AccionPersonal] (
    [PK_AccionPersonal] int IDENTITY(1,1) NOT NULL,
    [NumAccion] varchar(10)  NOT NULL,
    [AnioRige] varchar(5)  NOT NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [FecRigeIntegra] datetime  NULL,
    [FecVenceIntegra] datetime  NULL,
    [FK_TipoAccionPersonal] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [FK_Nombramiento] int  NULL,
    [Observaciones] varchar(600)  NULL,
    [CodModulo] int  NOT NULL,
    [CodObjetoEntidad] int  NOT NULL,
    [IndDato] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacionSeguimiento'
CREATE TABLE [dbo].[DetalleCalificacionSeguimiento] (
    [PK_Detalle] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionNombramientoFuncionario] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [IdJefatura] int  NOT NULL,
    [FecRegistro] datetime  NOT NULL,
    [DesOportunidadMejora] varchar(500)  NOT NULL,
    [DesPlanAccion] varchar(max)  NOT NULL,
    [FecCierreAccion] datetime  NOT NULL,
    [DesEvidencia] varchar(500)  NOT NULL,
    [DesComentario] varchar(500)  NOT NULL
);
GO

-- Creating table 'FamiliaPuestos'
CREATE TABLE [dbo].[FamiliaPuestos] (
    [PK_Familia] int IDENTITY(1,1) NOT NULL,
    [DesFamilia] varchar(100)  NOT NULL,
    [DesObservaciones] varchar(500)  NOT NULL
);
GO

-- Creating table 'CalificacionCapacitacion'
CREATE TABLE [dbo].[CalificacionCapacitacion] (
    [PK_CalificacionCapacitacion] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionFuncionario] int  NOT NULL,
    [DesCapacitacion] varchar(1000)  NOT NULL,
    [DesTemas] varchar(1000)  NOT NULL,
    [DesObjetivos] varchar(1000)  NOT NULL,
    [FK_TipoPP] int  NOT NULL,
    [DesLineaEstrategica] varchar(1000)  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'CalificacionNombramientoFuncionarios'
CREATE TABLE [dbo].[CalificacionNombramientoFuncionarios] (
    [PK_CalificacionNombramiento] int IDENTITY(1,1) NOT NULL,
    [FK_PeriodoCalificacion] int  NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [FK_Puesto] int  NULL,
    [FK_Funcionario] int  NOT NULL,
    [FecRige] datetime  NULL,
    [FecVence] datetime  NULL,
    [FK_Seccion] int  NULL,
    [FK_Departamento] int  NULL,
    [FK_DireccionGeneral] int  NULL,
    [FK_Division] int  NULL,
    [FK_OcupacionReal] int  NOT NULL,
    [IdJefeInmediato] int  NULL,
    [IdJefeSuperior] int  NULL,
    [NumTipo] int  NOT NULL,
    [ObsNoCalificacion] varchar(200)  NULL,
    [FK_DetallePuesto] int  NOT NULL,
    [PorAutoEvaluacion] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Cargo'
CREATE TABLE [dbo].[Cargo] (
    [PK_Cargo] int IDENTITY(1,1) NOT NULL,
    [IndClase] int  NULL,
    [IndEspecialidad] int  NULL,
    [IndSubespecialidad] int  NULL,
    [IndSeccion] int  NULL,
    [DesProcesoTrabajo] varchar(500)  NULL,
    [NomCargo] varchar(500)  NULL,
    [IndJefaturaInmediata] varchar(500)  NULL,
    [IndJefaturaSuperiorInmediata] varchar(500)  NULL,
    [DesProposito] varchar(2500)  NULL,
    [DesEstrato] varchar(500)  NULL,
    [DesUbicacionOrganizacional] varchar(500)  NULL,
    [IndDeclaracion] bit  NULL,
    [IndPoliza] bit  NULL
);
GO

-- Creating table 'CatPermisoEvidencia'
CREATE TABLE [dbo].[CatPermisoEvidencia] (
    [PK_Permiso] int IDENTITY(1,1) NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [IndArchivo] int  NOT NULL
);
GO

-- Creating table 'MetaObjetivoCalificacion'
CREATE TABLE [dbo].[MetaObjetivoCalificacion] (
    [PK_Meta] int IDENTITY(1,1) NOT NULL,
    [FK_ObjetivoCalificacion] int  NOT NULL,
    [DesMeta] varchar(500)  NOT NULL,
    [FecInicio] datetime  NULL,
    [FecFinalizacion] datetime  NULL,
    [TipMeta] int  NOT NULL,
    [IndEstado] int  NOT NULL,
    [DesProductoEspecifico] varchar(500)  NOT NULL,
    [DesFuenteDatos] varchar(500)  NOT NULL,
    [DesSupuestos] varchar(500)  NOT NULL,
    [DesNotasTecnicas] varchar(500)  NOT NULL,
    [DesTipoIndicador] varchar(500)  NOT NULL,
    [DesIndicador] varchar(500)  NOT NULL,
    [DesDimension] varchar(100)  NOT NULL,
    [DesMetaAnual] varchar(100)  NOT NULL
);
GO

-- Creating table 'CatCampo'
CREATE TABLE [dbo].[CatCampo] (
    [PK_Campo] int  NOT NULL,
    [NomCampo] varchar(50)  NOT NULL,
    [DesTabla] varchar(50)  NOT NULL,
    [DesColumna] varchar(50)  NOT NULL,
    [DesEnPantalla] varchar(50)  NOT NULL
);
GO

-- Creating table 'MetaIndividualEvidencia'
CREATE TABLE [dbo].[MetaIndividualEvidencia] (
    [PK_Evidencia] int IDENTITY(1,1) NOT NULL,
    [FK_Meta] int  NOT NULL,
    [DesEvidencia] varchar(300)  NOT NULL,
    [IndEstado] int  NOT NULL,
    [FecRegistro] datetime  NOT NULL,
    [DesEnlace] varchar(500)  NOT NULL,
    [DocAdjunto] varbinary(max)  NULL,
    [DesObservaciones] varchar(300)  NULL,
    [DesArchivo] varchar(max)  NULL
);
GO

-- Creating table 'C_EMU_CarreraProfesional'
CREATE TABLE [dbo].[C_EMU_CarreraProfesional] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Puesto] int  NULL,
    [Nombre] varchar(45)  NULL,
    [Cedula] varchar(10)  NULL,
    [Clase] int  NULL,
    [Codigo] int  NULL,
    [Division] int  NULL,
    [Direccion] int  NULL,
    [Ubicacion] varchar(25)  NULL,
    [TotalPuntos] decimal(6,2)  NULL,
    [Departamento] int  NULL,
    [ValorPunto] decimal(9,2)  NULL,
    [AnnoExperienciaPR] int  NULL,
    [Aprovechamiento] int  NULL,
    [Participacion] int  NULL,
    [ParticipacionInstruccion] int  NULL,
    [CalificacionServicio] varchar(10)  NULL,
    [HorasAprovechamiento] decimal(9,2)  NULL,
    [HorasParticipacion] decimal(9,2)  NULL,
    [HorasInstruccion] decimal(9,2)  NULL,
    [PtosGrado] decimal(6,2)  NULL,
    [PtosAprovechamiento] decimal(6,2)  NULL,
    [PtosExperienciaPR] decimal(6,2)  NULL,
    [PtosParticipacion] decimal(6,2)  NULL,
    [PtosInstruccion] decimal(6,2)  NULL,
    [PtosOtros] decimal(6,2)  NULL,
    [ExplicacionOtros] varchar(50)  NULL,
    [Observacion] varchar(255)  NULL,
    [PSS1Feri] datetime  NULL,
    [PSS1Feve] datetime  NULL,
    [PSS2Feri] datetime  NULL,
    [PSS2Feve] datetime  NULL,
    [PSS3Feri] datetime  NULL,
    [PSS3Feve] datetime  NULL,
    [MesCarrera] int  NULL,
    [AnnoCarrera] int  NULL,
    [FecRigePago] datetime  NULL,
    [HorasExcParticipacion] decimal(6,2)  NULL,
    [HorasExcAprovechamiento] decimal(6,2)  NULL,
    [NumResolucion] varchar(25)  NULL,
    [FecResolucion] datetime  NULL,
    [Periodo] varchar(10)  NULL,
    [Grado] varchar(10)  NULL,
    [Nivel] char(1)  NULL,
    [AnnoExperienciaEst] int  NULL,
    [AprovechamientoEst] int  NULL,
    [ParticipacionEst] int  NULL,
    [ParticipacionInstruccionEst] int  NULL,
    [HorasAprovechamientoEst] decimal(6,2)  NULL,
    [HorasParticipacionEst] decimal(6,2)  NULL,
    [HorasInstruccionEst] decimal(6,2)  NULL,
    [PtosGradoEst] decimal(6,2)  NULL,
    [PtosAprovechamientoEst] decimal(6,2)  NULL,
    [PtosExperienciaEst] decimal(6,2)  NULL,
    [PtosParticipacionEst] decimal(6,2)  NULL,
    [PtosInstruccionEst] decimal(6,2)  NULL,
    [PtosOtroEst] decimal(6,2)  NULL,
    [ExcParticipacionEst] decimal(6,2)  NULL,
    [ExcAprovechamientoEst] decimal(6,2)  NULL,
    [Marca] char(1)  NULL,
    [Curso1] varchar(30)  NULL,
    [Curso2] varchar(30)  NULL,
    [Curso3] varchar(30)  NULL,
    [Curso4] varchar(30)  NULL,
    [Curso5] varchar(30)  NULL,
    [Curso6] varchar(30)  NULL,
    [Movimiento] varchar(15)  NULL,
    [Curso7] varchar(30)  NULL,
    [Curso8] varchar(30)  NULL,
    [Observacion1] varchar(255)  NULL,
    [Observacion2] varchar(255)  NULL,
    [Observacion3] varchar(255)  NULL,
    [Fecha] datetime  NULL
);
GO

-- Creating table 'C_EMU_Cursos'
CREATE TABLE [dbo].[C_EMU_Cursos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Cedula] varchar(10)  NULL,
    [Nombre] varchar(50)  NULL,
    [NombreCurso] varchar(50)  NULL,
    [TotalHoras] decimal(6,2)  NULL,
    [TipoCurso] varchar(50)  NULL,
    [ImpartidoEn] varchar(50)  NULL,
    [FecRige] datetime  NULL,
    [FecFinal] datetime  NULL,
    [Resolucion] varchar(20)  NULL
);
GO

-- Creating table 'C_EMU_Puntos'
CREATE TABLE [dbo].[C_EMU_Puntos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(30)  NULL,
    [Cedula] varchar(10)  NULL,
    [TotalPuntos] decimal(6,2)  NULL,
    [ValorPunto] int  NULL,
    [AnnoExpPR] int  NULL,
    [Aprovechamiento] int  NULL,
    [Participacion] int  NULL,
    [ParticipacionInstruccion] int  NULL,
    [CalificacionServicio] varchar(15)  NULL,
    [HorasAprovechamiento] decimal(6,2)  NULL,
    [HorasParticipacion] decimal(6,2)  NULL,
    [HorasInstruccion] decimal(6,2)  NULL,
    [PtosGrado] decimal(6,2)  NULL,
    [PtosAprovechamiento] decimal(6,2)  NULL,
    [PtosExpPR] decimal(6,2)  NULL,
    [PtosParticipacion] decimal(6,2)  NULL,
    [PtosInstruccion] decimal(6,2)  NULL,
    [PtosOtros] decimal(6,2)  NULL,
    [ExplicacionOtros] varchar(50)  NULL,
    [Observacion] varchar(255)  NULL,
    [MesCarrera] int  NULL,
    [AnnoCarrera] int  NULL,
    [FecRigePago] datetime  NULL,
    [HsExcPar] decimal(6,2)  NULL,
    [HsExcApr] decimal(6,2)  NULL,
    [NumResolucion] varchar(20)  NULL,
    [FecResolucion] datetime  NULL,
    [Periodo] varchar(10)  NULL,
    [Grado] varchar(20)  NULL,
    [Nivel] char(1)  NULL,
    [AnnoExpEst] decimal(6,2)  NULL,
    [AprovechamientoEst] decimal(6,2)  NULL,
    [ParticipacionEst] decimal(6,2)  NULL,
    [HoraAprEst] decimal(6,2)  NULL,
    [HoraParEst] decimal(6,2)  NULL,
    [PtosGrEst] decimal(6,2)  NULL,
    [PtosAprEst] decimal(6,2)  NULL,
    [PtosExpEst] decimal(6,2)  NULL,
    [PtosParEst] decimal(6,2)  NULL,
    [PtosOtrEst] decimal(6,2)  NULL,
    [ExcParEst] decimal(6,2)  NULL,
    [ExcAprEst] decimal(6,2)  NULL,
    [CAprovechamiento] decimal(6,2)  NULL,
    [CParticipacion] decimal(6,2)  NULL,
    [CInstruccion] decimal(6,2)  NULL,
    [ExpDoc] decimal(6,2)  NULL,
    [Movimiento] varchar(15)  NULL,
    [Observacion1] varchar(255)  NULL,
    [Observacion2] varchar(255)  NULL,
    [Observacion3] varchar(255)  NULL,
    [Fecha] datetime  NULL,
    [PtosPublicacion] decimal(6,2)  NULL,
    [PtosExpDoc] decimal(6,2)  NULL,
    [PtosOrgInt] decimal(6,2)  NULL,
    [RigeEst] datetime  NULL,
    [CalficacionEst] varchar(15)  NULL
);
GO

-- Creating table 'CursoCapacitacion'
CREATE TABLE [dbo].[CursoCapacitacion] (
    [PK_CursoCapacitacion] int IDENTITY(1,1) NOT NULL,
    [IndTotalHoras] int  NULL,
    [IndTotalPuntos] int  NULL,
    [DesCursoCapacitacion] varchar(150)  NULL,
    [NumResolucion] varchar(50)  NULL,
    [FK_Modalidad] int  NULL,
    [FK_FormacionAcademica] int  NULL,
    [FK_EntidadEducativa] int  NULL,
    [FecInicio] datetime  NULL,
    [FecFin] datetime  NULL,
    [ImgTitulo] varbinary(max)  NULL,
    [Estado] int  NULL,
    [Observaciones] varchar(150)  NULL,
    [FecRegistro] datetime  NULL,
    [FecVence] datetime  NULL
);
GO

-- Creating table 'DetallePuntosAdicional'
CREATE TABLE [dbo].[DetallePuntosAdicional] (
    [PK_DetallePuntos] int IDENTITY(1,1) NOT NULL,
    [CantPtos] int  NULL,
    [Observaciones] varchar(255)  NULL,
    [NumDoc] varchar(50)  NULL,
    [FecRegistro] datetime  NULL,
    [FK_FormacionAcademica] int  NOT NULL
);
GO

-- Creating table 'EntidadEducativa'
CREATE TABLE [dbo].[EntidadEducativa] (
    [PK_EntidadEducativa] int IDENTITY(1,1) NOT NULL,
    [NomEntidad] varchar(100)  NULL,
    [TipEntidad] int  NULL,
    [Estado] int  NULL
);
GO

-- Creating table 'ViaticoCorrido'
CREATE TABLE [dbo].[ViaticoCorrido] (
    [PK_ViaticoCorrido] int IDENTITY(1,1) NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [FK_EstadoViaticoCorrido] int  NOT NULL,
    [FK_Presupuesto] int  NOT NULL,
    [MontViaticoCorrido] decimal(18,2)  NOT NULL,
    [MonActual] decimal(18,2)  NOT NULL,
    [ObsViaticoCorrido] varchar(500)  NULL,
    [FecInicViaticoCorrido] datetime  NOT NULL,
    [FecFinViaticoCorrido] datetime  NOT NULL,
    [DesSeñas] varchar(250)  NULL,
    [NumTelDomicilio] varchar(9)  NULL,
    [FK_Distrito] int  NULL,
    [ObsLugarPernocte] varchar(250)  NULL,
    [ObsLugarHospedaje] varchar(250)  NULL,
    [FecRegistro] datetime  NULL,
    [FecContrato] datetime  NULL,
    [NumDocumento] varchar(50)  NULL,
    [IndCabinas] int  NULL,
    [ImgDocumento] varbinary(max)  NULL,
    [FK_DistritoContrato] int  NULL,
    [FK_DistritoTrabajo] int  NULL,
    [IdRegistradoPor] int  NOT NULL,
    [IdAnalizadoPor] int  NOT NULL,
    [IdRevisadoPor] int  NOT NULL,
    [IdAprobadoPor] int  NOT NULL,
    [ObsEstado] varchar(300)  NOT NULL
);
GO

-- Creating table 'GastoTransporte'
CREATE TABLE [dbo].[GastoTransporte] (
    [PK_GastosTransporte] int IDENTITY(1,1) NOT NULL,
    [FK_Nombramiento] int  NULL,
    [FK_EstadoGastosTransporte] int  NULL,
    [MonOriginal] decimal(18,2)  NOT NULL,
    [MonActual] decimal(18,2)  NOT NULL,
    [ObsGastosTransporte] varchar(500)  NULL,
    [FecInicGastosTransporte] datetime  NULL,
    [FecFinGastosTransporte] datetime  NULL,
    [HojaIndividualizada] varchar(50)  NULL,
    [FK_Presupuesto] int  NULL,
    [FecRegistro] datetime  NOT NULL,
    [FecContrato] datetime  NULL,
    [NumDocumento] varchar(50)  NULL,
    [ImgDocumento] varbinary(max)  NULL,
    [FK_DistritoContrato] int  NULL,
    [FK_DistritoTrabajo] int  NULL,
    [IdRegistradoPor] int  NOT NULL,
    [IdAnalizadoPor] int  NOT NULL,
    [IdRevisadoPor] int  NOT NULL,
    [IdAprobadoPor] int  NOT NULL,
    [ObsEstado] varchar(300)  NOT NULL
);
GO

-- Creating table 'EstadoCargo'
CREATE TABLE [dbo].[EstadoCargo] (
    [PK_EstadoCargo] int IDENTITY(1,1) NOT NULL,
    [FK_Cargo] int  NULL,
    [DesEstadoCargo] varchar(1000)  NULL,
    [IndEstadoCargo] int  NULL,
    [FecEstadoCargo] datetime  NULL,
    [UsrRegistro] int  NULL
);
GO

-- Creating table 'CatMetaNivel'
CREATE TABLE [dbo].[CatMetaNivel] (
    [PK_Nivel] int IDENTITY(1,1) NOT NULL,
    [DesNivel] varchar(100)  NOT NULL,
    [DesDetalle] varchar(200)  NOT NULL
);
GO

-- Creating table 'MetaIndividualCalificacion'
CREATE TABLE [dbo].[MetaIndividualCalificacion] (
    [PK_Meta] int IDENTITY(1,1) NOT NULL,
    [FK_PeriodoCalificacion] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FK_Prioridad] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [FK_MetaObjetivo] int  NULL,
    [FK_Nivel] int  NOT NULL,
    [DesMeta] varchar(500)  NOT NULL,
    [FecDesde] datetime  NOT NULL,
    [FecHasta] datetime  NOT NULL,
    [FecFinalizado] datetime  NULL,
    [FecRegistro] datetime  NOT NULL,
    [DesIndicadorMensual] varchar(300)  NOT NULL,
    [FK_TipoIndicador] int  NOT NULL,
    [NumIndicador] decimal(18,2)  NOT NULL,
    [DesResultadoProduccion] varchar(300)  NOT NULL,
    [IndEsTeletrabajable] int  NOT NULL,
    [DesObservaciones] varchar(300)  NOT NULL,
    [IdJefeInmediato] int  NOT NULL,
    [PorPeso] decimal(18,2)  NOT NULL,
    [IndModificar] int  NOT NULL
);
GO

-- Creating table 'CalificacionNombramiento'
CREATE TABLE [dbo].[CalificacionNombramiento] (
    [PK_CalificacionNombramiento] int IDENTITY(1,1) NOT NULL,
    [FK_Calificacion] int  NOT NULL,
    [FK_Nombramiento] int  NOT NULL,
    [FK_PeriodoCalificacion] int  NOT NULL,
    [UsrEvaluador] varchar(250)  NOT NULL,
    [FecCreacion] datetime  NOT NULL,
    [IndEstado] int  NOT NULL,
    [ObsGeneral] varchar(1000)  NULL,
    [ObsCapacitacion] varchar(1000)  NULL,
    [ObsJustificacionCapacitacion] varchar(1000)  NULL,
    [IdJefeInmediato] int  NOT NULL,
    [IdJefeSuperior] int  NOT NULL,
    [IndFormulario] int  NOT NULL,
    [IndRatificado] int  NOT NULL,
    [IndEntregado] int  NOT NULL,
    [IndConformidad] int  NOT NULL,
    [FecRatificacion] datetime  NULL,
    [IdDetallePuesto] int  NOT NULL
);
GO

-- Creating table 'CatCalificacionCompetencias'
CREATE TABLE [dbo].[CatCalificacionCompetencias] (
    [PK_Competencia] int IDENTITY(1,1) NOT NULL,
    [FK_Clase] int  NOT NULL,
    [FK_TipoCompetencia] int  NOT NULL,
    [PorBasico] decimal(18,2)  NOT NULL,
    [PorIntermedio] decimal(18,2)  NOT NULL,
    [PorAvanzado] decimal(18,2)  NOT NULL,
    [PorDestacado] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacionAutoEvaluacion'
CREATE TABLE [dbo].[DetalleCalificacionAutoEvaluacion] (
    [PK_CalificacionAutoEvaluacion] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [FK_Tipo] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacionCompetencia'
CREATE TABLE [dbo].[DetalleCalificacionCompetencia] (
    [PK_CalificacionCompetencia] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [FK_Tipo] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [PorNotaOriginal] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL,
    [DesNotaOriginal] varchar(30)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacionJefeColaborador'
CREATE TABLE [dbo].[DetalleCalificacionJefeColaborador] (
    [PK_CalificacionJefeColaborador] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [FK_Tipo] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacionMeta'
CREATE TABLE [dbo].[DetalleCalificacionMeta] (
    [PK_DetalleMeta] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [FK_Meta] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [PorNotaOriginal] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'DetalleCalificacionServicio'
CREATE TABLE [dbo].[DetalleCalificacionServicio] (
    [PK_CalificacionServicio] int IDENTITY(1,1) NOT NULL,
    [FK_CalificacionNombramiento] int  NOT NULL,
    [FK_Tipo] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL
);
GO

-- Creating table 'EstadoActividadPlan'
CREATE TABLE [dbo].[EstadoActividadPlan] (
    [PK_Estado] int IDENTITY(1,1) NOT NULL,
    [DesEstado] varchar(50)  NOT NULL
);
GO

-- Creating table 'EstadoPlan'
CREATE TABLE [dbo].[EstadoPlan] (
    [PK_EstadoPlan] int  NOT NULL,
    [DesEstadoPlan] varchar(50)  NULL
);
GO

-- Creating table 'PlanAnual'
CREATE TABLE [dbo].[PlanAnual] (
    [PK_PlanAnual] int IDENTITY(1,1) NOT NULL,
    [FK_Seccion] int  NOT NULL,
    [FK_PlanEstrategico] int  NOT NULL,
    [FK_EstadoPlan] int  NOT NULL,
    [NumAnnio] int  NOT NULL,
    [NumVersion] int  NOT NULL,
    [NomPlan] varchar(500)  NOT NULL,
    [NumVersionPlanAnual] int  NOT NULL,
    [ObsObjetivoEspecifico] varchar(500)  NOT NULL
);
GO

-- Creating table 'PlanAnualActividad'
CREATE TABLE [dbo].[PlanAnualActividad] (
    [PK_Actividad] int IDENTITY(1,1) NOT NULL,
    [FK_Meta] int  NOT NULL,
    [FK_EstadoActividad] int  NOT NULL,
    [DesActividad] varchar(200)  NOT NULL,
    [DesActividadAnual] varchar(500)  NOT NULL,
    [PorMeta] decimal(18,0)  NOT NULL,
    [PorAvanceReal] decimal(18,2)  NOT NULL,
    [PorAvancePrevisto] decimal(18,2)  NOT NULL,
    [FecInicioProgramada] datetime  NULL,
    [FecFinalProgramada] datetime  NULL,
    [FecInicioReal] datetime  NULL,
    [FecFinalReal] datetime  NULL,
    [NumVersion] int  NOT NULL,
    [ObsActividad] varchar(500)  NOT NULL
);
GO

-- Creating table 'PlanAnualActividadAvance'
CREATE TABLE [dbo].[PlanAnualActividadAvance] (
    [PK_Avance] int IDENTITY(1,1) NOT NULL,
    [FK_ActividadPlanAnual] int  NOT NULL,
    [NumMes] int  NOT NULL,
    [DesObservacion] varchar(500)  NOT NULL,
    [PorAvance] decimal(18,2)  NOT NULL,
    [DesEvidencia] varchar(500)  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'PlanAnualActividadFuncionario'
CREATE TABLE [dbo].[PlanAnualActividadFuncionario] (
    [PK_ActividadPlanFuncionario] int IDENTITY(1,1) NOT NULL,
    [FK_Actividad] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [IndActivo] bit  NOT NULL
);
GO

-- Creating table 'PlanAnualMeta'
CREATE TABLE [dbo].[PlanAnualMeta] (
    [PK_Meta] int IDENTITY(1,1) NOT NULL,
    [DesMeta] varchar(200)  NOT NULL,
    [PorPeso] decimal(18,0)  NULL,
    [FK_ProductoPlanInstitucional] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'PlanAnualProductos'
CREATE TABLE [dbo].[PlanAnualProductos] (
    [PK_ProductoPlan] int IDENTITY(1,1) NOT NULL,
    [FK_Plan] int  NOT NULL,
    [FK_Producto] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'PlanEstrategico'
CREATE TABLE [dbo].[PlanEstrategico] (
    [PK_PlanEstrategico] int IDENTITY(1,1) NOT NULL,
    [FK_Direccion] int  NOT NULL,
    [FK_EstadoPlan] int  NOT NULL,
    [FecInicio] datetime  NOT NULL,
    [FecFinal] datetime  NOT NULL,
    [NomPlanEstrategico] varchar(50)  NOT NULL,
    [NumVersion] int  NOT NULL
);
GO

-- Creating table 'PlanEstrategicoAccion'
CREATE TABLE [dbo].[PlanEstrategicoAccion] (
    [PK_AccionEstrategica] int  NOT NULL,
    [FK_Producto] int  NOT NULL,
    [DesAccionEstrategica] varchar(1000)  NOT NULL,
    [IndAccionEstrategica] varchar(1000)  NOT NULL,
    [NumAnioInicioEsperado] int  NOT NULL,
    [NumAnioFinalEsperado] int  NOT NULL,
    [NumAnioFinalOficial] int  NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'PlanEstrategicoEje'
CREATE TABLE [dbo].[PlanEstrategicoEje] (
    [PK_Eje] int IDENTITY(1,1) NOT NULL,
    [FK_PlanEstrategico] int  NOT NULL,
    [DesEje] varchar(1000)  NOT NULL,
    [NumEje] int  NOT NULL,
    [FK_Seccion] int  NOT NULL,
    [FK_Departamento] int  NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'PlanEstrategicoLinea'
CREATE TABLE [dbo].[PlanEstrategicoLinea] (
    [PK_Linea] int IDENTITY(1,1) NOT NULL,
    [DesLinea] varchar(1000)  NOT NULL,
    [NumLinea] int  NOT NULL,
    [FK_Eje] int  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'PlanEstrategicoProducto'
CREATE TABLE [dbo].[PlanEstrategicoProducto] (
    [PK_Producto] int IDENTITY(1,1) NOT NULL,
    [FK_Linea] int  NOT NULL,
    [DesProducto] varchar(500)  NOT NULL,
    [IndPrioridad] int  NOT NULL,
    [ObsSituacionActual] varchar(1000)  NOT NULL,
    [ObsResultadoEsperado] varchar(1000)  NOT NULL,
    [IndEstado] int  NOT NULL
);
GO

-- Creating table 'TipoAutoevaluacion'
CREATE TABLE [dbo].[TipoAutoevaluacion] (
    [PK_Tipo] int IDENTITY(1,1) NOT NULL,
    [DesTipo] varchar(100)  NOT NULL,
    [DesDetalle] varchar(500)  NOT NULL
);
GO

-- Creating table 'TipoCalificacionCompetencia'
CREATE TABLE [dbo].[TipoCalificacionCompetencia] (
    [PK_TipoCompetencia] int  NOT NULL,
    [DesTipoCompetencia] varchar(300)  NOT NULL,
    [DesCategoria] varchar(300)  NOT NULL
);
GO

-- Creating table 'TipoCalJefeColaborador'
CREATE TABLE [dbo].[TipoCalJefeColaborador] (
    [PK_Tipo] int IDENTITY(1,1) NOT NULL,
    [DesTipo] varchar(100)  NOT NULL,
    [DesDetalle] varchar(1000)  NOT NULL
);
GO

-- Creating table 'TipoCategoriaServicio'
CREATE TABLE [dbo].[TipoCategoriaServicio] (
    [PK_TipoCategoria] int IDENTITY(1,1) NOT NULL,
    [DesCategoria] varchar(100)  NOT NULL
);
GO

-- Creating table 'CalificacionAutoEvaluacion'
CREATE TABLE [dbo].[CalificacionAutoEvaluacion] (
    [PK_CalificacionAutoEvaluacion] int IDENTITY(1,1) NOT NULL,
    [FK_Periodo] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FK_Tipo] int  NOT NULL,
    [IndEstado] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL
);
GO

-- Creating table 'CalificacionCompromiso'
CREATE TABLE [dbo].[CalificacionCompromiso] (
    [PK_Compromiso] int IDENTITY(1,1) NOT NULL,
    [FK_PeriodoCalificacion] int  NOT NULL,
    [FK_Funcionario] int  NOT NULL,
    [FK_Prioridad] int  NOT NULL,
    [FK_Estado] int  NOT NULL,
    [DesCompromiso] varchar(300)  NOT NULL,
    [FecDesde] datetime  NOT NULL,
    [FecHasta] datetime  NOT NULL,
    [FecFinalizado] datetime  NULL,
    [FecRegistro] datetime  NOT NULL,
    [DesIndicador] varchar(300)  NOT NULL,
    [NumIndicador] decimal(18,2)  NOT NULL,
    [DesObservacion] varchar(300)  NOT NULL
);
GO

-- Creating table 'CalificacionJefeColaborador'
CREATE TABLE [dbo].[CalificacionJefeColaborador] (
    [PK_CalificacionColaborador] int IDENTITY(1,1) NOT NULL,
    [FK_Periodo] int  NOT NULL,
    [FK_Jefatura] int  NOT NULL,
    [FK_Colaborador] int  NOT NULL,
    [FK_TipoCategoria] int  NOT NULL,
    [IndEstado] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL,
    [DesObservaciones] varchar(500)  NOT NULL
);
GO

-- Creating table 'CalificacionServicio'
CREATE TABLE [dbo].[CalificacionServicio] (
    [PK_CalificacionServicio] int IDENTITY(1,1) NOT NULL,
    [FK_Periodo] int  NOT NULL,
    [FK_Direccion] int  NOT NULL,
    [FK_TipoCategoria] int  NOT NULL,
    [IndEstado] int  NOT NULL,
    [PorNota] decimal(18,2)  NOT NULL,
    [DesNota] varchar(30)  NOT NULL
);
GO

-- Creating table 'RegistroTiempoExtra'
CREATE TABLE [dbo].[RegistroTiempoExtra] (
    [PK_RegistroTiempoExtra] int IDENTITY(1,1) NOT NULL,
    [FecEmision] datetime  NULL,
    [IndPeriodo] varchar(6)  NULL,
    [FecPago] datetime  NULL,
    [FK_DesgloseSalarialQ1] int  NULL,
    [FK_DesgloseSalarialQ2] int  NULL,
    [FK_Clase] int  NULL,
    [FK_Presupuesto] int  NULL,
    [IndEstadoExtra] int  NULL,
    [NumOficioJustificacion] varchar(50)  NULL,
    [Justificacion] varchar(1500)  NULL,
    [ArchivoJustificacion] varbinary(max)  NULL,
    [ObsEstado] varchar(2000)  NULL,
    [IndArea] varchar(2)  NULL,
    [IndActividad] varchar(2)  NULL,
    [ObsEstadoDoble] varchar(2000)  NULL,
    [IndEmergenciaNacional] bit  NULL,
    [IndSeccion] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'C_EMU_AccionPersonal'
ALTER TABLE [dbo].[C_EMU_AccionPersonal]
ADD CONSTRAINT [PK_C_EMU_AccionPersonal]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_Calificacion'
ALTER TABLE [dbo].[C_EMU_Calificacion]
ADD CONSTRAINT [PK_C_EMU_Calificacion]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_HistoricoPlanilla_oldie'
ALTER TABLE [dbo].[C_EMU_HistoricoPlanilla_oldie]
ADD CONSTRAINT [PK_C_EMU_HistoricoPlanilla_oldie]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_Vacaciones_Movimiento'
ALTER TABLE [dbo].[C_EMU_Vacaciones_Movimiento]
ADD CONSTRAINT [PK_C_EMU_Vacaciones_Movimiento]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_Vacaciones_Saldo'
ALTER TABLE [dbo].[C_EMU_Vacaciones_Saldo]
ADD CONSTRAINT [PK_C_EMU_Vacaciones_Saldo]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_ViaticoCorrido'
ALTER TABLE [dbo].[C_ViaticoCorrido]
ADD CONSTRAINT [PK_C_ViaticoCorrido]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PK_AddendumPrestamoPuesto] in table 'AddendumPrestamoPuesto'
ALTER TABLE [dbo].[AddendumPrestamoPuesto]
ADD CONSTRAINT [PK_AddendumPrestamoPuesto]
    PRIMARY KEY CLUSTERED ([PK_AddendumPrestamoPuesto] ASC);
GO

-- Creating primary key on [PK_BitacoraIncidencia] in table 'BitacoraIncidencia'
ALTER TABLE [dbo].[BitacoraIncidencia]
ADD CONSTRAINT [PK_BitacoraIncidencia]
    PRIMARY KEY CLUSTERED ([PK_BitacoraIncidencia] ASC);
GO

-- Creating primary key on [PK_BitacoraUsuario] in table 'BitacoraUsuario'
ALTER TABLE [dbo].[BitacoraUsuario]
ADD CONSTRAINT [PK_BitacoraUsuario]
    PRIMARY KEY CLUSTERED ([PK_BitacoraUsuario] ASC);
GO

-- Creating primary key on [PK_IdBoletaPrestamo] in table 'BoletaPrestamo'
ALTER TABLE [dbo].[BoletaPrestamo]
ADD CONSTRAINT [PK_BoletaPrestamo]
    PRIMARY KEY CLUSTERED ([PK_IdBoletaPrestamo] ASC);
GO

-- Creating primary key on [PK_Borrador] in table 'BorradorAccionPersonal'
ALTER TABLE [dbo].[BorradorAccionPersonal]
ADD CONSTRAINT [PK_BorradorAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_Borrador] ASC);
GO

-- Creating primary key on [PK_BotAccionIncidencia] in table 'BotAccionIncidencia'
ALTER TABLE [dbo].[BotAccionIncidencia]
ADD CONSTRAINT [PK_BotAccionIncidencia]
    PRIMARY KEY CLUSTERED ([PK_BotAccionIncidencia] ASC);
GO

-- Creating primary key on [PK_Calificacion] in table 'Calificacion'
ALTER TABLE [dbo].[Calificacion]
ADD CONSTRAINT [PK_Calificacion]
    PRIMARY KEY CLUSTERED ([PK_Calificacion] ASC);
GO

-- Creating primary key on [PK_CalificacionReglaTecnica] in table 'CalificacionReglaTecnica'
ALTER TABLE [dbo].[CalificacionReglaTecnica]
ADD CONSTRAINT [PK_CalificacionReglaTecnica]
    PRIMARY KEY CLUSTERED ([PK_CalificacionReglaTecnica] ASC);
GO

-- Creating primary key on [PK_CambioPorAccionPersonal] in table 'CambioPorAccionPersonal'
ALTER TABLE [dbo].[CambioPorAccionPersonal]
ADD CONSTRAINT [PK_CambioPorAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_CambioPorAccionPersonal] ASC);
GO

-- Creating primary key on [PK_Canton] in table 'Canton'
ALTER TABLE [dbo].[Canton]
ADD CONSTRAINT [PK_Canton]
    PRIMARY KEY CLUSTERED ([PK_Canton] ASC);
GO

-- Creating primary key on [PK_CaracteristicasPuesto] in table 'CaracteristicasPuesto'
ALTER TABLE [dbo].[CaracteristicasPuesto]
ADD CONSTRAINT [PK_CaracteristicasPuesto]
    PRIMARY KEY CLUSTERED ([PK_CaracteristicasPuesto] ASC);
GO

-- Creating primary key on [PK_CartasPresentacion] in table 'CartasPresentacion'
ALTER TABLE [dbo].[CartasPresentacion]
ADD CONSTRAINT [PK_CartasPresentacion]
    PRIMARY KEY CLUSTERED ([PK_CartasPresentacion] ASC);
GO

-- Creating primary key on [PK_CatalogoDeduccion] in table 'CatalogoDeduccion'
ALTER TABLE [dbo].[CatalogoDeduccion]
ADD CONSTRAINT [PK_CatalogoDeduccion]
    PRIMARY KEY CLUSTERED ([PK_CatalogoDeduccion] ASC);
GO

-- Creating primary key on [PK_CatalogoDia] in table 'CatalogoDia'
ALTER TABLE [dbo].[CatalogoDia]
ADD CONSTRAINT [PK_CatalogoDia]
    PRIMARY KEY CLUSTERED ([PK_CatalogoDia] ASC);
GO

-- Creating primary key on [PK_CatalogoIncidencia] in table 'CatalogoIncidencia'
ALTER TABLE [dbo].[CatalogoIncidencia]
ADD CONSTRAINT [PK_CatalogoIncidencia]
    PRIMARY KEY CLUSTERED ([PK_CatalogoIncidencia] ASC);
GO

-- Creating primary key on [PK_CatalogoPregunta] in table 'CatalogoPregunta'
ALTER TABLE [dbo].[CatalogoPregunta]
ADD CONSTRAINT [PK_CatalogoPregunta]
    PRIMARY KEY CLUSTERED ([PK_CatalogoPregunta] ASC);
GO

-- Creating primary key on [PK_CatalogoRemuneracion] in table 'CatalogoRemuneracion'
ALTER TABLE [dbo].[CatalogoRemuneracion]
ADD CONSTRAINT [PK_CatalogoRemuneracion]
    PRIMARY KEY CLUSTERED ([PK_CatalogoRemuneracion] ASC);
GO

-- Creating primary key on [AnioRige] in table 'CatAnioAccionPersonal'
ALTER TABLE [dbo].[CatAnioAccionPersonal]
ADD CONSTRAINT [PK_CatAnioAccionPersonal]
    PRIMARY KEY CLUSTERED ([AnioRige] ASC);
GO

-- Creating primary key on [AnioRige] in table 'CatAnioBoletaPrestamo'
ALTER TABLE [dbo].[CatAnioBoletaPrestamo]
ADD CONSTRAINT [PK_CatAnioBoletaPrestamo]
    PRIMARY KEY CLUSTERED ([AnioRige] ASC);
GO

-- Creating primary key on [PK_CatEstadoCivil] in table 'CatEstadoCivil'
ALTER TABLE [dbo].[CatEstadoCivil]
ADD CONSTRAINT [PK_CatEstadoCivil]
    PRIMARY KEY CLUSTERED ([PK_CatEstadoCivil] ASC);
GO

-- Creating primary key on [PK_CatMovimientoPresupuesto] in table 'CatMovimientoPresupuesto'
ALTER TABLE [dbo].[CatMovimientoPresupuesto]
ADD CONSTRAINT [PK_CatMovimientoPresupuesto]
    PRIMARY KEY CLUSTERED ([PK_CatMovimientoPresupuesto] ASC);
GO

-- Creating primary key on [PK_CatPermiso] in table 'CatPermiso'
ALTER TABLE [dbo].[CatPermiso]
ADD CONSTRAINT [PK_CatPermiso]
    PRIMARY KEY CLUSTERED ([PK_CatPermiso] ASC);
GO

-- Creating primary key on [PK_Caucion] in table 'Caucion'
ALTER TABLE [dbo].[Caucion]
ADD CONSTRAINT [PK_Caucion]
    PRIMARY KEY CLUSTERED ([PK_Caucion] ASC);
GO

-- Creating primary key on [PK_Clase] in table 'Clase'
ALTER TABLE [dbo].[Clase]
ADD CONSTRAINT [PK_Clase]
    PRIMARY KEY CLUSTERED ([PK_Clase] ASC);
GO

-- Creating primary key on [PK_ComponentePresupuestario] in table 'ComponentePresupuestario'
ALTER TABLE [dbo].[ComponentePresupuestario]
ADD CONSTRAINT [PK_ComponentePresupuestario]
    PRIMARY KEY CLUSTERED ([PK_ComponentePresupuestario] ASC);
GO

-- Creating primary key on [PK_ComponenteSalarial] in table 'ComponenteSalarial'
ALTER TABLE [dbo].[ComponenteSalarial]
ADD CONSTRAINT [PK_ComponenteSalarial]
    PRIMARY KEY CLUSTERED ([PK_ComponenteSalarial] ASC);
GO

-- Creating primary key on [PK_ContenidoPresupuestario] in table 'ContenidoPresupuestario'
ALTER TABLE [dbo].[ContenidoPresupuestario]
ADD CONSTRAINT [PK_ContenidoPresupuestario]
    PRIMARY KEY CLUSTERED ([PK_ContenidoPresupuestario] ASC);
GO

-- Creating primary key on [PK_CuentaBancaria] in table 'CuentaBancaria'
ALTER TABLE [dbo].[CuentaBancaria]
ADD CONSTRAINT [PK_CuentaBancaria]
    PRIMARY KEY CLUSTERED ([PK_CuentaBancaria] ASC);
GO

-- Creating primary key on [PK_CursoGrado] in table 'CursoGrado'
ALTER TABLE [dbo].[CursoGrado]
ADD CONSTRAINT [PK_CursoGrado]
    PRIMARY KEY CLUSTERED ([PK_CursoGrado] ASC);
GO

-- Creating primary key on [PK_Decreto] in table 'Decreto'
ALTER TABLE [dbo].[Decreto]
ADD CONSTRAINT [PK_Decreto]
    PRIMARY KEY CLUSTERED ([PK_Decreto] ASC);
GO

-- Creating primary key on [PK_DeduccionEfectuada] in table 'DeduccionEfectuada'
ALTER TABLE [dbo].[DeduccionEfectuada]
ADD CONSTRAINT [PK_DeduccionEfectuada]
    PRIMARY KEY CLUSTERED ([PK_DeduccionEfectuada] ASC);
GO

-- Creating primary key on [PK_DeduccionTemporal] in table 'DeduccionTemporal'
ALTER TABLE [dbo].[DeduccionTemporal]
ADD CONSTRAINT [PK_DeduccionTemporal]
    PRIMARY KEY CLUSTERED ([PK_DeduccionTemporal] ASC);
GO

-- Creating primary key on [PK_Departamento] in table 'Departamento'
ALTER TABLE [dbo].[Departamento]
ADD CONSTRAINT [PK_Departamento]
    PRIMARY KEY CLUSTERED ([PK_Departamento] ASC);
GO

-- Creating primary key on [PK_DesgloseSalarial] in table 'DesgloseSalarial'
ALTER TABLE [dbo].[DesgloseSalarial]
ADD CONSTRAINT [PK_DesgloseSalarial]
    PRIMARY KEY CLUSTERED ([PK_DesgloseSalarial] ASC);
GO

-- Creating primary key on [PK_DetalleAcceso] in table 'DetalleAcceso'
ALTER TABLE [dbo].[DetalleAcceso]
ADD CONSTRAINT [PK_DetalleAcceso]
    PRIMARY KEY CLUSTERED ([PK_DetalleAcceso] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetalleAccionPersonal'
ALTER TABLE [dbo].[DetalleAccionPersonal]
ADD CONSTRAINT [PK_DetalleAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_DetalleAsignacionGastoModificada] in table 'DetalleAsignacionGastoTransporteModificada'
ALTER TABLE [dbo].[DetalleAsignacionGastoTransporteModificada]
ADD CONSTRAINT [PK_DetalleAsignacionGastoTransporteModificada]
    PRIMARY KEY CLUSTERED ([PK_DetalleAsignacionGastoModificada] ASC);
GO

-- Creating primary key on [PK_IdDetalleBoleta] in table 'DetalleBoleta'
ALTER TABLE [dbo].[DetalleBoleta]
ADD CONSTRAINT [PK_DetalleBoleta]
    PRIMARY KEY CLUSTERED ([PK_IdDetalleBoleta] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetalleBorradorAccionPersonal'
ALTER TABLE [dbo].[DetalleBorradorAccionPersonal]
ADD CONSTRAINT [PK_DetalleBorradorAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_DetalleCalificacion] in table 'DetalleCalificacion'
ALTER TABLE [dbo].[DetalleCalificacion]
ADD CONSTRAINT [PK_DetalleCalificacion]
    PRIMARY KEY CLUSTERED ([PK_DetalleCalificacion] ASC);
GO

-- Creating primary key on [PK_DetalleCalificacion] in table 'DetalleCalificacionModificada'
ALTER TABLE [dbo].[DetalleCalificacionModificada]
ADD CONSTRAINT [PK_DetalleCalificacionModificada]
    PRIMARY KEY CLUSTERED ([PK_DetalleCalificacion] ASC);
GO

-- Creating primary key on [PK_DetalleCambioPedimento] in table 'DetalleCambioPedimento'
ALTER TABLE [dbo].[DetalleCambioPedimento]
ADD CONSTRAINT [PK_DetalleCambioPedimento]
    PRIMARY KEY CLUSTERED ([PK_DetalleCambioPedimento] ASC);
GO

-- Creating primary key on [PK_DetalleContratacion] in table 'DetalleContratacion'
ALTER TABLE [dbo].[DetalleContratacion]
ADD CONSTRAINT [PK_DetalleContratacion]
    PRIMARY KEY CLUSTERED ([PK_DetalleContratacion] ASC);
GO

-- Creating primary key on [PK_DetalleDeduccion] in table 'DetalleDeduccion'
ALTER TABLE [dbo].[DetalleDeduccion]
ADD CONSTRAINT [PK_DetalleDeduccion]
    PRIMARY KEY CLUSTERED ([PK_DetalleDeduccion] ASC);
GO

-- Creating primary key on [PK_DetalleDeduccionGastoTransporte] in table 'DetalleDeduccionGastoTransporte'
ALTER TABLE [dbo].[DetalleDeduccionGastoTransporte]
ADD CONSTRAINT [PK_DetalleDeduccionGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_DetalleDeduccionGastoTransporte] ASC);
GO

-- Creating primary key on [PK_DetalleDeduccionViaticoCorrido] in table 'DetalleDeduccionViaticoCorrido'
ALTER TABLE [dbo].[DetalleDeduccionViaticoCorrido]
ADD CONSTRAINT [PK_DetalleDeduccionViaticoCorrido]
    PRIMARY KEY CLUSTERED ([PK_DetalleDeduccionViaticoCorrido] ASC);
GO

-- Creating primary key on [PK_DetalleDesgloceSalarial] in table 'DetalleDesgloseSalarial'
ALTER TABLE [dbo].[DetalleDesgloseSalarial]
ADD CONSTRAINT [PK_DetalleDesgloseSalarial]
    PRIMARY KEY CLUSTERED ([PK_DetalleDesgloceSalarial] ASC);
GO

-- Creating primary key on [PK_DetalleEliminacionViaticoCorrido] in table 'DetalleEliminacionViaticoCorridoGastoTransporte'
ALTER TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte]
ADD CONSTRAINT [PK_DetalleEliminacionViaticoCorridoGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_DetalleEliminacionViaticoCorrido] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetalleIncapacidad'
ALTER TABLE [dbo].[DetalleIncapacidad]
ADD CONSTRAINT [PK_DetalleIncapacidad]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_DetallePago] in table 'DetallePagoGastoTransporte'
ALTER TABLE [dbo].[DetallePagoGastoTransporte]
ADD CONSTRAINT [PK_DetallePagoGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_DetallePago] ASC);
GO

-- Creating primary key on [PK_DetallePago] in table 'DetallePagoViaticoCorrido'
ALTER TABLE [dbo].[DetallePagoViaticoCorrido]
ADD CONSTRAINT [PK_DetallePagoViaticoCorrido]
    PRIMARY KEY CLUSTERED ([PK_DetallePago] ASC);
GO

-- Creating primary key on [PK_DetallePago] in table 'DetallePagoViaticoRetroactivo'
ALTER TABLE [dbo].[DetallePagoViaticoRetroactivo]
ADD CONSTRAINT [PK_DetallePagoViaticoRetroactivo]
    PRIMARY KEY CLUSTERED ([PK_DetallePago] ASC);
GO

-- Creating primary key on [PK_DetallePuesto] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [PK_DetallePuesto]
    PRIMARY KEY CLUSTERED ([PK_DetallePuesto] ASC);
GO

-- Creating primary key on [PK_DetalleTiempoExtra] in table 'DetalleTiempoExtra'
ALTER TABLE [dbo].[DetalleTiempoExtra]
ADD CONSTRAINT [PK_DetalleTiempoExtra]
    PRIMARY KEY CLUSTERED ([PK_DetalleTiempoExtra] ASC);
GO

-- Creating primary key on [PK_DiaPagado] in table 'DiaPagado'
ALTER TABLE [dbo].[DiaPagado]
ADD CONSTRAINT [PK_DiaPagado]
    PRIMARY KEY CLUSTERED ([PK_DiaPagado] ASC);
GO

-- Creating primary key on [PK_Direccion] in table 'Direccion'
ALTER TABLE [dbo].[Direccion]
ADD CONSTRAINT [PK_Direccion]
    PRIMARY KEY CLUSTERED ([PK_Direccion] ASC);
GO

-- Creating primary key on [PK_DireccionGeneral] in table 'DireccionGeneral'
ALTER TABLE [dbo].[DireccionGeneral]
ADD CONSTRAINT [PK_DireccionGeneral]
    PRIMARY KEY CLUSTERED ([PK_DireccionGeneral] ASC);
GO

-- Creating primary key on [PK_Distrito] in table 'Distrito'
ALTER TABLE [dbo].[Distrito]
ADD CONSTRAINT [PK_Distrito]
    PRIMARY KEY CLUSTERED ([PK_Distrito] ASC);
GO

-- Creating primary key on [PK_Division] in table 'Division'
ALTER TABLE [dbo].[Division]
ADD CONSTRAINT [PK_Division]
    PRIMARY KEY CLUSTERED ([PK_Division] ASC);
GO

-- Creating primary key on [PK_EntidadAdscrita] in table 'EntidadAdscrita'
ALTER TABLE [dbo].[EntidadAdscrita]
ADD CONSTRAINT [PK_EntidadAdscrita]
    PRIMARY KEY CLUSTERED ([PK_EntidadAdscrita] ASC);
GO

-- Creating primary key on [PK_EntidadFinanciera] in table 'EntidadFinanciera'
ALTER TABLE [dbo].[EntidadFinanciera]
ADD CONSTRAINT [PK_EntidadFinanciera]
    PRIMARY KEY CLUSTERED ([PK_EntidadFinanciera] ASC);
GO

-- Creating primary key on [PK_EntidadGubernamental] in table 'EntidadGubernamental'
ALTER TABLE [dbo].[EntidadGubernamental]
ADD CONSTRAINT [PK_EntidadGubernamental]
    PRIMARY KEY CLUSTERED ([PK_EntidadGubernamental] ASC);
GO

-- Creating primary key on [PK_EntidadMedica] in table 'EntidadMedica'
ALTER TABLE [dbo].[EntidadMedica]
ADD CONSTRAINT [PK_EntidadMedica]
    PRIMARY KEY CLUSTERED ([PK_EntidadMedica] ASC);
GO

-- Creating primary key on [PK_EntidadSeguros] in table 'EntidadSeguros'
ALTER TABLE [dbo].[EntidadSeguros]
ADD CONSTRAINT [PK_EntidadSeguros]
    PRIMARY KEY CLUSTERED ([PK_EntidadSeguros] ASC);
GO

-- Creating primary key on [PK_Escala] in table 'EscalaSalarial'
ALTER TABLE [dbo].[EscalaSalarial]
ADD CONSTRAINT [PK_EscalaSalarial]
    PRIMARY KEY CLUSTERED ([PK_Escala] ASC);
GO

-- Creating primary key on [PK_Especialidad] in table 'Especialidad'
ALTER TABLE [dbo].[Especialidad]
ADD CONSTRAINT [PK_Especialidad]
    PRIMARY KEY CLUSTERED ([PK_Especialidad] ASC);
GO

-- Creating primary key on [PK_EstadoBorrador] in table 'EstadoBorrador'
ALTER TABLE [dbo].[EstadoBorrador]
ADD CONSTRAINT [PK_EstadoBorrador]
    PRIMARY KEY CLUSTERED ([PK_EstadoBorrador] ASC);
GO

-- Creating primary key on [PK_EstadoDesarraigo] in table 'EstadoDesarraigo'
ALTER TABLE [dbo].[EstadoDesarraigo]
ADD CONSTRAINT [PK_EstadoDesarraigo]
    PRIMARY KEY CLUSTERED ([PK_EstadoDesarraigo] ASC);
GO

-- Creating primary key on [PK_EstadoFuncionario] in table 'EstadoFuncionario'
ALTER TABLE [dbo].[EstadoFuncionario]
ADD CONSTRAINT [PK_EstadoFuncionario]
    PRIMARY KEY CLUSTERED ([PK_EstadoFuncionario] ASC);
GO

-- Creating primary key on [PK_EstadoGastosTransporte] in table 'EstadoGastoTransporte'
ALTER TABLE [dbo].[EstadoGastoTransporte]
ADD CONSTRAINT [PK_EstadoGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_EstadoGastosTransporte] ASC);
GO

-- Creating primary key on [PK_EstadoMovimientoPuesto] in table 'EstadoMovimientoPuesto'
ALTER TABLE [dbo].[EstadoMovimientoPuesto]
ADD CONSTRAINT [PK_EstadoMovimientoPuesto]
    PRIMARY KEY CLUSTERED ([PK_EstadoMovimientoPuesto] ASC);
GO

-- Creating primary key on [PK_EstadoNombramiento] in table 'EstadoNombramiento'
ALTER TABLE [dbo].[EstadoNombramiento]
ADD CONSTRAINT [PK_EstadoNombramiento]
    PRIMARY KEY CLUSTERED ([PK_EstadoNombramiento] ASC);
GO

-- Creating primary key on [PK_EstadoPedimento] in table 'EstadoPedimento'
ALTER TABLE [dbo].[EstadoPedimento]
ADD CONSTRAINT [PK_EstadoPedimento]
    PRIMARY KEY CLUSTERED ([PK_EstadoPedimento] ASC);
GO

-- Creating primary key on [PK_EstadoPuesto] in table 'EstadoPuesto'
ALTER TABLE [dbo].[EstadoPuesto]
ADD CONSTRAINT [PK_EstadoPuesto]
    PRIMARY KEY CLUSTERED ([PK_EstadoPuesto] ASC);
GO

-- Creating primary key on [PK_EstadoTipoJornada] in table 'EstadoTipoJornada'
ALTER TABLE [dbo].[EstadoTipoJornada]
ADD CONSTRAINT [PK_EstadoTipoJornada]
    PRIMARY KEY CLUSTERED ([PK_EstadoTipoJornada] ASC);
GO

-- Creating primary key on [PK_EstadoTramite] in table 'EstadoTramite'
ALTER TABLE [dbo].[EstadoTramite]
ADD CONSTRAINT [PK_EstadoTramite]
    PRIMARY KEY CLUSTERED ([PK_EstadoTramite] ASC);
GO

-- Creating primary key on [PK_EstadoViaticoCorrido] in table 'EstadoViaticoCorrido'
ALTER TABLE [dbo].[EstadoViaticoCorrido]
ADD CONSTRAINT [PK_EstadoViaticoCorrido]
    PRIMARY KEY CLUSTERED ([PK_EstadoViaticoCorrido] ASC);
GO

-- Creating primary key on [PK_EstudioPuesto] in table 'EstudioPuesto'
ALTER TABLE [dbo].[EstudioPuesto]
ADD CONSTRAINT [PK_EstudioPuesto]
    PRIMARY KEY CLUSTERED ([PK_EstudioPuesto] ASC);
GO

-- Creating primary key on [PK_IdExpedienteFuncionario] in table 'ExpedienteFuncionario'
ALTER TABLE [dbo].[ExpedienteFuncionario]
ADD CONSTRAINT [PK_ExpedienteFuncionario]
    PRIMARY KEY CLUSTERED ([PK_IdExpedienteFuncionario] ASC);
GO

-- Creating primary key on [PK_ExperienciaProfesional] in table 'ExperienciaProfesional'
ALTER TABLE [dbo].[ExperienciaProfesional]
ADD CONSTRAINT [PK_ExperienciaProfesional]
    PRIMARY KEY CLUSTERED ([PK_ExperienciaProfesional] ASC);
GO

-- Creating primary key on [PK_Factor] in table 'Factor'
ALTER TABLE [dbo].[Factor]
ADD CONSTRAINT [PK_Factor]
    PRIMARY KEY CLUSTERED ([PK_Factor] ASC);
GO

-- Creating primary key on [PK_IdFolio] in table 'Folio'
ALTER TABLE [dbo].[Folio]
ADD CONSTRAINT [PK_Folio]
    PRIMARY KEY CLUSTERED ([PK_IdFolio] ASC);
GO

-- Creating primary key on [PK_FormacionAcademica] in table 'FormacionAcademica'
ALTER TABLE [dbo].[FormacionAcademica]
ADD CONSTRAINT [PK_FormacionAcademica]
    PRIMARY KEY CLUSTERED ([PK_FormacionAcademica] ASC);
GO

-- Creating primary key on [PK_Funcionario] in table 'Funcionario'
ALTER TABLE [dbo].[Funcionario]
ADD CONSTRAINT [PK_Funcionario]
    PRIMARY KEY CLUSTERED ([PK_Funcionario] ASC);
GO

-- Creating primary key on [PK_Reintegro] in table 'GastoTransporteReintegroDias'
ALTER TABLE [dbo].[GastoTransporteReintegroDias]
ADD CONSTRAINT [PK_GastoTransporteReintegroDias]
    PRIMARY KEY CLUSTERED ([PK_Reintegro] ASC);
GO

-- Creating primary key on [PK_HistorialEstadoCivil] in table 'HistorialEstadoCivil'
ALTER TABLE [dbo].[HistorialEstadoCivil]
ADD CONSTRAINT [PK_HistorialEstadoCivil]
    PRIMARY KEY CLUSTERED ([PK_HistorialEstadoCivil] ASC);
GO

-- Creating primary key on [PK_Incidencia] in table 'Incidencia'
ALTER TABLE [dbo].[Incidencia]
ADD CONSTRAINT [PK_Incidencia]
    PRIMARY KEY CLUSTERED ([PK_Incidencia] ASC);
GO

-- Creating primary key on [PK_InformacionContacto] in table 'InformacionContacto'
ALTER TABLE [dbo].[InformacionContacto]
ADD CONSTRAINT [PK_InformacionContacto]
    PRIMARY KEY CLUSTERED ([PK_InformacionContacto] ASC);
GO

-- Creating primary key on [PK_Modalidad] in table 'Modalidad'
ALTER TABLE [dbo].[Modalidad]
ADD CONSTRAINT [PK_Modalidad]
    PRIMARY KEY CLUSTERED ([PK_Modalidad] ASC);
GO

-- Creating primary key on [PK_MontoCaucion] in table 'MontoCaucion'
ALTER TABLE [dbo].[MontoCaucion]
ADD CONSTRAINT [PK_MontoCaucion]
    PRIMARY KEY CLUSTERED ([PK_MontoCaucion] ASC);
GO

-- Creating primary key on [PK_MotivoMovimiento] in table 'MotivoMovimiento'
ALTER TABLE [dbo].[MotivoMovimiento]
ADD CONSTRAINT [PK_MotivoMovimiento]
    PRIMARY KEY CLUSTERED ([PK_MotivoMovimiento] ASC);
GO

-- Creating primary key on [PK_MotivoPedimento] in table 'MotivoPedimento'
ALTER TABLE [dbo].[MotivoPedimento]
ADD CONSTRAINT [PK_MotivoPedimento]
    PRIMARY KEY CLUSTERED ([PK_MotivoPedimento] ASC);
GO

-- Creating primary key on [PK_MovimientoBorrador] in table 'MovimientoBorradorAccionPersonal'
ALTER TABLE [dbo].[MovimientoBorradorAccionPersonal]
ADD CONSTRAINT [PK_MovimientoBorradorAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_MovimientoBorrador] ASC);
GO

-- Creating primary key on [PK_MovimientoGastosTransporte] in table 'MovimientoGastoTransporte'
ALTER TABLE [dbo].[MovimientoGastoTransporte]
ADD CONSTRAINT [PK_MovimientoGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_MovimientoGastosTransporte] ASC);
GO

-- Creating primary key on [PK_MovimientoPuesto] in table 'MovimientoPuesto'
ALTER TABLE [dbo].[MovimientoPuesto]
ADD CONSTRAINT [PK_MovimientoPuesto]
    PRIMARY KEY CLUSTERED ([PK_MovimientoPuesto] ASC);
GO

-- Creating primary key on [PK_MovimientoViaticoCorrido] in table 'MovimientoViaticoCorrido'
ALTER TABLE [dbo].[MovimientoViaticoCorrido]
ADD CONSTRAINT [PK_MovimientoViaticoCorrido]
    PRIMARY KEY CLUSTERED ([PK_MovimientoViaticoCorrido] ASC);
GO

-- Creating primary key on [PK_Nombramiento] in table 'Nombramiento'
ALTER TABLE [dbo].[Nombramiento]
ADD CONSTRAINT [PK_Nombramiento]
    PRIMARY KEY CLUSTERED ([PK_Nombramiento] ASC);
GO

-- Creating primary key on [PK_ObjetoGasto] in table 'ObjetoGasto'
ALTER TABLE [dbo].[ObjetoGasto]
ADD CONSTRAINT [PK_ObjetoGasto]
    PRIMARY KEY CLUSTERED ([PK_ObjetoGasto] ASC);
GO

-- Creating primary key on [PK_OcupacionReal] in table 'OcupacionReal'
ALTER TABLE [dbo].[OcupacionReal]
ADD CONSTRAINT [PK_OcupacionReal]
    PRIMARY KEY CLUSTERED ([PK_OcupacionReal] ASC);
GO

-- Creating primary key on [PK_PagoExtraordinario] in table 'PagoExtraordinario'
ALTER TABLE [dbo].[PagoExtraordinario]
ADD CONSTRAINT [PK_PagoExtraordinario]
    PRIMARY KEY CLUSTERED ([PK_PagoExtraordinario] ASC);
GO

-- Creating primary key on [PK_PagoFeriado] in table 'PagoFeriado'
ALTER TABLE [dbo].[PagoFeriado]
ADD CONSTRAINT [PK_PagoFeriado]
    PRIMARY KEY CLUSTERED ([PK_PagoFeriado] ASC);
GO

-- Creating primary key on [PK_PagoPrestacion] in table 'PagoPrestacion'
ALTER TABLE [dbo].[PagoPrestacion]
ADD CONSTRAINT [PK_PagoPrestacion]
    PRIMARY KEY CLUSTERED ([PK_PagoPrestacion] ASC);
GO

-- Creating primary key on [PK_PagoViaticoCorrido] in table 'PagoViaticoCorrido'
ALTER TABLE [dbo].[PagoViaticoCorrido]
ADD CONSTRAINT [PK_PagoViaticoCorrido]
    PRIMARY KEY CLUSTERED ([PK_PagoViaticoCorrido] ASC);
GO

-- Creating primary key on [PK_PagoViaticoRetroactivo] in table 'PagoViaticoRetroactivo'
ALTER TABLE [dbo].[PagoViaticoRetroactivo]
ADD CONSTRAINT [PK_PagoViaticoRetroactivo]
    PRIMARY KEY CLUSTERED ([PK_PagoViaticoRetroactivo] ASC);
GO

-- Creating primary key on [PK_Partida] in table 'Partida'
ALTER TABLE [dbo].[Partida]
ADD CONSTRAINT [PK_Partida]
    PRIMARY KEY CLUSTERED ([PK_Partida] ASC);
GO

-- Creating primary key on [PK_Perfil] in table 'Perfil'
ALTER TABLE [dbo].[Perfil]
ADD CONSTRAINT [PK_Perfil]
    PRIMARY KEY CLUSTERED ([PK_Perfil] ASC);
GO

-- Creating primary key on [PK_PerfilAcceso] in table 'PerfilAcceso'
ALTER TABLE [dbo].[PerfilAcceso]
ADD CONSTRAINT [PK_PerfilAcceso]
    PRIMARY KEY CLUSTERED ([PK_PerfilAcceso] ASC);
GO

-- Creating primary key on [PK_PeriodoCalificacion] in table 'PeriodoCalificacion'
ALTER TABLE [dbo].[PeriodoCalificacion]
ADD CONSTRAINT [PK_PeriodoCalificacion]
    PRIMARY KEY CLUSTERED ([PK_PeriodoCalificacion] ASC);
GO

-- Creating primary key on [PK_Periodo] in table 'PeriodoEscalaSalarial'
ALTER TABLE [dbo].[PeriodoEscalaSalarial]
ADD CONSTRAINT [PK_PeriodoEscalaSalarial]
    PRIMARY KEY CLUSTERED ([PK_Periodo] ASC);
GO

-- Creating primary key on [PK_PeriodoVacaciones] in table 'PeriodoVacaciones'
ALTER TABLE [dbo].[PeriodoVacaciones]
ADD CONSTRAINT [PK_PeriodoVacaciones]
    PRIMARY KEY CLUSTERED ([PK_PeriodoVacaciones] ASC);
GO

-- Creating primary key on [PK_PrestacionLegal] in table 'PrestacionLegal'
ALTER TABLE [dbo].[PrestacionLegal]
ADD CONSTRAINT [PK_PrestacionLegal]
    PRIMARY KEY CLUSTERED ([PK_PrestacionLegal] ASC);
GO

-- Creating primary key on [PK_PrestamoPuesto] in table 'PrestamoPuesto'
ALTER TABLE [dbo].[PrestamoPuesto]
ADD CONSTRAINT [PK_PrestamoPuesto]
    PRIMARY KEY CLUSTERED ([PK_PrestamoPuesto] ASC);
GO

-- Creating primary key on [PK_Presupuesto] in table 'Presupuesto'
ALTER TABLE [dbo].[Presupuesto]
ADD CONSTRAINT [PK_Presupuesto]
    PRIMARY KEY CLUSTERED ([PK_Presupuesto] ASC);
GO

-- Creating primary key on [PK_Programa] in table 'Programa'
ALTER TABLE [dbo].[Programa]
ADD CONSTRAINT [PK_Programa]
    PRIMARY KEY CLUSTERED ([PK_Programa] ASC);
GO

-- Creating primary key on [PK_Provincia] in table 'Provincia'
ALTER TABLE [dbo].[Provincia]
ADD CONSTRAINT [PK_Provincia]
    PRIMARY KEY CLUSTERED ([PK_Provincia] ASC);
GO

-- Creating primary key on [PK_Puesto] in table 'Puesto'
ALTER TABLE [dbo].[Puesto]
ADD CONSTRAINT [PK_Puesto]
    PRIMARY KEY CLUSTERED ([PK_Puesto] ASC);
GO

-- Creating primary key on [PK_RegistroIncapacidad] in table 'RegistroIncapacidad'
ALTER TABLE [dbo].[RegistroIncapacidad]
ADD CONSTRAINT [PK_RegistroIncapacidad]
    PRIMARY KEY CLUSTERED ([PK_RegistroIncapacidad] ASC);
GO

-- Creating primary key on [PK_RegistroPagoReal] in table 'RegistroPrestacionReal'
ALTER TABLE [dbo].[RegistroPrestacionReal]
ADD CONSTRAINT [PK_RegistroPrestacionReal]
    PRIMARY KEY CLUSTERED ([PK_RegistroPagoReal] ASC);
GO

-- Creating primary key on [PK_RegistroVacaciones] in table 'RegistroVacaciones'
ALTER TABLE [dbo].[RegistroVacaciones]
ADD CONSTRAINT [PK_RegistroVacaciones]
    PRIMARY KEY CLUSTERED ([PK_RegistroVacaciones] ASC);
GO

-- Creating primary key on [PK_ReintegroVacaciones] in table 'ReintegroVacaciones'
ALTER TABLE [dbo].[ReintegroVacaciones]
ADD CONSTRAINT [PK_ReintegroVacaciones]
    PRIMARY KEY CLUSTERED ([PK_ReintegroVacaciones] ASC);
GO

-- Creating primary key on [PK_RelPuestoUbicacion] in table 'RelPuestoUbicacion'
ALTER TABLE [dbo].[RelPuestoUbicacion]
ADD CONSTRAINT [PK_RelPuestoUbicacion]
    PRIMARY KEY CLUSTERED ([PK_RelPuestoUbicacion] ASC);
GO

-- Creating primary key on [PK_RemuneracionEfectuadaPF] in table 'RemuneracionEfectuadaPF'
ALTER TABLE [dbo].[RemuneracionEfectuadaPF]
ADD CONSTRAINT [PK_RemuneracionEfectuadaPF]
    PRIMARY KEY CLUSTERED ([PK_RemuneracionEfectuadaPF] ASC);
GO

-- Creating primary key on [PK_Rescision] in table 'Rescision'
ALTER TABLE [dbo].[Rescision]
ADD CONSTRAINT [PK_Rescision]
    PRIMARY KEY CLUSTERED ([PK_Rescision] ASC);
GO

-- Creating primary key on [PK_ResolucionPedimento] in table 'ResolucionPedimento'
ALTER TABLE [dbo].[ResolucionPedimento]
ADD CONSTRAINT [PK_ResolucionPedimento]
    PRIMARY KEY CLUSTERED ([PK_ResolucionPedimento] ASC);
GO

-- Creating primary key on [PK_Seccion] in table 'Seccion'
ALTER TABLE [dbo].[Seccion]
ADD CONSTRAINT [PK_Seccion]
    PRIMARY KEY CLUSTERED ([PK_Seccion] ASC);
GO

-- Creating primary key on [PK_SubEspecialidad] in table 'SubEspecialidad'
ALTER TABLE [dbo].[SubEspecialidad]
ADD CONSTRAINT [PK_SubEspecialidad]
    PRIMARY KEY CLUSTERED ([PK_SubEspecialidad] ASC);
GO

-- Creating primary key on [PK_SubPartida] in table 'SubPartida'
ALTER TABLE [dbo].[SubPartida]
ADD CONSTRAINT [PK_SubPartida]
    PRIMARY KEY CLUSTERED ([PK_SubPartida] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [PK_TareasPuesto] in table 'TareasPuesto'
ALTER TABLE [dbo].[TareasPuesto]
ADD CONSTRAINT [PK_TareasPuesto]
    PRIMARY KEY CLUSTERED ([PK_TareasPuesto] ASC);
GO

-- Creating primary key on [PK_TipoAccionPersonal] in table 'TipoAccionPersonal'
ALTER TABLE [dbo].[TipoAccionPersonal]
ADD CONSTRAINT [PK_TipoAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_TipoAccionPersonal] ASC);
GO

-- Creating primary key on [PK_TipoCambioPorAccionPersonal] in table 'TipoCambioPorAccionPersonal'
ALTER TABLE [dbo].[TipoCambioPorAccionPersonal]
ADD CONSTRAINT [PK_TipoCambioPorAccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_TipoCambioPorAccionPersonal] ASC);
GO

-- Creating primary key on [PK_TipoContacto] in table 'TipoContacto'
ALTER TABLE [dbo].[TipoContacto]
ADD CONSTRAINT [PK_TipoContacto]
    PRIMARY KEY CLUSTERED ([PK_TipoContacto] ASC);
GO

-- Creating primary key on [PK_TipoDeduccion] in table 'TipoDeduccion'
ALTER TABLE [dbo].[TipoDeduccion]
ADD CONSTRAINT [PK_TipoDeduccion]
    PRIMARY KEY CLUSTERED ([PK_TipoDeduccion] ASC);
GO

-- Creating primary key on [PK_TipoDetallePagoGasto] in table 'TipoDetalleGastoTransporte'
ALTER TABLE [dbo].[TipoDetalleGastoTransporte]
ADD CONSTRAINT [PK_TipoDetalleGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_TipoDetallePagoGasto] ASC);
GO

-- Creating primary key on [PK_TipoDetallePagoViatico] in table 'TipoDetallePagoViatico'
ALTER TABLE [dbo].[TipoDetallePagoViatico]
ADD CONSTRAINT [PK_TipoDetallePagoViatico]
    PRIMARY KEY CLUSTERED ([PK_TipoDetallePagoViatico] ASC);
GO

-- Creating primary key on [PK_TipoDia] in table 'TipoDia'
ALTER TABLE [dbo].[TipoDia]
ADD CONSTRAINT [PK_TipoDia]
    PRIMARY KEY CLUSTERED ([PK_TipoDia] ASC);
GO

-- Creating primary key on [PK_TipoExtra] in table 'TipoExtra'
ALTER TABLE [dbo].[TipoExtra]
ADD CONSTRAINT [PK_TipoExtra]
    PRIMARY KEY CLUSTERED ([PK_TipoExtra] ASC);
GO

-- Creating primary key on [PK_TipoIncapacidad] in table 'TipoIncapacidad'
ALTER TABLE [dbo].[TipoIncapacidad]
ADD CONSTRAINT [PK_TipoIncapacidad]
    PRIMARY KEY CLUSTERED ([PK_TipoIncapacidad] ASC);
GO

-- Creating primary key on [PK_TipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [PK_TipoJornada]
    PRIMARY KEY CLUSTERED ([PK_TipoJornada] ASC);
GO

-- Creating primary key on [PK_TipoPrestacion] in table 'TipoPrestacion'
ALTER TABLE [dbo].[TipoPrestacion]
ADD CONSTRAINT [PK_TipoPrestacion]
    PRIMARY KEY CLUSTERED ([PK_TipoPrestacion] ASC);
GO

-- Creating primary key on [PK_TipoPuesto] in table 'TipoPuesto'
ALTER TABLE [dbo].[TipoPuesto]
ADD CONSTRAINT [PK_TipoPuesto]
    PRIMARY KEY CLUSTERED ([PK_TipoPuesto] ASC);
GO

-- Creating primary key on [PK_TipoResolucionPedimento] in table 'TipoResolucionPedimento'
ALTER TABLE [dbo].[TipoResolucionPedimento]
ADD CONSTRAINT [PK_TipoResolucionPedimento]
    PRIMARY KEY CLUSTERED ([PK_TipoResolucionPedimento] ASC);
GO

-- Creating primary key on [PK_TipoUbicacion] in table 'TipoUbicacion'
ALTER TABLE [dbo].[TipoUbicacion]
ADD CONSTRAINT [PK_TipoUbicacion]
    PRIMARY KEY CLUSTERED ([PK_TipoUbicacion] ASC);
GO

-- Creating primary key on [PK_TituloFactor] in table 'TituloFactor'
ALTER TABLE [dbo].[TituloFactor]
ADD CONSTRAINT [PK_TituloFactor]
    PRIMARY KEY CLUSTERED ([PK_TituloFactor] ASC);
GO

-- Creating primary key on [PK_IdTomo] in table 'Tomo'
ALTER TABLE [dbo].[Tomo]
ADD CONSTRAINT [PK_Tomo]
    PRIMARY KEY CLUSTERED ([PK_IdTomo] ASC);
GO

-- Creating primary key on [PK_UbicacionAdministrativa] in table 'UbicacionAdministrativa'
ALTER TABLE [dbo].[UbicacionAdministrativa]
ADD CONSTRAINT [PK_UbicacionAdministrativa]
    PRIMARY KEY CLUSTERED ([PK_UbicacionAdministrativa] ASC);
GO

-- Creating primary key on [PK_UbicacionAsueto] in table 'UbicacionAsueto'
ALTER TABLE [dbo].[UbicacionAsueto]
ADD CONSTRAINT [PK_UbicacionAsueto]
    PRIMARY KEY CLUSTERED ([PK_UbicacionAsueto] ASC);
GO

-- Creating primary key on [PK_UbicacionPuesto] in table 'UbicacionPuesto'
ALTER TABLE [dbo].[UbicacionPuesto]
ADD CONSTRAINT [PK_UbicacionPuesto]
    PRIMARY KEY CLUSTERED ([PK_UbicacionPuesto] ASC);
GO

-- Creating primary key on [PK_Usuario] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([PK_Usuario] ASC);
GO

-- Creating primary key on [PK_Reintegro] in table 'ViaticoCorridoReintegroDias'
ALTER TABLE [dbo].[ViaticoCorridoReintegroDias]
ADD CONSTRAINT [PK_ViaticoCorridoReintegroDias]
    PRIMARY KEY CLUSTERED ([PK_Reintegro] ASC);
GO

-- Creating primary key on [id] in table 'C_Componentes'
ALTER TABLE [dbo].[C_Componentes]
ADD CONSTRAINT [PK_C_Componentes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ISN_ADPEF03M] in table 'C_EMU_EXFUNCIONARIOS'
ALTER TABLE [dbo].[C_EMU_EXFUNCIONARIOS]
ADD CONSTRAINT [PK_C_EMU_EXFUNCIONARIOS]
    PRIMARY KEY CLUSTERED ([ISN_ADPEF03M] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_HistoricoPlanilla'
ALTER TABLE [dbo].[C_EMU_HistoricoPlanilla]
ADD CONSTRAINT [PK_C_EMU_HistoricoPlanilla]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID], [PK_Funcionario] in table 'C_InicioPlanilla'
ALTER TABLE [dbo].[C_InicioPlanilla]
ADD CONSTRAINT [PK_C_InicioPlanilla]
    PRIMARY KEY CLUSTERED ([ID], [PK_Funcionario] ASC);
GO

-- Creating primary key on [ID] in table 'C_Planilla_Anterior'
ALTER TABLE [dbo].[C_Planilla_Anterior]
ADD CONSTRAINT [PK_C_Planilla_Anterior]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [idnuevo], [ID], [PK_Funcionario], [PK_Nombramiento] in table 'C_planillacargar'
ALTER TABLE [dbo].[C_planillacargar]
ADD CONSTRAINT [PK_C_planillacargar]
    PRIMARY KEY CLUSTERED ([idnuevo], [ID], [PK_Funcionario], [PK_Nombramiento] ASC);
GO

-- Creating primary key on [FK_Decreto], [FK_ComponentePresupuestario] in table 'DecretoComponentePresupuestario'
ALTER TABLE [dbo].[DecretoComponentePresupuestario]
ADD CONSTRAINT [PK_DecretoComponentePresupuestario]
    PRIMARY KEY CLUSTERED ([FK_Decreto], [FK_ComponentePresupuestario] ASC);
GO

-- Creating primary key on [PK_Mes] in table 'Mes'
ALTER TABLE [dbo].[Mes]
ADD CONSTRAINT [PK_Mes]
    PRIMARY KEY CLUSTERED ([PK_Mes] ASC);
GO

-- Creating primary key on [PK_CatalogoDia] in table 'CatDiaViaticoGasto'
ALTER TABLE [dbo].[CatDiaViaticoGasto]
ADD CONSTRAINT [PK_CatDiaViaticoGasto]
    PRIMARY KEY CLUSTERED ([PK_CatalogoDia] ASC);
GO

-- Creating primary key on [PK_TipoDeduccionTemporal] in table 'TipoDeduccionTemporal'
ALTER TABLE [dbo].[TipoDeduccionTemporal]
ADD CONSTRAINT [PK_TipoDeduccionTemporal]
    PRIMARY KEY CLUSTERED ([PK_TipoDeduccionTemporal] ASC);
GO

-- Creating primary key on [PK_NotificacionUsuario] in table 'NotificacionUsuario'
ALTER TABLE [dbo].[NotificacionUsuario]
ADD CONSTRAINT [PK_NotificacionUsuario]
    PRIMARY KEY CLUSTERED ([PK_NotificacionUsuario] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetalleAccionPersonalAnterior'
ALTER TABLE [dbo].[DetalleAccionPersonalAnterior]
ADD CONSTRAINT [PK_DetalleAccionPersonalAnterior]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_DetallePrestacion] in table 'DetallePrestacion'
ALTER TABLE [dbo].[DetallePrestacion]
ADD CONSTRAINT [PK_DetallePrestacion]
    PRIMARY KEY CLUSTERED ([PK_DetallePrestacion] ASC);
GO

-- Creating primary key on [PK_ActividadResultadoCargo] in table 'ActividadResultadoCargo'
ALTER TABLE [dbo].[ActividadResultadoCargo]
ADD CONSTRAINT [PK_ActividadResultadoCargo]
    PRIMARY KEY CLUSTERED ([PK_ActividadResultadoCargo] ASC);
GO

-- Creating primary key on [PK_Observacion] in table 'CalificacionObservaciones'
ALTER TABLE [dbo].[CalificacionObservaciones]
ADD CONSTRAINT [PK_CalificacionObservaciones]
    PRIMARY KEY CLUSTERED ([PK_Observacion] ASC);
GO

-- Creating primary key on [AnioRige] in table 'CatOrdenMovimiento'
ALTER TABLE [dbo].[CatOrdenMovimiento]
ADD CONSTRAINT [PK_CatOrdenMovimiento]
    PRIMARY KEY CLUSTERED ([AnioRige] ASC);
GO

-- Creating primary key on [PK_CompetenciaTransversalCargo] in table 'CompetenciaTransversalCargo'
ALTER TABLE [dbo].[CompetenciaTransversalCargo]
ADD CONSTRAINT [PK_CompetenciaTransversalCargo]
    PRIMARY KEY CLUSTERED ([PK_CompetenciaTransversalCargo] ASC);
GO

-- Creating primary key on [PK_ComportamientoGrupoOcupacional] in table 'ComportamientoGrupoOcupacional'
ALTER TABLE [dbo].[ComportamientoGrupoOcupacional]
ADD CONSTRAINT [PK_ComportamientoGrupoOcupacional]
    PRIMARY KEY CLUSTERED ([PK_ComportamientoGrupoOcupacional] ASC);
GO

-- Creating primary key on [PK_ComportamientoTransversal] in table 'ComportamientoTransversal'
ALTER TABLE [dbo].[ComportamientoTransversal]
ADD CONSTRAINT [PK_ComportamientoTransversal]
    PRIMARY KEY CLUSTERED ([PK_ComportamientoTransversal] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetallePrestacionAfiliacion'
ALTER TABLE [dbo].[DetallePrestacionAfiliacion]
ADD CONSTRAINT [PK_DetallePrestacionAfiliacion]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_DetalleCuadro] in table 'DetallePrestacionCuadro'
ALTER TABLE [dbo].[DetallePrestacionCuadro]
ADD CONSTRAINT [PK_DetallePrestacionCuadro]
    PRIMARY KEY CLUSTERED ([PK_DetalleCuadro] ASC);
GO

-- Creating primary key on [PK_Estado] in table 'EstadoOrdenMovimiento'
ALTER TABLE [dbo].[EstadoOrdenMovimiento]
ADD CONSTRAINT [PK_EstadoOrdenMovimiento]
    PRIMARY KEY CLUSTERED ([PK_Estado] ASC);
GO

-- Creating primary key on [PK_EvidenciaComportamientoTransversal] in table 'EvidenciaComportamientoTransversal'
ALTER TABLE [dbo].[EvidenciaComportamientoTransversal]
ADD CONSTRAINT [PK_EvidenciaComportamientoTransversal]
    PRIMARY KEY CLUSTERED ([PK_EvidenciaComportamientoTransversal] ASC);
GO

-- Creating primary key on [PK_EvidenciaGrupoOcupacional] in table 'EvidenciaGrupoOcupacional'
ALTER TABLE [dbo].[EvidenciaGrupoOcupacional]
ADD CONSTRAINT [PK_EvidenciaGrupoOcupacional]
    PRIMARY KEY CLUSTERED ([PK_EvidenciaGrupoOcupacional] ASC);
GO

-- Creating primary key on [PK_FactorClasificacion] in table 'FactorClasificacionCargo'
ALTER TABLE [dbo].[FactorClasificacionCargo]
ADD CONSTRAINT [PK_FactorClasificacionCargo]
    PRIMARY KEY CLUSTERED ([PK_FactorClasificacion] ASC);
GO

-- Creating primary key on [PK_Declaracion] in table 'OrdenMovimientoDeclaracion'
ALTER TABLE [dbo].[OrdenMovimientoDeclaracion]
ADD CONSTRAINT [PK_OrdenMovimientoDeclaracion]
    PRIMARY KEY CLUSTERED ([PK_Declaracion] ASC);
GO

-- Creating primary key on [PK_RequerimientoEspecificoCargo] in table 'RequerimientoEspecificoCargo'
ALTER TABLE [dbo].[RequerimientoEspecificoCargo]
ADD CONSTRAINT [PK_RequerimientoEspecificoCargo]
    PRIMARY KEY CLUSTERED ([PK_RequerimientoEspecificoCargo] ASC);
GO

-- Creating primary key on [PK_ResultadoCargo] in table 'ResultadoCargo'
ALTER TABLE [dbo].[ResultadoCargo]
ADD CONSTRAINT [PK_ResultadoCargo]
    PRIMARY KEY CLUSTERED ([PK_ResultadoCargo] ASC);
GO

-- Creating primary key on [PK_TipoPP] in table 'TipoPoliticaPublica'
ALTER TABLE [dbo].[TipoPoliticaPublica]
ADD CONSTRAINT [PK_TipoPoliticaPublica]
    PRIMARY KEY CLUSTERED ([PK_TipoPP] ASC);
GO

-- Creating primary key on [PK_TipoCuadro] in table 'TipoPrestacionCuadro'
ALTER TABLE [dbo].[TipoPrestacionCuadro]
ADD CONSTRAINT [PK_TipoPrestacionCuadro]
    PRIMARY KEY CLUSTERED ([PK_TipoCuadro] ASC);
GO

-- Creating primary key on [PK_CompetenciaGrupoOcupacional] in table 'CompetenciaGrupoOcupacional'
ALTER TABLE [dbo].[CompetenciaGrupoOcupacional]
ADD CONSTRAINT [PK_CompetenciaGrupoOcupacional]
    PRIMARY KEY CLUSTERED ([PK_CompetenciaGrupoOcupacional] ASC);
GO

-- Creating primary key on [PK_Nombramiento], [PK_Puesto], [PK_Funcionario], [PK_DetallePuesto], [IndPropiedad] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [PK_ListaNombramientosActivos]
    PRIMARY KEY CLUSTERED ([PK_Nombramiento], [PK_Puesto], [PK_Funcionario], [PK_DetallePuesto], [IndPropiedad] ASC);
GO

-- Creating primary key on [PK_CalificacionEncargado] in table 'CalificacionEncargado'
ALTER TABLE [dbo].[CalificacionEncargado]
ADD CONSTRAINT [PK_CalificacionEncargado]
    PRIMARY KEY CLUSTERED ([PK_CalificacionEncargado] ASC);
GO

-- Creating primary key on [PK_Estado] in table 'CatMetaEstado'
ALTER TABLE [dbo].[CatMetaEstado]
ADD CONSTRAINT [PK_CatMetaEstado]
    PRIMARY KEY CLUSTERED ([PK_Estado] ASC);
GO

-- Creating primary key on [PK_Prioridad] in table 'CatMetaPrioridad'
ALTER TABLE [dbo].[CatMetaPrioridad]
ADD CONSTRAINT [PK_CatMetaPrioridad]
    PRIMARY KEY CLUSTERED ([PK_Prioridad] ASC);
GO

-- Creating primary key on [PK_ObjetivoCalificacion] in table 'ObjetivoCalificacion'
ALTER TABLE [dbo].[ObjetivoCalificacion]
ADD CONSTRAINT [PK_ObjetivoCalificacion]
    PRIMARY KEY CLUSTERED ([PK_ObjetivoCalificacion] ASC);
GO

-- Creating primary key on [PK_Actividad] in table 'ActividadFuncionario'
ALTER TABLE [dbo].[ActividadFuncionario]
ADD CONSTRAINT [PK_ActividadFuncionario]
    PRIMARY KEY CLUSTERED ([PK_Actividad] ASC);
GO

-- Creating primary key on [PK_ContratoArrendamiento] in table 'ContratoArrendamiento'
ALTER TABLE [dbo].[ContratoArrendamiento]
ADD CONSTRAINT [PK_ContratoArrendamiento]
    PRIMARY KEY CLUSTERED ([PK_ContratoArrendamiento] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetalleDesarraigoEliminacion'
ALTER TABLE [dbo].[DetalleDesarraigoEliminacion]
ADD CONSTRAINT [PK_DetalleDesarraigoEliminacion]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_FacturaDesarraigo] in table 'FacturaDesarraigo'
ALTER TABLE [dbo].[FacturaDesarraigo]
ADD CONSTRAINT [PK_FacturaDesarraigo]
    PRIMARY KEY CLUSTERED ([PK_FacturaDesarraigo] ASC);
GO

-- Creating primary key on [PK_TipoIndicador] in table 'TipoIndicadorMeta'
ALTER TABLE [dbo].[TipoIndicadorMeta]
ADD CONSTRAINT [PK_TipoIndicadorMeta]
    PRIMARY KEY CLUSTERED ([PK_TipoIndicador] ASC);
GO

-- Creating primary key on [PK_Desarraigo] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [PK_Desarraigo]
    PRIMARY KEY CLUSTERED ([PK_Desarraigo] ASC);
GO

-- Creating primary key on [PK_DetallePuestoRubro] in table 'DetallePuestoRubro'
ALTER TABLE [dbo].[DetallePuestoRubro]
ADD CONSTRAINT [PK_DetallePuestoRubro]
    PRIMARY KEY CLUSTERED ([PK_DetallePuestoRubro] ASC);
GO

-- Creating primary key on [PK_Ruta] in table 'GastoTransporteRutas'
ALTER TABLE [dbo].[GastoTransporteRutas]
ADD CONSTRAINT [PK_GastoTransporteRutas]
    PRIMARY KEY CLUSTERED ([PK_Ruta] ASC);
GO

-- Creating primary key on [PK_Informe] in table 'MetaIndividualInforme'
ALTER TABLE [dbo].[MetaIndividualInforme]
ADD CONSTRAINT [PK_MetaIndividualInforme]
    PRIMARY KEY CLUSTERED ([PK_Informe] ASC);
GO

-- Creating primary key on [PK_PagoGastoTransporte] in table 'PagoGastoTransporte'
ALTER TABLE [dbo].[PagoGastoTransporte]
ADD CONSTRAINT [PK_PagoGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_PagoGastoTransporte] ASC);
GO

-- Creating primary key on [PK_DetalleAsignacionGastoTransporte] in table 'DetalleAsignacionGastoTransporte'
ALTER TABLE [dbo].[DetalleAsignacionGastoTransporte]
ADD CONSTRAINT [PK_DetalleAsignacionGastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_DetalleAsignacionGastoTransporte] ASC);
GO

-- Creating primary key on [PK_PedimentoPuesto] in table 'PedimentoPuesto'
ALTER TABLE [dbo].[PedimentoPuesto]
ADD CONSTRAINT [PK_PedimentoPuesto]
    PRIMARY KEY CLUSTERED ([PK_PedimentoPuesto] ASC);
GO

-- Creating primary key on [PK_OrdenMovimiento] in table 'OrdenMovimiento'
ALTER TABLE [dbo].[OrdenMovimiento]
ADD CONSTRAINT [PK_OrdenMovimiento]
    PRIMARY KEY CLUSTERED ([PK_OrdenMovimiento] ASC);
GO

-- Creating primary key on [PK_Correo] in table 'TEMP_EnviarCorreo'
ALTER TABLE [dbo].[TEMP_EnviarCorreo]
ADD CONSTRAINT [PK_TEMP_EnviarCorreo]
    PRIMARY KEY CLUSTERED ([PK_Correo] ASC);
GO

-- Creating primary key on [PK_AccionPersonal] in table 'AccionPersonal'
ALTER TABLE [dbo].[AccionPersonal]
ADD CONSTRAINT [PK_AccionPersonal]
    PRIMARY KEY CLUSTERED ([PK_AccionPersonal] ASC);
GO

-- Creating primary key on [PK_Detalle] in table 'DetalleCalificacionSeguimiento'
ALTER TABLE [dbo].[DetalleCalificacionSeguimiento]
ADD CONSTRAINT [PK_DetalleCalificacionSeguimiento]
    PRIMARY KEY CLUSTERED ([PK_Detalle] ASC);
GO

-- Creating primary key on [PK_Familia] in table 'FamiliaPuestos'
ALTER TABLE [dbo].[FamiliaPuestos]
ADD CONSTRAINT [PK_FamiliaPuestos]
    PRIMARY KEY CLUSTERED ([PK_Familia] ASC);
GO

-- Creating primary key on [PK_CalificacionCapacitacion] in table 'CalificacionCapacitacion'
ALTER TABLE [dbo].[CalificacionCapacitacion]
ADD CONSTRAINT [PK_CalificacionCapacitacion]
    PRIMARY KEY CLUSTERED ([PK_CalificacionCapacitacion] ASC);
GO

-- Creating primary key on [PK_CalificacionNombramiento] in table 'CalificacionNombramientoFuncionarios'
ALTER TABLE [dbo].[CalificacionNombramientoFuncionarios]
ADD CONSTRAINT [PK_CalificacionNombramientoFuncionarios]
    PRIMARY KEY CLUSTERED ([PK_CalificacionNombramiento] ASC);
GO

-- Creating primary key on [PK_Cargo] in table 'Cargo'
ALTER TABLE [dbo].[Cargo]
ADD CONSTRAINT [PK_Cargo]
    PRIMARY KEY CLUSTERED ([PK_Cargo] ASC);
GO

-- Creating primary key on [PK_Permiso] in table 'CatPermisoEvidencia'
ALTER TABLE [dbo].[CatPermisoEvidencia]
ADD CONSTRAINT [PK_CatPermisoEvidencia]
    PRIMARY KEY CLUSTERED ([PK_Permiso] ASC);
GO

-- Creating primary key on [PK_Meta] in table 'MetaObjetivoCalificacion'
ALTER TABLE [dbo].[MetaObjetivoCalificacion]
ADD CONSTRAINT [PK_MetaObjetivoCalificacion]
    PRIMARY KEY CLUSTERED ([PK_Meta] ASC);
GO

-- Creating primary key on [PK_Campo] in table 'CatCampo'
ALTER TABLE [dbo].[CatCampo]
ADD CONSTRAINT [PK_CatCampo]
    PRIMARY KEY CLUSTERED ([PK_Campo] ASC);
GO

-- Creating primary key on [PK_Evidencia] in table 'MetaIndividualEvidencia'
ALTER TABLE [dbo].[MetaIndividualEvidencia]
ADD CONSTRAINT [PK_MetaIndividualEvidencia]
    PRIMARY KEY CLUSTERED ([PK_Evidencia] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_CarreraProfesional'
ALTER TABLE [dbo].[C_EMU_CarreraProfesional]
ADD CONSTRAINT [PK_C_EMU_CarreraProfesional]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_Cursos'
ALTER TABLE [dbo].[C_EMU_Cursos]
ADD CONSTRAINT [PK_C_EMU_Cursos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'C_EMU_Puntos'
ALTER TABLE [dbo].[C_EMU_Puntos]
ADD CONSTRAINT [PK_C_EMU_Puntos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PK_CursoCapacitacion] in table 'CursoCapacitacion'
ALTER TABLE [dbo].[CursoCapacitacion]
ADD CONSTRAINT [PK_CursoCapacitacion]
    PRIMARY KEY CLUSTERED ([PK_CursoCapacitacion] ASC);
GO

-- Creating primary key on [PK_DetallePuntos] in table 'DetallePuntosAdicional'
ALTER TABLE [dbo].[DetallePuntosAdicional]
ADD CONSTRAINT [PK_DetallePuntosAdicional]
    PRIMARY KEY CLUSTERED ([PK_DetallePuntos] ASC);
GO

-- Creating primary key on [PK_EntidadEducativa] in table 'EntidadEducativa'
ALTER TABLE [dbo].[EntidadEducativa]
ADD CONSTRAINT [PK_EntidadEducativa]
    PRIMARY KEY CLUSTERED ([PK_EntidadEducativa] ASC);
GO

-- Creating primary key on [PK_ViaticoCorrido] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [PK_ViaticoCorrido]
    PRIMARY KEY CLUSTERED ([PK_ViaticoCorrido] ASC);
GO

-- Creating primary key on [PK_GastosTransporte] in table 'GastoTransporte'
ALTER TABLE [dbo].[GastoTransporte]
ADD CONSTRAINT [PK_GastoTransporte]
    PRIMARY KEY CLUSTERED ([PK_GastosTransporte] ASC);
GO

-- Creating primary key on [PK_EstadoCargo] in table 'EstadoCargo'
ALTER TABLE [dbo].[EstadoCargo]
ADD CONSTRAINT [PK_EstadoCargo]
    PRIMARY KEY CLUSTERED ([PK_EstadoCargo] ASC);
GO

-- Creating primary key on [PK_Nivel] in table 'CatMetaNivel'
ALTER TABLE [dbo].[CatMetaNivel]
ADD CONSTRAINT [PK_CatMetaNivel]
    PRIMARY KEY CLUSTERED ([PK_Nivel] ASC);
GO

-- Creating primary key on [PK_Meta] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [PK_MetaIndividualCalificacion]
    PRIMARY KEY CLUSTERED ([PK_Meta] ASC);
GO

-- Creating primary key on [PK_CalificacionNombramiento] in table 'CalificacionNombramiento'
ALTER TABLE [dbo].[CalificacionNombramiento]
ADD CONSTRAINT [PK_CalificacionNombramiento]
    PRIMARY KEY CLUSTERED ([PK_CalificacionNombramiento] ASC);
GO

-- Creating primary key on [PK_Competencia] in table 'CatCalificacionCompetencias'
ALTER TABLE [dbo].[CatCalificacionCompetencias]
ADD CONSTRAINT [PK_CatCalificacionCompetencias]
    PRIMARY KEY CLUSTERED ([PK_Competencia] ASC);
GO

-- Creating primary key on [PK_CalificacionAutoEvaluacion] in table 'DetalleCalificacionAutoEvaluacion'
ALTER TABLE [dbo].[DetalleCalificacionAutoEvaluacion]
ADD CONSTRAINT [PK_DetalleCalificacionAutoEvaluacion]
    PRIMARY KEY CLUSTERED ([PK_CalificacionAutoEvaluacion] ASC);
GO

-- Creating primary key on [PK_CalificacionCompetencia] in table 'DetalleCalificacionCompetencia'
ALTER TABLE [dbo].[DetalleCalificacionCompetencia]
ADD CONSTRAINT [PK_DetalleCalificacionCompetencia]
    PRIMARY KEY CLUSTERED ([PK_CalificacionCompetencia] ASC);
GO

-- Creating primary key on [PK_CalificacionJefeColaborador] in table 'DetalleCalificacionJefeColaborador'
ALTER TABLE [dbo].[DetalleCalificacionJefeColaborador]
ADD CONSTRAINT [PK_DetalleCalificacionJefeColaborador]
    PRIMARY KEY CLUSTERED ([PK_CalificacionJefeColaborador] ASC);
GO

-- Creating primary key on [PK_DetalleMeta] in table 'DetalleCalificacionMeta'
ALTER TABLE [dbo].[DetalleCalificacionMeta]
ADD CONSTRAINT [PK_DetalleCalificacionMeta]
    PRIMARY KEY CLUSTERED ([PK_DetalleMeta] ASC);
GO

-- Creating primary key on [PK_CalificacionServicio] in table 'DetalleCalificacionServicio'
ALTER TABLE [dbo].[DetalleCalificacionServicio]
ADD CONSTRAINT [PK_DetalleCalificacionServicio]
    PRIMARY KEY CLUSTERED ([PK_CalificacionServicio] ASC);
GO

-- Creating primary key on [PK_Estado] in table 'EstadoActividadPlan'
ALTER TABLE [dbo].[EstadoActividadPlan]
ADD CONSTRAINT [PK_EstadoActividadPlan]
    PRIMARY KEY CLUSTERED ([PK_Estado] ASC);
GO

-- Creating primary key on [PK_EstadoPlan] in table 'EstadoPlan'
ALTER TABLE [dbo].[EstadoPlan]
ADD CONSTRAINT [PK_EstadoPlan]
    PRIMARY KEY CLUSTERED ([PK_EstadoPlan] ASC);
GO

-- Creating primary key on [PK_PlanAnual] in table 'PlanAnual'
ALTER TABLE [dbo].[PlanAnual]
ADD CONSTRAINT [PK_PlanAnual]
    PRIMARY KEY CLUSTERED ([PK_PlanAnual] ASC);
GO

-- Creating primary key on [PK_Actividad] in table 'PlanAnualActividad'
ALTER TABLE [dbo].[PlanAnualActividad]
ADD CONSTRAINT [PK_PlanAnualActividad]
    PRIMARY KEY CLUSTERED ([PK_Actividad] ASC);
GO

-- Creating primary key on [PK_Avance] in table 'PlanAnualActividadAvance'
ALTER TABLE [dbo].[PlanAnualActividadAvance]
ADD CONSTRAINT [PK_PlanAnualActividadAvance]
    PRIMARY KEY CLUSTERED ([PK_Avance] ASC);
GO

-- Creating primary key on [PK_ActividadPlanFuncionario] in table 'PlanAnualActividadFuncionario'
ALTER TABLE [dbo].[PlanAnualActividadFuncionario]
ADD CONSTRAINT [PK_PlanAnualActividadFuncionario]
    PRIMARY KEY CLUSTERED ([PK_ActividadPlanFuncionario] ASC);
GO

-- Creating primary key on [PK_Meta] in table 'PlanAnualMeta'
ALTER TABLE [dbo].[PlanAnualMeta]
ADD CONSTRAINT [PK_PlanAnualMeta]
    PRIMARY KEY CLUSTERED ([PK_Meta] ASC);
GO

-- Creating primary key on [PK_ProductoPlan] in table 'PlanAnualProductos'
ALTER TABLE [dbo].[PlanAnualProductos]
ADD CONSTRAINT [PK_PlanAnualProductos]
    PRIMARY KEY CLUSTERED ([PK_ProductoPlan] ASC);
GO

-- Creating primary key on [PK_PlanEstrategico] in table 'PlanEstrategico'
ALTER TABLE [dbo].[PlanEstrategico]
ADD CONSTRAINT [PK_PlanEstrategico]
    PRIMARY KEY CLUSTERED ([PK_PlanEstrategico] ASC);
GO

-- Creating primary key on [PK_AccionEstrategica] in table 'PlanEstrategicoAccion'
ALTER TABLE [dbo].[PlanEstrategicoAccion]
ADD CONSTRAINT [PK_PlanEstrategicoAccion]
    PRIMARY KEY CLUSTERED ([PK_AccionEstrategica] ASC);
GO

-- Creating primary key on [PK_Eje] in table 'PlanEstrategicoEje'
ALTER TABLE [dbo].[PlanEstrategicoEje]
ADD CONSTRAINT [PK_PlanEstrategicoEje]
    PRIMARY KEY CLUSTERED ([PK_Eje] ASC);
GO

-- Creating primary key on [PK_Linea] in table 'PlanEstrategicoLinea'
ALTER TABLE [dbo].[PlanEstrategicoLinea]
ADD CONSTRAINT [PK_PlanEstrategicoLinea]
    PRIMARY KEY CLUSTERED ([PK_Linea] ASC);
GO

-- Creating primary key on [PK_Producto] in table 'PlanEstrategicoProducto'
ALTER TABLE [dbo].[PlanEstrategicoProducto]
ADD CONSTRAINT [PK_PlanEstrategicoProducto]
    PRIMARY KEY CLUSTERED ([PK_Producto] ASC);
GO

-- Creating primary key on [PK_Tipo] in table 'TipoAutoevaluacion'
ALTER TABLE [dbo].[TipoAutoevaluacion]
ADD CONSTRAINT [PK_TipoAutoevaluacion]
    PRIMARY KEY CLUSTERED ([PK_Tipo] ASC);
GO

-- Creating primary key on [PK_TipoCompetencia] in table 'TipoCalificacionCompetencia'
ALTER TABLE [dbo].[TipoCalificacionCompetencia]
ADD CONSTRAINT [PK_TipoCalificacionCompetencia]
    PRIMARY KEY CLUSTERED ([PK_TipoCompetencia] ASC);
GO

-- Creating primary key on [PK_Tipo] in table 'TipoCalJefeColaborador'
ALTER TABLE [dbo].[TipoCalJefeColaborador]
ADD CONSTRAINT [PK_TipoCalJefeColaborador]
    PRIMARY KEY CLUSTERED ([PK_Tipo] ASC);
GO

-- Creating primary key on [PK_TipoCategoria] in table 'TipoCategoriaServicio'
ALTER TABLE [dbo].[TipoCategoriaServicio]
ADD CONSTRAINT [PK_TipoCategoriaServicio]
    PRIMARY KEY CLUSTERED ([PK_TipoCategoria] ASC);
GO

-- Creating primary key on [PK_CalificacionAutoEvaluacion] in table 'CalificacionAutoEvaluacion'
ALTER TABLE [dbo].[CalificacionAutoEvaluacion]
ADD CONSTRAINT [PK_CalificacionAutoEvaluacion]
    PRIMARY KEY CLUSTERED ([PK_CalificacionAutoEvaluacion] ASC);
GO

-- Creating primary key on [PK_Compromiso] in table 'CalificacionCompromiso'
ALTER TABLE [dbo].[CalificacionCompromiso]
ADD CONSTRAINT [PK_CalificacionCompromiso]
    PRIMARY KEY CLUSTERED ([PK_Compromiso] ASC);
GO

-- Creating primary key on [PK_CalificacionColaborador] in table 'CalificacionJefeColaborador'
ALTER TABLE [dbo].[CalificacionJefeColaborador]
ADD CONSTRAINT [PK_CalificacionJefeColaborador]
    PRIMARY KEY CLUSTERED ([PK_CalificacionColaborador] ASC);
GO

-- Creating primary key on [PK_CalificacionServicio] in table 'CalificacionServicio'
ALTER TABLE [dbo].[CalificacionServicio]
ADD CONSTRAINT [PK_CalificacionServicio]
    PRIMARY KEY CLUSTERED ([PK_CalificacionServicio] ASC);
GO

-- Creating primary key on [PK_RegistroTiempoExtra] in table 'RegistroTiempoExtra'
ALTER TABLE [dbo].[RegistroTiempoExtra]
ADD CONSTRAINT [PK_RegistroTiempoExtra]
    PRIMARY KEY CLUSTERED ([PK_RegistroTiempoExtra] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FK_PrestamoPuesto] in table 'AddendumPrestamoPuesto'
ALTER TABLE [dbo].[AddendumPrestamoPuesto]
ADD CONSTRAINT [FK_AddendumPrestamoPuesto_PrestamoPuesto]
    FOREIGN KEY ([FK_PrestamoPuesto])
    REFERENCES [dbo].[PrestamoPuesto]
        ([PK_PrestamoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddendumPrestamoPuesto_PrestamoPuesto'
CREATE INDEX [IX_FK_AddendumPrestamoPuesto_PrestamoPuesto]
ON [dbo].[AddendumPrestamoPuesto]
    ([FK_PrestamoPuesto]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'BitacoraIncidencia'
ALTER TABLE [dbo].[BitacoraIncidencia]
ADD CONSTRAINT [FK_BitacoraIncidencia_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BitacoraIncidencia_Funcionario'
CREATE INDEX [IX_FK_BitacoraIncidencia_Funcionario]
ON [dbo].[BitacoraIncidencia]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Incidencia] in table 'BitacoraIncidencia'
ALTER TABLE [dbo].[BitacoraIncidencia]
ADD CONSTRAINT [FK_BitacoraIncidencia_Incidencia]
    FOREIGN KEY ([FK_Incidencia])
    REFERENCES [dbo].[Incidencia]
        ([PK_Incidencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BitacoraIncidencia_Incidencia'
CREATE INDEX [IX_FK_BitacoraIncidencia_Incidencia]
ON [dbo].[BitacoraIncidencia]
    ([FK_Incidencia]);
GO

-- Creating foreign key on [FK_Usuario] in table 'BitacoraUsuario'
ALTER TABLE [dbo].[BitacoraUsuario]
ADD CONSTRAINT [FK_BitacoraUsuario_Usuario]
    FOREIGN KEY ([FK_Usuario])
    REFERENCES [dbo].[Usuario]
        ([PK_Usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BitacoraUsuario_Usuario'
CREATE INDEX [IX_FK_BitacoraUsuario_Usuario]
ON [dbo].[BitacoraUsuario]
    ([FK_Usuario]);
GO

-- Creating foreign key on [FK_ExpedienteFuncionario] in table 'BoletaPrestamo'
ALTER TABLE [dbo].[BoletaPrestamo]
ADD CONSTRAINT [FK_BoletaPrestamo_ExpedienteFuncionario]
    FOREIGN KEY ([FK_ExpedienteFuncionario])
    REFERENCES [dbo].[ExpedienteFuncionario]
        ([PK_IdExpedienteFuncionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoletaPrestamo_ExpedienteFuncionario'
CREATE INDEX [IX_FK_BoletaPrestamo_ExpedienteFuncionario]
ON [dbo].[BoletaPrestamo]
    ([FK_ExpedienteFuncionario]);
GO

-- Creating foreign key on [FK_Usuario] in table 'BoletaPrestamo'
ALTER TABLE [dbo].[BoletaPrestamo]
ADD CONSTRAINT [FK_BoletaPrestamo_Usuario]
    FOREIGN KEY ([FK_Usuario])
    REFERENCES [dbo].[Usuario]
        ([PK_Usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoletaPrestamo_Usuario'
CREATE INDEX [IX_FK_BoletaPrestamo_Usuario]
ON [dbo].[BoletaPrestamo]
    ([FK_Usuario]);
GO

-- Creating foreign key on [FK_IdBoletaPrestamo] in table 'DetalleBoleta'
ALTER TABLE [dbo].[DetalleBoleta]
ADD CONSTRAINT [FK_DatosBoleta_BoletaPrestamo]
    FOREIGN KEY ([FK_IdBoletaPrestamo])
    REFERENCES [dbo].[BoletaPrestamo]
        ([PK_IdBoletaPrestamo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DatosBoleta_BoletaPrestamo'
CREATE INDEX [IX_FK_DatosBoleta_BoletaPrestamo]
ON [dbo].[DetalleBoleta]
    ([FK_IdBoletaPrestamo]);
GO

-- Creating foreign key on [FK_Borrador] in table 'MovimientoBorradorAccionPersonal'
ALTER TABLE [dbo].[MovimientoBorradorAccionPersonal]
ADD CONSTRAINT [FK_Borrador_Borrador]
    FOREIGN KEY ([FK_Borrador])
    REFERENCES [dbo].[BorradorAccionPersonal]
        ([PK_Borrador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Borrador_Borrador'
CREATE INDEX [IX_FK_Borrador_Borrador]
ON [dbo].[MovimientoBorradorAccionPersonal]
    ([FK_Borrador]);
GO

-- Creating foreign key on [FK_EstadoBorrador] in table 'BorradorAccionPersonal'
ALTER TABLE [dbo].[BorradorAccionPersonal]
ADD CONSTRAINT [FK_BorradorAccionPersonal_EstadoBorrador]
    FOREIGN KEY ([FK_EstadoBorrador])
    REFERENCES [dbo].[EstadoBorrador]
        ([PK_EstadoBorrador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BorradorAccionPersonal_EstadoBorrador'
CREATE INDEX [IX_FK_BorradorAccionPersonal_EstadoBorrador]
ON [dbo].[BorradorAccionPersonal]
    ([FK_EstadoBorrador]);
GO

-- Creating foreign key on [FK_Borrador] in table 'DetalleBorradorAccionPersonal'
ALTER TABLE [dbo].[DetalleBorradorAccionPersonal]
ADD CONSTRAINT [FK_DetalleBorradorAccionPersonal_BorradorAccionPersonal]
    FOREIGN KEY ([FK_Borrador])
    REFERENCES [dbo].[BorradorAccionPersonal]
        ([PK_Borrador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleBorradorAccionPersonal_BorradorAccionPersonal'
CREATE INDEX [IX_FK_DetalleBorradorAccionPersonal_BorradorAccionPersonal]
ON [dbo].[DetalleBorradorAccionPersonal]
    ([FK_Borrador]);
GO

-- Creating foreign key on [FK_CatalogoIncidencia] in table 'BotAccionIncidencia'
ALTER TABLE [dbo].[BotAccionIncidencia]
ADD CONSTRAINT [FK_BotAccionIncidencia_CatalogoIncidencia]
    FOREIGN KEY ([FK_CatalogoIncidencia])
    REFERENCES [dbo].[CatalogoIncidencia]
        ([PK_CatalogoIncidencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BotAccionIncidencia_CatalogoIncidencia'
CREATE INDEX [IX_FK_BotAccionIncidencia_CatalogoIncidencia]
ON [dbo].[BotAccionIncidencia]
    ([FK_CatalogoIncidencia]);
GO

-- Creating foreign key on [FK_PeriodoCalificacion] in table 'CalificacionReglaTecnica'
ALTER TABLE [dbo].[CalificacionReglaTecnica]
ADD CONSTRAINT [FK_CalificacionReglaTecnica_PeriodoCalificacion]
    FOREIGN KEY ([FK_PeriodoCalificacion])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionReglaTecnica_PeriodoCalificacion'
CREATE INDEX [IX_FK_CalificacionReglaTecnica_PeriodoCalificacion]
ON [dbo].[CalificacionReglaTecnica]
    ([FK_PeriodoCalificacion]);
GO

-- Creating foreign key on [FK_ComponenteSalarial] in table 'CambioPorAccionPersonal'
ALTER TABLE [dbo].[CambioPorAccionPersonal]
ADD CONSTRAINT [FK_CambioPorAccionPersonal_ComponenteSalarial]
    FOREIGN KEY ([FK_ComponenteSalarial])
    REFERENCES [dbo].[ComponenteSalarial]
        ([PK_ComponenteSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CambioPorAccionPersonal_ComponenteSalarial'
CREATE INDEX [IX_FK_CambioPorAccionPersonal_ComponenteSalarial]
ON [dbo].[CambioPorAccionPersonal]
    ([FK_ComponenteSalarial]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'CambioPorAccionPersonal'
ALTER TABLE [dbo].[CambioPorAccionPersonal]
ADD CONSTRAINT [FK_CambioPorAccionPersonal_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CambioPorAccionPersonal_Nombramiento'
CREATE INDEX [IX_FK_CambioPorAccionPersonal_Nombramiento]
ON [dbo].[CambioPorAccionPersonal]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_TipoCambioPorAccionPersonal] in table 'CambioPorAccionPersonal'
ALTER TABLE [dbo].[CambioPorAccionPersonal]
ADD CONSTRAINT [FK_CambioPorAccionPersonal_TipoCambioPorAccionPersonal]
    FOREIGN KEY ([FK_TipoCambioPorAccionPersonal])
    REFERENCES [dbo].[TipoCambioPorAccionPersonal]
        ([PK_TipoCambioPorAccionPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CambioPorAccionPersonal_TipoCambioPorAccionPersonal'
CREATE INDEX [IX_FK_CambioPorAccionPersonal_TipoCambioPorAccionPersonal]
ON [dbo].[CambioPorAccionPersonal]
    ([FK_TipoCambioPorAccionPersonal]);
GO

-- Creating foreign key on [FK_Provincia] in table 'Canton'
ALTER TABLE [dbo].[Canton]
ADD CONSTRAINT [FK__Canton__Provinci__597B3B93]
    FOREIGN KEY ([FK_Provincia])
    REFERENCES [dbo].[Provincia]
        ([PK_Provincia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Canton__Provinci__597B3B93'
CREATE INDEX [IX_FK__Canton__Provinci__597B3B93]
ON [dbo].[Canton]
    ([FK_Provincia]);
GO

-- Creating foreign key on [FK_Canton] in table 'Distrito'
ALTER TABLE [dbo].[Distrito]
ADD CONSTRAINT [FK__Distrito__Canton__733B0D96]
    FOREIGN KEY ([FK_Canton])
    REFERENCES [dbo].[Canton]
        ([PK_Canton])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Distrito__Canton__733B0D96'
CREATE INDEX [IX_FK__Distrito__Canton__733B0D96]
ON [dbo].[Distrito]
    ([FK_Canton]);
GO

-- Creating foreign key on [FK_Canton] in table 'UbicacionAsueto'
ALTER TABLE [dbo].[UbicacionAsueto]
ADD CONSTRAINT [FK_dbo_UbicacionAsueto_3]
    FOREIGN KEY ([FK_Canton])
    REFERENCES [dbo].[Canton]
        ([PK_Canton])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_UbicacionAsueto_3'
CREATE INDEX [IX_FK_dbo_UbicacionAsueto_3]
ON [dbo].[UbicacionAsueto]
    ([FK_Canton]);
GO

-- Creating foreign key on [FK_Factor] in table 'CaracteristicasPuesto'
ALTER TABLE [dbo].[CaracteristicasPuesto]
ADD CONSTRAINT [FK_CaracteristicasPuesto_Factor]
    FOREIGN KEY ([FK_Factor])
    REFERENCES [dbo].[Factor]
        ([PK_Factor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CaracteristicasPuesto_Factor'
CREATE INDEX [IX_FK_CaracteristicasPuesto_Factor]
ON [dbo].[CaracteristicasPuesto]
    ([FK_Factor]);
GO

-- Creating foreign key on [FK_Puesto] in table 'CaracteristicasPuesto'
ALTER TABLE [dbo].[CaracteristicasPuesto]
ADD CONSTRAINT [FK_CaracteristicasPuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CaracteristicasPuesto_Puesto'
CREATE INDEX [IX_FK_CaracteristicasPuesto_Puesto]
ON [dbo].[CaracteristicasPuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'CartasPresentacion'
ALTER TABLE [dbo].[CartasPresentacion]
ADD CONSTRAINT [FK_Nombramiento_CartasPresentacion]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Nombramiento_CartasPresentacion'
CREATE INDEX [IX_FK_Nombramiento_CartasPresentacion]
ON [dbo].[CartasPresentacion]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_TipoDeduccion] in table 'CatalogoDeduccion'
ALTER TABLE [dbo].[CatalogoDeduccion]
ADD CONSTRAINT [FK_dbo_CatalogoDeduccion_2]
    FOREIGN KEY ([FK_TipoDeduccion])
    REFERENCES [dbo].[TipoDeduccion]
        ([PK_TipoDeduccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CatalogoDeduccion_2'
CREATE INDEX [IX_FK_dbo_CatalogoDeduccion_2]
ON [dbo].[CatalogoDeduccion]
    ([FK_TipoDeduccion]);
GO

-- Creating foreign key on [FK_CatalogoDeduccion] in table 'DeduccionEfectuada'
ALTER TABLE [dbo].[DeduccionEfectuada]
ADD CONSTRAINT [FK_dbo_DeduccionEfectuada_2]
    FOREIGN KEY ([FK_CatalogoDeduccion])
    REFERENCES [dbo].[CatalogoDeduccion]
        ([PK_CatalogoDeduccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_DeduccionEfectuada_2'
CREATE INDEX [IX_FK_dbo_DeduccionEfectuada_2]
ON [dbo].[DeduccionEfectuada]
    ([FK_CatalogoDeduccion]);
GO

-- Creating foreign key on [FK_CatalogoDeduccion] in table 'DetalleDeduccion'
ALTER TABLE [dbo].[DetalleDeduccion]
ADD CONSTRAINT [FK_Planilla_CatalogoDeduccion]
    FOREIGN KEY ([FK_CatalogoDeduccion])
    REFERENCES [dbo].[CatalogoDeduccion]
        ([PK_CatalogoDeduccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Planilla_CatalogoDeduccion'
CREATE INDEX [IX_FK_Planilla_CatalogoDeduccion]
ON [dbo].[DetalleDeduccion]
    ([FK_CatalogoDeduccion]);
GO

-- Creating foreign key on [FK_TipoDia] in table 'CatalogoDia'
ALTER TABLE [dbo].[CatalogoDia]
ADD CONSTRAINT [FK_dbo_CatalogoDia_2]
    FOREIGN KEY ([FK_TipoDia])
    REFERENCES [dbo].[TipoDia]
        ([PK_TipoDia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CatalogoDia_2'
CREATE INDEX [IX_FK_dbo_CatalogoDia_2]
ON [dbo].[CatalogoDia]
    ([FK_TipoDia]);
GO

-- Creating foreign key on [FK_CatalogoDia] in table 'DiaPagado'
ALTER TABLE [dbo].[DiaPagado]
ADD CONSTRAINT [FK_dbo_DiaPagado_3]
    FOREIGN KEY ([FK_CatalogoDia])
    REFERENCES [dbo].[CatalogoDia]
        ([PK_CatalogoDia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_DiaPagado_3'
CREATE INDEX [IX_FK_dbo_DiaPagado_3]
ON [dbo].[DiaPagado]
    ([FK_CatalogoDia]);
GO

-- Creating foreign key on [FK_CatalogoDia] in table 'UbicacionAsueto'
ALTER TABLE [dbo].[UbicacionAsueto]
ADD CONSTRAINT [FK_dbo_UbicacionAsueto_2]
    FOREIGN KEY ([FK_CatalogoDia])
    REFERENCES [dbo].[CatalogoDia]
        ([PK_CatalogoDia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_UbicacionAsueto_2'
CREATE INDEX [IX_FK_dbo_UbicacionAsueto_2]
ON [dbo].[UbicacionAsueto]
    ([FK_CatalogoDia]);
GO

-- Creating foreign key on [FK_Perfil] in table 'CatalogoIncidencia'
ALTER TABLE [dbo].[CatalogoIncidencia]
ADD CONSTRAINT [FK_Catalogo_Perfil]
    FOREIGN KEY ([FK_Perfil])
    REFERENCES [dbo].[Perfil]
        ([PK_Perfil])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Catalogo_Perfil'
CREATE INDEX [IX_FK_Catalogo_Perfil]
ON [dbo].[CatalogoIncidencia]
    ([FK_Perfil]);
GO

-- Creating foreign key on [FK_CatalogoIncidencia] in table 'Incidencia'
ALTER TABLE [dbo].[Incidencia]
ADD CONSTRAINT [FK_Incidencia_CatalogoIncidencia]
    FOREIGN KEY ([FK_CatalogoIncidencia])
    REFERENCES [dbo].[CatalogoIncidencia]
        ([PK_CatalogoIncidencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Incidencia_CatalogoIncidencia'
CREATE INDEX [IX_FK_Incidencia_CatalogoIncidencia]
ON [dbo].[Incidencia]
    ([FK_CatalogoIncidencia]);
GO

-- Creating foreign key on [FK_CatalogoPregunta] in table 'DetalleCalificacionModificada'
ALTER TABLE [dbo].[DetalleCalificacionModificada]
ADD CONSTRAINT [FK_DetalleCalificacionModificada_CatalogoPregunta]
    FOREIGN KEY ([FK_CatalogoPregunta])
    REFERENCES [dbo].[CatalogoPregunta]
        ([PK_CatalogoPregunta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionModificada_CatalogoPregunta'
CREATE INDEX [IX_FK_DetalleCalificacionModificada_CatalogoPregunta]
ON [dbo].[DetalleCalificacionModificada]
    ([FK_CatalogoPregunta]);
GO

-- Creating foreign key on [FK_CatalogoPregunta] in table 'DetalleCalificacion'
ALTER TABLE [dbo].[DetalleCalificacion]
ADD CONSTRAINT [FK_detalleEvaluacion_CatalogoPreguntas]
    FOREIGN KEY ([FK_CatalogoPregunta])
    REFERENCES [dbo].[CatalogoPregunta]
        ([PK_CatalogoPregunta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detalleEvaluacion_CatalogoPreguntas'
CREATE INDEX [IX_FK_detalleEvaluacion_CatalogoPreguntas]
ON [dbo].[DetalleCalificacion]
    ([FK_CatalogoPregunta]);
GO

-- Creating foreign key on [FK_CatalogoRemuneracion] in table 'RemuneracionEfectuadaPF'
ALTER TABLE [dbo].[RemuneracionEfectuadaPF]
ADD CONSTRAINT [FK_dbo_RemuneracionEfectuadaPF_3]
    FOREIGN KEY ([FK_CatalogoRemuneracion])
    REFERENCES [dbo].[CatalogoRemuneracion]
        ([PK_CatalogoRemuneracion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_RemuneracionEfectuadaPF_3'
CREATE INDEX [IX_FK_dbo_RemuneracionEfectuadaPF_3]
ON [dbo].[RemuneracionEfectuadaPF]
    ([FK_CatalogoRemuneracion]);
GO

-- Creating foreign key on [FK_CatEstadoCivil] in table 'HistorialEstadoCivil'
ALTER TABLE [dbo].[HistorialEstadoCivil]
ADD CONSTRAINT [FK__Historial__CatEs__65E11278]
    FOREIGN KEY ([FK_CatEstadoCivil])
    REFERENCES [dbo].[CatEstadoCivil]
        ([PK_CatEstadoCivil])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Historial__CatEs__65E11278'
CREATE INDEX [IX_FK__Historial__CatEs__65E11278]
ON [dbo].[HistorialEstadoCivil]
    ([FK_CatEstadoCivil]);
GO

-- Creating foreign key on [FK_CatMovimientoPresupuesto] in table 'ComponentePresupuestario'
ALTER TABLE [dbo].[ComponentePresupuestario]
ADD CONSTRAINT [FK_ComponentePresupuestario_CatMovimientoPresupuesto]
    FOREIGN KEY ([FK_CatMovimientoPresupuesto])
    REFERENCES [dbo].[CatMovimientoPresupuesto]
        ([PK_CatMovimientoPresupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComponentePresupuestario_CatMovimientoPresupuesto'
CREATE INDEX [IX_FK_ComponentePresupuestario_CatMovimientoPresupuesto]
ON [dbo].[ComponentePresupuestario]
    ([FK_CatMovimientoPresupuesto]);
GO

-- Creating foreign key on [FK_Perfil] in table 'CatPermiso'
ALTER TABLE [dbo].[CatPermiso]
ADD CONSTRAINT [FK__CatPermis__Perfi__024846FC]
    FOREIGN KEY ([FK_Perfil])
    REFERENCES [dbo].[Perfil]
        ([PK_Perfil])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CatPermis__Perfi__024846FC'
CREATE INDEX [IX_FK__CatPermis__Perfi__024846FC]
ON [dbo].[CatPermiso]
    ([FK_Perfil]);
GO

-- Creating foreign key on [FK_CatPermiso] in table 'PerfilAcceso'
ALTER TABLE [dbo].[PerfilAcceso]
ADD CONSTRAINT [FK__PerfilAcc__CatPe__033C6B35]
    FOREIGN KEY ([FK_CatPermiso])
    REFERENCES [dbo].[CatPermiso]
        ([PK_CatPermiso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PerfilAcc__CatPe__033C6B35'
CREATE INDEX [IX_FK__PerfilAcc__CatPe__033C6B35]
ON [dbo].[PerfilAcceso]
    ([FK_CatPermiso]);
GO

-- Creating foreign key on [FK_EntidadSeguros] in table 'Caucion'
ALTER TABLE [dbo].[Caucion]
ADD CONSTRAINT [FK_Caucion_EntidadSeguros]
    FOREIGN KEY ([FK_EntidadSeguros])
    REFERENCES [dbo].[EntidadSeguros]
        ([PK_EntidadSeguros])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Caucion_EntidadSeguros'
CREATE INDEX [IX_FK_Caucion_EntidadSeguros]
ON [dbo].[Caucion]
    ([FK_EntidadSeguros]);
GO

-- Creating foreign key on [FK_MontoCaucion] in table 'Caucion'
ALTER TABLE [dbo].[Caucion]
ADD CONSTRAINT [FK_Caucion_MontoCaucion]
    FOREIGN KEY ([FK_MontoCaucion])
    REFERENCES [dbo].[MontoCaucion]
        ([PK_MontoCaucion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Caucion_MontoCaucion'
CREATE INDEX [IX_FK_Caucion_MontoCaucion]
ON [dbo].[Caucion]
    ([FK_MontoCaucion]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'Caucion'
ALTER TABLE [dbo].[Caucion]
ADD CONSTRAINT [FK_Caucion_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Caucion_Nombramiento'
CREATE INDEX [IX_FK_Caucion_Nombramiento]
ON [dbo].[Caucion]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Clase] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_Clase]
    FOREIGN KEY ([FK_Clase])
    REFERENCES [dbo].[Clase]
        ([PK_Clase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_Clase'
CREATE INDEX [IX_FK_detallePuesto_Clase]
ON [dbo].[DetallePuesto]
    ([FK_Clase]);
GO

-- Creating foreign key on [FK_ObjetoGasto] in table 'ComponentePresupuestario'
ALTER TABLE [dbo].[ComponentePresupuestario]
ADD CONSTRAINT [FK_ComponentePresupuestario_ObjetoGasto]
    FOREIGN KEY ([FK_ObjetoGasto])
    REFERENCES [dbo].[ObjetoGasto]
        ([PK_ObjetoGasto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComponentePresupuestario_ObjetoGasto'
CREATE INDEX [IX_FK_ComponentePresupuestario_ObjetoGasto]
ON [dbo].[ComponentePresupuestario]
    ([FK_ObjetoGasto]);
GO

-- Creating foreign key on [FK_Programa] in table 'ComponentePresupuestario'
ALTER TABLE [dbo].[ComponentePresupuestario]
ADD CONSTRAINT [FK_ComponentePresupuestario_Programa]
    FOREIGN KEY ([FK_Programa])
    REFERENCES [dbo].[Programa]
        ([PK_Programa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComponentePresupuestario_Programa'
CREATE INDEX [IX_FK_ComponentePresupuestario_Programa]
ON [dbo].[ComponentePresupuestario]
    ([FK_Programa]);
GO

-- Creating foreign key on [FK_ComponentePresupuestario] in table 'DecretoComponentePresupuestario'
ALTER TABLE [dbo].[DecretoComponentePresupuestario]
ADD CONSTRAINT [FK_DecretoComponentePresupuestario_ComponentePresupuestario]
    FOREIGN KEY ([FK_ComponentePresupuestario])
    REFERENCES [dbo].[ComponentePresupuestario]
        ([PK_ComponentePresupuestario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DecretoComponentePresupuestario_ComponentePresupuestario'
CREATE INDEX [IX_FK_DecretoComponentePresupuestario_ComponentePresupuestario]
ON [dbo].[DecretoComponentePresupuestario]
    ([FK_ComponentePresupuestario]);
GO

-- Creating foreign key on [FK_ObjetoGasto] in table 'ComponenteSalarial'
ALTER TABLE [dbo].[ComponenteSalarial]
ADD CONSTRAINT [FK_ComponenteSalarial_ObjetoGasto]
    FOREIGN KEY ([FK_ObjetoGasto])
    REFERENCES [dbo].[ObjetoGasto]
        ([PK_ObjetoGasto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComponenteSalarial_ObjetoGasto'
CREATE INDEX [IX_FK_ComponenteSalarial_ObjetoGasto]
ON [dbo].[ComponenteSalarial]
    ([FK_ObjetoGasto]);
GO

-- Creating foreign key on [FK_ComponenteSalarial] in table 'DetalleDesgloseSalarial'
ALTER TABLE [dbo].[DetalleDesgloseSalarial]
ADD CONSTRAINT [FK_DetalleDesgloseSalarial_ComponenteSalarial]
    FOREIGN KEY ([FK_ComponenteSalarial])
    REFERENCES [dbo].[ComponenteSalarial]
        ([PK_ComponenteSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleDesgloseSalarial_ComponenteSalarial'
CREATE INDEX [IX_FK_DetalleDesgloseSalarial_ComponenteSalarial]
ON [dbo].[DetalleDesgloseSalarial]
    ([FK_ComponenteSalarial]);
GO

-- Creating foreign key on [FK_ContenidoPresupuestario] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_ContenidoPresupuestario]
    FOREIGN KEY ([FK_ContenidoPresupuestario])
    REFERENCES [dbo].[ContenidoPresupuestario]
        ([PK_ContenidoPresupuestario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_ContenidoPresupuestario'
CREATE INDEX [IX_FK_detallePuesto_ContenidoPresupuestario]
ON [dbo].[DetallePuesto]
    ([FK_ContenidoPresupuestario]);
GO

-- Creating foreign key on [FK_DetalleContratacion] in table 'CuentaBancaria'
ALTER TABLE [dbo].[CuentaBancaria]
ADD CONSTRAINT [FK_CuentaBancaria_DetalleContratacion]
    FOREIGN KEY ([FK_DetalleContratacion])
    REFERENCES [dbo].[DetalleContratacion]
        ([PK_DetalleContratacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaBancaria_DetalleContratacion'
CREATE INDEX [IX_FK_CuentaBancaria_DetalleContratacion]
ON [dbo].[CuentaBancaria]
    ([FK_DetalleContratacion]);
GO

-- Creating foreign key on [FK_EntidadFinanciera] in table 'CuentaBancaria'
ALTER TABLE [dbo].[CuentaBancaria]
ADD CONSTRAINT [FK_Rel_CuentaBancaria_EntidadFinanciera]
    FOREIGN KEY ([FK_EntidadFinanciera])
    REFERENCES [dbo].[EntidadFinanciera]
        ([PK_EntidadFinanciera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rel_CuentaBancaria_EntidadFinanciera'
CREATE INDEX [IX_FK_Rel_CuentaBancaria_EntidadFinanciera]
ON [dbo].[CuentaBancaria]
    ([FK_EntidadFinanciera]);
GO

-- Creating foreign key on [FK_FormacionAcademica] in table 'CursoGrado'
ALTER TABLE [dbo].[CursoGrado]
ADD CONSTRAINT [FK_CursoGrado_FormacionAcademica]
    FOREIGN KEY ([FK_FormacionAcademica])
    REFERENCES [dbo].[FormacionAcademica]
        ([PK_FormacionAcademica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoGrado_FormacionAcademica'
CREATE INDEX [IX_FK_CursoGrado_FormacionAcademica]
ON [dbo].[CursoGrado]
    ([FK_FormacionAcademica]);
GO

-- Creating foreign key on [FK_Decreto] in table 'DecretoComponentePresupuestario'
ALTER TABLE [dbo].[DecretoComponentePresupuestario]
ADD CONSTRAINT [FK_DecretoComponentePresupuestario_Decreto]
    FOREIGN KEY ([FK_Decreto])
    REFERENCES [dbo].[Decreto]
        ([PK_Decreto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FK_PagoFeriado] in table 'DeduccionEfectuada'
ALTER TABLE [dbo].[DeduccionEfectuada]
ADD CONSTRAINT [FK_dbo_DeduccionEfectuada_3]
    FOREIGN KEY ([FK_PagoFeriado])
    REFERENCES [dbo].[PagoFeriado]
        ([PK_PagoFeriado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_DeduccionEfectuada_3'
CREATE INDEX [IX_FK_dbo_DeduccionEfectuada_3]
ON [dbo].[DeduccionEfectuada]
    ([FK_PagoFeriado]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'DeduccionTemporal'
ALTER TABLE [dbo].[DeduccionTemporal]
ADD CONSTRAINT [FK_DeduccionTemporal_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeduccionTemporal_Nombramiento'
CREATE INDEX [IX_FK_DeduccionTemporal_Nombramiento]
ON [dbo].[DeduccionTemporal]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Departamento] in table 'UbicacionAdministrativa'
ALTER TABLE [dbo].[UbicacionAdministrativa]
ADD CONSTRAINT [FK__Ubicacion__Depar__6E765879]
    FOREIGN KEY ([FK_Departamento])
    REFERENCES [dbo].[Departamento]
        ([PK_Departamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubicacion__Depar__6E765879'
CREATE INDEX [IX_FK__Ubicacion__Depar__6E765879]
ON [dbo].[UbicacionAdministrativa]
    ([FK_Departamento]);
GO

-- Creating foreign key on [FK_DesgloseSalarial] in table 'DetalleDesgloseSalarial'
ALTER TABLE [dbo].[DetalleDesgloseSalarial]
ADD CONSTRAINT [FK_DetalleDesgloseSalarial_DesgloseSalarial]
    FOREIGN KEY ([FK_DesgloseSalarial])
    REFERENCES [dbo].[DesgloseSalarial]
        ([PK_DesgloseSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleDesgloseSalarial_DesgloseSalarial'
CREATE INDEX [IX_FK_DetalleDesgloseSalarial_DesgloseSalarial]
ON [dbo].[DetalleDesgloseSalarial]
    ([FK_DesgloseSalarial]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'DesgloseSalarial'
ALTER TABLE [dbo].[DesgloseSalarial]
ADD CONSTRAINT [FK_Nombramiento_DesgloseSalarial]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Nombramiento_DesgloseSalarial'
CREATE INDEX [IX_FK_Nombramiento_DesgloseSalarial]
ON [dbo].[DesgloseSalarial]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_DesgloseSalarial] in table 'DetalleDeduccion'
ALTER TABLE [dbo].[DetalleDeduccion]
ADD CONSTRAINT [FK_Planilla_DesgloseSalarial]
    FOREIGN KEY ([FK_DesgloseSalarial])
    REFERENCES [dbo].[DesgloseSalarial]
        ([PK_DesgloseSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Planilla_DesgloseSalarial'
CREATE INDEX [IX_FK_Planilla_DesgloseSalarial]
ON [dbo].[DetalleDeduccion]
    ([FK_DesgloseSalarial]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'DetalleAcceso'
ALTER TABLE [dbo].[DetalleAcceso]
ADD CONSTRAINT [FK__DetalleAc__Funci__78BEDCC2]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DetalleAc__Funci__78BEDCC2'
CREATE INDEX [IX_FK__DetalleAc__Funci__78BEDCC2]
ON [dbo].[DetalleAcceso]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Usuario] in table 'DetalleAcceso'
ALTER TABLE [dbo].[DetalleAcceso]
ADD CONSTRAINT [FK__DetalleAc__Usuar__79B300FB]
    FOREIGN KEY ([FK_Usuario])
    REFERENCES [dbo].[Usuario]
        ([PK_Usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DetalleAc__Usuar__79B300FB'
CREATE INDEX [IX_FK__DetalleAc__Usuar__79B300FB]
ON [dbo].[DetalleAcceso]
    ([FK_Usuario]);
GO

-- Creating foreign key on [FK_DetalleAcceso] in table 'PerfilAcceso'
ALTER TABLE [dbo].[PerfilAcceso]
ADD CONSTRAINT [FK__PerfilAcc__Detal__7C8F6DA6]
    FOREIGN KEY ([FK_DetalleAcceso])
    REFERENCES [dbo].[DetalleAcceso]
        ([PK_DetalleAcceso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PerfilAcc__Detal__7C8F6DA6'
CREATE INDEX [IX_FK__PerfilAcc__Detal__7C8F6DA6]
ON [dbo].[PerfilAcceso]
    ([FK_DetalleAcceso]);
GO

-- Creating foreign key on [FK_DetallePuesto] in table 'DetalleAccionPersonal'
ALTER TABLE [dbo].[DetalleAccionPersonal]
ADD CONSTRAINT [FK_DetalleAccionPersonal_DetallePuesto]
    FOREIGN KEY ([FK_DetallePuesto])
    REFERENCES [dbo].[DetallePuesto]
        ([PK_DetallePuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleAccionPersonal_DetallePuesto'
CREATE INDEX [IX_FK_DetalleAccionPersonal_DetallePuesto]
ON [dbo].[DetalleAccionPersonal]
    ([FK_DetallePuesto]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'DetalleBorradorAccionPersonal'
ALTER TABLE [dbo].[DetalleBorradorAccionPersonal]
ADD CONSTRAINT [FK_DetalleBorradorAccionPersonal_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleBorradorAccionPersonal_Nombramiento'
CREATE INDEX [IX_FK_DetalleBorradorAccionPersonal_Nombramiento]
ON [dbo].[DetalleBorradorAccionPersonal]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Programa] in table 'DetalleBorradorAccionPersonal'
ALTER TABLE [dbo].[DetalleBorradorAccionPersonal]
ADD CONSTRAINT [FK_DetalleBorradorAccionPersonal_Programa]
    FOREIGN KEY ([FK_Programa])
    REFERENCES [dbo].[Programa]
        ([PK_Programa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleBorradorAccionPersonal_Programa'
CREATE INDEX [IX_FK_DetalleBorradorAccionPersonal_Programa]
ON [dbo].[DetalleBorradorAccionPersonal]
    ([FK_Programa]);
GO

-- Creating foreign key on [FK_Seccion] in table 'DetalleBorradorAccionPersonal'
ALTER TABLE [dbo].[DetalleBorradorAccionPersonal]
ADD CONSTRAINT [FK_DetalleBorradorAccionPersonal_Seccion]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleBorradorAccionPersonal_Seccion'
CREATE INDEX [IX_FK_DetalleBorradorAccionPersonal_Seccion]
ON [dbo].[DetalleBorradorAccionPersonal]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_TipoAccionPersonal] in table 'DetalleBorradorAccionPersonal'
ALTER TABLE [dbo].[DetalleBorradorAccionPersonal]
ADD CONSTRAINT [FK_DetalleBorradorAccionPersonal_TipoAccionPersonal]
    FOREIGN KEY ([FK_TipoAccionPersonal])
    REFERENCES [dbo].[TipoAccionPersonal]
        ([PK_TipoAccionPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleBorradorAccionPersonal_TipoAccionPersonal'
CREATE INDEX [IX_FK_DetalleBorradorAccionPersonal_TipoAccionPersonal]
ON [dbo].[DetalleBorradorAccionPersonal]
    ([FK_TipoAccionPersonal]);
GO

-- Creating foreign key on [FK_EstadoPedimento] in table 'DetalleCambioPedimento'
ALTER TABLE [dbo].[DetalleCambioPedimento]
ADD CONSTRAINT [FK_DetalleCambioPedimento_EstadoPedimento]
    FOREIGN KEY ([FK_EstadoPedimento])
    REFERENCES [dbo].[EstadoPedimento]
        ([PK_EstadoPedimento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCambioPedimento_EstadoPedimento'
CREATE INDEX [IX_FK_DetalleCambioPedimento_EstadoPedimento]
ON [dbo].[DetalleCambioPedimento]
    ([FK_EstadoPedimento]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'DetalleContratacion'
ALTER TABLE [dbo].[DetalleContratacion]
ADD CONSTRAINT [FK_DetalleContratacion_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleContratacion_Funcionario'
CREATE INDEX [IX_FK_DetalleContratacion_Funcionario]
ON [dbo].[DetalleContratacion]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_TipoJornada] in table 'DetalleContratacion'
ALTER TABLE [dbo].[DetalleContratacion]
ADD CONSTRAINT [FK_DetalleContratacion_TipoJornada]
    FOREIGN KEY ([FK_TipoJornada])
    REFERENCES [dbo].[TipoJornada]
        ([PK_TipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleContratacion_TipoJornada'
CREATE INDEX [IX_FK_DetalleContratacion_TipoJornada]
ON [dbo].[DetalleContratacion]
    ([FK_TipoJornada]);
GO

-- Creating foreign key on [FK_MovimientoGastoTransporte] in table 'DetalleDeduccionGastoTransporte'
ALTER TABLE [dbo].[DetalleDeduccionGastoTransporte]
ADD CONSTRAINT [FK_DetalleDeduccionGastoTransporte_MovimientoGastoTransporte]
    FOREIGN KEY ([FK_MovimientoGastoTransporte])
    REFERENCES [dbo].[MovimientoGastoTransporte]
        ([PK_MovimientoGastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleDeduccionGastoTransporte_MovimientoGastoTransporte'
CREATE INDEX [IX_FK_DetalleDeduccionGastoTransporte_MovimientoGastoTransporte]
ON [dbo].[DetalleDeduccionGastoTransporte]
    ([FK_MovimientoGastoTransporte]);
GO

-- Creating foreign key on [FK_MovimientoViaticoCorrido] in table 'DetalleDeduccionViaticoCorrido'
ALTER TABLE [dbo].[DetalleDeduccionViaticoCorrido]
ADD CONSTRAINT [FK_DetalleDeduccionViaticoCorrido_MovimientoViaticoCorrido]
    FOREIGN KEY ([FK_MovimientoViaticoCorrido])
    REFERENCES [dbo].[MovimientoViaticoCorrido]
        ([PK_MovimientoViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleDeduccionViaticoCorrido_MovimientoViaticoCorrido'
CREATE INDEX [IX_FK_DetalleDeduccionViaticoCorrido_MovimientoViaticoCorrido]
ON [dbo].[DetalleDeduccionViaticoCorrido]
    ([FK_MovimientoViaticoCorrido]);
GO

-- Creating foreign key on [FK_MovimientoGastoTransporte] in table 'DetalleEliminacionViaticoCorridoGastoTransporte'
ALTER TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte]
ADD CONSTRAINT [FK_EliminacionGastoTransporte_MovimientoGastoTransporte]
    FOREIGN KEY ([FK_MovimientoGastoTransporte])
    REFERENCES [dbo].[MovimientoGastoTransporte]
        ([PK_MovimientoGastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EliminacionGastoTransporte_MovimientoGastoTransporte'
CREATE INDEX [IX_FK_EliminacionGastoTransporte_MovimientoGastoTransporte]
ON [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte]
    ([FK_MovimientoGastoTransporte]);
GO

-- Creating foreign key on [FK_MovimientoViaticoCorrido] in table 'DetalleEliminacionViaticoCorridoGastoTransporte'
ALTER TABLE [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte]
ADD CONSTRAINT [FK_EliminacionViaticoCorrido_MovimientoViaticoCorrido]
    FOREIGN KEY ([FK_MovimientoViaticoCorrido])
    REFERENCES [dbo].[MovimientoViaticoCorrido]
        ([PK_MovimientoViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EliminacionViaticoCorrido_MovimientoViaticoCorrido'
CREATE INDEX [IX_FK_EliminacionViaticoCorrido_MovimientoViaticoCorrido]
ON [dbo].[DetalleEliminacionViaticoCorridoGastoTransporte]
    ([FK_MovimientoViaticoCorrido]);
GO

-- Creating foreign key on [FK_RegistroIncapacidad] in table 'DetalleIncapacidad'
ALTER TABLE [dbo].[DetalleIncapacidad]
ADD CONSTRAINT [FK_DetalleIncapacidad_RegistroIncapacidad]
    FOREIGN KEY ([FK_RegistroIncapacidad])
    REFERENCES [dbo].[RegistroIncapacidad]
        ([PK_RegistroIncapacidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleIncapacidad_RegistroIncapacidad'
CREATE INDEX [IX_FK_DetalleIncapacidad_RegistroIncapacidad]
ON [dbo].[DetalleIncapacidad]
    ([FK_RegistroIncapacidad]);
GO

-- Creating foreign key on [FK_TipoDetallePagoGasto] in table 'DetallePagoGastoTransporte'
ALTER TABLE [dbo].[DetallePagoGastoTransporte]
ADD CONSTRAINT [FK_DetallePagoGastoTransporte_TipoDetalleGastoTransporte]
    FOREIGN KEY ([FK_TipoDetallePagoGasto])
    REFERENCES [dbo].[TipoDetalleGastoTransporte]
        ([PK_TipoDetallePagoGasto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePagoGastoTransporte_TipoDetalleGastoTransporte'
CREATE INDEX [IX_FK_DetallePagoGastoTransporte_TipoDetalleGastoTransporte]
ON [dbo].[DetallePagoGastoTransporte]
    ([FK_TipoDetallePagoGasto]);
GO

-- Creating foreign key on [FK_PagoViaticoCorrido] in table 'DetallePagoViaticoCorrido'
ALTER TABLE [dbo].[DetallePagoViaticoCorrido]
ADD CONSTRAINT [FK_DetallePagoViaticoCorrido_PagoViaticoCorrido]
    FOREIGN KEY ([FK_PagoViaticoCorrido])
    REFERENCES [dbo].[PagoViaticoCorrido]
        ([PK_PagoViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePagoViaticoCorrido_PagoViaticoCorrido'
CREATE INDEX [IX_FK_DetallePagoViaticoCorrido_PagoViaticoCorrido]
ON [dbo].[DetallePagoViaticoCorrido]
    ([FK_PagoViaticoCorrido]);
GO

-- Creating foreign key on [FK_TipoDetallePagoViatico] in table 'DetallePagoViaticoCorrido'
ALTER TABLE [dbo].[DetallePagoViaticoCorrido]
ADD CONSTRAINT [FK_DetallePagoViaticoCorrido_TipoDetallePagoViatico]
    FOREIGN KEY ([FK_TipoDetallePagoViatico])
    REFERENCES [dbo].[TipoDetallePagoViatico]
        ([PK_TipoDetallePagoViatico])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePagoViaticoCorrido_TipoDetallePagoViatico'
CREATE INDEX [IX_FK_DetallePagoViaticoCorrido_TipoDetallePagoViatico]
ON [dbo].[DetallePagoViaticoCorrido]
    ([FK_TipoDetallePagoViatico]);
GO

-- Creating foreign key on [FK_PagoViaticoRetroactivo] in table 'DetallePagoViaticoRetroactivo'
ALTER TABLE [dbo].[DetallePagoViaticoRetroactivo]
ADD CONSTRAINT [FK_DetallePagoViaticoRetroactivo_PagoViaticoRetroactivo]
    FOREIGN KEY ([FK_PagoViaticoRetroactivo])
    REFERENCES [dbo].[PagoViaticoRetroactivo]
        ([PK_PagoViaticoRetroactivo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePagoViaticoRetroactivo_PagoViaticoRetroactivo'
CREATE INDEX [IX_FK_DetallePagoViaticoRetroactivo_PagoViaticoRetroactivo]
ON [dbo].[DetallePagoViaticoRetroactivo]
    ([FK_PagoViaticoRetroactivo]);
GO

-- Creating foreign key on [FK_TipoDetallePagoViatico] in table 'DetallePagoViaticoRetroactivo'
ALTER TABLE [dbo].[DetallePagoViaticoRetroactivo]
ADD CONSTRAINT [FK_DetallePagoViaticoRetroactivo_TipoDetallePagoViatico]
    FOREIGN KEY ([FK_TipoDetallePagoViatico])
    REFERENCES [dbo].[TipoDetallePagoViatico]
        ([PK_TipoDetallePagoViatico])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePagoViaticoRetroactivo_TipoDetallePagoViatico'
CREATE INDEX [IX_FK_DetallePagoViaticoRetroactivo_TipoDetallePagoViatico]
ON [dbo].[DetallePagoViaticoRetroactivo]
    ([FK_TipoDetallePagoViatico]);
GO

-- Creating foreign key on [FK_Escala] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_Escala]
    FOREIGN KEY ([FK_Escala])
    REFERENCES [dbo].[EscalaSalarial]
        ([PK_Escala])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_Escala'
CREATE INDEX [IX_FK_detallePuesto_Escala]
ON [dbo].[DetallePuesto]
    ([FK_Escala]);
GO

-- Creating foreign key on [FK_Especialidad] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_Especialidad]
    FOREIGN KEY ([FK_Especialidad])
    REFERENCES [dbo].[Especialidad]
        ([PK_Especialidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_Especialidad'
CREATE INDEX [IX_FK_detallePuesto_Especialidad]
ON [dbo].[DetallePuesto]
    ([FK_Especialidad]);
GO

-- Creating foreign key on [FK_OcupacionReal] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_OcupacionReal]
    FOREIGN KEY ([FK_OcupacionReal])
    REFERENCES [dbo].[OcupacionReal]
        ([PK_OcupacionReal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_OcupacionReal'
CREATE INDEX [IX_FK_detallePuesto_OcupacionReal]
ON [dbo].[DetallePuesto]
    ([FK_OcupacionReal]);
GO

-- Creating foreign key on [FK_Puesto] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_Puesto'
CREATE INDEX [IX_FK_detallePuesto_Puesto]
ON [dbo].[DetallePuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_SubEspecialidad] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_Subespecialidad]
    FOREIGN KEY ([FK_SubEspecialidad])
    REFERENCES [dbo].[SubEspecialidad]
        ([PK_SubEspecialidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_Subespecialidad'
CREATE INDEX [IX_FK_detallePuesto_Subespecialidad]
ON [dbo].[DetallePuesto]
    ([FK_SubEspecialidad]);
GO

-- Creating foreign key on [FK_TipoPuesto] in table 'DetallePuesto'
ALTER TABLE [dbo].[DetallePuesto]
ADD CONSTRAINT [FK_detallePuesto_TipoPuesto]
    FOREIGN KEY ([FK_TipoPuesto])
    REFERENCES [dbo].[TipoPuesto]
        ([PK_TipoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_detallePuesto_TipoPuesto'
CREATE INDEX [IX_FK_detallePuesto_TipoPuesto]
ON [dbo].[DetallePuesto]
    ([FK_TipoPuesto]);
GO

-- Creating foreign key on [FK_TipoExtra] in table 'DetalleTiempoExtra'
ALTER TABLE [dbo].[DetalleTiempoExtra]
ADD CONSTRAINT [FK_DetalleTiempoExtra_Tipo]
    FOREIGN KEY ([FK_TipoExtra])
    REFERENCES [dbo].[TipoExtra]
        ([PK_TipoExtra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleTiempoExtra_Tipo'
CREATE INDEX [IX_FK_DetalleTiempoExtra_Tipo]
ON [dbo].[DetalleTiempoExtra]
    ([FK_TipoExtra]);
GO

-- Creating foreign key on [FK_PagoFeriado] in table 'DiaPagado'
ALTER TABLE [dbo].[DiaPagado]
ADD CONSTRAINT [FK_dbo_DiaPagado_2]
    FOREIGN KEY ([FK_PagoFeriado])
    REFERENCES [dbo].[PagoFeriado]
        ([PK_PagoFeriado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_DiaPagado_2'
CREATE INDEX [IX_FK_dbo_DiaPagado_2]
ON [dbo].[DiaPagado]
    ([FK_PagoFeriado]);
GO

-- Creating foreign key on [FK_Distrito] in table 'Direccion'
ALTER TABLE [dbo].[Direccion]
ADD CONSTRAINT [FK__Direccion__Distr__7ADC2F5E]
    FOREIGN KEY ([FK_Distrito])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Direccion__Distr__7ADC2F5E'
CREATE INDEX [IX_FK__Direccion__Distr__7ADC2F5E]
ON [dbo].[Direccion]
    ([FK_Distrito]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'Direccion'
ALTER TABLE [dbo].[Direccion]
ADD CONSTRAINT [FK__Direccion__Funci__79E80B25]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Direccion__Funci__79E80B25'
CREATE INDEX [IX_FK__Direccion__Funci__79E80B25]
ON [dbo].[Direccion]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_DireccionGeneral] in table 'UbicacionAdministrativa'
ALTER TABLE [dbo].[UbicacionAdministrativa]
ADD CONSTRAINT [FK__Ubicacion__Direc__6D823440]
    FOREIGN KEY ([FK_DireccionGeneral])
    REFERENCES [dbo].[DireccionGeneral]
        ([PK_DireccionGeneral])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubicacion__Direc__6D823440'
CREATE INDEX [IX_FK__Ubicacion__Direc__6D823440]
ON [dbo].[UbicacionAdministrativa]
    ([FK_DireccionGeneral]);
GO

-- Creating foreign key on [FK_Distrito] in table 'UbicacionPuesto'
ALTER TABLE [dbo].[UbicacionPuesto]
ADD CONSTRAINT [FK__Ubicacion__Distr__76177A41]
    FOREIGN KEY ([FK_Distrito])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubicacion__Distr__76177A41'
CREATE INDEX [IX_FK__Ubicacion__Distr__76177A41]
ON [dbo].[UbicacionPuesto]
    ([FK_Distrito]);
GO

-- Creating foreign key on [FK_Division] in table 'UbicacionAdministrativa'
ALTER TABLE [dbo].[UbicacionAdministrativa]
ADD CONSTRAINT [FK__Ubicacion__Divis__6C8E1007]
    FOREIGN KEY ([FK_Division])
    REFERENCES [dbo].[Division]
        ([PK_Division])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubicacion__Divis__6C8E1007'
CREATE INDEX [IX_FK__Ubicacion__Divis__6C8E1007]
ON [dbo].[UbicacionAdministrativa]
    ([FK_Division]);
GO

-- Creating foreign key on [FK_EntidadAdscrita] in table 'PrestamoPuesto'
ALTER TABLE [dbo].[PrestamoPuesto]
ADD CONSTRAINT [FK_PrestamoPuesto_EntidadAdscrita]
    FOREIGN KEY ([FK_EntidadAdscrita])
    REFERENCES [dbo].[EntidadAdscrita]
        ([PK_EntidadAdscrita])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestamoPuesto_EntidadAdscrita'
CREATE INDEX [IX_FK_PrestamoPuesto_EntidadAdscrita]
ON [dbo].[PrestamoPuesto]
    ([FK_EntidadAdscrita]);
GO

-- Creating foreign key on [FK_EntidadGubernamental] in table 'PrestamoPuesto'
ALTER TABLE [dbo].[PrestamoPuesto]
ADD CONSTRAINT [FK_PrestamoPuesto_EntidadGubernamental]
    FOREIGN KEY ([FK_EntidadGubernamental])
    REFERENCES [dbo].[EntidadGubernamental]
        ([PK_EntidadGubernamental])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestamoPuesto_EntidadGubernamental'
CREATE INDEX [IX_FK_PrestamoPuesto_EntidadGubernamental]
ON [dbo].[PrestamoPuesto]
    ([FK_EntidadGubernamental]);
GO

-- Creating foreign key on [FK_EntidadMedica] in table 'TipoIncapacidad'
ALTER TABLE [dbo].[TipoIncapacidad]
ADD CONSTRAINT [FK_TipoIncapacidad_EntidadMedica]
    FOREIGN KEY ([FK_EntidadMedica])
    REFERENCES [dbo].[EntidadMedica]
        ([PK_EntidadMedica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoIncapacidad_EntidadMedica'
CREATE INDEX [IX_FK_TipoIncapacidad_EntidadMedica]
ON [dbo].[TipoIncapacidad]
    ([FK_EntidadMedica]);
GO

-- Creating foreign key on [FK_Periodo] in table 'EscalaSalarial'
ALTER TABLE [dbo].[EscalaSalarial]
ADD CONSTRAINT [FK_Periodo_EscalaSalarial]
    FOREIGN KEY ([FK_Periodo])
    REFERENCES [dbo].[PeriodoEscalaSalarial]
        ([PK_Periodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Periodo_EscalaSalarial'
CREATE INDEX [IX_FK_Periodo_EscalaSalarial]
ON [dbo].[EscalaSalarial]
    ([FK_Periodo]);
GO

-- Creating foreign key on [FK_EstadoFuncionario] in table 'Funcionario'
ALTER TABLE [dbo].[Funcionario]
ADD CONSTRAINT [FK__Funcionar__Estad__5C57A83E]
    FOREIGN KEY ([FK_EstadoFuncionario])
    REFERENCES [dbo].[EstadoFuncionario]
        ([PK_EstadoFuncionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Funcionar__Estad__5C57A83E'
CREATE INDEX [IX_FK__Funcionar__Estad__5C57A83E]
ON [dbo].[Funcionario]
    ([FK_EstadoFuncionario]);
GO

-- Creating foreign key on [FK_EstadoMovimientoPuesto] in table 'MovimientoPuesto'
ALTER TABLE [dbo].[MovimientoPuesto]
ADD CONSTRAINT [FK_MovimientoPuesto_EstadoMovimientoPuesto]
    FOREIGN KEY ([FK_EstadoMovimientoPuesto])
    REFERENCES [dbo].[EstadoMovimientoPuesto]
        ([PK_EstadoMovimientoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimientoPuesto_EstadoMovimientoPuesto'
CREATE INDEX [IX_FK_MovimientoPuesto_EstadoMovimientoPuesto]
ON [dbo].[MovimientoPuesto]
    ([FK_EstadoMovimientoPuesto]);
GO

-- Creating foreign key on [FK_EstadoNombramiento] in table 'Nombramiento'
ALTER TABLE [dbo].[Nombramiento]
ADD CONSTRAINT [FK_Nombramiento_EstadoNombramiento]
    FOREIGN KEY ([FK_EstadoNombramiento])
    REFERENCES [dbo].[EstadoNombramiento]
        ([PK_EstadoNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Nombramiento_EstadoNombramiento'
CREATE INDEX [IX_FK_Nombramiento_EstadoNombramiento]
ON [dbo].[Nombramiento]
    ([FK_EstadoNombramiento]);
GO

-- Creating foreign key on [FK_EstadoPuesto] in table 'Puesto'
ALTER TABLE [dbo].[Puesto]
ADD CONSTRAINT [FK_Puesto_EstadoPuesto]
    FOREIGN KEY ([FK_EstadoPuesto])
    REFERENCES [dbo].[EstadoPuesto]
        ([PK_EstadoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Puesto_EstadoPuesto'
CREATE INDEX [IX_FK_Puesto_EstadoPuesto]
ON [dbo].[Puesto]
    ([FK_EstadoPuesto]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__37F0F5ED]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__37F0F5ED'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__37F0F5ED]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__38E51A26]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__38E51A26'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__38E51A26]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__39D93E5F]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__39D93E5F'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__39D93E5F]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__3ACD6298]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__3ACD6298'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__3ACD6298]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__5BA4467E]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__5BA4467E'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__5BA4467E]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__5C986AB7]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__5C986AB7'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__5C986AB7]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__5D8C8EF0]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__5D8C8EF0'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__5D8C8EF0]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTipoJornada] in table 'TipoJornada'
ALTER TABLE [dbo].[TipoJornada]
ADD CONSTRAINT [FK__TipoJorna__FK_Es__5E80B329]
    FOREIGN KEY ([FK_EstadoTipoJornada])
    REFERENCES [dbo].[EstadoTipoJornada]
        ([PK_EstadoTipoJornada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TipoJorna__FK_Es__5E80B329'
CREATE INDEX [IX_FK__TipoJorna__FK_Es__5E80B329]
ON [dbo].[TipoJornada]
    ([FK_EstadoTipoJornada]);
GO

-- Creating foreign key on [FK_EstadoTramite] in table 'PagoFeriado'
ALTER TABLE [dbo].[PagoFeriado]
ADD CONSTRAINT [FK_dbo_PagoFeriado_3]
    FOREIGN KEY ([FK_EstadoTramite])
    REFERENCES [dbo].[EstadoTramite]
        ([PK_EstadoTramite])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_PagoFeriado_3'
CREATE INDEX [IX_FK_dbo_PagoFeriado_3]
ON [dbo].[PagoFeriado]
    ([FK_EstadoTramite]);
GO

-- Creating foreign key on [FK_Puesto] in table 'EstudioPuesto'
ALTER TABLE [dbo].[EstudioPuesto]
ADD CONSTRAINT [FK_EstudidoPuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudidoPuesto_Puesto'
CREATE INDEX [IX_FK_EstudidoPuesto_Puesto]
ON [dbo].[EstudioPuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'ExpedienteFuncionario'
ALTER TABLE [dbo].[ExpedienteFuncionario]
ADD CONSTRAINT [FK_ExpedienteFuncionario_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpedienteFuncionario_Funcionario'
CREATE INDEX [IX_FK_ExpedienteFuncionario_Funcionario]
ON [dbo].[ExpedienteFuncionario]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_ExpedienteFuncionario] in table 'Tomo'
ALTER TABLE [dbo].[Tomo]
ADD CONSTRAINT [FK_Tomo_ExpedienteFuncionario]
    FOREIGN KEY ([FK_ExpedienteFuncionario])
    REFERENCES [dbo].[ExpedienteFuncionario]
        ([PK_IdExpedienteFuncionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tomo_ExpedienteFuncionario'
CREATE INDEX [IX_FK_Tomo_ExpedienteFuncionario]
ON [dbo].[Tomo]
    ([FK_ExpedienteFuncionario]);
GO

-- Creating foreign key on [FK_FormacionAcademica] in table 'ExperienciaProfesional'
ALTER TABLE [dbo].[ExperienciaProfesional]
ADD CONSTRAINT [FK_ExperienciaProfesional_FormacionAcademica]
    FOREIGN KEY ([FK_FormacionAcademica])
    REFERENCES [dbo].[FormacionAcademica]
        ([PK_FormacionAcademica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExperienciaProfesional_FormacionAcademica'
CREATE INDEX [IX_FK_ExperienciaProfesional_FormacionAcademica]
ON [dbo].[ExperienciaProfesional]
    ([FK_FormacionAcademica]);
GO

-- Creating foreign key on [FK_TituloFactor] in table 'Factor'
ALTER TABLE [dbo].[Factor]
ADD CONSTRAINT [FK_Factor_TituloFactor]
    FOREIGN KEY ([FK_TituloFactor])
    REFERENCES [dbo].[TituloFactor]
        ([PK_TituloFactor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Factor_TituloFactor'
CREATE INDEX [IX_FK_Factor_TituloFactor]
ON [dbo].[Factor]
    ([FK_TituloFactor]);
GO

-- Creating foreign key on [FK_IdTomo] in table 'Folio'
ALTER TABLE [dbo].[Folio]
ADD CONSTRAINT [FK_Folio_Tomo]
    FOREIGN KEY ([FK_IdTomo])
    REFERENCES [dbo].[Tomo]
        ([PK_IdTomo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Folio_Tomo'
CREATE INDEX [IX_FK_Folio_Tomo]
ON [dbo].[Folio]
    ([FK_IdTomo]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'FormacionAcademica'
ALTER TABLE [dbo].[FormacionAcademica]
ADD CONSTRAINT [FK_FormacionAcademica_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormacionAcademica_Funcionario'
CREATE INDEX [IX_FK_FormacionAcademica_Funcionario]
ON [dbo].[FormacionAcademica]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'HistorialEstadoCivil'
ALTER TABLE [dbo].[HistorialEstadoCivil]
ADD CONSTRAINT [FK__Historial__Funci__64ECEE3F]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Historial__Funci__64ECEE3F'
CREATE INDEX [IX_FK__Historial__Funci__64ECEE3F]
ON [dbo].[HistorialEstadoCivil]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'InformacionContacto'
ALTER TABLE [dbo].[InformacionContacto]
ADD CONSTRAINT [FK__Informaci__Funci__68BD7F23]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Informaci__Funci__68BD7F23'
CREATE INDEX [IX_FK__Informaci__Funci__68BD7F23]
ON [dbo].[InformacionContacto]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'PagoExtraordinario'
ALTER TABLE [dbo].[PagoExtraordinario]
ADD CONSTRAINT [FK_dbo_PagoExtraordinario_2]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_PagoExtraordinario_2'
CREATE INDEX [IX_FK_dbo_PagoExtraordinario_2]
ON [dbo].[PagoExtraordinario]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_FuncionarioEmisor] in table 'Incidencia'
ALTER TABLE [dbo].[Incidencia]
ADD CONSTRAINT [FK_Incidencia_FuncionarioEmisor]
    FOREIGN KEY ([FK_FuncionarioEmisor])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Incidencia_FuncionarioEmisor'
CREATE INDEX [IX_FK_Incidencia_FuncionarioEmisor]
ON [dbo].[Incidencia]
    ([FK_FuncionarioEmisor]);
GO

-- Creating foreign key on [FK_FuncionarioUIRH] in table 'Incidencia'
ALTER TABLE [dbo].[Incidencia]
ADD CONSTRAINT [FK_Incidencia_FuncionarioUIRH]
    FOREIGN KEY ([FK_FuncionarioUIRH])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Incidencia_FuncionarioUIRH'
CREATE INDEX [IX_FK_Incidencia_FuncionarioUIRH]
ON [dbo].[Incidencia]
    ([FK_FuncionarioUIRH]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'Nombramiento'
ALTER TABLE [dbo].[Nombramiento]
ADD CONSTRAINT [FK_Nombramiento_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Nombramiento_Funcionario'
CREATE INDEX [IX_FK_Nombramiento_Funcionario]
ON [dbo].[Nombramiento]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_TipoContacto] in table 'InformacionContacto'
ALTER TABLE [dbo].[InformacionContacto]
ADD CONSTRAINT [FK__Informaci__TipoC__69B1A35C]
    FOREIGN KEY ([FK_TipoContacto])
    REFERENCES [dbo].[TipoContacto]
        ([PK_TipoContacto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Informaci__TipoC__69B1A35C'
CREATE INDEX [IX_FK__Informaci__TipoC__69B1A35C]
ON [dbo].[InformacionContacto]
    ([FK_TipoContacto]);
GO

-- Creating foreign key on [FK_MotivoMovimiento] in table 'MovimientoPuesto'
ALTER TABLE [dbo].[MovimientoPuesto]
ADD CONSTRAINT [FK_Rel_MovimientoPuesto_MotivoMovimiento]
    FOREIGN KEY ([FK_MotivoMovimiento])
    REFERENCES [dbo].[MotivoMovimiento]
        ([PK_MotivoMovimiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rel_MovimientoPuesto_MotivoMovimiento'
CREATE INDEX [IX_FK_Rel_MovimientoPuesto_MotivoMovimiento]
ON [dbo].[MovimientoPuesto]
    ([FK_MotivoMovimiento]);
GO

-- Creating foreign key on [FK_Puesto] in table 'MovimientoPuesto'
ALTER TABLE [dbo].[MovimientoPuesto]
ADD CONSTRAINT [FK_MovimientoPuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimientoPuesto_Puesto'
CREATE INDEX [IX_FK_MovimientoPuesto_Puesto]
ON [dbo].[MovimientoPuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_Puesto] in table 'Nombramiento'
ALTER TABLE [dbo].[Nombramiento]
ADD CONSTRAINT [FK_Nombramiento_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Nombramiento_Puesto'
CREATE INDEX [IX_FK_Nombramiento_Puesto]
ON [dbo].[Nombramiento]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'PeriodoVacaciones'
ALTER TABLE [dbo].[PeriodoVacaciones]
ADD CONSTRAINT [FK_PeriodoVacaciones_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodoVacaciones_Nombramiento'
CREATE INDEX [IX_FK_PeriodoVacaciones_Nombramiento]
ON [dbo].[PeriodoVacaciones]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'PrestacionLegal'
ALTER TABLE [dbo].[PrestacionLegal]
ADD CONSTRAINT [FK_PrestacionLegal_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestacionLegal_Nombramiento'
CREATE INDEX [IX_FK_PrestacionLegal_Nombramiento]
ON [dbo].[PrestacionLegal]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'RegistroIncapacidad'
ALTER TABLE [dbo].[RegistroIncapacidad]
ADD CONSTRAINT [FK_PK_RegistroIncapacidad_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PK_RegistroIncapacidad_Nombramiento'
CREATE INDEX [IX_FK_PK_RegistroIncapacidad_Nombramiento]
ON [dbo].[RegistroIncapacidad]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Partida] in table 'ObjetoGasto'
ALTER TABLE [dbo].[ObjetoGasto]
ADD CONSTRAINT [FK_ObjetoGasto_Partida]
    FOREIGN KEY ([FK_Partida])
    REFERENCES [dbo].[Partida]
        ([PK_Partida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetoGasto_Partida'
CREATE INDEX [IX_FK_ObjetoGasto_Partida]
ON [dbo].[ObjetoGasto]
    ([FK_Partida]);
GO

-- Creating foreign key on [FK_SubPartida] in table 'ObjetoGasto'
ALTER TABLE [dbo].[ObjetoGasto]
ADD CONSTRAINT [FK_ObjetoGasto_SubPartida]
    FOREIGN KEY ([FK_SubPartida])
    REFERENCES [dbo].[SubPartida]
        ([PK_SubPartida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetoGasto_SubPartida'
CREATE INDEX [IX_FK_ObjetoGasto_SubPartida]
ON [dbo].[ObjetoGasto]
    ([FK_SubPartida]);
GO

-- Creating foreign key on [FK_PagoExtraordinario] in table 'PagoFeriado'
ALTER TABLE [dbo].[PagoFeriado]
ADD CONSTRAINT [FK_dbo_PagoFeriado_2]
    FOREIGN KEY ([FK_PagoExtraordinario])
    REFERENCES [dbo].[PagoExtraordinario]
        ([PK_PagoExtraordinario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_PagoFeriado_2'
CREATE INDEX [IX_FK_dbo_PagoFeriado_2]
ON [dbo].[PagoFeriado]
    ([FK_PagoExtraordinario]);
GO

-- Creating foreign key on [FK_PagoFeriado] in table 'RemuneracionEfectuadaPF'
ALTER TABLE [dbo].[RemuneracionEfectuadaPF]
ADD CONSTRAINT [FK_dbo_RemuneracionEfectuadaPF_2]
    FOREIGN KEY ([FK_PagoFeriado])
    REFERENCES [dbo].[PagoFeriado]
        ([PK_PagoFeriado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_RemuneracionEfectuadaPF_2'
CREATE INDEX [IX_FK_dbo_RemuneracionEfectuadaPF_2]
ON [dbo].[RemuneracionEfectuadaPF]
    ([FK_PagoFeriado]);
GO

-- Creating foreign key on [FK_PagoViaticoCorrido] in table 'PagoViaticoRetroactivo'
ALTER TABLE [dbo].[PagoViaticoRetroactivo]
ADD CONSTRAINT [FK_PagoViaticoRetroactivo_PagoViaticoCorrido]
    FOREIGN KEY ([FK_PagoViaticoCorrido])
    REFERENCES [dbo].[PagoViaticoCorrido]
        ([PK_PagoViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PagoViaticoRetroactivo_PagoViaticoCorrido'
CREATE INDEX [IX_FK_PagoViaticoRetroactivo_PagoViaticoCorrido]
ON [dbo].[PagoViaticoRetroactivo]
    ([FK_PagoViaticoCorrido]);
GO

-- Creating foreign key on [FK_Partida] in table 'SubPartida'
ALTER TABLE [dbo].[SubPartida]
ADD CONSTRAINT [FK_SubPartida_Partida]
    FOREIGN KEY ([FK_Partida])
    REFERENCES [dbo].[Partida]
        ([PK_Partida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubPartida_Partida'
CREATE INDEX [IX_FK_SubPartida_Partida]
ON [dbo].[SubPartida]
    ([FK_Partida]);
GO

-- Creating foreign key on [FK_PeriodoVacaciones] in table 'RegistroVacaciones'
ALTER TABLE [dbo].[RegistroVacaciones]
ADD CONSTRAINT [FK_RegistroVacaciones_PeriodoVacaciones]
    FOREIGN KEY ([FK_PeriodoVacaciones])
    REFERENCES [dbo].[PeriodoVacaciones]
        ([PK_PeriodoVacaciones])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroVacaciones_PeriodoVacaciones'
CREATE INDEX [IX_FK_RegistroVacaciones_PeriodoVacaciones]
ON [dbo].[RegistroVacaciones]
    ([FK_PeriodoVacaciones]);
GO

-- Creating foreign key on [FK_TipoPrestacion] in table 'PrestacionLegal'
ALTER TABLE [dbo].[PrestacionLegal]
ADD CONSTRAINT [FK_PrestacionLegal_TipoPrestacion]
    FOREIGN KEY ([FK_TipoPrestacion])
    REFERENCES [dbo].[TipoPrestacion]
        ([PK_TipoPrestacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestacionLegal_TipoPrestacion'
CREATE INDEX [IX_FK_PrestacionLegal_TipoPrestacion]
ON [dbo].[PrestacionLegal]
    ([FK_TipoPrestacion]);
GO

-- Creating foreign key on [FK_Puesto] in table 'PrestamoPuesto'
ALTER TABLE [dbo].[PrestamoPuesto]
ADD CONSTRAINT [FK_PrestamoPuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestamoPuesto_Puesto'
CREATE INDEX [IX_FK_PrestamoPuesto_Puesto]
ON [dbo].[PrestamoPuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_UbicacionAdministrativa] in table 'PrestamoPuesto'
ALTER TABLE [dbo].[PrestamoPuesto]
ADD CONSTRAINT [FK_PrestamoPuesto_UbicacionAdministrativa]
    FOREIGN KEY ([FK_UbicacionAdministrativa])
    REFERENCES [dbo].[UbicacionAdministrativa]
        ([PK_UbicacionAdministrativa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestamoPuesto_UbicacionAdministrativa'
CREATE INDEX [IX_FK_PrestamoPuesto_UbicacionAdministrativa]
ON [dbo].[PrestamoPuesto]
    ([FK_UbicacionAdministrativa]);
GO

-- Creating foreign key on [FK_PrestamoPuesto] in table 'Rescision'
ALTER TABLE [dbo].[Rescision]
ADD CONSTRAINT [FK_Rescision_PrestamoPuesto]
    FOREIGN KEY ([FK_PrestamoPuesto])
    REFERENCES [dbo].[PrestamoPuesto]
        ([PK_PrestamoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rescision_PrestamoPuesto'
CREATE INDEX [IX_FK_Rescision_PrestamoPuesto]
ON [dbo].[Rescision]
    ([FK_PrestamoPuesto]);
GO

-- Creating foreign key on [FK_Programa] in table 'Presupuesto'
ALTER TABLE [dbo].[Presupuesto]
ADD CONSTRAINT [FK_presupuesto_Programa]
    FOREIGN KEY ([FK_Programa])
    REFERENCES [dbo].[Programa]
        ([PK_Programa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_presupuesto_Programa'
CREATE INDEX [IX_FK_presupuesto_Programa]
ON [dbo].[Presupuesto]
    ([FK_Programa]);
GO

-- Creating foreign key on [FK_Presupuesto] in table 'UbicacionAdministrativa'
ALTER TABLE [dbo].[UbicacionAdministrativa]
ADD CONSTRAINT [FK_Ubicacion_Presupuesto]
    FOREIGN KEY ([FK_Presupuesto])
    REFERENCES [dbo].[Presupuesto]
        ([PK_Presupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ubicacion_Presupuesto'
CREATE INDEX [IX_FK_Ubicacion_Presupuesto]
ON [dbo].[UbicacionAdministrativa]
    ([FK_Presupuesto]);
GO

-- Creating foreign key on [FK_UbicacionAdministrativa] in table 'Puesto'
ALTER TABLE [dbo].[Puesto]
ADD CONSTRAINT [FK_Puesto_UbicacionAdministrativa]
    FOREIGN KEY ([FK_UbicacionAdministrativa])
    REFERENCES [dbo].[UbicacionAdministrativa]
        ([PK_UbicacionAdministrativa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Puesto_UbicacionAdministrativa'
CREATE INDEX [IX_FK_Puesto_UbicacionAdministrativa]
ON [dbo].[Puesto]
    ([FK_UbicacionAdministrativa]);
GO

-- Creating foreign key on [FK_Puesto] in table 'RelPuestoUbicacion'
ALTER TABLE [dbo].[RelPuestoUbicacion]
ADD CONSTRAINT [FK_RelPuestoUbicacion_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RelPuestoUbicacion_Puesto'
CREATE INDEX [IX_FK_RelPuestoUbicacion_Puesto]
ON [dbo].[RelPuestoUbicacion]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_Puesto] in table 'TareasPuesto'
ALTER TABLE [dbo].[TareasPuesto]
ADD CONSTRAINT [FK_TareasPuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareasPuesto_Puesto'
CREATE INDEX [IX_FK_TareasPuesto_Puesto]
ON [dbo].[TareasPuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_TipoIncapacidad] in table 'RegistroIncapacidad'
ALTER TABLE [dbo].[RegistroIncapacidad]
ADD CONSTRAINT [FK_RegistroIncapacidad_TipoIncapacidad]
    FOREIGN KEY ([FK_TipoIncapacidad])
    REFERENCES [dbo].[TipoIncapacidad]
        ([PK_TipoIncapacidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroIncapacidad_TipoIncapacidad'
CREATE INDEX [IX_FK_RegistroIncapacidad_TipoIncapacidad]
ON [dbo].[RegistroIncapacidad]
    ([FK_TipoIncapacidad]);
GO

-- Creating foreign key on [FK_RegistroVacaciones] in table 'ReintegroVacaciones'
ALTER TABLE [dbo].[ReintegroVacaciones]
ADD CONSTRAINT [FK_ReintegroVacaciones_RegistroVacaciones]
    FOREIGN KEY ([FK_RegistroVacaciones])
    REFERENCES [dbo].[RegistroVacaciones]
        ([PK_RegistroVacaciones])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReintegroVacaciones_RegistroVacaciones'
CREATE INDEX [IX_FK_ReintegroVacaciones_RegistroVacaciones]
ON [dbo].[ReintegroVacaciones]
    ([FK_RegistroVacaciones]);
GO

-- Creating foreign key on [FK_UbicacionPuesto] in table 'RelPuestoUbicacion'
ALTER TABLE [dbo].[RelPuestoUbicacion]
ADD CONSTRAINT [FK__RelPuesto__Ubica__1590259A]
    FOREIGN KEY ([FK_UbicacionPuesto])
    REFERENCES [dbo].[UbicacionPuesto]
        ([PK_UbicacionPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RelPuesto__Ubica__1590259A'
CREATE INDEX [IX_FK__RelPuesto__Ubica__1590259A]
ON [dbo].[RelPuestoUbicacion]
    ([FK_UbicacionPuesto]);
GO

-- Creating foreign key on [FK_TipoResolucionPedimento] in table 'ResolucionPedimento'
ALTER TABLE [dbo].[ResolucionPedimento]
ADD CONSTRAINT [FK_Resolucion_TipoResolucion]
    FOREIGN KEY ([FK_TipoResolucionPedimento])
    REFERENCES [dbo].[TipoResolucionPedimento]
        ([PK_TipoResolucionPedimento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Resolucion_TipoResolucion'
CREATE INDEX [IX_FK_Resolucion_TipoResolucion]
ON [dbo].[ResolucionPedimento]
    ([FK_TipoResolucionPedimento]);
GO

-- Creating foreign key on [FK_Seccion] in table 'UbicacionAdministrativa'
ALTER TABLE [dbo].[UbicacionAdministrativa]
ADD CONSTRAINT [FK__Ubicacion__Secci__6F6A7CB2]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubicacion__Secci__6F6A7CB2'
CREATE INDEX [IX_FK__Ubicacion__Secci__6F6A7CB2]
ON [dbo].[UbicacionAdministrativa]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_TipoUbicacion] in table 'UbicacionPuesto'
ALTER TABLE [dbo].[UbicacionPuesto]
ADD CONSTRAINT [FK__Ubicacion__TipoU__770B9E7A]
    FOREIGN KEY ([FK_TipoUbicacion])
    REFERENCES [dbo].[TipoUbicacion]
        ([PK_TipoUbicacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubicacion__TipoU__770B9E7A'
CREATE INDEX [IX_FK__Ubicacion__TipoU__770B9E7A]
ON [dbo].[UbicacionPuesto]
    ([FK_TipoUbicacion]);
GO

-- Creating foreign key on [FK_TipoDia] in table 'CatDiaViaticoGasto'
ALTER TABLE [dbo].[CatDiaViaticoGasto]
ADD CONSTRAINT [FK_CatDiaViaticoGasto_CatDiaViaticoGasto]
    FOREIGN KEY ([FK_TipoDia])
    REFERENCES [dbo].[TipoDia]
        ([PK_TipoDia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatDiaViaticoGasto_CatDiaViaticoGasto'
CREATE INDEX [IX_FK_CatDiaViaticoGasto_CatDiaViaticoGasto]
ON [dbo].[CatDiaViaticoGasto]
    ([FK_TipoDia]);
GO

-- Creating foreign key on [FK_TipoDeduccionTemporal] in table 'DeduccionTemporal'
ALTER TABLE [dbo].[DeduccionTemporal]
ADD CONSTRAINT [FK_DeduccionTemporal_TipoDeduccionTemporal]
    FOREIGN KEY ([FK_TipoDeduccionTemporal])
    REFERENCES [dbo].[TipoDeduccionTemporal]
        ([PK_TipoDeduccionTemporal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeduccionTemporal_TipoDeduccionTemporal'
CREATE INDEX [IX_FK_DeduccionTemporal_TipoDeduccionTemporal]
ON [dbo].[DeduccionTemporal]
    ([FK_TipoDeduccionTemporal]);
GO

-- Creating foreign key on [FK_Usuario] in table 'NotificacionUsuario'
ALTER TABLE [dbo].[NotificacionUsuario]
ADD CONSTRAINT [FK_NotificacionUsuario_Usuario]
    FOREIGN KEY ([FK_Usuario])
    REFERENCES [dbo].[Usuario]
        ([PK_Usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificacionUsuario_Usuario'
CREATE INDEX [IX_FK_NotificacionUsuario_Usuario]
ON [dbo].[NotificacionUsuario]
    ([FK_Usuario]);
GO

-- Creating foreign key on [FK_UsuarioDestino] in table 'NotificacionUsuario'
ALTER TABLE [dbo].[NotificacionUsuario]
ADD CONSTRAINT [FK_NotificacionUsuario_Usuario_Destino]
    FOREIGN KEY ([FK_UsuarioDestino])
    REFERENCES [dbo].[Usuario]
        ([PK_Usuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificacionUsuario_Usuario_Destino'
CREATE INDEX [IX_FK_NotificacionUsuario_Usuario_Destino]
ON [dbo].[NotificacionUsuario]
    ([FK_UsuarioDestino]);
GO

-- Creating foreign key on [FK_PrestacionLegal] in table 'DetallePrestacion'
ALTER TABLE [dbo].[DetallePrestacion]
ADD CONSTRAINT [FK_DetallePrestacion_PrestacionLegal]
    FOREIGN KEY ([FK_PrestacionLegal])
    REFERENCES [dbo].[PrestacionLegal]
        ([PK_PrestacionLegal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePrestacion_PrestacionLegal'
CREATE INDEX [IX_FK_DetallePrestacion_PrestacionLegal]
ON [dbo].[DetallePrestacion]
    ([FK_PrestacionLegal]);
GO

-- Creating foreign key on [FK_ResultadoCargo] in table 'ActividadResultadoCargo'
ALTER TABLE [dbo].[ActividadResultadoCargo]
ADD CONSTRAINT [FK_ActividadResultadoCargo_ResultadoCargo]
    FOREIGN KEY ([FK_ResultadoCargo])
    REFERENCES [dbo].[ResultadoCargo]
        ([PK_ResultadoCargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadResultadoCargo_ResultadoCargo'
CREATE INDEX [IX_FK_ActividadResultadoCargo_ResultadoCargo]
ON [dbo].[ActividadResultadoCargo]
    ([FK_ResultadoCargo]);
GO

-- Creating foreign key on [FK_CompetenciaTransversalCargo] in table 'ComportamientoTransversal'
ALTER TABLE [dbo].[ComportamientoTransversal]
ADD CONSTRAINT [FK_ComportamientoTransversal_CompetenciaTransversalCargo]
    FOREIGN KEY ([FK_CompetenciaTransversalCargo])
    REFERENCES [dbo].[CompetenciaTransversalCargo]
        ([PK_CompetenciaTransversalCargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComportamientoTransversal_CompetenciaTransversalCargo'
CREATE INDEX [IX_FK_ComportamientoTransversal_CompetenciaTransversalCargo]
ON [dbo].[ComportamientoTransversal]
    ([FK_CompetenciaTransversalCargo]);
GO

-- Creating foreign key on [FK_ComportamientoGrupoOcupacional] in table 'EvidenciaGrupoOcupacional'
ALTER TABLE [dbo].[EvidenciaGrupoOcupacional]
ADD CONSTRAINT [FK_EvidenciaGrupoOcupacional_ComportamientoGrupoOcupacional]
    FOREIGN KEY ([FK_ComportamientoGrupoOcupacional])
    REFERENCES [dbo].[ComportamientoGrupoOcupacional]
        ([PK_ComportamientoGrupoOcupacional])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvidenciaGrupoOcupacional_ComportamientoGrupoOcupacional'
CREATE INDEX [IX_FK_EvidenciaGrupoOcupacional_ComportamientoGrupoOcupacional]
ON [dbo].[EvidenciaGrupoOcupacional]
    ([FK_ComportamientoGrupoOcupacional]);
GO

-- Creating foreign key on [FK_ComportamientoTransversal] in table 'EvidenciaComportamientoTransversal'
ALTER TABLE [dbo].[EvidenciaComportamientoTransversal]
ADD CONSTRAINT [FK_EvidenciaComportamientoTransversal_ComportamientoTransversal]
    FOREIGN KEY ([FK_ComportamientoTransversal])
    REFERENCES [dbo].[ComportamientoTransversal]
        ([PK_ComportamientoTransversal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvidenciaComportamientoTransversal_ComportamientoTransversal'
CREATE INDEX [IX_FK_EvidenciaComportamientoTransversal_ComportamientoTransversal]
ON [dbo].[EvidenciaComportamientoTransversal]
    ([FK_ComportamientoTransversal]);
GO

-- Creating foreign key on [FK_Prestacion] in table 'DetallePrestacionAfiliacion'
ALTER TABLE [dbo].[DetallePrestacionAfiliacion]
ADD CONSTRAINT [FK_DetallePrestacionAfiliacion_PrestacionLegal]
    FOREIGN KEY ([FK_Prestacion])
    REFERENCES [dbo].[PrestacionLegal]
        ([PK_PrestacionLegal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePrestacionAfiliacion_PrestacionLegal'
CREATE INDEX [IX_FK_DetallePrestacionAfiliacion_PrestacionLegal]
ON [dbo].[DetallePrestacionAfiliacion]
    ([FK_Prestacion]);
GO

-- Creating foreign key on [FK_Prestacion] in table 'DetallePrestacionCuadro'
ALTER TABLE [dbo].[DetallePrestacionCuadro]
ADD CONSTRAINT [FK_DetallePrestacionCuadro_PrestacionLegal1]
    FOREIGN KEY ([FK_Prestacion])
    REFERENCES [dbo].[PrestacionLegal]
        ([PK_PrestacionLegal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePrestacionCuadro_PrestacionLegal1'
CREATE INDEX [IX_FK_DetallePrestacionCuadro_PrestacionLegal1]
ON [dbo].[DetallePrestacionCuadro]
    ([FK_Prestacion]);
GO

-- Creating foreign key on [FK_Tipo] in table 'DetallePrestacionCuadro'
ALTER TABLE [dbo].[DetallePrestacionCuadro]
ADD CONSTRAINT [FK_DetallePrestacionCuadro_TipoPrestacionCuadro]
    FOREIGN KEY ([FK_Tipo])
    REFERENCES [dbo].[TipoPrestacionCuadro]
        ([PK_TipoCuadro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePrestacionCuadro_TipoPrestacionCuadro'
CREATE INDEX [IX_FK_DetallePrestacionCuadro_TipoPrestacionCuadro]
ON [dbo].[DetallePrestacionCuadro]
    ([FK_Tipo]);
GO

-- Creating foreign key on [FK_CompetenciaGrupoOcupacional] in table 'ComportamientoGrupoOcupacional'
ALTER TABLE [dbo].[ComportamientoGrupoOcupacional]
ADD CONSTRAINT [FK_ComportamientoGrupoOcupacional_CompetenciaGrupoOcupacional]
    FOREIGN KEY ([FK_CompetenciaGrupoOcupacional])
    REFERENCES [dbo].[CompetenciaGrupoOcupacional]
        ([PK_CompetenciaGrupoOcupacional])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComportamientoGrupoOcupacional_CompetenciaGrupoOcupacional'
CREATE INDEX [IX_FK_ComportamientoGrupoOcupacional_CompetenciaGrupoOcupacional]
ON [dbo].[ComportamientoGrupoOcupacional]
    ([FK_CompetenciaGrupoOcupacional]);
GO

-- Creating foreign key on [PK_Departamento] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_Departamento]
    FOREIGN KEY ([PK_Departamento])
    REFERENCES [dbo].[Departamento]
        ([PK_Departamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_Departamento'
CREATE INDEX [IX_FK_ListaNombramientosActivos_Departamento]
ON [dbo].[ListaNombramientosActivos]
    ([PK_Departamento]);
GO

-- Creating foreign key on [PK_DetallePuesto] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_DetallePuesto]
    FOREIGN KEY ([PK_DetallePuesto])
    REFERENCES [dbo].[DetallePuesto]
        ([PK_DetallePuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_DetallePuesto'
CREATE INDEX [IX_FK_ListaNombramientosActivos_DetallePuesto]
ON [dbo].[ListaNombramientosActivos]
    ([PK_DetallePuesto]);
GO

-- Creating foreign key on [PK_Direccion] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_DireccionGeneral]
    FOREIGN KEY ([PK_Direccion])
    REFERENCES [dbo].[DireccionGeneral]
        ([PK_DireccionGeneral])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_DireccionGeneral'
CREATE INDEX [IX_FK_ListaNombramientosActivos_DireccionGeneral]
ON [dbo].[ListaNombramientosActivos]
    ([PK_Direccion]);
GO

-- Creating foreign key on [PK_Division] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_Division]
    FOREIGN KEY ([PK_Division])
    REFERENCES [dbo].[Division]
        ([PK_Division])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_Division'
CREATE INDEX [IX_FK_ListaNombramientosActivos_Division]
ON [dbo].[ListaNombramientosActivos]
    ([PK_Division]);
GO

-- Creating foreign key on [PK_Funcionario] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_Funcionario]
    FOREIGN KEY ([PK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_Funcionario'
CREATE INDEX [IX_FK_ListaNombramientosActivos_Funcionario]
ON [dbo].[ListaNombramientosActivos]
    ([PK_Funcionario]);
GO

-- Creating foreign key on [PK_Nombramiento] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_Nombramiento]
    FOREIGN KEY ([PK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PK_Puesto] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_Puesto]
    FOREIGN KEY ([PK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_Puesto'
CREATE INDEX [IX_FK_ListaNombramientosActivos_Puesto]
ON [dbo].[ListaNombramientosActivos]
    ([PK_Puesto]);
GO

-- Creating foreign key on [PK_Seccion] in table 'ListaNombramientosActivos'
ALTER TABLE [dbo].[ListaNombramientosActivos]
ADD CONSTRAINT [FK_ListaNombramientosActivos_Seccion]
    FOREIGN KEY ([PK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaNombramientosActivos_Seccion'
CREATE INDEX [IX_FK_ListaNombramientosActivos_Seccion]
ON [dbo].[ListaNombramientosActivos]
    ([PK_Seccion]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'CalificacionEncargado'
ALTER TABLE [dbo].[CalificacionEncargado]
ADD CONSTRAINT [FK_CalificacionEncargado_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionEncargado_Funcionario'
CREATE INDEX [IX_FK_CalificacionEncargado_Funcionario]
ON [dbo].[CalificacionEncargado]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Seccion] in table 'CalificacionEncargado'
ALTER TABLE [dbo].[CalificacionEncargado]
ADD CONSTRAINT [FK_CalificacionEncargado_Seccion]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionEncargado_Seccion'
CREATE INDEX [IX_FK_CalificacionEncargado_Seccion]
ON [dbo].[CalificacionEncargado]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_PeriodoCalificacion] in table 'ObjetivoCalificacion'
ALTER TABLE [dbo].[ObjetivoCalificacion]
ADD CONSTRAINT [FK_ObjetivoCalificacion_PeriodoCalificacion]
    FOREIGN KEY ([FK_PeriodoCalificacion])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetivoCalificacion_PeriodoCalificacion'
CREATE INDEX [IX_FK_ObjetivoCalificacion_PeriodoCalificacion]
ON [dbo].[ObjetivoCalificacion]
    ([FK_PeriodoCalificacion]);
GO

-- Creating foreign key on [FK_Seccion] in table 'ObjetivoCalificacion'
ALTER TABLE [dbo].[ObjetivoCalificacion]
ADD CONSTRAINT [FK_ObjetivoCalificacion_Seccion]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjetivoCalificacion_Seccion'
CREATE INDEX [IX_FK_ObjetivoCalificacion_Seccion]
ON [dbo].[ObjetivoCalificacion]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'ActividadFuncionario'
ALTER TABLE [dbo].[ActividadFuncionario]
ADD CONSTRAINT [FK_ActividadFuncionario_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadFuncionario_Funcionario'
CREATE INDEX [IX_FK_ActividadFuncionario_Funcionario]
ON [dbo].[ActividadFuncionario]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Estado] in table 'DetalleDesarraigoEliminacion'
ALTER TABLE [dbo].[DetalleDesarraigoEliminacion]
ADD CONSTRAINT [FK_DetalleDesarraigoEliminacion_EstadoDesarraigo]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[EstadoDesarraigo]
        ([PK_EstadoDesarraigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleDesarraigoEliminacion_EstadoDesarraigo'
CREATE INDEX [IX_FK_DetalleDesarraigoEliminacion_EstadoDesarraigo]
ON [dbo].[DetalleDesarraigoEliminacion]
    ([FK_Estado]);
GO

-- Creating foreign key on [FK_ComponenteSalarial] in table 'DetallePuestoRubro'
ALTER TABLE [dbo].[DetallePuestoRubro]
ADD CONSTRAINT [FK_DetallePuestoRubro_ComponenteSalarial]
    FOREIGN KEY ([FK_ComponenteSalarial])
    REFERENCES [dbo].[ComponenteSalarial]
        ([PK_ComponenteSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePuestoRubro_ComponenteSalarial'
CREATE INDEX [IX_FK_DetallePuestoRubro_ComponenteSalarial]
ON [dbo].[DetallePuestoRubro]
    ([FK_ComponenteSalarial]);
GO

-- Creating foreign key on [FK_Desarraigo] in table 'ContratoArrendamiento'
ALTER TABLE [dbo].[ContratoArrendamiento]
ADD CONSTRAINT [FK_ContratoArrendamiento_Desarraigo]
    FOREIGN KEY ([FK_Desarraigo])
    REFERENCES [dbo].[Desarraigo]
        ([PK_Desarraigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratoArrendamiento_Desarraigo'
CREATE INDEX [IX_FK_ContratoArrendamiento_Desarraigo]
ON [dbo].[ContratoArrendamiento]
    ([FK_Desarraigo]);
GO

-- Creating foreign key on [FK_Departamento] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_Departamento]
    FOREIGN KEY ([FK_Departamento])
    REFERENCES [dbo].[Departamento]
        ([PK_Departamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_Departamento'
CREATE INDEX [IX_FK_Desarraigo_Departamento]
ON [dbo].[Desarraigo]
    ([FK_Departamento]);
GO

-- Creating foreign key on [FK_DistritoContrato] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_DistritoContrato]
    FOREIGN KEY ([FK_DistritoContrato])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_DistritoContrato'
CREATE INDEX [IX_FK_Desarraigo_DistritoContrato]
ON [dbo].[Desarraigo]
    ([FK_DistritoContrato]);
GO

-- Creating foreign key on [FK_DistritoPernocte] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_DistritoPernocte]
    FOREIGN KEY ([FK_DistritoPernocte])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_DistritoPernocte'
CREATE INDEX [IX_FK_Desarraigo_DistritoPernocte]
ON [dbo].[Desarraigo]
    ([FK_DistritoPernocte]);
GO

-- Creating foreign key on [FK_DistritoTrabajo] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_DistritoTrabajo]
    FOREIGN KEY ([FK_DistritoTrabajo])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_DistritoTrabajo'
CREATE INDEX [IX_FK_Desarraigo_DistritoTrabajo]
ON [dbo].[Desarraigo]
    ([FK_DistritoTrabajo]);
GO

-- Creating foreign key on [FK_EstadoDesarraigo] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_EstadoDesarraigo]
    FOREIGN KEY ([FK_EstadoDesarraigo])
    REFERENCES [dbo].[EstadoDesarraigo]
        ([PK_EstadoDesarraigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_EstadoDesarraigo'
CREATE INDEX [IX_FK_Desarraigo_EstadoDesarraigo]
ON [dbo].[Desarraigo]
    ([FK_EstadoDesarraigo]);
GO

-- Creating foreign key on [FK_Presupuesto] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_Presupuesto]
    FOREIGN KEY ([FK_Presupuesto])
    REFERENCES [dbo].[Presupuesto]
        ([PK_Presupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_Presupuesto'
CREATE INDEX [IX_FK_Desarraigo_Presupuesto]
ON [dbo].[Desarraigo]
    ([FK_Presupuesto]);
GO

-- Creating foreign key on [FK_Seccion] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Desarraigo_Seccion]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Desarraigo_Seccion'
CREATE INDEX [IX_FK_Desarraigo_Seccion]
ON [dbo].[Desarraigo]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_Desarraigo] in table 'DetalleDesarraigoEliminacion'
ALTER TABLE [dbo].[DetalleDesarraigoEliminacion]
ADD CONSTRAINT [FK_DetalleDesarraigoEliminacion_Desarraigo]
    FOREIGN KEY ([FK_Desarraigo])
    REFERENCES [dbo].[Desarraigo]
        ([PK_Desarraigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleDesarraigoEliminacion_Desarraigo'
CREATE INDEX [IX_FK_DetalleDesarraigoEliminacion_Desarraigo]
ON [dbo].[DetalleDesarraigoEliminacion]
    ([FK_Desarraigo]);
GO

-- Creating foreign key on [FK_Desarraigo] in table 'FacturaDesarraigo'
ALTER TABLE [dbo].[FacturaDesarraigo]
ADD CONSTRAINT [FK_FacturaDesarraigo_Desarraigo]
    FOREIGN KEY ([FK_Desarraigo])
    REFERENCES [dbo].[Desarraigo]
        ([PK_Desarraigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaDesarraigo_Desarraigo'
CREATE INDEX [IX_FK_FacturaDesarraigo_Desarraigo]
ON [dbo].[FacturaDesarraigo]
    ([FK_Desarraigo]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'Desarraigo'
ALTER TABLE [dbo].[Desarraigo]
ADD CONSTRAINT [FK_Nombramiento_Desarraigo]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Nombramiento_Desarraigo'
CREATE INDEX [IX_FK_Nombramiento_Desarraigo]
ON [dbo].[Desarraigo]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_DetallePuesto] in table 'DetallePuestoRubro'
ALTER TABLE [dbo].[DetallePuestoRubro]
ADD CONSTRAINT [FK_DetallePuestoRubro_DetallePuesto]
    FOREIGN KEY ([FK_DetallePuesto])
    REFERENCES [dbo].[DetallePuesto]
        ([PK_DetallePuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePuestoRubro_DetallePuesto'
CREATE INDEX [IX_FK_DetallePuestoRubro_DetallePuesto]
ON [dbo].[DetallePuestoRubro]
    ([FK_DetallePuesto]);
GO

-- Creating foreign key on [FK_PagoGastoTransporte] in table 'DetallePagoGastoTransporte'
ALTER TABLE [dbo].[DetallePagoGastoTransporte]
ADD CONSTRAINT [FK_DetallePagoGastoTransporte_PagoGastoTransporte]
    FOREIGN KEY ([FK_PagoGastoTransporte])
    REFERENCES [dbo].[PagoGastoTransporte]
        ([PK_PagoGastoTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePagoGastoTransporte_PagoGastoTransporte'
CREATE INDEX [IX_FK_DetallePagoGastoTransporte_PagoGastoTransporte]
ON [dbo].[DetallePagoGastoTransporte]
    ([FK_PagoGastoTransporte]);
GO

-- Creating foreign key on [FK_Estado] in table 'GastoTransporteRutas'
ALTER TABLE [dbo].[GastoTransporteRutas]
ADD CONSTRAINT [FK_GastoTransporteRutas_EstadoGastoTransporte]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[EstadoGastoTransporte]
        ([PK_EstadoGastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTransporteRutas_EstadoGastoTransporte'
CREATE INDEX [IX_FK_GastoTransporteRutas_EstadoGastoTransporte]
ON [dbo].[GastoTransporteRutas]
    ([FK_Estado]);
GO

-- Creating foreign key on [FK_Ruta] in table 'DetalleAsignacionGastoTransporte'
ALTER TABLE [dbo].[DetalleAsignacionGastoTransporte]
ADD CONSTRAINT [FK_DetalleAsignacionGastoTransporte_GastoTransporteRutas]
    FOREIGN KEY ([FK_Ruta])
    REFERENCES [dbo].[GastoTransporteRutas]
        ([PK_Ruta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleAsignacionGastoTransporte_GastoTransporteRutas'
CREATE INDEX [IX_FK_DetalleAsignacionGastoTransporte_GastoTransporteRutas]
ON [dbo].[DetalleAsignacionGastoTransporte]
    ([FK_Ruta]);
GO

-- Creating foreign key on [FK_PedimentoPuesto] in table 'DetalleCambioPedimento'
ALTER TABLE [dbo].[DetalleCambioPedimento]
ADD CONSTRAINT [FK_DetalleCambioPedimento_PedimentoPuesto]
    FOREIGN KEY ([FK_PedimentoPuesto])
    REFERENCES [dbo].[PedimentoPuesto]
        ([PK_PedimentoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCambioPedimento_PedimentoPuesto'
CREATE INDEX [IX_FK_DetalleCambioPedimento_PedimentoPuesto]
ON [dbo].[DetalleCambioPedimento]
    ([FK_PedimentoPuesto]);
GO

-- Creating foreign key on [FK_Motivo] in table 'PedimentoPuesto'
ALTER TABLE [dbo].[PedimentoPuesto]
ADD CONSTRAINT [FK_PedimentoPuesto_MotivoPedimento]
    FOREIGN KEY ([FK_Motivo])
    REFERENCES [dbo].[MotivoPedimento]
        ([PK_MotivoPedimento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedimentoPuesto_MotivoPedimento'
CREATE INDEX [IX_FK_PedimentoPuesto_MotivoPedimento]
ON [dbo].[PedimentoPuesto]
    ([FK_Motivo]);
GO

-- Creating foreign key on [FK_Puesto] in table 'PedimentoPuesto'
ALTER TABLE [dbo].[PedimentoPuesto]
ADD CONSTRAINT [FK_PedimentoPuesto_Puesto]
    FOREIGN KEY ([FK_Puesto])
    REFERENCES [dbo].[Puesto]
        ([PK_Puesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedimentoPuesto_Puesto'
CREATE INDEX [IX_FK_PedimentoPuesto_Puesto]
ON [dbo].[PedimentoPuesto]
    ([FK_Puesto]);
GO

-- Creating foreign key on [FK_PedimentoPuesto] in table 'ResolucionPedimento'
ALTER TABLE [dbo].[ResolucionPedimento]
ADD CONSTRAINT [FK_Resolucion_PedimentoPuesto]
    FOREIGN KEY ([FK_PedimentoPuesto])
    REFERENCES [dbo].[PedimentoPuesto]
        ([PK_PedimentoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Resolucion_PedimentoPuesto'
CREATE INDEX [IX_FK_Resolucion_PedimentoPuesto]
ON [dbo].[ResolucionPedimento]
    ([FK_PedimentoPuesto]);
GO

-- Creating foreign key on [FK_DetallePuesto] in table 'OrdenMovimiento'
ALTER TABLE [dbo].[OrdenMovimiento]
ADD CONSTRAINT [FK_OrdenMovimiento_DetallePuesto]
    FOREIGN KEY ([FK_DetallePuesto])
    REFERENCES [dbo].[DetallePuesto]
        ([PK_DetallePuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenMovimiento_DetallePuesto'
CREATE INDEX [IX_FK_OrdenMovimiento_DetallePuesto]
ON [dbo].[OrdenMovimiento]
    ([FK_DetallePuesto]);
GO

-- Creating foreign key on [FK_Estado] in table 'OrdenMovimiento'
ALTER TABLE [dbo].[OrdenMovimiento]
ADD CONSTRAINT [FK_OrdenMovimiento_EstadoOrdenMovimiento]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[EstadoOrdenMovimiento]
        ([PK_Estado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenMovimiento_EstadoOrdenMovimiento'
CREATE INDEX [IX_FK_OrdenMovimiento_EstadoOrdenMovimiento]
ON [dbo].[OrdenMovimiento]
    ([FK_Estado]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'OrdenMovimiento'
ALTER TABLE [dbo].[OrdenMovimiento]
ADD CONSTRAINT [FK_OrdenMovimiento_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenMovimiento_Funcionario'
CREATE INDEX [IX_FK_OrdenMovimiento_Funcionario]
ON [dbo].[OrdenMovimiento]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_TipoMovimiento] in table 'OrdenMovimiento'
ALTER TABLE [dbo].[OrdenMovimiento]
ADD CONSTRAINT [FK_OrdenMovimiento_TipoMovimiento]
    FOREIGN KEY ([FK_TipoMovimiento])
    REFERENCES [dbo].[MotivoMovimiento]
        ([PK_MotivoMovimiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenMovimiento_TipoMovimiento'
CREATE INDEX [IX_FK_OrdenMovimiento_TipoMovimiento]
ON [dbo].[OrdenMovimiento]
    ([FK_TipoMovimiento]);
GO

-- Creating foreign key on [FK_Pedimento] in table 'OrdenMovimiento'
ALTER TABLE [dbo].[OrdenMovimiento]
ADD CONSTRAINT [FK_OrdenMovimiento_PedimentoPuesto]
    FOREIGN KEY ([FK_Pedimento])
    REFERENCES [dbo].[PedimentoPuesto]
        ([PK_PedimentoPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenMovimiento_PedimentoPuesto'
CREATE INDEX [IX_FK_OrdenMovimiento_PedimentoPuesto]
ON [dbo].[OrdenMovimiento]
    ([FK_Pedimento]);
GO

-- Creating foreign key on [FK_OrdenMovimiento] in table 'OrdenMovimientoDeclaracion'
ALTER TABLE [dbo].[OrdenMovimientoDeclaracion]
ADD CONSTRAINT [FK_OrdenMovimientoDeclaracion_OrdenMovimiento]
    FOREIGN KEY ([FK_OrdenMovimiento])
    REFERENCES [dbo].[OrdenMovimiento]
        ([PK_OrdenMovimiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenMovimientoDeclaracion_OrdenMovimiento'
CREATE INDEX [IX_FK_OrdenMovimientoDeclaracion_OrdenMovimiento]
ON [dbo].[OrdenMovimientoDeclaracion]
    ([FK_OrdenMovimiento]);
GO

-- Creating foreign key on [AnioRige] in table 'AccionPersonal'
ALTER TABLE [dbo].[AccionPersonal]
ADD CONSTRAINT [FK_AccionPersonal_CatAnioAccionPersonal]
    FOREIGN KEY ([AnioRige])
    REFERENCES [dbo].[CatAnioAccionPersonal]
        ([AnioRige])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccionPersonal_CatAnioAccionPersonal'
CREATE INDEX [IX_FK_AccionPersonal_CatAnioAccionPersonal]
ON [dbo].[AccionPersonal]
    ([AnioRige]);
GO

-- Creating foreign key on [FK_Estado] in table 'AccionPersonal'
ALTER TABLE [dbo].[AccionPersonal]
ADD CONSTRAINT [FK_AccionPersonal_EstadoBorrador]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[EstadoBorrador]
        ([PK_EstadoBorrador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccionPersonal_EstadoBorrador'
CREATE INDEX [IX_FK_AccionPersonal_EstadoBorrador]
ON [dbo].[AccionPersonal]
    ([FK_Estado]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'AccionPersonal'
ALTER TABLE [dbo].[AccionPersonal]
ADD CONSTRAINT [FK_AccionPersonal_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccionPersonal_Nombramiento'
CREATE INDEX [IX_FK_AccionPersonal_Nombramiento]
ON [dbo].[AccionPersonal]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_TipoAccionPersonal] in table 'AccionPersonal'
ALTER TABLE [dbo].[AccionPersonal]
ADD CONSTRAINT [FK_AccionPersonal_TipoAccionPersonal]
    FOREIGN KEY ([FK_TipoAccionPersonal])
    REFERENCES [dbo].[TipoAccionPersonal]
        ([PK_TipoAccionPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccionPersonal_TipoAccionPersonal'
CREATE INDEX [IX_FK_AccionPersonal_TipoAccionPersonal]
ON [dbo].[AccionPersonal]
    ([FK_TipoAccionPersonal]);
GO

-- Creating foreign key on [FK_AccionPersonal] in table 'CambioPorAccionPersonal'
ALTER TABLE [dbo].[CambioPorAccionPersonal]
ADD CONSTRAINT [FK_CambioPorAccionPersonal_AccionPersonal]
    FOREIGN KEY ([FK_AccionPersonal])
    REFERENCES [dbo].[AccionPersonal]
        ([PK_AccionPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CambioPorAccionPersonal_AccionPersonal'
CREATE INDEX [IX_FK_CambioPorAccionPersonal_AccionPersonal]
ON [dbo].[CambioPorAccionPersonal]
    ([FK_AccionPersonal]);
GO

-- Creating foreign key on [FK_AccionPersonal] in table 'DetalleAccionPersonal'
ALTER TABLE [dbo].[DetalleAccionPersonal]
ADD CONSTRAINT [FK_DetalleAccionPersonal_AccionPersonal]
    FOREIGN KEY ([FK_AccionPersonal])
    REFERENCES [dbo].[AccionPersonal]
        ([PK_AccionPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleAccionPersonal_AccionPersonal'
CREATE INDEX [IX_FK_DetalleAccionPersonal_AccionPersonal]
ON [dbo].[DetalleAccionPersonal]
    ([FK_AccionPersonal]);
GO

-- Creating foreign key on [FK_AccionPersonal] in table 'DetalleAccionPersonalAnterior'
ALTER TABLE [dbo].[DetalleAccionPersonalAnterior]
ADD CONSTRAINT [FK_DetalleAccionPersonalAnterior_AccionPersonal]
    FOREIGN KEY ([FK_AccionPersonal])
    REFERENCES [dbo].[AccionPersonal]
        ([PK_AccionPersonal])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleAccionPersonalAnterior_AccionPersonal'
CREATE INDEX [IX_FK_DetalleAccionPersonalAnterior_AccionPersonal]
ON [dbo].[DetalleAccionPersonalAnterior]
    ([FK_AccionPersonal]);
GO

-- Creating foreign key on [FK_Estado] in table 'DetalleCalificacionSeguimiento'
ALTER TABLE [dbo].[DetalleCalificacionSeguimiento]
ADD CONSTRAINT [FK_DetalleCalificacionSeguimiento_CatMetaEstado]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[CatMetaEstado]
        ([PK_Estado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionSeguimiento_CatMetaEstado'
CREATE INDEX [IX_FK_DetalleCalificacionSeguimiento_CatMetaEstado]
ON [dbo].[DetalleCalificacionSeguimiento]
    ([FK_Estado]);
GO

-- Creating foreign key on [IdJefatura] in table 'DetalleCalificacionSeguimiento'
ALTER TABLE [dbo].[DetalleCalificacionSeguimiento]
ADD CONSTRAINT [FK_DetalleCalificacionSeguimiento_Funcionario]
    FOREIGN KEY ([IdJefatura])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionSeguimiento_Funcionario'
CREATE INDEX [IX_FK_DetalleCalificacionSeguimiento_Funcionario]
ON [dbo].[DetalleCalificacionSeguimiento]
    ([IdJefatura]);
GO

-- Creating foreign key on [FK_FamiliaPuesto] in table 'Puesto'
ALTER TABLE [dbo].[Puesto]
ADD CONSTRAINT [FK_Puesto_Puesto]
    FOREIGN KEY ([FK_FamiliaPuesto])
    REFERENCES [dbo].[FamiliaPuestos]
        ([PK_Familia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Puesto_Puesto'
CREATE INDEX [IX_FK_Puesto_Puesto]
ON [dbo].[Puesto]
    ([FK_FamiliaPuesto]);
GO

-- Creating foreign key on [FK_CalificacionFuncionario] in table 'CalificacionCapacitacion'
ALTER TABLE [dbo].[CalificacionCapacitacion]
ADD CONSTRAINT [FK_CalificacionCapacitacion_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionFuncionario])
    REFERENCES [dbo].[CalificacionNombramientoFuncionarios]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCapacitacion_CalificacionNombramiento'
CREATE INDEX [IX_FK_CalificacionCapacitacion_CalificacionNombramiento]
ON [dbo].[CalificacionCapacitacion]
    ([FK_CalificacionFuncionario]);
GO

-- Creating foreign key on [FK_TipoPP] in table 'CalificacionCapacitacion'
ALTER TABLE [dbo].[CalificacionCapacitacion]
ADD CONSTRAINT [FK_CalificacionCapacitacion_TipoPoliticaPublica]
    FOREIGN KEY ([FK_TipoPP])
    REFERENCES [dbo].[TipoPoliticaPublica]
        ([PK_TipoPP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCapacitacion_TipoPoliticaPublica'
CREATE INDEX [IX_FK_CalificacionCapacitacion_TipoPoliticaPublica]
ON [dbo].[CalificacionCapacitacion]
    ([FK_TipoPP]);
GO

-- Creating foreign key on [FK_PeriodoCalificacion] in table 'CalificacionNombramientoFuncionarios'
ALTER TABLE [dbo].[CalificacionNombramientoFuncionarios]
ADD CONSTRAINT [FK_CalificacionNombramientoFuncionarios_PeriodoCalificacion]
    FOREIGN KEY ([FK_PeriodoCalificacion])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionNombramientoFuncionarios_PeriodoCalificacion'
CREATE INDEX [IX_FK_CalificacionNombramientoFuncionarios_PeriodoCalificacion]
ON [dbo].[CalificacionNombramientoFuncionarios]
    ([FK_PeriodoCalificacion]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'CalificacionObservaciones'
ALTER TABLE [dbo].[CalificacionObservaciones]
ADD CONSTRAINT [FK_CalificacionObservaciones_CalificacionNombramientoFuncionarios]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramientoFuncionarios]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionObservaciones_CalificacionNombramientoFuncionarios'
CREATE INDEX [IX_FK_CalificacionObservaciones_CalificacionNombramientoFuncionarios]
ON [dbo].[CalificacionObservaciones]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramientoFuncionario] in table 'DetalleCalificacionSeguimiento'
ALTER TABLE [dbo].[DetalleCalificacionSeguimiento]
ADD CONSTRAINT [FK_DetalleCalificacionSeguimiento_CalificacionNombramientoFuncionarios]
    FOREIGN KEY ([FK_CalificacionNombramientoFuncionario])
    REFERENCES [dbo].[CalificacionNombramientoFuncionarios]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionSeguimiento_CalificacionNombramientoFuncionarios'
CREATE INDEX [IX_FK_DetalleCalificacionSeguimiento_CalificacionNombramientoFuncionarios]
ON [dbo].[DetalleCalificacionSeguimiento]
    ([FK_CalificacionNombramientoFuncionario]);
GO

-- Creating foreign key on [FK_Cargo] in table 'CompetenciaGrupoOcupacional'
ALTER TABLE [dbo].[CompetenciaGrupoOcupacional]
ADD CONSTRAINT [FK_CompetenciaGrupoOcupacional_Cargo]
    FOREIGN KEY ([FK_Cargo])
    REFERENCES [dbo].[Cargo]
        ([PK_Cargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenciaGrupoOcupacional_Cargo'
CREATE INDEX [IX_FK_CompetenciaGrupoOcupacional_Cargo]
ON [dbo].[CompetenciaGrupoOcupacional]
    ([FK_Cargo]);
GO

-- Creating foreign key on [FK_Cargo] in table 'CompetenciaTransversalCargo'
ALTER TABLE [dbo].[CompetenciaTransversalCargo]
ADD CONSTRAINT [FK_CompetenciaTransversalCargo_Cargo]
    FOREIGN KEY ([FK_Cargo])
    REFERENCES [dbo].[Cargo]
        ([PK_Cargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetenciaTransversalCargo_Cargo'
CREATE INDEX [IX_FK_CompetenciaTransversalCargo_Cargo]
ON [dbo].[CompetenciaTransversalCargo]
    ([FK_Cargo]);
GO

-- Creating foreign key on [FK_Cargo] in table 'FactorClasificacionCargo'
ALTER TABLE [dbo].[FactorClasificacionCargo]
ADD CONSTRAINT [FK_FactorClasificacionCargo_Cargo]
    FOREIGN KEY ([FK_Cargo])
    REFERENCES [dbo].[Cargo]
        ([PK_Cargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactorClasificacionCargo_Cargo'
CREATE INDEX [IX_FK_FactorClasificacionCargo_Cargo]
ON [dbo].[FactorClasificacionCargo]
    ([FK_Cargo]);
GO

-- Creating foreign key on [FK_Cargo] in table 'RequerimientoEspecificoCargo'
ALTER TABLE [dbo].[RequerimientoEspecificoCargo]
ADD CONSTRAINT [FK_RequerimientoEspecificoCargo_Cargo]
    FOREIGN KEY ([FK_Cargo])
    REFERENCES [dbo].[Cargo]
        ([PK_Cargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequerimientoEspecificoCargo_Cargo'
CREATE INDEX [IX_FK_RequerimientoEspecificoCargo_Cargo]
ON [dbo].[RequerimientoEspecificoCargo]
    ([FK_Cargo]);
GO

-- Creating foreign key on [FK_Cargo] in table 'ResultadoCargo'
ALTER TABLE [dbo].[ResultadoCargo]
ADD CONSTRAINT [FK_ResultadoCargo_Cargo]
    FOREIGN KEY ([FK_Cargo])
    REFERENCES [dbo].[Cargo]
        ([PK_Cargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResultadoCargo_Cargo'
CREATE INDEX [IX_FK_ResultadoCargo_Cargo]
ON [dbo].[ResultadoCargo]
    ([FK_Cargo]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'CatPermisoEvidencia'
ALTER TABLE [dbo].[CatPermisoEvidencia]
ADD CONSTRAINT [FK_CatPermisoEvidencia_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatPermisoEvidencia_Funcionario'
CREATE INDEX [IX_FK_CatPermisoEvidencia_Funcionario]
ON [dbo].[CatPermisoEvidencia]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_ObjetivoCalificacion] in table 'MetaObjetivoCalificacion'
ALTER TABLE [dbo].[MetaObjetivoCalificacion]
ADD CONSTRAINT [FK_MetaObjetivoCalificacion_ObjetivoCalificacion]
    FOREIGN KEY ([FK_ObjetivoCalificacion])
    REFERENCES [dbo].[ObjetivoCalificacion]
        ([PK_ObjetivoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaObjetivoCalificacion_ObjetivoCalificacion'
CREATE INDEX [IX_FK_MetaObjetivoCalificacion_ObjetivoCalificacion]
ON [dbo].[MetaObjetivoCalificacion]
    ([FK_ObjetivoCalificacion]);
GO

-- Creating foreign key on [FK_EntidadEducativa] in table 'CursoCapacitacion'
ALTER TABLE [dbo].[CursoCapacitacion]
ADD CONSTRAINT [FK_CursoCapacitacion_EntidadEducativa]
    FOREIGN KEY ([FK_EntidadEducativa])
    REFERENCES [dbo].[EntidadEducativa]
        ([PK_EntidadEducativa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoCapacitacion_EntidadEducativa'
CREATE INDEX [IX_FK_CursoCapacitacion_EntidadEducativa]
ON [dbo].[CursoCapacitacion]
    ([FK_EntidadEducativa]);
GO

-- Creating foreign key on [FK_FormacionAcademica] in table 'CursoCapacitacion'
ALTER TABLE [dbo].[CursoCapacitacion]
ADD CONSTRAINT [FK_CursoCapacitacion_FormacionAcademica]
    FOREIGN KEY ([FK_FormacionAcademica])
    REFERENCES [dbo].[FormacionAcademica]
        ([PK_FormacionAcademica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoCapacitacion_FormacionAcademica'
CREATE INDEX [IX_FK_CursoCapacitacion_FormacionAcademica]
ON [dbo].[CursoCapacitacion]
    ([FK_FormacionAcademica]);
GO

-- Creating foreign key on [FK_Modalidad] in table 'CursoCapacitacion'
ALTER TABLE [dbo].[CursoCapacitacion]
ADD CONSTRAINT [FK_CursoCapacitacion_Modalidad]
    FOREIGN KEY ([FK_Modalidad])
    REFERENCES [dbo].[Modalidad]
        ([PK_Modalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoCapacitacion_Modalidad'
CREATE INDEX [IX_FK_CursoCapacitacion_Modalidad]
ON [dbo].[CursoCapacitacion]
    ([FK_Modalidad]);
GO

-- Creating foreign key on [FK_EntidadEducativa] in table 'CursoGrado'
ALTER TABLE [dbo].[CursoGrado]
ADD CONSTRAINT [FK_CursoGrado_EntidadEducativa]
    FOREIGN KEY ([FK_EntidadEducativa])
    REFERENCES [dbo].[EntidadEducativa]
        ([PK_EntidadEducativa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CursoGrado_EntidadEducativa'
CREATE INDEX [IX_FK_CursoGrado_EntidadEducativa]
ON [dbo].[CursoGrado]
    ([FK_EntidadEducativa]);
GO

-- Creating foreign key on [FK_FormacionAcademica] in table 'DetallePuntosAdicional'
ALTER TABLE [dbo].[DetallePuntosAdicional]
ADD CONSTRAINT [FK__DetallePu__FK_Fo__2EA782D5]
    FOREIGN KEY ([FK_FormacionAcademica])
    REFERENCES [dbo].[FormacionAcademica]
        ([PK_FormacionAcademica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DetallePu__FK_Fo__2EA782D5'
CREATE INDEX [IX_FK__DetallePu__FK_Fo__2EA782D5]
ON [dbo].[DetallePuntosAdicional]
    ([FK_FormacionAcademica]);
GO

-- Creating foreign key on [FK_ViaticoCorrido] in table 'ContratoArrendamiento'
ALTER TABLE [dbo].[ContratoArrendamiento]
ADD CONSTRAINT [FK_ViaticoCorrido_ViaticoCorrido]
    FOREIGN KEY ([FK_ViaticoCorrido])
    REFERENCES [dbo].[ViaticoCorrido]
        ([PK_ViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_ViaticoCorrido'
CREATE INDEX [IX_FK_ViaticoCorrido_ViaticoCorrido]
ON [dbo].[ContratoArrendamiento]
    ([FK_ViaticoCorrido]);
GO

-- Creating foreign key on [FK_DistritoContrato] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [FK_ViaticoCorrido_Contrato]
    FOREIGN KEY ([FK_DistritoContrato])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_Contrato'
CREATE INDEX [IX_FK_ViaticoCorrido_Contrato]
ON [dbo].[ViaticoCorrido]
    ([FK_DistritoContrato]);
GO

-- Creating foreign key on [FK_Distrito] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [FK_ViaticoCorrido_Ditrito]
    FOREIGN KEY ([FK_Distrito])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_Ditrito'
CREATE INDEX [IX_FK_ViaticoCorrido_Ditrito]
ON [dbo].[ViaticoCorrido]
    ([FK_Distrito]);
GO

-- Creating foreign key on [FK_DistritoTrabajo] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [FK_ViaticoCorrido_Trabajo]
    FOREIGN KEY ([FK_DistritoTrabajo])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_Trabajo'
CREATE INDEX [IX_FK_ViaticoCorrido_Trabajo]
ON [dbo].[ViaticoCorrido]
    ([FK_DistritoTrabajo]);
GO

-- Creating foreign key on [FK_EstadoViaticoCorrido] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [FK_ViaticoCorrido_EstadoViaticoCorrido]
    FOREIGN KEY ([FK_EstadoViaticoCorrido])
    REFERENCES [dbo].[EstadoViaticoCorrido]
        ([PK_EstadoViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_EstadoViaticoCorrido'
CREATE INDEX [IX_FK_ViaticoCorrido_EstadoViaticoCorrido]
ON [dbo].[ViaticoCorrido]
    ([FK_EstadoViaticoCorrido]);
GO

-- Creating foreign key on [FK_ViaticoCorrido] in table 'FacturaDesarraigo'
ALTER TABLE [dbo].[FacturaDesarraigo]
ADD CONSTRAINT [FK_FacturaDesarraigoV_Viatico]
    FOREIGN KEY ([FK_ViaticoCorrido])
    REFERENCES [dbo].[ViaticoCorrido]
        ([PK_ViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaDesarraigoV_Viatico'
CREATE INDEX [IX_FK_FacturaDesarraigoV_Viatico]
ON [dbo].[FacturaDesarraigo]
    ([FK_ViaticoCorrido]);
GO

-- Creating foreign key on [FK_ViaticoCorrido] in table 'MovimientoViaticoCorrido'
ALTER TABLE [dbo].[MovimientoViaticoCorrido]
ADD CONSTRAINT [FK_MovimientosViaticoCorrido_ViaticoCorrido]
    FOREIGN KEY ([FK_ViaticoCorrido])
    REFERENCES [dbo].[ViaticoCorrido]
        ([PK_ViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimientosViaticoCorrido_ViaticoCorrido'
CREATE INDEX [IX_FK_MovimientosViaticoCorrido_ViaticoCorrido]
ON [dbo].[MovimientoViaticoCorrido]
    ([FK_ViaticoCorrido]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [FK_ViaticoCorrido_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_Nombramiento'
CREATE INDEX [IX_FK_ViaticoCorrido_Nombramiento]
ON [dbo].[ViaticoCorrido]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_ViaticoCorrido] in table 'PagoViaticoCorrido'
ALTER TABLE [dbo].[PagoViaticoCorrido]
ADD CONSTRAINT [FK_PagoViaticoCorrido_ViaticoCorrido]
    FOREIGN KEY ([FK_ViaticoCorrido])
    REFERENCES [dbo].[ViaticoCorrido]
        ([PK_ViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PagoViaticoCorrido_ViaticoCorrido'
CREATE INDEX [IX_FK_PagoViaticoCorrido_ViaticoCorrido]
ON [dbo].[PagoViaticoCorrido]
    ([FK_ViaticoCorrido]);
GO

-- Creating foreign key on [FK_Presupuesto] in table 'ViaticoCorrido'
ALTER TABLE [dbo].[ViaticoCorrido]
ADD CONSTRAINT [FK_ViaticoCorrido_Presupuesto]
    FOREIGN KEY ([FK_Presupuesto])
    REFERENCES [dbo].[Presupuesto]
        ([PK_Presupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorrido_Presupuesto'
CREATE INDEX [IX_FK_ViaticoCorrido_Presupuesto]
ON [dbo].[ViaticoCorrido]
    ([FK_Presupuesto]);
GO

-- Creating foreign key on [FK_ViaticoCorrido] in table 'ViaticoCorridoReintegroDias'
ALTER TABLE [dbo].[ViaticoCorridoReintegroDias]
ADD CONSTRAINT [FK_ViaticoCorridoReintegroDias_ViaticoCorrido]
    FOREIGN KEY ([FK_ViaticoCorrido])
    REFERENCES [dbo].[ViaticoCorrido]
        ([PK_ViaticoCorrido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ViaticoCorridoReintegroDias_ViaticoCorrido'
CREATE INDEX [IX_FK_ViaticoCorridoReintegroDias_ViaticoCorrido]
ON [dbo].[ViaticoCorridoReintegroDias]
    ([FK_ViaticoCorrido]);
GO

-- Creating foreign key on [FK_GastoTransporte] in table 'DetalleAsignacionGastoTransporteModificada'
ALTER TABLE [dbo].[DetalleAsignacionGastoTransporteModificada]
ADD CONSTRAINT [FK_DetalleAsignacionGastoTransporteModificada_GastoTransporte]
    FOREIGN KEY ([FK_GastoTransporte])
    REFERENCES [dbo].[GastoTransporte]
        ([PK_GastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleAsignacionGastoTransporteModificada_GastoTransporte'
CREATE INDEX [IX_FK_DetalleAsignacionGastoTransporteModificada_GastoTransporte]
ON [dbo].[DetalleAsignacionGastoTransporteModificada]
    ([FK_GastoTransporte]);
GO

-- Creating foreign key on [FK_DistritoContrato] in table 'GastoTransporte'
ALTER TABLE [dbo].[GastoTransporte]
ADD CONSTRAINT [FK_GastoTransporte_DistritoC]
    FOREIGN KEY ([FK_DistritoContrato])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTransporte_DistritoC'
CREATE INDEX [IX_FK_GastoTransporte_DistritoC]
ON [dbo].[GastoTransporte]
    ([FK_DistritoContrato]);
GO

-- Creating foreign key on [FK_DistritoTrabajo] in table 'GastoTransporte'
ALTER TABLE [dbo].[GastoTransporte]
ADD CONSTRAINT [FK_GastoTransporte_DistritoT]
    FOREIGN KEY ([FK_DistritoTrabajo])
    REFERENCES [dbo].[Distrito]
        ([PK_Distrito])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTransporte_DistritoT'
CREATE INDEX [IX_FK_GastoTransporte_DistritoT]
ON [dbo].[GastoTransporte]
    ([FK_DistritoTrabajo]);
GO

-- Creating foreign key on [FK_EstadoGastosTransporte] in table 'GastoTransporte'
ALTER TABLE [dbo].[GastoTransporte]
ADD CONSTRAINT [FK_GastosTransporteo_EstadosGastosTransporte]
    FOREIGN KEY ([FK_EstadoGastosTransporte])
    REFERENCES [dbo].[EstadoGastoTransporte]
        ([PK_EstadoGastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastosTransporteo_EstadosGastosTransporte'
CREATE INDEX [IX_FK_GastosTransporteo_EstadosGastosTransporte]
ON [dbo].[GastoTransporte]
    ([FK_EstadoGastosTransporte]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'GastoTransporte'
ALTER TABLE [dbo].[GastoTransporte]
ADD CONSTRAINT [FK_GastosTransporte_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastosTransporte_Nombramiento'
CREATE INDEX [IX_FK_GastosTransporte_Nombramiento]
ON [dbo].[GastoTransporte]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_Presupuesto] in table 'GastoTransporte'
ALTER TABLE [dbo].[GastoTransporte]
ADD CONSTRAINT [FK_GastoTransporte_Presupuesto]
    FOREIGN KEY ([FK_Presupuesto])
    REFERENCES [dbo].[Presupuesto]
        ([PK_Presupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTransporte_Presupuesto'
CREATE INDEX [IX_FK_GastoTransporte_Presupuesto]
ON [dbo].[GastoTransporte]
    ([FK_Presupuesto]);
GO

-- Creating foreign key on [FK_GastoTransporte] in table 'GastoTransporteReintegroDias'
ALTER TABLE [dbo].[GastoTransporteReintegroDias]
ADD CONSTRAINT [FK_GastoTransporteReintegroDias_GastoTransporte]
    FOREIGN KEY ([FK_GastoTransporte])
    REFERENCES [dbo].[GastoTransporte]
        ([PK_GastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTransporteReintegroDias_GastoTransporte'
CREATE INDEX [IX_FK_GastoTransporteReintegroDias_GastoTransporte]
ON [dbo].[GastoTransporteReintegroDias]
    ([FK_GastoTransporte]);
GO

-- Creating foreign key on [FK_GastoTransporte] in table 'GastoTransporteRutas'
ALTER TABLE [dbo].[GastoTransporteRutas]
ADD CONSTRAINT [FK_GastoTransporteRutas_GastoTransporte]
    FOREIGN KEY ([FK_GastoTransporte])
    REFERENCES [dbo].[GastoTransporte]
        ([PK_GastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTransporteRutas_GastoTransporte'
CREATE INDEX [IX_FK_GastoTransporteRutas_GastoTransporte]
ON [dbo].[GastoTransporteRutas]
    ([FK_GastoTransporte]);
GO

-- Creating foreign key on [FK_GastosTransporte] in table 'MovimientoGastoTransporte'
ALTER TABLE [dbo].[MovimientoGastoTransporte]
ADD CONSTRAINT [FK_MovimientoGastosTransporte_GastosTransporte]
    FOREIGN KEY ([FK_GastosTransporte])
    REFERENCES [dbo].[GastoTransporte]
        ([PK_GastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovimientoGastosTransporte_GastosTransporte'
CREATE INDEX [IX_FK_MovimientoGastosTransporte_GastosTransporte]
ON [dbo].[MovimientoGastoTransporte]
    ([FK_GastosTransporte]);
GO

-- Creating foreign key on [FK_GastosTransporte] in table 'PagoGastoTransporte'
ALTER TABLE [dbo].[PagoGastoTransporte]
ADD CONSTRAINT [FK_PagoGastosTransporte_GastoTransporte]
    FOREIGN KEY ([FK_GastosTransporte])
    REFERENCES [dbo].[GastoTransporte]
        ([PK_GastosTransporte])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PagoGastosTransporte_GastoTransporte'
CREATE INDEX [IX_FK_PagoGastosTransporte_GastoTransporte]
ON [dbo].[PagoGastoTransporte]
    ([FK_GastosTransporte]);
GO

-- Creating foreign key on [FK_Cargo] in table 'EstadoCargo'
ALTER TABLE [dbo].[EstadoCargo]
ADD CONSTRAINT [FK_EstadoCargo_Cargo]
    FOREIGN KEY ([FK_Cargo])
    REFERENCES [dbo].[Cargo]
        ([PK_Cargo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoCargo_Cargo'
CREATE INDEX [IX_FK_EstadoCargo_Cargo]
ON [dbo].[EstadoCargo]
    ([FK_Cargo]);
GO

-- Creating foreign key on [FK_Estado] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_CatMetaEstado]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[CatMetaEstado]
        ([PK_Estado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_CatMetaEstado'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_CatMetaEstado]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_Estado]);
GO

-- Creating foreign key on [FK_Nivel] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_CatMetaNivel]
    FOREIGN KEY ([FK_Nivel])
    REFERENCES [dbo].[CatMetaNivel]
        ([PK_Nivel])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_CatMetaNivel'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_CatMetaNivel]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_Nivel]);
GO

-- Creating foreign key on [FK_Prioridad] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_CatMetaPrioridad]
    FOREIGN KEY ([FK_Prioridad])
    REFERENCES [dbo].[CatMetaPrioridad]
        ([PK_Prioridad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_CatMetaPrioridad'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_CatMetaPrioridad]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_Prioridad]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_Funcionario'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_Funcionario]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [PK_Meta] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_MetaIndividualCalificacion]
    FOREIGN KEY ([PK_Meta])
    REFERENCES [dbo].[MetaIndividualCalificacion]
        ([PK_Meta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FK_MetaObjetivo] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_MetaObjetivoCalificacion]
    FOREIGN KEY ([FK_MetaObjetivo])
    REFERENCES [dbo].[MetaObjetivoCalificacion]
        ([PK_Meta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_MetaObjetivoCalificacion'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_MetaObjetivoCalificacion]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_MetaObjetivo]);
GO

-- Creating foreign key on [FK_PeriodoCalificacion] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_PeriodoCalificacion]
    FOREIGN KEY ([FK_PeriodoCalificacion])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_PeriodoCalificacion'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_PeriodoCalificacion]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_PeriodoCalificacion]);
GO

-- Creating foreign key on [FK_TipoIndicador] in table 'MetaIndividualCalificacion'
ALTER TABLE [dbo].[MetaIndividualCalificacion]
ADD CONSTRAINT [FK_MetaIndividualCalificacion_TipoIndicadorMeta]
    FOREIGN KEY ([FK_TipoIndicador])
    REFERENCES [dbo].[TipoIndicadorMeta]
        ([PK_TipoIndicador])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualCalificacion_TipoIndicadorMeta'
CREATE INDEX [IX_FK_MetaIndividualCalificacion_TipoIndicadorMeta]
ON [dbo].[MetaIndividualCalificacion]
    ([FK_TipoIndicador]);
GO

-- Creating foreign key on [FK_Meta] in table 'MetaIndividualEvidencia'
ALTER TABLE [dbo].[MetaIndividualEvidencia]
ADD CONSTRAINT [FK_MetaIndividualEvidencia_MetaIndividualCalificacion]
    FOREIGN KEY ([FK_Meta])
    REFERENCES [dbo].[MetaIndividualCalificacion]
        ([PK_Meta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualEvidencia_MetaIndividualCalificacion'
CREATE INDEX [IX_FK_MetaIndividualEvidencia_MetaIndividualCalificacion]
ON [dbo].[MetaIndividualEvidencia]
    ([FK_Meta]);
GO

-- Creating foreign key on [FK_Meta] in table 'MetaIndividualInforme'
ALTER TABLE [dbo].[MetaIndividualInforme]
ADD CONSTRAINT [FK_MetaIndividualInforme_MetaIndividualCalificacion]
    FOREIGN KEY ([FK_Meta])
    REFERENCES [dbo].[MetaIndividualCalificacion]
        ([PK_Meta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaIndividualInforme_MetaIndividualCalificacion'
CREATE INDEX [IX_FK_MetaIndividualInforme_MetaIndividualCalificacion]
ON [dbo].[MetaIndividualInforme]
    ([FK_Meta]);
GO

-- Creating foreign key on [FK_Calificacion] in table 'CalificacionNombramiento'
ALTER TABLE [dbo].[CalificacionNombramiento]
ADD CONSTRAINT [FK_CalificacionNombramiento_Calificacion]
    FOREIGN KEY ([FK_Calificacion])
    REFERENCES [dbo].[Calificacion]
        ([PK_Calificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionNombramiento_Calificacion'
CREATE INDEX [IX_FK_CalificacionNombramiento_Calificacion]
ON [dbo].[CalificacionNombramiento]
    ([FK_Calificacion]);
GO

-- Creating foreign key on [FK_PeriodoCalificacion] in table 'CalificacionNombramiento'
ALTER TABLE [dbo].[CalificacionNombramiento]
ADD CONSTRAINT [FK_CalificacionNombramiento_CatCalificacion]
    FOREIGN KEY ([FK_PeriodoCalificacion])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionNombramiento_CatCalificacion'
CREATE INDEX [IX_FK_CalificacionNombramiento_CatCalificacion]
ON [dbo].[CalificacionNombramiento]
    ([FK_PeriodoCalificacion]);
GO

-- Creating foreign key on [FK_Nombramiento] in table 'CalificacionNombramiento'
ALTER TABLE [dbo].[CalificacionNombramiento]
ADD CONSTRAINT [FK_CalificacionNombramiento_Nombramiento]
    FOREIGN KEY ([FK_Nombramiento])
    REFERENCES [dbo].[Nombramiento]
        ([PK_Nombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionNombramiento_Nombramiento'
CREATE INDEX [IX_FK_CalificacionNombramiento_Nombramiento]
ON [dbo].[CalificacionNombramiento]
    ([FK_Nombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacionAutoEvaluacion'
ALTER TABLE [dbo].[DetalleCalificacionAutoEvaluacion]
ADD CONSTRAINT [FK_DetalleCalificacionAutoEvaluacion_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionAutoEvaluacion_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleCalificacionAutoEvaluacion_CalificacionNombramiento]
ON [dbo].[DetalleCalificacionAutoEvaluacion]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacionCompetencia'
ALTER TABLE [dbo].[DetalleCalificacionCompetencia]
ADD CONSTRAINT [FK_DetalleCalificacionCompetencia_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionCompetencia_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleCalificacionCompetencia_CalificacionNombramiento]
ON [dbo].[DetalleCalificacionCompetencia]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacionJefeColaborador'
ALTER TABLE [dbo].[DetalleCalificacionJefeColaborador]
ADD CONSTRAINT [FK_DetalleCalificacionJefeColaborador_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionJefeColaborador_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleCalificacionJefeColaborador_CalificacionNombramiento]
ON [dbo].[DetalleCalificacionJefeColaborador]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacionMeta'
ALTER TABLE [dbo].[DetalleCalificacionMeta]
ADD CONSTRAINT [FK_DetalleCalificacionMeta_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionMeta_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleCalificacionMeta_CalificacionNombramiento]
ON [dbo].[DetalleCalificacionMeta]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacionModificada'
ALTER TABLE [dbo].[DetalleCalificacionModificada]
ADD CONSTRAINT [FK_DetalleCalificacionModificada_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionModificada_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleCalificacionModificada_CalificacionNombramiento]
ON [dbo].[DetalleCalificacionModificada]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacionServicio'
ALTER TABLE [dbo].[DetalleCalificacionServicio]
ADD CONSTRAINT [FK_DetalleCalificacionServicio_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionServicio_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleCalificacionServicio_CalificacionNombramiento]
ON [dbo].[DetalleCalificacionServicio]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_CalificacionNombramiento] in table 'DetalleCalificacion'
ALTER TABLE [dbo].[DetalleCalificacion]
ADD CONSTRAINT [FK_DetalleEvaluacion_CalificacionNombramiento]
    FOREIGN KEY ([FK_CalificacionNombramiento])
    REFERENCES [dbo].[CalificacionNombramiento]
        ([PK_CalificacionNombramiento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleEvaluacion_CalificacionNombramiento'
CREATE INDEX [IX_FK_DetalleEvaluacion_CalificacionNombramiento]
ON [dbo].[DetalleCalificacion]
    ([FK_CalificacionNombramiento]);
GO

-- Creating foreign key on [FK_Clase] in table 'CatCalificacionCompetencias'
ALTER TABLE [dbo].[CatCalificacionCompetencias]
ADD CONSTRAINT [FK_CatCalificacionCompetencias_Clase]
    FOREIGN KEY ([FK_Clase])
    REFERENCES [dbo].[Clase]
        ([PK_Clase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatCalificacionCompetencias_Clase'
CREATE INDEX [IX_FK_CatCalificacionCompetencias_Clase]
ON [dbo].[CatCalificacionCompetencias]
    ([FK_Clase]);
GO

-- Creating foreign key on [FK_TipoCompetencia] in table 'CatCalificacionCompetencias'
ALTER TABLE [dbo].[CatCalificacionCompetencias]
ADD CONSTRAINT [FK_CatCalificacionCompetencias_TipoCalificacionCompetencia]
    FOREIGN KEY ([FK_TipoCompetencia])
    REFERENCES [dbo].[TipoCalificacionCompetencia]
        ([PK_TipoCompetencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatCalificacionCompetencias_TipoCalificacionCompetencia'
CREATE INDEX [IX_FK_CatCalificacionCompetencias_TipoCalificacionCompetencia]
ON [dbo].[CatCalificacionCompetencias]
    ([FK_TipoCompetencia]);
GO

-- Creating foreign key on [FK_Departamento] in table 'PlanEstrategicoEje'
ALTER TABLE [dbo].[PlanEstrategicoEje]
ADD CONSTRAINT [FK_Eje_Departamento]
    FOREIGN KEY ([FK_Departamento])
    REFERENCES [dbo].[Departamento]
        ([PK_Departamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Eje_Departamento'
CREATE INDEX [IX_FK_Eje_Departamento]
ON [dbo].[PlanEstrategicoEje]
    ([FK_Departamento]);
GO

-- Creating foreign key on [FK_Tipo] in table 'DetalleCalificacionAutoEvaluacion'
ALTER TABLE [dbo].[DetalleCalificacionAutoEvaluacion]
ADD CONSTRAINT [FK_DetalleCalificacionAutoEvaluacion_TipoAutoevaluacion]
    FOREIGN KEY ([FK_Tipo])
    REFERENCES [dbo].[TipoAutoevaluacion]
        ([PK_Tipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionAutoEvaluacion_TipoAutoevaluacion'
CREATE INDEX [IX_FK_DetalleCalificacionAutoEvaluacion_TipoAutoevaluacion]
ON [dbo].[DetalleCalificacionAutoEvaluacion]
    ([FK_Tipo]);
GO

-- Creating foreign key on [FK_Tipo] in table 'DetalleCalificacionCompetencia'
ALTER TABLE [dbo].[DetalleCalificacionCompetencia]
ADD CONSTRAINT [FK_CalificacionCompetencia_TipoCalificacionCompetencia]
    FOREIGN KEY ([FK_Tipo])
    REFERENCES [dbo].[TipoCalificacionCompetencia]
        ([PK_TipoCompetencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCompetencia_TipoCalificacionCompetencia'
CREATE INDEX [IX_FK_CalificacionCompetencia_TipoCalificacionCompetencia]
ON [dbo].[DetalleCalificacionCompetencia]
    ([FK_Tipo]);
GO

-- Creating foreign key on [FK_Tipo] in table 'DetalleCalificacionJefeColaborador'
ALTER TABLE [dbo].[DetalleCalificacionJefeColaborador]
ADD CONSTRAINT [FK_DetalleCalificacionJefeColaborador_TipoCalJefeColaborador]
    FOREIGN KEY ([FK_Tipo])
    REFERENCES [dbo].[TipoCalJefeColaborador]
        ([PK_Tipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionJefeColaborador_TipoCalJefeColaborador'
CREATE INDEX [IX_FK_DetalleCalificacionJefeColaborador_TipoCalJefeColaborador]
ON [dbo].[DetalleCalificacionJefeColaborador]
    ([FK_Tipo]);
GO

-- Creating foreign key on [FK_Meta] in table 'DetalleCalificacionMeta'
ALTER TABLE [dbo].[DetalleCalificacionMeta]
ADD CONSTRAINT [FK_DetalleCalificacionMeta_MetaIndividualCalificacion]
    FOREIGN KEY ([FK_Meta])
    REFERENCES [dbo].[MetaIndividualCalificacion]
        ([PK_Meta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionMeta_MetaIndividualCalificacion'
CREATE INDEX [IX_FK_DetalleCalificacionMeta_MetaIndividualCalificacion]
ON [dbo].[DetalleCalificacionMeta]
    ([FK_Meta]);
GO

-- Creating foreign key on [FK_Tipo] in table 'DetalleCalificacionServicio'
ALTER TABLE [dbo].[DetalleCalificacionServicio]
ADD CONSTRAINT [FK_DetalleCalificacionServicio_TipoCategoriaServicio]
    FOREIGN KEY ([FK_Tipo])
    REFERENCES [dbo].[TipoCategoriaServicio]
        ([PK_TipoCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleCalificacionServicio_TipoCategoriaServicio'
CREATE INDEX [IX_FK_DetalleCalificacionServicio_TipoCategoriaServicio]
ON [dbo].[DetalleCalificacionServicio]
    ([FK_Tipo]);
GO

-- Creating foreign key on [FK_Direccion] in table 'PlanEstrategico'
ALTER TABLE [dbo].[PlanEstrategico]
ADD CONSTRAINT [FK_PlanEstrategico_DireccionGeneral]
    FOREIGN KEY ([FK_Direccion])
    REFERENCES [dbo].[DireccionGeneral]
        ([PK_DireccionGeneral])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanEstrategico_DireccionGeneral'
CREATE INDEX [IX_FK_PlanEstrategico_DireccionGeneral]
ON [dbo].[PlanEstrategico]
    ([FK_Direccion]);
GO

-- Creating foreign key on [FK_EstadoActividad] in table 'PlanAnualActividad'
ALTER TABLE [dbo].[PlanAnualActividad]
ADD CONSTRAINT [FK_PlanAnualActividad_EstadoActividadPlan]
    FOREIGN KEY ([FK_EstadoActividad])
    REFERENCES [dbo].[EstadoActividadPlan]
        ([PK_Estado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanAnualActividad_EstadoActividadPlan'
CREATE INDEX [IX_FK_PlanAnualActividad_EstadoActividadPlan]
ON [dbo].[PlanAnualActividad]
    ([FK_EstadoActividad]);
GO

-- Creating foreign key on [FK_EstadoPlan] in table 'PlanEstrategico'
ALTER TABLE [dbo].[PlanEstrategico]
ADD CONSTRAINT [FK_PlanEstrategico_EstadoPlan]
    FOREIGN KEY ([FK_EstadoPlan])
    REFERENCES [dbo].[EstadoPlan]
        ([PK_EstadoPlan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanEstrategico_EstadoPlan'
CREATE INDEX [IX_FK_PlanEstrategico_EstadoPlan]
ON [dbo].[PlanEstrategico]
    ([FK_EstadoPlan]);
GO

-- Creating foreign key on [FK_EstadoPlan] in table 'PlanAnual'
ALTER TABLE [dbo].[PlanAnual]
ADD CONSTRAINT [FK_PlanInstitucional_EstadoPlan]
    FOREIGN KEY ([FK_EstadoPlan])
    REFERENCES [dbo].[EstadoPlan]
        ([PK_EstadoPlan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanInstitucional_EstadoPlan'
CREATE INDEX [IX_FK_PlanInstitucional_EstadoPlan]
ON [dbo].[PlanAnual]
    ([FK_EstadoPlan]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'PlanAnualActividadFuncionario'
ALTER TABLE [dbo].[PlanAnualActividadFuncionario]
ADD CONSTRAINT [FK_ActividadPlanFuncionario_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadPlanFuncionario_Funcionario'
CREATE INDEX [IX_FK_ActividadPlanFuncionario_Funcionario]
ON [dbo].[PlanAnualActividadFuncionario]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_PlanEstrategico] in table 'PlanAnual'
ALTER TABLE [dbo].[PlanAnual]
ADD CONSTRAINT [FK_PlanInstitucional_PlanEstrategico]
    FOREIGN KEY ([FK_PlanEstrategico])
    REFERENCES [dbo].[PlanEstrategico]
        ([PK_PlanEstrategico])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanInstitucional_PlanEstrategico'
CREATE INDEX [IX_FK_PlanInstitucional_PlanEstrategico]
ON [dbo].[PlanAnual]
    ([FK_PlanEstrategico]);
GO

-- Creating foreign key on [FK_Seccion] in table 'PlanAnual'
ALTER TABLE [dbo].[PlanAnual]
ADD CONSTRAINT [FK_PlanInstitucional_Seccion]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanInstitucional_Seccion'
CREATE INDEX [IX_FK_PlanInstitucional_Seccion]
ON [dbo].[PlanAnual]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_Plan] in table 'PlanAnualProductos'
ALTER TABLE [dbo].[PlanAnualProductos]
ADD CONSTRAINT [FK_ProductosPlanInstitucional_PlanInstitucional]
    FOREIGN KEY ([FK_Plan])
    REFERENCES [dbo].[PlanAnual]
        ([PK_PlanAnual])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductosPlanInstitucional_PlanInstitucional'
CREATE INDEX [IX_FK_ProductosPlanInstitucional_PlanInstitucional]
ON [dbo].[PlanAnualProductos]
    ([FK_Plan]);
GO

-- Creating foreign key on [FK_Meta] in table 'PlanAnualActividad'
ALTER TABLE [dbo].[PlanAnualActividad]
ADD CONSTRAINT [FK_Actividad_Meta]
    FOREIGN KEY ([FK_Meta])
    REFERENCES [dbo].[PlanAnualMeta]
        ([PK_Meta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Actividad_Meta'
CREATE INDEX [IX_FK_Actividad_Meta]
ON [dbo].[PlanAnualActividad]
    ([FK_Meta]);
GO

-- Creating foreign key on [FK_ActividadPlanAnual] in table 'PlanAnualActividadAvance'
ALTER TABLE [dbo].[PlanAnualActividadAvance]
ADD CONSTRAINT [FK_ActividadAvance_ActividadPlanAnual]
    FOREIGN KEY ([FK_ActividadPlanAnual])
    REFERENCES [dbo].[PlanAnualActividad]
        ([PK_Actividad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadAvance_ActividadPlanAnual'
CREATE INDEX [IX_FK_ActividadAvance_ActividadPlanAnual]
ON [dbo].[PlanAnualActividadAvance]
    ([FK_ActividadPlanAnual]);
GO

-- Creating foreign key on [FK_Actividad] in table 'PlanAnualActividadFuncionario'
ALTER TABLE [dbo].[PlanAnualActividadFuncionario]
ADD CONSTRAINT [FK_PlanAnualActividadFuncionario_PlanAnualActividad]
    FOREIGN KEY ([FK_Actividad])
    REFERENCES [dbo].[PlanAnualActividad]
        ([PK_Actividad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanAnualActividadFuncionario_PlanAnualActividad'
CREATE INDEX [IX_FK_PlanAnualActividadFuncionario_PlanAnualActividad]
ON [dbo].[PlanAnualActividadFuncionario]
    ([FK_Actividad]);
GO

-- Creating foreign key on [FK_ProductoPlanInstitucional] in table 'PlanAnualMeta'
ALTER TABLE [dbo].[PlanAnualMeta]
ADD CONSTRAINT [FK_MetaPlanInstitucional_ProductosPlanInstitucional]
    FOREIGN KEY ([FK_ProductoPlanInstitucional])
    REFERENCES [dbo].[PlanAnualProductos]
        ([PK_ProductoPlan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MetaPlanInstitucional_ProductosPlanInstitucional'
CREATE INDEX [IX_FK_MetaPlanInstitucional_ProductosPlanInstitucional]
ON [dbo].[PlanAnualMeta]
    ([FK_ProductoPlanInstitucional]);
GO

-- Creating foreign key on [FK_Producto] in table 'PlanAnualProductos'
ALTER TABLE [dbo].[PlanAnualProductos]
ADD CONSTRAINT [FK_ProductosPlanInstitucional_Producto]
    FOREIGN KEY ([FK_Producto])
    REFERENCES [dbo].[PlanEstrategicoProducto]
        ([PK_Producto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductosPlanInstitucional_Producto'
CREATE INDEX [IX_FK_ProductosPlanInstitucional_Producto]
ON [dbo].[PlanAnualProductos]
    ([FK_Producto]);
GO

-- Creating foreign key on [FK_PlanEstrategico] in table 'PlanEstrategicoEje'
ALTER TABLE [dbo].[PlanEstrategicoEje]
ADD CONSTRAINT [FK_Eje_PlanEstrategico]
    FOREIGN KEY ([FK_PlanEstrategico])
    REFERENCES [dbo].[PlanEstrategico]
        ([PK_PlanEstrategico])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Eje_PlanEstrategico'
CREATE INDEX [IX_FK_Eje_PlanEstrategico]
ON [dbo].[PlanEstrategicoEje]
    ([FK_PlanEstrategico]);
GO

-- Creating foreign key on [FK_Producto] in table 'PlanEstrategicoAccion'
ALTER TABLE [dbo].[PlanEstrategicoAccion]
ADD CONSTRAINT [FK_AccionEstrategica_Producto]
    FOREIGN KEY ([FK_Producto])
    REFERENCES [dbo].[PlanEstrategicoProducto]
        ([PK_Producto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccionEstrategica_Producto'
CREATE INDEX [IX_FK_AccionEstrategica_Producto]
ON [dbo].[PlanEstrategicoAccion]
    ([FK_Producto]);
GO

-- Creating foreign key on [FK_Seccion] in table 'PlanEstrategicoEje'
ALTER TABLE [dbo].[PlanEstrategicoEje]
ADD CONSTRAINT [FK_Eje_Seccion]
    FOREIGN KEY ([FK_Seccion])
    REFERENCES [dbo].[Seccion]
        ([PK_Seccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Eje_Seccion'
CREATE INDEX [IX_FK_Eje_Seccion]
ON [dbo].[PlanEstrategicoEje]
    ([FK_Seccion]);
GO

-- Creating foreign key on [FK_Eje] in table 'PlanEstrategicoLinea'
ALTER TABLE [dbo].[PlanEstrategicoLinea]
ADD CONSTRAINT [FK_Linea_Eje]
    FOREIGN KEY ([FK_Eje])
    REFERENCES [dbo].[PlanEstrategicoEje]
        ([PK_Eje])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Linea_Eje'
CREATE INDEX [IX_FK_Linea_Eje]
ON [dbo].[PlanEstrategicoLinea]
    ([FK_Eje]);
GO

-- Creating foreign key on [FK_Linea] in table 'PlanEstrategicoProducto'
ALTER TABLE [dbo].[PlanEstrategicoProducto]
ADD CONSTRAINT [FK_Producto_Linea]
    FOREIGN KEY ([FK_Linea])
    REFERENCES [dbo].[PlanEstrategicoLinea]
        ([PK_Linea])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_Linea'
CREATE INDEX [IX_FK_Producto_Linea]
ON [dbo].[PlanEstrategicoProducto]
    ([FK_Linea]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'CalificacionAutoEvaluacion'
ALTER TABLE [dbo].[CalificacionAutoEvaluacion]
ADD CONSTRAINT [FK_CalificacionAutoEvaluacion_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionAutoEvaluacion_Funcionario'
CREATE INDEX [IX_FK_CalificacionAutoEvaluacion_Funcionario]
ON [dbo].[CalificacionAutoEvaluacion]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_Periodo] in table 'CalificacionAutoEvaluacion'
ALTER TABLE [dbo].[CalificacionAutoEvaluacion]
ADD CONSTRAINT [FK_CalificacionAutoEvaluacion_PeriodoCalificacion]
    FOREIGN KEY ([FK_Periodo])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionAutoEvaluacion_PeriodoCalificacion'
CREATE INDEX [IX_FK_CalificacionAutoEvaluacion_PeriodoCalificacion]
ON [dbo].[CalificacionAutoEvaluacion]
    ([FK_Periodo]);
GO

-- Creating foreign key on [FK_Tipo] in table 'CalificacionAutoEvaluacion'
ALTER TABLE [dbo].[CalificacionAutoEvaluacion]
ADD CONSTRAINT [FK_CalificacionAutoEvaluacion_TipoAutoevaluacion]
    FOREIGN KEY ([FK_Tipo])
    REFERENCES [dbo].[TipoAutoevaluacion]
        ([PK_Tipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionAutoEvaluacion_TipoAutoevaluacion'
CREATE INDEX [IX_FK_CalificacionAutoEvaluacion_TipoAutoevaluacion]
ON [dbo].[CalificacionAutoEvaluacion]
    ([FK_Tipo]);
GO

-- Creating foreign key on [FK_Estado] in table 'CalificacionCompromiso'
ALTER TABLE [dbo].[CalificacionCompromiso]
ADD CONSTRAINT [FK_CalificacionCompromiso_CatMetaEstado]
    FOREIGN KEY ([FK_Estado])
    REFERENCES [dbo].[CatMetaEstado]
        ([PK_Estado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCompromiso_CatMetaEstado'
CREATE INDEX [IX_FK_CalificacionCompromiso_CatMetaEstado]
ON [dbo].[CalificacionCompromiso]
    ([FK_Estado]);
GO

-- Creating foreign key on [FK_Prioridad] in table 'CalificacionCompromiso'
ALTER TABLE [dbo].[CalificacionCompromiso]
ADD CONSTRAINT [FK_CalificacionCompromiso_CatMetaPrioridad]
    FOREIGN KEY ([FK_Prioridad])
    REFERENCES [dbo].[CatMetaPrioridad]
        ([PK_Prioridad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCompromiso_CatMetaPrioridad'
CREATE INDEX [IX_FK_CalificacionCompromiso_CatMetaPrioridad]
ON [dbo].[CalificacionCompromiso]
    ([FK_Prioridad]);
GO

-- Creating foreign key on [FK_Funcionario] in table 'CalificacionCompromiso'
ALTER TABLE [dbo].[CalificacionCompromiso]
ADD CONSTRAINT [FK_CalificacionCompromiso_Funcionario]
    FOREIGN KEY ([FK_Funcionario])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCompromiso_Funcionario'
CREATE INDEX [IX_FK_CalificacionCompromiso_Funcionario]
ON [dbo].[CalificacionCompromiso]
    ([FK_Funcionario]);
GO

-- Creating foreign key on [FK_PeriodoCalificacion] in table 'CalificacionCompromiso'
ALTER TABLE [dbo].[CalificacionCompromiso]
ADD CONSTRAINT [FK_CalificacionCompromiso_PeriodoCalificacion]
    FOREIGN KEY ([FK_PeriodoCalificacion])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionCompromiso_PeriodoCalificacion'
CREATE INDEX [IX_FK_CalificacionCompromiso_PeriodoCalificacion]
ON [dbo].[CalificacionCompromiso]
    ([FK_PeriodoCalificacion]);
GO

-- Creating foreign key on [FK_Jefatura] in table 'CalificacionJefeColaborador'
ALTER TABLE [dbo].[CalificacionJefeColaborador]
ADD CONSTRAINT [FK_CalificacionJefeColaborador_Funcionario]
    FOREIGN KEY ([FK_Jefatura])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionJefeColaborador_Funcionario'
CREATE INDEX [IX_FK_CalificacionJefeColaborador_Funcionario]
ON [dbo].[CalificacionJefeColaborador]
    ([FK_Jefatura]);
GO

-- Creating foreign key on [FK_Colaborador] in table 'CalificacionJefeColaborador'
ALTER TABLE [dbo].[CalificacionJefeColaborador]
ADD CONSTRAINT [FK_CalificacionJefeColaborador_Funcionario1]
    FOREIGN KEY ([FK_Colaborador])
    REFERENCES [dbo].[Funcionario]
        ([PK_Funcionario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionJefeColaborador_Funcionario1'
CREATE INDEX [IX_FK_CalificacionJefeColaborador_Funcionario1]
ON [dbo].[CalificacionJefeColaborador]
    ([FK_Colaborador]);
GO

-- Creating foreign key on [FK_Periodo] in table 'CalificacionJefeColaborador'
ALTER TABLE [dbo].[CalificacionJefeColaborador]
ADD CONSTRAINT [FK_CalificacionJefeColaborador_PeriodoCalificacion]
    FOREIGN KEY ([FK_Periodo])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionJefeColaborador_PeriodoCalificacion'
CREATE INDEX [IX_FK_CalificacionJefeColaborador_PeriodoCalificacion]
ON [dbo].[CalificacionJefeColaborador]
    ([FK_Periodo]);
GO

-- Creating foreign key on [FK_TipoCategoria] in table 'CalificacionJefeColaborador'
ALTER TABLE [dbo].[CalificacionJefeColaborador]
ADD CONSTRAINT [FK_CalificacionJefeColaborador_TipoCalJefeColaborador]
    FOREIGN KEY ([FK_TipoCategoria])
    REFERENCES [dbo].[TipoCalJefeColaborador]
        ([PK_Tipo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionJefeColaborador_TipoCalJefeColaborador'
CREATE INDEX [IX_FK_CalificacionJefeColaborador_TipoCalJefeColaborador]
ON [dbo].[CalificacionJefeColaborador]
    ([FK_TipoCategoria]);
GO

-- Creating foreign key on [FK_Direccion] in table 'CalificacionServicio'
ALTER TABLE [dbo].[CalificacionServicio]
ADD CONSTRAINT [FK_CalificacionServicio_Direccion]
    FOREIGN KEY ([FK_Direccion])
    REFERENCES [dbo].[DireccionGeneral]
        ([PK_DireccionGeneral])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionServicio_Direccion'
CREATE INDEX [IX_FK_CalificacionServicio_Direccion]
ON [dbo].[CalificacionServicio]
    ([FK_Direccion]);
GO

-- Creating foreign key on [FK_Periodo] in table 'CalificacionServicio'
ALTER TABLE [dbo].[CalificacionServicio]
ADD CONSTRAINT [FK_CalificacionServicio_PeriodoCalificacion]
    FOREIGN KEY ([FK_Periodo])
    REFERENCES [dbo].[PeriodoCalificacion]
        ([PK_PeriodoCalificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionServicio_PeriodoCalificacion'
CREATE INDEX [IX_FK_CalificacionServicio_PeriodoCalificacion]
ON [dbo].[CalificacionServicio]
    ([FK_Periodo]);
GO

-- Creating foreign key on [FK_TipoCategoria] in table 'CalificacionServicio'
ALTER TABLE [dbo].[CalificacionServicio]
ADD CONSTRAINT [FK_CalificacionServicio_TipoCategoriaServicio]
    FOREIGN KEY ([FK_TipoCategoria])
    REFERENCES [dbo].[TipoCategoriaServicio]
        ([PK_TipoCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CalificacionServicio_TipoCategoriaServicio'
CREATE INDEX [IX_FK_CalificacionServicio_TipoCategoriaServicio]
ON [dbo].[CalificacionServicio]
    ([FK_TipoCategoria]);
GO

-- Creating foreign key on [FK_Clase] in table 'RegistroTiempoExtra'
ALTER TABLE [dbo].[RegistroTiempoExtra]
ADD CONSTRAINT [FK_RegistroTiempoExtra_Clase]
    FOREIGN KEY ([FK_Clase])
    REFERENCES [dbo].[Clase]
        ([PK_Clase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroTiempoExtra_Clase'
CREATE INDEX [IX_FK_RegistroTiempoExtra_Clase]
ON [dbo].[RegistroTiempoExtra]
    ([FK_Clase]);
GO

-- Creating foreign key on [FK_DesgloseSalarialQ1] in table 'RegistroTiempoExtra'
ALTER TABLE [dbo].[RegistroTiempoExtra]
ADD CONSTRAINT [FK_RegistroTiempoExtra_DesgloseSalarialQ1]
    FOREIGN KEY ([FK_DesgloseSalarialQ1])
    REFERENCES [dbo].[DesgloseSalarial]
        ([PK_DesgloseSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroTiempoExtra_DesgloseSalarialQ1'
CREATE INDEX [IX_FK_RegistroTiempoExtra_DesgloseSalarialQ1]
ON [dbo].[RegistroTiempoExtra]
    ([FK_DesgloseSalarialQ1]);
GO

-- Creating foreign key on [FK_DesgloseSalarialQ2] in table 'RegistroTiempoExtra'
ALTER TABLE [dbo].[RegistroTiempoExtra]
ADD CONSTRAINT [FK_RegistroTiempoExtra_DesgloseSalarialQ2]
    FOREIGN KEY ([FK_DesgloseSalarialQ2])
    REFERENCES [dbo].[DesgloseSalarial]
        ([PK_DesgloseSalarial])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroTiempoExtra_DesgloseSalarialQ2'
CREATE INDEX [IX_FK_RegistroTiempoExtra_DesgloseSalarialQ2]
ON [dbo].[RegistroTiempoExtra]
    ([FK_DesgloseSalarialQ2]);
GO

-- Creating foreign key on [FK_RegistroTiempoExtra] in table 'DetalleTiempoExtra'
ALTER TABLE [dbo].[DetalleTiempoExtra]
ADD CONSTRAINT [FK_DetalleTiempoExtra_RegistroTiempoExtra]
    FOREIGN KEY ([FK_RegistroTiempoExtra])
    REFERENCES [dbo].[RegistroTiempoExtra]
        ([PK_RegistroTiempoExtra])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleTiempoExtra_RegistroTiempoExtra'
CREATE INDEX [IX_FK_DetalleTiempoExtra_RegistroTiempoExtra]
ON [dbo].[DetalleTiempoExtra]
    ([FK_RegistroTiempoExtra]);
GO

-- Creating foreign key on [FK_Presupuesto] in table 'RegistroTiempoExtra'
ALTER TABLE [dbo].[RegistroTiempoExtra]
ADD CONSTRAINT [FK_RegistroTiempoExtra_Presupuesto]
    FOREIGN KEY ([FK_Presupuesto])
    REFERENCES [dbo].[Presupuesto]
        ([PK_Presupuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroTiempoExtra_Presupuesto'
CREATE INDEX [IX_FK_RegistroTiempoExtra_Presupuesto]
ON [dbo].[RegistroTiempoExtra]
    ([FK_Presupuesto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------