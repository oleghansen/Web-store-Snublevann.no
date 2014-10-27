using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.admin.Controllers
{
    public class OrderController : Controller
    {
        private IOrderBLL _orderbll;

        public OrderController()
        {
            _orderbll = new OrderBLL();
        }

        public OrderController(OrderBLL stud)
        {
            _orderbll = stud;
        }

        public ActionResult ListOrders()
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main");

            List<OrderViewModel> list = new List<OrderViewModel>();

            List<Order> allOrders = _orderbll.getAllOrders();

             foreach (var item in allOrders)
                {
                list.Add(new OrderViewModel()
                {
                    id = item.id,
                    orderdate = item.orderdate,
                    customerid = item.customerid,
                    customer = item.customer,
                    quantity = _orderbll.getNumItems(item),
                    sum = _orderbll.getSum(item)
                });
            }
            return View(list);
        }
        // GET: OrderTest
        public ActionResult Index()
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main"); 
            return View();
        }

        public ActionResult Details(int id)
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main"); 
            Order orderDetails = _orderbll.getOne(id);
            return View(orderDetails);
        }
        private bool isAdmin()
        {
            if (Session == null)
                return false;
            var user = (Customer)Session["loggedInUser"];
            return (user == null) ? false : user.admin;
        }
    }
}