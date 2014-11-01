using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nettbutikk.DAL
{
    public class CategoryDAL : DAL.ICategoryDAL
    {
        public List<Category> getAll(int? id)
        {
            try
            {
                var db = new DatabaseContext();
                List<Category> category;
                if (id == null)
                {
                    category = db.Categories.Select(item => new Category()
                    {
                        ID = item.Id,
                        name = item.Name
                    }).ToList();
                }
                else
                {
                    category = db.Categories.Select(item => new Category()
                {
                    ID = item.Id,
                    name = item.Name
                }).Where(item => item.ID == id).ToList();
                }
                return category;

            }
            catch(Exception e)
            {
                writeToFile(e);
                return null; 
            }
        }


        public List<SubCategory> getAllSub(int? id)
        {
            try
            {
                var db = new DatabaseContext();
                List<SubCategories> subcat;
                if (id != null)
                {
                    subcat = db.SubCategories.Include("Categories").Where(p => p.Id == id).ToList();
                }
                else
                    subcat = db.SubCategories.Include("Categories").ToList();
                var list = new List<SubCategory>();
                foreach (var item in subcat)
                {
                    list.Add(new SubCategory()
                    {
                        ID = item.Id,
                        name = item.Name,
                        catName = item.Categories.Name
                    });
                }
                return list;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null; 
            }
        }

        public List<Producer> getAllProducers(int? id)
        {
            try
            {
                var db = new DatabaseContext();
                List<Producer> producers = db.Producers.Select(item => new Producer()
                {
                    id = item.Id,
                    name = item.Name
                }).ToList();

                return producers;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null; 
            }
        }

        public bool Add(Category category, int adminId)
        {
            var newCategory = new Categories()
            {
                Name = category.name
            };

            try
            {
                var db = new DatabaseContext();
                db.Categories.Add(newCategory);
                db.SaveChanges(adminId);
                return true;
            }
            catch (Exception failed)
            {
                writeToFile(failed);
                return false;
            }
            
        }

        public bool AddSub(int adminId, SubCategory sc)
        {
            var db = new DatabaseContext();
            db.SubCategories.Add(new SubCategories()
            {
                Name = sc.name,
                CategoriesId = sc.catId
            });
            try
            {
                db.SaveChanges(adminId);
            }
            catch(Exception e)
            {
                writeToFile(e);
                return false; 
            }
            return true;
        }

        public SubCategory SubCatDetails(int id)
        {
            try
            {
                var db = new DatabaseContext();
                SubCategories subcat = (SubCategories)db.SubCategories.FirstOrDefault(c => c.Id == id);
                SubCategory subcategory = new SubCategory()
                {
                    ID = subcat.Id,
                    name = subcat.Name,
                    catId = subcat.CategoriesId
                };

                return subcategory;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return null; 
            }
        }

        public bool update(int id, SubCategory sc)
        {
            var db = new DatabaseContext();
            SubCategories existing = db.SubCategories.FirstOrDefault(u => u.Id == sc.ID);
            try
            {
                existing.Name = sc.name;
                existing.CategoriesId = sc.catId;

                db.SaveChanges(id);
            }
            catch (Exception e)
            {
                writeToFile(e);
                return false;
            }
            return true;
        }

        public bool updateCategory(int id, Category c, int adminid)
        {
            var db = new DatabaseContext();

            try
            {
                Categories cat = db.Categories.FirstOrDefault(ca => ca.Id == id);
                cat.Name = c.name;

                db.SaveChanges(adminid);
                return true;
            }
            catch(Exception e)
            {
                writeToFile(e);
                return false;
            }

        }

        public List<SubCategory> deleteCategory(int id, int adminid)
        {
            var db = new DatabaseContext();
            Categories c = db.Categories.FirstOrDefault(ca => ca.Id == id);
            db.Categories.Remove(c);
            try
            {
                db.SaveChanges(adminid);
            }
            catch (DbUpdateException ue)
            {
                writeToFile(ue);
                try
                {
                    return db.SubCategories.Where(sc => sc.CategoriesId == id).Select(p => new SubCategory()
                    {
                        name = p.Name
                    }).ToList();
                }
                catch(Exception e)
                {
                    writeToFile(e);
                }
            }
            catch( Exception e)
            {
                writeToFile(e);
            }
            return null; 
        }
        public List<Product> deleteSubCategory(int id, int adminid)
        {
            var db = new DatabaseContext();
            SubCategories c = db.SubCategories.FirstOrDefault(ca => ca.Id == id);
            db.SubCategories.Remove(c);
            try
            {
                db.SaveChanges(adminid);
            }
            catch (DbUpdateException ue)
            {
                writeToFile(ue);
                try
                {
                    return db.Products.Where(sc => sc.SubCategoriesId == id).Select(p => new Product()
                    {
                        name = p.Name
                    }).ToList();
                }
                catch (Exception e)
                {
                    writeToFile(e);
                }
            }
            catch (Exception e)
            {
                writeToFile(e);
            }
            return null;
        }
        public List<Product> deleteProducer(int id, int adminid)
        {
            var db = new DatabaseContext();
            Producers c = db.Producers.FirstOrDefault(ca => ca.Id == id);
            db.Producers.Remove(c);
            try
            {
                db.SaveChanges(adminid);
            }
            catch (DbUpdateException ue)
            {
                writeToFile(ue);
                try
                {
                    return db.Products.Where(sc => sc.ProducersId == id).Select(p => new Product()
                    {
                        name = p.Name
                    }).ToList();
                }
                catch (Exception e)
                {
                    writeToFile(e);
                }
            }
            catch (Exception e)
            {
                writeToFile(e);
            }
            return null;
        
        
        }



        private void writeToFile(Exception e)
        {
            string path =Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ @"nettbutikkFeiLogg.txt";
            Debug.WriteLine(path);
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("-----------   " + DateTime.Now.ToString() + "   --------------");
                    writer.WriteLine("");
                    writer.WriteLine("Message: " + e.Message + Environment.NewLine 
                        + "InnerMessage: " + e.InnerException.Message + Environment.NewLine
                        + "Stacktrace: " + e.StackTrace + Environment.NewLine);
                }
            }catch(IOException ioe)
            {
                Debug.WriteLine(ioe.Message);
            }
            catch(UnauthorizedAccessException uae)
            {
                Debug.WriteLine(uae.Message);
            }
        }
    }
}
