/*Metodos para el Pop-Up Detalles*/
function abrirDetalles(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada, motivo, observaciones) {
    $("#modal-detalles").appendTo("body");
    $('#modal-detalles').modal('show');
    $("#modal-detalles #idRegistro").val(idRegistro);
    $("#modal-detalles #numDocumento").text(numDocumento);
    $("#modal-detalles #mensajeDias").text(dias);
    $("#modal-detalles #dias").val(dias);
    $("#modal-detalles #motivo").text(motivo);
    $("#modal-detalles #observaciones").text(observaciones);
    

    $("#modal-detalles #solicitud").text(numDocumento);
    $("#modal-detalles #fechaEntrada").text(fechaEntrada);
    $("#modal-detalles #fechaSalida").text(fechaSalida);
    $("#modal-detalles #dias").text(dias);
    return true;
}

function CancelarDetallesConfirmado() {
    $("#modal-detalles").hide();
    $('.modal-backdrop').remove();
}

function CompleteCancelarDetalles() {
    $("#modal-detalles").hide();
    $('.modal-backdrop').remove();
}

function abrirCancelarReintegro(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada, motivo, observaciones) {
    $("#modal-cancelar").appendTo("body");
    $('#modal-cancelar').modal('show');
    $("#modal-cancelar #idRegistro").val(idRegistro);
    $("#modal-cancelar #numDocumento").text(numDocumento);
    $("#modal-cancelar #mensajeDias").text(dias);
    $("#modal-cancelar #dias").val(dias);
    $("#modal-cancelar #motivo").text(motivo);
    $("#modal-cancelar #observaciones").text(observaciones);


    $("#modal-cancelar #solicitud").text(numDocumento);
    $("#modal-cancelar #fechaEntrada").text(fechaEntrada);
    $("#modal-cancelar #fechaSalida").text(fechaSalida);
    $("#modal-cancelar #dias").text(dias);
    return true;
}

function CancelarReintegroConfirmado() {
    $("#modal-cancelar").hide();
    $('.modal-backdrop').remove();
}

function CompleteCancelarReintegro() {
    $("#modal-cancelar").hide();
    $('.modal-backdrop').remove();
}