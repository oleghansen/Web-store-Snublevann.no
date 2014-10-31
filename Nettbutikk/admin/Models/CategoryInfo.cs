using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.admin.Models
{
    public class CategoryInfo
    {
        [Display(Name = "ID nummer")]
        public int id { get; set; }
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategorinavn må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig kategorinavn")]
        public String name { get; set; }
    }
}