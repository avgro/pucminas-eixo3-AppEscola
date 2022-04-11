// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let listaDestinatariosId = [];
let listaDestinatariosNome = [];

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
    document.getElementById("listaDeDestinatariosPorId").value = document.getElementsByClassName("listaDeDestinatariosPorId")[idMensagemASerRespondida].value;
    document.getElementById("listaDeDestinatariosPorNome").value = document.getElementsByClassName("listaDeDestinatariosPorNome")[idMensagemASerRespondida].value;
    document.getElementById("mensagemRespondidaId").value = document.getElementsByClassName("mensagemRespondidaId")[idMensagemASerRespondida].value;

    listaDestinatariosId = [];
    listaDestinatariosNome = [];

    let selectListaDeDestinatariosPorId = document.getElementById("listaDeDestinatariosPorId").value;
    let selectListaDeDestinatariosPorNome = document.getElementById("listaDeDestinatariosPorNome").value;
    if (selectListaDeDestinatariosPorId != null && selectListaDeDestinatariosPorNome != null) {
        var selectListaDeDestinatariosPorIdSplit = selectListaDeDestinatariosPorId.split(";");
        var selectListaDeDestinatariosPorNomeSplit = selectListaDeDestinatariosPorNome.split(";");
        for (i = 0; i < (selectListaDeDestinatariosPorIdSplit.length - 1); i++) {
            listaDestinatariosId[i] = selectListaDeDestinatariosPorIdSplit[i];
            listaDestinatariosNome[i] = selectListaDeDestinatariosPorNomeSplit[i];
        }

        document.getElementById("tela-responder-mensagem").style.display = "block";

        exibirDestinatariosNaTela();
    }
}

function fecharTelaDeResponderMensagem() {
    document.getElementById("tela-responder-mensagem").style.display = "none";
}