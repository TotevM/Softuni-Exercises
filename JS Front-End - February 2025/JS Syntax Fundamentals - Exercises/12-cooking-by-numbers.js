function processNumber(startingNumber, ...operations) {
    let number = Number(startingNumber);

    const operationsMap = {
        chop: (num) => num / 2,
        dice: (num) => Math.sqrt(num),
        spice: (num) => num + 1,
        bake: (num) => num * 3,
        fillet: (num) => num * 0.8
    };

    for (let operation of operations) {
        if (operationsMap[operation]) {
            number = operationsMap[operation](number);
            console.log(number);
        }
    }
}