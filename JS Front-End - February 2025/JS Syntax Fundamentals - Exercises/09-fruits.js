function solve(fruit, weightInGrams, pricePerKg){

    const weightInKg=weightInGrams/1000;

    console.log(`I need $${(pricePerKg*weightInKg).toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`)
}