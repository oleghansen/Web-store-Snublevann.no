using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class BillingViewModel
    {
        public int id { get; set; }
        public Customer customer { get; set; }
        public Order order { get; set; }
        public Product product { get; set; }
        public int orderlineSum { get; set; }
        public int exmva { get; set; }
        public int mva { get; set; }
        public int sum { get; set; }
    }
}