using System;
using System.Collections.Generic;
using System.Linq;
using Nettbutikk.Models;

namespace Nettbutikk
{
    public class DBProduct
    {
        public List<Product> getAll()
        {
            var db = new DatabaseContext();
            List<Product> allProducts = db.Products.Select(p => new Product()
                {
                    Itemnumber = p.Itemnumber,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Producers = p.Producers.Name,
                    Categories = p.Categories.Name
                }
            ).ToList();
            return allProducts;
        }

        public bool add(Product inProduct)
        {
            var newProduct = new Product()
            {
                Itemnumber = inProduct.Itemnumber,
                Name = inProduct.Name,
                Description = inProduct.Description,
                Price = inProduct.Price
               // Producer = inProduct.producer , må hente fra DbSet Producers?
               // Category = inProduct.category , må hente fra DbSet Categories?
            };

            var db = new ProductContext();
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