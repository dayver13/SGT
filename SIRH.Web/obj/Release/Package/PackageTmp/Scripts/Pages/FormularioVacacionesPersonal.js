function BeginCargarVacaciones() {
    $('#btnBuscar').hide();
    $("#preloader").removeAttr("hidden");
    $('#preloader').show();
}
function CompleteCargarVacaciones() {
    $('#preloader').hide();
    $('#btnBuscar').show();
}
function SuccessCargarVacaciones() {
    var config = {
        locale: 'es-es',
        uiLibrary: 'bootstrap4',
        format: 'dd/mm/yyyy'
    }
    $("#FechaRige").datepicker(config);
    $("#FechaVence").datepicker(config);
    $('#dias').val("");
}
function BeginGuardarVacaciones() {
    $('#btnGuardar').hide();
    $('#preloader1').removeAttr("hidden");
    $('#preloader1').show();
}

function CompleteGuardarVacaciones() {
    $('#preloader1').hide();
    $('#btnGuardar').show();
   
    
}

function SuccessGuardarVacaciones() {
    SuccessCargarVacaciones();
}


$(function () {
    $('#FechaRige').val("Click aquí");
    $('#FechaRige').datepicker(
        {       
            language: "es",
            autoclose: true,
            daysOfWeekDisabled: [0, 6],
            startDate: '-15d'
           
        });
    $('#FechaRige').change(function (event) {

        $('#FechaVence').val(CalcularFechaRegreso()),
        $('#FechaFinalizacion').val(CalcularFechaFinalizacion());
    })

    $('#dias').change(function (event) {
        if ($('#FechaRige').val() != "Click aquí") {
            $('#FechaVence').val(CalcularFechaRegreso()),
            $('#FechaFinalizacion').val(CalcularFechaFinalizacion());
        }
        if (parseFloat($('#dias').val()) == 0.5) {
            document.getElementById('divMediosDias').style.display = 'block';
            $("input[type=radio][name=MedioDia]").prop('checked', true);
        }
        else {
            document.getElementById('divMediosDias').style.display = 'none';
            $("input[type=radio][name=MedioDia]").prop('checked',false);
            
        }
    })

    
});

//function mostrarMediosDias() {
//    var cantidadDias = $('#dias').val() + "";
//    document.getElementById("divMediosDias").style.display = parseFloat(cantidadDias) == 0.5 ? 'block' : 'none';
    
//}
function CalcularFechaRegreso() {

    var fechaSalida = $('#FechaRige').val() + "";   
    var cantidadDias = $('#dias').val() + "";

    var fecha = stringToDate(fechaSalida, "dd/MM/yyyy", "/");
    var dias = parseInt(cantidadDias);
    var count = 0;

    while (count < dias) {
        fecha.setDate(fecha.getDate() + 1);
        if (fecha.getDay() != 0 && fecha.getDay() != 6) {//Se salta sabados y domingos para jornada de 5 dias
            count++
        }
    }
    return dateFormat(fecha, 'dd/MM/yyyy');
}

function CalcularFechaFinalizacion() {

    var fechaSalida = $('#FechaRige').val() + "";
    var cantidadDias = $('#dias').val() + "";

    var fecha = stringToDate(fechaSalida, "dd/MM/yyyy", "/");
    var dias = parseFloat(cantidadDias);
    var count = 1;

    if (dias <= 1)
    {
        return dateFormat(fecha, 'dd/MM/yyyy');
    }
    else
    {
        while (count < dias) {
            fecha.setDate(fecha.getDate() + 1);
            if (fecha.getDay() != 0 && fecha.getDay() != 6) {//Se salta sabados y domingos para jornada de 5 dias
                count++
            }
        }

        return dateFormat(fecha, 'dd/MM/yyyy');
    }
}

function stringToDate(_date, _format, _delimiter) {
    var formatLowerCase = _format.toLowerCase();
    var formatItems = formatLowerCase.split(_delimiter);
    var dateItems = _date.split(_delimiter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    month -= 1;
    var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
    return formatedDate;
}

function dateFormat(inputDate, format) {
    //parse the input date
    const date = new Date(inputDate);

    //extract the parts of the date
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();

    //replace the month
    format = format.replace("MM", month.toString().padStart(2, "0"));

    //replace the year
    if (format.indexOf("yyyy") > -1) {
        format = format.replace("yyyy", year.toString());
    } else if (format.indexOf("yy") > -1) {
        format = format.replace("yy", year.toString().substr(2, 2));
    }

    //replace the day
    format = format.replace("dd", day.toString().padStart(2, "0"));

    return format;
}