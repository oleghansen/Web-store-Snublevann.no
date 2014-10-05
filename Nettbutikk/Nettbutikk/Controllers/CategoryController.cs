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
  
        public ActionResult Categories()
        {
            var db = new DBCategory();
            List<Category> listCategories = db.getAll();
            return View(listCategories);
        }

        public ActionResult getProductsByCategory(int id)
        {

            List<Product> productsByCat = db.Products.AsEnumerable().Where(p => p.SubCategories.CategoriesId == id).Select(p => new Product()
            {
                itemnumber = p.Id,
                name = p.Name,
                description = p.Description,
                price = p.Price,
                producer = p.Producers.Name,
                category = p.SubCategories.Categories.Name
            }
            ).ToList();


            var category = db.Categories.Find(id);
            if (category != null)
            {
                ViewBag.CategoryName = category.Name;
            }
            ViewData.Model = productsByCat;
            return View("Category");
        }
    }
}