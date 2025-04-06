function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        const inputElement = document.querySelector('#inputs textarea');
        const inputList = JSON.parse(inputElement.value);
        const restaurants = {};

        for (const entry of inputList) {
            const [restaurant, workersData] = entry.split(' - ');
            const workers = workersData.split(', ').map((worker) => {
                const [name, salary] = worker.split(' ');
                return { name, salary: Number(salary) };
            });

            if (!restaurants[restaurant]) {
                restaurants[restaurant] = [];
            }

            restaurants[restaurant].push(...workers);
        }

        let bestRestaurantName = '';
        let bestAverageSalary = 0;

        for (const restaurant in restaurants) {
            const avgSalary =
                restaurants[restaurant].reduce(
                    (acc, worker) => acc + worker.salary,
                    0
                ) / restaurants[restaurant].length;

            if (avgSalary > bestAverageSalary) {
                bestAverageSalary = avgSalary;
                bestRestaurantName = restaurant;
            }
        }

        const bestWorkers = restaurants[bestRestaurantName].sort(
            (a, b) => b.salary - a.salary
        );
        const bestSalary = bestWorkers[0].salary;

        const bestRestaurantText = `Name: ${bestRestaurantName} Average Salary: ${bestAverageSalary.toFixed(
            2
        )} Best Salary: ${bestSalary.toFixed(2)}`;
        const workersText = bestWorkers
            .map(
                (worker) => `Name: ${worker.name} With Salary: ${worker.salary}`
            )
            .join(' ');

        document.querySelector('#bestRestaurant p').textContent =
            bestRestaurantText;
        document.querySelector('#workers p').textContent = workersText;
    }
}
