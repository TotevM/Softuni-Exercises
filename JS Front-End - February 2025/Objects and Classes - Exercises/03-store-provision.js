function storeProvision(currentStock, orderedStock) {
    let store = {};

    for (let i = 0; i < currentStock.length; i += 2) {
        let product = currentStock[i];
        let quantity = Number(currentStock[i + 1]);
        store[product] = quantity;
    }

    for (let i = 0; i < orderedStock.length; i += 2) {
        let product = orderedStock[i];
        let quantity = Number(orderedStock[i + 1]);

        if (store[product] !== undefined) {
            store[product] += quantity;
        } else {
            store[product] = quantity;
        }
    }

    for (let product in store) {
        console.log(`${product} -> ${store[product]}`);
    }
}
