using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.admin.Models
{
    public class CustomerDetail
    {
        public int id { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String email { get; set; }
        public String phonenumber { get; set; }
        public String address { get; set; }
        public String postalcode { get; set; }
        public String postalarea { get; set; }
        public bool admin { get; set; }

    }
}