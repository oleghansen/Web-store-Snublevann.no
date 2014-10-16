using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.admin.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

    }
}