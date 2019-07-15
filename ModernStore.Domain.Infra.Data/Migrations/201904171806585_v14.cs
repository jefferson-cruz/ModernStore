namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Salt", c => c.String(maxLength: 250));
        }
    }
}
