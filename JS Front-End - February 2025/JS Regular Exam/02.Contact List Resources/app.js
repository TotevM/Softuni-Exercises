window.addEventListener('load', solve);

function solve() {
    const form = document.getElementById('contact_form');
    const firstNameInput = document.getElementById('first_name');
    const lastNameInput = document.getElementById('last_name');
    const phoneInput = document.getElementById('phone');
    // const addBtn = document.getElementById("add_btn");
    const pendingList = document.getElementById('pending_contact_list');
    const verifiedList = document.getElementById('contact_list');

    form.addEventListener('submit', (e) => {
        e.preventDefault();

        const firstName = firstNameInput.value.trim();
        const lastName = lastNameInput.value.trim();
        const phone = phoneInput.value.trim();

        if (firstName === '' || lastName === '' || phone === '') {
            return;
        }

        const li = document.createElement('li');
        li.classList.add('contact');

        const nameSpan = document.createElement('span');
        nameSpan.classList.add('names');
        nameSpan.textContent = `${firstName} ${lastName}`;

        const phoneSpan = document.createElement('span');
        phoneSpan.classList.add('phone_number');
        phoneSpan.textContent = phone;

        const editBtn = document.createElement('button');
        editBtn.classList.add('edit_btn');
        editBtn.textContent = 'Edit';
        editBtn.addEventListener('click', () => {
            const [fName, lName] = nameSpan.textContent.split(' ');
            firstNameInput.value = fName;
            lastNameInput.value = lName;
            phoneInput.value = phoneSpan.textContent;
            li.remove();
        });

        const verifyBtn = document.createElement('button');
        verifyBtn.classList.add('verify_btn');
        verifyBtn.textContent = 'Verify';
        verifyBtn.addEventListener('click', () => {
            li.remove();

            const verifiedLi = document.createElement('li');
            verifiedLi.classList.add('verified_contact');

            const verifiedName = document.createElement('span');
            verifiedName.classList.add('names');
            verifiedName.textContent = nameSpan.textContent;

            const verifiedPhone = document.createElement('span');
            verifiedPhone.classList.add('phone_number');
            verifiedPhone.textContent = phoneSpan.textContent;

            const deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete_btn');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', () => {
                verifiedLi.remove();
            });

            verifiedLi.appendChild(verifiedName);
            verifiedLi.appendChild(verifiedPhone);
            verifiedLi.appendChild(deleteBtn);
            verifiedList.appendChild(verifiedLi);
        });

        li.appendChild(nameSpan);
        li.appendChild(phoneSpan);
        li.appendChild(editBtn);
        li.appendChild(verifyBtn);

        pendingList.appendChild(li);

        firstNameInput.value = '';
        lastNameInput.value = '';
        phoneInput.value = '';
    });
}
