$(document).ready(function () {

    $('#FechaRige').val("Click aquí");
    $('#FechaRige').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });

    $('#FechaVence').val("Click aquí");
    $('#FechaVence').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });
});

function BeginBuscar() {
    $('#preloader').show();
    $("#btnBuscar").hide();
    $("#btnAgregar").hide();
    $("#btnRemover").hide();
    $("#btnGenerar").hide();
}

function CompleteBuscar() {
    $('#preloader').hide();
    $('#btnBuscar').show();
    $('#btnAgregar').show();
    $('#btnGenerar').show();
}


