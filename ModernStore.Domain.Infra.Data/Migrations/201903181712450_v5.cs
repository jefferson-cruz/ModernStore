namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "BirthDate", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "BirthDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}