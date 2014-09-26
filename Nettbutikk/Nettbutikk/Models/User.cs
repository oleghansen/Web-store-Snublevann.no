using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class User
    {
        [Key]
        public String username { get; set; }
        public byte[] password { get; set; }
    }
}