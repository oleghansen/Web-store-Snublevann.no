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
                CustomerID = cart.userID
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();
            Debug.WriteLine("Her kommer ID'En");
            Debug.WriteLine(newOrder.ID); 

            foreach (var item in cart.shoppingCartItems)
            {
                var newItem = new OrderLines()
                {
                    ProductID = item.product.itemnumber,
                    OrderID = newOrder.ID,
                    Quantity = item.quantity
                };
                db.OrderLines.Add(newItem);
            }
            db.SaveChanges();

        }
    }
}