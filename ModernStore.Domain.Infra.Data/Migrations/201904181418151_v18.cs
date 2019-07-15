namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCryptoPassword",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Salt = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.User", "Password_Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Password_Salt", c => c.String(maxLength: 250));
            DropForeignKey("dbo.UserCryptoPassword", "Id", "dbo.User");
            DropIndex("dbo.UserCryptoPassword", new[] { "Id" });
            DropTable("dbo.UserCryptoPassword");
        }
    }
}
