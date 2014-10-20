using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;
using MvcContrib.TestHelper;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class ProductBLLTest
    {
        [TestMethod]
        public void List_All_Products_Not_Null()
        {
            TestControllerBuilder builder = new TestControllerBuilder();
            var allProd = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(allProd);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            List<Product> expected = new List<Product>();
            var prod = new Product()
            {
                itemnumber = 100,
                description = "Tullball",
                name = "Tull"
            };

            expected.Add(prod);

            var actrow = (ViewResult)allProd.ListProducts();
            var result = (List<Product>)actrow.Model;

            Assert.IsNotNull(result);
        }
    }
}
