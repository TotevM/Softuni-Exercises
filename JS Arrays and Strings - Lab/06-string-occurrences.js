function solve(sentense, word) {
    let array = sentense.split(' ').filter(function (element) {
        return element === word
    })

    console.log(array.length)
}

