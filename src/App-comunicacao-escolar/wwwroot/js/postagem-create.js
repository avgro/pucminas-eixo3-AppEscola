function previewDaImagemSelecinada() {
    let previewImagem = document.getElementById('preview-imagem');
    let arquivoSelect = document.getElementById('arquivos').files[0];

    const reader = new FileReader();
    reader.readAsDataURL(arquivoSelect);
    reader.addEventListener("load", function () {
        previewImagem.hidden = false;
        previewImagem.src = reader.result;
    }) 
}