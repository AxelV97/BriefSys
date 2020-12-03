asycData();

function asycData() {

    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            callback(xhr.responseText);
        }
    }

    xhr.open('GET', '/RH/GetDepartamentos/')
    xhr.send();
}

function callback(response) {
    var obj = JSON.parse(response);
    createTableFromJSON(obj);
}

function createTableFromJSON(data) {
    var objTabla = data.data;

    /*--------------------------
     * Columnas/header de tabla
     *--------------------------*/
    var col = []; /*Arreglo para columnas*/

    for (var i = 0; i < objTabla.length; i++) {

        objTabla[i].Acciones = '<button class="btn btn-info">Detalles</button> <button class="btn btn-warning">Editar</button> <button class="btn btn-danger">Eliminar</button>';

        for (var key in objTabla[i]) { /*Key = Propiedad, se moverá en las propiedades del objeto JSON*/
            if (key !== "Estado") {
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

    /*----------------------
     * Crear fila de header
     *----------------------*/
    var tr = tablaDinamica.insertRow(-1); /*Index -1 indica insertar una fila detras de la ultima*/

    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");
        th.innerHTML = col[i];
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

    /*-----------------------------------------------
     * Footer con count de valores y añadir registro
     *-----------------------------------------------*/
    var tr = tablaDinamica.insertRow(-1); /*Index -1 indica insertar una fila detras de la ultima*/
    var tabCell = tr.insertCell(-1);
    tr.style.textAlign = "right";
    tabCell.colSpan = Object.keys(objTabla).length; /*Numero de filas*/
    tabCell.innerHTML = '<button class="btn btn-success">Añadir departamento</button>';

    /*------------------------------
     * Añadir tabla a un contenedor
     *------------------------------*/
    var divTabla = document.getElementById('divTabla');
    divTabla.innerHTML = "";
    divTabla.appendChild(tablaDinamica);
    divTabla.classList.add('table');
    divTabla.classList.add('table-bordered');
}
