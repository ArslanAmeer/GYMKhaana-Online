namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUsertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "User_Id", "dbo.Users");
            DropIndex("dbo.Members", new[] { "User_Id" });
            AddColumn("dbo.Members", "FullName", c => c.String());
            AddColumn("dbo.Members", "CNIC", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "MobileNo", c => c.Long(nullable: false));
            AddColumn("dbo.Members", "FullAddress", c => c.String());
            AddColumn("dbo.Members", "DateofBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Members", "ImageUrl", c => c.String());
            DropColumn("dbo.Members", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "User_Id", c => c.Int());
            DropColumn("dbo.Members", "ImageUrl");
            DropColumn("dbo.Members", "DateofBirth");
            DropColumn("dbo.Members", "FullAddress");
            DropColumn("dbo.Members", "MobileNo");
            DropColumn("dbo.Members", "CNIC");
            DropColumn("dbo.Members", "FullName");
            CreateIndex("dbo.Members", "User_Id");
            AddForeignKey("dbo.Members", "User_Id", "dbo.Users", "Id");
        }
    }
}
