﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class ProductBLL : BLL.IProductBLL
    {
        private IProductDAL _product;
        public ProductBLL()
        {
            _product = new ProductDAL(); 
        }
        public ProductBLL(IProductDAL stub)
        {
            _product = stub;
        }

        public List<Product> getAll(int? id)
        {
            List<Product> allProducts = _product.getAll(id);

            return allProducts;
        }

        public Product seeDetails(int id)
        {
            return _product.findProduct(id);
        }

        public List<Category> getAllCategories()
        {
            List<Category> allCategories = _product.getAllCategories();
            return allCategories;
        }

    }
}
