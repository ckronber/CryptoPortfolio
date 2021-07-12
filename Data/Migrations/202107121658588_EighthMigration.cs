namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EighthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptoPurchase", "TotalCryptoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CryptoPurchase", "TotalCryptoValue");
        }
    }
}
