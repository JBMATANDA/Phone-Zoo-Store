namespace WebbShop.Models.DataContexts.CustomerInfo.CustomerInfoMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebbShop.Models.DataContexts.OrderInfo.OrderInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Models\DataContexts\CustomerInfo\CustomerInfoMigrations";
        }

        protected override void Seed(WebbShop.Models.DataContexts.OrderInfo.OrderInfoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
