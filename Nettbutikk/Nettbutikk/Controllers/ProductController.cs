using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ListProducts()
        {
            var db = new DBProduct();
            List<Product> listOfProducts = db.getAll();
            return View(listOfProducts);
        }

    }

}