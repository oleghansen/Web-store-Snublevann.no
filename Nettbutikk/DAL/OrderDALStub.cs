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
                orderdate = DateTime.Now, 
                id = 1,
                orderLine  = new List<OrderLine>(),
                customer = new Customer(),
                customerid = 1                 
            };
            list.Add(order);
            list.Add(order);
            list.Add(order);
            return list;
        }
        public List<OrderLine> getAllOrderLinesOfOrder(int id)
        {
            return null;
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
