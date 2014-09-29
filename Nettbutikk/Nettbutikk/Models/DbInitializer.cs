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
                new Producers {Name = "Ringnes"},
                new Producers {Name = "Carlsberg"},
                new Producers {Name = "Absolut Vodka"},
                new Producers {Name = "En vinprodusent"}
            };
            producers.ForEach(p => context.Producers.Add(p));
            var products = new List<Products>
            {
                new Products {Name="Juleøl", Description="En juleøl fra Ringnes",LongDescription="En meget god Juleøl fra Ringnes som fungerer godt til Juleribbe og til Pinnekjøtt!", Price=200,ProducersID=1,CategoriesID=1},
                new Products {Name="Carlsberg Øl", Description="En dansk øl", LongDescription="En god dansk øl, som passer godt til god dansk pølse", Price=32, ProducersID=2,CategoriesID=1},
                new Products {Name="Absolut Mandarin", Description="Vodka med mandarinsmak", LongDescription="En brennevin av typen vodka som er tilsatt et par mandariner", Price=280, ProducersID=3, CategoriesID=3},
                new Products {Name="Jacob's Creek", Description="Rød vin", LongDescription="En rød vin som er billig", Price=80, ProducersID=4, CategoriesID=2}
            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

        }

    }
}