using Nettbutikk.BLL;
using Nettbutikk.admin.Models;
using Nettbutikk.Model; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using PagedList;


namespace Nettbutikk.admin.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBLL _customerbll;

        public CustomerController()
        {
            _customerbll = new CustomerBLL();
        }

        public CustomerController(CustomerBLL stud)
        {
            _customerbll = stud;
        }

        public ActionResult ListCustomers(int? page, int? itemsPerPage, string sortOrder, string currentFilter, string searchString)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "FName" ? "fname_desc" : "FName";
            ViewBag.LastNameSortParm = sortOrder == "LName" ? "lname_desc" : "LName";
            ViewBag.AddressSortParm = sortOrder == "Address" ? "address_desc" : "Address";
            ViewBag.EMailSortParm = sortOrder == "EMail" ? "email_desc" : "EMail";
            ViewBag.PostAreaSortParm = sortOrder == "PArea" ? "parea_desc" : "PArea";
            ViewBag.PostCodeSortParm = sortOrder == "PCode" ? "pcode_desc" : "PCode";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            List<Customer> allCustomers;

            if (!String.IsNullOrEmpty(searchString))
            {
                allCustomers = _customerbll.getResult(searchString); 
            }
            else
                allCustomers = _customerbll.getAll(); 
            
            switch(sortOrder)
            {
                case "id_desc":
                    allCustomers = allCustomers.OrderByDescending(s => s.id).ToList();
                    break;
                case "FName":
                    allCustomers = allCustomers.OrderBy(s => s.firstname).ToList();
                    break;
                case "fname_desc":
                    allCustomers = allCustomers.OrderByDescending(s => s.firstname).ToList();
                    break;
                case "LName":
                    allCustomers = allCustomers.OrderBy(s => s.lastname).ToList();
                    break;
                case "lname_desc":
                    allCustomers = allCustomers.OrderByDescending(s=> s.lastname).ToList();
                    break;
                case "Address":
                    allCustomers = allCustomers.OrderBy(s => s.address).ToList();
                    break;
                case "address_desc":
                    allCustomers = allCustomers.OrderByDescending(s => s.address).ToList();
                    break;
                case "EMail":
                    allCustomers = allCustomers.OrderBy(s=>s.email).ToList();
                    break;
                case "email_desc":
                    allCustomers = allCustomers.OrderByDescending(s => s.email).ToList();
                    break;
                case "PArea":
                    allCustomers = allCustomers.OrderBy(s => s.postalarea).ToList();
                    break;
                case "parea_desc":
                    allCustomers = allCustomers.OrderByDescending(s => s.postalarea).ToList();
                    break;
                case "PCode":
                    allCustomers = allCustomers.OrderBy(s => s.postalcode).ToList();
                    break;
                case "pcode_desc":
                    allCustomers = allCustomers.OrderByDescending(s => s.postalcode).ToList(); 
                    break;
                default:
                    allCustomers = allCustomers.OrderBy(s => s.id).ToList(); 
                    break; 
            }

            ViewBag.CurrentItemsPerPage = itemsPerPage;

            List<UserInfo> list = new List<UserInfo>();
            foreach(var item in allCustomers)
            {
                list.Add(
                    new UserInfo()
                    {
                        id = item.id,
                        firstname = item.firstname,
                        lastname = item.lastname,
                        email = item.email,
                        address = item.address,
                        phonenumber = item.phonenumber,
                        password = item.password,
                        hashpassword = item.hashpassword,
                        postalarea = item.postalarea,
                        postalcode = item.postalcode,
                        admin = item.admin

                        
                    });
               
            }
            return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
        }

        private bool isAdmin(){
            if (Session == null)
            {
                Debug.WriteLine("her?");
                return false;
            }
            var user = (Customer) Session["loggedInUser"];
            return (user == null)?false:user.admin; 
        }

        [HttpGet]
        public ActionResult  makeAdmin(int id)
        {
            if (!isAdmin())
            {
                return RedirectToAction("Login", "Main");
            }
            Customer c = (Customer)Session["loggedInUser"];
            var b =  _customerbll.makeAdmin(id, c.id);
            return RedirectToAction("CustomerDetails", new { id = id});
            //her skal det komme en modalboks som spør om man er sikker på at man vil gi bruker full tilgang til systemet
        }

        [HttpGet]


        public ActionResult revokeAdmin(int id)
        {
            if (!isAdmin())
            {
                return RedirectToAction("Login", "Main");
            }
            Customer c = (Customer)Session["loggedInUser"];
            if(id == c.id)
                //her skal vel en modalboks av noe slag komme opp
                return RedirectToAction("CustomerDetails", new { id = id });
                
            
            var b = _customerbll.revokeAdmin(id,c.id);
            return RedirectToAction("CustomerDetails", new { id = id });
        }

        public ActionResult CustomerDetails(int id)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");

            
            Customer customerDetails = _customerbll.getCustomer(id);

            CustomerDetail custinfo = new CustomerDetail()
            {
                id = customerDetails.id,
                firstname = customerDetails.firstname,
                lastname = customerDetails.lastname,
                email = customerDetails.email,
                address = customerDetails.address,
                postalarea = customerDetails.postalarea,
                postalcode = customerDetails.postalcode,
                phonenumber = customerDetails.phonenumber,
                admin = customerDetails.admin
            };
            return View(custinfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerDetails(CustomerDetail cd)
        {
            if (!isAdmin())
            {
                return RedirectToAction("Login", "Main");
            }
            bool b = false;
            bool eouaoae = ModelState.IsValid;
            if (ModelState.IsValid)
            {
                Customer a = (Customer)Session["loggedInUser"];
                Customer c = new Customer();
                c.firstname = cd.firstname;
                c.lastname = cd.lastname;
                c.address = cd.address;
                c.email = cd.email;
                c.phonenumber = cd.phonenumber;
                c.postalarea = cd.postalarea;
                c.postalcode = cd.postalcode;
                b = _customerbll.update(cd.id, c, a.id);
            }
            if (b)
                return Json(new { success = true, message = "Endringene ble lagret", redirect = "/Customer/ListCustomers/" });
            return Json(new { success = false, message = "Noe gikk galt, endringene ble ikke lagret" }); 
        }

        public ActionResult ListCustomerOrders(int id,int? page, int? itemsPerPage, string sortOrder, string currentFilter)
        {
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

            

            IOrderBLL _orderbll = new OrderBLL();
           List<Order> orders =  _customerbll.getAllOrdersbyCust(id);
           
            List<OrderViewModel> list = new List<OrderViewModel>();

             foreach (var item in orders)
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
             switch (sortOrder)
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
             return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
        }

        public ActionResult ListCustomersOrderLines(int id, int? page, int? itemsPerPage, string sortOrder, string currentFilter)
        {

            if (!isAdmin())
                return RedirectToAction("Main", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.PIDSortParm = sortOrder == "PID" ? "pid_desc" : "PID";
            ViewBag.PNameSortParm = sortOrder == "PName" ? "pname_desc" : "PName";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "amount_desc" : "Amount";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.TotalSortParm = sortOrder == "Total" ? "total_desc" : "Total"; 

            IOrderBLL _orderbll = new OrderBLL();
            List<OrderLineViewModel> list = new List<OrderLineViewModel>();

            List<Order> allOrders = _orderbll.getAllOrders(id);
            int linje = 1;
            foreach (var item in allOrders)
            {

                foreach (var olItem in item.orderLine)
                {

                    list.Add(new OrderLineViewModel()
                    {
                        id = linje,
                        customer = item.customer,
                        orderdate = item.orderdate,
                        orderId = item.id,
                        order = item,
                        product = olItem.product,
                        quantity = olItem.quantity,
                        orderlineSum = (olItem.quantity * olItem.product.price),
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
                        list = list.OrderBy(s => s.product.itemnumber).ToList();
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
                        list = list.OrderByDescending(s => s.orderlineSum).ToList();
                        break;
                    default:
                        list = list.OrderBy(s => s.id).ToList();
                        break;
                }

                ViewBag.CurrentItemsPerPage = itemsPerPage;
                ViewBag.contoller = "customer";
                return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
           
        }

        public ActionResult delete(int id)
        {

            if (!isAdmin())
                return RedirectToAction("Main", "Main");
            Customer a = (Customer)Session["loggedInUser"];
            var b =_customerbll.delete(id, a.id); 
            return RedirectToAction("ListCustomers");
 
        }
    }
}