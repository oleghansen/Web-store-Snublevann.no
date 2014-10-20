using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Model
{
    public class Customer
    {

        public int id { get; set; }
 
        public String firstname { get; set; }

        public String lastname { get; set; }
 
        public String email { get; set; }
 
        public String phonenumber { get; set; }

        public String address { get; set; }

        public String postalcode { get; set; }
 
        public String postalarea { get; set; }
 
        public String password { get; set; }
        public byte[] hashpassword { get; set; }

        public bool admin { get; set; }
    }
}