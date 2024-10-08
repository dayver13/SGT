function abrirCancelarRegistro2(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada) {
    $("#modal-cancelar").appendTo("body");
    $('#modal-cancelar').modal('show');
    $("#modal-cancelar #idRegistro").val(idRegistro);
    $("#modal-cancelar #numDocumento").text(numDocumento);
    $("#modal-cancelar #mensajeDias").text(dias);
    $("#modal-cancelar #dias").val(dias);

    $("#modal-cancelar #solicitud").text(numDocumento);
    $("#modal-cancelar #fechaEntrada").text(fechaEntrada);
    $("#modal-cancelar #fechaSalida").text(fechaSalida);
    $("#modal-cancelar #dias").text(dias);
    return true;
}

function CancelarRegistroConfirmado() {
    $("#modal-cancelar").hide();
    $('.modal-backdrop').remove();
}

function CompleteCancelarRegistro() {
    $("#modal-cancelar").hide();
    $('.modal-backdrop').remove();
}

/*Metodos para el Pop-Up Detalles*/
function abrirDetalles(idRegistro, numDocumento, dias, fechaSalida, fechaEntrada,tipoTransaccion,estado) {
    $("#modal-detalles").appendTo("body");
    $('#modal-detalles').modal('show');
    $("#modal-detalles #idRegistro").val(idRegistro);
    $("#modal-detalles #numDocumento").text(numDocumento);
    $("#modal-detalles #mensajeDias").text(dias);
    $("#modal-detalles #dias").val(dias);
    if (tipoTransaccion == 1) {
        $("#modal-detalles #tipoTransaccion").text("Vacaciones");
    }
    else if (tipoTransaccion == 6) {
        $("#modal-detalles #tipoTransaccion").text("Permiso sin goce de salario");
    }
    else if (tipoTransaccion == 5) {
        $("#modal-detalles #tipoTransaccion").text("Proporcionales");
    }
    else {
        $("#modal-detalles #tipoTransaccion").text("Vacío");

    }

    if (estado == 1) { 
        $("#modal-detalles #estado").text("Aprobado");
        $("#modal-detalles #btnReintegrar").show();
    }
    else if (estado == 2 || estado == 3 ) {
        $("#modal-detalles #estado").text("Pendiente");
        $("#modal-detalles #btnReintegrar").hide();
    }
    else if (estado == 4 || estado == 5 || estado == 6) {
        $("#modal-detalles #estado").text("Rechazado");
        $("#modal-detalles #btnReintegrar").hide();
    }
    else if (estado == 7) {
        $("#modal-detalles #estado").text("Anulado");
        $("#modal-detalles #btnReintegrar").hide();
    }
    
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

function AbrirReintegroVacaciones(idRegistro, numDocumento, dias, fechaEntrada,fechaSalida, periodo) {
    $("#modal-reintegro").appendTo("body");
    $("#modal-reintegro").modal('show');
    $("#modal-reintegro #idRegistro").val(idRegistro);
    $("#modal-reintegro #numDocumento").val(numDocumento);
    $("#modal-reintegro #mensajeDias").text(dias);
    $("#modal-reintegro #dias").text(dias);
    $("#modal-reintegro #fechaInicio").text(fechaEntrada);
    $("#modal-reintegro #fechaFin").text(fechaSalida);
    $("#modal-reintegro #fechaInicioOriginal").val(fechaEntrada);
    $("#modal-reintegro #fechaFinOriginal").val(fechaSalida);
    $("#modal-reintegro #diasReintegro").attr('max', dias);
    $("#modal-reintegro #periodo").val(periodo);

    $("#modal-reintegro #diasReintegro").val('');
    $('#modal-reintegro #obsReintegro').val("");

    $('#modal-reintegro #fecInicio').val('');
    $('#modal-reintegro #fecInicio').datepicker(
        {
            language: "es",
            autoclose: true,
            daysOfWeekDisabled: [0, 6]
        });

    $('#modal-reintegro #fecFin').val('');
    $('#modal-reintegro #fecFin').datepicker(
        {
            language: "es",
            autoclose: true,
            daysOfWeekDisabled: [0, 6]
            
        });
    return true;
}
//$('#datepicker').datepicker({
//    minDate: new Date(2014, 10, 30),
//    maxDate: new Date(2015, 2, 5),
//    setDate: new Date(2014, 10, 30)
//});
function CompleteCargarReintegro() {
    $('#modal-reintegro').hide();
    LimpiarModalReintegro();
    
}

function LimpiarModalReintegro() {
    $('#modal-reintegro').on("hidden.bs.modal", function () {
        $(".modal-reintegro-body").html("");
    });
    $('#modal-reintegro #error').hide();
}

function BeginCargarReintegro() {
    if ($('#modal-reintegro #fecInicio').val() == "") {
        $("#modal-reintegro #error").show();
        $("#modal-reintegro #error").text("Debe seleccionar la fecha de inicio entre el rango de registro.");
        return false;
    }

    if ($('#modal-reintegro #fecFin').val() == "") {
        $("#modal-reintegro #error").show();
        $("#modal-reintegro #error").text("Debe seleccionar la fecha de finalizacion entre el rango de registro.");
        return false;
    }

    if ($('#modal-reintegro #diasReintegro').val() == "" || $('#modal-reintegro #diasReintegro').val() == "") {
        $("#modal-reintegro #error").show();
        $("#modal-reintegro #error").text("Debe seleccionar la cantidad de dias a reintegrar.");
        return false;
    }

    if ($('#modal-reintegro #obsReintegro').val() == "") {
        $("#modal-reintegro #error").show();
        $("#modal-reintegro #error").text("Debe indicar el motivo del reintegro en el campo de observaciones.");
        return false;
    }

    if ($('#modal-reintegro #docReintegro').val() == "") {
        $("#modal-reintegro #error").show();
        $("#modal-reintegro #error").text("Debe indicar el documento de reintegro.");
        return false;
    }

    $('#modal-reintegro #error').hide();
    
    return true;
}