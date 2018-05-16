namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalFee = c.Single(nullable: false),
                        Fee = c.Single(nullable: false),
                        SubmissionDate = c.DateTime(nullable: false),
                        CurrentDate = c.DateTime(nullable: false),
                        RollNo = c.Int(nullable: false),
                        SubmitTo = c.String(nullable: false),
                        Gender_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Members", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Members", new[] { "User_Id" });
            DropIndex("dbo.Members", new[] { "Gender_Id" });
            DropTable("dbo.Members");
        }
    }
}
