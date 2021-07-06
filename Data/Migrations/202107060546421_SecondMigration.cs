namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CryptoInfo", "Price");
            DropColumn("dbo.CryptoInfo", "TotalValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoInfo", "TotalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
