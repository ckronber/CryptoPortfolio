namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Portfolio", "CryptoUser_UserId", "dbo.CryptoUser");
            DropIndex("dbo.Portfolio", new[] { "CryptoUser_UserId" });
            AlterColumn("dbo.Portfolio", "CryptoUser_UserId", c => c.Int());
            CreateIndex("dbo.Portfolio", "CryptoUser_UserId");
            AddForeignKey("dbo.Portfolio", "CryptoUser_UserId", "dbo.CryptoUser", "UserId");
            DropColumn("dbo.Portfolio", "CryptoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Portfolio", "CryptoId", c => c.Int());
            DropForeignKey("dbo.Portfolio", "CryptoUser_UserId", "dbo.CryptoUser");
            DropIndex("dbo.Portfolio", new[] { "CryptoUser_UserId" });
            AlterColumn("dbo.Portfolio", "CryptoUser_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Portfolio", "CryptoUser_UserId");
            AddForeignKey("dbo.Portfolio", "CryptoUser_UserId", "dbo.CryptoUser", "UserId", cascadeDelete: true);
        }
    }
}
