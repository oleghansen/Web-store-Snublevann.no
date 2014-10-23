using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nettbutikk.DAL
{
    public class OrderDAL : DAL.IOrderDAL
    {
        public List<OrderLine> getAllOrderLines(int id)
        {
            var db = new DatabaseContext();
            var lines = db.OrderLines.Include(p => p.Products).ToList();
            List<OrderLine> list = new List<OrderLine>();
            foreach (var item in lines)
            {
                var itemProduct = new Product()
                {
                    itemnumber = item.Products.Id,
                    name = item.Products.Name,
                    price = item.Products.Price,
                    description = item.Products.Description
                };
                list.Add(new OrderLine()
                {
                     id = item.Id,
                      orderid = item.OrdersId,
                        productid = item.ProductsId,
                    product = itemProduct,
                    quantity = item.Quantity,
                });
            }
            return list;
        }


        public List<Order> getAllOrders()
        {
            var db = new DatabaseContext();
            var lines = db.Orders.Include(c => c.Customers).ToList();
            List<Order> list = new List<Order>();
            foreach (var item in lines)
            {
                var itemCust = new Customer()
                {
                    id = item.CustomersId,
                    firstname = item.Customers.Firstname,
                    lastname = item.Customers.Lastname

                };
                list.Add(new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = item.CustomersId

                });
            }
            return list;
        }
       


        public Order findOrder(int id)
        {
            return null;
        }

        public bool checkOrder(int? id)
        {
            return false;
        }
    }
}