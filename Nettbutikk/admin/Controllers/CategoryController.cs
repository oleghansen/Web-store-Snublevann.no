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

        public ActionResult ListProducers(int? page, int? itemsPerPage, string sortOrder, string currentFilter, string searchString)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemSortParm = String.IsNullOrEmpty(sortOrder) ? "item_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter; 

            ViewBag.CurrentFilter = searchString;
            List<Producer> allProducers;
            if (!String.IsNullOrEmpty(searchString))
                allProducers = _categoryBLL.getResultProducer(null, searchString);
            else
                allProducers = _categoryBLL.getAllProducers(null);

            switch (sortOrder)
            {
                case "item_desc":
                    allProducers = allProducers.OrderByDescending(s => s.id).ToList();
                    break;
                case "name_desc":
                    allProducers = allProducers.OrderByDescending(s => s.name).ToList();
                    break;
                default:
                    allProducers = allProducers.OrderBy(s => s.id).ToList();
                    break;
            }

            List<ProducerInfo> list = new List<ProducerInfo>();
            foreach (var item in allProducers)
            {
                list.Add(
                    new ProducerInfo()
                    {
                        prodId = item.id,
                        prodName = item.name
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


        
        [HttpPost]
        public ActionResult newCategory(Category category)
        {
            if (!isAdmin())
                return RedirectToAction("Login", "Main");
            if (ModelState.IsValid)
            {
                Customer c = (Customer)Session["loggedInUser"];
                bool OK = _categoryBLL.Add(category, c.id);
                if (OK)
                {
                    return RedirectToAction("ListCategories");
                }
            }
            return View();
        }

        public ActionResult newSubCategory()
        {
            if (!isAdmin())
                return RedirectToAction("Login", "Main");
            return View();
        }

        [HttpPost]
        public ActionResult newSubCategory(SubCategory sc)
        {
            if (!isAdmin())
                return RedirectToAction("Login", "Main");
            if (ModelState.IsValid)
            {
                Customer c = (Customer)Session["loggedInUser"];
                bool OK = _categoryBLL.AddSub(sc, c.id);
                if (OK)
                {
                    return RedirectToAction("ListSubCategories");
                }
            }
            return View();
        }

        public ActionResult ListSubCategories(int? page, int? itemsPerPage, string sortOrder, string currentFilter, string searchString)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemSortParm = String.IsNullOrEmpty(sortOrder) ? "item_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            List<SubCategory> allSubCategories;
            if (!String.IsNullOrEmpty(searchString))
                allSubCategories = _categoryBLL.getResultSub(null, searchString);
            else
                allSubCategories = _categoryBLL.getAllSub(null);

            switch (sortOrder)
            {
                case "item_desc":
                    allSubCategories = allSubCategories.OrderByDescending(s => s.ID).ToList();
                    break;
                case "name_desc":
                    allSubCategories = allSubCategories.OrderByDescending(s => s.name).ToList();
                    break;
                default:
                    allSubCategories = allSubCategories.OrderBy(s => s.ID).ToList();
                    break;
            }

            ViewBag.CurrentItemsPerPage = itemsPerPage;

            List<SubCategoryInfo> list = new List<SubCategoryInfo>();
            foreach (var item in allSubCategories)
            {
                list.Add(
                    new SubCategoryInfo()
                    {
                        ID = item.ID,
                        name = item.name,
                        categoriesName = item.catName
                    });
            }

            return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 15));
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