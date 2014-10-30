using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nettbutikk.admin.Models
{
    public class ProductDetail
    {
        [Display(Name="Varenummer")]
        public int itemnumber { get; set; }
        [Display(Name="Produktnavn")]
        public String name { get; set; }
        [Display(Name="Beskrivelse")]
        public String description { get; set; }
        [Display(Name="Lang beskrivelse")]
        public String longDescription { get; set; }
        [Display(Name="Pris")]
        public int price { get; set; }
        [Display(Name="Volum")]
        public double volum { get; set; }
        [Display(Name="Pris per liter")]
        public double pricePerLitre { get; set; }
        [Display(Name="Produsent")]
        public String producer { get; set; }
        [Display(Name="Sub kategori")]
        public int subCategoryid { get; set; }
        [Display(Name="Land")]
        public int countryid { get; set; }
        public IEnumerable<SelectListItem> countryList { get; set; }
        public IEnumerable<SelectListItem> subCategoryList { get; set; }

    }
}
