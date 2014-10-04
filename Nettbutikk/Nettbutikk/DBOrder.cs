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

        public List<Order> getOrders(int id)
        {
            var db = new DatabaseContext();
            var order = db.Orders.Where(o => o.Id == id).ToList();
            List<Order> list = new List<Order>();
            foreach (var item in order){
                list.Add(new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate
                });
            }
            return list; 
        }
    }
}