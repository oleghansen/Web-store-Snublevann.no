using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk.Model;
using System.Data.Entity;

namespace Nettbutikk.DAL
{

    public class ProductDAL : DAL.IProductDAL
    {
        public List<Category> getAllCategories()
        {
            var db = new DatabaseContext();
            var categories = db.Categories.ToList();
            var list = new List<Category>();
            foreach (var item in categories)
            {
                list.Add(new Category()
                {
                    ID = item.Id,
                    name = item.Name
                });
            }
            return list; 
        }
        public List<Product> getAll(int? id, String sc, int? sort)
        {
            return new List<Product>();
        }

        public List<Product> getAll(int? id)
        {
            var db = new DatabaseContext();
            List<Products> products; 
            if(id != null)
                products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).ToList();
            else
                products = db.Products.Include(p => p.SubCategories.Categories).ToList();
            var list = new List<Product>();
            foreach (var item in products)
            {
                list.Add(new Product()
                {
                    itemnumber = item.Id,
                    name = item.Name,
                    description = item.Description,
                    price = item.Price,
                    volum = item.Volum,
                    producer = item.Producers.Name,
                    country = item.Countries.Name
                });
            }
            return list;
        }
 
        public Product get(int id)
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

        public List<string> getAutoComplete(string term)
        {
            return null;
        }
    }
}