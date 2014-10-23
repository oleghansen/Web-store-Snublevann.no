using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class ProductMenu
    {
        public List<ProductInfo> productInfo { get; set; }
        public List<CategoryViewModel> categories { get; set; }
    }
}