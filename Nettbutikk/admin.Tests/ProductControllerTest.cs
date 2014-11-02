using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections.Generic;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;
using MvcContrib.TestHelper;
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
        
        [TestMethod]
        public void product_detail_view()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            ProductDetail expected = new ProductDetail()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei",
                price = 123,
                volum = 50,
                producerid = 2,
                longDescription = "Tullball er et fantastisk godt drikkeprodukt",
                subCategoryid = 3,
                countryid = 1
            };

            // Act
            var action = (ViewResult)controller.ProductDetails(expected.itemnumber);
            var result = (ProductDetail)action.Model;

            // Assert
            Assert.AreEqual(expected.itemnumber, result.itemnumber);
            Assert.AreEqual(expected.name, result.name);
            Assert.AreEqual(expected.description, result.description);
            Assert.AreEqual(expected.price, result.price);
            Assert.AreEqual(expected.volum, result.volum);
            Assert.AreEqual(expected.producerid, result.producerid);
            Assert.AreEqual(expected.longDescription, result.longDescription);
            Assert.AreEqual(expected.countryid, result.countryid);
        }

        [TestMethod]
        public void product_update_detail_HTTPPOST_modelState_IsValid()
        {
            // Arrange
            TestControllerBuilder builder = new TestControllerBuilder();

            var controller = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            ProductDetail expected = new ProductDetail()
            {
                itemnumber = 1,
                name = "Tullball",
                description = "Hei",
                price = 123,
                volum = 50,
                producerid = 2,
                longDescription = "Tullball er et fantastisk godt drikkeprodukt",
                subCategoryid = 3,
                countryid = 1
            };

            // Act
            var result = (JsonResult)controller.ProductDetails( 1, expected);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;

            //Assert
            Assert.IsTrue(success);
        }
    }
}
