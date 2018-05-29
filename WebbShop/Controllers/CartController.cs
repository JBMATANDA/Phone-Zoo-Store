using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbShop.Models.DataContexts.Cart;

namespace WebbShop.Controllers
{
    public class CartController : Controller
    {
        CartContext cartDB = new CartContext();
        // GET: Cart
        public ActionResult ShoppingCart()
        {          

            return View(cartDB.CartItems.ToList());
        }
    }
}