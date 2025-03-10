function solve(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapisLazuli = 0;
    let gold = 0;
    let height = 0;

    while (base > 0) {
        height++;

        if (base === 1 || base === 2) {
            gold += base * base * increment;
            break;
        }

        let innerArea = (base - 2) * (base - 2) * increment;
        stone += innerArea;

        let outerLayer = (4 * base - 4) * increment;

        if (height % 5 === 0) {
            lapisLazuli += outerLayer;
        } else {
            marble += outerLayer;
        }

        base -= 2;
    }

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuli)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(height * increment)}`);
}