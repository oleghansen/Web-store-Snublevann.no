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
            return null;
        }
        List<OrderLine> getAllOrderLines(int id)
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
