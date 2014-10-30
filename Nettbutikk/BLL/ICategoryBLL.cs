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
        List<SubCategory> getResultSub (int? id, string sc);
        List<SubCategory> getAllSub(int? id);
        List<Producer> getAllProducers(int? id);
        List<Producer> getResultProducer(int? id, string sc);
    }
}
