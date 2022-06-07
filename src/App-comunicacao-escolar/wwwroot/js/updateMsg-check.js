// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Redireciona de volta para a home page caso a partial view não seja carregada corretamente

var url = new URL(window.location.href);
var msgUpdateFail = url.toString().split("/");
if (msgUpdateFail[msgUpdateFail.length - 1] == "UpdateMsg" || msgUpdateFail[msgUpdateFail.length - 1] == "UpdateAutorizacao" || msgUpdateFail[msgUpdateFail.length - 1] == "UpdateNotificacao") {
    var newHref = "";
    for (i = 0; i < (msgUpdateFail.length - 1); i++) {
        newHref += msgUpdateFail[i] + "/"
    }
    window.location.href = newHref;
}

