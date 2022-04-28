let counter = 0;
let counterHorario = 0;
let listarHorarios = "";
while (true) {
    counter++;
    let checarDisciplina = "nomeDisciplina" + counter;
    if (document.getElementById(checarDisciplina)) {
        counterHorario = 0;
        while (true) {
            counterHorario++;
            let checarHorarioDisciplina = "horarioDisciplina" + counter + "-" + counterHorario;
            if (document.getElementById(checarHorarioDisciplina)) {
                listarHorarios += document.getElementById(checarHorarioDisciplina).innerText + ";;";
            }
            else {
                break;
            }
        }
    }
    else {
        break;
    }
}

listarHorarios = listarHorarios.split(";;");

desenharCardsHorarios();

function desenharCardsHorarios() {
    let criarCardInnerHtml = "";

    for (i = 0; i < (listarHorarios.length - 1); i++) {
        separarElementosCardHorario = listarHorarios[i].split(";");
        /* separarElementosCardHorario[0] = Nome, separarElementosCardHorario[2] = dia da semana (domingo = 0, sabado = 6),
        /separarElementosCardHorario[3] = horario de inicio (HH:MM) separarElementosCardHorario[4] = horario do fim (HH:MM) */

        let separarHorarioInicio = separarElementosCardHorario[3].split(":");
        let horarioInicioEmMinutos = parseInt(separarHorarioInicio[0]) * 60 + parseInt(separarHorarioInicio[1]);
        let separarHorarioFim = separarElementosCardHorario[4].split(":");
        let horarioFimEmMinutos = parseInt(separarHorarioFim[0]) * 60 + parseInt(separarHorarioFim[1]);

        // Determinar posição do card baseado no dia e horário da disciplina
        let windowHeight = document.querySelector(".container-horarios").offsetHeight;
        let espacoOcupadoPeloLabelDeDiaDaSemana = 28;
        windowHeight -= espacoOcupadoPeloLabelDeDiaDaSemana;
        let windowWidth = document.getElementById("inserirCardsHorariosDisciplinas").offsetWidth;
        let marginLeft = 1 + separarElementosCardHorario[2] * windowWidth / 7;
        let width = windowWidth / 7 - 1;
        let marginTop = Math.round(horarioInicioEmMinutos * (windowHeight - 3) / 1440) + espacoOcupadoPeloLabelDeDiaDaSemana;
        let height = Math.round((horarioFimEmMinutos - horarioInicioEmMinutos) * windowHeight / 1440);
        if (height == 0) {
            height = 1;
        }

        criarCardInnerHtml += `
    <div class="cardHorarios" style="margin-left: ${marginLeft}px; margin-top: ${marginTop}px; height: ${height}px; width: ${width}px">

    </div>
    <div class="cardHorarios" style="margin-left: ${marginLeft}px; margin-top: ${marginTop}px; height: ${height}px; width: ${width}px">
    ${separarElementosCardHorario[0]}<br>
    (${separarElementosCardHorario[1]})<br>
    ${separarElementosCardHorario[3]} - ${separarElementosCardHorario[4]}
    </div>
    `
    }
    document.getElementById("inserirCardsHorariosDisciplinas").innerHTML = criarCardInnerHtml;
}

window.addEventListener("resize", changeWindowSize);

function changeWindowSize() {
    desenharCardsHorarios();
}