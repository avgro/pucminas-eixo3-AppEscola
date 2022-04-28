//destinatarioNome = destinatarioNome.options[destinatarioNome.selectedIndex].innerText;

var url = new URL(window.location.href);
var tentarAssociarDisciplina = url.searchParams.get("tentarAssociarDisciplina");




window.addEventListener('load', function () {
    if (tentarAssociarDisciplina > 0) {
        selecionarDisciplina(tentarAssociarDisciplina);
    }
})


function selecionarDisciplina(tentarAssociarDisciplina = 0) {
    let selectedIndex = document.getElementById("disciplinasId").selectedIndex;
    let idDisciplina;
    if (tentarAssociarDisciplina > 0) {
        idDisciplina = tentarAssociarDisciplina;
    }
    else {
        idDisciplina = document.getElementById("disciplinasId").options[selectedIndex].value;
    }
    if (idDisciplina > 0) {
        document.getElementById("numeroDaDisciplinaQueDesejaAdicionar").value = idDisciplina;
        document.getElementById("adicionarOuRemover").value = "adicionar";
        let scrollY = window.scrollY;
        localStorage.setItem("scrollY", JSON.parse(scrollY));
        document.getElementById("botaoSubmeter").click();
    }
    else {
        document.getElementById("disciplinasId").focus();
    }
}

function removerDisciplina(idDisciplina) {
    document.getElementById("numeroDaDisciplinaQueDesejaAdicionar").value = idDisciplina;
    document.getElementById("adicionarOuRemover").value = "remover";
    let scrollY = window.scrollY;
    localStorage.setItem("scrollY", JSON.parse(scrollY));
    document.getElementById("botaoSubmeter").click();
}

function hideDisciplinasError() {
    document.getElementById("disciplinasError").hidden = true;
}