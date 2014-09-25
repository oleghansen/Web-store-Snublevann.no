using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Phonenumber { get; set; }
        public String Address { get; set; }
        public int Postalcode { get; set; }
        public Postalarea Postalareas { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}