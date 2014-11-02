$(document).ready(function () {
    $('a.ajaxdelete').on('click', function (e) {
        e.preventDefault();
        var form = $('form.ajaxdelete');
        var token = $('input[name="__RequestVerificationToken"]',form).val();
        //var id = $('input[name="hiddenid"]',this).val();
        var bid = $(this).attr('id'); 
        console.log(token);
        console.log(bid);
        $.ajax({
            url: $(this).attr('href'),
            type: "POST",
            data: {
                __RequestVerificationToken: token,
                id: bid,
            },
            success: function (status) {
                if(status.success)
                {
                    var notification = $.notify.create(status.message, {
                        style: 'box',
                        type: 'success',
                        opacity: 0.95,
                        displayTime: 3000,
                        autoShow: true,
                        adjustScroll: true
                    });
                    setTimeout(function () {
                        notification.notify("hide");
                        if (typeof status.redirect !== "undefined")
                            window.location.href = status.redirect;
                    },
                    3000
                    );
                }
                else
                {
                    $('#infoModal').modal('show');
                    $('.modal-title').text("Feil");
                    $('.modal-body').html(status.message);

                    if(typeof status.list !== "undefined")
                    {
                        $('.modal-body').append("<ul>");
                        for (var i = 0; i < status.list.length; i++) {
                            $('.modal-body').append("<li>"+status.list[i].name+"</li>");  
                        }
                    }
                }
            }
        });
    });
});