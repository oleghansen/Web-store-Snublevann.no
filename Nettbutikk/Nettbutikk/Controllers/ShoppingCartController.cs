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
            if (Session["LoggedInUser"])
            {
                Customer c = (Customer)Session["LoggedInUser"];
                List<ShoppingCartItem> l = c.shoppingcart.shoppingCartItems;
                return View(l);
            }
            else
                Redirect
        }
    }
}