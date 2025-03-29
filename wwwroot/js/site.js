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
});

function confirmDelete(clientId) {
    var form = document.getElementById('deleteForm');
    form.action = '/Admin/Delete/' + clientId;
    var modal = new bootstrap.Modal(document.getElementById('confirmModal'));
    modal.show();
}


//function hideLoadingMessage(img) {
//    var loadingMessage = img.previousElementSibling;
//    if (loadingMessage && loadingMessage.classList.contains('loading-message')) {
//        loadingMessage.style.display = 'none';
//    }
//}

function hideLoadingMessage(img) {
    var loadingMessage = img.previousElementSibling;
    if (loadingMessage && loadingMessage.classList.contains('loading-message')) {
        loadingMessage.style.display = 'none';
    }
}