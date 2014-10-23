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