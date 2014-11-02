using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.admin.Models
{
    public class UserInfo
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Fornavn")]
        public String firstname { get; set; }
        [Display(Name = "Etternavn")]
        public String lastname { get; set; }
        [Display(Name = "E-postaddresse")]
        public String email { get; set; }
        [Display(Name = "Telefonnummer")]
        public String phonenumber { get; set; }
        [Display(Name = "Adresse")]
        public String address { get; set; }
        [Display(Name = "Postnummer")]
        public String postalcode { get; set; }

        [Display(Name = "Poststed")]
        public String postalarea { get; set; }
        [Display(Name = "Passord")]
        public String password { get; set; }
        public byte[] hashpassword { get; set; }

        [Display(Name = "Admin")]
        public bool admin { get; set; }

        //public ShoppingCart shoppingcart;
        //public List<Orders> Orders { get; set; }

    }
}