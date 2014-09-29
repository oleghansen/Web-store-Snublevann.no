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


        public ActionResult GetBeerCategory()
        {
            var beer = (from ID in db.Categories select 1).ToList();
            return View(beer);
        }

        [HttpPost]
        public ActionResult GetBeerCategory(DBCategory model)
        {
            var data = db.Categories.ToList();
            return View(data);
        }
    }
}