using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class ShoppingCart
    {
        public int userID;
        public List<ShoppingCartItem> shoppingCartItems;
        public int sum { get; set; }
        public ShoppingCart(int id)
        {
            userID = id; 
            shoppingCartItems = new List<ShoppingCartItem>();
            sum = 0;
        }


    }

    public class ShoppingCartItem
    {
        public Product product;
        public int quantity;
        public int price;

        public ShoppingCartItem(Product p, int qty)
        {
            product = p;
            quantity = qty;
            price = qty * product.price;
        }
    }

}