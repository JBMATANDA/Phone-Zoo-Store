using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebbShop.Models.Entities;

namespace WebbShop.Models.DataContexts
{
    public class OrderDetailsContext:DbContext
    {
        public OrderDetailsContext() : base("DefaultConnection")
        { 

        }
        public DbSet<OrderDetails> OrderDetail { get; set; }

        public System.Data.Entity.DbSet<WebbShop.Models.Entities.OrderInfo> OrderInfoes { get; set; }
    }
}