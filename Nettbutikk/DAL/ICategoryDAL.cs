using Nettbutikk.Model;
using System;
using System.Collections.Generic;
namespace Nettbutikk.DAL
{
    public interface ICategoryDAL
    {
        List<Category> getAll(int? id);
        bool Add(Category cat, int id);
        bool AddSub(int id, SubCategory sc);
        SubCategory SubCatDetails(int id);
        List<SubCategory> getAllSub(int? id);
        List<Producer> getAllProducers(int? id);
        bool update(int id, SubCategory sc);
        bool updateCategory(int id, Category c, int adminid);
        List<SubCategory> deleteCategory(int id, int adminid);
        List<Product> deleteSubCategory(int id, int adminid);
        List<Product> deleteProducer(int id, int adminid);
        bool AddProducer(Producer prod, int id);
        Producer producerDetails(int id);
    }
}
