function mudarTipoUsuario() {
    let tipoUsuario = document.getElementById("selecionar-tipo-usuario");
    let tipoUsuarioNome = tipoUsuario.options[tipoUsuario.selectedIndex].value;
    window.location.href = `/Usuarios/?tipoUsuario=${tipoUsuarioNome}`;
}