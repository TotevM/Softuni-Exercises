document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const button = document.querySelector('#task-input input:nth-child(2)');
    button.addEventListener('click', (e) => {
        e.preventDefault();
        const words = document
            .querySelector('#task-input input:nth-child(1)')
            .value.split(',');
        const contentElement = document.getElementById('content');

        for (let word of words) {
            const divElement = document.createElement('div');
            const paragraphElement = document.createElement('p');
            paragraphElement.textContent = word;
            paragraphElement.style.display = 'none';
            divElement.appendChild(paragraphElement);
            divElement.addEventListener('click', () => {
                paragraphElement.style.display = 'block';
            });
            contentElement.appendChild(divElement);
        }
    });
}
