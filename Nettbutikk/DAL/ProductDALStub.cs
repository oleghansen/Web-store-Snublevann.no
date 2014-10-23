using Nettbutikk.Model;
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
        public List<Product> getAll(int? id, String sc, int? sort)
        {
            return new List<Product>();
        }

        public List<Product> getAll(int? id)
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

        public Product get(int id)
        {
            return null;
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
                description = "Ball"
            };
            return product;   
        }


        // Har ikke testet denne metoden
        public bool updateProduct(int id, Product update)
        {
            var db = new DatabaseContext();
            try
            {
                Products products = db.Products.FirstOrDefault(u => u.Id == id);

                products.Name = update.name;
                products.Description = update.description;
                products.LongDescription = update.longDescription;
                products.Price = update.price;
                products.Volum = update.volum;

                db.SaveChanges();
                return true;
            }
            catch(Exception fail)
            {
                return false;
            }
        }
    }
}
