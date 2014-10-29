using System;
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


        public List<Product> getResult(int? id, string s)
        {
            List<Product> allProducts = _product.getResult(id, s);

            return allProducts;
        }

        public Product seeDetails(int id)
        {
            return _product.findProduct(id);
        }

        public List<SubCategory> getAllSubCategories()
        {
            return _product.getAllSubCategories(); 
            
        }


        public List<Category> getAllCategories()
        {
            List<Category> allCategories = _product.getAllCategories();
            return allCategories;
        }

        public List<string> getAutoComplete(string term)
        {
            List<string> searchList = _product.getAutoComplete(term);
            return searchList; 
        }

        public bool updateProduct(int id, Product p)
        {
            return _product.updateProduct(id, p);
        }

        public bool addProduct(int id)
        {
            return _product.addProduct(id);
        }

        // TODO: fjern før levering
        public bool addCategoriesTest(int userId)
        {
            return _product.addCategoriesTest(userId);
        }

        public List<Country> getCountries()
        {
            List<Country> allCountries = _product.getCountries();
            return allCountries;
        }
    }
}
