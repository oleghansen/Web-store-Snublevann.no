using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class CategoryDAL : DAL.ICategoryDAL
    {
        public List<Category> getAll(int? id)
        {
            var db = new DatabaseContext();
            List<Category> products = db.Categories.Select(item => new Category() 
            {
                ID = item.Id,
                name = item.Name
            }).ToList();

            return products;
        }

        public List<Category> getCategories()
        {
            var db = new DatabaseContext();
            List<Category> list = db.Categories.Select(item => new Category()
            {
                ID = item.Id,
                name = item.Name
            }).ToList();

            return list;
        }


        public List<Category> getResult(int? id, string searchString)
        {
            return null;
            /*
            var db = new DatabaseContext();
            var foundCategories = new List<Category>();
            var categories = db.Categories.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper().ToList());
            foreach (var p in categories)
            {
                var category = new Category()
                {
                    ID = p.Id,
                    name = p.Name
                };
                foundCategories.Add(category);
            }
            return foundCategories;
        
             */
        }

        public List<SubCategory> getAllSub(int? id)
        {
            var db = new DatabaseContext();
            List<SubCategories> subcat;
            if (id != null)
            {
                subcat = db.SubCategories.Include("Categories").Where(p => p.Id == id).ToList();
            }
            else
                subcat = db.SubCategories.Include("Categories").ToList();
            var list = new List<SubCategory>();
            foreach (var item in subcat)
            {
                list.Add(new SubCategory()
                {
                    ID = item.Id,
                    name = item.Name,
                    catName = item.Categories.Name
                });
            }
            return list;
        }

        public List<Producer> getAllProducers(int? id)
        {
            var db = new DatabaseContext();
            List<Producer> producers = db.Producers.Select(item => new Producer()
            {
                id = item.Id,
                name = item.Name
            }).ToList();

            return producers;
        }

        public List<Producer> getResultProducer(int? id, string sc)
        {
            return null;
        }
        public List<SubCategory> getResultSub(int? id, string sc)
        {
            return null;
            /*
            var db = new DatabaseContext();
            var foundCategories = new List<Category>();
            var categories = db.Categories.Where(p => p.Name.ToUpper().Contains(searchString.ToUpper().ToList());
            foreach (var p in categories)
            {
                var category = new Category()
                {
                    ID = p.Id,
                    name = p.Name
                };
                foundCategories.Add(category);
            }
            return foundCategories;
        
             */
        }

        public bool Add(Category category, int adminId)
        {
            var newCategory = new Categories()
            {
                Name = category.name
            };

            try
            {
                var db = new DatabaseContext();
                db.Categories.Add(newCategory);
                db.SaveChanges(adminId);
                return true;
            }
            catch (Exception failed)
            {
                return false;
            }
            
        }

        public bool AddSub(int adminId, SubCategory sc)
        {
            var db = new DatabaseContext();
            db.SubCategories.Add(new SubCategories()
            {
                Name = sc.name,
                CategoriesId = sc.catId
            });
            db.SaveChanges(adminId);

            return true;
        }
    }
}
