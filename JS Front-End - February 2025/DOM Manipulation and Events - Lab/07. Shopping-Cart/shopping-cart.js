document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const resultElement = document.querySelector('textarea[disabled]');
    const checkoutButton = document.querySelector('button.checkout');
    const productCatalogueElement = document.querySelector('.shopping-cart');

    let products = [];

    productCatalogueElement.addEventListener('click', (e) => {
        if (
            e.target.tagName !== 'BUTTON' ||
            e.target.textContent.trim() !== 'Add'
        ) {
            return;
        }

        const productElement = e.target.closest('.product');
        const name = productElement.querySelector('.product-title').textContent;
        const price = Number(
            productElement.querySelector('.product-line-price').textContent
        );

        resultElement.value += `Added ${name} for ${price.toFixed(
            2
        )} to the cart.\n`;

        products.push({
            name,
            price,
        });
    });

    checkoutButton.addEventListener('click', (e) => {
        const totalPrice = products.reduce(
            (price, product) => price + product.price,
            0
        );
        const productList = [
            ...new Set(products.map((product) => product.name)),
        ];

        resultElement.value += `You bought ${productList.join(
            ', '
        )} for ${totalPrice.toFixed(2)}.`;

        document
            .querySelectorAll('button.add-product, button.checkout')
            .forEach((btn) => btn.setAttribute('disabled', 'disabled'));
    });
}
