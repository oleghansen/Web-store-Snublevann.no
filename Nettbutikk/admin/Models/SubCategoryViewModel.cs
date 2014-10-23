using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public String name { get; set; }
        public CategoryViewModel categoryName { get; set; }
    }
}