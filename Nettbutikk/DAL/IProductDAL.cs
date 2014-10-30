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
        List<Product> getResult(int? id, string sc);
        List<Product> getAll(int? id, string sc, int? sort);
        List<string> getAutoComplete(string term);
        Product findProduct(int id);
        bool updateProduct(int id,Product p);
        bool addProduct(int id);
        List<SubCategory> getAllSubCategories();

        //TODO: fjern før levering
        bool addCategoriesTest(int userId);

        List<Country> getCountries();
        List<Producer> getProducers();

    }
}
