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
    console.log(data);

    var aux = document.getElementById('seccionAux');
    var objetonuevo = data.data[0];
    console.log(objetonuevo.Descripcion);

    /*Crear las columnas*/
}
