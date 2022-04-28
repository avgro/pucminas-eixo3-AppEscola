// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Manter posição da barra de rolagem em atualização automática
if (localStorage.getItem("scrollY")) {


    let scrollY = JSON.parse(localStorage.getItem("scrollY"));
    window.scrollTo({ top: scrollY, behavior: 'instant' });
}

window.addEventListener('load', function () {

    if (localStorage.getItem("scrollY")) {
        if (!document.getElementById("validation-error")) {
            let scrollY = document.body.scrollHeight;
            window.scrollTo({ top: scrollY, behavior: 'instant' });
        }
    }
    localStorage.removeItem("scrollY");
})



function abrirTelaDeResponderMensagem(idMensagemASerRespondida) {
    let transferirListaDeDestinatariosId = document.getElementsByClassName("remetenteId")[idMensagemASerRespondida].value + ";";
    document.getElementById("listaDeDestinatariosPorId").value = transferirListaDeDestinatariosId;

    let transferirListaDeDestinatariosNome = document.getElementsByClassName("remetenteNome")[idMensagemASerRespondida].value + "; ";
    document.getElementById("listaDeDestinatariosPorNome").value = transferirListaDeDestinatariosNome;

    document.getElementById("mensagemRespondidaId").value = document.getElementsByClassName("mensagemRespondidaId")[idMensagemASerRespondida].value;

    copiarValoresDaPaginaParaAsListasJavascript();
}

function abrirTelaDeResponderMensagemParaTodosOsParticipantes(idMensagemASerRespondida, idRemetente = -1) {
    let transferirListaDeDestinatariosId = document.getElementsByClassName("listaDeDestinatariosPorId")[idMensagemASerRespondida].value;
    transferirListaDeDestinatariosId = document.getElementsByClassName("remetenteId")[idMensagemASerRespondida].value.replaceAll(";", ":") + ";" + transferirListaDeDestinatariosId;
    document.getElementById("listaDeDestinatariosPorId").value = transferirListaDeDestinatariosId;

    let transferirListaDeDestinatariosNome = document.getElementsByClassName("listaDeDestinatariosPorNome")[idMensagemASerRespondida].value;
    transferirListaDeDestinatariosNome = document.getElementsByClassName("remetenteNome")[idMensagemASerRespondida].value.replaceAll(";", ":") + "; " + transferirListaDeDestinatariosNome;
    document.getElementById("listaDeDestinatariosPorNome").value = transferirListaDeDestinatariosNome;

    document.getElementById("mensagemRespondidaId").value = document.getElementsByClassName("mensagemRespondidaId")[idMensagemASerRespondida].value;

    copiarValoresDaPaginaParaAsListasJavascript(idRemetente);
}

function fecharTelaDeResponderMensagem() {
    document.getElementById("tela-responder-mensagem").style.display = "none";
}

function copiarValoresDaPaginaParaAsListasJavascript(idRemetente = -1) {
    listaDestinatariosId = [];
    listaDestinatariosNome = [];

    let selectListaDeDestinatariosPorId = document.getElementById("listaDeDestinatariosPorId").value;
    let selectListaDeDestinatariosPorNome = document.getElementById("listaDeDestinatariosPorNome").value;
    if (selectListaDeDestinatariosPorId != null && selectListaDeDestinatariosPorNome != null) {
        let selectListaDeDestinatariosPorIdSplit = selectListaDeDestinatariosPorId.split(";");
        let selectListaDeDestinatariosPorNomeSplit = selectListaDeDestinatariosPorNome.split(";");
        let remetentePresenteNosDestinatarios = false;
        for (i = 0; i < (selectListaDeDestinatariosPorIdSplit.length - 1); i++) {
            if (selectListaDeDestinatariosPorIdSplit[i+1] == idRemetente) {
                remetentePresenteNosDestinatarios = true;
            }
            listaDestinatariosId[i] = selectListaDeDestinatariosPorIdSplit[i];
            listaDestinatariosNome[i] = selectListaDeDestinatariosPorNomeSplit[i];
        }
        if (remetentePresenteNosDestinatarios) {
            removerDestinatarioDaLista(0);
        }
        document.getElementById("tela-responder-mensagem").style.display = "block";

        document.getElementById("conteudoMensagem").focus();

        exibirDestinatariosNaTela();
    }
}

function postagemRealizada() {
    let scrollY = window.scrollY;
    localStorage.setItem("scrollY", JSON.stringify(scrollY));
}

