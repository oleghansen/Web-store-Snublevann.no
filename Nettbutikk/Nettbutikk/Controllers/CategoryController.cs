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

        public List<Product> getProductsByCategory(int id)
        {
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
        }
    }
}