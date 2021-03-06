﻿using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IOrderBLL
    {
        List<Order> getAllOrders(int? id);
        int getNumItems(Order o);
        int getSum(Order o);

        double getExmva(int sum);

        double getMva(int sum);
    }
}
