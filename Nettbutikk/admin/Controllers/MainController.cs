using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.BLL;
using Nettbutikk.Model;

namespace Nettbutikk.admin.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Main()
        {
            if (!isAdmin())
                RedirectToAction("logIn");

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
        [ValidateAntiForgeryToken]
        public ActionResult logIn(String email, String password)
        {
            if (ModelState.IsValid)
            {
                var admin = _customerbll.logIn(email, password);
                Session["loggedInUser"] = admin;
                return RedirectToAction("Main");
            } return View();
        }

        private bool isAdmin()
        {
            if (Session == null)
                return false;
            var user = (Customer)Session["loggedInUser"];
            return (user == null) ? false : user.admin;
        }
    }
}