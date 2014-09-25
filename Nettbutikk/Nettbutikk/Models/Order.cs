using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Order
    {
        public int id { get; set; }
        public DateTime orderdate { get; set; }
        public int customerid { get; set; }
        // setter ikke opp en public Customer customer her, for vi antar at en kunde opprettes før en ordre, og ikke samtidig. 
        public List<OrderLine> orderline { get; set; }
    }
}