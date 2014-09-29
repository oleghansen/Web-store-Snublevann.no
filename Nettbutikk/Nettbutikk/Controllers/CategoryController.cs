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
        // GET: Category
        public ActionResult Categories()
        {
            var db = new DBCategory();
            List<Category> listCategories = db.getAll();
            return View(listCategories);
        }
    }
}