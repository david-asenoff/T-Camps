// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    var searchInput = document.getElementById('searchInput');
    if (searchInput) {
        searchInput.addEventListener('keyup', function () {
            var input, filter, table, tr, td, i, j, txtValue;
            input = document.getElementById('searchInput');
            filter = input.value.toLowerCase();
            table = document.getElementById('clientsTable');
            tr = table.getElementsByTagName('tr');

            console.log("search...");

            for (i = 0; i < tr.length; i++) {
                tr[i].style.display = 'none';
                td = tr[i].getElementsByTagName('td');
                for (j = 0; j < td.length; j++) {
                    if (td[j]) {
                        txtValue = td[j].textContent || td[j].innerText;
                        if (txtValue.toLowerCase().indexOf(filter) > -1) {
                            tr[i].style.display = '';
                            break;
                        }
                    }
                }
            }
        });
    }


    // Set alt attribute dynamically based on image name
    var images = document.querySelectorAll('.gallery-one__img img');
    images.forEach(function (img) {
        var src = img.getAttribute('src');
        var imageName = src.substring(src.lastIndexOf('/') + 1, src.lastIndexOf('.'));
        img.setAttribute('alt', imageName);
    });

    // Hide loading component once the page is fully loaded
    window.addEventListener('load', function () {
        var loadingComponent = document.getElementById('loadingComponent');
        if (loadingComponent) {
            loadingComponent.style.display = 'none';
        }
    });

});

function confirmDelete(clientId) {
    var form = document.getElementById('deleteForm');
    form.action = '/Admin/Delete/' + clientId;
    var modal = new bootstrap.Modal(document.getElementById('confirmModal'));
    modal.show();
}

function hideLoadingMessage(img) {
    var loadingMessage = img.previousElementSibling;
    if (loadingMessage && loadingMessage.classList.contains('loading-message')) {
        loadingMessage.style.display = 'none';
    }
}

/**
 * Summary:
 * This JavaScript code checks the current URL path against the href of each navigation link. 
 * When it finds a match, it adds a current class to the parent <li> element. 
 * If there’s no match, it ensures the current class is removed. 
 * This ensures the active menu item is visually highlighted on page load.
 */
document.addEventListener('DOMContentLoaded', function () {
    const currentUrlPath = window.location.pathname;
    //console.log('Current URL Path:', currentUrlPath);

    const navLinks = document.querySelectorAll('.main-menu__list a');
    //console.log('Nav Links:', navLinks);

    navLinks.forEach(link => {
        const href = link.getAttribute('href');
        //console.log('Checking link:', href);

        if (href === currentUrlPath) {
            const listItem = link.closest('li');
            //console.log('Match found. Adding "current" class to <li>:', listItem);
            listItem.classList.add('current');
        } else {
            const listItem = link.closest('li');
            if (listItem) {
                //console.log('No match for:', href);
                listItem.classList.remove('current');
            }
        }
    });
});


let isFiltered = false; // Flag to track the state of the double-click

function handleDoubleClick(header) {

    const rows = document.querySelectorAll('#scheduleTable tbody tr'); // Select all rows in the table
    if (!isFiltered) {
        // First double-click: Call filterByDate
        filterByDate(header);
        isFiltered = true; // Set the flag to true
    } else {
        // Second double-click: Call resetFilter
        resetFilter();
        isFiltered = false; // Reset the flag
    }
}

function filterByDate(header) {
    const table = document.getElementById('scheduleTable');
    const rows = table.querySelectorAll('tbody tr');
    const dateToFilter = header.innerText.trim();

    rows.forEach(row => {
        const rowDate = row.getAttribute('data-date');

        if (new Date(rowDate).toDateString() === new Date(dateToFilter).toDateString()) {
            row.style.display = '';
            row.setAttribute("title", "Кликни 2 пъти на датата, за да изтриеш филтъра");
        } else {
            row.style.display = 'none';
        }
    });
}

function resetFilter() {
    const rows = document.querySelectorAll('#scheduleTable tbody tr');
    rows.forEach(row => {
        row.style.display = '';
        row.setAttribute("title", "Кликни 2 пъти на датата, за да филтрираш");
    });
}

