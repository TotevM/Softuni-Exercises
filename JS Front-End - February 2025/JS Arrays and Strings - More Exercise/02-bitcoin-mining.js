function solve(arr = []) {
    const btcPrice = 11949.16;
    const goldPrice = 67.51;
    let firstDayPurchased = -1;
    let currentAmount = 0;
    let btcCount = 0;

    for (let i = 0; i < arr.length; i++) {
        const element = arr[i];

        let profit =
            (i + 1) % 3 !== 0 ? element * goldPrice : element * goldPrice * 0.7;
        currentAmount += profit;

        if (currentAmount > btcPrice) {
            if (btcCount === 0) {
                firstDayPurchased = i + 1;
            }

            const count = Math.floor(currentAmount / btcPrice);
            btcCount += count;

            currentAmount -= count * btcPrice;
        }
    }

    console.log(`Bought bitcoins: ${btcCount}`)

    if (btcCount!==0) {
        console.log(`Day of the first purchased bitcoin: ${firstDayPurchased}`)
    }

    console.log(`Left money: ${currentAmount.toFixed(2)} lv.`)
}

solve([100, 200, 300]);
console.log('----')
solve([50, 100]);
console.log('----')
