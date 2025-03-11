function takeOrder(type, count) {
    let price = 0;

    switch (type) {
        case 'coffee':
            price = 1.5 * count;
            break;
        case 'water':
            price = 1 * count;
            break;
        case 'coke':
            price = 1.4 * count;
            break;
        case 'snacks':
            price = 2 * count;
            break;
    }

    console.log(price.toFixed(2));
}

takeOrder('water', 5);
