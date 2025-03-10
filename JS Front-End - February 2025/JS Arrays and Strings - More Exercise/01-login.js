function solve(arr = []) {
    let failsCounter = 0;
    const username = arr[0];
    const password = username.split('').reverse().join('');

    for (let i = 1; i < arr.length; i++) {
        const element = arr[i];

        if (element === password) {
            console.log(`User ${username} logged in.`);
        } else {
            failsCounter++;
            if (failsCounter === 4) {
                console.log(`User ${username} blocked!`);
                return;
            }
            console.log('Incorrect password. Try again.');
        }
    }
}

solve(['Acer', 'login', 'go', 'let me in', 'recA']);
