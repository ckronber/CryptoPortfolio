namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CryptoInfo",
                c => new
                    {
                        CryptoId = c.Int(nullable: false, identity: true),
                        Currency = c.String(nullable: false, maxLength: 3),
                        CryptoName = c.String(nullable: false, maxLength: 6),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseId = c.Int(),
                    })
                .PrimaryKey(t => t.CryptoId)
                .ForeignKey("dbo.CryptoPurchase", t => t.PurchaseId)
                .Index(t => t.PurchaseId);
            
            CreateTable(
                "dbo.CryptoPurchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GainPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Portfolio", t => t.PortfolioId)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Portfolio",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BullBear = c.String(),
                        CryptoUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.CryptoUser", t => t.CryptoUser_UserId)
                .Index(t => t.CryptoUser_UserId);
            
            CreateTable(
                "dbo.CryptoUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LogId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        TradeMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(nullable: false, maxLength: 3),
                        PreferredExchange = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CryptoInfo", "PurchaseId", "dbo.CryptoPurchase");
            DropForeignKey("dbo.CryptoPurchase", "PortfolioId", "dbo.Portfolio");
            DropForeignKey("dbo.Portfolio", "CryptoUser_UserId", "dbo.CryptoUser");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Portfolio", new[] { "CryptoUser_UserId" });
            DropIndex("dbo.CryptoPurchase", new[] { "PortfolioId" });
            DropIndex("dbo.CryptoInfo", new[] { "PurchaseId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.CryptoUser");
            DropTable("dbo.Portfolio");
            DropTable("dbo.CryptoPurchase");
            DropTable("dbo.CryptoInfo");
        }
    }
}
