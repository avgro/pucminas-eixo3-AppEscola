
if (document.getElementById("validation-error")) {
    if (document.getElementById("validation-error").innerHTML.length > 0) {
        let horarioInicioLista = JSON.parse(localStorage.getItem("horarioInicioLista"));
        let horarioFimLista = JSON.parse(localStorage.getItem("horarioFimLista"));
        let diaDaSemanaLista = JSON.parse(localStorage.getItem("diaDaSemanaLista"));
        let diaDaSemanaListaNumber = JSON.parse(localStorage.getItem("diaDaSemanaListaNumber"));

        document.getElementById("horarioInicioLista").value = horarioInicioLista;
        document.getElementById("horarioFimLista").value = horarioFimLista;
        document.getElementById("diaDaSemanaLista").value = diaDaSemanaLista;
        document.getElementById("diaDaSemanaListaNumber").value = diaDaSemanaListaNumber;
    }  
}

desenharHorariosAula();

function adicionarHorarioAula() {
    let horasInicio = document.getElementById("horasInicio").value;
    let minutosInicio = document.getElementById("minutosInicio").value;

    if (horasInicio == "" || horasInicio < 0) {
        horasInicio = "0";
    } if (minutosInicio == "" || minutosInicio < 0) {
        minutosInicio = "0";
    }

    if (horasInicio > 23) {
        horasInicio = "23";
    } if (minutosInicio > 59) {
        minutosInicio = "59";
    }

    if (horasInicio.length < 2) {
        horasInicio = "0" + horasInicio;
    }
    if (minutosInicio.length < 2) {
        minutosInicio = "0" + minutosInicio;
    }

    horasInicio = horasInicio.substring(0, 2);
    minutosInicio = minutosInicio.substring(0, 2);

    let horarioInicio = horasInicio + ":" + minutosInicio + ";";

    let horasFim = document.getElementById("horasFim").value;
    let minutosFim = document.getElementById("minutosFim").value;

    if (horasFim == "" || horasFim < 0) {
        horasFim = "0";
    } if (minutosFim == "" || minutosFim < 0) {
        minutosFim = "0";
    }

    if (horasFim > 23) {
        horasFim = "23";
    } if (minutosFim > 59) {
        minutosFim = "59";
    }

    if (horasFim.length < 2) {
        horasFim = "0" + horasFim;
    }
    if (minutosFim.length < 2) {
        minutosFim = "0" + minutosFim;
    }

    horasFim = horasFim.substring(0, 2);
    minutosFim = minutosFim.substring(0, 2);

    let horarioFim = horasFim + ":" + minutosFim + ";";

    let diaDaSemanaSelect = document.getElementById("diaDaSemana");
    let diaDaSemana = diaDaSemanaSelect.options[diaDaSemanaSelect.selectedIndex].innerText;
    let diaDaSemanaNumber = diaDaSemanaSelect.selectedIndex;

    

    if (diaDaSemana == "") {
        diaDaSemana = "Domingo";
    }
    if (diaDaSemanaNumber == "") {
        diaDaSemanaNumber = "0";
    }

    diaDaSemana = diaDaSemana + ";";
    diaDaSemanaNumber = diaDaSemanaNumber + ";";

    document.getElementById("horarioInicioLista").value += horarioInicio;
    document.getElementById("horarioFimLista").value += horarioFim;
    document.getElementById("diaDaSemanaLista").value += diaDaSemana;
    document.getElementById("diaDaSemanaListaNumber").value += diaDaSemanaNumber;

    desenharHorariosAula();
}

