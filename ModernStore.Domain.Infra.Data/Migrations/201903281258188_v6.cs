namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "User_Login");
            DropColumn("dbo.Customer", "User_Password");
            DropColumn("dbo.Customer", "User_Active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "User_Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "User_Password", c => c.String());
            AddColumn("dbo.Customer", "User_Login", c => c.String());
        }
    }
}
