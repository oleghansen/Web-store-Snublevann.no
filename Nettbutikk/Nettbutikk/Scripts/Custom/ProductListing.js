$(document).ready(function () {
    $('.clickable').css('cursor', 'pointer');
    $('.clickable').click(function (event) {
        event.preventDefault();
        var itemnumber = parseInt($(this).find('#itemnumber').text());
        var quantity = parseInt($(this).find('#qtyField').val());

        if ($(event.target).is($('.shoppingBtn'))) {
            $.ajax({
                url: '/ShoppingCart/addToCart',
                type: 'POST',
                data: {
                    quantity: quantity,
                    itemnumber: itemnumber
                },
                success: function (status) {
                    if (!status)
                        $('#NotLoggedIn').modal('show');
                    else
                    {
                        var notification = $.notify.create(quantity + $('#productName').text() +" ble lagt til i handlekurven", {
                            style: 'box',
                            type: 'success',
                            opacity: 0.8,
                            displayTime: 2000,
                            autoShow: true
                        });
                       
                        setTimeout(function () {
                            
                            notification.notify("hide");
                        },
                        2000
                        );
                        return false; 

                    }
                }
            });
            
        }
        else if ($(event.target).is($(this).find('#qtyField')))
            $.noop();
        else
            window.location.href = '/Product/viewProduct/' + itemnumber;
    });
    $('#modalLogInBtn').click(function () {
        $('#LoginModal').modal('show');
    });
});