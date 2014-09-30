using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        public String firstname { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        public String lastname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis")]
        public String email { get; set; }
         [Display(Name = "Telefonnummer")]
        public String phonenumber { get; set; }
        [Display(Name = "Adresse")]
        public String address { get; set; }
        [Display(Name = "Postnummer")]
        public int postalcode { get; set; }
        [Display(Name = "Poststed")]
        public Postalareas postalarea { get; set; }
        [Display(Name = "Brukernavn")]
        [Required(ErrorMessage = "Brukernavn må oppgis")]
        public String username { get; set; }
        [Display(Name = "Passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public String password { get; set; }

        public ShoppingCart shoppingcart; 

    }
}