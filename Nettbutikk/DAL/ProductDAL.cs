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
            return null;
        }

        public List<Product> getAll(int? id, int? sort)
        {
            return null;
        }
        public List<Product> getAll()
        {
            return null;
        }
        public Product get(int id)
        {
            return null;
        }

        public List<string> getAutoComplete(string term)
        {
            return null;
        }
    }
}