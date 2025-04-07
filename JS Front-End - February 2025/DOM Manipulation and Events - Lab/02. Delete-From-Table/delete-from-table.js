function deleteByEmail() {
    const emailsEl = document.querySelectorAll('tr td:nth-child(2)');
    const searchValue = document
        .querySelector('input[type="text"]')
        .value.trim();
    const resultEl = document.getElementById('result');

    const el = [...emailsEl].filter(
        (x) => x.textContent.trim() === searchValue
    );

    if (!el.length) {
        resultEl.textContent = 'Not found.';
        return;
    }
    el.forEach((x) => x.parentElement.remove());
    resultEl.textContent = 'Deleted.';
}
