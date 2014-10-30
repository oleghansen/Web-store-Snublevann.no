$(document).ready(function () {
    $('form').submit(function (event) {
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
                if(!status)
                    $('#infoModal').modal('show');
                else{
                    var notification = $.notify.create("Endringene ble lagret",{
                        style:'box',
                        type:'success',
                        opacity:0.95,
                        displayTime:2000,
                        autoShow: true,
                        adjustScroll: true
                    });
                    setTimeout(function() {
                        notification.notify("hide");
                    },
                    2000
                    );
                    return false;
                }
            }
        });
    });
});