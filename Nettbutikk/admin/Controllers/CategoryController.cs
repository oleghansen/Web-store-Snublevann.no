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
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : ""; 
            ViewBag.CategorySortParm = sortOrder == "Cat" ? "cat_desc" : "Cat";


            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter; 

            ViewBag.CurrentFilter = searchString; 
            List<Category> allCategories = _categoryBLL.getAll(null);

            switch (sortOrder)
            {
                case "id_desc":
                    allCategories = allCategories.OrderByDescending(s => s.ID).ToList();
                    break;
                case "cat_desc":
                    allCategories = allCategories.OrderByDescending(s => s.name).ToList();
                    break;
                case "Cat":
                    allCategories = allCategories.OrderBy(s => s.name).ToList();
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
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter; 

            ViewBag.CurrentFilter = searchString;
            List<Producer> allProducers = _categoryBLL.getAllProducers(null);

            switch (sortOrder)
            {
                case "id_desc":
                    allProducers = allProducers.OrderByDescending(s => s.id).ToList();
                    break;
                case "name_desc":
                    allProducers = allProducers.OrderByDescending(s => s.name).ToList();
                    break;
                case "Name":
                    allProducers = allProducers.OrderBy(s => s.name).ToList();
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
                return RedirectToAction("LogIn", "Main");
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken ]
        public ActionResult newCategory(CategoryInfo category)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");

            if (ModelState.IsValid)
            {
                Customer c = (Customer)Session["loggedInUser"];
                Category cat = new Category();
                cat.ID = category.id;
                cat.name = category.name;
                bool OK = _categoryBLL.Add(cat, c.id);
                if (OK)
                    return Json(new { success = true, message = cat.name + " ble lagt til.", redirect = "/Category/ListCategories?item_desc" });
            }
            return Json(new { success = false, message = "noe gikk galt, prøv igjen senere." });
        }

        public ActionResult updateCatergoryDetails(int id) 
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");

            List<Category> cat = _categoryBLL.getAll(id);
            CategoryInfo ci = new CategoryInfo();
            foreach(var item in cat){
                ci.id = item.ID;
                ci.name = item.name;
            }
           
            
 
            return View(ci);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult updateCatergoryDetails(CategoryInfo c)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            if (ModelState.IsValid)
            {
                Customer a = (Customer)Session["loggedInUser"];
                Category cat = new Category();
                cat.name = c.name;
                var b = _categoryBLL.updateCategory(c.id, cat ,a.id);
                return RedirectToAction("ListCategories");

            } return View(c.id);
        }

        public ActionResult newSubCategory()
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            var placeholder = new SubCategoryDetail()
            {
                categoryList = _categoryBLL.getAll(null).Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.name }).ToList()
            };
            return View(placeholder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newSubCategory(SubCategoryDetail sc)
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }

            if (ModelState.IsValid)
            {
                Customer admin = (Customer)Session["loggedInUser"];
                var adminid = admin.id;
                if (_categoryBLL.AddSub(adminid, new SubCategory()
                {
                    name = sc.name,
                    catId = sc.categoryId
                }))
                    return Json(new { success = true, message = "Ny subkategori ble lagt til", redirect = "/Category/ListSubCategories/" });
            }
            return Json(new { success = false, message = "Dette gikk ikke så bra, prøv igjen en annen gang" });
        }

        public ActionResult ListSubCategories(int? page, int? itemsPerPage, string sortOrder, string currentFilter, string searchString)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.CatNameSortParm = sortOrder == "CatName" ? "catname_desc" : "CatName";
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            List<SubCategory> allSubCategories = _categoryBLL.getAllSub(null);

            switch (sortOrder)
            {
                case "id_desc":
                    allSubCategories = allSubCategories.OrderByDescending(s => s.ID).ToList();
                    break;
                case "name_desc":
                    allSubCategories = allSubCategories.OrderByDescending(s => s.name).ToList();
                    break;
                case "Name":
                    allSubCategories = allSubCategories.OrderBy(s => s.name).ToList();
                    break;
                case "catname_desc":
                    allSubCategories = allSubCategories.OrderByDescending(s => s.catName).ToList();
                    break;
                case "CatName":
                    allSubCategories = allSubCategories.OrderBy(s => s.catName).ToList();
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

        public ActionResult SubCatDetails(int id)
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            SubCategory subcatdetails = _categoryBLL.SubCatDetails(id);

            SubCategoryDetail subDetail = new SubCategoryDetail()
            {
                ID = subcatdetails.ID,
                name = subcatdetails.name,
                categoryId = subcatdetails.catId,
                categoryList = _categoryBLL.getAll(null).Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.name }).ToList()
            };
            return View(subDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubCatDetails(SubCategoryDetail sc)
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            if (ModelState.IsValid)
            {
                SubCategory updated = new SubCategory()
                {
                    ID = sc.ID,
                    name = sc.name,
                    catId = sc.categoryId,
                };
                Customer admin = (Customer)Session["loggedInUser"];
                var adminid = admin.id;
                bool result = _categoryBLL.update(adminid, updated);
    
                sc.categoryList = _categoryBLL.getAll(null).Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.name }).ToList();

                return View(sc);
            }
            return RedirectToAction("ListSubCategories");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            if(!isAdmin())
                return RedirectToAction("LogIn","Main");
            Customer admin = (Customer) Session["loggedInUser"];

            var result = _categoryBLL.deleteCategory(id, admin.id);

            if(result == null)
                return Json(new {success= true, message = "Kategorien ble slettet",redirect="/Category/ListCategories/"});
            return Json(new { success = false, message = "<p>Du må først slette følgende subkategorier</p>", list = result }); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubCategory(int id)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            Customer admin = (Customer)Session["loggedInUser"];

            var result = _categoryBLL.deleteSubCategory(id, admin.id);

            if (result == null)
                return Json(new { success = true, message = "Subkategorien ble slettet", redirect = "/Category/ListSubCategories/" });
            return Json(new { success = false, message = "<p>Du må først slette følgende produkter</p>", list = result });
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProducer(int id)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            Customer admin = (Customer)Session["loggedInUser"];

            var result = _categoryBLL.deleteProducer(id, admin.id);

            if(result == null)
                return Json(new { success = true, message = "Produsenten ble slettet", redirect = "/Category/ListProducers/"});
            return Json(new { success = false, message = "<p>Du må først slette følgende produkter</p>", list = result }); 
        }


        private bool isAdmin()
        {
            if (Session == null)
                return false;
            var user = (Customer)Session["loggedInUser"];
            return (user == null) ? false : user.admin;
        }


        public ActionResult addProducer()
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addProducer(ProducerInfo producerinfo)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");

            if (ModelState.IsValid)
            {
                Customer c = (Customer)Session["loggedInUser"];
                Producer prod = new Producer();
                prod.id = producerinfo.prodId;
                prod.name = producerinfo.prodName;
                bool OK = _categoryBLL.AddProducer(prod, c.id);
                if (OK)
                    return Json(new { success = true, message = prod.name + " ble lagt til.", redirect = "/Category/ListProducers?item_desc" });
            }
            return Json(new { success = false, message = "noe gikk galt, prøv igjen senere." });
        }

        public ActionResult ProducerDetails(int id)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            Producer prodDetails = _categoryBLL.producerDetails(id);

            ProducerInfo prodinfo = new ProducerInfo()
            {
                prodId = prodDetails.id,
                prodName = prodDetails.name
            };

            return View(prodinfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProducerDetails(int id,ProducerInfo pi)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");

            if (ModelState.IsValid)
            {
                Customer c = (Customer)Session["loggedInUser"];
                Producer p = new Producer();
                p.name = pi.prodName;
                var result = _categoryBLL.updateProducer(id , p, c.id);
                if(result)
                        return Json(new { success = true, message = p.name + " ble endret.", redirect = "/Category/ListProducers/" });
            }
            return Json(new { success = false, message = "noe gikk galt, prøv igjen senere." });
        }
    }
}