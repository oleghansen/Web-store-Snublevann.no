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
            List<Categories> products;
                products = db.Categories.ToList();
            var list = new List<Category>();
            foreach (var item in products)
            {
                list.Add(new Category()
                {
                    ID = item.Id,
                    name = item.Name
                });
            }
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
    }
}
