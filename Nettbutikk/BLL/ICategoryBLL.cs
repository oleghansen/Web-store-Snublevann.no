using Nettbutikk.Model;
using System;
using System.Collections.Generic;

namespace Nettbutikk.BLL
{
    public interface ICategoryBLL
    {
        List<Category> getAll(int? id);
        bool Add(Category cat, int id);
        bool AddSub(int id, SubCategory sc);
        bool AddProducer(Producer prod, int id);
        SubCategory SubCatDetails(int id);
        List<SubCategory> getAllSub(int? id);
        List<Producer> getAllProducers(int? id);
        bool updateCategory(int id, Category c, int adminid);
        bool update(int id, SubCategory sc);
        List<SubCategory> deleteCategory(int id, int adminid);
        List<Product> deleteSubCategory(int id, int adminid);
        List<Product> deleteProducer(int id, int adminid);

    }
}
