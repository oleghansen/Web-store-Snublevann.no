using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string name { get; set; }
        public Product product { get; set; }
    }
}