using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Nettbutikk.admin.Controllers;
using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nettbutikk.admin.Tests
{
    [TestClass]
    public class OrderTestController
    {
        [TestMethod]
        public void Order_List_Is_Not_Null()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
          

            // Act 

            var actrow = (ViewResult)bll.ListOrders(null,null,null,null);
            var result = (List<OrderViewModel>)actrow.Model;


            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Order_List_Contains_Orders()
        {
            TestControllerBuilder builder = new TestControllerBuilder();
            //Arrange
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            List<OrderViewModel> expected = new List<OrderViewModel>();
            var o = new OrderViewModel()
            {
                id = 1,
                customerid = 1001
            };

            expected.Add(o);
            expected.Add(o);
            expected.Add(o);
           
            // Act

            var actrow = (ViewResult)bll.ListOrders(null, null, null, null);
            var result = (List<OrderViewModel>)actrow.Model;


            // Assert
            Assert.AreEqual(expected.Count, result.Count);
        }

        
        [TestMethod]
        public void Find_Order_By_Id()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder(); 
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true }; 
            var expected = new Order()
            {
                id = 1,
                customerid = 1001,
                orderdate = DateTime.Now
            };

            // Act
            var actionResult = (ViewResult)bll.Details(1);
            var result = (Order)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expected.id, result.id);
            Assert.AreEqual(expected.customerid, result.customerid);
            Assert.AreEqual(expected.orderLine, result.orderLine);
        }
    }
}
