namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCryptoPassword", "Salt", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCryptoPassword", "Salt", c => c.String(maxLength: 200));
        }
    }
}
