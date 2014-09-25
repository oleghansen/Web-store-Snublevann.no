using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
        public int CustomerID { get; set; }
    }
}