function abrirAprobarRegistro(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada, cedula, nombreFuncionario, primerApellido, segundoApellido) {
    $("#modal-aprobar").appendTo("body");
    $('#modal-aprobar').modal('show');
    $("#modal-aprobar #idRegistro").val(idRegistro);
    $("#modal-aprobar #Solicitud").prop('value', numDocumento);
    $("#modal-aprobar #numDocumento").text(numDocumento);
    $("#modal-aprobar #Solicitud").attr('value', numDocumento);
    $("#modal-aprobar #Solicitud").val(numDocumento).trigger('change');
    $("#modal-aprobar #mensajeDias").text(dias);
    $("#modal-aprobar #dias").val(dias);
    $("#modal-aprobar #cedula").text(cedula);
    $("#modal-aprobar #nomFuncionario").text(nombreFuncionario);
    $("#modal-aprobar #primerApellido").text(primerApellido);
    $("#modal-aprobar #segundoApellido").text(segundoApellido);
    $("#modal-aprobar #mensajeDias").val(dias);
    $("#modal-aprobar #Cedula").val(cedula);
    $("#modal-aprobar #Cedula").prop('value', cedula);

    $("#modal-aprobar #Solicitud").text(numDocumento);
    $("#modal-aprobar #fechaEntrada").text(fechaEntrada);
    $("#modal-aprobar #fechaSalida").text(fechaSalida);
    $("#modal-aprobar #dias").text(dias);
    return true;
}
function abrirDiscusionRegistro(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada, cedula, nombreFuncionario, primerApellido, segundoApellido) {
    $("#modal-discusion").appendTo("body");
    $('#modal-discusion').modal('show');
    $("#modal-discusion #idRegistro").val(idRegistro);

    $("#modal-discusion #Solicitud").prop('value', numDocumento);
    $("#modal-discusion #numDocumento").text(numDocumento);
    $("#modal-discusion #Solicitud").attr('value', numDocumento);
    $("#modal-discusion #Solicitud").val(numDocumento).trigger('change');
    $("#modal-discusion #mensajeDias").text(dias);
    $("#modal-discusion #dias").val(dias);
    $("#modal-discusion #cedula").text(cedula);
    $("#modal-discusion #nomFuncionario").text(nombreFuncionario);
    $("#modal-discusion #primerApellido").text(primerApellido);
    $("#modal-discusion #segundoApellido").text(segundoApellido);

    $("#modal-discusion #Cedula").val(cedula);
    $("#modal-discusion #Cedula").attr('value', cedula);
    $("#modal-discusion #Cedula").val();


    $("#modal-discusion #Solicitud").text(numDocumento);
    $("#modal-discusion #fechaEntrada").text(fechaEntrada);
    $("#modal-discusion #fechaSalida").text(fechaSalida);
    $("#modal-discusion #dias").text(dias);
    return true;
}
function abrirCancelarRegistro(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada, cedula, nombreFuncionario, primerApellido, segundoApellido) {
    $("#modal-cancelar").appendTo("body");
    $('#modal-cancelar').modal('show');
    $("#modal-cancelar #idRegistro").val(idRegistro);
    $("#modal-cancelar #Solicitud").prop('value', numDocumento);
    $("#modal-cancelar #numDocumento").text(numDocumento);
    $("#modal-cancelar #Solicitud").attr('value', numDocumento);
    $("#modal-cancelar #Solicitud").val(numDocumento).trigger('change');
    $("#modal-cancelar #mensajeDias").text(dias);
    $("#modal-cancelar #dias").val(dias);
    $("#modal-cancelar #cedula").text(cedula);
    $("#modal-cancelar #nomFuncionario").text(nombreFuncionario);
    $("#modal-cancelar #primerApellido").text(primerApellido);
    $("#modal-cancelar #segundoApellido").text(segundoApellido);

    $("#modal-cancelar #Cedula").prop('value', cedula);
    $("#modal-cancelar #Cedula").attr('value', cedula);
    $("#modal-cancelar #Cedula").val(cedula);
    $("#modal-cancelar #Cedula").val();
    $("#Cedula").val(cedula).trigger('change');



    $("#modal-cancelar #Solicitud").text(numDocumento);
    $("#modal-cancelar #fechaEntrada").text(fechaEntrada);
    $("#modal-cancelar #fechaSalida").text(fechaSalida);
    $("#modal-cancelar #dias").text(dias);
    return true;
}

function AprobarRegistroConfirmado() {
    $("#modal-aprobar").hide();
    $('.modal-backdrop').remove();
}

function DiscusionRegistroConfirmado() {
    $("#modal-discusion").hide();
    $('.modal-backdrop').remove();
}

function CancelarRegistroConfirmado() {
    $("#modal-cancelar").hide();
    $('.modal-backdrop').remove();
}

function BeginCargarVacacionesDivision() {
    $('#btnBuscar').hide();
    $("#preloaderDivision").removeAttr("hidden");
    $('#preloaderDivision').show();
}
function CompleteCargarVacacionesDivision() {
    $('#preloaderDivision').hide();
    $('#btnBuscar').show();
}

function BeginCargarVacacionesSeccion() {
    $('#btnBuscar').hide();
    $("#preloaderSeccion").removeAttr("hidden");
    $('#preloaderSeccion').show();
}
function CompleteCargarVacacionesSeccion() {
    $('#preloaderSeccion').hide();
    $('#btnBuscar').show();
}