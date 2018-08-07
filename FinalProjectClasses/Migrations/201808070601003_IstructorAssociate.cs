namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IstructorAssociate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instructers", "Member_Id", "dbo.Members");
            DropIndex("dbo.Instructers", new[] { "Member_Id" });
            AddColumn("dbo.Members", "Instructer_Id", c => c.Int());
            CreateIndex("dbo.Members", "Instructer_Id");
            AddForeignKey("dbo.Members", "Instructer_Id", "dbo.Instructers", "Id");
            DropColumn("dbo.Instructers", "Member_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructers", "Member_Id", c => c.Int());
            DropForeignKey("dbo.Members", "Instructer_Id", "dbo.Instructers");
            DropIndex("dbo.Members", new[] { "Instructer_Id" });
            DropColumn("dbo.Members", "Instructer_Id");
            CreateIndex("dbo.Instructers", "Member_Id");
            AddForeignKey("dbo.Instructers", "Member_Id", "dbo.Members", "Id");
        }
    }
}
