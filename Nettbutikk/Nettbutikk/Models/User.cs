using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class User
    {
        public Customer Customer { get; set; }
        public String Username { get; set; }
        public byte[] Password { get; set; }
    }
}