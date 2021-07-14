namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CryptoPurchase", "TotalCryptoValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoPurchase", "TotalCryptoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
