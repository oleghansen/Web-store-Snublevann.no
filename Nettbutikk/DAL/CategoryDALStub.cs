﻿using Nettbutikk.Model;
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
            if (id == 0 || category == null)
                return false;
            return true;
        }

        public bool AddSub(SubCategory category, int id)
        {
            if (id == 0 || category == null)
                return false;
            return true;
        }
    }
}