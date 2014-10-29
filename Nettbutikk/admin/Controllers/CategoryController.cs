using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace Nettbutikk.admin.Controllers
{
    public class CategoryController : Controller
    {
        // TODO: mulig endre til annen BLL
        private ICategoryBLL _categoryBLL;

        public CategoryController()
        {
            _categoryBLL = new CategoryBLL();
        }

        public CategoryController(CategoryBLL stub)
        {
            _categoryBLL = stub;
        }

        public ActionResult ListCategories(int? page, int? itemsPerPage, string sortOrder, string currentFilter, string searchString)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemSortParm = String.IsNullOrEmpty(sortOrder) ? "item_desc" : ""; 
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.ProducerSortParm = sortOrder == "Producer" ? "producer_desc" : "Producer";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter; 

            ViewBag.CurrentFilter = searchString; 
            List<Category> allCategories; 
            if(!String.IsNullOrEmpty(searchString))
                allCategories = _categoryBLL.getResult(null, searchString); 
            else
               allCategories = _categoryBLL.getAll(null);

            switch (sortOrder)
            {
                case "item_desc":
                    allCategories = allCategories.OrderByDescending(s => s.ID).ToList();
                    break;
                case "name_desc":
                    allCategories = allCategories.OrderByDescending(s => s.name).ToList();
                    break;
                default:
                    allCategories = allCategories.OrderBy(s => s.ID).ToList();
                    break;
            }
            
            List<CategoryInfo> list = new List<CategoryInfo>();
            foreach (var item in allCategories)
            {
                list.Add(
                    new CategoryInfo()
                    {
                        id = item.ID,
                        name = item.name
                    });
            }

            return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
        }

        public ActionResult newCategory()
        {
            if (!isAdmin())
                return RedirectToAction("Login", "Main");
            return View();
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