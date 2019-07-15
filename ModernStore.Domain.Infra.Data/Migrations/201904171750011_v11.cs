namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.User", name: "Username", newName: "Username_Address");
            AddColumn("dbo.User", "CustomerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "CustomerId");
            RenameColumn(table: "dbo.User", name: "Username_Address", newName: "Username");
        }
    }
}
