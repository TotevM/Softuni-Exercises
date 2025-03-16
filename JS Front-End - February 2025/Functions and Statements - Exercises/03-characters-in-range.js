function getRange(char1, char2) {
    const num1 = char1.charCodeAt(0);
    const num2 = char2.charCodeAt(0);

    const start = Math.min(num1, num2);
    const end = Math.max(num1, num2);
    let result = '';

    for (let i = start + 1; i < end; i++) {
        result += String.fromCharCode(i) + ' ';
    }
    console.log(result.trim());
}

getRange('a', 'd');
