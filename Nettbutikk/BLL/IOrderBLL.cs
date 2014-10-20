using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IOrderBLL
    {
        List<Order> getAll();

        Order getOne(int id);
    }
}
