using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;
using MvcContrib.TestHelper;
using PagedList.Mvc;
using PagedList;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class CategoryBLLTest
    {
        [TestMethod]
        public void Category_Add_Return_True()
        {
            TestControllerBuilder builder = new TestControllerBuilder();

            var bll = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            var expected = new Category()
            {
                ID = 1,
                name = "aifofjd"
            };

            //var action = (ViewResult)bll.newCategory(expected, 1);
           // var result = (bool)action.Model;

            //Assert.IsTrue(result);
        }
    }
}
