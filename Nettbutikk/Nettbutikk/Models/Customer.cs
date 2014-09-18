using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Customer
    {
        public int id { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String email { get; set; }
        public String phonenumber { get; set; }
        public String address { get; set; }
        public int postalcode { get; set; }
        public Postalareas postalarea { get; set; }

    }
}