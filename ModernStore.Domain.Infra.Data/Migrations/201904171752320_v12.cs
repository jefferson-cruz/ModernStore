namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "CustomerId", c => c.Guid(nullable: false));
        }
    }
}
