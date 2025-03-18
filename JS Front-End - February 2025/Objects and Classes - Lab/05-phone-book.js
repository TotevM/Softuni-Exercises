function solve(arr = []) {
    const print = (el) => console.log(`${el[0]} -> ${el[1]}`);

    const phoneBook = {};

    arr.forEach((element) => {
        const [name, phone] = element.split(' ');
        phoneBook[name] = phone;
    });

    Object.entries(phoneBook).forEach(([name, phone]) => {
        print([name, phone]);
    });
}
