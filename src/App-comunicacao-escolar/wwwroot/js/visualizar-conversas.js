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
    document.getElementById("listaDePessoasPorId").value = transferirListaDeDestinatariosId;

    let transferirListaDeDestinatariosNome = document.getElementsByClassName("remetenteNome")[idMensagemASerRespondida].value + "; ";
    document.getElementById("listaDePessoasPorNome").value = transferirListaDeDestinatariosNome;

    document.getElementById("mensagemRespondidaId").value = document.getElementsByClassName("mensagemRespondidaId")[idMensagemASerRespondida].value;

    copiarValoresDaPaginaParaAsListasJavascript();
}

function abrirTelaDeResponderMensagemParaTodosOsParticipantes(idMensagemASerRespondida, idRemetente = -1) {
    let transferirListaDeDestinatariosId = document.getElementsByClassName("listaDePessoasPorId")[idMensagemASerRespondida].value;
    transferirListaDeDestinatariosId = document.getElementsByClassName("remetenteId")[idMensagemASerRespondida].value.replaceAll(";", ":") + ";" + transferirListaDeDestinatariosId;
    document.getElementById("listaDePessoasPorId").value = transferirListaDeDestinatariosId;

    let transferirListaDeDestinatariosNome = document.getElementsByClassName("listaDePessoasPorNome")[idMensagemASerRespondida].value;
    transferirListaDeDestinatariosNome = document.getElementsByClassName("remetenteNome")[idMensagemASerRespondida].value.replaceAll(";", ":") + "; " + transferirListaDeDestinatariosNome;
    document.getElementById("listaDePessoasPorNome").value = transferirListaDeDestinatariosNome;

    document.getElementById("mensagemRespondidaId").value = document.getElementsByClassName("mensagemRespondidaId")[idMensagemASerRespondida].value;

    copiarValoresDaPaginaParaAsListasJavascript(idRemetente);
}

function fecharTelaDeResponderMensagem() {
    document.getElementById("tela-responder-mensagem").style.display = "none";
}

function copiarValoresDaPaginaParaAsListasJavascript(idRemetente = -1) {
    listaPessoasId = [];
    listaPessoasNome = [];

    let selectlistaDePessoasPorId = document.getElementById("listaDePessoasPorId").value;
    let selectlistaDePessoasPorNome = document.getElementById("listaDePessoasPorNome").value;
    if (selectlistaDePessoasPorId != null && selectlistaDePessoasPorNome != null) {
        let selectlistaDePessoasPorIdSplit = selectlistaDePessoasPorId.split(";");
        let selectlistaDePessoasPorNomeSplit = selectlistaDePessoasPorNome.split(";");
        let remetentePresenteNosDestinatarios = false;
        for (i = 0; i < (selectlistaDePessoasPorIdSplit.length - 1); i++) {
            if (selectlistaDePessoasPorIdSplit[i+1] == idRemetente) {
                remetentePresenteNosDestinatarios = true;
            }
            listaPessoasId[i] = selectlistaDePessoasPorIdSplit[i];
            listaPessoasNome[i] = selectlistaDePessoasPorNomeSplit[i];
        }
        if (remetentePresenteNosDestinatarios) {
            removerPessoaDaLista(0);
        }
        document.getElementById("tela-responder-mensagem").style.display = "block";

        document.getElementById("conteudoMensagem").focus();

        exibirListaDePessoasNaTela();
    }
}

function postagemRealizada() {
    let scrollY = window.scrollY;
    localStorage.setItem("scrollY", JSON.stringify(scrollY));
}

