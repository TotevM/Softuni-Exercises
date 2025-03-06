function solve(arr = [], num) {
    const iterations = num % arr.length;

    if (iterations === 0) {
        console.log(arr.join(' '));
        return;
    }

    const firstPart = arr.slice(0, iterations);
    const secondPart = arr.slice(iterations);

    console.log(secondPart.concat(firstPart).join(' '));
}
