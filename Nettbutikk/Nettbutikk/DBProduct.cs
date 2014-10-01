using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk.Models;
using System.Web.WebPages.Html;

namespace Nettbutikk
{

    

    public class DBProduct
    {
        public List<Product> getAll(int? id)
        {
            var db = new DatabaseContext();
            List<Product> allProducts;
            if(id.HasValue)
                allProducts = db.Products.AsEnumerable().Where(c => c.CategoriesID == id).Select(p => new Product()
                {
                    itemnumber = p.Itemnumber,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price,
                    volum = p.Volum,
                    producer = p.Producers.Name,
                    category = p.Categories.Name
                }
            ).ToList();
            else
                allProducts = db.Products.AsEnumerable().Select(p => new Product()
                {
                    itemnumber = p.Itemnumber,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price,
                    volum = p.Volum,
                    producer = p.Producers.Name,
                    category = p.Categories.Name
                }
            ).ToList();
            return allProducts;
        }
        public Product get(int id)
        {
            var db = new DatabaseContext();
            Products products = db.Products.Where(p=> p.Itemnumber == id).First<Products>();
            return new Product()
            {
                itemnumber = products.Itemnumber,
                name = products.Name,
                description = products.Description,
                longDescription = products.LongDescription,
                price = products.Price,
                volum = products.Volum,
                producer = products.Producers.Name,
                category = products.Categories.Name
            };
        }

        public List<Product> getResult(string searchString)
        {
            var db = new DatabaseContext();
            List<Product> foundProducts;
            foundProducts = db.Products.AsEnumerable().Where(p => p.Name.ToUpper().Contains(searchString.ToUpper())
                            || p.Description.ToUpper().Contains(searchString.ToUpper())).Select(p => new Product()
                            {                    
                                itemnumber = p.Itemnumber,
                                name = p.Name,
                                description = p.Description,
                                price = p.Price,
                                volum = p.Volum,
                                producer = p.Producers.Name,
                                category = p.Categories.Name
                            }).ToList();
            return foundProducts;
        }


        public bool add(Product inProduct)
        {
            var newProduct = new Products()
            {
                Itemnumber = inProduct.itemnumber,
                Name = inProduct.name,
                Description = inProduct.description,
                Price = inProduct.price,
                Volum = inProduct.volum
               // Producer = inProduct.producer , må hente fra DbSet Producers?
               // Category = inProduct.category , må hente fra DbSet Categories?
            };

            var db = new DatabaseContext();
            try
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }



    }
}