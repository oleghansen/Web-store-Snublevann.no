using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class BillingDocument
    {
        public Customer customer { get; set; }
        public Order order { get; set; }
        public ShoppingCart shoppingcart { get; set; }
        public double exmva { get; set; }
        public double mva { get; set; }
        public int sum { get; set; }


    }
}