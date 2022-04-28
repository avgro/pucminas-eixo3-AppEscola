// Manter posição da barra de rolagem em atualização automática

if (document.getElementById("disciplinasErrorMessage").innerText != "") {
    if (localStorage.getItem("scrollY")) {
        localStorage.removeItem("scrollY");
    }
    document.getElementById("disciplinasError").hidden = false;
}


if (localStorage.getItem("scrollY")) {
    let scrollY = JSON.parse(localStorage.getItem("scrollY"));
    window.scrollTo({ top: scrollY, behavior: 'instant' });
    localStorage.removeItem("scrollY");
}


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
