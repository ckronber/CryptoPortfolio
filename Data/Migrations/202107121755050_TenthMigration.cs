namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenthMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CryptoUser", new[] { "Email" });
            DropColumn("dbo.CryptoUser", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CryptoUser", "Email", c => c.String(maxLength: 50));
            CreateIndex("dbo.CryptoUser", "Email", unique: true);
        }
    }
}
