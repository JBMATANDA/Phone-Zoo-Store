using Microsoft.AspNet.Identity;

namespace WebbShop.Models.DataContexts.Product.ProductMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebbShop.Models.DataContexts.Product.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Models\DataContexts\Product\ProductMigrations";
        }

        protected override void Seed(WebbShop.Models.DataContexts.Product.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate(
                p => p.ArticleID, new Entities.Product()
                {
                    ArticleID = 1,
                    ArticleName = "IPhone X",
                    Description = "Experience incredible iPhone X with edge-to-edge 5.8 " +
                                  "Super Retina screen and a host of incredible features such as" +
                                  " Face ID face lock, personal animojis and more ..",

                    Image = "Iphone X.jpg",
                    Price = 11000,
                    Stock = 10
                },
                new Entities.Product()
                {
                    ArticleID = 2,
                    ArticleName = "Samsung Galaxy S8+",
                    Image = "Samsung S8.jpg",
                    Price = 8599.99,
                    Description =
                        "Samsung S8 takes classic Samsung reliability to the next " +
                        "level with even more clever and innovative technology.",
                    Stock = 5
                },
                new Entities.Product()
                {
                    ArticleID = 3,
                    ArticleName = "LG V30",
                    Image = "LG V30.jpg",
                    Price = 8999.79,
                    Description = "Smooth and water resistant LG V30 smartphone comes with a slight" +
                                  " vaulted glass and full of technology. The phone comes with" +
                                  " an octa-core Qualcom Snapdragon processor and 4GB of RAM for" +
                                  " good flow and high performance.",
                    Stock = 1
                },
                new Entities.Product()
                {
                    ArticleID = 4,
                    ArticleName = "Huawei Mate Pro 10",
                    Image = "Huwaei.jpg",
                    Description = "The Huawei Mate 10 Pro smartphone features an elegant design that hovers with power inside. " +
                                  "Double lenses with f / 1.6 aperture, bright and almost borderless 6 OLED display " +
                                  "along with Kirin 970 chip make this a flagship of a phone.",
                    Price = 7489.00,
                    Stock = 7
                },
                new Entities.Product()
                {
                    ArticleID = 5,
                    ArticleName = "Nokia 3310",
                    Image = "Nokia 3310.png",
                    Description = "LEGENDARY!! Made of the most durable material on earth.",
                    Price = 1000000.99,
                    Stock = 0
                },
                new Entities.Product()
                {
                    ArticleID = 6,
                    ArticleName = "IPhone 8(Rosé Gold)",
                    Image = "Iphone 7(rosa).jpg",
                    Description = "Discover the world around you in a brand new way through the iPhone 7, " +
                                  "equipped with an amazing MP camera for exceptional " +
                                  "photo quality, powerful A10 Fusion chip, better battery " +
                                  "capacity and water resistant design.",
                    Price = 6999,
                    Stock = 10
                }
                
            );
        }
    }
}
