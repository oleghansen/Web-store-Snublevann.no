using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;
using System.Web;

namespace Nettbutikk.admin.Tests
{

    [TestClass]
    public class AdminEnforcementCustomer
    {

        [TestMethod]
        public void non_admin_customer_list_customers()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            
            //Act
            var result = (RedirectToRouteResult)controller.ListCustomers(null, null, null, null, null); 

            //Assert

            Assert.AreEqual("LogIn",result.RouteValues["Action"]);
            Assert.AreEqual("Main",result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_customer_make_admin()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.makeAdmin(0);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_customer_revoke_admin()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.revokeAdmin(0);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_customer_customer_details()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.CustomerDetails(0);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_customer_customer_details_httppost()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.CustomerDetails(null);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_customer_list_customer_orders()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListCustomerOrders(0, null, null, null, null);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
        [TestMethod]
        public void non_admin_customer_list_customer_order_lines()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListCustomersOrderLines(0, null, null, null, null);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_customer_delete_customer()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.deleteCustomer(0);

            //Assert

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
    }
}
