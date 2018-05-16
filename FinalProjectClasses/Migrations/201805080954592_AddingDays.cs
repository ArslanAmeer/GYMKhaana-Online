namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "AddDays", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "AddDays");
        }
    }
}
