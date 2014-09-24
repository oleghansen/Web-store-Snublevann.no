using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Product
    {
        
        public int itemnumber { get; set; }
        [Display(Name = "Varenummer")]
       
        public String name { get; set; }
        [Display(Name = "Produktnavn")]
       
        public String description { get; set; }
        [Display(Name = "Beskrivelse")]
        
        public int price { get; set; }
        [Display(Name = "Pris")]
        public String producer { get; set; }
        [Display(Name = "Produsent")]
        
        public String category { get; set; }
        [Display(Name = "Kategori")]
        public int producerid { get; set; }
        public int categoryid { get; set; }
    }
}