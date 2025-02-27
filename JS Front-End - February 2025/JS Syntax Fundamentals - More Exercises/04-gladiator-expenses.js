function gladiatorExpenses(lostFights, helmetPrice, swordPrice, shieldPrice, armorPrice) {
    let helmetBroken = Math.floor(lostFights / 2);
    let swordBroken = Math.floor(lostFights / 3);
    let shieldBroken = Math.floor(lostFights / 6);
    let armorBroken = Math.floor(shieldBroken / 2);

    let totalExpenses = (helmetBroken * helmetPrice) + 
                        (swordBroken * swordPrice) + 
                        (shieldBroken * shieldPrice) + 
                        (armorBroken * armorPrice);

    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);
}
