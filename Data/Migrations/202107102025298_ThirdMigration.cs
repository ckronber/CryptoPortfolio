namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Portfolio", "PurchaseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolio", "PurchaseId", c => c.Int());
        }
    }
}
