function mudarAgenda() {
    let url = new URL(window.location.href);
    let urlSplit = url.toString().split("?");
    let params = "";
    if (urlSplit[1] != undefined) {
        params = "?" + urlSplit[1];
    }

    let agendaSelect = document.getElementById("AgendaId");
    let agendaId = agendaSelect.options[agendaSelect.selectedIndex].value;
    let agendaNome = agendaSelect.options[agendaSelect.selectedIndex].innerText;
    window.location.href = `/EventosDaAgenda/Create/${agendaId}${params}`;
}