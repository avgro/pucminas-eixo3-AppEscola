// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var numeroDeMensagens = "valor inicial";

// Manter posição da barra de rolagem em atualização automática
if (localStorage.getItem("scrollY")) {
    let scrollY = JSON.parse(localStorage.getItem("scrollY"));
    window.scrollTo({ top: scrollY, behavior: 'instant' });
    localStorage.removeItem("scrollY");
}

function mudarsecao() {
    let secao = document.getElementById("selecionar-secao");
    let secaoNome = secao.options[secao.selectedIndex].innerText;
    window.location.href = `/Conversas/?secao=${secaoNome}`;
}

var intervalCheckNewMessagesId = setInterval(function () {
    var novoNumeroDeMensagens = document.getElementById("msgUpdate").innerHTML;
    if (novoNumeroDeMensagens != numeroDeMensagens && numeroDeMensagens != "valor inicial") {
        let scrollY = window.scrollY;
        localStorage.setItem("scrollY", JSON.parse(scrollY));
        document.getElementById("refreshConversas").click();
    }
    numeroDeMensagens = document.getElementById("msgUpdate").innerHTML;
}, 1000);