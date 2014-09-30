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
                new Categories {Name="Rødvin"},
                new Categories {Name="Hvitvin"},
                new Categories {Name="Brennevin"}
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
                new Producers {Name = "Palm Breweries NV"},//10
                new Producers {Name = "Orlando Wines"},//11
                new Producers {Name = "CVBC og CSPA"},//12
                new Producers {Name = "Agr Vallone"},//13
                new Producers {Name = "G.D. Vajra"},//14
                new Producers {Name = "Alain Hudelot-Noellat"},//15
                new Producers {Name = "Lucien le Moine"},//16
                new Producers {Name = "Hammeken Cellars"},//17
                new Producers {Name = "Erik Texier"},//18
                new Producers {Name = "Angove"},//19
                new Producers {Name = "Lammershoek"},//20
                new Producers {Name = "Weing Leitz"},//21
                new Producers {Name = "Agnes et Didier Dauvissat"},//22
                new Producers {Name = "Bod Villabuena"},//23
                new Producers {Name = "Bodegas Urbina"},//24
                new Producers {Name = "MGM Mondo del Vino"},//25
                new Producers {Name = "Az Agr Graci"},//26
                new Producers {Name = "Pewsey Vale Vineyard"},//27
                new Producers {Name = "Weing Allram"},//28
                new Producers {Name = "Weing Karl Fritsch"},//29
                new Producers {Name = "The Absolut Company"},//30
                new Producers {Name = "Irish Dist"},//31
                new Producers {Name = "Robert Prizelius AS"},//32
                new Producers {Name = "Bailey og Co"},//33
                new Producers {Name = "Captain Morgan Rum Dist"},//34
                new Producers {Name = "Bacardi"},//35
                new Producers {Name = "Arcus AS"}//36
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
                new Products {Name="Oude Geuze Boon", Description="Spontangjæret belgisk surøl", LongDescription="Kompleks, frisk og saftig stil. Lang ettersmak. 7% alkohol", Price=53, ProducersID=10,CategoriesID=1},
                new Products {Name="Midtfyns Bryghus Chili Tripel", Description="Overgjæret dansk øl", LongDescription="God fylde, mild humlesmak avrunder smaksbildet. Chili gir en varm følelse i avslutningen. 9,2% alkohol", Price=80, ProducersID=11,CategoriesID=1},
                new Products {Name="Nøgne Ø Indian Pale Ale", Description="Overgjæret norsk øl", LongDescription="God og fyldig IPA med god rund bitterhet 6,9% alkohol", Price=74, ProducersID=5,CategoriesID=1},
                new Products {Name="Ringnes pilsner", Description="Undergjæret norsk øl", LongDescription="Frisk og god øl som passer fint sammen med fest og grilling i parken. 4.7% alkohol", Price=28, ProducersID=1,CategoriesID=1},
                //Rødvin
                new Products {Name="Jacob's Creek Shiraz 2011", Description="Rød vin", LongDescription="En rød vin som er billig", Price=80, ProducersID=11, CategoriesID=2},
                new Products {Name="Doppio Passo", Description="Rødvin fra Puglia, Italia", LongDescription="Krydret søtlig rødvin med mye fruktighet.", Price=105, ProducersID=12,CategoriesID=2},
                new Products {Name="Vallone Graticciaia 2008", Description="Rødvin fra Puglia, Italia", LongDescription="Myke tanniner, med balansert struktur.", Price=500, ProducersID=13,CategoriesID=2},
                new Products {Name="Vajra Langhe Rosso 2010/2011", Description="Rogvin fra Piermonte, Italia", LongDescription="Litt utviklet, preg av røde bær, litt tørket frukt og lakris, litt varm ettersmak.", Price=135, ProducersID=14,CategoriesID=2},
                new Products {Name="Hudelot-Noellat Clos de Vougeot Richebourg Grand Cru 2011", Description="Rødvin fra Burgund, Frankrike", LongDescription="Dyp med god frukt og konsentrasjon.", Price=2952, ProducersID=15,CategoriesID=2},
                new Products {Name="Lucien Le Moine Bonnes Mares Grand Cru 2011", Description="Rødvin fra Burgund, Frankrike", LongDescription="Balansert, mineralsk og lang.", Price=1800, ProducersID=16,CategoriesID=2},
                new Products {Name="Avent Tempranillo 2012", Description="Rødvin fra Castilla y León, Spania", LongDescription="Frisk og fruktig, mørke skogsbær med myke tanniner.", Price=89, ProducersID=17,CategoriesID=2},
                new Products {Name="Eric Texier Adéle Côtes du Rhône 2013", Description="Frankrike, Rhône Sør, Côtes du Rhône", LongDescription="Frisk med god struktur.", Price=180, ProducersID=18,CategoriesID=2},
                new Products {Name="Eric Texier Brézème Roussanne 2012", Description="Frankrike, Rhône Sør, Côtes du Rhône", LongDescription="", Price=71, ProducersID=18,CategoriesID=2},
                new Products {Name="Angove Deep Creek Shiraz 2013", Description="Rødvin fra South Eastern Austra, Australia", LongDescription="Ung og saftig, preg av mørke bær, lakris og urter.", Price=280, ProducersID=19,CategoriesID=2},
                new Products {Name="Lammershoek Lam Syrah 2013", Description="Rødvin fra Coastal Region, Swartland, Sør-Afrika", LongDescription="Tørr, fruktdrevet, frisk.", Price=165, ProducersID=20,CategoriesID=2},
                //Hvitvin
                new Products {Name="Leitz Rüdesheimer Berg Roseneck Katerloch Riesling Trocken 2012", Description="Hvitvin fra Rheingau, Øvrige, Tyskland", LongDescription="Tørr, mineral konsentrasjon.", Price=275, ProducersID=21,CategoriesID=3},
                new Products {Name="AD Dauvissat Chablis 1er cru Beauroy 2012", Description="Hitvin fra Burgund, Frankrike", LongDescription="Flott fylde, kompleks, stram og lang ettersmak.", Price=250, ProducersID=22,CategoriesID=3},
                new Products {Name="Viña Izadi Blanco 2008", Description="Hvitvin fra Rioja, Spania", LongDescription="Strågul farge, frisk og fruktig med noe floral aroma samt noe toast- og nøttepreg. Rund og bløt med lang ettersmak.", Price=99, ProducersID=23,CategoriesID=3},
                new Products {Name="Urbina Viura 2011/2012", Description="Hvitvin fra Rioja, Spania", LongDescription="Saftig og moden frukt, preg av eple og sitrus.", Price=165, ProducersID=24,CategoriesID=3},
                new Products {Name="Amore Bianco 2012", Description="Hvitvin fra Sicilia, Italia", LongDescription="Frisk, med god fruktkonsentrasjon og lett bitterhet i avslutningen.", Price=89, ProducersID=25,CategoriesID=3},
                new Products {Name="Graci Etna Bianco 2013", Description="Hvitvin fra Etna, Italia", LongDescription="Håndhøstet, gjæret med stedegengjær i sement og brukte fat, lagring på lees i 12 mnd.", Price=200, ProducersID=26,CategoriesID=3},
                new Products {Name="Jacob's Creek Chardonnay 2012", Description="Hvitvin fra South Eastern Austra, Australia", LongDescription="Ren og fruktig, preget av sitrus og tropisk frukt, antydning til vanilje.", Price=108, ProducersID=11,CategoriesID=3},
                new Products {Name="Pewsey Vale Riesling 2011", Description="Hvitvin fra Eden Valley, Australia", LongDescription="Halmgul farge. Fruktaromaer av knust og lime. God lengde og dybde med sitron og lime.", Price=175, ProducersID=27,CategoriesID=3},
                new Products {Name="Allram Grüner Veltliner Eiswein 2012", Description="Hvitvin fra Niederösterreich, Østerike", LongDescription="Gyllen farge. Aroma av hvit pepper, nektar, honning, moden sitrus og lime.", Price=205, ProducersID=28,CategoriesID=3},
                new Products {Name="Fritsch Windspiel Riesling 2010", Description="Hvitvin fra Niederösterreich, Østerike", LongDescription="Frisk, delikat og mineralsk med god konsentrasjon og fin lengde. Sitrus og eplepreget frukt. ", Price=145, ProducersID=29,CategoriesID=3},
                new Products {Name="Lammershoek Roulette Blanc 2011", Description="Hvitvin fra Swartland, Sør-Afrika", LongDescription="Tørr med krydret fruktighet, god konsentrasjon og mineralitet, krydret frukt i avslutning.", Price=165, ProducersID=20,CategoriesID=3},
                //Brennevin
                new Products {Name="Absolutt Vodka", Description="Vodka fra Sverige", LongDescription="Ren vodka, 40% alkohol", Price=300, ProducersID=30, CategoriesID=4},
                new Products {Name="Jameson", Description="Wiskey fra Irland", LongDescription="En ren wiskey med hint av korn. 40% alkohol", Price=400, ProducersID=31, CategoriesID=4},
                new Products {Name="Thor Heyerdal X.O", Description="Cognac fra Frankrike", LongDescription="Bitter og fyldig cognac med tydelig preg av fat, 40% alkohol", Price=450, ProducersID=32, CategoriesID=4},
                new Products {Name="Baileys", Description="Likør fra Irland", LongDescription="Tydelig sjokolade preg. Godt i kaffe. 17% alkohol", Price=200, ProducersID=33, CategoriesID=4},
                new Products {Name="Absolut Citron", Description="Vodka fra Sverige", LongDescription="Vodka med hint av Sitron. 40% alkohol", Price=310, ProducersID=30, CategoriesID=4},
                new Products {Name="Absolutt Mango", Description="Vodka fra Sverige", LongDescription="Vodka med hint av Mango. 40% alkohol", Price=310, ProducersID=30, CategoriesID=4},
                new Products {Name="Captain Morgan", Description="Rom fra Cuba", LongDescription="Søtelig rom som passer godt med cola og isbiter. 40% alkohol", Price=320, ProducersID=34, CategoriesID=4},
                new Products {Name="Bacardi Razz", Description="Søtt dritt", LongDescription="Søt festdrikke for de som liker det. 37,5% alkohol", Price=300, ProducersID=35, CategoriesID=4},
                new Products {Name="Gammel dansk", Description="Bitter fra Danmark", LongDescription="En bitter drikke som fungerer bra som shot", Price=410, ProducersID=36, CategoriesID=4},
                new Products {Name="Løyten Linie Akevitt", Description="Akevitt fra Norge", LongDescription="Fatpreget fyldig akevitt som passer godt til litt fet mat 40% alkohol", Price=450, ProducersID=36, CategoriesID=4},
            };

            products.ForEach(c => context.Products.Add(c));
            context.SaveChanges();

        }

    }
}