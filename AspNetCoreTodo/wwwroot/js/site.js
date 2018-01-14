// Write your JavaScript code.
$(document).ready(function () {
    // wire up the add button to send the new item to the server
    $('#add-item-button').on('click', addItem);
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });
});

function addItem() {
    $('#add-item-error').hide();
    var newTitle = $('#add-item-title').val();
    var newDate = $('#add-item-date').val();

    $.post('/Todo/AddItem', { title: newTitle, duedate: newDate }, function () {
        window.location = '/Todo';
    })
        .fail(function (data) {
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
                $('#add-item-error').text(firstError);
                $('#add-item-error').show();
            }
        })
}

function markCompleted(checkbox) {
    checkbox.disabled = true;
    $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
        var row = checkbox.parentElement.parentElement;
        $(row).addClass('done');
    });
}