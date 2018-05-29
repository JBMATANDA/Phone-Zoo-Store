namespace WebbShop.Models.DataContexts.Product.ProductMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        ArticleName = c.String(),
                        Description = c.String(maxLength: 250),
                        Price = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
