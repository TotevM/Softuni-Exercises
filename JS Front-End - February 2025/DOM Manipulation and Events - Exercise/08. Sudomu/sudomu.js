document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const quickCheckButton = document.querySelector(
        '.buttons input[type="submit"]'
    );
    const clearButton = document.querySelector('.buttons input[type="reset"]');
    const table = document.querySelector('table');
    const checkParagraph = document.querySelector('#check');
    const inputs = document.querySelectorAll('tbody input');

    quickCheckButton.addEventListener('click', (e) => {
        e.preventDefault();

        const matrix = Array.from({ length: 3 }, () => Array(3).fill(0));
        let isSolved = true;

        inputs.forEach((input, index) => {
            const value = parseInt(input.value);
            if (isNaN(value) || value < 1 || value > 3) {
                isSolved = false;
            }
            const row = Math.floor(index / 3);
            const col = index % 3;
            matrix[row][col] = value;
        });

        for (let i = 0; i < 3; i++) {
            const row = new Set(matrix[i]);
            const col = new Set([matrix[0][i], matrix[1][i], matrix[2][i]]);
            if (row.size !== 3 || col.size !== 3) {
                isSolved = false;
                break;
            }
        }

        if (isSolved) {
            table.style.border = '2px solid green';
            checkParagraph.textContent = 'Success!';
            checkParagraph.style.color = 'green';
        } else {
            table.style.border = '2px solid red';
            checkParagraph.textContent = 'Keep trying ...';
            checkParagraph.style.color = 'red';
        }
    });

    clearButton.addEventListener('click', clearBoard);

    function clearBoard() {
        inputs.forEach((input) => (input.value = ''));
        table.style.border = 'none';
        checkParagraph.textContent = '';
        checkParagraph.style.color = '';
    }
}
