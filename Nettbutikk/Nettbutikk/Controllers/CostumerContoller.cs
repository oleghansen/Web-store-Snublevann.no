using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nettbutikk.Models;

namespace Nettbutikk.Controllers
{
    public class CostumerContoller : Controller
    {   
        //SKjekker om man er logget inn
        //hvilken side skal man skjekke at man er logget inn eller ei ?
        //tatt fra lærern
        public ActionResult LogIn()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.LoggedIn = false;
            }
            else
            {
                ViewBag.LoggedIn = (bool)Session["LoggetInn"];
            }
            return View();
        }

        //Her kommer man dersom man har registrert en ny bruker 
        [HttpPost]
        public ActionResult Register(Customer newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new Models.DatabaseContext())
            {
                try
                {
                    var user = new Customers();
                    byte[] hasedpassword = makeHash(newUser.password);
                    user.Password = hasedpassword;
                    user.Username = newUser.username;
                    user.Firstname = newUser.firstname;
                    user.Lastname = newUser.lastname;
                    user.Email = newUser.email;
                    user.Phonenumber = newUser.phonenumber;
                    user.Address = newUser.address;
                    user.Postalcode = newUser.postalcode;
                    user.Postalareas = newUser.postalarea;
                    db.Customers.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("LogIn");
                }
                catch (Exception e)
                {
                    return View();
                }
            }
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

        // Her skjekker kaller man først opp userExits, dersom den gjør det så er man logget inn
        [HttpPost]
        public ActionResult LogIn(Customer user)
        {
            if (userExists(user))
            {
                Session["LoggetInn"] = true;
                ViewBag.loggedIn = true;
                return View();
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.loggedIn = false;
                return View();
            }
        }

        //Går inn i db og skjekker om brukeren finnes
        private static bool userExists(Customer user)
        {
            using (var db = new Models.DatabaseContext())
            {
                byte[] passwordDb = makeHash(user.password);
                Customers userFound = db.Customers.FirstOrDefault
                (u => u.Password == passwordDb && u.Username == user.username);
                if (userFound == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //Dersom man går inn i den personlige siden så viser man denne siden, ellers må man logge inn.
        public ActionResult PersonalSite()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggedIn = (bool)Session["LoggetInn"];
                if(loggedIn)
                {
                    return View();
                }
             }
             return RedirectToAction("LogIn");
        }
    }
}

