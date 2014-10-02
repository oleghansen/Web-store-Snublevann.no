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
        [RegularExpression(@"(^[a-zA-Z\s]+$)", ErrorMessage = "Ugyldig fornavn")]
        public String firstname { get; set; }
        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression(@"(^[a-zA-Z\s]+$)", ErrorMessage = "Ugyldig etternavn")]
        public String lastname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email må oppgis")]
        [RegularExpression(@"(^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$)", ErrorMessage = "Ugyldig email")]
        public String email { get; set; }
         [Display(Name = "Telefonnummer")]
         [RegularExpression(@"(^[0-9\+\(\)]+$)", ErrorMessage = "Ugyldig telefonnummer")]
        public String phonenumber { get; set; }
        [Display(Name = "Adresse")]
        [RegularExpression(@"(^[a-zA-Z0-9\s]+$)", ErrorMessage = "Ugyldig adresse")]
        public String address { get; set; }
        [Display(Name = "Postnummer")]
        [RegularExpression(@"(^[0-9]{4})", ErrorMessage = "Ugyldig postnummer")]
        public int postalcode { get; set; }
        [Display(Name = "Poststed")]
        [RegularExpression(@"(^[a-zA-Z]+$)", ErrorMessage = "Ugyldig poststed")]
        public String postalarea { get; set; }
        [Display(Name = "Brukernavn")]
        [RegularExpression(@"(^[a-zA-Z0-9_]+$)", ErrorMessage = "Ugyldig brukernavn")]
        [Required(ErrorMessage = "Brukernavn må oppgis")]
        public String username { get; set; }
        [Display(Name = "Passord")]
        [RegularExpression(@"(^[a-zA-Z0-9]+$)", ErrorMessage = "Ugyldig passord")]
        [Required(ErrorMessage = "Passord må oppgis")]
        public String password { get; set; }

        public byte[] hashpassword { get; set; }

        public ShoppingCart shoppingcart;
        public List<Orders> Orders { get; set; }

    }
}