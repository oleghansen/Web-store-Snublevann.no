using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;

namespace Nettbutikk.BLL
{
    class ProductBLL
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



    }
}
