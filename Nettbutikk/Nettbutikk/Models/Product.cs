using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Product
    {
        [Display(Name = "Varenummer")]
        public int itemnumber { get; set; }
        [Display(Name = "Produktnavn")]
        public String name { get; set; }
        [Display(Name = "Beskrivelse")]
        public String description { get; set; }
        [Display(Name = "Pris")]
        public int price { get; set; }
        [Display(Name = "Produsent")]
        public String producer { get; set; }
        [Display(Name = "Kategori")]
        public String category { get; set; }
        public int producerid { get; set; }
        public int categoryid { get; set; }
    }
}