namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationEleven : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolio", "TotalCryptoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolio", "TotalCryptoValue");
        }
    }
}
