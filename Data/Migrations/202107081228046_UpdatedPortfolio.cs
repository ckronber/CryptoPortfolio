namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPortfolio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Portfolio", "CryptoId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Portfolio", "CryptoId", c => c.Int(nullable: false));
        }
    }
}
