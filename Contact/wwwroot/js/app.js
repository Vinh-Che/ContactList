document.addEventListener('DOMContentLoaded', function () {
    fetch('http://localhost:7226/api/contacts') 
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => populateTable(data))
        .catch(error => console.error('Failed to fetch contacts:', error));
});

function populateTable(data) {
    const tbody = document.querySelector('#contactList tbody');
    tbody.innerHTML = ''; 

    data.forEach(contact => {
        let row = tbody.insertRow();
        let nameCell = row.insertCell(0);
        nameCell.textContent = contact.name;

        let detailsCell = row.insertCell(1);

        let detailsButton = document.createElement('button');
        detailsButton.textContent = 'View Details';
        detailsButton.onclick = () => alert(`Details for ${contact.name}`);
        detailsCell.appendChild(detailsButton);
    });
}
