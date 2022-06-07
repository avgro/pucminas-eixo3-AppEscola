// Manter posição da barra de rolagem em atualização automática

if (localStorage.getItem("scrollY")) {
    let scrollY = JSON.parse(localStorage.getItem("scrollY"));
    window.scrollTo({ top: scrollY, behavior: 'instant' });
    localStorage.removeItem("scrollY");
}

function manterScrollY() {
    let scrollY = window.scrollY;
    localStorage.setItem("scrollY", JSON.stringify(scrollY));
}

function mudarAgenda() {
    let url = new URL(window.location.href);
    let urlSplit = url.toString().split("?");
    let params = "";
    if (urlSplit[1] != undefined) {
        params = "?" + urlSplit[1];
    }

    let agendaSelect = document.getElementById("selecionar-agenda");
    let agendaId = agendaSelect.options[agendaSelect.selectedIndex].value;
    let agendaNome = agendaSelect.options[agendaSelect.selectedIndex].innerText;
    window.location.href = `/Agendas/Visualizar/${agendaId}${params}`;
}

function guardarParametros() {
    let url = new URL(window.location.href);
    let urlSplit = url.toString().split("?");
    let params = "";
    if (urlSplit[1] != undefined) {
        params = "?" + urlSplit[1];
    }
    localStorage.setItem("agendaParametros", params)
}

if (localStorage.getItem("agendaParametros")) {
    let url = new URL(window.location.href);
    parametrosGuardados = localStorage.getItem("agendaParametros");
    window.location.href = url + parametrosGuardados;
    localStorage.removeItem("agendaParametros");
}