function extractOddElements(text = '') {
    let arr = [];
    const words = text.toLowerCase().split(' ');

    for (let i = 0; i < words.length; i++) {
        let count = words.filter((word) => word === words[i]).length;

        if (count % 2 !== 0 && !arr.includes(words[i])) {
            arr.push(words[i]);
        }
    }

    console.log(arr.join(' '));
}

extractOddElements('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
