function findSpecialWords(input) {
    const words = input.split(' ');

    const specialWords = words
        .filter(word => word.startsWith('#'))
        .map(word => word.slice(1))
        .filter(word => /^[A-Za-z]+$/.test(word));

    specialWords.forEach(word => console.log(word));
}