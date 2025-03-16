function getSum(number) {
    let arr = number.toString().split('');

    let oddSum = 0;
    let evenSum = 0;

    const sum = (arr) =>
        arr.forEach((element) => {
            const temp = Number(element);

            if (temp % 2 == 0) {
                evenSum += temp;
            } else {
                oddSum += temp;
            }
        });

    sum(arr);
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

getSum(3495892137259234);
