﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class ProductDALStub : DAL.IProductDAL
    {
        public List<Category> getAllCategories()
        {
            return null;
        }
        public List<Product> getAll()
        {
            var prod = new Product()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei"
            };
            List<Product> productlist = new List<Product>();
            productlist.Add(prod);
            return productlist;
        }

        public List<Product> getResult( string searchstring)
        {
            var prod = new Product()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei"
            };
            List<Product> productlist = new List<Product>();
            productlist.Add(prod);
            return productlist;
        }



        public List<string> getAutoComplete(string term)
        {
            return null;
        }

        public Product findProduct(int id)
        {
            var product = new Product()
            {
                itemnumber = 1,
                name = "Tull",
                description = "Ball",
                price = 230,
            };
            return product;   
        }


        public bool updateProduct(int id, Product p)
        {
            if (id == 0 || p == null)
                return false;
            return true;
        }

        public Product deleteProduct(int id)
        {
            var product = new Product()
            {
                itemnumber = 1,
                name = "dfsdf",
                description = " dfsfsf"
            };
            return product;
        }

        public List<SubCategory> getAllSubCategories()
        {
            return null;
        }


        public Product addProduct(int id, Product p)
        {
            if (id == 0)
                return null;
            return null;
        }

        public List<Country> getCountries()
        {

            return null; 
        }
        public List<Producer> getProducers()
        {
            return null; 
        }
        public bool deleteProduct(int id, int adminid)
        {
            return false; 
        }
    }
}
