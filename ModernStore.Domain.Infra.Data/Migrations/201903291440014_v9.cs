namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "User_UserPassword_Password", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Customer", "User_UserPassword_Salt", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "User_UserPassword_Salt", c => c.String());
            AlterColumn("dbo.Customer", "User_UserPassword_Password", c => c.String());
        }
    }
}
