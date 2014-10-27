using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class OrderLineViewModel
    {
        [DisplayName("Linje")]
        public int id { get; set; }
        [DisplayName("Ordredato")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime orderdate { get; set; }
        [DisplayName("Ordrenummer")]
        public int orderId { get; set; }
        [DisplayName("Kundenummer")]
        public int customerid { get; set; }
        public Customer customer { get; set; }
        public Order order { get; set; }
        public Product product { get; set; }
        [DisplayName("Sum")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int orderlineSum { get; set; }
        [DisplayName("Antall")]
        public int quantity { get; set; }
        
    }
}