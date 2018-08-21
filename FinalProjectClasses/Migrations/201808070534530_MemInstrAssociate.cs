namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemInstrAssociate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructers", "Member_Id", c => c.Int());
            CreateIndex("dbo.Instructers", "Member_Id");
            AddForeignKey("dbo.Instructers", "Member_Id", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructers", "Member_Id", "dbo.Members");
            DropIndex("dbo.Instructers", new[] { "Member_Id" });
            DropColumn("dbo.Instructers", "Member_Id");
        }
    }
}
