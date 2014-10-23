using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class Orders
    {
        public int id { get; set; }
        public DateTime orderdate { get; set; }
        public int customerid { get; set; }
        public String firnstname { get; set; }
        public String lastname { get; set; }
        public int quantity { get; set; }
        public int sum { get; set; }
      
    }
}