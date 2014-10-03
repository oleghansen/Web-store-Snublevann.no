$('#sidebar > a').on('click', function (e) {
    e.preventDefault();

    if (!$(this).hasClass("active")) {
        var lastActive = $(this).closest("#sidebar").children(".active");
        lastActive.removeClass("active");

        $(this).addClass("active");
        $(this).next('div').collapse('show');
    }
});