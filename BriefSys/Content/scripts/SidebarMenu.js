﻿document.addEventListener("DOMContentLoaded", function (event) {

    var btnColapsar = document.getElementById('sidebarCollapse');

    btnColapsar.addEventListener('click', function () {
        var sidebar = document.getElementById('sidebar');
        console.log(sidebar);
        sidebar.classList.toggle('active');
    }, false);

});