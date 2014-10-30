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

        // GET: Product
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

            var test = _product.getAllSubCategories().Select(t => new GroupedSelectListItem
            {
                GroupKey = t.catId.ToString(),
                GroupName = t.catName,
                Text = t.name,
                Value = t.ID.ToString()
            });
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
                //subCategoryList = _product.getAllSubCategories().Select(s => new SelectListItem { Value = s.ID.ToString(), Text = s.name}).ToList(),
                subCategoryList = test,
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
            bool result = _product.updateProduct(adminid,updated);
            p.countryList = _product.getCountries().Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.name }).ToList();
            p.subCategoryList = _product.getAllSubCategories().Select(s => new GroupedSelectListItem { GroupKey = s.catId.ToString(), GroupName = s.catName, Value = s.ID.ToString(), Text = s.name }).ToList();
            p.producerList = _product.getProducers().Select(r => new SelectListItem { Value = r.id.ToString(), Text = r.name }).ToList();

            if (result)
                ViewBag.result = true;
            return View(p);

        }

        public JsonResult getResults(string term)
        {
            List<string> foundProducts = _product.getAutoComplete(term);
            return Json(foundProducts, JsonRequestBehavior.AllowGet);
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
            Customer admin = (Customer)Session["loggedInUser"];
            var adminid = admin.id;
            if (_product.addProduct(adminid, new Product()
            {
                name = p.name,
                countryid = p.countryid,
                description = p.description,
                longDescription = p.longDescription,
                price = p.price,
                producerid = p.producerid,
                subCategoryid = p.subCategoryid,
                volum = p.volum
            }))
                return RedirectToAction("ListProducts");
            
            p.countryList = _product.getCountries().Select(c => new SelectListItem { Value = c.id.ToString(), Text = c.name }).ToList();
            p.subCategoryList = _product.getAllSubCategories().Select(s => new GroupedSelectListItem { GroupKey = s.catId.ToString(), GroupName = s.catName, Value = s.ID.ToString(), Text = s.name }).ToList();
            p.producerList = _product.getProducers().Select(r => new SelectListItem { Value = r.id.ToString(), Text = r.name }).ToList();

            return View(p); 
            
        }
    }
}