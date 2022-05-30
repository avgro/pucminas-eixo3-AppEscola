// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var numeroDeAutorizacoes = "valor inicial";

// Manter posição da barra de rolagem em atualização automática
if (localStorage.getItem("scrollY")) {
    let scrollY = JSON.parse(localStorage.getItem("scrollY"));
    window.scrollTo({ top: scrollY, behavior: 'instant' });
    localStorage.removeItem("scrollY");
}

function mudarsecao() {
    let secao = document.getElementById("selecionar-secao");
    let secaoNome = secao.options[secao.selectedIndex].innerText;
    window.location.href = `/AutorizacoesEventos/?secao=${secaoNome}`;
}

var intervalCheckNewAutorizacoesId = setInterval(function () {
    var novoNumeroDeAutorizacoes = document.getElementById("autorizacaoUpdate").innerHTML;
    if (novoNumeroDeAutorizacoes != numeroDeAutorizacoes && numeroDeAutorizacoes != "valor inicial") {
        let scrollY = window.scrollY;
        localStorage.setItem("scrollY", JSON.parse(scrollY));
        document.getElementById("refreshConversas").click();
    }
    numeroDeAutorizacoes = document.getElementById("autorizacaoUpdate").innerHTML;
}, 1000);