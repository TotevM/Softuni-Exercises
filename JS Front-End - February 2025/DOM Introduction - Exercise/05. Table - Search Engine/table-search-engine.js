function solve() {
    const rowElements = document.querySelectorAll('tbody tr');
    const searchElement = document.getElementById('searchField');
    const searchValue = searchElement.value.toLowerCase();

    if (searchValue === '') {
        return;
    }

    for (const row of rowElements) {
        row.classList.remove('select');
        for (const record of row.children) {
            if (record.textContent.toLowerCase().includes(searchValue)) {
                row.classList.add('select');
                break;
            }
        }
    }

    searchElement.value = '';
}
