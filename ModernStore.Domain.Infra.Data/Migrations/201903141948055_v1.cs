namespace ModernStore.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name_FirstName = c.String(),
                    Name_LastName = c.String(),
                    Email_Address = c.String(),
                    BirthDate = c.DateTime(),
                    Document_Number = c.String(),
                    User_Login = c.String(),
                    User_Password = c.String(),
                    User_ConfirmPassword = c.String(),
                    User_Active = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
