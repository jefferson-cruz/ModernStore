namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "User_Login", c => c.String());
            AddColumn("dbo.Customer", "User_Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "User_UserPassword_Password", c => c.String());
            AddColumn("dbo.Customer", "User_UserPassword_Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "User_UserPassword_Salt");
            DropColumn("dbo.Customer", "User_UserPassword_Password");
            DropColumn("dbo.Customer", "User_Active");
            DropColumn("dbo.Customer", "User_Login");
        }
    }
}
