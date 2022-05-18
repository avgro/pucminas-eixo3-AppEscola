function formatarTelefone(idInputField) {
    let inputTelefone = idInputField.value;
    let onlyNumbersInputTelefone = "";
    for (let i = 0; i < inputTelefone.length; i++) {
        let parseNumber = parseInt(inputTelefone.charAt(i));
        if (parseNumber.toString() != "NaN") {
            onlyNumbersInputTelefone += parseNumber;
        }
    }
    let formatedInputTelefone = "";
    for (let i = 0; i < onlyNumbersInputTelefone.length; i++) {
        if (onlyNumbersInputTelefone.length > 1 && i == 0)
            formatedInputTelefone += "("
        if (onlyNumbersInputTelefone.length < 11 && i == 6)
            formatedInputTelefone += "-"
        if (onlyNumbersInputTelefone.length >= 11 && i == 7)
            formatedInputTelefone += "-"
        if (i < 11) 
            formatedInputTelefone += onlyNumbersInputTelefone.charAt(i);
        if (i == 1)
            formatedInputTelefone += ")"
    }
    idInputField.value = formatedInputTelefone;
}