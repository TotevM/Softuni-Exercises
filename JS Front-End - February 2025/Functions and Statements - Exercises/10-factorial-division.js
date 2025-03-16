function division(num1, num2) {
    const factorial = (number) => {
        if (number === 1) {
            return 1;
        }

        return number * factorial(number - 1);
    };

    console.log((factorial(num1) / factorial(num2)).toFixed(2));
}

division(6, 2);
