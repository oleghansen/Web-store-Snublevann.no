using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface ICustomerBLL
    {
        List<Customer> getAll();
    }
}
