using Nettbutikk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nettbutikk.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult viewShoppingCart()
        {
            ShoppingCart cart = getCart();
            if (cart != null)
                return View(cart);
            else
                return RedirectToAction("Frontpage", "Main");

        }
        [HttpPost]
        public ActionResult addToCart(int quantity, int itemnumber)
        {
            var db = new DBProduct();
            Product p = db.get(itemnumber);
            ShoppingCart cart = getCart();
            ShoppingCartItem item = new ShoppingCartItem(p, quantity);
            List<ShoppingCartItem> list = cart.shoppingCartItems;
            cart.sum += p.price * quantity;
            list.Add(item);


            //TODO hva skal returneres hvor her?
            return RedirectToAction("viewShoppingCart");
        }

        private ShoppingCart getCart()
        {
            if (Session["loggedInUser"] != null)
            {
                Customer c = (Customer)Session["loggedInUser"];
                ShoppingCart cart = c.shoppingcart;
                return cart;
            }
            return null;
        }

        public ActionResult checkout()
        {
            ShoppingCart cart = getCart();
            if (cart == null)
            {
                ViewBag.Empty = true;
                return View();
            }

            var orderDB = new DBOrder();
            orderDB.checkout(cart);
            return View(); 

        }
    }
}