using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public static byte[] hashPassword(String password)
        {
            string inPassword = password;
            var algorithm = System.Security.Cryptography.SHA512.Create();
            byte[] inData, outData;
            inData = System.Text.Encoding.ASCII.GetBytes(inPassword);
            outData = algorithm.ComputeHash(inData);

            return outData;
        }

        private static bool checkUser(String inUserName, String password )
        {
            //hent brukernavnet med passord ut av databsen 
            //hash det innkommende passordet: byte[] inPassword =  hashPassword(password);
            // UserFoundPassword = passordet fra databasen
            //UserFoundUserName = brukernavn fra databasen
            //if((UserFoundPassword == inPassword) && (UserFoundUserName.equals(inUserName)))
            //{
            //      return true;
            //}else
            //{
            //      return false;
            //}

            return false;
            
        }



    }
}