function flightStatus(input) {
    let flights = input[0];
    let statusUpdates = input[1];
    let statusToCheck = input[2][0];

    let flightMap = {};

    for (const flight of flights) {
        let [flightNumber, destination] = flight.split(' ');
        flightMap[flightNumber] = { destination, status: 'Ready to fly' };
    }

    for (const update of statusUpdates) {
        let [flightNumber, newStatus] = update.split(' ');
        if (flightMap[flightNumber]) {
            flightMap[flightNumber].status = newStatus;
        }
    }

    if (statusToCheck === 'Ready to fly') {
        Object.entries(flightMap)
            .filter(([_, flight]) => flight.status === 'Ready to fly')
            .forEach(([flightNumber, flight]) =>
                console.log(
                    `{ Destination: '${flight.destination}', Status: '${flight.status}' }`
                )
            );
    } else {
        Object.entries(flightMap)
            .filter(([_, flight]) => flight.status === statusToCheck)
            .forEach(([flightNumber, flight]) =>
                console.log(
                    `{ Destination: '${flight.destination}', Status: '${flight.status}' }`
                )
            );
    }
}
