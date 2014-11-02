using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections.Generic;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using Nettbutikk.admin.Models;
using PagedList;

namespace Nettbutikk.admin.Tests
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void main_login_view()
        {
            // Arrange 
            var controller = new MainController();
            // Act
            var result = (ViewResult)controller.LogIn();

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void main_login_modelstate_is_invalid()
        {
            // Arrange 
            var controller = new MainController(new CustomerBLL(new CustomerDALStub()));
            controller.ViewData.ModelState.AddModelError("feil", "dette ble feil gitt");
            Customer cust = new Customer()
            {
                email = "",
                password = ""
            };
            // Act
            var result = (ViewResult)controller.logIn(cust.email,cust.password);

            //Assert
            Assert.AreEqual("", result.ViewName);
            Assert.IsTrue(result.ViewData.ModelState.Count == 1);

        }

        [TestMethod]
        public void main_login_modelstate_valid_ok_admin_is_null()
        {
             // Arrange 
            var controller = new MainController(new CustomerBLL(new CustomerDALStub()));
            Customer cust = new Customer()
            {
                email = "",
                password = ""
            };
            // Act
            var result = (ViewResult)controller.logIn(cust.email, cust.password);

            // Assert
            Assert.AreEqual("", result.ViewName);
            Assert.IsTrue(result.ViewData.ModelState.Count == 0);
        }

        [TestMethod]
        public void main_login_redirect_to_main_login_OK()
        {
            // Arrange 
            var controller = new MainController(new CustomerBLL(new CustomerDALStub()));
            Customer cust = new Customer()
            {
                email = "stats@minister.no",
                hashpassword = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("konge"))
            };
            // Act
            var result = (RedirectToRouteResult) controller.logIn(cust.email, cust.password);
            // Assert
            Assert.AreEqual("Main", result.RouteValues["Action"]);
        }

    }
}
