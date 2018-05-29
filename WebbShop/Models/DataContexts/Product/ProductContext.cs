using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebbShop.Models.Entities;

namespace WebbShop.Models.DataContexts.Product
{
    public class ProductContext :DbContext
    {
        public ProductContext() : base("DefaultConnection") { }

        public DbSet<Entities.Product> Products { get; set; }
       
    }
}