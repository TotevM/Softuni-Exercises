document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const textareaInputElement = document.querySelector(
        '#exercise textarea:first-of-type'
    );
    const textareaOutputElement = document.querySelector(
        '#exercise textarea:last-of-type'
    );
    const generateButtonElement = document.querySelector(
        '#exercise input[value="Generate"]'
    );
    const buyButtonElement = document.querySelector(
        '#exercise input[value="Buy"]'
    );
    const furnitureTBodyElement = document.querySelector('table tbody');

    generateButtonElement.addEventListener('click', (event) => {
        event.preventDefault();

        const furnitures = JSON.parse(textareaInputElement.value);

        for (let furniture of furnitures) {
            const tr = document.createElement('tr');

            const img = document.createElement('img');
            img.src = furniture.img;
            const imgTd = document.createElement('td');
            imgTd.appendChild(img);
            tr.appendChild(imgTd);

            const nameP = document.createElement('p');
            nameP.textContent = furniture.name;
            const nameTd = document.createElement('td');
            nameTd.appendChild(nameP);
            tr.appendChild(nameTd);

            const priceP = document.createElement('p');
            priceP.textContent = furniture.price;
            const priceTd = document.createElement('td');
            priceTd.appendChild(priceP);
            tr.appendChild(priceTd);

            const decFactorP = document.createElement('p');
            decFactorP.textContent = furniture.decFactor;
            const decFactorTd = document.createElement('td');
            decFactorTd.appendChild(decFactorP);
            tr.appendChild(decFactorTd);

            const checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            const checkboxTd = document.createElement('td');
            checkboxTd.appendChild(checkbox);
            tr.appendChild(checkboxTd);

            furnitureTBodyElement.appendChild(tr);
        }
    });

    buyButtonElement.addEventListener('click', (event) => {
        event.preventDefault();

        const boughtFurniture = [];
        let totalPrice = 0;
        let totalDecFactor = 0;
        let itemCount = 0;

        const rows = Array.from(furnitureTBodyElement.querySelectorAll('tr'));

        for (let row of rows) {
            const checkbox = row.querySelector('input[type="checkbox"]');
            if (checkbox && checkbox.checked) {
                const name = row.children[1].textContent;
                const price = parseFloat(row.children[2].textContent);
                const decFactor = parseFloat(row.children[3].textContent);

                boughtFurniture.push(name);
                totalPrice += price;
                totalDecFactor += decFactor;
                itemCount++;
            }
        }

        if (itemCount > 0) {
            const avgDecFactor = totalDecFactor / itemCount;
            textareaOutputElement.value =
                `Bought furniture: ${boughtFurniture.join(', ')}\n` +
                `Total price: ${totalPrice.toFixed(2)}\n` +
                `Average decoration factor: ${avgDecFactor}`;
        } else {
            textareaOutputElement.value = 'No furniture selected.';
        }
    });
}
