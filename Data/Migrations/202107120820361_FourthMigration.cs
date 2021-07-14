namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CryptoInfo", "Gain", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.CryptoInfo", "GainPercent", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CryptoInfo", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CryptoInfo", "Gain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
