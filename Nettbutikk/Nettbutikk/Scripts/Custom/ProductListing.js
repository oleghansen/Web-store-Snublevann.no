$(document).ready(function () {
    $('.clickable').css('cursor', 'pointer');
    $('.clickable').click(function (event) {
        event.preventDefault();
        var itemnumber = parseInt($(this).find('#itemnumber').text());
        var quantity = parseInt($(this).find('#qtyField').val());

        console.log(itemnumber);
        console.log(quantity);
        
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
                        alert("varen ble lagt i handlekurv");
                }
            });
            
        }
        else if ($(event.target).is($(this).find('#qtyField')))
            noop();
        else
            window.location.href = '/Product/viewProduct/' + itemnumber;
    });
    $('#modalLogInBtn').click(function () {
        $('#LoginModal').modal('show');
    });
});