using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class CostumerContoller : Controller
    {
        private Models.DatabaseContext db = new Models.DatabaseContext();

        public ActionResult RegisterView()
        {
            return View();
        }
    }
}


