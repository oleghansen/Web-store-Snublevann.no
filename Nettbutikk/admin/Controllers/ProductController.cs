using Nettbutikk.BLL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductBLL _product;

        public ProductController()
        {
            _product = new ProductBLL();
        }
        public ProductController(IProductBLL stub)
        {
            _product = stub;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProducts()
        {
            List<Product> allProducts = _product.getAll();
            return View(allProducts);
        }
        private bool isAdmin()
        {
            var user = (Customer)Session["loggedInUser"];
            return user.admin;
        }
    }
}