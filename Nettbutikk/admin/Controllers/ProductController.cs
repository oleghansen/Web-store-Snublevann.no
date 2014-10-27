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
                return RedirectToAction("Main", "Main"); 
            return View();
        }
        
        public ActionResult ListProducts(int? page, int? itemsPerPage, string sortOrder)
        {
            if (!isAdmin())
                return RedirectToAction("Main", "Main");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ItemSortParm = String.IsNullOrEmpty(sortOrder) ? "item_desc" : ""; 
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.ProducerSortParm = sortOrder == "Producer" ? "producer_desc" : "Producer";
            var allProducts = _product.getAll(null);

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


            return View(list.ToPagedList(pageNumber: page ?? 1, pageSize: itemsPerPage ?? 10));
        }
      
        public ActionResult Search(int? page, string searchString)
        {
            ProductMenu returnValue = new ProductMenu();
            if (!isAdmin())
                return RedirectToAction("Main", "Main");

            int pageNumber = page ?? 1;
            int itemsPerPage = 25;
            List<Product> allProducts = _product.getResult(page, searchString);
            List<ProductInfo> list = new List<ProductInfo>();
           
            foreach (var item in allProducts)
            {
                if (item.name.ToUpper().Contains(searchString.ToUpper()) || item.description.ToUpper().Contains(searchString.ToUpper()))
                {
                    ProductInfo produkt = new ProductInfo()
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
                    };

                    list.Add(produkt);
                }
            }
            returnValue.productInfo = list;

            returnValue.categories = new List<CategoryViewModel>();
            List<Category> allCategories = _product.getAllCategories();
            foreach (var c in allCategories)
            {
                returnValue.categories.Add(new CategoryViewModel()
                {
                    SelectedCategoryId = c.ID,
                    CategoriesName = c.name
                });
            }

            return View(list.ToPagedList(pageNumber, itemsPerPage));
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
                return RedirectToAction("Main", "Main");
            }
            Product productDetails = _product.seeDetails(id);

            ProductInfo pif = new ProductInfo()
            {
                itemnumber = productDetails.itemnumber,
                name = productDetails.name,
                description = productDetails.description,
                longDescription = productDetails.longDescription,
                price = productDetails.price,
                volum = productDetails.volum,
                country = productDetails.country,
                quantity = productDetails.quantity,
                producer = productDetails.producer,
                pricePerLitre = productDetails.pricePerLitre,
            };
            return View(pif);
        }



        public ActionResult Updated(int id, Product p)
        {
            if (!isAdmin())
            {
                return RedirectToAction("Main", "Main");
            }
            bool updated = _product.updateProduct(id, p);
            return View(updated);

        }

        public JsonResult getResults(string term)
        {
            List<string> foundProducts = _product.getAutoComplete(term);
            return Json(foundProducts, JsonRequestBehavior.AllowGet);
        }
    }
}