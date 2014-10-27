using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface IOrderDAL
    {
        //int checkout(ShoppingCart cart);
       // System.Collections.Generic.List<Nettbutikk.Model.Product> getMostSold();
       // System.Collections.Generic.List<Nettbutikk.Model.OrderLine> getOrder(int id);
       // System.Collections.Generic.List<Nettbutikk.Model.Order> getOrders(int id);
       // System.Collections.Generic.List<Nettbutikk.Model.Order> getAll();


        List<Order> getAllOrders(int? id);
        List<OrderLine> getAllOrderLinesOfOrder(int id);

        Order getOrder(int id);
        bool checkOrder(int? id);
        Order findOrder(int id);
    }
}
