function storeCars(input) {
    const garage = {};

    for (const entry of input) {
        const [number, valuePart] = entry.split(' - ');

        if (!garage[number]) {
            garage[number] = [];
        }

        garage[number].push(valuePart.split(': ').join(' - '));
    }

    Object.entries(garage).forEach(([number, cars]) => {
        console.log(`Garage № ${number}`);
        console.log(cars.map((car) => `--- ${car}`).join('\n'));
    });
}
