function addItem() {
    event.preventDefault();
    var tblBody = document.getElementById('tblOrdenBody');

    var Partida = $("#Orden_Detalle_Partida").val();
    var IdProducto = $("#Orden_Detalle_IdProducto").val();
    var Producto = $("#Orden_Detalle_Producto").val();
    var Cantidad = $("#Orden_Detalle_Cantidad").val();
    var UnidadInterna = $("#Orden_Detalle_UnidadInterna").val();
    var UnidadExterna = $("#Orden_Detalle_UnidadExterna").val();

    var itemOrden = "<tr><td>" + Partida + "</td><td>" + IdProducto + "</td><td>" + Producto + "</td><td>" + Cantidad + "</td><td>" + UnidadInterna + "</td><td>" + UnidadExterna + "</td><td><button class='btn btn-danger' onclick='removeItem(this)'>Remover</button></td></tr>";

    tblBody.innerHTML += itemOrden;
    limpiarDatos();
}

function removeItem(btn) {
    event.preventDefault();

    var row = btn.parentNode.parentNode;
    row.parentNode.removeChild(row);
}

function guardarOrden() {
    event.preventDefault();

    var listaOrdenes = [];
    listaOrdenes.length = 0;

    var orden_maestro;

    orden_maestro = {
        IdProveedor: $("#Orden_IdProveedor").val(),
        Proveedor: $("#Orden_Proveedor").val(),
        Moneda: $("#Orden_Moneda").val(),
        FechaEntrega: $("#Orden_FechaEntrega").val(),
        FechaElaboracion: $("#Orden_FechaElaboracion").val()
    };

    $.each($("#tblOrdenDetail tbody tr"), function () {
        listaOrdenes.push({
            Partida: $(this).find('td:eq(0)').html(),
            IdProducto: $(this).find('td:eq(1)').html(),
            Producto: $(this).find('td:eq(2)').html(),
            Cantidad: $(this).find('td:eq(3)').html(),
            UnidadInterna: $(this).find('td:eq(3)').html(),
            UnidadExterna: $(this).find('td:eq(3)').html(),
        });
    });

    var data = JSON.stringify({
        orden: orden_maestro,
        orden_detalle: listaOrdenes
    });

    enviarOrden(data);
}

function enviarOrden(data) {
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'POST',
        url: "/CMP/CreateOrden",
        data: data,
        success: function (result) {
            alert(result);
            location.reload();
        },
        error: function () {
            alert("Error!")
        }
    });
}

function limpiarDatos() {

    $("#Orden_Detalle_Partida").val('');
    $("#Orden_Detalle_IdProducto").val('');
    $("#Orden_Detalle_Producto").val('');
    $("#Orden_Detalle_Cantidad").val('');
    $("#Orden_Detalle_UnidadInterna").val('');
    $("#Orden_Detalle_UnidadExterna").val('');
}