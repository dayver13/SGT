$(document).ready(function () {
    //var config = {
    //    locale: 'es-es',
    //    uiLibrary: 'bootstrap4',
    //    format: 'dd/mm/yyyy'
    //}

    //$('#FechaRige').datepicker(config);
    //var config2 = Object.assign({}, config);
    //config2["minDate"] = () => $("#FechaRige").val();
    //$('#FechaVence').datepicker(config2);

    //$('#FechaRige').val("");
    //$('#FechaVence').val(""); AR

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

function OnChangeFechaRige() {
    //var fecha = $("#FechaRige").val();
    //var vence = fecha.substr(0, fecha.length - 1) + (parseInt(fecha.substr(fecha.length - 1, 1)) + 5);
    //$('#FechaVence').val(vence);

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
}
