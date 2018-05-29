using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebbShop.Models.Entities;

namespace WebbShop.Models.DataContexts.OrderInfo
{
    public class OrderInfoContext : DbContext
    {
        public OrderInfoContext() : base("DefaultConnection") { }

        public DbSet<Entities.OrderInfo> Orders { get; set; }
    }
}