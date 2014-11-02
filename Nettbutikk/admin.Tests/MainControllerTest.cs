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
            var controller = new MainController(new CustomerBLL(new CustomerDALStub()));
            // Act
            var result = (ViewResult)controller.LogIn();

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }
    }
}
