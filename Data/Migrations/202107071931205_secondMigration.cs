namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CryptoInfo", "Currency", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CryptoInfo", "CryptoName", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CryptoInfo", "CryptoName", c => c.String(nullable: false));
            AlterColumn("dbo.CryptoInfo", "Currency", c => c.String(nullable: false));
        }
    }
}
