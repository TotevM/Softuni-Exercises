document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const emailInput = document.getElementById('email');

    emailInput.addEventListener('change', () => {
        const emailPattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (!emailPattern.test(emailInput.value)) {
            emailInput.classList.add('error');
        } else {
            emailInput.classList.remove('error');
        }
    });
}
