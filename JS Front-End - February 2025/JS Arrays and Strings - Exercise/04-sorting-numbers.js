function solve(arr=[]){
    arr.sort((a, b) => a-b);

    let result = [];
    let left = 0;
    let right = arr.length - 1;

    while (left <= right) {
        if (left !== right) {
            result.push(arr[left]);
            result.push(arr[right]);
        } else {
            result.push(arr[left]);
        }
        left++;
        right--;
    }
    
    return result;
}