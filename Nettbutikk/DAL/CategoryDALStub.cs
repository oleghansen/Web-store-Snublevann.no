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
            var cat = new Category()
            {
                ID = 1,
                name = "Rusbrus"
            };
            List<Category> catlist = new List<Category>();
            catlist.Add(cat);
            return catlist;
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
            List<SubCategory> sublist = new List<SubCategory>();
            sublist.Add(cat);
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
            List<Producer> prodlist = new List<Producer>();
            prodlist.Add(prod);
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
            return null;
        }

        public bool update(int id, SubCategory sc, int adminid)
        {
            if (id == 0)
                return false;
            return true;
        }

        public bool updateCategory(int id, Category c, int adminid)
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

        public List<SubCategory> deleteCategory(int id, int adminid)
        {
            return null; 
        }
        public List<Product> deleteSubCategory(int id, int adminid)
        {
            return null; 
        }
        public List<Product> deleteProducer(int id, int adminid)
        {
            return null;
        }
    }
}
