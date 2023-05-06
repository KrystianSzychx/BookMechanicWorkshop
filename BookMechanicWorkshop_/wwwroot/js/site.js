const searchButton = document.getElementById('search-button');
const searchInput = document.getElementById('search-input');

// dodanie funkcji obsługi zdarzeń do przycisku
searchButton.addEventListener('click', () => {
    // pobranie wartości pola tekstowego
    const city = searchInput.value;


    // wysłanie zapytania GET do akcji kontrolera
    window.location.href = `/MechanicWorkshop/MechanicWorkshopsByCity?city=${city}`;
});

searchInput.addEventListener('keyup', (event) => {
    if (event.key == 'Enter') {
        const city = searchInput.value;


        window.location.href = `/MechanicWorkshop/MechanicWorkshopsByCity?city=${city}`;
    }
});

searchInput.addEventListener('keydown', (event) => {
    if (event.keyCode === 13) {
        const city = searchInput.value;
        window.location.href = `/MechanicWorkshop/MechanicWorkshopsByCity?city=${city}`;
    }
});


