using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class OrderViewModel
    {
        [DisplayName("Ordrenummer")]
        public int id { get; set; }
        [DisplayName("Ordredato")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime orderdate { get; set; }
       [DisplayName("KundeId")]
        public int customerid { get; set; }
         [DisplayName("Fornavn")]
       public String firstname { get; set; }
         [DisplayName("Etternavn")]
         public String lastname { get; set; }
        public Customer customer { get; set; }
        [DisplayName("Antall")]
        public int quantity { get; set; }
        [DisplayName("Sum")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int sum { get; set; }
      
    }
}