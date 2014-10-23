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
        public List<Product> getAll(int? id, String sc, int? sort)
        {
            return new List<Product>();
        }

        public List<Product> getAll(int? id, int? sort)
        {
            return null;
        }
        public List<Product> getAll()
        {
            var db = new DatabaseContext();
            var products = db.Products.ToList();
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

        public List<Product> getResult(string searchString)
        {
            var db = new DatabaseContext();
            var foundProducts = new List<Product>();
            var products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.Name.ToUpper().Contains(searchString.ToUpper())
                            || p.Description.ToUpper().Contains(searchString.ToUpper())).ToList();
            foreach (var p in products)
            {
                var product = new Product()
                {
                    itemnumber = p.Id,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price,
                    volum = p.Volum,
                    producer = p.Producers.Name,
                    category = p.SubCategories.Categories.Name,
                    categoryid = p.SubCategories.Categories.Id,
                    subCategory = p.SubCategories.Name,
                    subCategoryid = p.SubCategories.Id,
                    country = p.Countries.Name
                };
                foundProducts.Add(product);
            }
            return foundProducts;
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


        // TODO: Denne skal testes på web når siden er oppe!

        public bool updateProduct(int id, Product update)
        {
            return false;
        }
            /*
            var db = new DatabaseContext();
            try
            {
                Products prod = db.Products.FirstOrDefault(u => u.Id == id);

                prod.Name = update.name;
                prod.Description = update.description;
                prod.LongDescription = update.longDescription;
                prod.Price = update.price;
                prod.Volum = update.volum;

                    
                // TODO: Trenger mer i denne metoden
                db.SaveChanges();
                return true;
            }
            catch (Exception fail)
            {
                return false;
            }
        }
         */
    }
}