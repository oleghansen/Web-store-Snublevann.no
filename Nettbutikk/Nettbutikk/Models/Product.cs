using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Product
    {
        public int itemnumber { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public int price { get; set; }
        public String producer { get; set; }
    }
}