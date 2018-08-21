namespace FinalProjectClasses.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatePaymentTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "TotalPaidAmount", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Payments", "TotalPaidAmount");
        }
    }
}
