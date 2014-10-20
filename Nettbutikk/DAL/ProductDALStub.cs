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
    }
}
