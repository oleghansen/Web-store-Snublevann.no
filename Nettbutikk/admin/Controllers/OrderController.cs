using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Diagnostics;

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

        public ActionResult ListOrders(int? page, int? itemsPerPage, string sortOrder)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CIDSortParm = sortOrder == "CID" ? "cid_desc" : "CID";
            ViewBag.CFNameSortParm = sortOrder == "CFName" ? "cfname_desc" : "CFName";
            ViewBag.CLNameSortParm = sortOrder == "CLName" ? "clname_desc" : "CLName";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "amount_desc" : "Amount";
            ViewBag.TotalSortParm = sortOrder == "Total" ? "total_desc" : "Total"; 

            
            List<OrderViewModel> list = new List<OrderViewModel>();

            List<Order> allOrders = _orderbll.getAllOrders(null);

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
            switch(sortOrder)
            {
                case "id_desc":
                    list = list.OrderByDescending(s => s.id).ToList();
                    break; 
                case "Date":
                    list = list.OrderBy(s => s.orderdate).ToList();
                    break;
                case "date_desc":
                    list = list.OrderByDescending(s => s.orderdate).ToList();
                    break;
                case "CID":
                    list = list.OrderBy(s => s.customerid).ToList();
                    break;
                case "cid_desc":
                    list = list.OrderByDescending(s => s.customerid).ToList();
                    break;
                case "CFName":
                    list = list.OrderBy(s => s.customer.firstname).ToList();
                    break;
                case "cfname_desc":
                    list = list.OrderByDescending(s => s.customer.firstname).ToList();
                    break;
                case "CLName":
                    list = list.OrderBy(s => s.customer.lastname).ToList();
                    break;
                case "clname_desc":
                    list = list.OrderByDescending(s => s.customer.lastname).ToList();
                    break;
                case "Amount":
                    list = list.OrderBy(s => s.quantity).ToList();
                    break;
                case "amount_desc":
                    list = list.OrderByDescending(s => s.quantity).ToList();
                    break;
                case "Total":
                    list = list.OrderBy(s => s.sum).ToList();
                    break;
                case "total_desc":
                    list = list.OrderByDescending(s => s.sum).ToList();
                    break; 
                default:
                    list = list.OrderBy(s => s.id).ToList();
                    break;
            }

            ViewBag.CurrentItemsPerPage = itemsPerPage;
            sw.Stop();

            Debug.WriteLine("GEtall i contoller Elapsed={0}", sw.Elapsed);
            //getall i contoller Elapsed=00:00:14.5930095

            return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
        }

       
        public ActionResult ListOrderLines(int id, int? page, int? itemsPerPage, string sortOrder)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");

            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.PIDSortParm = sortOrder == "PID" ? "pid_desc" : "PID";
            ViewBag.PNameSortParm = sortOrder == "PName" ? "pname_desc" : "PName";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "amount_desc" : "Amount";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.TotalSortParm = sortOrder == "Total" ? "total_desc" : "Total"; 

            List<OrderLineViewModel> list = new List<OrderLineViewModel>();

            List<Order> allOrders = _orderbll.getAllOrders(id);
            int linje = 1;
            foreach(var item in allOrders){
            
                foreach(var olItem in item.orderLine)
                {

                    list.Add(new OrderLineViewModel() 
                    {
                        id = linje,
                        customer = item.customer,
                        orderdate  = item.orderdate, 
                        orderId = item.id, 
                        product = olItem.product,
                        quantity = olItem.quantity,
                        orderlineSum = (olItem.quantity * olItem.product.price) ,
                        customerid = item.customerid,
                        price = olItem.product.price.ToString(),
                        productid = olItem.productid.ToString(),
                        productname = olItem.product.name



                    });
                    linje++;
                }
            }
            switch (sortOrder)
            {
                case "id_desc":
                    list = list.OrderByDescending(s => s.id).ToList();
                    break;
                case "PID":
                    list = list.OrderBy(s => s.product.itemnumber ).ToList();
                    break;
                case "pid_desc":
                    list = list.OrderByDescending(s => s.product.itemnumber).ToList();
                    break;
                case "PName":
                    list = list.OrderBy(s => s.product.name).ToList();
                    break;
                case "pname_desc":
                    list = list.OrderByDescending(s => s.product.name).ToList();
                    break;
                case "Amount":
                    list = list.OrderBy(s => s.quantity).ToList();
                    break;
                case "amount_desc":
                    list = list.OrderByDescending(s => s.quantity).ToList();
                    break;
                case "Price":
                    list = list.OrderBy(s => s.product.price).ToList();
                    break;
                case "price_desc":
                    list = list.OrderByDescending(s => s.product.price).ToList();
                    break;
                case "Total":
                    list = list.OrderBy(s => s.orderlineSum).ToList();
                    break;
                case "total_desc":
                    list = list.OrderByDescending(s => s.orderlineSum ).ToList();
                    break;
                default:
                    list = list.OrderBy(s => s.id).ToList();
                    break;
            }
            ViewBag.CurrentItemsPerPage = itemsPerPage;
            return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
            
        }

        public ActionResult showReceipt(int id)
        {

            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
          
            Order allOrders = _orderbll.getAllOrders(id)[0];
            BillingViewModel b = null;
        
               List<int> s = new List<int>();
               foreach(var i in allOrders.orderLine)
               {
                   
                     s.Add(i.quantity * i.product.price);
                }
               
               b = new BillingViewModel() 
               {
                    customer = allOrders.customer,
                    order = allOrders,
                    ordreid = allOrders.id,  
                    orderdate = allOrders.orderdate,
                    shoppingcart = allOrders.orderLine,
                    totsum = _orderbll.getSum(allOrders),
                    mva = _orderbll.getMva(_orderbll.getSum(allOrders)), 
                    exmva = _orderbll.getExmva(_orderbll.getSum(allOrders)),
                    sum = s
                    
               };
              
            return View(b);
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