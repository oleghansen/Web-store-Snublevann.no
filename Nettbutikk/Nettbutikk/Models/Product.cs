using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Product
    {
        [Key]
        public int Itemnumber { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public int ProducersID { get; set; }
        public virtual Producer Producers { get; set; }
        public int CategoriesID { get; set; }
        public virtual Category Categories { get; set; }
        public virtual List<OrderLine> Orderlines { get; set; }
    }
}