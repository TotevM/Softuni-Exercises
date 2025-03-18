function solve(arr = []) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    arr.forEach((catString) => {
        const [name, age] = catString.split(' ');
        const cat = new Cat(name, age);
        cat.meow();
    });
}
