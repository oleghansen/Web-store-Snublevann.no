using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Model
{
    public class Order
    {
        
        public int id { get; set; }
      
        public DateTime orderdate { get; set; }
        public int customerid { get; set; }
        public Customer customer { get; set; }
        public List<OrderLine> orderLine { get; set; }
    }
}