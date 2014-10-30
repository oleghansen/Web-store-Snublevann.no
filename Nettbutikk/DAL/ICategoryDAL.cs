using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface ICategoryDAL
    {
        List<Category> getAll(int? id);
        List<Category> getResult(int? id, string sc);
        bool Add(Category cat, int id);
        List<SubCategory> getAllSub(int? id);
        List<SubCategory> getResultSub(int? id, string sc);
    }
}
