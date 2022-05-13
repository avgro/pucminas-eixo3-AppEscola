function formularioTrocar(idHide, idShow) {
    idHide.hidden = true;
    idShow.hidden = false;
    mostrarCampoPedirSenha();
}

function mostrarCampoPedirSenha() {
    document.getElementById("senhaNecessaria").hidden = false;
}

function trocarSenha() {
    document.getElementById("NovaSenha").required = true;
    document.getElementById("NovaSenhaRepetir").required = true;
}

function checarNovaSenhaRepetir() {
    if (document.getElementById("NovaSenha").value == document.getElementById("NovaSenhaRepetir").value) {
        document.getElementById("mensagemSenhasConferem").hidden = false;
        document.getElementById("mensagemSenhasNaoConferem").hidden = true;
    }
    else {
        document.getElementById("mensagemSenhasConferem").hidden = true;
        document.getElementById("mensagemSenhasNaoConferem").hidden = false;
    }

    if (document.getElementById("NovaSenha").value == "") {
        document.getElementById("NovaSenhaRepetir").value = ""
        document.getElementById("mensagemSenhasConferem").hidden = true;
        document.getElementById("mensagemSenhasNaoConferem").hidden = true;
    }
}
