using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class MainController : Controller
    {
        // GET: Product
        public ActionResult Frontpage()
        {
            return View();

        }
    }
}