function addItem() {
    const textInputElement = document.getElementById('newItemText');
    const ulElement = document.getElementById('items');

    if (textInputElement.value !== '') {
        const childLiElement = document.createElement('li');
        const childAElement = document.createElement('a');

        childAElement.href = '#';
        childAElement.textContent = '[Delete]';

        childLiElement.textContent = textInputElement.value;
        childLiElement.appendChild(childAElement);
        ulElement.appendChild(childLiElement);

        childAElement.addEventListener('click', (event) => {
            event.currentTarget.parentElement.remove();
        });
    }

    textInputElement.value = '';
}
