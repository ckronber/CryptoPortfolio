namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cryptoUserChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CryptoPurchase", "CryptoInfo_CryptoId", "dbo.CryptoInfo");
            DropIndex("dbo.CryptoPurchase", new[] { "CryptoInfo_CryptoId" });
            DropColumn("dbo.CryptoInfo", "PurchaseId");
            RenameColumn(table: "dbo.CryptoInfo", name: "CryptoInfo_CryptoId", newName: "PurchaseId");
            RenameColumn(table: "dbo.Portfolio", name: "User_UserId", newName: "CryptoUser_UserId");
            RenameIndex(table: "dbo.Portfolio", name: "IX_User_UserId", newName: "IX_CryptoUser_UserId");
            AddColumn("dbo.CryptoUser", "FirstName", c => c.String());
            AddColumn("dbo.CryptoUser", "LastName", c => c.String());
            AddColumn("dbo.CryptoUser", "Email", c => c.String());
            AddColumn("dbo.CryptoUser", "TradeMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CryptoUser", "Currency", c => c.String());
            AddColumn("dbo.Portfolio", "CryptoId", c => c.Int(nullable: false));
            AddColumn("dbo.CryptoPurchase", "GainPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CryptoInfo", "PurchaseId", c => c.Int(nullable: false));
            AlterColumn("dbo.CryptoUser", "PortfolioId", c => c.Int(nullable: false));
            CreateIndex("dbo.CryptoInfo", "PurchaseId");
            AddForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase", "PurchaseId", cascadeDelete: true);
            DropColumn("dbo.CryptoPurchase", "TotalGain");
            DropColumn("dbo.CryptoPurchase", "CryptoInfo_CryptoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoPurchase", "CryptoInfo_CryptoId", c => c.Int());
            AddColumn("dbo.CryptoPurchase", "TotalGain", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase");
            DropIndex("dbo.CryptoInfo", new[] { "PurchaseId" });
            AlterColumn("dbo.CryptoUser", "PortfolioId", c => c.Int());
            AlterColumn("dbo.CryptoInfo", "PurchaseId", c => c.Int());
            DropColumn("dbo.CryptoPurchase", "GainPercent");
            DropColumn("dbo.Portfolio", "CryptoId");
            DropColumn("dbo.CryptoUser", "Currency");
            DropColumn("dbo.CryptoUser", "TradeMoney");
            DropColumn("dbo.CryptoUser", "Email");
            DropColumn("dbo.CryptoUser", "LastName");
            DropColumn("dbo.CryptoUser", "FirstName");
            RenameIndex(table: "dbo.Portfolio", name: "IX_CryptoUser_UserId", newName: "IX_User_UserId");
            RenameColumn(table: "dbo.Portfolio", name: "CryptoUser_UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.CryptoInfo", name: "PurchaseId", newName: "CryptoInfo_CryptoId");
            AddColumn("dbo.CryptoInfo", "PurchaseId", c => c.Int());
            CreateIndex("dbo.CryptoPurchase", "CryptoInfo_CryptoId");
            AddForeignKey("dbo.CryptoPurchase", "CryptoInfo_CryptoId", "dbo.CryptoInfo", "CryptoId");
        }
    }
}
