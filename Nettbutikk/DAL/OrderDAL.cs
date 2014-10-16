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
        /*
        public int checkout(ShoppingCart cart)
        {
            return 0;
        }
        */
        public List<Order> getOrders(int id)
        {
            return null;
        }
        public List<OrderLine> getOrder(int id)
        {

            return null;
        }

        public List<Product> getMostSold()
        {
            return null;
        }

        public List<Order> getAll()
        {
            return new List<Order>();
        }

    }
}