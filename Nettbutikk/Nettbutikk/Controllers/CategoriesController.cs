using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CategoriesController : Controller
    {
        
        // GET: Cat
        private Models.DatabaseContext db = new Models.DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        /*
        public ActionResult ListProducts()
        {
            var db = new DBProduct();
            List<Product> listOfProducts = db.getAll();
            return View(listOfProducts);
        }
        */

        public ActionResult Categories()
        {
            List<Models.Category> allCategories = db.Categories.ToList();
            ViewData.Model = allCategories;
            return View();
        }
    }
}