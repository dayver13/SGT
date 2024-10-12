var listaDiasFeriado = [];// ['01/01', '11/04', '01/05', '25/07', '02/08', '15/08', '15/09', '12/10', '01/12', '25/12'];
// OFIC.SEGUR - POLICIA DE TRANSITO
var listaClases = ['350', '352', '14812', '14814', '14816', '14818', '14822', '8412', '8414', '8416', '8418', '8420']; //, '11671'

var esOficial = false;

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

    ObtenerDiasFeriados();
       
    var codClase = $("#CodClase").val();
   
    if (listaClases.indexOf(codClase) > -1) {
        esOficial = true;
    }
       
    //alert(esOficial);
    $('#FechaRige').val("Click aquí");
    if (esOficial) {
       $('#FechaRige').datepicker(
       {
           language: "es",
           autoclose: true,
           startDate: '-15d'
       });
    }
    else {
       $('#FechaRige').datepicker(
       {
           language: "es",
           autoclose: true,
           daysOfWeekDisabled: [0, 6],
           startDate: '-15d'
       });
    }
   
    $('#FechaRige').change(function (event) {
        var fecha = stringToDate($('#FechaRige').val() + "", "dd/MM/yyyy", "/");
        var fechaBuscar = fecha.getDate().toString().padStart(2, "0") + '/' + (fecha.getMonth() + 1).toString().padStart(2, "0");

        if ((fecha.getDay() == 0 || fecha.getDay() == 6) && esOficial == false) {
            $('#FechaRige').val('');
            $('#FechaRige').val('Click aquí');
            $('#FechaVence').val('');
            $('#FechaRegreso').val('');
            $('#mensaje').text('No puede comenzar las vacaciones un Sábado ni un Domingo');
            $("#modal-mensaje").appendTo("body");
            $('#modal-mensaje').modal('show');
        }

        if (listaDiasFeriado.indexOf(fechaBuscar) > -1 && esOficial == false) {
            $('#FechaRige').val('');
            $('#FechaRige').val('Click aquí');
            $('#FechaVence').val('');
            $('#FechaRegreso').val('');
            $('#mensaje').text('No puede comenzar las vacaciones un día feriado');
            $("#modal-mensaje").appendTo("body");
            $('#modal-mensaje').modal('show');
            //alert('No puede comenzar las vacaciones un día feriado');   
        }
        else {
            $('#FechaVence').val(CalcularFechaFinalizacion());
            $('#FechaRegreso').val(CalcularFechaRegreso());
        }
    })

    $('#dias').change(function (event) {
        if ($('#FechaRige').val() != "Click aquí") {
            $('#FechaVence').val(CalcularFechaFinalizacion());
            $('#FechaRegreso').val(CalcularFechaRegreso());
        }
        if (parseFloat($('#dias').val()) == 0.5) {
            document.getElementById('divMediosDias').style.display = 'block';
            $("input[type=radio][name=MedioDia]").prop('checked', true);
        }
        else {
            document.getElementById('divMediosDias').style.display = 'none';
            $("input[type=radio][name=MedioDia]").prop('checked',false);
            
        }
       // alert($('#saldoTotal').val());
        var cantPeriodo = ($('#cantidaPeriodos').val());
        var saldo = parseFloat($('#saldoOriginal').val());
        var dias = parseFloat($('#dias').val());
        var saldoPeriodo = parseFloat("0");

        $('#saldoTotal').val(saldo - dias);

        for (var j = 0; j < cantPeriodo; j++) {
            if (dias > 0)
            {
                saldoPeriodo = parseFloat($('#saldoPeriodo' + j).val());
                if (dias < saldoPeriodo) {
                    $('#diaSolicitado' + j).val(dias);
                    $('#saldoRestante' + j).val(saldoPeriodo - dias);
                }
                else {
                    $('#diaSolicitado' + j).val(saldoPeriodo);
                    $('#saldoRestante' + j).val(0);
                }
                dias = dias - saldoPeriodo;
            }
        }
    })

    
});

