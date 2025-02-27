function solve(input) {
    const words = input.match(/\w+/g);
    const upperCaseWords = words.map(word => word.toUpperCase()).join(', ')

    console.log(upperCaseWords);
}