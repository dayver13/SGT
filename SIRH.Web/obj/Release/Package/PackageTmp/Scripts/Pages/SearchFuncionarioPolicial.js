$(document).ready(function () {
    //var config = {
    //    locale: 'es-es',
    //    uiLibrary: 'bootstrap4',
    //    format: 'dd/mm/yyyy'
    //}

    //$('#FechaDesde').datepicker(config);
    //var config2 = Object.assign({}, config);
    //config2["minDate"] = () => $("#FechaDesde").val();
    //$('#FechaHasta').datepicker(config2);

    ////$('#FecBitacoraDesde').datepicker(config);
    ////$('#FecBitacoraHasta').datepicker(config);

    //$('#FechaDesde').val("");
    //$('#FechaHasta').val("");

    ////$('#FecBitacoraDesde').val("");
    ////$('#FecBitacoraHasta').val(""); AR

    $('#FechaDesde').val("Click aquí");
    $('#FechaDesde').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });
    
    $('#FechaHasta').val("Click aquí");
    $('#FechaHasta').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });

    $('#FecBitacoraDesde').val("Click aquí");
    $('#FecBitacoraDesde').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });
    $('#FecBitacoraHasta').val("Click aquí");
    $('#FecBitacoraHasta').datepicker(
    {
        weekStart: 0,
        language: "es",
        autoclose: true
    });
});

function BeginSearch() {
    $("#btnBuscar").css("display", "none");
    $("#preloader").css("display", "block");
}

function CompleteSearch() {
    $("#preloader").css("display", "none");
    $("#btnBuscar").css("display", "block");
}