using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IProductBLL
    {
        List<Product> getAll();

        Product seeDetails(int i);

        bool updateProduct(int id, Product p);
    }
}
