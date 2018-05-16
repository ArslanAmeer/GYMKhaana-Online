namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssociateMemberwithPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Members_Id", c => c.Int());
            CreateIndex("dbo.Members", "Members_Id");
            AddForeignKey("dbo.Members", "Members_Id", "dbo.Members", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Members_Id", "dbo.Members");
            DropIndex("dbo.Members", new[] { "Members_Id" });
            DropColumn("dbo.Members", "Members_Id");
        }
    }
}
