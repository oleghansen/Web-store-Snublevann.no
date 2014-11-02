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
        public void find_user()
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