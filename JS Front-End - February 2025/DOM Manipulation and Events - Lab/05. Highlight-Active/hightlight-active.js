document.addEventListener('DOMContentLoaded', focused);

function focused() {
    const divElements = document.querySelectorAll('div.panel input');

    divElements.forEach((element) => {
        element.addEventListener('focus', () => {
            element.parentElement.classList.add('focused');
        });

        element.addEventListener('blur', () => {
            element.parentElement.classList.remove('focused');
        });
    });
}
