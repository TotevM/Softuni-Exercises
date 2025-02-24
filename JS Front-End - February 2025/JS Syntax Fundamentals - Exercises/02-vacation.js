function solve(peopleCount, type, day) {
    let prices = {
        "Students": { "Friday": 8.45, "Saturday": 9.80, "Sunday": 10.46 },
        "Business": { "Friday": 10.90, "Saturday": 15.60, "Sunday": 16.00 },
        "Regular": { "Friday": 15.00, "Saturday": 20.00, "Sunday": 22.50 }
    };

    let pricePerPerson = prices[type][day];
    let totalPrice = peopleCount * pricePerPerson;

    if (type === "Students" && peopleCount >= 30) {
        totalPrice *= 0.85;
    }

    if (type === "Business" && peopleCount >= 100) {
        totalPrice -= pricePerPerson * 10;
    }

    if (type === "Regular" && peopleCount >= 10 && peopleCount <= 20) {
        totalPrice *= 0.95;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}