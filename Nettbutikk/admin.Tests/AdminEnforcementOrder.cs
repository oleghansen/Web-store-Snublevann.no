using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class AdminEnforcementOrder
    {
        [TestMethod]
        public void non_admin_list_orders()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListOrders(); 

            //Assert
            Assert.AreEqual("Main", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
    }
}
