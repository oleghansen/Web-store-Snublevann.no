using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk.Models;
using System.Web.WebPages.Html;
using System.Data.Entity;

namespace Nettbutikk
{

    

    public class DBProduct
    {
        public List<Product> getAll(int? id)
        {
            var db = new DatabaseContext();
            List<Product> allProducts = new List<Product>();
            if (id.HasValue)
            {

                var products = db.Products.Include(p => p.SubCategories.Categories).Where(p => p.SubCategories.CategoriesId == id).ToList();

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
                        subCategory = p.SubCategories.Name,
                        country = p.Countries.Name

                    };
                    allProducts.Add(product);
                }
            }
            else
            {
                var products = db.Products.Include(p => p.SubCategories.Categories).ToList();
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
                        subCategory = p.SubCategories.Categories.Name,
                        country = p.Countries.Name
                    };
                    allProducts.Add(product);
                }
            }

            return allProducts;
        }
        public Product get(int id)
        {
            var db = new DatabaseContext();
            Products products = db.Products.Include(p => p.SubCategories.Categories).Where(p=> p.Id == id).First<Products>();
            //Products products = db.Products.Where(p=> p.Id == id).First<Products>();
            return new Product()
            {
                itemnumber = products.Id,
                name = products.Name,
                description = products.Description,
                longDescription = products.LongDescription,
                price = products.Price,
                volum = products.Volum,
                producer = products.Producers.Name,
                category = products.SubCategories.Categories.Name,
                country = products.Countries.Name
            };
        }

        public List<Product> getResult(string searchString)
        {
            var db = new DatabaseContext();
            List<Product> foundProducts;
            foundProducts = db.Products.AsEnumerable().Where(p => p.Name.ToUpper().Contains(searchString.ToUpper())
                            || p.Description.ToUpper().Contains(searchString.ToUpper())).Select(p => new Product()
                            {                    
                                itemnumber = p.Id,
                                name = p.Name,
                                description = p.Description,
                                price = p.Price,
                                volum = p.Volum,
                                producer = p.Producers.Name,
                                category = p.SubCategories.Categories.Name
                            }).ToList();
            return foundProducts;
        }
    }
}