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
        bool AddSub(int id, SubCategory sc);
        List<Category> getCategories();
        List<SubCategory> getAllSub(int? id);
        List<SubCategory> getResultSub(int? id, string sc);
        List<Producer> getAllProducers(int? id);
        List<Producer> getResultProducer(int? id, string sc);
    }
}
