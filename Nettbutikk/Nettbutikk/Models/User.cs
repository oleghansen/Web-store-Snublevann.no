using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class User
    {
        public Customer user { get; set; }
        [Required(ErrorMessage = "Bruker må oppgis")]
        public String userName { get; set; }
        [Required(ErrorMessage = "PAssord må oppgis")]
        public String password { get; set; }
    }
}