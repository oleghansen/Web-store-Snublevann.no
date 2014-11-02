using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class CategoryDALStub : DAL.ICategoryDAL
    {
        public List<Category> getAll(int? id)
        {
            var cat1 = new Category()
            {
                ID = 1,
                name = "Rusbrus"
            };
            var cat2 = new Category()
            {
                ID = 2,
                name = "Brennevin"
            };
            var cat3 = new Category()
            {
                ID = 3,
                name = "Tilfeldig navn"
            };
            var cat4 = new Category()
            {
                ID = 4,
                name = "Brus"
            };
            var cat5 = new Category()
            {
                ID = 5,
                name = "Melk"
            };
            List<Category> catlist = new List<Category>();
            catlist.Add(cat1);
            catlist.Add(cat2);
            catlist.Add(cat3);
            catlist.Add(cat4);
            catlist.Add(cat5);

            if (id == null)
                return catlist;
            else
                return catlist.Where(c => c.ID == id).ToList();
        }

        public List<Category> getResult(int? id, string sc)
        {
            var cat = new Category()
            {
                ID = 1,
                name = "Rusbrus"
            };
            List<Category> catlist = new List<Category>();
            catlist.Add(cat);
            return catlist;
        }

        public List<SubCategory> getAllSub(int? id)
        {
            var cat = new SubCategory()
            {
                ID = 1,
                name = "Rusbrus",
                catName = "ØL"
            };
            var cat1 = new SubCategory()
            {
                ID = 2,
                name = "Preskanne",
                catName = "Kaffe"
            };
            var cat2 = new SubCategory()
            {
                ID = 3,
                name = "Pulver",
                catName = "Kaffe"
            };
            var cat3 = new SubCategory()
            {
                ID = 4,
                name = "Mokka",
                catName = "Kaffe"
            };
            var cat4 = new SubCategory()
            {
                ID = 5,
                name = "Latte",
                catName = "Kaffe"
            };

            List<SubCategory> sublist = new List<SubCategory>();
            sublist.Add(cat);
            sublist.Add(cat1);
            sublist.Add(cat2);
            sublist.Add(cat3);
            sublist.Add(cat4);

            return sublist;
        }

        public List<SubCategory> getResultSub(int? id, string sc)
        {
            var cat = new SubCategory()
            {
                ID = 1,
                name = "Rusbrus",
                catName = "ØL"
            };
            List<SubCategory> sublist = new List<SubCategory>();
            sublist.Add(cat);
            return sublist;
        }

        public bool Add(Category category, int id)
        {
            if (id == 0 )
                return false;
            return true;
        }

        public bool AddSub(int id, SubCategory category)
        {
            if (id == 0)
                return false;
            return true;
        }

        public List<Producer> getAllProducers(int? id)
        {
            var prod = new Producer()
            {
                id = 1,
                name = "Harry Potter"
            };
            var prod2 = new Producer()
            {
                id = 2,
                name = "Hermine Granger"
            };
            var prod3 = new Producer()
            {
                id = 3,
                name = "Ronald Weasley"
            };
            var prod4 = new Producer()
            {
                id = 4,
                name = "Albus Dumbledore"
            };
            var prod5 = new Producer()
            {
                id = 5,
                name = "Voldemort"
            };
            List<Producer> prodlist = new List<Producer>();
            prodlist.Add(prod);
            prodlist.Add(prod2);
            prodlist.Add(prod3);
            prodlist.Add(prod4);
            prodlist.Add(prod5);
            return prodlist;
        }

        public List<Producer> getResultProducer(int? id, string sc)
        {
            var cat = new Producer()
            {
                id = 1,
                name = "Rusbrus",
            };
            List<Producer> sublist = new List<Producer>();
            sublist.Add(cat);
            return sublist;
        }

        public SubCategory SubCatDetails(int id)
        {
            return getAllSub(id)[0];
        }

        public bool update(int id, SubCategory sc, int adminid)
        {
            if (id == 0)
                return false;
            return true;
        }

        public bool update(int id, SubCategory sc)
        {
            if (id == 0)
            {
                return false;
            }
            return true;
        }

        public bool updateCategory(int id, Category c, int adminid)
        {
            if (id == 0)
                return false;
            return true;
        }


        public List<SubCategory> deleteCategory(int id, int adminid)
        {
            List<SubCategory> list = new List<SubCategory>();
            list.Add(new SubCategory()
            {
                name = "mokka"
            });
            if (id == 5)
                return null;
            else
                return list;

        }
        public List<Product> deleteSubCategory(int id, int adminid)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product()
            {
                name = "IPA"
            });
            if (id == 5)
                return null;
            else
                return list;
        }
        public List<Product> deleteProducer(int id, int adminid)
        {
            return null;
        }
        public bool AddProducer(Producer prod, int id)
        {
            return false;
        }
        public Producer producerDetails(int id)
        {
            return null;
        }

        public bool updateProducer(int id, Producer p, int adminid)
        {
            return false;
        }
    }
}
