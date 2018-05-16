namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddVideoImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ImageUrl = c.String(),
                    Text = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Videos",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    VideoUrl = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Videos");
            DropTable("dbo.Images");
        }
    }
}
