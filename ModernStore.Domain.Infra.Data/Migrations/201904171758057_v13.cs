namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Email_Address", c => c.String(maxLength: 200));
            DropColumn("dbo.User", "Username_Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Username_Address", c => c.String(maxLength: 200));
            DropColumn("dbo.User", "Email_Address");
        }
    }
}
