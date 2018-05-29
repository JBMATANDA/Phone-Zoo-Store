using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebbShop.Models.Entities;

namespace WebbShop.Models.DataContexts.Cart
{
    public class CartContext : DbContext 
    {
        public DbSet<CartItem> CartItems { get; set; }
    }
}