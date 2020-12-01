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
    console.log(response);
    var obj = JSON.parse(response);
    createTableFromJSON(obj);
}

function createTableFromJSON(data) {
    console.log(data.data);

    /*Crear las columnas*/
}
