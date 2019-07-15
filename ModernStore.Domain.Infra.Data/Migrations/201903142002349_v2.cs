namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "User_ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "User_ConfirmPassword", c => c.String());
        }
    }
}
