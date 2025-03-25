function parkingLot(commands = []) {
    let parking = new Set(); //Set keeps unique values only

    for (const command of commands) {
        let [direction, carNumber] = command.split(', ');

        if (direction === 'IN') {
            parking.add(carNumber);
        } else if (direction === 'OUT') {
            parking.delete(carNumber);
        }
    }

    if (parking.size === 0) {
        console.log('Parking Lot is Empty');
    } else {
        [...parking].sort().forEach((car) => console.log(car));
    }
}
