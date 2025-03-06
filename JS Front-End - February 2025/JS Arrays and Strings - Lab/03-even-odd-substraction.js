function solve(array) {
    let sum = 0
    for (let i = 0; i < array.length; i++) {
        if (array[i] % 2 === 0) {
            sum += array[i]
        } else {
            sum -= array[i]
        }
    }

    console.log(sum)
}

solve([1, 2, 4, 5])