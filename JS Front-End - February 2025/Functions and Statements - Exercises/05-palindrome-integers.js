function isPalindrome(arr = []) {
    arr.forEach((element) => {
        const reversed = element.toString().split('').reverse().join('');

        if (element == reversed) {
            console.log(true);
        } else {
            console.log(false);
        }
    });
}
