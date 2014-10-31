$(document).ready(function () {
    $('.ajaxform').submit(function (event) {
        event.preventDefault();
        var formtoken = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', formtoken).val();
        var formdata = $(this).serializeArray();
        formdata.push({__RequestVerificationToken: token}); 
        
        $.ajax({
            url: this.action,
            type: this.method,
            data: formdata,
            success: function(status){
                if (!status.success) {
                    $('#infoModal').modal('show');
                    $('.modal-title').text("Feil");
                    $('.modal-body').text(status.message);
                    $('#sletteModalKnapp').hide();
                    $('#defaultModalButton').hide(); 
                }
                else {
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
                    },
                    3000
                    );
                    return false;
                }
            }
        });
    });
});