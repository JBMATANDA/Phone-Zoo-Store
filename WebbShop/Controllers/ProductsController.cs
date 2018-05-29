using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using WebbShop.Models.DataContexts.Cart;
using WebbShop.Models.DataContexts.Product;
using WebbShop.Models.Entities;

namespace WebbShop.Controllers
{
    public class ProductsController : Controller
    {
       private ProductContext db = new ProductContext();
       private CartContext cartDb = new CartContext();

        // GET: Products
        public ActionResult Products()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Cart()
        {
            return View();
        }
        public double GetTotalPrice()
        {
            var session = HttpContext.Session;

            if (session["Cart"] == null)
            {
                return 0;
            }
            List<CartItem> cartList = (List<CartItem>)Session["Cart"]; 

            double totalPrice = 0;
            foreach (var item in cartList)
            {
                
                totalPrice += (item.Quantity * item.Product.Price);
            }
            return totalPrice;
        }

        public ActionResult AddToCart(int id)
        {

            var session = HttpContext.Session;
            if (session["Cart"] == null)
            {
                Session["Cart"] = new List<CartItem>();
            }

            List<CartItem> cartList = (List<CartItem>) Session["Cart"];

            foreach (var product in cartList)
            {
                if (product.Product.ArticleID == id)
                {
                    product.Quantity++;
                }
            }
            var item = from p in db.Products
                where p.ArticleID == id
                select p;
            CartItem cartItem = new CartItem
            {
                Product = item.First()
            };

            if (cartItem.Product.Stock > 0 && cartList.Count() == 0)
            {
                cartList.Add(cartItem);
            }
            //Product product = db.Products.First(p=> p.ArticleID == id);
            // var cartItem = cartDb.CartItems.FirstOrDefault();

            // //If cartitem does not exist then create it and add it to the list
            // if (cartItem == null)
            // {
            //     cartItem = new CartItem
            //     {
            //         Product = product,
            //         Quantity = 1
            //     };
            //     cartDb.CartItems.Add(cartItem);
            // }
            //if it exists then increase quantity
            // else
            // {
            //     cartItem.Quantity++;
            // }
            db.SaveChanges();
            
            return RedirectToAction("Cart");
        }

       
        public ActionResult RemoveFromCart(int id)
        {
            var session = HttpContext.Session;


            if (session["Cart"] == null || id == 0)
            {
                return RedirectToAction("Products");

            }

            CartItem cartItem = new CartItem(); 

            List<CartItem> cartList = (List<CartItem>)Session["Cart"];
            foreach (var item in cartList)
            {
                if (item.Product.ArticleID == id)
                {
                    if (item.Quantity == 1)
                    {
                        cartList.Remove(item);
                    }
                    item.Quantity--;
                    item.Product.Stock = item.Product.Stock + item.Quantity;

                    return RedirectToAction("Cart", new {id});
                }
            }
            return RedirectToAction("Cart");
        }

        public int GetCartSize()
        {
            var session = HttpContext.Session;

            if (session["Cart"] == null)
            {
                //Session["Cart"] = new List<ShoppingCart>();
                return 0;
            }
            List<CartItem> cartList = (List<CartItem>)Session["Cart"]; // we get the shoppinglist
            int i = 0;
            foreach (var item in cartList)
            {
                i += item.Quantity;
            }
            return i;
        }

       

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewData["Product"] = product;
            }
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleID,Image,ArticleName,Description,Price,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleID,Image,ArticleName,Description,Price,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
