function colorize() {
    const evenRows = document.querySelectorAll('tbody tr:nth-child(even)');

    for (const row of evenRows) {
        row.style.backgroundColor = 'teal';
    }
}
