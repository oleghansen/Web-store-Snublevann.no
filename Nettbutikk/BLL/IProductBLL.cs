using Nettbutikk.Model; 
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IProductBLL
    {
        List<Category> getAllCategories();
        List<Product> getAll(int? id);
        List<Product> getResult(int? id, string sc);
        
        List<string> getAutoComplete(string term);
        Product seeDetails(int i);

        bool updateProduct(int id, Product p);
        bool addProduct(int id);
        //TODO:fjern før levering
        bool addCategoriesTest(int userId);
    }
}
