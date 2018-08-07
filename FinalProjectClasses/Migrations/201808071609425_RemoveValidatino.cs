namespace FinalProjectClasses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveValidatino : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructers", "Name", c => c.String());
            AlterColumn("dbo.Instructers", "Experience", c => c.String());
            AlterColumn("dbo.Instructers", "FullAddress", c => c.String());
            AlterColumn("dbo.Instructers", "ImageUrl", c => c.String());
            AlterColumn("dbo.Instructers", "Achivements", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Instructers", "Achivements", c => c.String(nullable: false));
            AlterColumn("dbo.Instructers", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Instructers", "FullAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Instructers", "Experience", c => c.String(nullable: false));
            AlterColumn("dbo.Instructers", "Name", c => c.String(nullable: false));
        }
    }
}
