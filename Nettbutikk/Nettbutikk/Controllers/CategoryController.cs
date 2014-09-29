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
        public ActionResult CategoryView()
        {
            return View();
        }

        
        /*
        public ActionResult ListProducts()
        {
            var db = new DBProduct();
            List<CategoriesController> listCategories = db.getAll();
            return View(listCategories);
        }
        */
        
        public ActionResult Categories()
        {
            List<Models.Categories> allCategories = db.Categories.ToList();
            ViewData.Model = allCategories;
            return View();
        }
    }
}