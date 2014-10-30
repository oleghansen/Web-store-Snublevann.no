using Nettbutikk.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikk.BLL
{
    public interface ICategoryBLL
    {
        List<Category> getAll(int? id);
        List<Category> getResult(int? id, string sc);
        bool Add(Category cat, int id);
        bool AddSub(SubCategory sc, int id);
        List<SubCategory> getResultSub (int? id, String sc);
        List<SubCategory> getAllSub(int? id);
    }
}
