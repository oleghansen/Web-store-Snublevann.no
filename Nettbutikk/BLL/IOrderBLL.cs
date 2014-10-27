using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IOrderBLL
    {
        List<Order> getAllOrders(int? id);
        List<OrderLine> getAllOrderLinesOfOrder(int id);
        Customer getCustomer(int id);

        Order getOne(int id);
        int getNumItems(Order o);
        int getSum(Order o);
    }
}
