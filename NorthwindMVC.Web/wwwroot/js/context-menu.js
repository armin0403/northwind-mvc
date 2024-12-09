document.addEventListener("DOMContentLoaded", function () {
    const contextMenu = document.getElementById('contextMenu');

    // Function to close the context menu
    const closeMenu = function (event) {
        if (!contextMenu.contains(event.target)) {
            contextMenu.style.display = 'none';
            document.removeEventListener('click', closeMenu);
        }
    };

    document.querySelectorAll('.context-menu-row').forEach(function (row) {
        row.addEventListener('contextmenu', function (e) {
            e.preventDefault();
            console.log("Right-clicked row");

            // Get data attributes
            const rowId = row.getAttribute('data-id');
            const controllerName = row.getAttribute('data-controller');

            // Calculate menu position
            const viewportWidth = window.innerWidth;
            const viewportHeight = window.innerHeight;
            const menuWidth = contextMenu.offsetWidth;
            const menuHeight = contextMenu.offsetHeight;
            let posX = e.pageX;
            let posY = e.pageY;

            if (posX + menuWidth > viewportWidth) posX = viewportWidth - menuWidth - 10;
            if (posY + menuHeight > viewportHeight) posY = viewportHeight - menuHeight - 10;

            // Display the context menu
            contextMenu.style.top = `${posY}px`;
            contextMenu.style.left = `${posX}px`;
            contextMenu.style.display = 'block';

            // Set up action handlers
            document.getElementById('editOption').onclick = function () {
                console.log("Edit option clicked");
                const editUrl = `/${controllerName}/EditEmployee?id=${rowId}`;
                window.location.href = editUrl;
            };

            document.getElementById('deleteOption').onclick = function () {
                console.log("Delete option clicked");
                const deleteUrl = `/${controllerName}/DeleteEmployee?id=${rowId}`;
                window.location.href = deleteUrl;
            };

            // Attach closeMenu listener
            document.addEventListener('click', closeMenu);
        });
    });
});
