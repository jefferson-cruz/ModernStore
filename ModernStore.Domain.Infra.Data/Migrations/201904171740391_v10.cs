namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(maxLength: 200),
                        Password = c.String(maxLength: 250),
                        Salt = c.String(maxLength: 250),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Customer", "Email_Address", c => c.String(maxLength: 200));
            DropColumn("dbo.Customer", "User_Login");
            DropColumn("dbo.Customer", "User_Active");
            DropColumn("dbo.Customer", "User_UserPassword_Password");
            DropColumn("dbo.Customer", "User_UserPassword_Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "User_UserPassword_Salt", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Customer", "User_UserPassword_Password", c => c.String(maxLength: 8000, unicode: false));
            AddColumn("dbo.Customer", "User_Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "User_Login", c => c.String());
            DropForeignKey("dbo.User", "Id", "dbo.Customer");
            DropIndex("dbo.User", new[] { "Id" });
            AlterColumn("dbo.Customer", "Email_Address", c => c.String());
            DropTable("dbo.User");
        }
    }
}
