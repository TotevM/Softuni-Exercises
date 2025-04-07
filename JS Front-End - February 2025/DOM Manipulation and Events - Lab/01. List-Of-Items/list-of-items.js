function addItem() {
    const textInputElement = document.getElementById('newItemText');
    const ulElement = document.getElementById('items');

    if (textInputElement.value !== '') {
        const childLiElement = document.createElement('li');
        childLiElement.textContent = textInputElement.value;
        ulElement.appendChild(childLiElement);
    }

    textInputElement.value = '';
}
