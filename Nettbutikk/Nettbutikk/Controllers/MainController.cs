using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        //endre
        public ActionResult Index()
        {
            return View();
        }
    }
}