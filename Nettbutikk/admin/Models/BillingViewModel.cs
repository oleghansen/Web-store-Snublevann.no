using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class BillingViewModel
    {
        
            public Customer customer { get; set; }
            public Order order { get; set; }
            [DisplayName("Ordredato")]
            [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
            public DateTime orderdate { get; set; }
            [DisplayName("Ordrenummer")]
            public int ordreid { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}")]
            public List<int> sum { get; set; }
            public List<OrderLine> shoppingcart { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}")]
            public double exmva { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}")]
            public double mva { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}")]
          
        
            
            public double totsum { get; set; }
            public int quantity { get; set; }
        
    }
}