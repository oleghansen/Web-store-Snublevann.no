using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Kategori")]
        public string name { get; set; }

        //public Product product { get; set; }
    }
}