using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class AdminEnforcementCategory
    {
        [TestMethod]
        public void non_admin_list_categories()
        {
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            var result = (RedirectToRouteResult)controller.ListCategories(null, null, null, null, null);

            Assert.AreEqual("Main", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
    }
}