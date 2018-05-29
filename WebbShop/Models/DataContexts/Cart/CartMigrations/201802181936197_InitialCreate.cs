namespace WebbShop.Models.DataContexts.Cart.CartMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        product_ArticleID = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Products", t => t.product_ArticleID)
                .Index(t => t.product_ArticleID);
            
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
            DropForeignKey("dbo.CartItems", "product_ArticleID", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "product_ArticleID" });
            DropTable("dbo.Products");
            DropTable("dbo.CartItems");
        }
    }
}
