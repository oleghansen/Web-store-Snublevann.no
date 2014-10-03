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
                        $('#LoginModal').modal('show');
                    else
                        window.location.href = '/ShoppingCart/viewShoppingCart';
                }
            });
            
        }
        else if ($(event.target).is($(this).find('#qtyField')))
            console.log("tull");
        else
            window.location.href = '/Product/viewProduct/' + itemnumber;
    });
});