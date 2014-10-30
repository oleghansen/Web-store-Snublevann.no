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

        public List<Category> getResult(int? id, string s)
        {
            List<Category> allCategories = _category.getResult(id, s);
            return allCategories;
        }

        public bool Add(Category category, int adminId)
        {
            return _category.Add(category, adminId);
        }

        public bool AddSub(SubCategory sc, int adminId)
        {
            return _category.AddSub(sc, adminId);
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
    }
}
