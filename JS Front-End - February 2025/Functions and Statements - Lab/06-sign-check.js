function check(numOne, numTwo, numThree) {
    const negatives = [numOne, numTwo, numThree].filter((n) => n < 0).length;
    console.log(negatives % 2 === 0 ? 'Positive' : 'Negative');
}
