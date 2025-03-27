function sumTable() {
    const priceElements = document.querySelectorAll('tbody td:nth-child(2)');
    let sum = 0;

    for (let i = 0; i < priceElements.length - 1; i++) {
        sum += Number(priceElements[i].textContent);
    }

    document.getElementById('sum').textContent = sum;
}
