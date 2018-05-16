namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Loginid = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        ImageUrl = c.String(),
                        Email = c.String(),
                        Cnic = c.Long(nullable: false),
                        Shift = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        MobileNo = c.Long(nullable: false),
                        FullAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
