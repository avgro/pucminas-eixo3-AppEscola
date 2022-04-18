// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Atualiza os contadores de mensagens e notificação a cada 5 segundos

// Inicializa o contador após o carregamento da página


window.addEventListener('load', function () {
    jQrefresh();
})

var intervalId = setInterval(function () {

    jQrefresh();

}, 5000);

// Atualiza o contador de mensagens
function jQrefresh() {
    document.getElementById("refreshPartial").click();
}

// Suporte à validação customizada. Esconde mensagens de erro ao digitar valor nos campos a serem validados.
function checkError(elementInput, divErrorMessage) {
    if (elementInput.value == "") {
        divErrorMessage.hidden = false;
    }
    else {
        divErrorMessage.hidden = true;
    }
    if (elementInput.type == "file") {
        divErrorMessage.hidden = true;
    }
}