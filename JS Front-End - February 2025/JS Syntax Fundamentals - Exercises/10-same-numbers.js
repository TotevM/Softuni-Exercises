function solve(number) {
    const stringNum = number.toString();
    const firstChar = stringNum[0];
    let same = true;
    let sum = 0;

    for (const char of stringNum) {
        if (char !== firstChar) {
            same = false;
        }
        sum += Number(char);
    }

    console.log(same)
    console.log(sum)
}


solve(554)