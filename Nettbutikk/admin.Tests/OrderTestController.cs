using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using Nettbutikk.DAL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nettbutikk.admin.Tests
{
    [TestClass]
    public class OrderTestController
    {
        [TestMethod]
        public void Order_List_Is_Not_Null()
        {
            // Arrange
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            List<Order> expected = new List<Order>();
            var o = new Order()
            {
                id = 1,
                customerid = 1001
            };

            

            // Act 

            var actrow = (ViewResult)bll.ListAll();
            var result = (List<Order>)actrow.Model;


            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Order_List_Contains_Orders()
        {

            //Arrange
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            List<Order> expected = new List<Order>();
            var o = new Order()
            {
                id = 1,
                customerid = 1001
            };

            expected.Add(o);
            // Act

            var actrow = (ViewResult)bll.ListAll();
            var result = (List<Order>)actrow.Model;


            // Assert
            Assert.AreEqual(expected.Count, result.Count);
        }

        /*
        [TestMethod]
        public void Find_Order_By_Id()
        {
            // Arrange
            var bll = new OrderController(new OrderBLL(new OrderDALStub()));
            var expected = new Order()
            {
                id = 1,
                customerid = 1001
            };

            // Act
            var actionResult = (ViewResult)bll.Details(1);
            var result = (Order)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(expected.id, result.id);
            Assert.AreEqual(expected.customerid, result.customerid);
        }
         */
    }
}
