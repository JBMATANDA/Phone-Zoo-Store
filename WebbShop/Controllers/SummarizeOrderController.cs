using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbShop.Models.DataContexts.OrderInfo;
using WebbShop.Models.DataContexts.Product;
using WebbShop.Models.Entities;

namespace WebbShop.Controllers
{
    [Authorize]
    public class SummarizeOrderController : Controller
    {
        OrderInfoContext order = new OrderInfoContext();
        ProductContext prodDB = new ProductContext();
        private List<CartItem> cartList;
       
        // GET: SummarizeOrder
        public ActionResult SummerizeOrder()
        {
            List<CartItem> cartList = (List<CartItem>) Session["Cart"];
            return View(cartList.ToList());
        }
    }
}