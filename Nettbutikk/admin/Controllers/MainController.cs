using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.BLL;

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

        private ICustomerBLL _customerbll;

        public MainController()
        {
            _customerbll = new CustomerBLL();
        }

        public MainController(CustomerBLL stud)
        {
            _customerbll = stud;
        }

        [HttpPost]
        public ActionResult logIn(String email, String password)
        {
            if (ModelState.IsValid)
            {
                var admin = _customerbll.logIn(email,password);
                Session["admin"] = admin;
                return RedirectToAction("Main");
            }
            return View();

        }
    }
}