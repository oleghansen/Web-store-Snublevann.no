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
        public List<Product> getAll()
        {
            var db = new ProductContext();
            List<Product> allProducts = db.Products.AsEnumerable().Select(p => new Product()
                {
                    itemnumber = p.Itemnumber,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price,
                    producer = p.Producers.Name,
                    category = p.Categories.Name
                }
            ).ToList();
            return allProducts;
        }

        /*public bool add(Product inProduct)
        {
            var newProduct = new Products()
            {
                Itemnumber = inProduct.itemnumber,
                Name = inProduct.name,
                Description = inProduct.description,
                Price = inProduct.price
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
        }*/



    }
}