//function mostrarMediosDias() {
//    var cantidadDias = $('#dias').val() + "";
//    document.getElementById("divMediosDias").style.display = parseFloat(cantidadDias) == 0.5 ? 'block' : 'none';
    
//}
function CalcularFechaRegreso() {
    var fechaBuscar = "";
    var fechaSalida = $('#FechaRige').val() + "";   
    var cantidadDias = $('#dias').val() + "";

    var fecha = stringToDate(fechaSalida, "dd/MM/yyyy", "/");
    var dias = parseInt(cantidadDias);
    var count = 0;

    while (count < dias) {
        fecha.setDate(fecha.getDate() + 1);
        if (esOficial) {
            count++;
        }
        else {
            if (fecha.getDay() != 0 && fecha.getDay() != 6) {//Se salta sabados y domingos para jornada de 5 dias
                count++
                fechaBuscar = fecha.getDate().toString().padStart(2, "0") + '/' + (fecha.getMonth() + 1).toString().padStart(2, "0");
                if (listaDiasFeriado.indexOf(fechaBuscar) > -1) {
                    //Si el feriado es viernes, le resta 1 día al contador
                    if (fecha.getDay() == 5) {
                        count--
                    }
                    //alert('Está ' + fechaBuscar);
                    fecha.setDate(fecha.getDate() + 1);
                }
            }
        }
    }
    return dateFormat(fecha, 'dd/MM/yyyy');
}

function CalcularFechaFinalizacion() {
    
    var fechaBuscar = "";

    var fechaSalida = $('#FechaRige').val() + "";
    var cantidadDias = $('#dias').val() + "";

    var fecha = stringToDate(fechaSalida, "dd/MM/yyyy", "/");
    var dias = parseFloat(cantidadDias);
    var count = 1;

    if (dias <= 1)
    {
        if (esOficial == false) {
            fechaBuscar = fecha.getDate().toString().padStart(2, "0") + '/' + (fecha.getMonth() + 1).toString().padStart(2, "0");
            if (listaDiasFeriado.indexOf(fechaBuscar) > -1) {
                fecha.setDate(fecha.getDate() + 1);
            }
        }
        
        return dateFormat(fecha, 'dd/MM/yyyy');
    }
    else
    {
        while (count < dias) {
            fecha.setDate(fecha.getDate() + 1);

            if (esOficial) {
                count++;
            }
            else {
                //alert(fecha.getDate().toString().padStart(2, "0") + '/' + (fecha.getMonth() + 1).toString().padStart(2, "0"));
                fechaBuscar = fecha.getDate().toString().padStart(2, "0") + '/' + (fecha.getMonth() + 1).toString().padStart(2, "0");
                if (fecha.getDay() != 0 && fecha.getDay() != 6) {//Se salta sabados y domingos para jornada de 5 dias
                    count++
                    //alert(listaDiasFeriado.length);
                    if (listaDiasFeriado.indexOf(fechaBuscar) > -1) {
                        //Si el feriado es viernes, le resta 1 día al contador
                        if (fecha.getDay() == 5) {
                            count--
                        }
                        fecha.setDate(fecha.getDate() + 1);
                    }
                }
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

function ObtenerDiasFeriados() {
    $.ajax({
        type: "post",
        url: "/Vacaciones/GetDiasFeriado",
        //data: { idTipo: idTipo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            if (data.success) {
                listaDiasFeriado= [];
                for (var i = 0; i < data.listado.length; i++) {
                    listaDiasFeriado.push(data.listado[i].Dia.toString().padStart(2, "0") + '/' + data.listado[i].Mes.toString().padStart(2, "0"));
                    //alert(listaDiasFeriado.length);
                }
            }
            else {
                alert(data.mensaje);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status == 500) {
                alert('Internal error: ' + jqXHR.responseText);
            } else {
                $('#Errores_Formulario').val(jqXHR.responseText);
                alert('Unexpected error.' + errorThrown);
            }
        }
        //error: function (err) {
        //    alert("Error");
        //}
    });
}