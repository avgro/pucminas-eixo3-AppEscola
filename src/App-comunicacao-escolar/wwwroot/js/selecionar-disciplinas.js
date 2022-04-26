//destinatarioNome = destinatarioNome.options[destinatarioNome.selectedIndex].innerText;

function selecionarDisciplina() {
    let selectedIndex = document.getElementById("disciplinasId").selectedIndex;
    let nomeDisciplina = document.getElementById("disciplinasId").options[selectedIndex].innerText;
    let idDisciplina = document.getElementById("disciplinasId").options[selectedIndex].value;
    document.getElementById("adicionarDisciplinasList").value = idDisciplina;
    document.getElementById("adicionarOuRemover").value = "adicionar";
    document.getElementById("botaoSubmeter").click();
}

function removerDisciplina(idDisciplina) {
    document.getElementById("adicionarDisciplinasList").value = idDisciplina;
    document.getElementById("adicionarOuRemover").value = "remover";
    document.getElementById("botaoSubmeter").click();
}
