using Nettbutikk.BLL;
using Nettbutikk.admin.Models;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using PagedList;


namespace Nettbutikk.admin.Controllers
{
    public class CategoryController : Controller
    {
        // TODO: mulig endre til annen BLL
        private IProductBLL _productbll;

        public CategoryController()
        {
            _productbll = new ProductBLL();
        }

        public CategoryController(ProductBLL stub)
        {
            _productbll = stub;
        }

        public ActionResult ListCategories()
        {
            return null;
        }
    
    }
}