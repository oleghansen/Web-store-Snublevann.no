﻿using Nettbutikk.Model; 
using System;
using System.Collections.Generic;
namespace Nettbutikk.BLL
{
    public interface IProductBLL
    {
        List<Category> getAllCategories();
        List<Product> getAll();
        List<Product> getResult( string searchstring);
        
        List<string> getAutoComplete(string term);
        Product seeDetails(int i);

        bool updateProduct(int id, Product p);
        bool addProduct(int id, Product p);
        //TODO:fjern før levering
        bool addCategoriesTest(int userId);
        List<SubCategory> getAllSubCategories();
        List<Country> getCountries();
        List<Producer> getProducers(); 
    }
}
