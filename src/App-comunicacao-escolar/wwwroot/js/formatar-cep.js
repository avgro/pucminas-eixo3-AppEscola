function formatarCep(idInputField) {
    let inputCep = idInputField.value;
    let formatedInputCep = "";
    let formatedInputCepCharCounter = 0;
    for (let i = 0; i < inputCep.length; i++) {
        let parseNumber = parseInt(inputCep.charAt(i));
        if (parseNumber.toString() != "NaN") {
            if (formatedInputCepCharCounter == 5)
                formatedInputCep += "-"
            if (formatedInputCepCharCounter < 8) {
                formatedInputCep += parseNumber;
                formatedInputCepCharCounter++;
            }
        }
    }
    idInputField.value = formatedInputCep;
}