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
        public List<Order> getAll()
        {
            var order = new Order()
            {
                id = 1,
                customerid = 1001,
            };
            List<Order> orderlist = new List<Order>();
            orderlist.Add(order);
            return orderlist;
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
