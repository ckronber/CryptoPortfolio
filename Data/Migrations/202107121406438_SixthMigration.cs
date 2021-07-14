namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CryptoInfo", "Gain");
            DropColumn("dbo.CryptoInfo", "GainPercent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoInfo", "GainPercent", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "Gain", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
