using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using System.Collections.Generic;
using admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using System.Web.Mvc;

namespace Nettbutikk.admin.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Product_list_is_not_null()
        {
            // Arrange
            var product = new ProductController(new ProductBLL(new ProductDALStub()));
          
            // Act
            var result = (ViewResult) product.ListProducts();
            var actual = (List<Product>)result.Model;

            // Assert

            Assert.IsNotNull(actual);
        }
    }
}
