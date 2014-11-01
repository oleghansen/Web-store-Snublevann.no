using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;
using MvcContrib.TestHelper;
using PagedList.Mvc;
using PagedList;

namespace Nettbutikk.Tests
{
    [TestClass]
    public class CategoryControllerTest
    {
        [TestMethod]
        public void Category_Add_Return_True()
        {
            TestControllerBuilder builder = new TestControllerBuilder();

            var bll = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(bll);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { admin = true };
            var expected = new Category()
            {
                ID = 1,
                name = "aifofjd"
            };

            //var action = (ViewResult)bll.newCategory(expected, 1);
           // var result = (bool)action.Model;

            //Assert.IsTrue(result);
        }
        [TestMethod]
        public void category_list_categories()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() {id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(2, 2, null, null, null);
            var result = (PagedList<CategoryInfo>)action.Model;

            //Assert
            Assert.AreEqual(result.PageNumber, 2);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IPagedList<CategoryInfo>));
            Assert.IsTrue(result[0].id < result[1].id);
        }
        [TestMethod]
        public void category_list_categories_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(2, 2, "id_desc", null, "notnull");
            var result = (PagedList<CategoryInfo>) action.Model;
            
            //Assert
            Assert.AreEqual(result.PageNumber, 1);
            Assert.IsTrue(result[0].id > result[1].id);
        }
        [TestMethod]
        public void category_list_categories_sort_category()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(null, null, "Cat", null, null);
            var result = (IPagedList<CategoryInfo>)action.Model;

            //Assert
            Assert.IsTrue(string.Compare(result[0].name,result[1].name) < 0);
        }
        [TestMethod]
        public void category_list_categories_sort_category_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListCategories(null, null, "cat_desc", null, null);
            var result = (IPagedList<CategoryInfo>)action.Model;

 
            //Assert
            Assert.IsTrue(string.Compare(result[0].name, result[1].name) > 0);
        }
        [TestMethod]
        public void category_list_producers()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, null, null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2,result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(result[0].prodId < result[1].prodId);
        }
        [TestMethod]
        public void category_list_producers_sort_id_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, "id_desc", null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(result[0].prodId > result[1].prodId);
        }
        [TestMethod]
        public void category_list_producers_sort_name()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, "Name", null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(string.Compare(result[0].prodName, result[1].prodName)<0);
        }
        [TestMethod]
        public void category_list_producers_sort_name_desc()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };

            //Act
            var action = (ViewResult)controller.ListProducers(2, 2, "name_desc", null, null);
            var result = (PagedList<ProducerInfo>)action.Model;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.PageNumber);
            Assert.IsInstanceOfType(result, typeof(IPagedList<ProducerInfo>));
            Assert.IsTrue(string.Compare(result[0].prodName, result[1].prodName) > 0);
        }
        [TestMethod]
        public void category_new_category_view()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true }; 

            //Act
            var action = (ViewResult)controller.newCategory();
           
            var result = (CategoryInfo)action.Model;

            //Assert
            Assert.AreEqual("", action.ViewName);
            Assert.IsNull(result); 
        }




        // denne funker ikke, må fikses!
        [TestMethod]
        public void category_new_category_httppost()
        {
            //Arrange
            TestControllerBuilder builder = new TestControllerBuilder();
            var controller = new CategoryController(new CategoryBLL(new CategoryDALStub()));
            builder.InitializeController(controller);
            builder.HttpContext.Session["loggedInUser"] = new Customer() { id = 1, admin = true };
            CategoryInfo c = new CategoryInfo()
            {
                
            };
            var expected = new {success = true}; 

            //Act
            var result = (JsonResult) controller.newCategory(c);
            var success = (bool)(new PrivateObject(result.Data, "success")).Target;
            //Assert
            Assert.IsTrue(success);
        }
    }
}
