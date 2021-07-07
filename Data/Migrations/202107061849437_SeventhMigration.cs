namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CryptoUser", "PortfolioId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CryptoUser", "PortfolioId");
        }
    }
}
