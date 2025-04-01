function subtract() {
    const firstNumber = document.getElementById('firstNumber');
    const secondNumber = document.getElementById('secondNumber');
    const resultElement = document.getElementById('result');

    resultElement.textContent =
        Number(firstNumber.value) - Number(secondNumber.value);
}
