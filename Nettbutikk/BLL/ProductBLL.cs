using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class ProductBLL : BLL.IProductBLL
    {
        private IProductDAL _product;
        public ProductBLL()
        {
            _product = new ProductDAL(); 
        }
        public ProductBLL(IProductDAL stub)
        {
            _product = stub;
        }

        public List<Product> getAll()
        {
            List<Product> allProducts = _product.getAll();
            return allProducts;
        }

        public Product seeDetails(int id)
        {
            return _product.findProduct(id);
        }

        public bool updateProduct(int id, Product p)
        {
            return _product.updateProduct(id, p);
        }



    }
}
