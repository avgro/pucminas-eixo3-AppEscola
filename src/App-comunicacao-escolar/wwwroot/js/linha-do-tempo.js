// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Manter posição da barra de rolagem em atualização automática
if (localStorage.getItem("scrollY")) {
    let scrollY = JSON.parse(localStorage.getItem("scrollY"));
    window.scrollTo({ top: scrollY, behavior: 'instant' });
    localStorage.removeItem("scrollY");
}

function manterScrollY() {
    let scrollY = window.scrollY;
    localStorage.setItem("scrollY", JSON.stringify(scrollY));
}

if (localStorage.getItem("scrollYFimDosComentarios")) {
    let idSelect = JSON.parse(localStorage.getItem("scrollYFimDosComentarios"));

    let fimDosComentariosDiv = document.getElementById(idSelect);
    let getDivScrollY = fimDosComentariosDiv.getBoundingClientRect();

    scrollY = getDivScrollY.y - window.innerHeight/1.5;

    window.scrollTo({ top: scrollY, behavior: 'instant' });
    localStorage.removeItem("scrollYFimDosComentarios");
}

function scrollYFimDosComentarios(id) {
    let idSelect = "fimDaSecaoDeComentarios" + id;
    localStorage.setItem("scrollYFimDosComentarios", JSON.stringify(idSelect));
}

