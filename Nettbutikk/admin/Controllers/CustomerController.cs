using Nettbutikk.BLL;
using Nettbutikk.admin.Models;
using Nettbutikk.Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.admin.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBLL _customerbll;

        public CustomerController()
        {
            _customerbll = new CustomerBLL();
        }

        public CustomerController(CustomerBLL stud)
        {
            _customerbll = stud;
        }

        public ActionResult ListCustomers()
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main"); 

            List<Customer> allCustomers = _customerbll.getAll();
            return View(allCustomers);
        }
        // GET: Customer
        public ActionResult Index()
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main"); 
            return View();
        }
        private bool isAdmin(){
            var user = (Customer) Session["loggedInUser"];
            return user.admin; 
        }
    }
}