namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptoPurchase", "CryptoId", c => c.Int(nullable: false));
            AddColumn("dbo.Portfolio", "PurchaseId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolio", "PurchaseId");
            DropColumn("dbo.CryptoPurchase", "CryptoId");
        }
    }
}
