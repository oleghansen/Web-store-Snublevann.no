using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Nettbutikk.Models.Search
{
    public class Search
    {
        public IEnumerable<Nettbutikk.Models.Product> UserSearch { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Beskrivelse")]
        public string desctiption { get; set; }
        [Display(Name = "Pris")]
        public int price { get; set; }
        [Display(Name = "Produsent")]
        public string producer { get; set; }
    }

}