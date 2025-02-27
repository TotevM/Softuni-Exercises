function solve(firstNum, operator, secondNum) {
    const result = eval(`${firstNum} ${operator} ${secondNum}`);
    console.log(result.toFixed(2));
}