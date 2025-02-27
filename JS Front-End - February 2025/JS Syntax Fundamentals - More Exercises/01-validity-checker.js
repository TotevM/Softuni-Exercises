function check(x1, y1, x2, y2) {

    solve(x1, y1, 0, 0)
    solve(x2, y2, 0, 0)
    solve(x1, y1, x2, y2)

    function solve(x1, y1, x2, y2) {
        let num = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2))
        if (Number.isInteger(num)) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
        } else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
        }
    }
}