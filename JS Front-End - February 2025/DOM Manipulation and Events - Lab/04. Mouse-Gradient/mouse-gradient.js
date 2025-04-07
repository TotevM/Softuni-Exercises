function attachGradientEvents() {
    const gradientBox = document.getElementById('gradient');
    const result = document.getElementById('result');

    gradientBox.addEventListener('mousemove', (event) => {
        const offsetX = event.offsetX;
        const boxWidth = gradientBox.clientWidth;
        const percentage = Math.floor((offsetX / boxWidth) * 100);
        result.textContent = `${percentage}%`;
    });
}
