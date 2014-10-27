using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class OrderLineViewModel
    {
        public int id { get; set; }
       // public DateTime orderdate
        public Customer customer { get; set; }
        public Order order { get; set; }
        public Product product { get; set; }
        public int orderlineSum { get; set; }
        public int quantity { get; set; }
        
    }
}