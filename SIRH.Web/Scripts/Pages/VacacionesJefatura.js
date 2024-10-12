function check_text(input) {
    if (input.validity.patternMismatch) {
        input.setCustomValidity("Debe ingresar 10 dígitos y Solo números");
    }
    else {
        input.setCustomValidity("");
    }
}



function MostrarMensaje(mensaje) {
    $('#idMensaje').val(mensaje);
    $('#mostrar-mensaje').appendTo('body');
    $('#mostrar-mensaje').modal('show');
}

//$("#dialog-jefe").button({
//    label: 'Buscar por Jefatura',
//    text: false
//})

$("#clean-jefe").button({
    label: 'Limpiar búsqueda',
    text: false
}).click(function () {
    $('#codjefe').val('');
})

function CargarDato(funcionario) {
    $('#codFuncionario').val(funcionario);
    $("#buscar-jefe").appendTo("body");
    $('#buscar-jefe').modal('show');
    return false;
}


function ActualizarJefe(idJefe, nomJefe) {
    $('#buscar-jefe').modal('hide');
    var funcionario = $('#codFuncionario').val();
    //alert(funcionario);
    $.ajax({
        type: "post",
        url: "/Vacaciones/AsignarJefatura",
        data: { idFuncionario: funcionario, idJefatura: idJefe },
        datatype: "json",
        traditional: true,
        success: function (data) {
            if (data.success) {
                var cedula = $('#cedula').val();
                var cedulaJefe = $('#cedulaJefe').val();
                var coddivision = $('#coddivision').val();
                var coddireccion = $('#coddireccion').val();
                var coddepartamento = $('#coddepartamento').val();
                var codseccion = $('#codseccion').val();

                $.ajax({
                    type: "post",
                    url: "/Vacaciones/ListFuncionario",
                    data: {
                        cedula: cedula, cedulaJefe: cedulaJefe,
                        coddivision: coddivision, coddireccion: coddireccion, coddepartamento: coddepartamento,
                        codseccion: codseccion
                    },
                    datatype: "json",
                    traditional: true,
                    success: function (result) {
                        $('#target').html(result);
                    },
                    error: function (err) {
                        //alert("Error");
                    }
                });
            }
            else {
                //alert(data.mensaje);
            }
        },
        error: function (err) {
            //alert("Error");
        }
    });
    //$('#cod-jefe').val(idJefe + '' + nomJefe);
    return false;
}

function EliminarJefe(idFuncionario) {
    $.ajax({
        type: "post",
        url: "/Vacaciones/AsignarJefatura",
        data: { idFuncionario: idFuncionario, idJefatura: 0 },
        datatype: "json",
        traditional: true,
        success: function (data) {
            if (data.success) {
                var cedula = $('#cedula').val();
                var cedulaJefe = $('#cedulaJefe').val();
                var coddivision = $('#coddivision').val();
                var coddireccion = $('#coddireccion').val();
                var coddepartamento = $('#coddepartamento').val();
                var codseccion = $('#codseccion').val();

                $.ajax({
                    type: "post",
                    url: "/Vacaciones/ListFuncionario",
                    data: {
                        cedula: cedula, cedulaJefe: cedulaJefe,
                        coddivision: coddivision, coddireccion: coddireccion, coddepartamento: coddepartamento,
                        codseccion: codseccion
                    },
                    datatype: "json",
                    traditional: true,
                    success: function (result) {
                        alert('Se eliminó la asignación de la Jefatura');
                        $('#target').html(result);
                    },
                    error: function (err) {
                        //alert("Error");
                    }
                });
            }
            else {
                //alert(data.mensaje);
            }
        },
        error: function (err) {
            //alert("Error");
        }
    });
    //$('#cod-jefe').val(idJefe + '' + nomJefe);
    return false;
}
function BeginCargarFuncionario() {
    $('#btnBuscar').css("display", "none");
    $("#preloader").css("display", "block");
}

