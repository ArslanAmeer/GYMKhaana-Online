namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInstructerTbale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Experience = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        FullAddress = c.String(nullable: false),
                        PhoneNo = c.Long(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        Achivements = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instructers");
        }
    }
}
