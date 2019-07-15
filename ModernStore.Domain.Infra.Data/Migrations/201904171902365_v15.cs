namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Password_Value", c => c.String(maxLength: 250));
            AddColumn("dbo.User", "Password_Salt", c => c.String(maxLength: 250));
            DropColumn("dbo.User", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Password", c => c.String(maxLength: 250));
            DropColumn("dbo.User", "Password_Salt");
            DropColumn("dbo.User", "Password_Value");
        }
    }
}
