// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Atualiza os contadores de mensagens e notificação a cada 5 segundos

// Inicializa o contador após o carregamento da página


window.addEventListener('load', function () {
    jQrefresh();
    var intervalId = setInterval(function () {
        jQrefresh();
    }, 5000);
})


// Atualiza o contador de mensagens
function jQrefresh() {
    document.getElementById("refreshPartial").click();
    document.getElementById("refreshPartialAutorizacao").click();
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

// Menu dropdown customizado (dropdown do Boostrap incompativel com Asp.Net.Core.MVC)

function showDropDown(dropdownButton, dropdownDiv) {
    if (dropdownDiv.hidden == true) {
        dropdownDiv.hidden = false;

    }
    else {
        dropdownDiv.hidden = true;
    }
    document.addEventListener('click', function (event) {
        const ignoreRefreshPartial = document.getElementById("refreshPartial");
        const ignoreRefreshPartialAutorizacao = document.getElementById("refreshPartialAutorizacao");
        if (!dropdownButton.contains(event.target) && !dropdownDiv.contains(event.target) && !ignoreRefreshPartial.contains(event.target) && !ignoreRefreshPartialAutorizacao.contains(event.target)) {
            dropdownDiv.hidden = true;
        }
    });

}

// ----------------------------------------------------------------------------- //

function limitarInputHoras(idInput) {
    if (idInput.value > 23) {
        idInput.value = 23;
    }
    if (idInput.value < 0) {
        idInput.value = 0;
    }
}

function limitarInputMinutos(idInput) {
    if (idInput.value > 59) {
        idInput.value = 59;
    }
    if (idInput.value < 0) {
        idInput.value = 0;
    }
}

function doisDigitosInputHorario(idInput) {
    if (idInput.value.length < 2) {
        idInput.value = "0" + idInput.value;
    }
    if (idInput.value == 0) {
        idInput.value = "00";
    }
    idInput.value = idInput.value.substring(idInput.value.length - 2, idInput.value.length);
}

function disableSubmitButtonAfterSubmission(idSubmitButton) {
    idSubmitButton.disabled = true;
    
}

function resetarDataAgenda() {
    if (localStorage.getItem("agendaParametros")) {
        localStorage.removeItem("agendaParametros");
    }
}