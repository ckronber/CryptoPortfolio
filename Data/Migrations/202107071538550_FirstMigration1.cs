namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase");
            DropIndex("dbo.CryptoInfo", new[] { "PurchaseId" });
            AlterColumn("dbo.CryptoInfo", "PurchaseId", c => c.Int());
            CreateIndex("dbo.CryptoInfo", "PurchaseId");
            AddForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase", "PurchaseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase");
            DropIndex("dbo.CryptoInfo", new[] { "PurchaseId" });
            AlterColumn("dbo.CryptoInfo", "PurchaseId", c => c.Int(nullable: false));
            CreateIndex("dbo.CryptoInfo", "PurchaseId");
            AddForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase", "PurchaseId", cascadeDelete: true);
        }
    }
}
