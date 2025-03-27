function extractText() {
    const items = document.querySelectorAll('#items li');
    const result = document.getElementById('result');

    result.value = Array.from(items)
        .map((item) => item.textContent)
        .join('\n');
}
