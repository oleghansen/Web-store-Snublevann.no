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
        //hvilken side skal man skjekke at man er logget inn eller ei ?
        //tatt fra lærern
        public ActionResult Frontpage()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }
             return View();
         }

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


