using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nettbutikk.Model;
using Nettbutikk.admin.Controllers;
using Nettbutikk.BLL;
using System.Web.Mvc;
using Nettbutikk.DAL;
using System.Collections.Generic;

namespace admin.Tests
{
    [TestClass]
    public class CustomerBLLTest
    {
        [TestMethod]
        public void List_All_Customers()
        {
            // Arrange
            var bll = new CustomerController(new CustomerBLL(new CustomerDALStub()));
            List<Customer> expected = new List<Customer>();
            var cust = new Customer()
            {
                id = 1,
                firstname = "Gunnar",
                lastname = "Hansen",
                address = "Golia",
                email = "klin@kokkos.no",
                postalarea = "Gollie",
                postalcode = "1232",
                phonenumber = "94499449",
                password = "tullball123"

            };

            expected.Add(cust);

            // Act
            var actrow = (ViewResult)bll.ListAll();
            var result = (List<Customer>)actrow.Model;

                     
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Count, result.Count);
        }
    }
}
