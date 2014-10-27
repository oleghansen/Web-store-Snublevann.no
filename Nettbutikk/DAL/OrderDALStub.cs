using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class OrderDALStub : DAL.IOrderDAL       
    {
        public List<Order> getAllOrders()
        {
            List<Order> list = new List<Order>();
            
           

            var order = new Order()
            {
                 
                id = 298423,
                
                customerid = 1,   
                orderdate = DateTime.Now
            };
            list.Add(order);
            list.Add(order);
            list.Add(order);
            return list;
        }
        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
            List<OrderLine> olList = new List<OrderLine>();
            var orderline = new OrderLine()
            {
                id = 1,
                productid = 100001,
                quantity = 3,
                orderid = 298423,

            };
            olList.Add(orderline);
            olList.Add(orderline);
            olList.Add(orderline);
            return olList;
        }

        

        public Order findOrder(int id)
       { 
            var order = new Order()
            {
                id = 1,
                customerid = 1001,
                orderdate = DateTime.Now,
            };
            return order;
        }

        public bool checkOrder(int? id)
        {
            return false;
        }
    }
}
