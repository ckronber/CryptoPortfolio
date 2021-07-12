namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptoInfo", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "Gain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoInfo", "PurchaseDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.CryptoPurchase", "TotalCryptoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoPurchase", "DateAdded", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.CryptoInfo", "Price");
            DropColumn("dbo.CryptoPurchase", "Name");
            DropColumn("dbo.CryptoPurchase", "PurchasePrice");
            DropColumn("dbo.CryptoPurchase", "PurchaseAmount");
            DropColumn("dbo.CryptoPurchase", "Gain");
            DropColumn("dbo.CryptoPurchase", "GainPercent");
            DropColumn("dbo.CryptoPurchase", "PurchaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoPurchase", "PurchaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.CryptoPurchase", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoPurchase", "Gain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoPurchase", "PurchaseAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoPurchase", "PurchasePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoPurchase", "Name", c => c.String());
            AddColumn("dbo.CryptoInfo", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CryptoPurchase", "DateAdded");
            DropColumn("dbo.CryptoPurchase", "TotalCryptoValue");
            DropColumn("dbo.CryptoInfo", "PurchaseDate");
            DropColumn("dbo.CryptoInfo", "GainPercent");
            DropColumn("dbo.CryptoInfo", "Gain");
            DropColumn("dbo.CryptoInfo", "CurrentPrice");
            DropColumn("dbo.CryptoInfo", "PurchasePrice");
        }
    }
}
