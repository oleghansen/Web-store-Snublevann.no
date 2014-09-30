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
                new Producers {Name = "Ringnes"},//1
                new Producers {Name = "Carlsberg"},//2
                new Producers {Name = "Absolut Vodka"},//3
                new Producers {Name = "En vinprodusent"},//4
                new Producers {Name = "Nøgne Ø"},//5
                new Producers {Name = "Aas Bryggeri"},//6
                new Producers {Name = "Haandbryggeriet"},//7
                new Producers {Name = "Kinn brygghus"},//8
                new Producers {Name = "Brouwerij Verhaeghe"},//9
                new Producers {Name = ""},//10
                new Producers {Name = ""},//11
                new Producers {Name = ""},//12
                new Producers {Name = ""},//13
                new Producers {Name = ""},//14
                new Producers {Name = ""},//15
                new Producers {Name = ""},//16
                new Producers {Name = ""},//17
                new Producers {Name = ""},//18
                new Producers {Name = ""},//19
                new Producers {Name = ""},//20
                new Producers {Name = ""},//21
                new Producers {Name = ""},//22
                new Producers {Name = ""},//23
                new Producers {Name = ""},//24
                new Producers {Name = ""},//25
                new Producers {Name = ""},//26
                new Producers {Name = ""},//27
                new Producers {Name = ""},//28
                new Producers {Name = ""},//29
                new Producers {Name = ""},//30
                new Producers {Name = ""},//31
                new Producers {Name = ""},//32
                new Producers {Name = ""},//33
                new Producers {Name = ""},//34
                new Producers {Name = ""},//35
                new Producers {Name = ""},//36
                new Producers {Name = ""},//37
                new Producers {Name = ""},//38
                new Producers {Name = ""},//39
                new Producers {Name = ""},//40
            };
            producers.ForEach(p => context.Producers.Add(p));
            var products = new List<Products>
            {
                //Øl
                new Products {Name="Julebukk", Description="En juleøl fra Ringnes",LongDescription="En meget god Juleøl fra Ringnes som fungerer godt til Juleribbe og til Pinnekjøtt!", Price=200,ProducersID=1,CategoriesID=1},
                new Products {Name="Carlsberg Pilsner", Description="En dansk øl", LongDescription="En god dansk øl, som passer godt til god dansk pølse", Price=32, ProducersID=2,CategoriesID=1},
                new Products {Name="Nøgne Ø TWO CAPTAINS", Description="Dobbel IPA", LongDescription="Passer godt til fet mat. Fruktig øl med god bitterhet", Price=80, ProducersID=5,CategoriesID=1},
                new Products {Name="Aass Bock", Description="Undergjæret og mørk øl", LongDescription="Kremet, mørk og litt sødmefull. Fint innslag av vørterkake og honning.", Price=39, ProducersID=6,CategoriesID=1},
                new Products {Name="Haandbryggeriet Rips", Description="Overgjæret rips øl", LongDescription="Syrlig øl laget på rips 7% alkohol", Price=71, ProducersID=7,CategoriesID=1},
                new Products {Name="Kinn Ivar Aasen-øl", Description="Norsk overgjæret øl", LongDescription="Kremet og halvtørr. Preg av ristet korn, hint av urter og honning, lang ettersmak. 10,5% alkohol", Price=130, ProducersID=8,CategoriesID=1},
                new Products {Name="Duchesse de Bourgogne", Description="Overgjæret belgisk øl", LongDescription="Fruktig nese i retning kirsebær, humle og malt. Smak av syrlig frukt, kirsebær og bringebær, tydelig karamellmalt. 6,2% alkohol", Price=147, ProducersID=9,CategoriesID=1},
                new Products {Name="Oude Geuze Boon", Description="Spontangjæret belgisk surøl", LongDescription="Kompleks, frisk og saftig stil. Lang ettersmak. 7% alkohol", Price=53, ProducersID=2,CategoriesID=1},
                new Products {Name="Midtfyns Bryghus Chili Tripel", Description="Overgjæret dansk øl", LongDescription="God fylde, mild humlesmak avrunder smaksbildet. Chili gir en varm følelse i avslutningen. 9,2% alkohol", Price=80, ProducersID=2,CategoriesID=1},
                new Products {Name="Nøgne Ø Indian Pale Ale", Description="Overgjæret norsk øl", LongDescription="God og fyldig IPA med god rund bitterhet 6,9% alkohol", Price=74, ProducersID=2,CategoriesID=1},
                new Products {Name="Ringnes pilsner", Description="Undergjæret norsk øl", LongDescription="Frisk og god øl som passer fint sammen med fest og grilling i parken. 4.7% alkohol", Price=28, ProducersID=2,CategoriesID=1},
                //Rødvin
                new Products {Name="Jacob's Creek", Description="Rød vin", LongDescription="En rød vin som er billig", Price=80, ProducersID=4, CategoriesID=2},
                new Products {Name="Doppio Passo", Description="Rødvin fra Puglia, Italia", LongDescription="Krydret søtlig rødvin med mye fruktighet.", Price=105, ProducersID=2,CategoriesID=2},
                new Products {Name="Vallone Graticciaia 2008", Description="Rødvin fra Puglia, Italia", LongDescription="Myke tanniner, med balansert struktur.", Price=500, ProducersID=2,CategoriesID=2},
                new Products {Name="Vajra Langhe Rosso 2010/2011", Description="Rogvin fra Piermonte, Italia", LongDescription="Litt utviklet, preg av røde bær, litt tørket frukt og lakris, litt varm ettersmak.", Price=135, ProducersID=2,CategoriesID=2},
                new Products {Name="Hudelot-Noellat Clos de Vougeot Richebourg Grand Cru 2011", Description="Rødvin fra Burgund, Frankrike", LongDescription="Dyp med god frukt og konsentrasjon.", Price=2952, ProducersID=2,CategoriesID=2},
                new Products {Name="Lucien Le Moine Bonnes Mares Grand Cru 2011", Description="Rødvin fra Burgund, Frankrike", LongDescription="Balansert, mineralsk og lang.", Price=1800, ProducersID=2,CategoriesID=2},
                new Products {Name="Avent Tempranillo 2012", Description="Rødvin fra Castilla y León, Spania", LongDescription="Frisk og fruktig, mørke skogsbær med myke tanniner.", Price=89, ProducersID=2,CategoriesID=2},
                new Products {Name="Eric Texier Adéle Côtes du Rhône 2013", Description="Frankrike, Rhône Sør, Côtes du Rhône", LongDescription="Frisk med god struktur.", Price=180, ProducersID=2,CategoriesID=2},
                new Products {Name="Eric Texier Brézème Roussanne 2012", Description="", LongDescription="", Price=71, ProducersID=2,CategoriesID=2},
                new Products {Name="", Description="", LongDescription="", Price=71, ProducersID=2,CategoriesID=2},
                new Products {Name="", Description="", LongDescription="", Price=71, ProducersID=2,CategoriesID=2},
                //Hvitvin

                //Brennevin
                new Products {Name="Absolut Mandarin", Description="Vodka med mandarinsmak", LongDescription="En brennevin av typen vodka som er tilsatt et par mandariner", Price=280, ProducersID=3, CategoriesID=3},
            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

        }

    }
}