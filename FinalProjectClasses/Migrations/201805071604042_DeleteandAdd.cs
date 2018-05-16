namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteandAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Members_Id", "dbo.Members");
            DropIndex("dbo.Members", new[] { "Members_Id" });
            AddColumn("dbo.Payments", "Member_Id", c => c.Int());
            CreateIndex("dbo.Payments", "Member_Id");
            AddForeignKey("dbo.Payments", "Member_Id", "dbo.Members", "Id");
            DropColumn("dbo.Members", "Members_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Members_Id", c => c.Int());
            DropForeignKey("dbo.Payments", "Member_Id", "dbo.Members");
            DropIndex("dbo.Payments", new[] { "Member_Id" });
            DropColumn("dbo.Payments", "Member_Id");
            CreateIndex("dbo.Members", "Members_Id");
            AddForeignKey("dbo.Members", "Members_Id", "dbo.Members", "Id");
        }
    }
}
