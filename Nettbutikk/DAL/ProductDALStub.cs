using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class ProductDALStub : DAL.IProductDAL
    {
        public List<Category> getAllCategories()
        {
            return null;
        }
        public List<Product> getAll()
        {
            var prod = new Product()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei",
                price = 123,
                producerid = 2,
                producer = "Ringnes"
            };
            var prod1 = new Product()
            {
                itemnumber = 2,
                name = "Truse",
                description = "Hei",
                price = 23,
                producerid = 3,
                producer = "Fjellbekk"
            };
            var prod2 = new Product()
            {
                itemnumber = 3,
                name = "Bjelleklang",
                description = "Hei",
                price = 433,
                producerid = 4,
                producer = "Brokkoliekspressen"
            };
            var prod3 = new Product()
            {
                itemnumber = 4,
                name = "Bremse",
                description = "Hei",
                price = 988,
                producerid = 6,
                producer = "Batman"
            };
            var prod4 = new Product()
            {
                itemnumber = 5,
                name = "Apekatt",
                description = "Hei",
                price = 900,
                producerid = 13,
                producer = "Robin"
            };
            List<Product> productlist = new List<Product>();
            productlist.Add(prod);
            productlist.Add(prod1);
            productlist.Add(prod2);
            productlist.Add(prod3);
            productlist.Add(prod4);
            return productlist;
        }

        public List<Product> getResult( string searchstring)
        {
            var prod = new Product()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei"
            };
            List<Product> productlist = new List<Product>();
            productlist.Add(prod);
            return productlist;
        }



        public List<string> getAutoComplete(string term)
        {
            return null;
        }

        public Product findProduct(int id)
        {
            var product = new Product()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei",
                price = 123,
                volum = 50,
                producerid = 2,
                longDescription = "Tullball er et fantastisk godt drikkeprodukt",
                subCategoryid = 3,
                countryid = 1
            };
            return product;   
        }


        public bool updateProduct(int id, Product p)
        {
            if (id == 0)
                return false;
            return true;
        }

        public Product deleteProduct(int id)
        {
            var product = new Product()
            {
                itemnumber = 1,
                name = "dfsdf",
                description = " dfsfsf"
            };
            return product;
        }

        public List<SubCategory> getAllSubCategories()
        {
            List<SubCategory> sub = new List<SubCategory>();
            sub.Add(new SubCategory()
            {
                ID= 1, 
                name = "Søt",
                catId = 1,
                catName = "Øl"
            });
            sub.Add(new SubCategory()
            {
                ID= 2, 
                name = "Tørr"
            });
            sub.Add(new SubCategory()
            {
                ID= 3, 
                name = "Vodka",
                catId = 1,
                catName = "Øl"
            });
            sub.Add(new SubCategory()
            {
                ID= 4, 
                name = "Brus",
                catId = 1,
                catName = "Øl"
            });
            sub.Add(new SubCategory()
            {
                ID= 5, 
                name = "Kaffer",
                catId = 1,
                catName = "Øl"
            });
            return sub;
        }


        public Product addProduct(int id, Product p)
        {
            if (id == 0)
                return null;
            return null;
        }

        public List<Country> getCountries()
        {
            List<Country> country = new List<Country>();
            country.Add(new Country()
            {
                id = 1,
                name = "Sverige"
            });
            country.Add(new Country()
            {
                id = 2,
                name = "Norge"
            });
            country.Add(new Country()
            {
                id = 3,
                name = "Danmark"
            });
            return country;
        }
        public List<Producer> getProducers()
        {
            List<Producer> producer = new List<Producer>();
            producer.Add(new Producer()
            {
                id = 1,
                name = "Ringnger"
            });
            producer.Add(new Producer()
            {
                id = 2,
                name = "Carlsberg"
            });
            producer.Add(new Producer()
            {
                id = 3,
                name = "Fjellelc"
            });
            producer.Add(new Producer()
            {
                id = 4,
                name = "Tromsøvann"
            });
            producer.Add(new Producer()
            {
                id = 5,
                name = "Absolute"
            });
            return producer;
        }
        public bool deleteProduct(int id, int adminid)
        {
            return false; 
        }
    }
}
