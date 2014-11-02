using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections.Generic;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using Nettbutikk.admin.Controllers;
using Nettbutikk.admin.Models;
using PagedList;

namespace Nettbutikk.admin.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void product_list_list_products()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, null, null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.AreEqual(result.PageNumber, 2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].itemnumber < result[1].itemnumber);
        }

        [TestMethod]

        public void product_list_products_sort_id_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "item_desc", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(result[0].itemnumber > result[1].itemnumber);
        }
        [TestMethod]
        public void product_list_products_name_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id=1, admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "name_desc", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(string.Compare(result[0].name, result[1].name) > 0);    
        }

        [TestMethod]
        public void product_list_products_name()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "Name", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(string.Compare(result[0].name, result[1].name) < 0);
        }

        [TestMethod]
        public void product_list_products_Price()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "Price", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(result[0].price < result[1].price);
        }

        [TestMethod]
        public void product_list_products_Price_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "price_desc", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(result[0].price > result[1].price);
        }

        [TestMethod]
        public void product_list_products_Producer()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "Producer", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(string.Compare(result[0].producer, result[1].producer) <= 0);
        }

        [TestMethod]
        public void product_list_products_Producer_desc()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            // Act
            var action = (ViewResult)controller.ListProducts(2, 2, "producer_desc", null, null);
            var result = (IPagedList<ProductInfo>)action.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsTrue(string.Compare(result[0].producer, result[1].producer) >= 0);
        }
        

    }
}
