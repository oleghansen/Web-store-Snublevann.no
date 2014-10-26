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
        public List<OrderLine> getAllOrderLines()
        {
            var db = new DatabaseContext();
            var lines = db.OrderLines.Include(p => p.Products).Include(o => o.Orders).Include(c => c.Orders.Customers).ToList();
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
                var customeritem = new Customer()
                {
                    id = item.Orders.CustomersId,
                    firstname = item.Orders.Customers.Firstname,
                    lastname = item.Orders.Customers.Lastname
                };
                var orderitem = new Order() 
                {
                     orderdate = item.Orders.OrderDate,
                     customerid = item.Orders.CustomersId,
                     customer = customeritem,
                      id = item.Orders.Id
                       
                };
               
                list.Add(new OrderLine()
                {
                     id = orderitem.id, 
                      orderid = item.OrdersId,
                        productid = item.ProductsId,
                         order = orderitem,
                    product = itemProduct,
                    quantity = item.Quantity,
                    
                });
            }
            return list;
        }


        public List<Order> getAllOrders()
        {
            var db = new DatabaseContext();
            var lines = db.Orders.Include(c => c.Customers).Include(ol => ol.OrderLines).ToList();
            List<Order> list = new List<Order>();
            foreach (var item in lines)
            {
                var itemCust = new Customer()
                {
                    id = item.CustomersId,
                    firstname = item.Customers.Firstname,
                    lastname = item.Customers.Lastname

                };

                var itemOrderLine = new OrderLine()
                {
                     
                };
                
                list.Add(new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = itemCust.id,
                    customer = itemCust,
                     

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