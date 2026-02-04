$(document).ready(function () {

    let rowId, controllerName;

    // Handle right-click to show context menu and extract row data
    $('.context-menu-row').on('contextmenu', function (e) {
        e.preventDefault(); // Prevent default right-click menu

        var row = $(this);
        rowId = row.data('id'); // Extract row ID
        controllerName = row.data('controller'); // Extract controller name

        $('#contextMenu').css({
            top: e.pageY + 'px',
            left: e.pageX + 'px',
            display: 'block'
        });

        // Close context menu on click outside
        $(document).on('click', function () {
            $('#contextMenu').hide();
        });
    });

    // Handle menu option click (using delegated event handling)
    $(document).on('click', '.menu-items', function () {
        const action = $(this).data('action');
        let modal, url;

        if (action === 'edit') {
            modal = $('#generalModalLG');
            url = `/${controllerName}/EditView`;
        } else if (action === 'delete') {
            modal = $('#generalModal');
            url = `/${controllerName}/DeleteView`;
        }

        // Perform AJAX request
        $.ajax({
            url: url,
            type: 'GET',
            data: { id: rowId }, // Pass the row ID to the server
            success: function (response) {
                modal.find('.modal-content').html(response);
                modal.modal('show');
            },
            error: function () {
                console.error('Failed to load content.');
            }
        });

        $('#contextMenu').hide(); // Hide context menu
    });
});
