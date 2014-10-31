using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbutikk.DAL;
using Nettbutikk.Model;

namespace Nettbutikk.BLL
{
    public class CategoryBLL : BLL.ICategoryBLL
    {
        private ICategoryDAL _category;

        public CategoryBLL()
        {
            _category = new CategoryDAL();
        }

        public CategoryBLL(ICategoryDAL stub)
        {
            _category = stub;
        }

        public List<Category> getAll(int? id)
        {
            List<Category> allCategories = _category.getAll(id);
            return allCategories;
        }

        public List<Category> getResult(int? id, string s)
        {
            List<Category> allCategories = _category.getResult(id, s);
            return allCategories;
        }

        public bool Add(Category category, int adminId)
        {
            return _category.Add(category, adminId);
        }

        public bool AddSub(int adminId, SubCategory sc)
        {
            return _category.AddSub(adminId,sc);
        }

        public SubCategory SubCatDetails(int id)
        {
            return _category.SubCatDetails(id);
        }

        public List<SubCategory> getAllSub(int? id)
        {
            List<SubCategory> allSub = _category.getAllSub(id);
            return allSub;
        }

        public List<SubCategory> getResultSub(int? id, string sc)
        {
            List<SubCategory> allSub = _category.getResultSub(id, sc);
            return allSub;
        }

        public List<Producer> getAllProducers(int? id)
        {
            List<Producer> allproducers = _category.getAllProducers(id);
            return allproducers;
        }

        public List<Producer> getResultProducer(int? id, string sc)
        {
            List<Producer> allproducers = _category.getResultProducer(id, sc);
            return allproducers;
        }

        public bool update(int id, SubCategory sc)
        {
            return _category.update(id, sc);
        }

        public bool updateCategory(int id, Category c, int adminid)
        {
            return _category.updateCategory(id, c, adminid);
        }

        public List<SubCategory> deleteCategory(int id, int adminid)
        {
            return _category.deleteCategory(id, adminid); 
        }
        public List<Product> deleteSubCategory(int id, int adminid)
        {
            return _category.deleteSubCategory(id, adminid);
        }
        public List<Product> deleteProducer(int id, int adminid)
        {
            return _category.deleteProducer(id, adminid); 
        }
    }
}
