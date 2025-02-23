function solve(firstNum, secondNum, Operator){
    let result;
    switch (Operator) {
        case '+': result=firstNum+secondNum; break;
        case '-': result=firstNum-secondNum; break;
        case '/': result=firstNum/secondNum; break;
        case '*': result=firstNum*secondNum; break;
        case '%': result=firstNum%secondNum; break;
        case '**': result=firstNum**secondNum; break;
    }

    console.log(result)
}

solve(3, 5, '+')