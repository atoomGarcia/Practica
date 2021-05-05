$(document).ready(function () {
    $("#tablaArticulos>tbody .borrar").on("click", function () {
        var tr = $(this).closest('tr');
        tr.css("background-color", "#FF3700");
        tr.fadeOut(400, function () {
            tr.remove();
        });
        return false;
    });
});

function AddRow() {
    var valorescliente="";
    if ($('#stock2').val() == "0") {
        Swal.fire(
            'ATENCIÓN!',
            'El artículo seleccionado no cuenta con existencia, favor de verificar !',
            'warning'
        )
    }
    else if ($('#stock2').val() > 0) {
        $("#tablaArticulos>tbody").append("<tr id='fila" + $('#id2').val() + "'><td>" + $('#id2').val() + "</td><td>" + $('#codigo2').val() + "</td><td>" + $('#desc2').val() + "</td><td>" + $('#nombre2').val() + "</td><td><input type='text' id='stock' value='1'/></td><td>" + $('#precio2').val() + "</td><td class='text-right importe'>" + $('#precio2').val() + "</td><td><button onclick='anular(" + $('#id2').val()+")' class='btn btn-danger'><span class='oi oi-delete'></span> </button ></td ></tr>");
        $('#idCliente2').val();
        valorescliente = $('#idCliente2').text();
        $('#idCliente3').val(valorescliente);
        sumar();
    }
    else {
        //$('#stock2').val()
        Swal.fire(
            'ATENCIÓN!',
            'Favor de seleccionar un articulo !',
            'warning'
        )
    }

}

function anular(id) {
    $("#fila" + id).remove();
    sumar();
    //$('fila' + id).remove();
}

function sumar() {
    var sum = 0;
    var enganche = 0;
    var bon = 0;
    var tot = 0;
    $('.importe').each(function () {
        sum += parseFloat($(this).text());
    });



    enganche = (20 / 100) * sum;
    bon = ((2.8 * 12) / 100);
    tot = (sum - enganche) - tot;
    $('#eng').val(enganche.toFixed(2));
    $('#bonif').val(bon.toFixed(2));
    $('#tot').val(tot.toFixed(2));
}

function GuardaVenta() {
    if ($('#stock2').val() == "0") {
        Swal.fire(
            'ATENCIÓN!',
            'El artículo seleccionado no cuenta con existencia, favor de verificar !',
            'warning'
        )
    }
    else {
        //$('#stock2').val()
        $("#tablaArticulos>tbody").append("<tr><td>" + $('#id2').val() + "</td><td>" + $('#codigo2').val() + "</td><td>" + $('#desc2').val() + "</td><td>" + $('#nombre2').val() + "</td><td><input type='text' id='stock' value='1'/></td><td>" + $('#precio2').val() + "</td><td class='text-right importe'>" + $('#precio2').val() + "</td><td><button id='btnDeleteArt' type='button' class='btn btn-danger' @onclick='deleteRow'><span class='oi oi-delete'></span> </button ></td ></tr>");
        sumar();
    }

}

function Mensaje() {
    Swal.fire(
        'Bien Hecho!',
        'Tu venta ha sido registrada correctamente !',
        'warning'
    )
}



function validaSig() {
    if ($('#idCliente').val() > 0 && $('#serie_comprobante').val() != "" && $('#num_comprobante').val() != "" && $('#tot').val() > 0 && $('#tot2').val() > 0) {
            var enganche = 0;
            var bon = 0;
            var tot = 0;
            var tot3 = 0;
            var tot6 = 0;
            var tot9 = 0;
            var tot12 = 0;
            var pag3 = 0;
            var pag6 = 0;
            var pag9 = 0;
            var pag12 = 0;

            var aho3 = 0;
            var aho6 = 0;
            var aho9 = 0;
            var aho12 = 0;

            enganche = $('#eng').val();
            bon = $('#bonif').val();
            tot = $('#tot').val();

            var tot3 = tot * ((1 + (2.8 * 3)) / 100);
            var tot6 = tot * ((1 + (2.8 * 6)) / 100);
            var tot9 = tot * ((1 + (2.8 * 9)) / 100);
            var tot12 = tot * ((1 + (2.8 * 12)) / 100);

            pag3 = tot / 3;
            pag6 = tot / 6;
            pag9 = tot / 9;
            pag12 = tot / 12;

            aho3 = tot12 - tot3;
            aho6 = tot12 - tot6;
            aho9 = tot12 - tot9;
            aho12 = tot12 - tot12;

            $('#3tot').text(tot3.toFixed(2));
            $('#6tot').text(tot6.toFixed(2));
            $('#9tot').text(tot9.toFixed(2));
            $('#12tot').text(tot12.toFixed(2));

            $('#3div').text(pag3.toFixed(2));
            $('#6div').text(pag6.toFixed(2));
            $('#9div').text(pag9.toFixed(2));
            $('#12div').text(pag12.toFixed(2));

            $('#3ahorro').text(aho3.toFixed(2));
            $('#6ahorro').text(aho6.toFixed(2));
            $('#9ahorro').text(aho9.toFixed(2));
            $('#12ahorro').text(aho12.toFixed(2));

            $('#card2').show(2000);
            $('#card3').show(3000);

    }
    else {
        Swal.fire(
            'ATENCIÓN!',
            'Los datos ingresados no son correctos, falta uno o mas elementos por ingresar, favor de verificar !',
            'warning'
        )
    }
}



