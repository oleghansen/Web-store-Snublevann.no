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
            List<UserInfo> list = new List<UserInfo>();
            foreach(var item in allCustomers)
            {
                list.Add(
                    new UserInfo()
                    {
                        id = item.id,
                        firstname = item.firstname,
                        lastname = item.lastname,
                        email = item.email,
                        address = item.address,
                        phonenumber = item.phonenumber,
                        password = item.password,
                        hashpassword = item.hashpassword,
                        postalarea = item.postalarea,
                        postalcode = item.postalcode
                    });
                

             
            }
            return View(list);
        }
        // GET: Customer
        public ActionResult Index()
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main"); 
            return View();
        }
        private bool isAdmin(){
            if (Session == null)
                return false;
            var user = (Customer) Session["loggedInUser"];
            return (user == null)?false:user.admin; 
        }
    }
}