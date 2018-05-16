namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attDDLL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attandances", "Member_Id", "dbo.Members");
            DropIndex("dbo.Attandances", new[] { "Member_Id" });
            CreateTable(
                "dbo.AttandanceDDLs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Attandances", "AttandanceDdl_Id", c => c.Int());
            CreateIndex("dbo.Attandances", "AttandanceDdl_Id");
            AddForeignKey("dbo.Attandances", "AttandanceDdl_Id", "dbo.AttandanceDDLs", "Id");
            DropColumn("dbo.Attandances", "Hazri");
            DropColumn("dbo.Attandances", "Member_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attandances", "Member_Id", c => c.Int());
            AddColumn("dbo.Attandances", "Hazri", c => c.String());
            DropForeignKey("dbo.Attandances", "AttandanceDdl_Id", "dbo.AttandanceDDLs");
            DropIndex("dbo.Attandances", new[] { "AttandanceDdl_Id" });
            DropColumn("dbo.Attandances", "AttandanceDdl_Id");
            DropTable("dbo.AttandanceDDLs");
            CreateIndex("dbo.Attandances", "Member_Id");
            AddForeignKey("dbo.Attandances", "Member_Id", "dbo.Members", "Id");
        }
    }
}
