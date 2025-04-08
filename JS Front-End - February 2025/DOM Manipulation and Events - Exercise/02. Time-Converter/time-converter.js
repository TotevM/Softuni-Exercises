document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const daysInput = document.getElementById('days-input');
    const hoursInput = document.getElementById('hours-input');
    const minutesInput = document.getElementById('minutes-input');
    const secondsInput = document.getElementById('seconds-input');

    document.getElementById('daysBtn').addEventListener('click', (e) => {
        e.preventDefault();
        const days = Number(daysInput.value);
        hoursInput.value = days * 24;
        minutesInput.value = days * 24 * 60;
        secondsInput.value = days * 24 * 60 * 60;
    });

    document.getElementById('hoursBtn').addEventListener('click', (e) => {
        e.preventDefault();
        const hours = Number(hoursInput.value);
        daysInput.value = hours / 24;
        minutesInput.value = hours * 60;
        secondsInput.value = hours * 60 * 60;
    });

    document.getElementById('minutesBtn').addEventListener('click', (e) => {
        e.preventDefault();
        const minutes = Number(minutesInput.value);
        hoursInput.value = minutes / 60;
        daysInput.value = minutes / 60 / 24;
        secondsInput.value = minutes * 60;
    });

    document.getElementById('secondsBtn').addEventListener('click', (e) => {
        e.preventDefault();
        const seconds = Number(secondsInput.value);
        minutesInput.value = seconds / 60;
        hoursInput.value = seconds / 60 / 60;
        daysInput.value = seconds / 60 / 60 / 24;
    });
}
