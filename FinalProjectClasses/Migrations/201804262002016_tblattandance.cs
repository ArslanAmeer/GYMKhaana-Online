namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblattandance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attandances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hazri = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attandances", "Member_Id", "dbo.Members");
            DropIndex("dbo.Attandances", new[] { "Member_Id" });
            DropTable("dbo.Attandances");
        }
    }
}
