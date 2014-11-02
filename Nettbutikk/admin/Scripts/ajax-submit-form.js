$(document).ready(function () {
    $('.ajaxform').submit(function (event) {
        event.preventDefault();
        var formtoken = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', formtoken).val();
        var formdata = $(this).serializeArray();
        formdata.push({__RequestVerificationToken: token}); 
        console.log("osrtuh");
        $.ajax({
            url: this.action,
            type: this.method,
            data: formdata,
            success: function (status) {
                console.log("oaetnoteuah");
                if (!status.success) {
                    console.log("modal??");
                    $('#infoModal').modal('show');
                    $('.modal-title').text("Feil");
                    $('.modal-body').text(status.message);
                }
                else {
                    console.log("baoetus");
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

            }
        });
    });
});