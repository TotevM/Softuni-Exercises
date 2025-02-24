function solve(number) {
    const num = number.toString();
    let sum = 0;

    for (const element of num) {
        sum += Number(element);
    }

    console.log(sum);
}