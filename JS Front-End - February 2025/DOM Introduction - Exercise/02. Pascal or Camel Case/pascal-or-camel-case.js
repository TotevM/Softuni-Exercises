function solve() {
    const text = document.getElementById('text');
    const convention = document.getElementById('naming-convention');
    const resultEl = document.getElementById('result');

    debugger;
    let words = text.value
        .toLowerCase()
        .split(' ')
        .map((x) => x[0].toUpperCase() + x.slice(1))
        .join('');

    if (convention.value === 'Camel Case') {
        resultEl.textContent = words[0].toLowerCase() + words.slice(1);
    } else if (convention.value === 'Pascal Case') {
        resultEl.textContent = words;
    } else {
        resultEl.textContent = 'Error!';
    }
}
