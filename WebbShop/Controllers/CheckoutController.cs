using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebbShop.Models.DataContexts.OrderInfo;
using WebbShop.Models.DataContexts.Product;
using WebbShop.Models.Entities;

namespace WebbShop.Controllers
{
    public class CheckoutController : Controller
    {
        private OrderInfoContext db = new OrderInfoContext();
        private ProductContext prodDB = new ProductContext();

        // GET: OrderInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckoutComplete()
        {
         //  db.Orders.Add(order);
            return View();
        }
        public ActionResult EmptyCart()
        {

            var session = HttpContext.Session;


            if (session["Cart"] == null)
            {
                return RedirectToAction("Products", "Products");
            }

            List<CartItem> cartList = (List<CartItem>) Session["Cart"];

            foreach (var item in cartList)
            {
                int id = item.Product.ArticleID;
                var query =
                    from p in prodDB.Products
                    where p.ArticleID == id
                    select p;
                foreach (Product product in query)
                {
                   product.Stock--;
                }
            }
            prodDB.SaveChanges();
            cartList.Clear();
          
            return RedirectToAction("Index", "Home");
        }

        // GET: OrderInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.Orders.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        public ActionResult Create()
        {
            return View();
        }
        // GET: OrderInfo/Create
        public ActionResult Checkout(FormCollection collection)
        {
            var order = new OrderInfo();
            TryUpdateModel(order);
            db.SaveChanges();
            return View();
        }

        
        // POST: OrderInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "OrderID,Firstname,Lastname,PostCode,City,Email,Phonenumber")] OrderInfo orderInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(orderInfo);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
              
            }
            return View(orderInfo);
        }

    

    // GET: OrderInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.Orders.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: OrderInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,Firstname,Lastname,PostCode,City,Email,Phonenumber")] OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderInfo);
        }

        // GET: OrderInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInfo orderInfo = db.Orders.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: OrderInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderInfo orderInfo = db.Orders.Find(id);
            db.Orders.Remove(orderInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
