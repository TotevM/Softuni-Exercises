function printTowns(arr = []) {
    let result = [];

    arr.forEach((element) => {
        let [name, latitude, longitude] = element.split(' | ');

        const obj = {
            name,
            latitude,
            longitude,
        };

        result.push(obj);
    });

    for (const town of result) {
        console.log(
            `{ town: '${town.name}', latitude: '${Number(town.latitude).toFixed(
                2
            )}', longitude: '${Number(town.longitude).toFixed(2)}' }`
        );
    }
}

printTowns([
    'Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625',
]);
