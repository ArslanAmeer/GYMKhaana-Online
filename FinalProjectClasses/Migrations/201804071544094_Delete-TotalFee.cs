namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTotalFee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "TotalFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "TotalFee", c => c.Single(nullable: false));
        }
    }
}
