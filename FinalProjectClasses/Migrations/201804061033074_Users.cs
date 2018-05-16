namespace FinalProjectClasses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Fullname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Loginid", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Shift", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FullAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "State", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "State", c => c.String());
            AlterColumn("dbo.Users", "City", c => c.String());
            AlterColumn("dbo.Users", "FullAddress", c => c.String());
            AlterColumn("dbo.Users", "Shift", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "ImageUrl", c => c.String());
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Loginid", c => c.String());
            AlterColumn("dbo.Users", "Fullname", c => c.String());
        }
    }
}
