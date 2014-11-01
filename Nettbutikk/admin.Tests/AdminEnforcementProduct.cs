using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class AdminEnforcementProduct
    {
        [TestMethod]
        public void non_admin_product_list_products()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ListProducts(null,null,null,null,null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
        [TestMethod]
        public void non_admin_product_index()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.Index();

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_product_product_details()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ProductDetails(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_product_product_details_httppost()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.ProductDetails(0,null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_product_add_product()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.addProduct();

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_product_add_product_httppost()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.addProduct(null);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void non_admin_product_delete_product()
        {
            //Arrange
            var controller = new ProductController(new ProductBLL(new ProductDALStub()));

            //Act
            var result = (RedirectToRouteResult)controller.deleteProduct(0);

            //Assert
            Assert.AreEqual("LogIn", result.RouteValues["Action"]);
            Assert.AreEqual("Main", result.RouteValues["Controller"]);
        }
    }
}
