﻿using System;
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


        public bool Add(Category category, int adminId)
        {
            return _category.Add(category, adminId);
        }

        public bool AddProducer(Producer prod, int id)
        {
            return _category.AddProducer(prod, id);
        }


        public Producer producerDetails(int id)
        {
            return _category.producerDetails(id);
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


        public List<Producer> getAllProducers(int? id)
        {
            List<Producer> allproducers = _category.getAllProducers(id);
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

        public bool updateProducer(int id, Producer p, int adminid)
        {
            return _category.updateProducer(id,p,adminid );
        }
    }
}
