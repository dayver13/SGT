/* METODOS PARA CARGA DEL FORMULARIO DE GUARDADO */
function BeginCargarFuncionario() {
    $('#btnBuscar').hide();
    $('#preloader').show();
}

function CompleteCargarFuncionario() {
    $('#preloader').hide();
    $('#btnBuscar').show();
    //var config = {
    //    locale: 'es-es',
    //    uiLibrary: 'bootstrap4',
    //    format: 'dd/mm/yyyy'
    //}

    //$('#FechaReg').datepicker(config); AR

    $('#FechaReg').val("Click aquí");
    $('#FechaReg').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });
}

/* METODOS PARA EL GUARDADO DE DATOS DEL FORMULARIO Y CONTROL DE ERRORES */

function BeginGuardarExperiencia() {
    $('#btnGuardar_reg').hide();
    $('#preloader_reg').show();
}

function CompleteGuardarExperiencia() {
    $('#preloader_reg').hide();
    $('#btnGuardar_reg').show();
}

function SuccessGuardarExperiencia() {
    CompleteCargarFuncionario()
}

