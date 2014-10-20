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
        public void non_admin_list_customers()
        {
            //Arrange
            CustomerController controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            
            //Act
            var result = (RedirectToRouteResult)controller.ListCustomers(); 

            //Assert

            Assert.AreEqual("Main",result.RouteValues["Action"]);
            Assert.AreEqual("Main",result.RouteValues["Controller"]);
        }
    }
}
