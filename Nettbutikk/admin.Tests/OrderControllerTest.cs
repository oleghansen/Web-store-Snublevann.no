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
        public void order_listOrders_sort_cfname()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "CFName");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(string.Compare(result[0].customer.firstname ,result[1].customer.firstname) < 0);

        }

        [TestMethod]
        public void order_listOrders_sort_cfname_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "cfname_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(string.Compare(result[0].customer.firstname, result[1].customer.firstname) > 0);

        }

        [TestMethod]
        public void order_listOrders_sort_clname()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "CLName");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(string.Compare(result[0].customer.lastname, result[1].customer.lastname) < 0);

        }

        [TestMethod]
        public void order_listOrders_sort_clname_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "clname_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(string.Compare(result[0].customer.lastname, result[1].customer.lastname) >= 0);

        }


        [TestMethod]
        public void order_listOrders_sort_cid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "cid");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].customerid < result[1].customerid);

        }

        [TestMethod]
        public void order_listOrders_sort_cid_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "cid_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].customerid > result[1].customerid);

        }

        [TestMethod]
        public void order_listOrders_sort_amount()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "Amount");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].quantity <= result[1].quantity );
            Assert.IsNotNull(result[0].quantity); 

        }

        [TestMethod]
        public void order_listOrders_sort_amount_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "amount_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].quantity >= result[1].quantity);
            Assert.IsNotNull(result[0].quantity); 

        }

        [TestMethod]
        public void order_listOrders_sort_sum()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "Total");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].sum  <= result[1].sum);
            Assert.IsNotNull(result[0].sum);

        }

        [TestMethod]
        public void order_listOrders_sort_sum_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "total_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].sum >= result[1].sum);
            Assert.IsNotNull(result[0].sum);

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
