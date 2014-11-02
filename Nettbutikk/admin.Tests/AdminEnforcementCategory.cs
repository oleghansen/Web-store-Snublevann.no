using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;
using Nettbutikk.admin.Models;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class AdminEnforcementCategory
    {
        [TestMethod]
        public void non_admin_category_list_categories()
        {
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            var result = (RedirectToRouteResult)controller.ListCategories(null, null, null, null, null);

            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_list_producers()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            
            //Act
            var result = (RedirectToRouteResult)controller.ListProducers(null, null, null, null, null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_new_category()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.newCategory();

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
        [TestMethod]
        public void non_admin_category_new_category_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.newCategory(null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
        [TestMethod]
        public void non_admin_category_update_category_details()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.updateCatergoryDetails(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_update_category_details_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.updateCatergoryDetails(null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_new_subcategory()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.newSubCategory();

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_new_subcategory_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.newSubCategory(null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_list_subcategories()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListSubCategories(null, null, null, null, null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_subcategory_details()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.SubCatDetails(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
        [TestMethod]
        public void non_admin_category_subcategory_details_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.SubCatDetails(null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_delete_category_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.DeleteCategory(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_delete_subcategory_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.DeleteSubCategory(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_category_delete_producer_httppost()
        {
            //Arrange
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.DeleteProducer(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        
    }
}