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
            List<ShoppingCartItem> list = getCart();
            if (list != null)
                return View(list);
            else
               return RedirectToAction("Main", "Frontpage");
            
        }

        public ActionResult addToCart(Product p, int qty)
        {
            List<ShoppingCartItem> list = getCart();
            ShoppingCartItem item = new ShoppingCartItem(p, qty);
            list.Add(item);

            //TODO hva skal returneres hvor her?
            return View(true); 
        }

        private List<ShoppingCartItem> getCart()
        {
            if(!Session["loggedInUser"].Equals(null))
            {
                Customer c = (Customer)Session["loggedInUser"];
                List<ShoppingCartItem> list = c.shoppingcart.shoppingCartItems;
                return list; 
            }
            return null; 
        }
    }
}