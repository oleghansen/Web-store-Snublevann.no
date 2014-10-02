using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;
using System.Diagnostics;

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
                    logInUser(newUser.username);
                    
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
        public ActionResult LogIn(String un, String pw)
        {
    
            Debug.WriteLine(un);
            Debug.WriteLine(pw);

            var customerDB = new DBCustomer(); 
            var hashedPassword = makeHash(pw); 
            if (customerDB.validate(un, hashedPassword))
            {
                //TODO: ugly hack, fikse bedre metode for å få id inn i shoppingcart
             //   var userid = customerDB.findCustomer(user.username).Id;
                 logInUser(un);
                ViewBag.loggedIn = true;
                return PersonalSite(); 
               
            }
            else
            {
                Session["loggedInUser"] = null;
                ViewBag.loggedIn = false;
                return RedirectToAction("Frontpage","Main");
            }
        }

        //Dersom man går inn i den personlige siden så viser man denne siden, ellers må man logge inn.
        public ActionResult PersonalSite()
        {
            Debug.WriteLine("tullball");
            if (Session["loggedInUser"] != null )
            {
                Customer c = (Customer)Session["loggedInUser"];
                return View("PersonalSite",c);
               
           }
            return View("../Main/Frontpage");
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
                Customer c = (Customer)Session["loggedInUser"];
                c.firstname = newUser.firstname;
                c.lastname = newUser.lastname;
                c.email = newUser.email;
                c.phonenumber = newUser.phonenumber;
                c.address = newUser.address;
                c.postalcode = newUser.postalcode;
                c.postalarea = newUser.postalarea;
                c.username = newUser.username;
                c.password = newUser.password;

                var customerDB = new DBCustomer();
                byte[] hashedPassword = makeHash(newUser.password);
                bool updateOK = customerDB.update(c.id,c, newUser.hashpassword);
                
                if (updateOK)
                {
                    Session["loggedInUser"] = c;
                    return View("PersonalSite",c);
                }
                else
                {
                   Customer old = (Customer)Session["loggedInUser"];
                    return View("PersonalSite",old);
                }
            }
            return View("../Main/Frontpage");
        }

        public void logInUser(String un)
        {
            var customerDB = new DBCustomer(); 
            var founduser = customerDB.findCustomer(un);
            founduser.shoppingcart = new ShoppingCart(founduser.id);
            Session["loggedInUser"] = founduser;
            
        }


    }
}

