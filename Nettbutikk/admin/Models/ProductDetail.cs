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
        [Required(ErrorMessage = "Produktnavn må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig produktnavn")]
        public String name { get; set; }
        [Display(Name="Beskrivelse")]
        [Required(ErrorMessage = "Beskrivelse må oppgis")]
        public String description { get; set; }
        [Display(Name="Lang beskrivelse")]
        [Required(ErrorMessage = "Lang beskrivelse må oppgis")]
        public String longDescription { get; set; }
        [Display(Name="Pris")]
        [Required(ErrorMessage="Pris må oppgis")]
        [RegularExpression(@"(^[0-9]+$)", ErrorMessage = "Kun tall i pris")]
        public int price { get; set; }
        [Display(Name="Volum")]
        [Required(ErrorMessage="Volum må oppgis")]
        public double volum { get; set; }
        [Display(Name="Pris per liter")]
        public double pricePerLitre { get; set; }
        [Display(Name="Produsent")]
        public int producerid { get; set; }
        [Display(Name="Subkategori")]
        public int subCategoryid { get; set; }
        [Display(Name="Land")]
        public int countryid { get; set; }
        public IEnumerable<SelectListItem> countryList { get; set; }
        public IEnumerable<GroupedSelectListItem> subCategoryList { get; set; }
        public IEnumerable<SelectListItem> producerList { get; set; }


    }
}
