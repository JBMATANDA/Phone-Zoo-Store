namespace WebbShop.Models.DataContexts.OrderDetailsMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebbShop.Models.DataContexts.OrderDetailsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Models\DataContexts\OrderDetailsMigrations";
        }

        protected override void Seed(WebbShop.Models.DataContexts.OrderDetailsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
