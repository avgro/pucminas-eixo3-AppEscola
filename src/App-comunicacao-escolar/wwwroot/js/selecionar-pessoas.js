// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


listaPessoasId = [];
let listaPessoasNome = [];

try {
    let listaRecuperarInformacoes = document.getElementById("recuperarInformacoesPessoasListadas").innerHTML;
    listaRecuperarInformacoes = listaRecuperarInformacoes.split(";;");
    listaPessoasId = listaRecuperarInformacoes[0];
    listaPessoasNome = listaRecuperarInformacoes[1];
    listaPessoasId = listaPessoasId.split(";");
    listaPessoasNome = listaPessoasNome.split(";");
    listaPessoasId = listaPessoasId.splice(0, listaPessoasId.length - 1);
    listaPessoasNome = listaPessoasNome.splice(0, listaPessoasNome.length - 1);
}
catch {
    
}

if (document.getElementById("validation-error")) {
    if (document.getElementById("validation-error").innerHTML.length > 0) {
        listaPessoasId = JSON.parse(localStorage.getItem("listaPessoasId"));
        listaPessoasNome = JSON.parse(localStorage.getItem("listaPessoasNome"));
        if (document.getElementById("tela-responder-mensagem") != null) {
            document.getElementById("tela-responder-mensagem").style.display = "block";
        }
    }
}

exibirListaDePessoasNaTela()

function adicionarPessoaNaLista() {

   
    let pessoaId = document.getElementById("pessoaId").value;
    let pessoaNome = document.getElementById("pessoaId");

    if (pessoaId > 0) {
        pessoaNome = pessoaNome.options[pessoaNome.selectedIndex].innerText;
        if (!listaPessoasId.includes(pessoaId) && pessoaId != -1) {

            listaPessoasId.push(pessoaId);

            listaPessoasNome.push(pessoaNome);
        }

        exibirListaDePessoasNaTela();
    }
    else {
        document.getElementById("pessoaId").focus();
    }
}

function removerPessoaDaLista(posicaoRemover){
    listaPessoasId.splice(posicaoRemover, 1);
    listaPessoasNome.splice(posicaoRemover, 1);
    exibirListaDePessoasNaTela();
}

function exibirListaDePessoasNaTela() {
    localStorage.setItem("listaPessoasId", JSON.stringify(listaPessoasId));
    localStorage.setItem("listaPessoasNome", JSON.stringify(listaPessoasNome));

    let exibirPessoasSelecionadas = document.getElementById("exibirPessoasSelecionadas");
    let listaDePessoasPorId = document.getElementById("listaDePessoasPorId");
    let exibirPessoasSelecionadasConteudoHtml = "";
    let preencherListaDePessoas = "";
    for (i = 0; i < listaPessoasNome.length; i++) {
        exibirPessoasSelecionadasConteudoHtml += `<div class="caixa-itens-listados"><div class="caixa-itens-listados-texto">${listaPessoasNome[i]}</div> <button type="button" class="btn-transparent" onclick="removerPessoaDaLista(${i})"><i class="bi bi-x-square bi-1halfx"></i></button></div>`;
        preencherListaDePessoas += listaPessoasId[i] + ";";
    }
    exibirPessoasSelecionadas.innerHTML = exibirPessoasSelecionadasConteudoHtml;
    listaDePessoasPorId.value = preencherListaDePessoas;
    document.getElementById("listaDePessoasPorId").onkeyup();
}
