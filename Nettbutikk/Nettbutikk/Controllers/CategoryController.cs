using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CategoryController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        // GET: Category
        public ActionResult Categories()
        {
            var db = new DBCategory();
            List<Category> listCategories = db.getAll();
            return View(listCategories);
        }

        public ActionResult getProductsByCategory(int id)
        {

            List<Product> productsByCat = db.Products.AsEnumerable().Where(p => p.CategoriesId == id).Select(p => new Product()
            {
                itemnumber = p.Id,
                name = p.Name,
                description = p.Description,
                price = p.Price,
                producer = p.Producers.Name,
                category = p.Categories.Name
            }
            ).ToList();


            var category = db.Categories.Find(id);
            if (category != null)
            {
                ViewBag.CategoryName = category.Name;
            }
            ViewData.Model = productsByCat;
            return View("Category");


            


            /*//linq to lambda
            var productsByCategory = Products
                .Join(Categories, p => p.Id, pc => pc.ProdId, (p, pc) => new { p, pc })
                .Select(m => new { 
                    ProdId = m.ppc.p.Id, 
                    CatId = m.c.CatId
                });
             */
            /*
            var query = db.Products
                .Join(db.Categories.Where)


            return null;
            */
            /*
            var db = new DatabaseContext();
            Products products = db.Products.Where(p => p.CategoriesID == id).First<Products>();
            Categories categories = db.Categories.Where(c => c.ID == id).First<Categories>();
            new Product()
            {
                itemnumber = products.Itemnumber,
                name = products.Name,
                description = products.Description,
                longDescription = products.LongDescription,
                price = products.Price,
                producer = products.Producers.Name,
                category = products.Categories.Name
            };
            return null;
             * */
        }
    }
}