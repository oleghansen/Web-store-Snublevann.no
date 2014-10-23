using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IOrderBLL
    {
        List<Order> getAllOrders();
        List<OrderLine> getAllOrderLines(int id);
     

        Order getOne(int id);
    }
}
