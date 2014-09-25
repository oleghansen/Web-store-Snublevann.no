using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Category
    {

        public int ID { get; set; }
        public String Name { get; set; }
        public virtual List<Product> Products { get; set; } 
    }
}