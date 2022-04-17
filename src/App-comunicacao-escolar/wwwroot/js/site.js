// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Refresh page 

window.addEventListener('load', function () {
    jQrefresh();
    startRefreshCount = true;
})

var intervalId = setInterval(function () {
    if (startRefreshCount) {
        jQrefresh();
    }
}, 5000);

function jQrefresh() {
    document.getElementById("refreshPartial").click();
}

