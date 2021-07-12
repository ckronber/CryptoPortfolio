namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptoPurchase", "TotalCryptoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CryptoPurchase", "TotalPurchasePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoPurchase", "TotalPurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CryptoPurchase", "TotalCryptoValue");
        }
    }
}
