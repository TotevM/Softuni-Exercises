document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const button = document.querySelector('input[type=submit]');
    button.addEventListener('click', (e) => {
        e.preventDefault();
        const textElement = document.querySelector('#newItemText');
        const valueElement = document.querySelector('#newItemValue');
        const selectElement = document.querySelector('#menu');
        const newOptionElement = document.createElement('option');

        newOptionElement.value = valueElement.value;
        newOptionElement.textContent = textElement.value;
        selectElement.appendChild(newOptionElement);

        textElement.value = '';
        valueElement.value = '';
    });
}
