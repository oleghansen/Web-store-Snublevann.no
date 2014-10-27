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

            var actrow = (ViewResult)allProd.ListProducts(null);
            var result = (List<Product>)actrow.Model;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contains_Products()
        {
            TestControllerBuilder builder = new TestControllerBuilder();

            var allProd = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(allProd);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            List<Product> expected = new List<Product>();
            var prod = new Product()
            {
                itemnumber = 1,
                description = "Tull",
                name = "Ball"
            };

            expected.Add(prod);
            expected.Add(prod);
            expected.Add(prod);

            var action = (ViewResult)allProd.ListProducts(null);
            var result = (List<Product>)action.Model;

            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod]
        public void Find_Product_By_Id()
        {
            TestControllerBuilder builder = new TestControllerBuilder();

            var bll = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            var expected = new Product()
            {
                itemnumber = 1,
                name = "Tull",
                description = "Ball"
            };

            var action = (ViewResult)bll.ProductDetails(1);
            var result = (Product)action.Model;


            Assert.AreEqual(action.ViewName, "");
            Assert.AreEqual(expected.itemnumber, result.itemnumber);
            Assert.AreEqual(expected.name, result.name);
            Assert.AreEqual(expected.description, result.description);

        }

       [TestMethod]
        public void Product_Update_Return_True()
        {
            TestControllerBuilder builder = new TestControllerBuilder();

            var bll = new ProductController(new ProductBLL(new ProductDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            var expected = new Product()
            {
                itemnumber = 1,
                name = "Tull",
                description = "Ball"
            };

            var action = (ViewResult)bll.Updated(1, expected);
            var result = (bool)action.Model;

            Assert.IsTrue(result);
        }



        // TODO: Test for sletting
        /*
        [TestMethod]
       public void Delete_Product_By_Id()
       {
           TestControllerBuilder builder = new TestControllerBuilder();

           var bll = new ProductController(new ProductBLL(new ProductDALStub()));
           builder.InitializeController(bll);
           builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
           var expected = new Product()
           {
               itemnumber = 1,
               name = "Tull",
               description = "Ball"
           };

           var action = (ViewResult)bll.Remove(1);
           var result = (Product)action.Model;
       }
         */
    }
}
