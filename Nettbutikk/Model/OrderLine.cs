using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.Model
{
    public class OrderLine
    {
        public int id { get; set; }
        public int productid { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        public int orderid { get; set; }
        public Order order { get; set; }


    }
}
