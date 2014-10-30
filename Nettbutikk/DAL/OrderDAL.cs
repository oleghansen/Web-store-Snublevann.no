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
            List<OrderLine> lines = db.OrderLines.Select(item => new OrderLine(){
                 id = item.Id,  
                     orderid = item.OrdersId,
                     productid = item.ProductsId,   
                     quantity = item.Quantity,
            }).Where(item =>item.orderid == id).ToList();
           
            return lines;
        }


        public List<Order> getAllOrders(int? id)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
    
            var db = new DatabaseContext();
            List<Order> lines;
            if (id != null)
                lines = db.Orders.Select(item => new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = item.CustomersId
                }).Where(item => item.id == id).ToList();
            else
                lines = db.Orders.Select(item => new Order()
                {
                    id = item.Id,
                    orderdate = item.OrderDate,
                    customerid = item.CustomersId
                }).ToList();
            sw.Stop();

            Debug.WriteLine("get allorders; Elapsed={0}", sw.Elapsed);
            //get allorders; Elapsed=00:00:00.0457881
            return lines;
        }

        public List<Order> getAllOrdersbyCust(int id)
        {
            var db = new DatabaseContext();
            List<Order> lines = db.Orders.Select(item => new Order() 
            {
                id = item.Id,
                orderdate = item.OrderDate,
                customerid = item.CustomersId
            }).Where(o => o.customerid == id).ToList();
      
            return lines;
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

    }
}