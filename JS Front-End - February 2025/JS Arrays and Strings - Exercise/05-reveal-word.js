function solve(wordsString, template) {
    const wordsArr = wordsString.split(', ');

    for (const word of wordsArr) {
        template = template.replace('*'.repeat(word.length), word);
    }

    console.log(template);
}