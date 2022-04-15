// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let listaDestinatariosId = [];
let listaDestinatariosNome = [];
let startRefreshCount = false;

function adicionarDestinatarioALista() {

   
    let destinatarioId = document.getElementById("destinatarioId").value;
    let destinatarioNome = document.getElementById("destinatarioId");

    destinatarioNome = destinatarioNome.options[destinatarioNome.selectedIndex].innerHTML;
    if (!listaDestinatariosId.includes(destinatarioId) && destinatarioId != -1) {

        listaDestinatariosId.push(destinatarioId);

        listaDestinatariosNome.push(destinatarioNome);
    }
    
    exibirDestinatariosNaTela();
}

function removerDestinatarioDaLista(posicaoRemover){
    listaDestinatariosId.splice(posicaoRemover, 1);
    listaDestinatariosNome.splice(posicaoRemover, 1);
    exibirDestinatariosNaTela();
}

function exibirDestinatariosNaTela() {

    let exibirDestinatariosSelecionados = document.getElementById("exibirDestinatariosSelecionados");
    let listaDeDestinatariosPorId = document.getElementById("listaDeDestinatariosPorId");
    let exibirDestinatariosSelecionadosConteudoHtml = "";
    let preencherListaDeDestinatarios = "";
    for (i = 0; i < listaDestinatariosNome.length; i++) {
        exibirDestinatariosSelecionadosConteudoHtml += `<div class="caixa-destinatario-lista">${listaDestinatariosNome[i]} <button type="button" onclick="removerDestinatarioDaLista(${i})">x</button></div>`;
        preencherListaDeDestinatarios += listaDestinatariosId[i] + ";";
    }
    exibirDestinatariosSelecionados.innerHTML = exibirDestinatariosSelecionadosConteudoHtml;
    listaDeDestinatariosPorId.value = preencherListaDeDestinatarios;
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

function verificarSeUsuarioSelecionouDestinatarios() {
    let selectListaDeDestinatariosPorId = document.getElementById("listaDeDestinatariosPorId").value;
    if (selectListaDeDestinatariosPorId == "") {
        window.alert("Selecionar ao menos um destinatário!")
    }
}



window.addEventListener('load', function () {
    jQrefresh();
    startRefreshCount = true;
})

var intervalId = setInterval(function () {
    jQrefresh();
}, 5000);

function jQrefresh() {
    document.getElementById("refreshPartial").click();
}

