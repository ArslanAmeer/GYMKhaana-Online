namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateattandance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attandances", "Member_Id", c => c.Int());
            CreateIndex("dbo.Attandances", "Member_Id");
            AddForeignKey("dbo.Attandances", "Member_Id", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attandances", "Member_Id", "dbo.Members");
            DropIndex("dbo.Attandances", new[] { "Member_Id" });
            DropColumn("dbo.Attandances", "Member_Id");
        }
    }
}
