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
using System.Diagnostics;
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
            Assert.AreEqual(result.PageSize, 2);
            Assert.IsTrue(result[0].id > result[1].id);
            Assert.IsNotNull(result[0].id);

        }

        [TestMethod]
        public void order_is_equal()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            var order = new Order()
            {

                id = 298423,
                customerid = 1,
                orderdate = DateTime.Now
            };

            //Act 
            var actrow = (ViewResult)controller.ListOrders(null, null, null);
            var result = (IPagedList<OrderViewModel>)actrow.Model;

            //Assert
           Assert.AreEqual(actrow.ViewName, "" );
           Assert.AreEqual(result[0].id, order.id);
           Assert.AreEqual(result[0].customerid, order.customerid);


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
            Assert.IsNotNull(result[0].customer.firstname);
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

            Assert.IsTrue(string.Compare(result[0].customer.firstname, result[1].customer.firstname) >= 0);
         
           
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
            Assert.IsNotNull(result[0].customer.lastname);
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
            Debug.Write(result[0].customer.lastname + result[1].customer.lastname);
            Assert.IsTrue(string.Compare(result[0].customer.lastname, result[1].customer.lastname) > 0);
            Assert.IsNotNull(result[0].customer.lastname);
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
            Assert.IsNotNull(result[0].customerid);

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
            Assert.IsNotNull(result[0].customerid);

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
            Assert.IsTrue(result[0].quantity < result[1].quantity );
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
            Assert.IsTrue(result[0].sum  < result[1].sum);
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
            Assert.IsTrue(result[0].sum > result[1].sum);
            Assert.IsNotNull(result[0].sum);

        }

        [TestMethod]
        public void order_listOrders_sort_date()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "Date");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].orderdate.Date <= result[1].orderdate.Date);
            Assert.IsNotNull(result[0].orderdate);

        }


        [TestMethod]
        public void order_listOrders_sort_date_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrders(null, null, "date_desc");
            var result = (IPagedList<OrderViewModel>)actrow.Model;
            //Assert
            Assert.IsTrue(result[0].orderdate.Date >= result[1].orderdate.Date);
            Assert.IsNotNull(result[0].orderdate);

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
        public void order_listOrderLines_is_not_null()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            var order = new Order()
            {
                id = 298423,
                customerid = 1,
                orderdate = DateTime.Now
            };

            // Act 
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, null);
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            // Assert
            Assert.IsNotNull(result);
           // Assert.AreEqual(result.PageNumber, 2);
            Assert.IsInstanceOfType(result, typeof(IPagedList<OrderLineViewModel>));
            Assert.AreEqual(result[0].orderId , order.id ); 
            Assert.IsTrue(result[0].id <= result[1].id);

        }

        [TestMethod]
        public void order_orderlineslist_contains_orderlines()
        {
            TestControllerBuilder builder = new TestControllerBuilder();
            //Arrange
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            List<OrderLineViewModel> expected = new List<OrderLineViewModel>();
            var o = new OrderLineViewModel()
            {
                id = 1,
                productid = 100001.ToString(),
                quantity = 3,
                customerid = 1,
                orderdate = DateTime.Now, 
                orderId = 298423,
                orderlineSum = 300,
                price = 50.ToString(),
                productname = "hei"

            };

            expected.Add(o);
            expected.Add(o);
            expected.Add(o);
            // Act
            var actual = (ViewResult)bll.ListOrderLines(298423, null, 2, null);
            var result = (PagedList<OrderLineViewModel>)actual.Model;
            // Assert
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(result[0].orderlineSum, (int.Parse(result[0].price) * result[0].quantity) );
            
        }

        [TestMethod]
        public void order_listOrderlines_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423,1, 2, "id_desc");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.AreEqual(result.PageNumber, 2);
            Assert.AreEqual(result.PageSize, 2);
            Assert.IsTrue(result[0].id >= result[1].id);
            Assert.IsNotNull(result[0].id);

        }

        [TestMethod]
        public void order_listOrderlines_sort_pid()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, 1, 2, "PID");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.AreEqual(result.PageNumber, 1);
            Assert.AreEqual(result.PageSize, result.Count);
            Assert.IsTrue(result[0].product.itemnumber <= result[1].product.itemnumber );
            Assert.IsNotNull(result[0].product.itemnumber);

        }

        [TestMethod]
        public void order_listOrderlines_sort_pid_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, 1, 2, "pid_desc");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.AreEqual(result.PageNumber, 1);
            Assert.AreEqual(result.PageSize, result.Count);
            Assert.IsTrue(result[0].product.itemnumber > result[1].product.itemnumber);
            Assert.IsNotNull(result[0].product.itemnumber);

        }

        [TestMethod]
        public void order_listOrderlines_sort_pname()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, 1, 2, "PName");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.AreEqual(result.PageNumber, 1);
            Assert.AreEqual(result.PageSize, result.Count);
            Assert.IsTrue(string.Compare(result[0].product.name, result[1].product.name) <= 0);
            Assert.IsNotNull(result[0].product.name);

        }

        [TestMethod]
        public void order_listOrderlines_sort_pname_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "pname_desc");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(string.Compare(result[0].product.name, result[1].product.name) >= 0);
            Assert.IsNotNull(result[0].product.name);

        }

        [TestMethod]
        public void order_listOrderlines_sort_amount()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "Amount");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(result[0].quantity  < result[1].quantity);
            Assert.IsNotNull(result[0].product.quantity );

        }

        [TestMethod]
        public void order_listOrderlines_sort_amount_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "amount_desc");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(result[0].quantity > result[1].quantity);
            Assert.IsNotNull(result[0].product.quantity);

        }

        [TestMethod]
        public void order_listOrderlines_sort_price()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "Price");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(result[0].product.price  <= result[1].product.price);
            Assert.IsNotNull(result[0].product.price);

        }

        [TestMethod]
        public void order_listOrderlines_sort_price_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "price_desc");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(result[0].product.price >= result[1].product.price);
            Assert.IsNotNull(result[0].product.price);

        }

        [TestMethod]
        public void order_listOrderlines_sort_totalsum()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "Total");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(result[0].orderlineSum  < result[1].orderlineSum);
            Assert.IsNotNull(result[0].orderlineSum);

        }

        [TestMethod]
        public void order_listOrderlines_sort_totalsum_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new OrderController(new OrderBLL(new OrderDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            //Act
            var actrow = (ViewResult)controller.ListOrderLines(298423, null, null, "total_desc");
            var result = (IPagedList<OrderLineViewModel>)actrow.Model;

            Assert.IsTrue(result[0].orderlineSum > result[1].orderlineSum);
            Assert.IsNotNull(result[0].orderlineSum);

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
