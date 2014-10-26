using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.BLL
{
    public class OrderBLL : BLL.IOrderBLL
    {
        private IOrderDAL _order;

        public OrderBLL()
        {
            _order = new OrderDAL();
        }

        public OrderBLL(IOrderDAL stub)
        {
            _order = stub;
        }

        public List<Order> getAllOrders()
        {
            List<Order> allOrders = _order.getAllOrders();
            return allOrders;
        }

        public List<OrderLine> getAllOrderLines()
        {
            List<OrderLine> allOrderLines = _order.getAllOrderLines();
            return allOrderLines;
        }

        public Order getOne(int id)
        {
            return _order.findOrder(id);
        }
    }
}
