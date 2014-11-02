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
        public void non_admin_order_list_orders()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListOrders(null, null, null); 

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_order_list_order_lines()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListOrderLines(0,null, null, null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
       
        [TestMethod]
        public void non_admin_order_show_receipt()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.showReceipt(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }




    }
}
