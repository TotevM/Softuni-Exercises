function combineDefinitions(jsonArray) {
    const combined = {};

    jsonArray.forEach((jsonStr) => {
        const data = JSON.parse(jsonStr);
        for (let term in data) {
            combined[term] = data[term];
        }
    });

    const sortedTerms = Object.keys(combined).sort();

    sortedTerms.forEach((term) => {
        console.log(`Term: ${term} => Definition: ${combined[term]}`);
    });
}
