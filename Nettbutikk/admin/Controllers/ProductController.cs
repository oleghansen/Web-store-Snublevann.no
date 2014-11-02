using Nettbutikk.admin.Models;
using Nettbutikk.BLL;
using Nettbutikk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Mvc.Html;

namespace Nettbutikk.admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductBLL _product;

        public ProductController()
        {
            _product = new ProductBLL();
        }
        public ProductController(IProductBLL stub)
        {
            _product = stub;
        }

        public ActionResult Index()
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main"); 
            return View();
        }
        
        public ActionResult ListProducts(int? page, int? itemsPerPage, string sortOrder, string currentFilter, string searchString)
        {
            if (!isAdmin())
                return RedirectToAction("LogIn", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemSortParm = String.IsNullOrEmpty(sortOrder) ? "item_desc" : ""; 
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.ProducerSortParm = sortOrder == "Producer" ? "producer_desc" : "Producer";
            ViewBag.VolumeSortParm = sortOrder == "Volume" ? "volume_desc" : "Volume";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter; 

            ViewBag.CurrentFilter = searchString; 
            List<Product> allProducts; 
            if(!String.IsNullOrEmpty(searchString))
                allProducts = _product.getResult(searchString); 
            else
               allProducts = _product.getAll();

            switch (sortOrder)
            {
                case "item_desc":
                    allProducts = allProducts.OrderByDescending(s => s.itemnumber).ToList();
                    break;
                case "name_desc":
                    allProducts = allProducts.OrderByDescending(s => s.name).ToList();
                    break;
                case "Name":
                    allProducts = allProducts.OrderBy(s => s.name).ToList();
                    break;
                case "Price":
                    allProducts = allProducts.OrderBy(s => s.price).ToList();
                    break;
                case "price_desc":
                    allProducts = allProducts.OrderByDescending(s => s.price).ToList();
                    break;
                case "Producer":
                    allProducts = allProducts.OrderBy(s => s.producer).ToList();
                    break;
                case "producer_desc":
                    allProducts = allProducts.OrderByDescending(s => s.producer).ToList();
                    break;
                case "Volume":
                    allProducts = allProducts.OrderBy(s => s.volum).ToList();
                    break;
                case "volume_desc":
                    allProducts = allProducts.OrderByDescending(s => s.volum).ToList();
                    break;
                default:
                    allProducts = allProducts.OrderBy(s => s.itemnumber).ToList();
                    break;
            }


            ViewBag.CurrentItemsPerPage = itemsPerPage; 

            List<ProductInfo> list = new List<ProductInfo>();
            foreach (var item in allProducts)
            {
                list.Add(
                    new ProductInfo()
                    {
                        itemnumber = item.itemnumber,
                        name = item.name,
                        description = item.description,
                        category = item.category,
                        subCategory = item.subCategory,
                        country = item.country,
                        price = item.price,
                        producer = item.producer,
                        volum = item.volum,
                        longDescription = item.longDescription,
                        pricePerLitre = item.pricePerLitre
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

      
        public ActionResult ProductDetails(int id)
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            Product productDetails = _product.seeDetails(id);
            
            List<GroupedSelectListItem> dropdownsubcategory2 = new List<GroupedSelectListItem>();
            var dropdownsubcategory1 = _product.getAllSubCategories();
            foreach (var item in dropdownsubcategory1)
            {
                if(item.ID == productDetails.subCategoryid)
                {
                    dropdownsubcategory2.Add(new GroupedSelectListItem()
                    {
                        GroupKey = item.catId.ToString(),
                        GroupName = item.catName,
                        Text = item.name,
                        Value = item.ID.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    dropdownsubcategory2.Add(new GroupedSelectListItem()
                    {
                        GroupKey = item.catId.ToString(),
                        GroupName = item.catName,
                        Text = item.name,
                        Value = item.ID.ToString()
                    });
                }
            }

            IEnumerable<GroupedSelectListItem> dropdownsubcategory = dropdownsubcategory2; 
            ProductDetail prodinfo = new ProductDetail()
            {
                itemnumber = productDetails.itemnumber,
                name = productDetails.name,
                description = productDetails.description,
                longDescription = productDetails.longDescription,
                price = productDetails.price,
                volum = productDetails.volum,
                countryid = productDetails.countryid,
                producerid = productDetails.producerid,
                pricePerLitre = productDetails.pricePerLitre,
                subCategoryList = dropdownsubcategory,
                countryList = _product.getCountries().Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.name}).ToList(),
                producerList = _product.getProducers().Select(p => new SelectListItem { Value = p.id.ToString(), Text = p.name}).ToList()
            };
            return View(prodinfo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDetails(int id,ProductDetail p)
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            if (ModelState.IsValid)
            {
                Product updated = new Product()
                {
                    itemnumber = p.itemnumber,
                    name = p.name,
                    description = p.description,
                    longDescription = p.longDescription,
                    price = p.price,
                    countryid = p.countryid,
                    subCategoryid = p.subCategoryid,
                    volum = p.volum,
                    producerid = p.producerid
                };
                Customer admin = (Customer)Session["loggedInUser"];
                var adminid = admin.id;
                bool result = _product.updateProduct(adminid, updated);
                
                List<GroupedSelectListItem> test2 = new List<GroupedSelectListItem>();
                var test1 = _product.getAllSubCategories();
                foreach (var item in test1)
                {
                    if (item.ID == p.subCategoryid)
                    {
                        test2.Add(new GroupedSelectListItem()
                        {
                            GroupKey = item.catId.ToString(),
                            GroupName = item.catName,
                            Text = item.name,
                            Value = item.ID.ToString(),
                            Selected = true
                        });
                    }
                    else
                    {
                        test2.Add(new GroupedSelectListItem()
                        {
                            GroupKey = item.catId.ToString(),
                            GroupName = item.catName,
                            Text = item.name,
                            Value = item.ID.ToString()
                        });
                    }
                }

                IEnumerable<GroupedSelectListItem> test = test2;
                p.countryList = _product.getCountries().Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.name }).ToList();
                p.subCategoryList = test;
                p.producerList = _product.getProducers().Select(r => new SelectListItem { Value = r.id.ToString(), Text = r.name }).ToList();

                if (result)
                    return Json(new { success = true, message = "Endringene ble lagret", redirect = "/Product/ListProducts/" });
                return Json(new { success = false, message = "Noe gikk galt, prøv igjen" });
            }
            return Json(new { success = false, message = "Feil i validering" });

        }

        public ActionResult addProduct()
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            var placeholder = new ProductDetail()
            {
                countryList = _product.getCountries().Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.name }).ToList(),
                subCategoryList = _product.getAllSubCategories().Select(s => new GroupedSelectListItem { GroupKey = s.catId.ToString(), GroupName = s.catName, Value = s.ID.ToString(), Text = s.name }).ToList(),
                producerList = _product.getProducers().Select(r => new SelectListItem { Value = r.id.ToString(), Text = r.name }).ToList()
            };
            return View(placeholder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addProduct(ProductDetail p)
        {
            if (!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            if(ModelState.IsValid)
            {
                Customer admin = (Customer)Session["loggedInUser"];
                var adminid = admin.id;
                var result = _product.addProduct(adminid, new Product()
                {
                    name = p.name,
                    countryid = p.countryid,
                    description = p.description,
                    longDescription = p.longDescription,
                    price = p.price,
                    producerid = p.producerid,
                    subCategoryid = p.subCategoryid,
                    volum = p.volum
                }); 

                        
                p.countryList = _product.getCountries().Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.name }).ToList();
                p.subCategoryList = _product.getAllSubCategories().Select(s => new GroupedSelectListItem { GroupKey = s.catId.ToString(), GroupName = s.catName, Value = s.ID.ToString(), Text = s.name,Selected=true }).ToList();
                p.producerList = _product.getProducers().Select(r => new SelectListItem { Value = r.id.ToString(), Text = r.name }).ToList();

                if (result != null)
                    return Json(new { success = true, message = result.name + " ble lagt til med varenummer " + result.itemnumber, redirect = "/Product/ListProducts/?sortOrder=item_desc" });
                return Json(new { success = false, message = "Noe gikk galt, prøv igjen senere" });
            }
            return Json(new { success = false, message = "Feil i validering" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult deleteProduct(int id)
        {
            if(!isAdmin())
            {
                return RedirectToAction("LogIn", "Main");
            }
            Customer admin = (Customer)Session["loggedInUser"];
            var result = _product.deleteProduct(id, admin.id);

            if (result)
                return Json(new { success = true, message = "Produktet ble slettet", redirect = "/Product/ListProducts/" });
            return Json(new { success = false, message = "Noe gikk galt, produktet ble ikke slettet, prøv igjen senere" }); 
        }
    }
}