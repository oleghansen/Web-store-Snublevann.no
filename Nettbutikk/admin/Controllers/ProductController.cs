﻿using Nettbutikk.admin.Models;
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
        
        public ActionResult ListProducts(int? page)
        {

            ProductMenu returnValue = new ProductMenu(); 
            if (!isAdmin())
                return RedirectToAction("Main", "Main");

            int pageNumber = page ?? 1;
            int itemsPerPage = 25;

            List<Product> allProducts = _product.getAll(null);

            List<ProductInfo> list = new List<ProductInfo>();
            foreach(var item in allProducts)
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
            returnValue.productInfo = list;

            returnValue.categories = new List<CategoryViewModel>();
            List<Category> allCategories = _product.getAllCategories(); 
            foreach(var c in allCategories)
            {
                returnValue.categories.Add(new CategoryViewModel()
                {
                    SelectedCategoryId = c.ID,
                    CategoriesName = c.name
                });
            }

            return View( list.ToPagedList(pageNumber, itemsPerPage));
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
            return View(productDetails);
               
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
    }
}