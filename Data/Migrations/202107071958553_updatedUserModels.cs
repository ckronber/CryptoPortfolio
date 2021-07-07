namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUserModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CryptoUser", "PortfolioId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CryptoUser", "PortfolioId", c => c.Int(nullable: false));
        }
    }
}
