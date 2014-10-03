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

                if (!customerDB.checkEmail(newUser.email))
                {
                    ViewBag.email = true;
                    return View();
                }
                else if (!customerDB.checkUsername(newUser.username))
                {
                    ViewBag.username = true;
                    return View();
                }
                else
                {

                    byte[] hashedPassword = makeHash(newUser.password);
                    bool insertOK = customerDB.add(newUser, hashedPassword);
                    if (insertOK)
                    {
                        logInUser(newUser.username);
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
    
            Debug.WriteLine(un);
            Debug.WriteLine(pw);

            var customerDB = new DBCustomer(); 
            var hashedPassword = makeHash(pw); 
            if (customerDB.validate(un, hashedPassword))
            {
               
                 logInUser(un);
                ViewBag.loggedIn = true;
               //return RedirectToAction("PersonalSite"); 
                return Json(true);
            }
            else
            {
                Session["loggedInUser"] = null;
                ViewBag.loggedIn = false;
                //return RedirectToAction("Frontpage","Main");
                return Json(false);
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

        public ActionResult updateUserPassword(int id )
        {
            Customer c = (Customer)Session["loggedInUser"];

            return View(c);
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
                  var customerDB = new DBCustomer(); 
                    bool updateOK = customerDB.update(c.id, c);
                
                    if (updateOK)
                    {
                        Session["loggedInUser"] = c;
                        return RedirectToAction("PersonalSite"); 
                    }
                    else
                    {
                       Customer old = (Customer)Session["loggedInUser"];
                       ViewBag.ok = "klarte ikke oppdatere"; 
                       return View();
                    }
            }
            ViewBag.ok = "et felt er blankt, fyll det ut trykk oppdater";
            return View();
        }

        private void logInUser(String un)
        {
            var customerDB = new DBCustomer(); 
            var founduser = customerDB.findCustomer(un);
            founduser.shoppingcart = new ShoppingCart(founduser.id);
            Session["loggedInUser"] = founduser;
            
        }


    }
}

