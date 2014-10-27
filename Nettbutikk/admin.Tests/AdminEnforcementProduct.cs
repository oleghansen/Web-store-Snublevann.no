using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class AdminEnforcementProduct
    {
        [TestMethod]
        public void non_admin_list_products()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListProducts(null,null);

            //Assert
            Assert.AreEqual("Main", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
    }
}
