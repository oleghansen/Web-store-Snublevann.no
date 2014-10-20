using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class ProductBLLTest
    {
        [TestMethod]
        public void List_All_Products_Not_Null()
        {
            var allProd = new ProductController(new ProductBLL(new ProductDALStub()));
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

        [TestMethod]
        public void Contains_Products()
        {
            var allProd = new ProductController(new ProductBLL(new ProductDALStub()));
            List<Product> expected = new List<Product>();
            var prod = new Product()
            {
                itemnumber = 1,
                description = "Tullball",
                name = "Tull"
            };

            expected.Add(prod);
            expected.Add(prod);
            expected.Add(prod);

            var action = (ViewResult)allProd.ListProducts();
            var result = (List<Product>)action.Model;

            Assert.IsTrue(result.Count > 0);

        }
    }
}
