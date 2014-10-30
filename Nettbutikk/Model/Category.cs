using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{
    public class Category
    {
        [Display(Name = "ID nummer")]
        public int ID { get; set; }

        [Display(Name = "Kategori")]
        public string name { get; set; }
        public string subCategoryName { get; set; }
    }
    public class SubCategory
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string catName { get; set; }
    }
}
