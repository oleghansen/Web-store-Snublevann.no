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

        public List<Product> getAll()
        {
            List<Product> allProducts = _product.getAll();
            return allProducts;
        }


        public List<Product> getResult( string s)
        {
            List<Product> allProducts = _product.getResult(s);

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

        public bool updateProduct(int id,Product p)
        {
            return _product.updateProduct(id,p);
        }

        public Product addProduct(int id, Product p)
        {
            return _product.addProduct(id,p);
        }


        public List<Country> getCountries()
        {
            List<Country> allCountries = _product.getCountries();
            return allCountries;
        }

        public List<Producer> getProducers()
        {
            return _product.getProducers();
        }
        public bool deleteProduct(int id, int adminid)
        {
            return _product.deleteProduct(id, adminid); 
        }
    }
}
