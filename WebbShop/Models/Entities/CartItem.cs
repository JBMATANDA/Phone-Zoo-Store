using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebbShop.Models.DataContexts.Product;

namespace WebbShop.Models.Entities
{
    public class CartItem
    {
        [Key]
        public int ArticleId { get; set; }

        private readonly ProductContext _context = new ProductContext();
        private int _quantity = 1;
        public Product Product { get; set; }

        public int Quantity
        {
            get { return _quantity; }
            set
            {

                var stock = from p in _context.Products
                    where p.ArticleID == Product.ArticleID
                    select p.Stock;

                int remaining = stock.First();

                if (remaining - (value) >= 0)
                {
                    this._quantity = value;
                }
            }
        }

        public CartItem()
        {
            
        }
        public CartItem(Product Product)
        {
            this.Product = Product;
        }
    }
}
    
