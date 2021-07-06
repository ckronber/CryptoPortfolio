namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptoInfo", "TotalValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CryptoInfo", "TotalValue");
        }
    }
}
