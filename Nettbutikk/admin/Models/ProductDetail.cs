﻿using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.admin.Models
{
    public class ProductDetail
    {
        public int itemnumber { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String longDescription { get; set; }
        public int price { get; set; }
        public double volum { get; set; }
        public double pricePerLitre { get; set; }
        public String producer { get; set; }

        public int subCategoryid { get; set; }
        public String country { get; set; }
        public int categoryid { get; set; }
        public List<SubCategory> subCategory { get; set; }

    }
}