namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolio", "PurchaseId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolio", "PurchaseId");
        }
    }
}
