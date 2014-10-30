using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.admin.Models
{
    public class ProducerInfo
    {
        [Display (Name="Produsent ID")]
        public int prodId { get; set; }
        [Display(Name="Navn")]
        public String prodName { get; set; }
    }
}