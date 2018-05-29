namespace WebbShop.Models.DataContexts.Cart.CartMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "product_ArticleID", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "product_ArticleID" });
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_ArticleID = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Products", t => t.Product_ArticleID)
                .Index(t => t.Product_ArticleID);
            
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        product_ArticleID = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            DropForeignKey("dbo.CartItems", "Product_ArticleID", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "Product_ArticleID" });
            DropTable("dbo.CartItems");
            CreateIndex("dbo.CartItems", "product_ArticleID");
            AddForeignKey("dbo.CartItems", "product_ArticleID", "dbo.Products", "ArticleID");
        }
    }
}
