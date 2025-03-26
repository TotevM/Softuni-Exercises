function getInformation(arr = []) {
    let entityArray = [];

    for (const names of arr) {
        let obj = {
            names,
            number: names.length,
        };

        entityArray.push(obj);
    }

    entityArray.forEach(({ names, number }) => {
        console.log(`Name: ${names} -- Personal Number: ${number}`);
    });
}

getInformation([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal',
]);
