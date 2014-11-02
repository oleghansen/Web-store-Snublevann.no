using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.admin.Models
{
    public class ProductInfo
    {
        [Display(Name = "Varenummer")]
        public int itemnumber { get; set; }
        [Display(Name = "Navn")]
        public String name { get; set; }
        [Display(Name = "Beskrivelse")]
        public String description { get; set; }
        [Display(Name = "Lang beskrivelse")]
        public String longDescription { get; set; }
        [Display(Name = "Pris (kr)")]
        public int price { get; set; }
        [Display(Name = "Volum (cl)")]
        public double volum { get; set; }
        [Display(Name = "Pris per liter")]
        public double pricePerLitre { get; set; }
        [Display(Name = "Produsent")]
        public String producer { get; set; }
        [Display(Name = "Kategori")]
        public String category { get; set; }
        [Display(Name = "Subkategori")]
        public String subCategory { get; set; }
        [Display(Name = "Subkategori ID")]
        public int subCategoryid { get; set; }
        [Display(Name = "Land")]
        public String country { get; set; }
        [Display(Name = "Kategori ID")]
        public int categoryid { get; set; }

    }
}
