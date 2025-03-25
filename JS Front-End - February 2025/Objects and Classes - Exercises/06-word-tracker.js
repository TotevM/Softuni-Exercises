function trackCount(arr = []) {
    const words = arr[0].split(' ');
    const wordList = arr.splice(1);

    let dictionary = [];

    for (let i = 0; i < words.length; i++) {
        dictionary.push({ word: words[i], count: 0 });
    }

    for (const word of words) {
        for (let i = 0; i < wordList.length; i++) {
            if (word === wordList[i]) {
                const element = dictionary.find((x) => x.word === word);
                element.count++;
            }
        }
    }
    dictionary.sort((a, b) => b.count - a.count);
    for (const obj of dictionary) {
        console.log(`${obj.word} - ${obj.count}`);
    }
}

trackCount([
    'this sentence',
    'In',
    'this',
    'sentence',
    'you',
    'have',
    'to',
    'count',
    'the',
    'occurrences',
    'of',
    'the',
    'words',
    'this',
    'and',
    'sentence',
    'because',
    'this',
    'is',
    'your',
    'task',
]);
