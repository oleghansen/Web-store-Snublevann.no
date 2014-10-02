$(document).ready(function () {
    $('.item').click(function () {
        if ($(this).css('max-height') == '33px') {
            $(this).css('max-height', '429px')
        } else {
            $(this).css('max-height', '33px')
        }
        $('#accordion a.collapse').live('click', function (event) {
            event.stopPropagation();
            event.preventDefault();
        });
    });
});