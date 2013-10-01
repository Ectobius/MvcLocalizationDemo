(function () {
    var utils = mvcLocalizationDemo.utils,
        $itemsTable = $('#itemsTable');
    
    function deleteItem(url) {
        return $.post(url);
    }

    $itemsTable.on('click', '.delete-link', function (e) {
        var $this = $(this),
            postUrl = $this.attr('href'),
            confirmationMessage = utils.localize('deleteItemConfirmation');
        
        if (confirm(confirmationMessage)) {
            deleteItem(postUrl);

            $this.closest('tr').remove();
        }
        
        e.preventDefault();
    });
})();