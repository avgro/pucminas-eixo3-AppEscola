// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var numeroDeMensagens = "valor inicial";

function mudarsecao() {
    let secao = document.getElementById("selecionar-secao");
    let secaoNome = secao.options[secao.selectedIndex].innerText;
    window.location.href = `/Conversas/?secao=${secaoNome}`;
}

var intervalCheckNewMessagesId = setInterval(function () {
    var novoNumeroDeMensagens = document.getElementById("msgupdate").innerHTML;
    if (novoNumeroDeMensagens != numeroDeMensagens && numeroDeMensagens != "valor inicial") {
        document.getElementById("refreshConversas").click();
    }
    numeroDeMensagens = document.getElementById("msgupdate").innerHTML;
}, 1000);