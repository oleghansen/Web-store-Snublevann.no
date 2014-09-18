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
            var db = new DatabaseContext();
            List<Product> allProducts = db.Products.Select(p => new Product()
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

    }
}