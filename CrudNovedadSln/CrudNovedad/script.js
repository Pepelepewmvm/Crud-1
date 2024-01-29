// wwwroot/script.js
document.addEventListener("DOMContentLoaded", function () {
    cargarTiposNov();

    // Manejar la creación o actualización de un tipo de novedad
    document.getElementById("tipoNovForm").addEventListener("submit", function (event) {
        event.preventDefault();
        crearActualizarTipoNov();
    });
});

async function cargarTiposNov() {
    const response = await fetch("/api/TipoNov");
    const tiposNov = await response.json();

    const listaTipoNov = document.getElementById("listaTipoNov");
    listaTipoNov.innerHTML = "";

    tiposNov.forEach(tipoNov => {
        const listItem = document.createElement("li");
        listItem.textContent = tipoNov.tipo;
        listaTipoNov.appendChild(listItem);
    });
}

async function crearActualizarTipoNov() {
    const tipoNovForm = document.getElementById("tipoNovForm");
    const formData = new FormData(tipoNovForm);
    const tipoNovData = {};

    formData.forEach((value, key) => {
        tipoNovData[key] = value;
    });

    const method = tipoNovData.id ? "PUT" : "POST";
    const url = tipoNovData.id ? `/api/TipoNov/${tipoNovData.id}` : "/api/TipoNov";

    const response = await fetch(url, {
        method: method,
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(tipoNovData)
    });

    if (response.ok) {
        cargarTiposNov();
        tipoNovForm.reset();
    }
}
