// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let listaDestinatariosId = [];
let listaDestinatariosNome = [];

let startRefreshCount = false;


if (document.getElementById("validation-error")) {
    if (document.getElementById("validation-error").innerHTML.length > 0) {
        listaDestinatariosId = JSON.parse(localStorage.getItem("listaDestinatariosId"));
        listaDestinatariosNome = JSON.parse(localStorage.getItem("listaDestinatariosNome"));
        if (document.getElementById("tela-responder-mensagem") != null) {
            document.getElementById("tela-responder-mensagem").style.display = "block";
        }
    }
}

exibirDestinatariosNaTela()

function adicionarDestinatarioALista() {

   
    let destinatarioId = document.getElementById("destinatarioId").value;
    let destinatarioNome = document.getElementById("destinatarioId");

    destinatarioNome = destinatarioNome.options[destinatarioNome.selectedIndex].innerText;
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
    localStorage.setItem("listaDestinatariosId", JSON.stringify(listaDestinatariosId));
    localStorage.setItem("listaDestinatariosNome", JSON.stringify(listaDestinatariosNome));

    let exibirDestinatariosSelecionados = document.getElementById("exibirDestinatariosSelecionados");
    let listaDeDestinatariosPorId = document.getElementById("listaDeDestinatariosPorId");
    let exibirDestinatariosSelecionadosConteudoHtml = "";
    let preencherListaDeDestinatarios = "";
    for (i = 0; i < listaDestinatariosNome.length; i++) {
        exibirDestinatariosSelecionadosConteudoHtml += `<div class="caixa-itens-listados">${listaDestinatariosNome[i]} <button type="button" onclick="removerDestinatarioDaLista(${i})">x</button></div>`;
        preencherListaDeDestinatarios += listaDestinatariosId[i] + ";";
    }
    exibirDestinatariosSelecionados.innerHTML = exibirDestinatariosSelecionadosConteudoHtml;
    listaDeDestinatariosPorId.value = preencherListaDeDestinatarios;
    document.getElementById("listaDeDestinatariosPorId").onkeyup();
}
