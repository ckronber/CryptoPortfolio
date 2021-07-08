namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ef6differentMethod : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CryptoUser", "PortfolioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoUser", "PortfolioId", c => c.Int());
        }
    }
}
