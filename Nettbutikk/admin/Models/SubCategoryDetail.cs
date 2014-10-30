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
    public class SubCategoryDetail
    {
        [Display (Name="Subkategori ID")]
        public int ID { get; set; }
        [Display(Name="Navn")]
        public string name { get; set; }
        public IEnumerable<SelectListItem> categoryList { get; set; }
    }
}