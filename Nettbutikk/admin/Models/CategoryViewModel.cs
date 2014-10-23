using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.admin.Models
{
    public class CategoryViewModel
    {
        public int SelectedCategoryId { get; set; }
        public String CategoriesName { get; set; }
    }
}