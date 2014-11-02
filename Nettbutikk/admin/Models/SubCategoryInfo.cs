using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class SubCategoryInfo
    {
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Display(Name = "Navn")]
        public string name { get; set; }
        [Display(Name = "Kategori")]
        public string categoriesName { get; set; }
    }
}