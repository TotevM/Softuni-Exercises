function catalog(products = []) {
    let productMap = {};

    for (const product of products) {
        let [name, price] = product.split(' : ');
        price = Number(price);

        let initial = name[0];

        if (!productMap[initial]) {
            productMap[initial] = [];
        }

        productMap[initial].push({ name, price });
    }

    let sortedKeys = Object.keys(productMap).sort();

    for (const key of sortedKeys) {
        console.log(key);
        productMap[key]
            .sort((a, b) => a.name.localeCompare(b.name))
            .forEach((p) => console.log(`  ${p.name}: ${p.price}`));
    }
}
