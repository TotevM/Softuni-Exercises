window.addEventListener('load', () => {
    document
        .getElementById('load-history')
        .addEventListener('click', loadReservations);
    document
        .getElementById('add-reservation')
        .addEventListener('click', addReservation);
    document
        .getElementById('edit-reservation')
        .addEventListener('click', editReservation);
});

const baseUrl = 'http://localhost:3030/jsonstore/reservations';
let editId = null;

async function loadReservations() {
    const res = await fetch(baseUrl);
    const data = await res.json();

    const list = document.getElementById('list');
    list.innerHTML = '';

    Object.values(data).forEach((reservation) => {
        const container = document.createElement('div');
        container.className = 'container';

        container.innerHTML = `
        <h2>${reservation.names}</h2>
        <h3>${reservation.date}</h3>
        <h3>${reservation.days}</h3>
        <button class="change-btn">Change</button>
        <button class="delete-btn">Done</button>
      `;

        const changeBtn = container.querySelector('.change-btn');
        changeBtn.addEventListener('click', () => loadForEdit(reservation));

        const deleteBtn = container.querySelector('.delete-btn');
        deleteBtn.addEventListener('click', () =>
            deleteReservation(reservation._id)
        );

        list.appendChild(container);
    });
}

async function addReservation(e) {
    e.preventDefault();

    const names = document.getElementById('names');
    const days = document.getElementById('days');
    const date = document.getElementById('date');

    if (!names.value || !days.value || !date.value) return;

    const newReservation = {
        names: names.value,
        days: days.value,
        date: date.value,
    };

    await fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newReservation),
    });

    names.value = '';
    days.value = '';
    date.value = '';

    loadReservations();
}

function loadForEdit(reservation) {
    document.getElementById('names').value = reservation.names;
    document.getElementById('days').value = reservation.days;
    document.getElementById('date').value = reservation.date;
    editId = reservation._id;

    document.getElementById('edit-reservation').disabled = false;
    document.getElementById('add-reservation').disabled = true;
}

async function editReservation(e) {
    e.preventDefault();

    if (!editId) return;

    const names = document.getElementById('names');
    const days = document.getElementById('days');
    const date = document.getElementById('date');

    const updated = {
        names: names.value,
        days: days.value,
        date: date.value,
    };

    await fetch(`${baseUrl}/${editId}`, {
        method: 'PATCH',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(updated),
    });

    names.value = '';
    days.value = '';
    date.value = '';
    editId = null;

    document.getElementById('edit-reservation').disabled = true;
    document.getElementById('add-reservation').disabled = false;

    loadReservations();
}

async function deleteReservation(id) {
    await fetch(`${baseUrl}/${id}`, {
        method: 'DELETE',
    });

    loadReservations();
}
