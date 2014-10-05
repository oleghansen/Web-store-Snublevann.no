using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;
using System.Diagnostics;

namespace Nettbutikk.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        /*public ActionResult ListProducts(int? id)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;

            listOfProducts = db.getAll(id);

            return View(listOfProducts);
        }

        public ActionResult ListProducts(int id, string random)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;

            listOfProducts = db.getAll(id, random);

            return View(listOfProducts);
        }*/

        public ActionResult ListProducts(int? id, string sc)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
            if(sc.Equals("yes"))
              {
                Debug.WriteLine("SubCategory");
                listOfProducts = db.getAll(id,sc);
              }
            else
             {
                Debug.WriteLine("Category");
             listOfProducts = db.getAll(id);
             }
            
            return View(listOfProducts);
        }

        public ActionResult ListSub(int? id)
        {
            var db = new DBProduct();
            List<Product> listSub;

            if (id.HasValue)
                listSub = db.getAll(id);
            else
                listSub = db.getAll(id);

            return View(listSub);
        }

        public ActionResult Search(string searchString)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                listOfProducts = db.getResult(searchString);
                return View(listOfProducts);
            }
            else
            {
                listOfProducts = db.getResult("Tomt");
                return View(listOfProducts);
            }
        }

        public ActionResult viewProduct(int id)
        {
            var db = new DBProduct();
            Product p = db.get(id);
            return View(p);
        }

        public JsonResult getResults(string term)
        {
            DatabaseContext db = new DatabaseContext();
            List<string> foundProducts;
            foundProducts = db.Products.Where(x=>x.Name.StartsWith(term))
                                               .Select(y => y.Name).ToList();

            return Json(foundProducts, JsonRequestBehavior.AllowGet);
        }
    }
}