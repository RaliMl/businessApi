// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



<script>
    $(document).ready(function () {
        $('.addToBookshelfButton').click(function () {
            var volumeId = $(this).data('volume-id');
            var bookshelfId = prompt('Enter the Bookshelf ID:'); // Prompt the user to enter the bookshelf ID

            // Send an AJAX request to add the volume to the bookshelf
            $.ajax({
                url: '/Volumes/AddToBookshelf',
                method: 'POST',
                data: {
                    volumeId: volumeId,
                    bookshelfId: bookshelfId
                }
            });
        });
    });
</script>