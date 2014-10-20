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
            List<Order> allOrders = _orderbll.getAll();
            return View(allOrders);
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
            var user = (Customer)Session["loggedInUser"];
            return user.admin;
        }
    }
}