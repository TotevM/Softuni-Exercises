function extractUniqueNumbers(input) {
    const sequences = new Set();

    for (const entry of input) {
        const numbers = JSON.parse(entry).sort((a, b) => b - a);
        sequences.add(numbers.join(','));
    }

    const sortedSequences = [...sequences]
        .map((seq) => seq.split(',').map(Number))
        .sort((a, b) => a.length - b.length);

    sortedSequences.forEach((seq) => console.log(`[${seq.join(', ')}]`));
}
