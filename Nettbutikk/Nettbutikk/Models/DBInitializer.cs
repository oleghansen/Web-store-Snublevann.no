using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>//<Context>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Database.CreateIfNotExists();
            getCategories().ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
        }

        private List<Category> getCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    ID = 1,
                    Name = "Sjokolade"
                },
                new Category
                {
                    ID = 2,
                    Name = "Vingummi"
                },
                new Category
                {
                    ID = 3,
                    Name = "Lavkalori"
                }
            };


        }
    }
}