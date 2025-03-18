function solve(obj) {
    for (const value in obj) {
        console.log(`${value} -> ${obj[value]}`);
    }
}
