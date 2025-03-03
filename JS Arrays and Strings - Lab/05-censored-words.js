function solve(sentense, word) {
    let result = sentense.replaceAll(word, '*'.repeat(word.length))
    console.log(result)
}