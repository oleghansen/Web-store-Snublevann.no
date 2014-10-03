$(document).ready(function () {
    $('#stop').submit(function (event) {
        event.preventDefault();
        var form = $('#__AjaxAntiForgeryForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();
        $.ajax({
            url: $(this).data('url'),
            type: 'POST',
            data: {
                __RequestVerificationToken: token,
                un: $('#un').val(),
                pw: $('#pw').val()
            },
            success: function (status) {
                if(status)
                {
                    $('#LoginModal').hide();
                    window.location.href = '/Customer/PersonalSite/';
                }
                else
                {
                    alert("Feil passord, prøv igjen motherfucker!");
                }
            }
        }); 
        console.log("tull");
        console.log($(this).data('url'));
        return false;
    });
});
