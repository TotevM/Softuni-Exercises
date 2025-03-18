function solve(arr = []) {
    const personInfo = {};

    arr.forEach((entry) => {
        const [name, address] = entry.split(':');
        personInfo[name] = address;
    });

    Object.entries(personInfo)
        .sort(([nameA], [nameB]) => nameA.localeCompare(nameB))
        .forEach(([name, address]) => {
            console.log(`${name} -> ${address}`);
        });
}
