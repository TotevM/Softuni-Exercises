function splitPascalCase(str) {
    const words = str.match(/[A-Z][a-z]*/g);

    console.log(words.join(", "));
}
