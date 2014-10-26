using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IProductBLL
    {
        List<Category> getAllCategories();
        List<Product> getAll(int? id);
        Product seeDetails(int i);

        bool updateProduct(int id, Product p);
    }
}
