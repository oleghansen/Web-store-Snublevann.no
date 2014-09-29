using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var categories = new List<Category>
            {
                new Category {name="Admin"},
                new Category {name="ProjectManager"},
                new Category {name="Developer"}
            };

            // add data into context and save to db
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

        }
    }
}