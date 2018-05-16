namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPdateGenderRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rank = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Gender_Id", c => c.Int());
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            CreateIndex("dbo.Users", "Gender_Id");
            CreateIndex("dbo.Users", "Role_Id");
            AddForeignKey("dbo.Users", "Gender_Id", "dbo.Genders", "Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Users", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "Gender_Id" });
            DropColumn("dbo.Users", "Role_Id");
            DropColumn("dbo.Users", "Gender_Id");
            DropTable("dbo.Roles");
            DropTable("dbo.Genders");
        }
    }
}
