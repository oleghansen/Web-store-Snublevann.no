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
        public int checkout(ShoppingCart cart)
        {
            return 0;
        }

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

    }
}
