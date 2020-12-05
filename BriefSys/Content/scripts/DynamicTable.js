
function obtenerDatos(tipo, area, objeto, pluralizeUrl) {
    var xhr = new XMLHttpRequest();
    var url = "";
    if (pluralizeUrl) {
        url = "/" + area + "/Get" + objeto + "s/";
    } else {
        url = "/" + area + "/Get" + objeto + "/";
    }

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            callback(xhr.responseText, area, objeto);
        }
    }

    xhr.open(tipo, url)
    xhr.send();
}

function callback(response, area, objeto) {
    var data = JSON.parse(response);
    createTableFromJSON(data, area, objeto);
}

function createTableFromJSON(data, area, objeto) {
    var objTabla = data.data;

    /*--------------------------
     * Columnas/header de tabla
     *--------------------------*/
    var col = []; /*Arreglo para columnas*/

    for (var i = 0; i < objTabla.length; i++) {

        objTabla[i].Acciones = '<a class="btn btn-info">Detalles</a> <a class="btn btn-warning" href="/' + area + '/Edit' + objeto + '/' + objTabla[i].IdDepartamento + '">Editar</a> <a class="btn btn-danger" href="/' + area + '/Delete' + objeto + '/' + objTabla[i].IdDepartamento + '">Eliminar</a>';

        for (var key in objTabla[i]) { /*Key = Propiedad, se moverá en las propiedades del objeto JSON*/
            if (key != "Estado") {
                if (col.indexOf(key) === -1) { /*Detras de la ultima columna/propiedad*/
                    col.push(key);
                }
            }
        }
    }

    /*--------------------
     * Crear objeto tabla
     *--------------------*/
    var tablaDinamica = document.createElement("table");
    tablaDinamica.classList.add("table");
    tablaDinamica.classList.add("table-bordered");

    /*----------------------
     * Crear fila de header
     *----------------------*/
    var tr = tablaDinamica.insertRow(-1); /*Index -1 indica insertar una fila detras de la ultima*/

    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");
        th.innerHTML = col[i];
        th.id = i;
        th.addEventListener('click', function () { ordenarTabla(tablaDinamica, this) }, false);
        tr.appendChild(th);
    }

    /*----------------------------
     * Crear filas para los datos
     *----------------------------*/
    for (var i = 0; i < objTabla.length; i++) {
        tr = tablaDinamica.insertRow(-1);

        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1); /*Inserta detrás de la ultima celda*/
            tabCell.innerHTML = objTabla[i][col[j]];
        }
    }

    /*Añadir footer*/

    /*------------------------------
     * Añadir tabla a un contenedor
     *------------------------------*/
    var divTabla = document.getElementById('divTabla');
    divTabla.innerHTML = "";
    divTabla.appendChild(tablaDinamica);
    divTabla.classList.add('table');
    divTabla.classList.add('table-bordered');
}

/*----------------------------
 * Funcion para ordenar tabla
 *----------------------------*/
function ordenarTabla(tabla, n) {
    var table, rows, switching, x, y, i, shouldswitch, direction, switchcount = 0, th;
    th = n.id;

    var table = tabla;
    /*----------------
     * Activar cambio
     *----------------*/
    switching = true;

    direction = "asc";

    while (switching) {
        switching = false;

        rows = table.rows;

        /*---------------------------------------------
         * Primera fila contiene el header de la tabla
         *---------------------------------------------*/
        for (i = 1; i < (rows.length - 1); i++) {
            shouldswitch = false;

            /*-------------------------------------------------
             * Obtener elemento para comparar con el siguiente
             *-------------------------------------------------*/
            x = rows[i].getElementsByTagName("td")[th];
            y = rows[i + 1].getElementsByTagName("td")[th];

            if ((x !== undefined && y !== undefined)) {
                /*---------------------------------
                 * Evalua la dirección del sorting
                 *---------------------------------*/
                if (direction == "asc") {
                    /*----------------------------------------------------------
                     * Si el valor actual es mayor al siguiente, deberá sortear
                     *----------------------------------------------------------*/
                    if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                        shouldswitch = true;
                        break;
                    }
                } else if (direction == "desc") {
                    /*----------------------------------------------------------
                     * Si el valor actual es menor al siguiente, deberá sortear
                     *----------------------------------------------------------*/
                    if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                        shouldswitch = true;
                        break;
                    }
                }
            }
        }

        /*-------------------------------
         * Se detectó un valor a sortear
         *-------------------------------*/
        if (shouldswitch) {
            /*----------------------------------------------------------------
             * Inserta el valor siguiente en un nodo anterior al valor actual
             *----------------------------------------------------------------*/

            /*-------------------------------------------
             * insertBefore(Nuevo nodo, Nodo referencia)
             *-------------------------------------------*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++; /*Nos ayudara a identificar si ha sorteado*/
        } else {
            /*----------------------------------------------------------------------------------------------
             * Si no se ha realizado ningun sort y la dirección es ascendente, cambiaremos la direccion a desc y volveremos al loop
             *----------------------------------------------------------------------------------------------*/
            if (switchcount == 0 && direction == "asc") {
                direction = "desc";
                switching = true;
            }
        }
    }
}


//function contenedor() {
//    /*-----------------------------------------------
//         * Footer con count de valores y añadir registro
//         *-----------------------------------------------*/
//    var tr = tablaDinamica.insertRow(-1); /*Index -1 indica insertar una fila detras de la ultima*/
//    tr.id = "footer";
//    var tabCell = tr.insertCell(-1);
//    tr.style.textAlign = "right";
//    var propiedades = 0;
//    for (var key in objTabla[0]) {
//        if (key != "Estado") {
//            if (objTabla[0].hasOwnProperty(key)) {
//                propiedades++;
//            }
//        }
//    }
//tabCell.colSpan = propiedades; /*Numero de filas*/
//tabCell.innerHTML = '<button class="btn btn-success">Añadir departamento</button>';
//}