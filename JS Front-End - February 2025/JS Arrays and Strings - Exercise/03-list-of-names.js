function solve(arr=[]){
    arr.sort((a, b) => a.localeCompare(b));

    arr.forEach((name, index) => {
        console.log(`${index + 1}.${name}`);
    });
}

solve(["John", "Bob", "Christina", "Ema"])