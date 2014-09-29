using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Nettbutikk.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var categories = new List<Categories>
            {
                new Categories {Name="Øl"},
                new Categories {Name="Vin"},
                new Categories {Name="Brennevin"}
            };

            // add data into context and save to db


            categories.ForEach(c => context.Categories.Add(c));

            var producers = new List<Producers>
            {
                new Producers {Name = "Ringnes"}
            };
            producers.ForEach(p => context.Producers.Add(p));
            var products = new List<Products>
            {
                new Products {Name="Juleøl", Description="Hei", Price=200,ProducersID=1,CategoriesID=1}
            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

        }

    }
}