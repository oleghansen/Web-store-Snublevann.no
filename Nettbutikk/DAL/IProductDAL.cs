using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface IProductDAL
    {
        Product get(int id);
        List<Category> getAllCategories();
        List<Product> getAll();
        List<Product> getResult(string searchstring);
        List<Product> getAll(int? id, string sc, int? sort);
        List<string> getAutoComplete(string term);
        Product findProduct(int id);
        bool updateProduct(int id,Product p);
        bool addProduct(int id, Product p);
        List<SubCategory> getAllSubCategories();

        //TODO: fjern før levering
        bool addCategoriesTest(int userId);

        List<Country> getCountries();
        List<Producer> getProducers();

    }
}
