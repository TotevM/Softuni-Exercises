function calculate(a, b, c) {
    const add = (num1, num2) => num1 + num2;
    const subtract = (num1, num2) => num1 - num2;

    const result = subtract(add(a, b), c);
    console.log(result);
}

calculate(23, 6, 10);
