using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class PostalArea
    {
        [Key]
        public int Postalcode { get; set; }
        public String Postalareas { get; set; }
    }
}