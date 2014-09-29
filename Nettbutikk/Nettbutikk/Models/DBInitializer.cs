using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>//<context>
    {
        protected override void Seed(DatabaseContext context)
        {
            context.Database.CreateIfNotExists();
            getCategories().ForEach(c => context.Categories.Add(c));
            context.SaveChanges();
        }

        private List<Categories> getCategories()
        {
            return new List<Categories>()
            {
                new Categories
                {
                    ID = 1,
                    Name = "Øl"
                },
                new Categories
                {
                    ID = 2,
                    Name = "Brennevin"
                },
                new Categories
                {
                    ID = 3,
                    Name = "Rødvin"
                },
                new Categories
                {
                    ID = 4,
                    Name = "Hvitvin"
                },
                new Categories
                {
                    ID = 5,
                    Name = "Rosevin"
                },
                new Categories
                {
                    ID = 6,
                    Name = "Likør"
                },
            };
        }
    }
}