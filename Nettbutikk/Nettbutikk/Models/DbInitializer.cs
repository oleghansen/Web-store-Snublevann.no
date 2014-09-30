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
                new Categories {Name="Øl", ID=1},
                new Categories {Name="Vin", ID=2},
                new Categories {Name="Brennevin", ID=3}
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
                new Products {Name="Juleøl", Description="En juleøl fra Ringnes",LongDescription="En meget god Juleøl fra Ringnes som fungerer godt til Juleribbe og til Pinnekjøtt!", Price=200,ProducersID=1,CategoriesID=1}
            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

        }

    }
}