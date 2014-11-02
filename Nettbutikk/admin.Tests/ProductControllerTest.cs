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
            var result = (PagedList<ProductInfo>)action.Model;

            // Assert
            Assert.AreEqual(result.PageNumber, 2);
            Assert.IsNotNull(result);
            Assert.IsTrue(result[0].itemnumber < result[1].itemnumber);
        }
    }
}