function desenharHorariosAula() {
    let horarioInicioLista = document.getElementById("horarioInicioLista").value;  
    let horarioFimLista = document.getElementById("horarioFimLista").value;
    let diaDaSemanaLista = document.getElementById("diaDaSemanaLista").value;
    let diaDaSemanaListaNumber = document.getElementById("diaDaSemanaListaNumber").value;

    localStorage.setItem("horarioInicioLista", JSON.stringify(horarioInicioLista));
    localStorage.setItem("horarioFimLista", JSON.stringify(horarioFimLista));
    localStorage.setItem("diaDaSemanaLista", JSON.stringify(diaDaSemanaLista));
    localStorage.setItem("diaDaSemanaListaNumber", JSON.stringify(diaDaSemanaListaNumber));

    horarioInicioLista = horarioInicioLista.split(";");
    horarioFimLista = horarioFimLista.split(";");
    diaDaSemanaLista = diaDaSemanaLista.split(";");

    let mostrarHorariosAulas = "";
    if (horarioInicioLista.length != horarioFimLista.length || horarioInicioLista.length != diaDaSemanaLista.length) {
        document.getElementById("horarioInicioLista").value = "";
        document.getElementById("horarioFimLista").value = "";
        document.getElementById("diaDaSemanaLista").value = "";
    }
    else {
        for (i = 0; i < (diaDaSemanaLista.length - 1); i++) {
            mostrarHorariosAulas += `<tr>
                                        <td>${diaDaSemanaLista[i]}</td>
                                        <td>${horarioInicioLista[i]}</td>
                                        <td>${horarioFimLista[i]}</td>         
                                        <td>
                                            <button onclick="removerHorario(${i})" type="button" class="btn btn-primary p-1">Remover</button>
                                        </td>
                                     </tr>`
        }
    }
    if (mostrarHorariosAulas == "") {
        document.getElementById("listaHorariosWarning").hidden = false;
    }
    else {
        document.getElementById("listaHorariosWarning").hidden = true;
    }
    document.getElementById("mostrarHorariosAulas").innerHTML = mostrarHorariosAulas;
}

function removerHorario(numeroNaLista) {
    let horarioInicioLista = document.getElementById("horarioInicioLista").value;
    horarioInicioLista = horarioInicioLista.split(";");
    let horarioFimLista = document.getElementById("horarioFimLista").value;
    horarioFimLista = horarioFimLista.split(";");
    let diaDaSemanaLista = document.getElementById("diaDaSemanaLista").value;
    diaDaSemanaLista = diaDaSemanaLista.split(";");
    let diaDaSemanaListaNumber = document.getElementById("diaDaSemanaListaNumber").value;
    diaDaSemanaListaNumber = diaDaSemanaListaNumber.split(";");

    let horarioInicioListaSubstituir = "";
    let horarioFimListaSubstituir = "";
    let diaDaSemanaListaSubstituir = "";
    let diaDaSemanaListaNumberSubstituir = "";
    if (horarioInicioLista.length != horarioFimLista.length || horarioInicioLista.length != diaDaSemanaLista.length) {
        document.getElementById("horarioInicioLista").value = "";
        document.getElementById("horarioFimLista").value = "";
        document.getElementById("diaDaSemanaLista").value = "";
        document.getElementById("diaDaSemanaListaNumber").value = "";
    }
    else {
        for (i = 0; i < (diaDaSemanaLista.length - 1); i++) {
            if (i != numeroNaLista) {
                horarioInicioListaSubstituir += horarioInicioLista[i] + ";";
                horarioFimListaSubstituir += horarioFimLista[i] + ";";
                diaDaSemanaListaSubstituir += diaDaSemanaLista[i] + ";";
                diaDaSemanaListaNumberSubstituir += diaDaSemanaListaNumber[i] + ";";
            }
        }
        document.getElementById("horarioInicioLista").value = horarioInicioListaSubstituir;
        document.getElementById("horarioFimLista").value = horarioFimListaSubstituir;
        document.getElementById("diaDaSemanaLista").value = diaDaSemanaListaSubstituir;
        document.getElementById("diaDaSemanaListaNumber").value = diaDaSemanaListaNumberSubstituir;
        desenharHorariosAula();
    }  
}