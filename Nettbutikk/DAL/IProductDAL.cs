using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface IProductDAL
    {
        Product get(int id);
        List<Category> getAllCategories();
        List<Product> getAll(int? id);
        List<Product> getAll(int? id, string sc, int? sort);
        List<string> getAutoComplete(string term);
        Product findProduct(int id);
        bool updateProduct(int id, Product p);
    }
}
