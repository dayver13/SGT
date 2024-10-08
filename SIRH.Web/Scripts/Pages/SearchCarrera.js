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

    //$('#FechaDesde').val("");
    //$('#FechaHasta').val(""); 
    
    //OnChangeTipo() AR

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

});

function BeginSearch() {
    $('#btnBuscar').hide();
    $('#preloader').show();
}

function CompleteSearch() {
    $('#preloader').hide();
    $('#btnBuscar').show();
}

function OnChangeTipo() {
    if ($('#TipoSelec').val().indexOf("grado") > 0) {
        document.getElementById("LabelGradoAcademico").style.display = "block";
        document.getElementById("ColGradoAcademico").style.display = "block";
        document.getElementById("LabelModalidad").style.display = "none";
        document.getElementById("ColModalidad").style.display = "none";
    }
    else {
        if ($('#TipoSelec').val().indexOf("capacita") > 0) {
            document.getElementById("LabelGradoAcademico").style.display = "none";
            document.getElementById("ColGradoAcademico").style.display = "none";
            document.getElementById("LabelModalidad").style.display = "block";
            document.getElementById("ColModalidad").style.display = "block";
        }
        else {
            document.getElementById("LabelGradoAcademico").style.display = "none";
            document.getElementById("ColGradoAcademico").style.display = "none";
            document.getElementById("LabelModalidad").style.display = "none";
            document.getElementById("ColModalidad").style.display = "none";
        }
    }
}