using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nettbutikk.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Nettbutikk.DAL
{

    public class ProductDAL : DAL.IProductDAL
    {
        public List<Category> getAllCategories()
        {
            var db = new DatabaseContext();
            List<Category> categories = db.Categories.Select(item => new Category(){
                    ID = item.Id,
                    name = item.Name
            }).ToList();

            return categories; 
            }

        public List<SubCategory> getAllSubCategories()
        {
            var db = new DatabaseContext();
            List<SubCategory> subCategories = db.SubCategories.Select(item => new SubCategory() 
            {
                     ID = item.Id,
                     name  = item.Name,
                     catName = item.Categories.Name,
                     catId = item.CategoriesId
            }).ToList();
            
            return subCategories;
        }

        public List<Product> getAll(int? id, String sc, int? sort)
        {
            return new List<Product>();
        }

        public List<Product> getAll()
        {
            var db = new DatabaseContext();
            List<Product> products = db.Products.Select(item => new Product() {
                    itemnumber = item.Id,
                    name = item.Name,
                    description = item.Description,
                    price = item.Price,
                    volum = item.Volum,
                    producer = item.Producers.Name,
                    country = item.Countries.Name,
                     
                }).ToList();


            return products;
            }
 
        public Product get(int id)
        {
            return null;
        }

        public List<Product> getResult(string searchString)
        {
            var db = new DatabaseContext();
            List<Product> products = db.Products.Select(p => new Product() 
            {
                    itemnumber = p.Id,
                    name = p.Name,
                    description = p.Description,
                    price = p.Price,
                    volum = p.Volum,
                    producer = p.Producers.Name,
                    category = p.SubCategories.Categories.Name,
                    categoryid = p.SubCategories.Categories.Id,
                    subCategory = p.SubCategories.Name,
                    subCategoryid = p.SubCategories.Id,
                    country = p.Countries.Name
            }).Where(p => p.name.ToUpper().Contains(searchString.ToUpper())
                            || p.description.ToUpper().Contains(searchString.ToUpper())).ToList();
            return products;
        }

        public Product findProduct(int id)
        {
            var db = new DatabaseContext();
            Products products = db.Products.Include(p => p.SubCategories.Categories)
                .Where(p => p.Id == id).FirstOrDefault<Products>();
            return new Product()
            {
                itemnumber = products.Id,
                name = products.Name,
                description = products.Description,
                longDescription = products.LongDescription,
                price = products.Price,
                volum = products.Volum,
                producerid = products.ProducersId,
                producer = products.Producers.Name,
                category = products.SubCategories.Categories.Name,
                categoryid = products.SubCategories.Categories.Id,
                subCategory = products.SubCategories.Name,
                subCategoryid = products.SubCategories.Id,
                country = products.Countries.Name,
                countryid = products.CountriesId
            };
        }

        public List<string> getAutoComplete(string term)
        {
            var db = new DatabaseContext();
            List<string> searchList = new List<string>();
            searchList = db.Products.Where(x => x.Name.StartsWith(term)).Select(y => y.Name).ToList();
            return searchList;
        }


        // TODO: Denne skal testes på web når siden er oppe!

        public bool updateProduct(int id,Product update)
        {
            var db = new DatabaseContext();
            Products existing = db.Products.FirstOrDefault(u => u.Id == update.itemnumber);
            try
            {
                existing.Name = update.name;
                existing.Price = update.price;
                existing.Volum = update.volum;
                existing.SubCategoriesId = update.subCategoryid;
                existing.ProducersId = update.producerid; 
                existing.CountriesId = update.countryid;
                existing.Description = update.description;
                existing.LongDescription = update.longDescription;
                existing.ProducersId = update.producerid;
                db.SaveChanges(id);
            }
            catch(Exception e)
            {
                //TODO: skriv noe til fil
                return false;
            }
            return true; 

        }

        public Product addProduct(int id, Product p)
        {
            var db = new DatabaseContext();
            var newp = new Products()
                {
                    Name = p.name,
                    Description = p.description,
                    LongDescription = p.longDescription,
                    CountriesId = p.countryid,
                    SubCategoriesId = p.subCategoryid,
                    Price = p.price,
                    Volum = p.volum,
                    ProducersId = p.producerid
                };
            db.Products.Add(newp); 
            db.SaveChanges(id);
            p.itemnumber = newp.Id; 

            return p; 
        }

        // TODO: denne metoden er kun for å teste audit trail. Må fjernes før innlevering

        public bool addCategoriesTest(int userId)
        {
            var db = new DatabaseContext();
            Categories b = new Categories()
            {
                Name = "Test"
            };
            db.Categories.Add(b);
            db.SaveChanges(userId); 
            return true; 
        }

        public List<Country> getCountries()
        {
            var db = new DatabaseContext();
            List<Country> list = db.Countries.Select(item => new Country()
                {
                    id = item.Id,
                    name = item.Name
            }).ToList();

            return list; 
        }

        public List<Producer> getProducers()
        {
            var db = new DatabaseContext();
            List<Producer> list = db.Producers.Select(p => new Producer()
            {
                id = p.Id,
                name = p.Name
            }).ToList();

            return list; 
        }

        public bool deleteProduct(int id, int adminid)
        {
            var db = new DatabaseContext();
            Products c = db.Products.FirstOrDefault(ca => ca.Id == id);
            db.Products.Remove(c);
            try
            {
                db.SaveChanges(adminid);
            }
            catch (DbUpdateException ue)
            {
                // write to file
                return false;
            }
            catch (Exception e)
            {
                // write to file
                return false;
            }
            return true;
        }
    }
}

