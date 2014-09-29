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
                new Category {name="Øl"},
                new Category {name="Vin"},
                new Category {name="Brennevin"}
            };

            // add data into context and save to db


            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var products = new List<Products>
            {
                new Products {Name="Høne", Description="Hei", Price=200}

            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

        }

    }
}