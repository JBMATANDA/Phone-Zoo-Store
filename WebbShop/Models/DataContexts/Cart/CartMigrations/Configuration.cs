namespace WebbShop.Models.DataContexts.Cart.CartMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebbShop.Models.DataContexts.Cart.CartContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Models\DataContexts\Cart\CartMigrations";
            ContextKey = "WebbShop.Models.DataContexts.CartContext";
        }

        protected override void Seed(WebbShop.Models.DataContexts.Cart.CartContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
