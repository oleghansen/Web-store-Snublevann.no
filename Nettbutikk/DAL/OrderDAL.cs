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
        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
            var db = new DatabaseContext();
            var lines = db.OrderLines.Where(ol =>ol.OrdersId  == id).ToList();
            List<OrderLine> list = new List<OrderLine>();
            foreach (var item in lines)
            {
                list.Add(new OrderLine()
                {
                     id = item.Id,  
                     orderid = item.OrdersId,
                     productid = item.ProductsId,   
                     quantity = item.Quantity,              
                });
            }
            return list;
        }


        public List<Order> getAllOrders(int? id)
        {
            var db = new DatabaseContext();
            List<Orders> lines;
            if(id != null)
                 lines = db.Orders.Where(o => o.Id  == id).ToList();
            else
             lines = db.Orders.ToList();

            List<Order> list = new List<Order>();
            foreach (var item in lines)
            {             
                    
                list.Add(new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = item.CustomersId
                   
                 });
            }
            return list;
        }

        public Order getOrder(int id)
        {
            var db = new DatabaseContext();
            Orders order = (Orders)db.Orders.FirstOrDefault(p=> p.Id == id);
           
            Order o = new Order()
            {
               id = order.Id,
               orderdate = order.OrderDate,
               customerid = order.CustomersId

            };
            
            return o;
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