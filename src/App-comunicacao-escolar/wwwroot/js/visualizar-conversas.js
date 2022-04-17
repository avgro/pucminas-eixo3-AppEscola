// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if (localStorage.getItem("postagemRealizada")) {
    window.scrollTo(0, document.body.scrollHeight);
    localStorage.removeItem("postagemRealizada");
}

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
    transferirListaDeDestinatariosId = document.getElementsByClassName("remetenteId")[idMensagemASerRespondida].value + ";" + transferirListaDeDestinatariosId;
    document.getElementById("listaDeDestinatariosPorId").value = transferirListaDeDestinatariosId;

    let transferirListaDeDestinatariosNome = document.getElementsByClassName("listaDeDestinatariosPorNome")[idMensagemASerRespondida].value;
    transferirListaDeDestinatariosNome = document.getElementsByClassName("remetenteNome")[idMensagemASerRespondida].value + "; " + transferirListaDeDestinatariosNome;
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

        exibirDestinatariosNaTela();
    }
}

function validarSubmissaoDeResposta() {
    let okToSubmit = true;
    let selectListaDeDestinatariosPorId = document.getElementById("listaDeDestinatariosPorId").value;
    if (selectListaDeDestinatariosPorId == "") {
        okToSubmit = false;
        window.alert("Selecionar ao menos um destinatário!")
    }
    let selectListaDeAnexos = document.getElementById("arquivos");
    let tamanhoListaDeAnexosEmBytes = 0;
    for (i = 0; i < selectListaDeAnexos.files.length; i++) {
        tamanhoListaDeAnexosEmBytes += selectListaDeAnexos.files[i].size;
    }
    if (tamanhoListaDeAnexosEmBytes > 25000000) {
        okToSubmit = false;
        window.alert("Tamanho dos arquivos excede o valor máximo de 25 MB!");
    }
    if (okToSubmit) {
        localStorage.setItem("postagemRealizada", "ok");
        okToSubmit = true;
        document.getElementById("botao-submit-resposta").click();
    }
}
