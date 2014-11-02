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
        [Display (Name="ID")]
        public int prodId { get; set; }
        [Display(Name="Navn")]
        [Required(ErrorMessage="Produsent må oppgis")]
        [RegularExpression(@"(^[a-zA-ZæÆøØåÅ\s]+$)", ErrorMessage = "Ugyldig produsentnavn")]
        public String prodName { get; set; }
    }
}