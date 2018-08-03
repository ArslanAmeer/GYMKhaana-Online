namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "TotalPaidAmount", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "TotalPaidAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "TotalPaidAmount", c => c.Int(nullable: false));
            DropColumn("dbo.Members", "TotalPaidAmount");
        }
    }
}
