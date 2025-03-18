function solve(arr = []) {
    const print = (el, isAvailable = true) =>
        isAvailable ? `Scheduled for ${el}` : `Conflict on ${el}!`;

    const schedules = {};

    arr.forEach((element) => {
        const [day, person] = element.split(' ');

        if (!schedules.hasOwnProperty(day)) {
            schedules[day] = person;
            console.log(print(day));
        } else {
            console.log(print(day, false));
        }
    });

    Object.entries(schedules).forEach(([day, person]) => {
        console.log(`${day} -> ${person}`);
    });
}
