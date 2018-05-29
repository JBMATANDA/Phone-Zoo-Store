using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbShop.Models.Entities
{
    public class Product
    {
        [Key]
        public int ArticleID { get; set; }
        public string Image { get; set; }
        public string ArticleName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
       
    }
}