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
        public ActionResult Register(Customer newUser, String password_confirmation)
        {
            if (ModelState.IsValid)
            {
                if (!newUser.password.Equals(password_confirmation))
                {
                    ViewBag.confirmation = true;
                    return View();
                }
                var customerDB = new DBCustomer();

                if (!customerDB.checkEmail(newUser.email,null))
                {
                    ViewBag.email = true;
                    return View();
                }
                else
                {

                    byte[] hashedPassword = makeHash(newUser.password);
                    bool insertOK = customerDB.add(newUser, hashedPassword);
                    if (insertOK)
                    {
                        logInUser(newUser.email);
                        return RedirectToAction("PersonalSite");

                    }

                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session["loggedInUser"] = null;
            return View("../Main/Frontpage");

        }
        

        // Her skjekker kaller man først opp userExits, dersom den gjør det så er man logget inn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(String un, String pw)
        {
    
            var customerDB = new DBCustomer(); 
            var hashedPassword = makeHash(pw); 
            if (customerDB.validate(un, hashedPassword))
            {
                 logInUser(un);
                ViewBag.loggedIn = true;
                return Json(true);
            }
            else
            {
                Session["loggedInUser"] = null;
                ViewBag.loggedIn = false;
                return Json(false);
            }

        }

        //Dersom man går inn i den personlige siden så viser man denne siden, ellers må man logge inn.
        public ActionResult PersonalSite()
        {
        
            if (Session["loggedInUser"] != null )
            {
                TempData["pview"] = "none";
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

          [HttpPost]
        public ActionResult updateUserPassword(String op, String np, String bp)
        {
            if (ModelState.IsValid)
            {
                
                Customer c = (Customer)Session["loggedInUser"];

                byte[] hpass = makeHash(op);
                if (Enumerable.SequenceEqual(c.hashpassword, hpass))
                {
                    if (np.Equals(bp))
                    {
                        byte[] hashedPassword = makeHash(np);
                        c.hashpassword = hashedPassword;

                        var customerDB = new DBCustomer();
                        bool updateOK = customerDB.updatePw(c.id, hashedPassword);

                        if (updateOK)
                        {
                            Session["loggedInUser"] = c;
                            TempData["changed"] = "Passord ble endret";
                            return RedirectToAction("PersonalSite");
                        }
                        else
                        {
                            ViewBag.correct = "klarte ikke oppdatere";
                            Customer old = (Customer)Session["loggedInUser"];
                            return View();
                        }
                    } ViewBag.correct = "bekreftet ikke passordet riktig";
                    return View();
                } ViewBag.correct = "ikke riktig nåværende passord";
                return View();
            } return RedirectToAction("PersonalSite");
        }

        public ActionResult updateUserPassword()
        {
            Customer c = (Customer)Session["loggedInUser"];
            TempData["pview"] = "password";
            return View("PersonalSite",c);
        }

        public ActionResult updateUserinfo()
        {
            Customer c = (Customer)Session["loggedInUser"];
            TempData["pview"] = "info";
            return View("PersonalSite",c);
        }

        [HttpPost]
        public ActionResult updateUserinfo(Customer newUser)
        {

            if (ModelState.IsValid)
            {
                Customer c = (Customer)Session["loggedInUser"];
                var customerDB = new DBCustomer(); 
                if (!customerDB.checkEmail(newUser.email,c.id))
                {
                    ViewBag.ok = "email er i bruk av annen bruker, velg en annen";
                    return View();
                }
       
                  c.firstname = newUser.firstname;
                  c.lastname = newUser.lastname;
                  c.email = newUser.email;
                  c.phonenumber = newUser.phonenumber;
                  c.address = newUser.address;
                  c.postalcode = newUser.postalcode;
                  c.postalarea = newUser.postalarea;
                  
                    bool updateOK = customerDB.update(c.id, c);
                
                    if (updateOK)
                    {
                        Session["loggedInUser"] = c;
                        TempData["changed"] = "Brukerinformasjon ble oppdatert";
                        return RedirectToAction("PersonalSite"); 
                    }
                    else
                    {
                       Customer old = (Customer)Session["loggedInUser"];
                       ViewBag.ok = "klarte ikke oppdatere"; 
                       return View();
                    }
            }
            ViewBag.ok = "et felt er blankt, fyll det ut og trykk oppdater";
            return View();
        }

        private void logInUser(String un)
        {
            var customerDB = new DBCustomer(); 
            var founduser = customerDB.findCustomer(un);
            
            if(int.Parse(founduser.postalcode) < 1000)
            {
                founduser.postalcode = "0" + founduser.postalcode;
                if (int.Parse(founduser.postalcode) < 100)
                {
                    founduser.postalcode = "0" + founduser.postalcode;
                    if(int.Parse(founduser.postalcode) < 10)
                        founduser.postalcode = "0" + founduser.postalcode;
                }

            }

            founduser.shoppingcart = new ShoppingCart(founduser.id);
            Session["loggedInUser"] = founduser;
            
        }

    }
}

