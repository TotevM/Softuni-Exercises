document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const encodeButtonElement = document.querySelector('main #encode button');
    const encodeTextAreaElement = document.querySelector(
        'main #encode textarea'
    );
    const decodeButtonElement = document.querySelector('main #decode button');
    const decodeTextAreaElement = document.querySelector(
        'main #decode textarea'
    );

    encodeButtonElement.addEventListener('click', (e) => {
        e.preventDefault();
        let encodedMessage = '';
        for (let valueElement of encodeTextAreaElement.value) {
            encodedMessage += String.fromCharCode(
                valueElement.charCodeAt(0) + 1
            );
        }
        decodeTextAreaElement.value = encodedMessage;
        encodeTextAreaElement.value = '';
    });
    decodeButtonElement.addEventListener('click', (e) => {
        e.preventDefault();
        let decodedMessage = '';
        for (let valueElement of decodeTextAreaElement.value) {
            decodedMessage += String.fromCharCode(
                valueElement.charCodeAt(0) - 1
            );
        }
        decodeTextAreaElement.value = decodedMessage;
    });
}
