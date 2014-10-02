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
            var countries = new List<Countries>
            {
                new Countries {Name = "Norge"},//1
                new Countries {Name = "Sverige"},//2
                new Countries {Name = "Frankrike"},//3
                new Countries {Name = "Belgia"},//4
                new Countries {Name = "Tyskland"},//5
                new Countries {Name = "Østerike"},//6
                new Countries {Name = "Sørafrika"},//7
                new Countries {Name = "Spania"},//8
                new Countries {Name = "Italia"},//9
                new Countries {Name = "Danmark"},//10
                new Countries {Name = "Cuba"},//11
                new Countries {Name = "Australia"},//12
                new Countries {Name = "Norge"}//13
            };
            countries.ForEach(c => context.Countries.Add(c));


            var categories = new List<Categories>
            {
                new Categories {Name="Øl"},//1
                new Categories {Name="Rødvin"},//2
                new Categories {Name="Hvitvin"},//3
                new Categories {Name="Brennevin"}//4
            };

            // add data into context and save to db


            categories.ForEach(c => context.Categories.Add(c));

            var subcategories = new List<SubCategories>
            {
                new SubCategories {Name="Overgjæret", CategoriesId=1},
                new SubCategories {Name="Undergjæret", CategoriesId=1},
                new SubCategories {Name="Spotangjæret", CategoriesId=1},   
                new SubCategories {Name="Fyldig", CategoriesId=2},
                new SubCategories {Name="Mild", CategoriesId=2},
                new SubCategories {Name="Søt", CategoriesId=3},
                new SubCategories {Name="Tørr", CategoriesId=3},
                new SubCategories {Name="Vodka", CategoriesId=4},
                new SubCategories {Name="Rom", CategoriesId=4},
                new SubCategories {Name="Likør", CategoriesId=4},
                new SubCategories {Name="Cognac", CategoriesId=4},
                new SubCategories {Name="Wiskey", CategoriesId=4},
                new SubCategories {Name="Likør over 22%", CategoriesId=4},
                new SubCategories {Name="Akevitt", CategoriesId=4}
            }; 

            subcategories.ForEach(s => context.SubCategories.Add(s));
            
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
            context.SaveChanges();
            var products = new List<Products>
            {
                //Øl
                new Products {Name="Julebukk", Description="En juleøl fra Ringnes. Vol: 8.0 % ",LongDescription="En meget god Juleøl fra Ringnes som fungerer godt til Juleribbe og til Pinnekjøtt!", Price=200,ProducersId=1,SubCategoriesId=2, CountriesId=1},
                new Products {Name="Carlsberg Pilsner", Description="En dansk øl. Vol: 4.7 %", LongDescription="En god dansk øl, som passer godt til god dansk pølse", Price=32, ProducersId=2,SubCategoriesId=2, CountriesId=10},
                new Products {Name="Nøgne Ø TWO CAPTAINS", Description="Dobbel IPA. Vol: 6.8 %", LongDescription="Passer godt til fet mat. Fruktig øl med god bitterhet", Price=80, ProducersId=5,SubCategoriesId=1, CountriesId=1},
                new Products {Name="Aass Bock", Description="Undergjæret og mørk øl. Vol: 7.0 %", LongDescription="Kremet, mørk og litt sødmefull. Fint innslag av vørterkake og honning.", Price=39, ProducersId=6,SubCategoriesId=2, CountriesId=1},
                new Products {Name="Haandbryggeriet Rips", Description="Overgjæret rips øl. Vol: 5.5 %", LongDescription="Syrlig øl laget på rips 7% alkohol", Price=71, ProducersId=7,SubCategoriesId=1, CountriesId=1},
                new Products {Name="Kinn Ivar Aasen-øl", Description="Norsk overgjæret øl. Vol: 11.0 %", LongDescription="Kremet og halvtørr. Preg av ristet korn, hint av urter og honning, lang ettersmak.", Price=130, ProducersId=8,SubCategoriesId=1,CountriesId=1},
                new Products {Name="Duchesse de Bourgogne", Description="Overgjæret belgisk øl. Vol: 6.2 %", LongDescription="Fruktig nese i retning kirsebær, humle og malt. Smak av syrlig frukt, kirsebær og bringebær, tydelig karamellmalt. 6,2% alkohol", Price=147, ProducersId=9,SubCategoriesId=1, CountriesId=4},
                new Products {Name="Oude Geuze Boon", Description="Spontangjæret belgisk surøl. Vol: 6.2 %", LongDescription="Kompleks, frisk og saftig stil. Lang ettersmak.", Price=53, ProducersId=10,SubCategoriesId=12, CountriesId=4},
                new Products {Name="Midtfyns Bryghus Chili Tripel", Description="Overgjæret dansk øl. Vol: 9.2 %", LongDescription="God fylde, mild humlesmak avrunder smaksbildet. Chili gir en varm følelse i avslutningen.", Price=80, ProducersId=11,SubCategoriesId=1, CountriesId=10},
                new Products {Name="Nøgne Ø Indian Pale Ale", Description="Overgjæret norsk øl. Vol: 7.2 %", LongDescription="God og fyldig IPA med god rund bitterhet.", Price=74, ProducersId=5,SubCategoriesId=1, CountriesId=1},
                new Products {Name="Ringnes pilsner", Description="Undergjæret norsk øl. Vol: 4.7 %", LongDescription="Frisk og god øl som passer fint sammen med fest og grilling i parken.", Price=28, ProducersId=1,SubCategoriesId=2, CountriesId=1},
                //Rødvin
                
                new Products {Name="Jacob's Creek Shiraz 2011", Description="Rødvin fra Chile. Vol: 13 %", LongDescription="En rød vin som er billig", Price=80, ProducersId=11, SubCategoriesId=4, CountriesId=1},
                new Products {Name="Doppio Passo", Description="Rødvin fra Puglia, Italia. Vol: 12 %", LongDescription="Krydret søtlig rødvin med mye fruktighet.", Price=105, ProducersId=12,SubCategoriesId=4, CountriesId=9},
                new Products {Name="Vallone Graticciaia 2008", Description="Rødvin fra Puglia, Italia. Vol: 12 %", LongDescription="Myke tanniner, med balansert struktur.", Price=500, ProducersId=13,SubCategoriesId=3, CountriesId=9},
                new Products {Name="Vajra Langhe Rosso 2010/2011", Description="Rødvin fra Piermonte, Italia. Vol: 14 %", LongDescription="Litt utviklet, preg av røde bær, litt tørket frukt og lakris, litt varm ettersmak.", Price=135, ProducersId=14,SubCategoriesId=3, CountriesId=9},
                new Products {Name="Hudelot-Noellat Clos de Vougeot Richebourg Grand Cru 2011. Vol: 13 %", Description="Rødvin fra Burgund, Frankrike", LongDescription="Dyp med god frukt og konsentrasjon.", Price=2952, ProducersId=15,SubCategoriesId=3, CountriesId=3},
                new Products {Name="Lucien Le Moine Bonnes Mares Grand Cru 2011. Vol: 13.5 %", Description="Rødvin fra Burgund, Frankrike", LongDescription="Balansert, mineralsk og lang.", Price=1800, ProducersId=16,SubCategoriesId=3, CountriesId=3},
                new Products {Name="Avent Tempranillo 2012", Description="Rødvin fra Castilla y León, Spania. Vol: 12.5 %", LongDescription="Frisk og fruktig, mørke skogsbær med myke tanniner.", Price=89, ProducersId=17,SubCategoriesId=4, CountriesId=8},
                new Products {Name="Eric Texier Adéle Côtes du Rhône 2013", Description="Frankrike, Rhône Sør, Côtes du Rhône. Vol: 13 %", LongDescription="Frisk med god struktur.", Price=180, ProducersId=18,SubCategoriesId=3,CountriesId=3},
                new Products {Name="Eric Texier Brézème Roussanne 2012", Description="Frankrike, Rhône Sør, Côtes du Rhône. Vol: 13 %", LongDescription="", Price=71, ProducersId=18,SubCategoriesId=3,CountriesId=3},
                new Products {Name="Angove Deep Creek Shiraz 2013", Description="Rødvin fra South Eastern Austra, Australia. Vol: 12 %", LongDescription="Ung og saftig, preg av mørke bær, lakris og urter.", Price=280, ProducersId=19,SubCategoriesId=4,CountriesId=12},
                new Products {Name="Lammershoek Lam Syrah 2013", Description="Rødvin fra Coastal Region, Swartland, Sør-Afrika. Vol: 14 %", LongDescription="Tørr, fruktdrevet, frisk.", Price=165, ProducersId=20,SubCategoriesId=3,CountriesId=7},
                //Hvitvin
                
                new Products {Name="Leitz Rüdesheimer Berg Roseneck Katerloch Riesling Trocken 2012", Description="Hvitvin fra Rheingau, Øvrige, Tyskland. Vol: 11 %", LongDescription="Tørr, mineral konsentrasjon.", Price=275, ProducersId=21,SubCategoriesId=6,CountriesId=5},
                new Products {Name="AD Dauvissat Chablis 1er cru Beauroy 2012", Description="Hitvin fra Burgund, Frankrike. Vol: 13 %", LongDescription="Flott fylde, kompleks, stram og lang ettersmak.", Price=250, ProducersId=22,SubCategoriesId=6,CountriesId=3},
                new Products {Name="Viña Izadi Blanco 2008", Description="Hvitvin fra Rioja, Spania. Vol: 14 %", LongDescription="Strågul farge, frisk og fruktig med noe floral aroma samt noe toast- og nøttepreg. Rund og bløt med lang ettersmak.", Price=99, ProducersId=23,SubCategoriesId=6,CountriesId=8},
                new Products {Name="Urbina Viura 2011/2012", Description="Hvitvin fra Rioja, Spania. Vol: 12.5 %", LongDescription="Saftig og moden frukt, preg av eple og sitrus.", Price=165, ProducersId=24,SubCategoriesId=5,CountriesId=8},
                new Products {Name="Amore Bianco 2012", Description="Hvitvin fra Sicilia, Italia. Vol: 13 %", LongDescription="Frisk, med god fruktkonsentrasjon og lett bitterhet i avslutningen.", Price=89, ProducersId=25,SubCategoriesId=6,CountriesId=9},
                new Products {Name="Graci Etna Bianco 2013", Description="Hvitvin fra Etna, Italia. Vol: 14.5 %", LongDescription="Håndhøstet, gjæret med stedegengjær i sement og brukte fat, lagring på lees i 12 mnd.", Price=200, ProducersId=26,SubCategoriesId=6,CountriesId=9},
                new Products {Name="Jacob's Creek Chardonnay 2012", Description="Hvitvin fra South Eastern Austra, Australia. Vol: 12 %", LongDescription="Ren og fruktig, preget av sitrus og tropisk frukt, antydning til vanilje.", Price=108, ProducersId=11,SubCategoriesId=5,CountriesId=12},
                new Products {Name="Pewsey Vale Riesling 2011", Description="Hvitvin fra Eden Valley, Australia. Vol: 14 %", LongDescription="Halmgul farge. Fruktaromaer av knust og lime. God lengde og dybde med sitron og lime.", Price=175, ProducersId=27,SubCategoriesId=5,CountriesId=12},
                new Products {Name="Allram Grüner Veltliner Eiswein 2012", Description="Hvitvin fra Niederösterreich, Østerike. Vol: 13 %", LongDescription="Gyllen farge. Aroma av hvit pepper, nektar, honning, moden sitrus og lime.", Price=205, ProducersId=28,SubCategoriesId=6,CountriesId=6},
                new Products {Name="Fritsch Windspiel Riesling 2010", Description="Hvitvin fra Niederösterreich, Østerike. Vol: 13.5 %", LongDescription="Frisk, delikat og mineralsk med god konsentrasjon og fin lengde. Sitrus og eplepreget frukt. ", Price=145, ProducersId=29,SubCategoriesId=6,CountriesId=6},
                new Products {Name="Lammershoek Roulette Blanc 2011", Description="Hvitvin fra Swartland, Sør-Afrika. Vol: 12 %", LongDescription="Tørr med krydret fruktighet, god konsentrasjon og mineralitet, krydret frukt i avslutning.", Price=165, ProducersId=20,SubCategoriesId=6,CountriesId=7},
                
                //Brennevin
                new Products {Name="Absolutt Vodka", Description="Vodka fra Sverige. Vol: 40 %", LongDescription="Ren vodka.", Price=300, ProducersId=30, SubCategoriesId=7,CountriesId=10},
                new Products {Name="Jameson", Description="Wiskey fra Irland. Vol: 40 %", LongDescription="En ren wiskey med hint av korn.", Price=400, ProducersId=31, SubCategoriesId=11,CountriesId=1},
                new Products {Name="Thor Heyerdal X.O", Description="Cognac fra Frankrike. Vol: 40 %", LongDescription="Bitter og fyldig cognac med tydelig preg av fat, 40% alkohol", Price=450, ProducersId=32, SubCategoriesId=10,CountriesId=3},
                new Products {Name="Baileys", Description="Likør fra Irland. Vol: 19 %", LongDescription="Tydelig sjokolade preg. Godt i kaffe. 17% alkohol", Price=200, ProducersId=33, SubCategoriesId=9,CountriesId=1},
                new Products {Name="Absolut Citron", Description="Vodka fra Sverige. Vol: 40 %", LongDescription="Vodka med hint av Sitron. 40% alkohol", Price=310, ProducersId=30, SubCategoriesId=7,CountriesId=10},
                new Products {Name="Absolutt Mango", Description="Vodka fra Sverige. Vol: 40 %", LongDescription="Vodka med hint av Mango. 40% alkohol", Price=310, ProducersId=30, SubCategoriesId=7,CountriesId=10},
                new Products {Name="Captain Morgan", Description="Rom fra Cuba. Vol: 40 %", LongDescription="Søtelig rom som passer godt med cola og isbiter. 40% alkohol", Price=320, ProducersId=34, SubCategoriesId=8,CountriesId=11},
                new Products {Name="Bacardi Razz", Description="Søtt dritt fra Cuba Vol: 37.5 %", LongDescription="Søt festdrikke for de som liker det. 37,5% alkohol", Price=300, ProducersId=35, SubCategoriesId=8,CountriesId=11},
                new Products {Name="Gammel dansk", Description="Bitter fra Danmark. Vol: 40 %", LongDescription="En bitter drikke som fungerer bra som shot", Price=410, ProducersId=36, SubCategoriesId=13,CountriesId=10},
                new Products {Name="Løyten Linie Akevitt", Description="Akevitt fra Norge. Vol: 40 %", LongDescription="Fatpreget fyldig akevitt som passer godt til litt fet mat 40% alkohol", Price=450, ProducersId=36, SubCategoriesId=14,CountriesId=1}
                
            };
            products.ForEach(c => context.Products.Add(c));
            //context.SaveChanges();

        }

    }
}