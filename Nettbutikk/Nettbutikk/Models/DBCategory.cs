using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class DBCategory
    {
        public List<Category> getAll()
        {
            var db = new DatabaseContext();
            List<Category> all = db.Categories.AsEnumerable().Select(p => new Category()
            {
                ID = p.ID,
                name = p.Name,
            }
            ).ToList();
            return all;
        }
    }
}