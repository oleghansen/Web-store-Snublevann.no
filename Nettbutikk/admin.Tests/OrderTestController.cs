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
    }
}
