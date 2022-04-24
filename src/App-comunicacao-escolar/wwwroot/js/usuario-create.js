var url = new URL(window.location.href);
var tipodeUsuario = url.searchParams.get("tipoDeUsuario");

var selectTipoDeUsuario = document.getElementById("Perfil");

if (tipodeUsuario == "Responsavel")
    selectTipoDeUsuario.selectedIndex = 0;
if (tipodeUsuario == "Professor") 
    selectTipoDeUsuario.selectedIndex = 1;
if (tipodeUsuario == "Outros")
    selectTipoDeUsuario.selectedIndex = 2;

mostrarCamposAdicionaisPorUsuario();

function mostrarCamposAdicionaisPorUsuario() {
    if (selectTipoDeUsuario.selectedIndex == 1) {
        document.getElementById("infoProfessor").hidden = false;
        document.getElementById("Professor_Formacao").value = "";
    }
    else {
        document.getElementById("infoProfessor").hidden = true;
        document.getElementById("Professor_Formacao").value = "Nenhuma";
        }
}