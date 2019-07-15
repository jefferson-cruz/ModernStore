namespace ModernStore.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "Email_Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Email_Address", c => c.String(maxLength: 200));
        }
    }
}
