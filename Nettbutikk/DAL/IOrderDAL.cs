using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface IOrderDAL
    {
        List<Order> getAllOrders(int? id);
        List<OrderLine> getAllOrderLinesOfOrder(int id);
        List<Order> getAllOrdersbyCust(int id);
    }
}
