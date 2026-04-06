let fondoActivo = false;

function agregar() {
    const lista = document.getElementById("lista");
    const cantidadElementos = lista.getElementsByTagName("li").length;

    const nuevoElemento = document.createElement("li");
    nuevoElemento.textContent = "Elemento" + (cantidadElementos + 1);

    lista.appendChild(nuevoElemento);
}

function cambiarFondo() {
    if (fondoActivo) {
        document.body.style.backgroundColor = "#b3d4ff";
    } else {
        document.body.style.backgroundColor = "#b3d4ff";
    }

    fondoActivo = !fondoActivo;
}

function borrar() {
    const lista = document.getElementById("lista");
    const elementos = lista.getElementsByTagName("li");

    if (elementos.length > 0) {
        lista.removeChild(elementos[elementos.length - 1]);
    }
}