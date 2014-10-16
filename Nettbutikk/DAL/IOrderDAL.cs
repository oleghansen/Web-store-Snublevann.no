using System;
namespace Nettbutikk.DAL
{
    interface IOrderDAL
    {
        int checkout(ShoppingCart cart);
        System.Collections.Generic.List<Nettbutikk.Model.Product> getMostSold();
        System.Collections.Generic.List<Nettbutikk.Model.OrderLine> getOrder(int id);
        System.Collections.Generic.List<Nettbutikk.Model.Order> getOrders(int id);
    }
}
