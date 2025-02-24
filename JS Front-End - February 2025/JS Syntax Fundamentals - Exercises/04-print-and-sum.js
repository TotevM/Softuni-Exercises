function solve(num1, num2){

    let sum=0;
    let text='';

    for (let i = num1; i <= num2; i++) {
        text+=`${i} `
        sum+=i;
    }
    console.log(text)
    console.log(`Sum: ${sum}`)
}

solve(5,10)