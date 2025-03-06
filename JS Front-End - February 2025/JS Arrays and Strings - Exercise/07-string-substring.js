function solve(word, text){
    const wordsArr=text.split(' ')
    let consists=false;

    for (const w of wordsArr) {
        if (w.toLowerCase() === word.toLowerCase()) {
            consists=true
            break;
        }
    }

    console.log(consists ? word : `${word} not found!`)
}