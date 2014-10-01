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
                    ViewBag.Username = newUser.username; 
                    Session["loggedInUser"] = newUser;
                    return RedirectToAction("PersonalSite");
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
        //hvilken side skal man skjekke at man er logget inn eller ei ?
        //tatt fra lærern

       
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
                var userid = customerDB.findCustomer(user.username).Id;
                user.shoppingcart = new ShoppingCart(userid);
                Session["loggedInUser"] = user;
                ViewBag.Username = user.username; 
                ViewBag.loggedIn = true;
                return View();
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

    }
}

