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
        public ActionResult ListProducts(int? id)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
            if(id.HasValue)
                listOfProducts = db.getAll(id);
            else
                listOfProducts = db.getAll(id);
    
            return View(listOfProducts);
        }
  //      public ActionResult ListProducts(int id)
    //    {
      //      var db = new DBProduct();
            
        //    return View(listOfProducts); 
        //}
        public ActionResult addProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addProduct(Product inProduct)
        {
            if(ModelState.IsValid)
            {
                var productDb = new DBProduct();
                bool insertOK = productDb.add(inProduct);
          
                if(insertOK)
                {
                    return RedirectToAction("ListProducts");
                }
            }
            return View();
        }

        public ActionResult viewProduct(int id)
        {
            var db = new DBProduct();
            return View(db.get(id));
        }

    }
}