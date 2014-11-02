using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Nettbutikk.admin.Controllers;
using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using Nettbutikk.Model;
using PagedList;
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
        public void order_listOrders_is_not_null()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act 
            var actrow = (ViewResult)controller.ListOrders(2,2,null);
            var result = (IPagedList<OrderViewModel>)actrow.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.PageNumber, 2);
            Assert.IsInstanceOfType(result, typeof(IPagedList<OrderViewModel>));
            Assert.IsTrue(result[0].id < result[1].id);
        }

        [TestMethod]
        public void order_listOrders_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(2, 2, "id_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;

            Assert.AreEqual(result.PageNumber, 2);
            Assert.IsTrue(result[0].id > result[1].id);

        }

        [TestMethod]
        public void order_list_contains_orders()
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
            expected.Add(o);
            expected.Add(o);
            expected.Add(o);

           
            // Act

            var actual = (ViewResult)bll.ListOrders(null, null, null);
            var result = (IPagedList<OrderViewModel>)actual.Model;


            // Assert
            Assert.AreEqual(expected.Count, result.Count);
        }

        [TestMethod]
        public void order_showReciept_not_null()
        {
            TestControllerBuilder builder = new TestControllerBuilder();
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            BillingViewModel expected = new BillingViewModel()
            { 
                ordreid = 12345,
                orderdate =DateTime.Now,
                totsum = 30,
                mva = 8,
                exmva = 28,
                
            };

            //Act
            var action = (ViewResult)controller.showReceipt(12345);
            var result = (BillingViewModel)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.sum.Count, result.shoppingcart.Count); 
            
        }
    }
}
