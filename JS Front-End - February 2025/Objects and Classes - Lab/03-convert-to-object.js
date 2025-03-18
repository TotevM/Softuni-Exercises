function solve(jsonFile) {
    const obj = JSON.parse(jsonFile);

    for (const key in obj) {
        console.log(`${key}: ${obj[key]}`);
    }
}
