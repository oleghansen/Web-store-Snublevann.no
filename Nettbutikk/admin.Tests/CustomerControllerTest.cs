﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Models;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;
using MvcContrib.TestHelper;
using System.Web;
using PagedList;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void customer_list_customers()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true }; 

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, null, null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].id < result[1].id);
        }

        [TestMethod]
        public void customer_list_customers_order_id_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "id_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].id > result[1].id);
        }

        [TestMethod]
        public void customer_list_customers_sort_customer()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "FName", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname,result[1].firstname) < 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_customer_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "fname_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) > 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_lastname()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "LName", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) < 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_lastname_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "lname_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) > 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_address()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "Address", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) > 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_address_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "address_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) < 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_email()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "EMail", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) > 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_email_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "email_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) < 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_postalarea()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "PArea", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) > 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_postalarea_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "parea_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) < 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_postalcode()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "PCode", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) > 0);
        }

        [TestMethod]
        public void customer_list_customers_sort_postalcode_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomers(null, null, "pcode_desc", null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare(result[0].firstname, result[1].firstname) < 0);
        }



        [TestMethod]
        public void customer_makeadmin()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            UserInfo expected = new UserInfo()
            {
                id = 3,
                firstname = "Jens",
                admin = false
            };

            //Act
            var action = (JsonResult)controller.makeAdmin(expected.id);
            var result = (bool)(new PrivateObject(action.Data, "success")).Target;
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void customer_revokeadmin()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            UserInfo expected = new UserInfo()
            {
                id = 3,
                firstname = "Jens",
                admin = true
            };

            //Act
            var action = (JsonResult)controller.revokeAdmin(expected.id);
            var result = (bool)(new PrivateObject(action.Data, "success")).Target;
            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void customer_list_details()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.CustomerDetails(2);
            var result = actual.Model;

            // Assert
            Assert.IsNotNull(result);
        }

        /*
        [TestMethod]
        public void customer_list_customers_orders()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var actual = (ViewResult)bll.ListCustomerOrders(2, 2, null, null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].id < result[1].id);
        }*/

        [TestMethod]
        public void customer_delete()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (JsonResult)controller.deleteCustomer(2);
            var success = (bool)(new PrivateObject(action.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success);
        }


        [TestMethod]
        public void Hashed_password_Not_Null()
        {
            //Arrange
            var bll = new CustomerBLL();
            String password = "yo";

            //Act
            var result = bll.makeHash(password);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Hashed_password_Not_empty()
        {
            //Arrange
            var bll = new CustomerBLL();
            var array = System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.ASCII.GetBytes("yo"));
            String password = "yo";

            //Act
            var result = bll.makeHash(password);

            //Assert
            Assert.AreNotEqual(array, result);
        }

        [TestMethod]
        public void customer_find_customer()
        {
            //Arrange 
            var bll = new CustomerBLL(new CustomerDALStub());
            string email = "admin@istrat.or";         
            //Act 
            var result = bll.findUser(email);
            //Assert
            Assert.IsNotNull(result.id);
        }
     


 /*       [TestMethod]
       public void validate_login()
        {
            //Arrange
            var bll = new MainController(new CustomerBLL(new CustomerDALStub()));
            String email =  "admin@istrat.or";
            String p = "admin";
           

            //Act
            var result = (ViewResult)bll.logInAdmin(email, p);
            
            
            
            //Assert
            Assert.IsNotNull(result.Model);

        }
        */

       

        [TestMethod]
        public void logged_inn_Main()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            //arrange
            var bll = new MainController();
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
         
            //Act
            var result = (ViewResult)bll.Main();
            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void test_database()
        {
            TestControllerBuilder builder = new TestControllerBuilder(); 
            //arrange
            var bll = new CustomerController();
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            // act
            var actual = (ViewResult)bll.ListCustomers(null, null, null, null, null);
            var result = (IPagedList<UserInfo>)actual.Model;

            //Assert
            Assert.IsTrue(result.Count > 0);
        }  
    }
}
