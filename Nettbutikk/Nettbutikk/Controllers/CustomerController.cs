using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class CustomerController : Controller
    {
        
        
        public ActionResult Register()
        {
            return View();

        }

        //Her kommer man dersom man har registrert en ny bruker 
        [HttpPost]
        public ActionResult Register(Customer newUser)
        {
            if (ModelState.IsValid)
            {
                var customerDB = new DBCustomer();
                byte[] hashedPassword = makeHash(newUser.password);
                bool insertOK = customerDB.add(newUser, hashedPassword);
                if (insertOK)
                {
                    var founduser = customerDB.findCustomer(newUser.username);
                    Session["loggedInUser"] = founduser;
                    return View("PersonalSite", founduser);
                }    
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session["loggedInUser"] = null;
            return View("../Main/Frontpage");

        }
        
        
        //SKjekker om man er logget inn
       
        public ActionResult LogIn()
        {
            if (Session["loggedInUser"] == null)
            {
                ViewBag.LoggedIn = false;
            }
            else
            {
                
                ViewBag.LoggedIn = true;
            }
            return View();
        }




        // Her skjekker kaller man først opp userExits, dersom den gjør det så er man logget inn
        [HttpPost]
        public ActionResult LogIn(Customer user)
        {
            var customerDB = new DBCustomer(); 
            var hashedPassword = makeHash(user.password); 
            if (customerDB.validate(user.username, hashedPassword))
            {
                //TODO: ugly hack, fikse bedre metode for å få id inn i shoppingcart
             //   var userid = customerDB.findCustomer(user.username).Id;
                var founduser = customerDB.findCustomer(user.username);
                user.shoppingcart = new ShoppingCart(founduser.id);
                Session["loggedInUser"] = founduser;
                ViewBag.loggedIn = true;
                return View("PersonalSite", founduser);
            }
            else
            {
                Session["loggedInUser"] = null;
                ViewBag.loggedIn = false;
                return View();
            }
        }

        //Dersom man går inn i den personlige siden så viser man denne siden, ellers må man logge inn.
        public ActionResult PersonalSite()
        {
            if (Session["loggedInUser"] != null )
            {
               
                return View();
                
           }
             return RedirectToAction("LogIn");
        }

        //Hasher passordet
        private static byte[] makeHash(string inPassword)
        {
            byte[] inData, outData;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            inData = System.Text.Encoding.ASCII.GetBytes(inPassword);
            outData = algorithm.ComputeHash(inData);
            return outData;
        }

        public ActionResult updateUserinfo(int id)
        {
            Customer c = (Customer)Session["loggedInUser"];
            
            return View(c);
        }

        [HttpPost]
        public ActionResult updateUserinfo(Customer newUser)
        {
            if (ModelState.IsValid)
            {
                Customer hm = newUser;
                Customer c = (Customer)Session["loggedInUser"];
                    return View("PersonalSite", c);
                
            }
            return View("../Main/Frontpage");
        }


    }
}

