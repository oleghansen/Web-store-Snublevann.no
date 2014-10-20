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
            List<Order> allOrders = _orderbll.getAll();
            return View(allOrders);
        }
        // GET: OrderTest
        public ActionResult Index()
        {
            return View();
        }
    }
}