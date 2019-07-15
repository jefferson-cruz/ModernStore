namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Guid(),
                        Order_Number = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .ForeignKey("dbo.Order", t => t.Order_Number, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Number);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantityOnHand = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        DeliveryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Customer", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "Order_Number", "dbo.Order");
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product");
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropIndex("dbo.OrderItem", new[] { "Order_Number" });
            DropIndex("dbo.OrderItem", new[] { "Product_Id" });
            DropTable("dbo.Order");
            DropTable("dbo.Product");
            DropTable("dbo.OrderItem");
        }
    }
}
