namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationTwelve : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Portfolio", "TotalCryptoValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolio", "TotalCryptoValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
