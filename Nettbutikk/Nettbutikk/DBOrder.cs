using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Nettbutikk
{
    public class DBOrder
    {
        public void checkout(ShoppingCart cart)
        {
            var db = new DatabaseContext();

            var newOrder = new Orders()
            {
                OrderDate = DateTime.Now, 
                CustomersId = cart.userID
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();
            Debug.WriteLine("Her kommer ID'En");
            Debug.WriteLine(newOrder.Id); 

            foreach (var item in cart.shoppingCartItems)
            {
                var newItem = new OrderLines()
                {
                    ProductsId = item.product.itemnumber,
                    OrdersId = newOrder.Id,
                    Quantity = item.quantity
                };
                db.OrderLines.Add(newItem);
            }
            db.SaveChanges();

        }
    }
}